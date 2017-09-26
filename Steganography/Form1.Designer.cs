namespace Steganography {
    partial class Steganography {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Steganography));
            this.txt_Container = new System.Windows.Forms.TextBox();
            this.btn_decrypt = new System.Windows.Forms.Button();
            this.txt_Content = new System.Windows.Forms.TextBox();
            this.btn_encrypt = new System.Windows.Forms.Button();
            this.btn_Container = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_Content = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckb_Compress = new System.Windows.Forms.CheckBox();
            this.txt_RGBOrder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Container
            // 
            this.txt_Container.Location = new System.Drawing.Point(11, 24);
            this.txt_Container.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Container.Name = "txt_Container";
            this.txt_Container.ReadOnly = true;
            this.txt_Container.Size = new System.Drawing.Size(194, 20);
            this.txt_Container.TabIndex = 0;
            this.txt_Container.Click += new System.EventHandler(this.txt_Container_Click);
            // 
            // btn_decrypt
            // 
            this.btn_decrypt.Location = new System.Drawing.Point(57, 130);
            this.btn_decrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btn_decrypt.Name = "btn_decrypt";
            this.btn_decrypt.Size = new System.Drawing.Size(65, 23);
            this.btn_decrypt.TabIndex = 1;
            this.btn_decrypt.Text = "Decrypt";
            this.btn_decrypt.UseVisualStyleBackColor = true;
            this.btn_decrypt.Click += new System.EventHandler(this.btn_Decrypt_Click);
            // 
            // txt_Content
            // 
            this.txt_Content.Location = new System.Drawing.Point(10, 71);
            this.txt_Content.Margin = new System.Windows.Forms.Padding(2);
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.ReadOnly = true;
            this.txt_Content.Size = new System.Drawing.Size(195, 20);
            this.txt_Content.TabIndex = 2;
            this.txt_Content.Click += new System.EventHandler(this.txt_Content_Click);
            // 
            // btn_encrypt
            // 
            this.btn_encrypt.Location = new System.Drawing.Point(127, 130);
            this.btn_encrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btn_encrypt.Name = "btn_encrypt";
            this.btn_encrypt.Size = new System.Drawing.Size(65, 23);
            this.btn_encrypt.TabIndex = 3;
            this.btn_encrypt.Text = "Encrypt";
            this.btn_encrypt.UseVisualStyleBackColor = true;
            this.btn_encrypt.Click += new System.EventHandler(this.btn_Encrypt_Click);
            // 
            // btn_Container
            // 
            this.btn_Container.Image = ((System.Drawing.Image)(resources.GetObject("btn_Container.Image")));
            this.btn_Container.Location = new System.Drawing.Point(210, 19);
            this.btn_Container.Name = "btn_Container";
            this.btn_Container.Size = new System.Drawing.Size(30, 28);
            this.btn_Container.TabIndex = 4;
            this.btn_Container.UseVisualStyleBackColor = true;
            this.btn_Container.Click += new System.EventHandler(this.btn_Container_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_Content
            // 
            this.btn_Content.Image = ((System.Drawing.Image)(resources.GetObject("btn_Content.Image")));
            this.btn_Content.Location = new System.Drawing.Point(209, 66);
            this.btn_Content.Name = "btn_Content";
            this.btn_Content.Size = new System.Drawing.Size(30, 28);
            this.btn_Content.TabIndex = 5;
            this.btn_Content.UseVisualStyleBackColor = true;
            this.btn_Content.Click += new System.EventHandler(this.btn_Content_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Image Container";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Content";
            // 
            // ckb_Compress
            // 
            this.ckb_Compress.AutoSize = true;
            this.ckb_Compress.Location = new System.Drawing.Point(10, 96);
            this.ckb_Compress.Name = "ckb_Compress";
            this.ckb_Compress.Size = new System.Drawing.Size(149, 17);
            this.ckb_Compress.TabIndex = 8;
            this.ckb_Compress.Text = "Most Compressed Method";
            this.ckb_Compress.UseVisualStyleBackColor = true;
            this.ckb_Compress.CheckedChanged += new System.EventHandler(this.ckb_Compress_CheckedChanged);
            // 
            // txt_RGBOrder
            // 
            this.txt_RGBOrder.Location = new System.Drawing.Point(183, 100);
            this.txt_RGBOrder.MaxLength = 3;
            this.txt_RGBOrder.Name = "txt_RGBOrder";
            this.txt_RGBOrder.Size = new System.Drawing.Size(57, 20);
            this.txt_RGBOrder.TabIndex = 9;
            this.txt_RGBOrder.Text = "RGB";
            this.txt_RGBOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_RGBOrder_KeyPress);
            // 
            // Steganography
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 164);
            this.Controls.Add(this.txt_RGBOrder);
            this.Controls.Add(this.ckb_Compress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Content);
            this.Controls.Add(this.btn_Container);
            this.Controls.Add(this.btn_encrypt);
            this.Controls.Add(this.txt_Content);
            this.Controls.Add(this.btn_decrypt);
            this.Controls.Add(this.txt_Container);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Steganography";
            this.Text = "Steganography";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Container;
        private System.Windows.Forms.Button btn_decrypt;
        private System.Windows.Forms.TextBox txt_Content;
        private System.Windows.Forms.Button btn_encrypt;
        private System.Windows.Forms.Button btn_Container;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_Content;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckb_Compress;
        private System.Windows.Forms.TextBox txt_RGBOrder;
    }
}

