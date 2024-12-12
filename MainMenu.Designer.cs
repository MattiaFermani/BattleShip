﻿namespace BattleShip
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
            this.BtnEsci = new System.Windows.Forms.Button();
            this.BtnIniziaPartita = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.pageSetupDialog2 = new System.Windows.Forms.PageSetupDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuTitle
            // 
            this.MainMenuTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.MainMenuTitle.AutoSize = true;
            this.MainMenuTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.MainMenuTitle.Font = new System.Drawing.Font("Ink Free", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuTitle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MainMenuTitle.Location = new System.Drawing.Point(208, 0);
            this.MainMenuTitle.Name = "MainMenuTitle";
            this.MainMenuTitle.Size = new System.Drawing.Size(699, 104);
            this.MainMenuTitle.TabIndex = 1;
            this.MainMenuTitle.Text = "BATTLE SHIP";
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
            this.tableLayoutPanel1.Controls.Add(this.BtnEsci, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1118, 521);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // BtnEsci
            // 
            this.BtnEsci.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnEsci.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.BtnEsci.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.BtnEsci.FlatAppearance.BorderSize = 0;
            this.BtnEsci.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnEsci.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.BtnEsci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEsci.Font = new System.Drawing.Font("Ink Free", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEsci.Location = new System.Drawing.Point(421, 315);
            this.BtnEsci.Name = "BtnEsci";
            this.BtnEsci.Size = new System.Drawing.Size(274, 41);
            this.BtnEsci.TabIndex = 3;
            this.BtnEsci.Text = "Exit";
            this.BtnEsci.UseVisualStyleBackColor = true;
            this.BtnEsci.Click += new System.EventHandler(this.BtnEsci_Click);
            // 
            // BtnIniziaPartita
            // 
            this.BtnIniziaPartita.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnIniziaPartita.BackColor = System.Drawing.SystemColors.Highlight;
            this.BtnIniziaPartita.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.BtnIniziaPartita.FlatAppearance.BorderColor = System.Drawing.SystemColors.Highlight;
            this.BtnIniziaPartita.FlatAppearance.BorderSize = 0;
            this.BtnIniziaPartita.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.BtnIniziaPartita.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.BtnIniziaPartita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIniziaPartita.Font = new System.Drawing.Font("Ink Free", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIniziaPartita.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnIniziaPartita.Location = new System.Drawing.Point(425, 212);
            this.BtnIniziaPartita.Name = "BtnIniziaPartita";
            this.BtnIniziaPartita.Size = new System.Drawing.Size(266, 97);
            this.BtnIniziaPartita.TabIndex = 2;
            this.BtnIniziaPartita.Text = "Nuova Partita";
            this.BtnIniziaPartita.UseVisualStyleBackColor = false;
            this.BtnIniziaPartita.Click += new System.EventHandler(this.BtnIniziaPartita_Click);
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.AllowMargins = false;
            this.pageSetupDialog1.AllowPrinter = false;
            // 
            // MainMenu
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1118, 521);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BATTLE SHIP";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label MainMenuTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button BtnIniziaPartita;
        private System.Windows.Forms.Button BtnEsci;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog2;
    }
}

