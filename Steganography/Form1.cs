using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
using System.Text;

// TODO: For now is only Encrypting PNG and BMP, when it saves jpg the image quality is lowered and fuck up all binary data
namespace Steganography {
    public partial class Steganography : Form {
        public Steganography() {
            InitializeComponent();
            this.MaximizeBox = false;
            //this.MinimizeBox = false;
        }

        private void btn_Decrypt_Click(object sender, EventArgs e) {
            if (txt_Container.Text == "") {
                MessageBox.Show("Select an image.");
                return;
            }

            try {
                string imageFile = txt_Container.Text;
                StringBuilder stBuilder = new StringBuilder();
                Bitmap image = new Bitmap(imageFile);
                int x = 0, y = 0;
                Color color;

                if (ckb_Compress.Checked) { // Minimum Significative bit
                    for (x = 0; x < image.Width; x++) {
                        for (y = 0; y < image.Height; y++) {
                            color = image.GetPixel(x, y);
                            stBuilder.Append(color.ToArgb() % 2);
                        }
                    }
                } else { // Minimum significative bit inside the RGB
                    if (txt_RGBOrder.TextLength != 3) {
                        MessageBox.Show("You have to inform the RGB order to decrypt.");
                        return;
                    }

                    char elem_1 = txt_RGBOrder.Text[0],
                         elem_2 = txt_RGBOrder.Text[1],
                         elem_3 = txt_RGBOrder.Text[2];

                    for (x = 0; x < image.Width; x++) {
                        for (y = 0; y < image.Height; y++) {
                            color = image.GetPixel(x, y);

                            stBuilder.Append(getByte(color, elem_1) % 2);
                            stBuilder.Append(getByte(color, elem_2) % 2);
                            stBuilder.Append(getByte(color, elem_3) % 2);
                        }
                    }
                }

                //////////////////////////////////////////////////

                while (stBuilder.Length % 8 != 0) {
                    stBuilder.Append("0");
                }

                List<byte> archive = new List<byte>();

                archive = getBytes(stBuilder.ToString());

                while (archive.Last() == 0x00) {
                    archive.RemoveAt(archive.Count - 1);
                }

                //1111 1111 -- END
                if (archive.Last() == 0xFF) {
                    archive.RemoveAt(archive.Count - 1);

                    string fileType = "";
                    List<byte> byteFileType = new List<byte>();

                    x = 0;
                    while (archive.Last() != 0xFF) {
                        byteFileType.Add(archive.Last());
                        archive.RemoveAt(archive.Count - 1);
                        x++;
                    }
                    archive.RemoveAt(archive.Count - 1);

                    //gpj --> jpg
                    byteFileType = Enumerable.Reverse(byteFileType).ToList();
                    fileType = Encoding.UTF8.GetString(byteFileType.ToArray());

                    using (FileStream file = File.Create(imageFile + "_decrypted." + fileType)) {
                        file.Write(archive.ToArray(), 0, archive.Count);
                        file.Close();
                    }
                } else {
                    MessageBox.Show("This image doesn't contain a cryptographed archive.");
                }


            } catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        private void btn_Encrypt_Click(object sender, EventArgs e) {
            if (txt_Container.Text == "") {
                MessageBox.Show("Select an image.");
                return;
            }

            if (txt_Content.Text == "") {
                MessageBox.Show("Select an archive.");
                return;
            }

            try {
                string imageFile = txt_Container.Text;
                string archiveType = txt_Content.Text.Split('.').Last();
                int x = 0, y = 0, z = 0;

                List<byte> listBytes = new List<byte>();
                List<int> listBit = new List<int>();
                Bitmap image = new Bitmap(imageFile);
                Bitmap editImage = image.Clone(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                //image.Dispose();
                Color color;

                using (FileStream fStream = File.OpenRead(txt_Content.Text)) {
                    var Byte = 0;

                    while ((Byte = fStream.ReadByte()) > -1) {
                        listBytes.Add(Convert.ToByte(Byte));
                    }

                    fStream.Dispose();
                }

                /* Validation */
                listBytes.Add(0xFF);
                /* Archive Type */
                for (x = 0; x < archiveType.Length; x++) {
                    listBytes.Add(Convert.ToByte(archiveType[x]));
                }
                /* END Archive Type */
                listBytes.Add(0xFF);
                /* END Validation */

                foreach (var Byte in listBytes) {
                    string stringByte = string.Format("{0,8}", Convert.ToString(Byte, 2)).Replace(' ', '0');
                    foreach (var bit in stringByte) {
                        listBit.Add(bit == 49 ? 1 : 0);
                    }
                }

                long bitNeeded = listBit.Count();

                //////////////////
                if (ckb_Compress.Checked) { // Minimum Significative bit
                    int tempColor = 0;

                    if ((image.Width * image.Height) < bitNeeded) {
                        MessageBox.Show("The image is too small to insert the archive.");
                        return;
                    }

                    for (x = 0; x < editImage.Width; x++) {
                        for (y = 0; y < editImage.Height; y++) {
                            color = editImage.GetPixel(x, y);
                            tempColor = color.ToArgb();

                            if (listBit.Count() > z) {
                                if (tempColor % 2 != listBit[z]) {
                                    tempColor = tempColor > 0 ? tempColor - 1 : tempColor + 1;
                                    editImage.SetPixel(x, y, Color.FromArgb(tempColor));
                                }
                                z++;
                            } else {
                                if (tempColor % 2 != 0) {
                                    tempColor = tempColor > 0 ? tempColor - 1 : tempColor + 1;
                                    editImage.SetPixel(x, y, Color.FromArgb(tempColor));
                                }
                            }
                        }
                    }
                } else { // Minimum significative bit inside the RGB
                    int tempColorA = 0, tempColor1 = 0, tempColor2 = 0, tempColor3 = 0;

                    if ((image.Width * image.Height * 3) < bitNeeded) {
                        MessageBox.Show("The image is too small to insert the archive.");
                        return;
                    }

                    if (txt_RGBOrder.TextLength != 3) {
                        MessageBox.Show("You have to inform the RGB order to decrypt.");
                        return;
                    }

                    char elem_1 = txt_RGBOrder.Text[0],
                         elem_2 = txt_RGBOrder.Text[1],
                         elem_3 = txt_RGBOrder.Text[2];

                    for (x = 0; x < editImage.Width; x++) {
                        for (y = 0; y < editImage.Height; y++) {
                            color = editImage.GetPixel(x, y);
                            tempColorA = color.A;

                            tempColor1 = getByte(color, elem_1);
                            if (listBit.Count() > z) {
                                if (tempColor1 % 2 != listBit[z]) {
                                    tempColor1 = tempColor1 > 0 ? tempColor1 - 1 : tempColor1 + 1;
                                }
                                z++;
                            } else {
                                if (tempColor1 % 2 != 0) {
                                    tempColor1 = tempColor1 > 0 ? tempColor1 - 1 : tempColor1 + 1;
                                }
                            }

                            tempColor2 = getByte(color, elem_2);
                            if (listBit.Count() > z) {
                                if (tempColor2 % 2 != listBit[z]) {
                                    tempColor2 = tempColor2 > 0 ? tempColor2 - 1 : tempColor2 + 1;
                                }
                                z++;
                            } else {
                                if (tempColor2 % 2 != 0) {
                                    tempColor2 = tempColor2 > 0 ? tempColor2 - 1 : tempColor2 + 1;
                                }
                            }

                            tempColor3 = getByte(color, elem_3);
                            if (listBit.Count() > z) {
                                if (tempColor3 % 2 != listBit[z]) {
                                    tempColor3 = tempColor3 > 0 ? tempColor3 - 1 : tempColor3 + 1;
                                }
                                z++;
                            } else {
                                if (tempColor3 % 2 != 0) {
                                    tempColor3 = tempColor3 > 0 ? tempColor3 - 1 : tempColor3 + 1;
                                }
                            }

                            Color tempColor = getColor(elem_1, elem_2, elem_3, tempColorA, tempColor1, tempColor2, tempColor3);

                            if (color != tempColor) {
                                editImage.SetPixel(x, y, tempColor);
                            }
                        }
                    }


                    editImage.Save("imageEncrypted_" + DateTime.Now.ToString("yyyyMMddHHmm") + "." + archiveType);
                    image.Dispose();
                    editImage.Dispose();

                    MessageBox.Show("Archive have been encryptographed.");
                }
            } catch (Exception ex) {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_Container_Click(object sender, EventArgs e) {
            txt_Container.Text = getFile();
        }
        private void btn_Container_Click(object sender, EventArgs e) {
            txt_Container.Text = getFile();
        }
        private void txt_Content_Click(object sender, EventArgs e) {
            txt_Content.Text = getFile();
        }
        private void btn_Content_Click(object sender, EventArgs e) {
            txt_Content.Text = getFile();
        }

        private void ckb_Compress_CheckedChanged(object sender, EventArgs e) {
            txt_RGBOrder.Visible = !ckb_Compress.Checked;
        }
        private void txt_RGBOrder_KeyPress(object sender, KeyPressEventArgs e) {
            var sKeys = "RGB\b";
            var key = e.KeyChar.ToString().ToUpper();

            if (!sKeys.Contains(key) || txt_RGBOrder.Text.ToUpper().Contains(key)) {
                e.Handled = true;
            }
        }

        private string getFile() {
            openFileDialog1.Reset();
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Image Files (*.bmp, *.jpg)|*.bmp;*.jpg";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                return openFileDialog1.FileName;
            }

            return null;
        }
        private int getByte(Color color, char rgb) {
            switch (rgb) {
                case 'R': return Convert.ToInt32(color.R);
                case 'G': return Convert.ToInt32(color.G);
                case 'B': return Convert.ToInt32(color.B);
            }

            return 0;
        }
        private List<byte> getBytes(string bitString) {
            return Enumerable.Range(0, bitString.Length / 8).
                Select(pos => Convert.ToByte(
                    bitString.Substring(pos * 8, 8),
                    2)
                ).ToList();
        }
        private Color getColor(char rgb1, char rgb2, char rgb3, int colorA, int color1, int color2, int color3) {
            int colorR = 0, colorG = 0, colorB = 0;

            switch (rgb1) {
                case 'R': colorR = color1; break;
                case 'G': colorG = color1; break;
                case 'B': colorB = color1; break;
            }

            switch (rgb2) {
                case 'R': colorR = color2; break;
                case 'G': colorG = color2; break;
                case 'B': colorB = color2; break;
            }

            switch (rgb3) {
                case 'R': colorR = color3; break;
                case 'G': colorG = color3; break;
                case 'B': colorB = color3; break;
            }

            return Color.FromArgb(colorA, colorR, colorG, colorB);

        }
        private int[] getBytes(StringBuilder stBuilder) {
            return stBuilder.ToString().Select(p => Convert.ToInt32(p)).ToArray();
        }
    }
}
