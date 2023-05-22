namespace diplom
{
    partial class TOForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TOForm));
            this.addTOPanel = new System.Windows.Forms.Panel();
            this.AddEdIzvTB = new MaterialSkin.Controls.MaterialTextBox();
            this.addKoloVoZTB = new MaterialSkin.Controls.MaterialTextBox();
            this.addKolVoOTB = new MaterialSkin.Controls.MaterialTextBox();
            this.addPriceTB = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialButton13 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.addBtn = new MaterialSkin.Controls.MaterialButton();
            this.addOtvTB = new MaterialSkin.Controls.MaterialTextBox();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.showAddPanelBtn = new MaterialSkin.Controls.MaterialButton();
            this.TODVG = new System.Windows.Forms.DataGridView();
            this.makeDocBtn = new MaterialSkin.Controls.MaterialButton();
            this.addTOPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TODVG)).BeginInit();
            this.SuspendLayout();
            // 
            // addTOPanel
            // 
            this.addTOPanel.Controls.Add(this.AddEdIzvTB);
            this.addTOPanel.Controls.Add(this.addKoloVoZTB);
            this.addTOPanel.Controls.Add(this.addKolVoOTB);
            this.addTOPanel.Controls.Add(this.addPriceTB);
            this.addTOPanel.Controls.Add(this.materialLabel2);
            this.addTOPanel.Controls.Add(this.materialButton13);
            this.addTOPanel.Controls.Add(this.materialButton2);
            this.addTOPanel.Controls.Add(this.addBtn);
            this.addTOPanel.Controls.Add(this.addOtvTB);
            this.addTOPanel.Location = new System.Drawing.Point(233, 132);
            this.addTOPanel.Name = "addTOPanel";
            this.addTOPanel.Size = new System.Drawing.Size(603, 459);
            this.addTOPanel.TabIndex = 15;
            this.addTOPanel.Visible = false;
            // 
            // AddEdIzvTB
            // 
            this.AddEdIzvTB.AnimateReadOnly = true;
            this.AddEdIzvTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AddEdIzvTB.Depth = 0;
            this.AddEdIzvTB.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.AddEdIzvTB.Hint = "Единица измерения";
            this.AddEdIzvTB.LeadingIcon = null;
            this.AddEdIzvTB.Location = new System.Drawing.Point(205, 78);
            this.AddEdIzvTB.MaxLength = 50;
            this.AddEdIzvTB.MouseState = MaterialSkin.MouseState.OUT;
            this.AddEdIzvTB.Multiline = false;
            this.AddEdIzvTB.Name = "AddEdIzvTB";
            this.AddEdIzvTB.Size = new System.Drawing.Size(210, 50);
            this.AddEdIzvTB.TabIndex = 76;
            this.AddEdIzvTB.Text = "";
            this.AddEdIzvTB.TrailingIcon = null;
            // 
            // addKoloVoZTB
            // 
            this.addKoloVoZTB.AnimateReadOnly = true;
            this.addKoloVoZTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addKoloVoZTB.Depth = 0;
            this.addKoloVoZTB.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addKoloVoZTB.Hint = "Кол-во запрошено";
            this.addKoloVoZTB.LeadingIcon = null;
            this.addKoloVoZTB.Location = new System.Drawing.Point(38, 176);
            this.addKoloVoZTB.MaxLength = 50;
            this.addKoloVoZTB.MouseState = MaterialSkin.MouseState.OUT;
            this.addKoloVoZTB.Multiline = false;
            this.addKoloVoZTB.Name = "addKoloVoZTB";
            this.addKoloVoZTB.Size = new System.Drawing.Size(210, 50);
            this.addKoloVoZTB.TabIndex = 75;
            this.addKoloVoZTB.Text = "";
            this.addKoloVoZTB.TrailingIcon = null;
            // 
            // addKolVoOTB
            // 
            this.addKolVoOTB.AnimateReadOnly = true;
            this.addKolVoOTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addKolVoOTB.Depth = 0;
            this.addKolVoOTB.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addKolVoOTB.Hint = "Кол-во отпущено";
            this.addKolVoOTB.LeadingIcon = null;
            this.addKolVoOTB.Location = new System.Drawing.Point(358, 176);
            this.addKolVoOTB.MaxLength = 50;
            this.addKolVoOTB.MouseState = MaterialSkin.MouseState.OUT;
            this.addKolVoOTB.Multiline = false;
            this.addKolVoOTB.Name = "addKolVoOTB";
            this.addKolVoOTB.Size = new System.Drawing.Size(210, 50);
            this.addKolVoOTB.TabIndex = 74;
            this.addKolVoOTB.Text = "";
            this.addKolVoOTB.TrailingIcon = null;
            // 
            // addPriceTB
            // 
            this.addPriceTB.AnimateReadOnly = true;
            this.addPriceTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.addPriceTB.Depth = 0;
            this.addPriceTB.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addPriceTB.Hint = "Цена";
            this.addPriceTB.LeadingIcon = null;
            this.addPriceTB.Location = new System.Drawing.Point(38, 274);
            this.addPriceTB.MaxLength = 50;
            this.addPriceTB.MouseState = MaterialSkin.MouseState.OUT;
            this.addPriceTB.Multiline = false;
            this.addPriceTB.Name = "addPriceTB";
            this.addPriceTB.Size = new System.Drawing.Size(210, 50);
            this.addPriceTB.TabIndex = 73;
            this.addPriceTB.Text = "";
            this.addPriceTB.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(16, 19);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(100, 19);
            this.materialLabel2.TabIndex = 70;
            this.materialLabel2.Text = "Добавить ТО";
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
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(967, 449);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(91, 36);
            this.materialButton3.TabIndex = 18;
            this.materialButton3.Text = "Удалить";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(189, 449);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(101, 36);
            this.materialButton1.TabIndex = 17;
            this.materialButton1.Text = "Изменить";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            // 
            // showAddPanelBtn
            // 
            this.showAddPanelBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showAddPanelBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.showAddPanelBtn.Depth = 0;
            this.showAddPanelBtn.HighEmphasis = true;
            this.showAddPanelBtn.Icon = null;
            this.showAddPanelBtn.Location = new System.Drawing.Point(40, 449);
            this.showAddPanelBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.showAddPanelBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.showAddPanelBtn.Name = "showAddPanelBtn";
            this.showAddPanelBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.showAddPanelBtn.Size = new System.Drawing.Size(100, 36);
            this.showAddPanelBtn.TabIndex = 16;
            this.showAddPanelBtn.Text = "Добавить";
            this.showAddPanelBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.showAddPanelBtn.UseAccentColor = false;
            this.showAddPanelBtn.UseVisualStyleBackColor = true;
            this.showAddPanelBtn.Click += new System.EventHandler(this.showAddPanelBtn_Click);
            // 
            // TODVG
            // 
            this.TODVG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TODVG.Location = new System.Drawing.Point(40, 87);
            this.TODVG.Name = "TODVG";
            this.TODVG.RowHeadersWidth = 51;
            this.TODVG.RowTemplate.Height = 24;
            this.TODVG.Size = new System.Drawing.Size(1027, 341);
            this.TODVG.TabIndex = 14;
            // 
            // makeDocBtn
            // 
            this.makeDocBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.makeDocBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.makeDocBtn.Depth = 0;
            this.makeDocBtn.HighEmphasis = true;
            this.makeDocBtn.Icon = null;
            this.makeDocBtn.Location = new System.Drawing.Point(833, 449);
            this.makeDocBtn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.makeDocBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.makeDocBtn.Name = "makeDocBtn";
            this.makeDocBtn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.makeDocBtn.Size = new System.Drawing.Size(126, 36);
            this.makeDocBtn.TabIndex = 19;
            this.makeDocBtn.Text = "Распечатать";
            this.makeDocBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.makeDocBtn.UseAccentColor = false;
            this.makeDocBtn.UseVisualStyleBackColor = true;
            this.makeDocBtn.Click += new System.EventHandler(this.makeDocBtn_Click);
            // 
            // TOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 678);
            this.Controls.Add(this.addTOPanel);
            this.Controls.Add(this.materialButton3);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.showAddPanelBtn);
            this.Controls.Add(this.TODVG);
            this.Controls.Add(this.makeDocBtn);
            this.Name = "TOForm";
            this.Text = "TOForm";
            this.Load += new System.EventHandler(this.TOForm_Load);
            this.addTOPanel.ResumeLayout(false);
            this.addTOPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TODVG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel addTOPanel;
        private MaterialSkin.Controls.MaterialTextBox addPriceTB;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialButton materialButton13;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton addBtn;
        private MaterialSkin.Controls.MaterialTextBox addOtvTB;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton showAddPanelBtn;
        private System.Windows.Forms.DataGridView TODVG;
        private MaterialSkin.Controls.MaterialButton makeDocBtn;
        private MaterialSkin.Controls.MaterialTextBox AddEdIzvTB;
        private MaterialSkin.Controls.MaterialTextBox addKoloVoZTB;
        private MaterialSkin.Controls.MaterialTextBox addKolVoOTB;
    }
}