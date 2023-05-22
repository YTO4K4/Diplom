namespace diplom
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.PasswordTB = new MaterialSkin.Controls.MaterialTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UsernameTB = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PasswordTB
            // 
            this.PasswordTB.AnimateReadOnly = false;
            this.PasswordTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTB.Depth = 0;
            this.PasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.PasswordTB.Hint = "Пароль";
            this.PasswordTB.LeadingIcon = null;
            this.PasswordTB.Location = new System.Drawing.Point(340, 400);
            this.PasswordTB.MaxLength = 50;
            this.PasswordTB.MouseState = MaterialSkin.MouseState.OUT;
            this.PasswordTB.Multiline = false;
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(251, 50);
            this.PasswordTB.TabIndex = 9;
            this.PasswordTB.Text = "";
            this.PasswordTB.TrailingIcon = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(372, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(187, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // UsernameTB
            // 
            this.UsernameTB.AnimateReadOnly = false;
            this.UsernameTB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UsernameTB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.UsernameTB.Depth = 0;
            this.UsernameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.UsernameTB.HideSelection = true;
            this.UsernameTB.Hint = "Логин";
            this.UsernameTB.LeadingIcon = null;
            this.UsernameTB.Location = new System.Drawing.Point(340, 333);
            this.UsernameTB.MaxLength = 32767;
            this.UsernameTB.MouseState = MaterialSkin.MouseState.OUT;
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.PasswordChar = '\0';
            this.UsernameTB.PrefixSuffixText = null;
            this.UsernameTB.ReadOnly = false;
            this.UsernameTB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UsernameTB.SelectedText = "";
            this.UsernameTB.SelectionLength = 0;
            this.UsernameTB.SelectionStart = 0;
            this.UsernameTB.ShortcutsEnabled = true;
            this.UsernameTB.Size = new System.Drawing.Size(250, 48);
            this.UsernameTB.TabIndex = 7;
            this.UsernameTB.TabStop = false;
            this.UsernameTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UsernameTB.TrailingIcon = null;
            this.UsernameTB.UseSystemPasswordChar = false;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(431, 520);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(71, 36);
            this.materialButton1.TabIndex = 6;
            this.materialButton1.Text = "Войти";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 637);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.UsernameTB);
            this.Controls.Add(this.materialButton1);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox PasswordTB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialTextBox2 UsernameTB;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}