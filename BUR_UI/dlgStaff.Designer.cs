namespace BUR_UI
{
    partial class dlgStaff
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
            this.btnStaffOK = new System.Windows.Forms.Button();
            this.cmbPayee = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStaffSubText = new System.Windows.Forms.Label();
            this.cmbStaffType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseImage = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.picStaffImage = new System.Windows.Forms.PictureBox();
            this.pnlPasswordConceal = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picStaffImage)).BeginInit();
            this.pnlPasswordConceal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStaffOK
            // 
            this.btnStaffOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStaffOK.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnStaffOK.Location = new System.Drawing.Point(376, 387);
            this.btnStaffOK.Name = "btnStaffOK";
            this.btnStaffOK.Size = new System.Drawing.Size(90, 31);
            this.btnStaffOK.TabIndex = 19;
            this.btnStaffOK.Text = "OK";
            this.btnStaffOK.UseVisualStyleBackColor = true;
            this.btnStaffOK.Click += new System.EventHandler(this.btnStaffOK_Click);
            // 
            // cmbPayee
            // 
            this.cmbPayee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPayee.FormattingEnabled = true;
            this.cmbPayee.Location = new System.Drawing.Point(19, 77);
            this.cmbPayee.Name = "cmbPayee";
            this.cmbPayee.Size = new System.Drawing.Size(437, 24);
            this.cmbPayee.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Payee";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(20, 188);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(212, 22);
            this.txtPassword.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password";
            // 
            // lblStaffSubText
            // 
            this.lblStaffSubText.AutoSize = true;
            this.lblStaffSubText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffSubText.Location = new System.Drawing.Point(13, 13);
            this.lblStaffSubText.Name = "lblStaffSubText";
            this.lblStaffSubText.Size = new System.Drawing.Size(57, 20);
            this.lblStaffSubText.TabIndex = 10;
            this.lblStaffSubText.Text = "label1";
            // 
            // cmbStaffType
            // 
            this.cmbStaffType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStaffType.FormattingEnabled = true;
            this.cmbStaffType.Items.AddRange(new object[] {
            "Budget",
            "Budget Head",
            "Admin"});
            this.cmbStaffType.Location = new System.Drawing.Point(19, 133);
            this.cmbStaffType.Name = "cmbStaffType";
            this.cmbStaffType.Size = new System.Drawing.Size(223, 24);
            this.cmbStaffType.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Staff Type";
            // 
            // txtImage
            // 
            this.txtImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImage.Location = new System.Drawing.Point(20, 253);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(340, 22);
            this.txtImage.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Image";
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseImage.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBrowseImage.Location = new System.Drawing.Point(370, 248);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(90, 31);
            this.btnBrowseImage.TabIndex = 24;
            this.btnBrowseImage.Text = "Browse...";
            this.btnBrowseImage.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(244, 188);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(212, 22);
            this.txtConfirmPassword.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(241, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Confirm Password";
            // 
            // picStaffImage
            // 
            this.picStaffImage.Location = new System.Drawing.Point(122, 281);
            this.picStaffImage.Name = "picStaffImage";
            this.picStaffImage.Size = new System.Drawing.Size(136, 136);
            this.picStaffImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStaffImage.TabIndex = 25;
            this.picStaffImage.TabStop = false;
            // 
            // pnlPasswordConceal
            // 
            this.pnlPasswordConceal.Controls.Add(this.button1);
            this.pnlPasswordConceal.Location = new System.Drawing.Point(13, 164);
            this.pnlPasswordConceal.Name = "pnlPasswordConceal";
            this.pnlPasswordConceal.Size = new System.Drawing.Size(453, 67);
            this.pnlPasswordConceal.TabIndex = 28;
            this.pnlPasswordConceal.Visible = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(151, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 31);
            this.button1.TabIndex = 29;
            this.button1.Text = "Change Password...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dlgStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(478, 430);
            this.Controls.Add(this.pnlPasswordConceal);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picStaffImage);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.txtImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStaffType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnStaffOK);
            this.Controls.Add(this.cmbPayee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStaffSubText);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgStaff";
            this.Load += new System.EventHandler(this.dlgStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picStaffImage)).EndInit();
            this.pnlPasswordConceal.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStaffOK;
        public System.Windows.Forms.ComboBox cmbPayee;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lblStaffSubText;
        public System.Windows.Forms.ComboBox cmbStaffType;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseImage;
        private System.Windows.Forms.PictureBox picStaffImage;
        public System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Panel pnlPasswordConceal;
    }
}