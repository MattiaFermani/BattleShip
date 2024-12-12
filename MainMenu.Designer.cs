namespace BattleShip
{
    partial class MainMenu
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.MainMenuTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnIniziaPartita = new System.Windows.Forms.Button();
            this.BtnEsci = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.BtnOpzioni = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.italianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.linguaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuTitle
            // 
            this.MainMenuTitle.AutoSize = true;
            this.MainMenuTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.MainMenuTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMenuTitle.Font = new System.Drawing.Font("Ink Free", 52F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuTitle.Location = new System.Drawing.Point(169, 0);
            this.MainMenuTitle.Name = "MainMenuTitle";
            this.MainMenuTitle.Size = new System.Drawing.Size(772, 97);
            this.MainMenuTitle.TabIndex = 1;
            this.MainMenuTitle.Text = "BATTAGLIA NAVALE";
            this.MainMenuTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.MainMenuTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.BtnIniziaPartita, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.BtnOpzioni, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.BtnEsci, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1112, 489);
            this.tableLayoutPanel1.TabIndex = 2;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // BtnIniziaPartita
            // 
            this.BtnIniziaPartita.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnIniziaPartita.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnIniziaPartita.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.BtnIniziaPartita.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.BtnIniziaPartita.FlatAppearance.BorderSize = 0;
            this.BtnIniziaPartita.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.BtnIniziaPartita.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.BtnIniziaPartita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIniziaPartita.Font = new System.Drawing.Font("Ink Free", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIniziaPartita.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnIniziaPartita.Location = new System.Drawing.Point(425, 238);
            this.BtnIniziaPartita.Name = "BtnIniziaPartita";
            this.BtnIniziaPartita.Size = new System.Drawing.Size(259, 50);
            this.BtnIniziaPartita.TabIndex = 2;
            this.BtnIniziaPartita.Text = "Nuova Partita";
            this.BtnIniziaPartita.UseVisualStyleBackColor = false;
            this.BtnIniziaPartita.Click += new System.EventHandler(this.BtnIniziaPartita_Click);
            // 
            // BtnEsci
            // 
            this.BtnEsci.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnEsci.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.BtnEsci.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.BtnEsci.FlatAppearance.BorderSize = 0;
            this.BtnEsci.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.BtnEsci.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.BtnEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEsci.Font = new System.Drawing.Font("Ink Free", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEsci.Location = new System.Drawing.Point(425, 391);
            this.BtnEsci.Name = "BtnEsci";
            this.BtnEsci.Size = new System.Drawing.Size(259, 41);
            this.BtnEsci.TabIndex = 3;
            this.BtnEsci.Text = "Esci";
            this.BtnEsci.UseVisualStyleBackColor = true;
            this.BtnEsci.Click += new System.EventHandler(this.BtnEsci_Click);
            // 
            // BtnOpzioni
            // 
            this.BtnOpzioni.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnOpzioni.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.BtnOpzioni.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.BtnOpzioni.FlatAppearance.BorderSize = 0;
            this.BtnOpzioni.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.BtnOpzioni.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.BtnOpzioni.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOpzioni.Font = new System.Drawing.Font("Ink Free", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOpzioni.Location = new System.Drawing.Point(423, 294);
            this.BtnOpzioni.Name = "BtnOpzioni";
            this.BtnOpzioni.Size = new System.Drawing.Size(263, 58);
            this.BtnOpzioni.TabIndex = 4;
            this.BtnOpzioni.Text = "Opzioni";
            this.BtnOpzioni.UseVisualStyleBackColor = true;
            this.BtnOpzioni.Click += new System.EventHandler(this.BtnOpzioni_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.menuStrip1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1118, 521);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // italianoToolStripMenuItem
            // 
            this.italianoToolStripMenuItem.Name = "italianoToolStripMenuItem";
            this.italianoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.italianoToolStripMenuItem.Text = "Italiano";
            this.italianoToolStripMenuItem.Click += new System.EventHandler(this.italianoToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linguaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1118, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // linguaToolStripMenuItem
            // 
            this.linguaToolStripMenuItem.Name = "linguaToolStripMenuItem";
            this.linguaToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.linguaToolStripMenuItem.Text = "Lingua";
            // 
            // MainMenu
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1118, 521);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BATTLE SHIP";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label MainMenuTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnIniziaPartita;
        private System.Windows.Forms.Button BtnEsci;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button BtnOpzioni;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem italianoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem linguaToolStripMenuItem;
    }
}

