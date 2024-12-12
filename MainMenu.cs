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
        private Button btnOpzioni;
        private Button btnEsci;


        public MainMenu()
        {
            InitializeComponent();
            this.Text = "Battaglia Navale - Menu Principale";

            // Associa i pulsanti definiti nel TableLayoutPanel
            btnIniziaPartita = (Button)tableLayoutPanel1.Controls.Find("BtnIniziaPartita", true).FirstOrDefault();
            btnOpzioni = (Button)tableLayoutPanel1.Controls.Find("BtnOpzioni", true).FirstOrDefault();

            // Controlla che i pulsanti esistano e associa gli eventi
            if (btnIniziaPartita != null)
                btnIniziaPartita.Click += BtnNuovaPartita_Click;

            if (btnOpzioni != null)
                btnOpzioni.Click += BtnOpzioni_Click;
        }

        private void CambiaLingua()
        {
            if (Impostazioni.LinguaCorrente == "it")
            {
                this.Text = "Battaglia Navale - Menu Principale";
                MainMenuTitle.Text = "Battaglia Navale";
                if (btnIniziaPartita != null) btnIniziaPartita.Text = "Inizia Partita";
            }
            else if (Impostazioni.LinguaCorrente == "en")
            {
                this.Text = "Battleship - Main Menu";
                MainMenuTitle.Text = "Battle Ship";
                if (btnIniziaPartita != null) btnIniziaPartita.Text = "Start Game";
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnNuovaPartita_Click(object sender, EventArgs e)
        {
            Form partita = new GrigliaPartita();
            partita.Show();
        }

        private void BtnOpzioni_Click(object sender, EventArgs e)
        {
            Form opzioni = new Impostazioni();
            opzioni.ShowDialog();
            CambiaLingua();
            Refresh();
            
        }
    }
}