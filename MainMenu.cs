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
        // Dichiarazione dei pulsanti come campi della classe
        private Button btnNuovaPartita;
        private Button btnOpzioni;
        private Button btnEsci;
        private Form partita;

        public MainMenu()
        {
            InitializeComponent();
            this.Text = "Battaglia Navale - Menu Principale";

            // Recupera i pulsanti dal TableLayoutPanel
            btnNuovaPartita = (Button)tableLayoutPanel1.Controls.Find("BtnNuovaPartita", true).FirstOrDefault();
            btnOpzioni = (Button)tableLayoutPanel1.Controls.Find("BtnOpzioni", true).FirstOrDefault();

            // Associa gli eventi solo se non già associati
            if (btnNuovaPartita != null)
                btnNuovaPartita.Click -= BtnNuovaPartita_Click; // Rimuove associazioni precedenti
            btnNuovaPartita.Click += BtnNuovaPartita_Click;

            if (btnOpzioni != null)
                btnOpzioni.Click -= BtnOpzioni_Click; // Rimuove associazioni precedenti
            btnOpzioni.Click += BtnOpzioni_Click;

            CambiaLingua();
        }

        private void CambiaLingua()
        {
            // Aggiorna i testi in base alla lingua
            if (Impostazioni.LinguaCorrente == "it")
            {
                this.Text = "Battaglia Navale - Menu Principale";
                MainMenuTitle.Text = "Battaglia Navale";
                if (btnNuovaPartita != null) btnNuovaPartita.Text = "Inizia Partita";
                if (btnOpzioni != null) btnOpzioni.Text = "Opzioni";
            }
            else if (Impostazioni.LinguaCorrente == "en")
            {
                this.Text = "Battleship - Main Menu";
                MainMenuTitle.Text = "Battle Ship";
                if (btnNuovaPartita != null) btnNuovaPartita.Text = "Start Game";
                if (btnOpzioni != null) btnOpzioni.Text = "Options";
            }
        }

        private void BtnNuovaPartita_Click(object sender, EventArgs e)
        {
            // Chiudi eventuali form precedenti
            if (partita != null && !partita.IsDisposed)
            {
                partita.Close();
            }

            // Crea una nuova istanza del form
            partita = new GrigliaPartita();
            partita.Show();
        }

        private void BtnOpzioni_Click(object sender, EventArgs e)
        {
            using (Form opzioni = new Impostazioni())
            {
                opzioni.ShowDialog(); // Mostra il form Opzioni in modo modale
            }

            CambiaLingua(); // Aggiorna la lingua al ritorno dal form Opzioni
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}