namespace diplom
{
    partial class BreakeAgrForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BreakeAgrForm));
            this.addTimeDtp = new System.Windows.Forms.DateTimePicker();
            this.BreakeDVG = new System.Windows.Forms.DataGridView();
            this.addBreakePanel = new System.Windows.Forms.Panel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton13 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.addBtn = new MaterialSkin.Controls.MaterialButton();
            this.addOtvTB = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.addOpisBreakeTB = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.addDrCommTB = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.showAddPanelBtn = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.makeDocBtn = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.BreakeDVG)).BeginInit();
            this.addBreakePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // addTimeDtp
            // 
            this.addTimeDtp.Location = new System.Drawing.Point(38, 299);
            this.addTimeDtp.Name = "addTimeDtp";
            this.addTimeDtp.Size = new System.Drawing.Size(200, 22);
            this.addTimeDtp.TabIndex = 1;
            // 
            // BreakeDVG
            // 
            this.BreakeDVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BreakeDVG.Location = new System.Drawing.Point(47, 106);
            this.BreakeDVG.Name = "BreakeDVG";
            this.BreakeDVG.RowHeadersWidth = 51;
            this.BreakeDVG.RowTemplate.Height = 24;
            this.BreakeDVG.Size = new System.Drawing.Size(1027, 341);
            this.BreakeDVG.TabIndex = 2;
            // 
            // addBreakePanel
            // 
            this.addBreakePanel.Controls.Add(this.materialLabel2);
            this.addBreakePanel.Controls.Add(this.materialButton13);
            this.addBreakePanel.Controls.Add(this.materialButton2);
            this.addBreakePanel.Controls.Add(this.addBtn);
            this.addBreakePanel.Controls.Add(this.addOtvTB);
            this.addBreakePanel.Controls.Add(this.materialLabel1);
            this.addBreakePanel.Controls.Add(this.addOpisBreakeTB);
            this.addBreakePanel.Controls.Add(this.addDrCommTB);
            this.addBreakePanel.Controls.Add(this.addTimeDtp);
            this.addBreakePanel.Location = new System.Drawing.Point(240, 151);
            this.addBreakePanel.Name = "addBreakePanel";
            this.addBreakePanel.Size = new System.Drawing.Size(603, 459);
            this.addBreakePanel.TabIndex = 3;
            this.addBreakePanel.Visible = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(16, 19);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(144, 19);
            this.materialLabel2.TabIndex = 70;
            this.materialLabel2.Text = "Добавить поломку";
            // 
            // materialButton13
            // 
            this.materialButton13.AutoSize = false;
            this.materialButton13.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton13.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Dense;
            this.materialButton13.Depth = 0;
            this.materialButton13.HighEmphasis = true;
            this.materialButton13.Icon = ((System.Drawing.Image)(resources.GetObject("materialButton13.Icon")));
            this.materialButton13.ImageIndex = 24;
            this.materialButton13.Location = new System.Drawing.Point(560, 6);
            this.materialButton13.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton13.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton13.Name = "materialButton13";
            this.materialButton13.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton13.Size = new System.Drawing.Size(39, 32);
            this.materialButton13.TabIndex = 69;
            this.materialButton13.Text = "CloseChangeMCPanelBtn";
            this.materialButton13.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.materialButton13.UseAccentColor = false;
            this.materialButton13.UseVisualStyleBackColor = true;
            this.materialButton13.Click += new System.EventHandler(this.materialButton13_Click);
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(393, 388);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(99, 36);
            this.materialButton2.TabIndex = 7;
            this.materialButton2.Text = "Очистить";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            // 
            // addBtn
            // 
            this.addBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.addBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.addBtn.Depth = 0;
            this.addBtn.HighEmphasis = true;
            this.addBtn.Icon = null;
            this.addBtn.Location = new System.Drawing.Point(77, 388);
            this.addBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.addBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.addBtn.Name = "addBtn";
            this.addBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.addBtn.Size = new System.Drawing.Size(100, 36);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "Добавить";
            this.addBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.addBtn.UseAccentColor = false;
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // addOtvTB
            // 
            this.addOtvTB.AnimateReadOnly = false;
            this.addOtvTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addOtvTB.Depth = 0;
            this.addOtvTB.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addOtvTB.Hint = "ФИО ответственного";
            this.addOtvTB.LeadingIcon = null;
            this.addOtvTB.Location = new System.Drawing.Point(358, 274);
            this.addOtvTB.MaxLength = 50;
            this.addOtvTB.MouseState = MaterialSkin.MouseState.OUT;
            this.addOtvTB.Multiline = false;
            this.addOtvTB.Name = "addOtvTB";
            this.addOtvTB.Size = new System.Drawing.Size(210, 50);
            this.addOtvTB.TabIndex = 5;
            this.addOtvTB.Text = "";
            this.addOtvTB.TrailingIcon = null;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(38, 274);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(123, 19);
            this.materialLabel1.TabIndex = 4;
            this.materialLabel1.Text = "Время возврата";
            // 
            // addOpisBreakeTB
            // 
            this.addOpisBreakeTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addOpisBreakeTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addOpisBreakeTB.Depth = 0;
            this.addOpisBreakeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addOpisBreakeTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.addOpisBreakeTB.Hint = "Краткое описание причины";
            this.addOpisBreakeTB.Location = new System.Drawing.Point(358, 96);
            this.addOpisBreakeTB.MouseState = MaterialSkin.MouseState.HOVER;
            this.addOpisBreakeTB.Name = "addOpisBreakeTB";
            this.addOpisBreakeTB.Size = new System.Drawing.Size(210, 165);
            this.addOpisBreakeTB.TabIndex = 3;
            this.addOpisBreakeTB.Text = "";
            // 
            // addDrCommTB
            // 
            this.addDrCommTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.addDrCommTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addDrCommTB.Depth = 0;
            this.addDrCommTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addDrCommTB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.addDrCommTB.Hint = "Коментарий водителя";
            this.addDrCommTB.Location = new System.Drawing.Point(38, 96);
            this.addDrCommTB.MouseState = MaterialSkin.MouseState.HOVER;
            this.addDrCommTB.Name = "addDrCommTB";
            this.addDrCommTB.Size = new System.Drawing.Size(210, 165);
            this.addDrCommTB.TabIndex = 2;
            this.addDrCommTB.Text = "";
            // 
            // showAddPanelBtn
            // 
            this.showAddPanelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showAddPanelBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.showAddPanelBtn.Depth = 0;
            this.showAddPanelBtn.HighEmphasis = true;
            this.showAddPanelBtn.Icon = null;
            this.showAddPanelBtn.Location = new System.Drawing.Point(47, 468);
            this.showAddPanelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.showAddPanelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.showAddPanelBtn.Name = "showAddPanelBtn";
            this.showAddPanelBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.showAddPanelBtn.Size = new System.Drawing.Size(100, 36);
            this.showAddPanelBtn.TabIndex = 4;
            this.showAddPanelBtn.Text = "Добавить";
            this.showAddPanelBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.showAddPanelBtn.UseAccentColor = false;
            this.showAddPanelBtn.UseVisualStyleBackColor = true;
            this.showAddPanelBtn.Click += new System.EventHandler(this.showAddPanelBtn_Click);
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(196, 468);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(101, 36);
            this.materialButton1.TabIndex = 5;
            this.materialButton1.Text = "Изменить";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(974, 468);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(91, 36);
            this.materialButton3.TabIndex = 6;
            this.materialButton3.Text = "Удалить";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // makeDocBtn
            // 
            this.makeDocBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.makeDocBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.makeDocBtn.Depth = 0;
            this.makeDocBtn.HighEmphasis = true;
            this.makeDocBtn.Icon = null;
            this.makeDocBtn.Location = new System.Drawing.Point(840, 468);
            this.makeDocBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.makeDocBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.makeDocBtn.Name = "makeDocBtn";
            this.makeDocBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.makeDocBtn.Size = new System.Drawing.Size(126, 36);
            this.makeDocBtn.TabIndex = 7;
            this.makeDocBtn.Text = "Распечатать";
            this.makeDocBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.makeDocBtn.UseAccentColor = false;
            this.makeDocBtn.UseVisualStyleBackColor = true;
            this.makeDocBtn.Click += new System.EventHandler(this.makeDocBtn_Click);
            // 
            // BreakeAgrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 681);
            this.Controls.Add(this.addBreakePanel);
            this.Controls.Add(this.materialButton3);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.showAddPanelBtn);
            this.Controls.Add(this.BreakeDVG);
            this.Controls.Add(this.makeDocBtn);
            this.Name = "BreakeAgrForm";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BreakeDVG)).EndInit();
            this.addBreakePanel.ResumeLayout(false);
            this.addBreakePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker addTimeDtp;
        private System.Windows.Forms.DataGridView BreakeDVG;
        private System.Windows.Forms.Panel addBreakePanel;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton addBtn;
        private MaterialSkin.Controls.MaterialTextBox addOtvTB;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialMultiLineTextBox addOpisBreakeTB;
        private MaterialSkin.Controls.MaterialMultiLineTextBox addDrCommTB;
        private MaterialSkin.Controls.MaterialButton materialButton13;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton showAddPanelBtn;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton makeDocBtn;
    }
}