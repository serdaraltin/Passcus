namespace Passcus
{
    partial class security_data
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
            this.label1 = new System.Windows.Forms.Label();
            this.text_mail = new System.Windows.Forms.TextBox();
            this.combo_question = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_reply = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "E-posta Adresi :";
            // 
            // text_mail
            // 
            this.text_mail.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.text_mail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_mail.Location = new System.Drawing.Point(104, 17);
            this.text_mail.Name = "text_mail";
            this.text_mail.Size = new System.Drawing.Size(205, 20);
            this.text_mail.TabIndex = 1;
            // 
            // combo_question
            // 
            this.combo_question.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.combo_question.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combo_question.FormattingEnabled = true;
            this.combo_question.Items.AddRange(new object[] {
            "Çocukluk arkadaşının adı ?",
            "Annenin kızlık soyadı ?",
            "En sevdiğin yemek ?",
            "En sevdiğin renk ?"});
            this.combo_question.Location = new System.Drawing.Point(104, 43);
            this.combo_question.Name = "combo_question";
            this.combo_question.Size = new System.Drawing.Size(205, 21);
            this.combo_question.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Güvenlik Sorusu :";
            // 
            // text_reply
            // 
            this.text_reply.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.text_reply.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_reply.Location = new System.Drawing.Point(104, 70);
            this.text_reply.Name = "text_reply";
            this.text_reply.Size = new System.Drawing.Size(205, 20);
            this.text_reply.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Cevap :";
            // 
            // text_phone
            // 
            this.text_phone.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.text_phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_phone.Location = new System.Drawing.Point(104, 96);
            this.text_phone.Name = "text_phone";
            this.text_phone.Size = new System.Drawing.Size(205, 20);
            this.text_phone.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Telefon : +90";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(104, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // security_data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(322, 151);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.text_phone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_reply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.combo_question);
            this.Controls.Add(this.text_mail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "security_data";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Güvenlik Bilgileri";
            this.Load += new System.EventHandler(this.security_data_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_mail;
        private System.Windows.Forms.ComboBox combo_question;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_reply;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_phone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}