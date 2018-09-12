namespace Passcus
{
    partial class password_refresh
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(password_refresh));
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_wath = new System.Windows.Forms.Label();
            this.label_mail_newpass = new System.Windows.Forms.Label();
            this.button_mailcode = new System.Windows.Forms.Button();
            this.linklabel_mail = new System.Windows.Forms.LinkLabel();
            this.button_mail = new System.Windows.Forms.Button();
            this.text_mailcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.text_mail = new System.Windows.Forms.TextBox();
            this.label_mail = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_sec = new System.Windows.Forms.Button();
            this.text_reply_sec = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_ques_sec = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timer_watch = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon_mail = new System.Windows.Forms.NotifyIcon(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(61, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Telefon";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(82, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "E-Posta";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(150, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(103, 17);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.Text = "Güvenlik Sorusu";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doğrulama Seçenekleri";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label_wath);
            this.panel1.Controls.Add(this.label_mail_newpass);
            this.panel1.Controls.Add(this.button_mailcode);
            this.panel1.Controls.Add(this.linklabel_mail);
            this.panel1.Controls.Add(this.button_mail);
            this.panel1.Controls.Add(this.text_mailcode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.text_mail);
            this.panel1.Controls.Add(this.label_mail);
            this.panel1.Location = new System.Drawing.Point(12, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 172);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // label_wath
            // 
            this.label_wath.AutoSize = true;
            this.label_wath.Location = new System.Drawing.Point(96, 114);
            this.label_wath.Name = "label_wath";
            this.label_wath.Size = new System.Drawing.Size(16, 13);
            this.label_wath.TabIndex = 7;
            this.label_wath.Text = "...";
            // 
            // label_mail_newpass
            // 
            this.label_mail_newpass.AutoSize = true;
            this.label_mail_newpass.Location = new System.Drawing.Point(103, 143);
            this.label_mail_newpass.Name = "label_mail_newpass";
            this.label_mail_newpass.Size = new System.Drawing.Size(0, 13);
            this.label_mail_newpass.TabIndex = 6;
            // 
            // button_mailcode
            // 
            this.button_mailcode.Enabled = false;
            this.button_mailcode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_mailcode.Location = new System.Drawing.Point(13, 137);
            this.button_mailcode.Name = "button_mailcode";
            this.button_mailcode.Size = new System.Drawing.Size(75, 23);
            this.button_mailcode.TabIndex = 5;
            this.button_mailcode.Text = "Onayla";
            this.button_mailcode.UseVisualStyleBackColor = true;
            this.button_mailcode.Click += new System.EventHandler(this.button_mailcode_Click);
            // 
            // linklabel_mail
            // 
            this.linklabel_mail.ActiveLinkColor = System.Drawing.Color.DodgerBlue;
            this.linklabel_mail.AutoSize = true;
            this.linklabel_mail.Enabled = false;
            this.linklabel_mail.Location = new System.Drawing.Point(177, 64);
            this.linklabel_mail.Name = "linklabel_mail";
            this.linklabel_mail.Size = new System.Drawing.Size(76, 13);
            this.linklabel_mail.TabIndex = 4;
            this.linklabel_mail.TabStop = true;
            this.linklabel_mail.Text = "Tekrar Gönder";
            this.linklabel_mail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabel_mail_LinkClicked);
            // 
            // button_mail
            // 
            this.button_mail.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_mail.Location = new System.Drawing.Point(15, 56);
            this.button_mail.Name = "button_mail";
            this.button_mail.Size = new System.Drawing.Size(75, 23);
            this.button_mail.TabIndex = 3;
            this.button_mail.Text = "Gönder";
            this.button_mail.UseVisualStyleBackColor = true;
            this.button_mail.Click += new System.EventHandler(this.button_mail_Click);
            // 
            // text_mailcode
            // 
            this.text_mailcode.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.text_mailcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_mailcode.Enabled = false;
            this.text_mailcode.Location = new System.Drawing.Point(13, 111);
            this.text_mailcode.Name = "text_mailcode";
            this.text_mailcode.Size = new System.Drawing.Size(74, 20);
            this.text_mailcode.TabIndex = 1;
            this.text_mailcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_mailcode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Güvenlik Kodu";
            // 
            // text_mail
            // 
            this.text_mail.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.text_mail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_mail.Location = new System.Drawing.Point(15, 31);
            this.text_mail.Name = "text_mail";
            this.text_mail.Size = new System.Drawing.Size(238, 20);
            this.text_mail.TabIndex = 1;
            // 
            // label_mail
            // 
            this.label_mail.AutoSize = true;
            this.label_mail.Location = new System.Drawing.Point(12, 14);
            this.label_mail.Name = "label_mail";
            this.label_mail.Size = new System.Drawing.Size(82, 13);
            this.label_mail.TabIndex = 0;
            this.label_mail.Text = "E-Posta Adresi :";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button_sec);
            this.panel2.Controls.Add(this.text_reply_sec);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label_ques_sec);
            this.panel2.Location = new System.Drawing.Point(12, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 172);
            this.panel2.TabIndex = 7;
            this.panel2.Visible = false;
            // 
            // button_sec
            // 
            this.button_sec.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button_sec.Location = new System.Drawing.Point(15, 83);
            this.button_sec.Name = "button_sec";
            this.button_sec.Size = new System.Drawing.Size(75, 23);
            this.button_sec.TabIndex = 3;
            this.button_sec.Text = "Onayla";
            this.button_sec.UseVisualStyleBackColor = true;
            this.button_sec.Click += new System.EventHandler(this.button_sec_Click);
            // 
            // text_reply_sec
            // 
            this.text_reply_sec.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.text_reply_sec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_reply_sec.Location = new System.Drawing.Point(15, 58);
            this.text_reply_sec.Name = "text_reply_sec";
            this.text_reply_sec.Size = new System.Drawing.Size(238, 20);
            this.text_reply_sec.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Yanıt";
            // 
            // label_ques_sec
            // 
            this.label_ques_sec.AutoSize = true;
            this.label_ques_sec.Location = new System.Drawing.Point(12, 14);
            this.label_ques_sec.Name = "label_ques_sec";
            this.label_ques_sec.Size = new System.Drawing.Size(91, 13);
            this.label_ques_sec.TabIndex = 0;
            this.label_ques_sec.Text = "Güvenlik Sorusu :";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.linkLabel2);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.textBox3);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.textBox5);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(12, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(268, 172);
            this.panel3.TabIndex = 7;
            this.panel3.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Yönlendiriliyorsunuz...";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(96, 109);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Onayla";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(101, 66);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(76, 13);
            this.linkLabel2.TabIndex = 4;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Tekrar Gönder";
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Location = new System.Drawing.Point(17, 59);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 3;
            this.button5.Text = "Gönder";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(16, 111);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(74, 20);
            this.textBox3.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Güvenlik Kodu";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Location = new System.Drawing.Point(45, 33);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(132, 20);
            this.textBox5.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "+90";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Tel No : ";
            // 
            // timer_watch
            // 
            this.timer_watch.Interval = 1000;
            this.timer_watch.Tick += new System.EventHandler(this.timer_watch_Tick);
            // 
            // notifyIcon_mail
            // 
            this.notifyIcon_mail.Text = "PassCus";
            this.notifyIcon_mail.Visible = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Aqua;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(11, 241);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(105, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Bunlara Erişimim Yok";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // password_refresh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(292, 259);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "password_refresh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Yenileme";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.password_refresh_FormClosing);
            this.Load += new System.EventHandler(this.password_refresh_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_mail_newpass;
        private System.Windows.Forms.Button button_mailcode;
        private System.Windows.Forms.LinkLabel linklabel_mail;
        private System.Windows.Forms.Button button_mail;
        private System.Windows.Forms.TextBox text_mailcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_mail;
        private System.Windows.Forms.Label label_mail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_sec;
        private System.Windows.Forms.TextBox text_reply_sec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_ques_sec;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer_watch;
        private System.Windows.Forms.Label label_wath;
        private System.Windows.Forms.NotifyIcon notifyIcon_mail;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}