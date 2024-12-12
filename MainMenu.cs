using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class MainMenu : Form
    {
        // Dichiarazione dei pulsanti come campi della classe
        private Button btnIniziaPartita;
        private Button btnEsci;
        Form partita = new GrigliaPartita();

        // Variabile globale per memorizzare la lingua
        public static string LinguaCorrente { get; private set; } = "it"; // Default: Italiano

        public MainMenu()
        {
            InitializeComponent();
            this.Text = "Battaglia Navale - Menu Principale";

            // Associa i pulsanti definiti nel TableLayoutPanel
            btnIniziaPartita = (Button)tableLayoutPanel1.Controls.Find("BtnIniziaPartita", true).FirstOrDefault();
            btnEsci = (Button)tableLayoutPanel1.Controls.Find("BtnEsci", true).FirstOrDefault();

            // Controlla che i pulsanti esistano e associa gli eventi
            if (btnIniziaPartita != null)
                btnIniziaPartita.Click += BtnIniziaPartita_Click;

            if (btnEsci != null)
                btnEsci.Click += BtnEsci_Click;
        }

        private void BtnIniziaPartita_Click(object sender, EventArgs e)
        {
            // Passa la lingua al form della partita
            partita.Show();
        }

        private void BtnEsci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CambiaLingua()
        {
            if (LinguaCorrente == "it")
            {
                this.Text = "Battaglia Navale - Menu Principale";
                MainMenuTitle.Text = "Battaglia Navale";
                linguaToolStripMenuItem.Text = "Lingua";
                if (btnIniziaPartita != null) btnIniziaPartita.Text = "Inizia Partita";
                if (btnEsci != null) btnEsci.Text = "Esci";
            }
            else if (LinguaCorrente == "en")
            {
                this.Text = "Battleship - Main Menu";
                MainMenuTitle.Text = "Battle Ship";
                linguaToolStripMenuItem.Text = "Language";
                if (btnIniziaPartita != null) btnIniziaPartita.Text = "Start Game";
                if (btnEsci != null) btnEsci.Text = "Exit";
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void italianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Cambia la lingua in italiano
            englishToolStripMenuItem.Checked = false;
            italianoToolStripMenuItem.Checked = true;
            LinguaCorrente = "it"; // Memorizza la lingua selezionata
            CambiaLingua();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Cambia la lingua in inglese
            englishToolStripMenuItem.Checked = true;
            italianoToolStripMenuItem.Checked = false;
            LinguaCorrente = "en"; // Memorizza la lingua selezionata
            CambiaLingua();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void BtnOpzioni_Click(object sender, EventArgs e)
        {

        }
    }
}