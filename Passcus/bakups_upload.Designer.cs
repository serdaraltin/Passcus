namespace Passcus
{
    partial class bakups_upload
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bakups_upload));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttun_sec = new System.Windows.Forms.Button();
            this.button_test = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yol";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(36, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(193, 20);
            this.textBox1.TabIndex = 0;
            // 
            // buttun_sec
            // 
            this.buttun_sec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttun_sec.Location = new System.Drawing.Point(235, 13);
            this.buttun_sec.Name = "buttun_sec";
            this.buttun_sec.Size = new System.Drawing.Size(27, 23);
            this.buttun_sec.TabIndex = 1;
            this.buttun_sec.Text = "...";
            this.buttun_sec.UseVisualStyleBackColor = true;
            this.buttun_sec.Click += new System.EventHandler(this.buttun_sec_Click);
            // 
            // button_test
            // 
            this.button_test.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_test.Location = new System.Drawing.Point(106, 42);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(75, 25);
            this.button_test.TabIndex = 2;
            this.button_test.Text = "Test Et";
            this.button_test.UseVisualStyleBackColor = true;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(187, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Yükle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bakups_upload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(271, 79);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_test);
            this.Controls.Add(this.buttun_sec);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "bakups_upload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yedek Yükle";
            this.Load += new System.EventHandler(this.bakups_upload_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttun_sec;
        private System.Windows.Forms.Button button_test;
        private System.Windows.Forms.Button button1;
    }
}