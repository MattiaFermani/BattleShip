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
        public MainMenu()
        {
            InitializeComponent();
            this.Text = "Battaglia Navale - Menu Principale";

            // Pulsante "Inizia Partita"
            Button btnIniziaPartita = new Button
            {
                Text = "Inizia Partita",
                Location = new System.Drawing.Point(100, 50),
                Size = new System.Drawing.Size(150, 50)
            };
            btnIniziaPartita.Click += BtnIniziaPartita_Click;
            this.Controls.Add(btnIniziaPartita);

            // Pulsante "Esci"
            Button btnEsci = new Button
            {
                Text = "Esci",
                Location = new System.Drawing.Point(100, 120),
                Size = new System.Drawing.Size(150, 50)
            };
            btnEsci.Click += BtnEsci_Click;
            this.Controls.Add(btnEsci);
        }

        private void BtnIniziaPartita_Click(object sender, EventArgs e)
        {
            Form partita = new GrigliaPartita();

            partita.Show();
        }


        private void BtnEsci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

    }
}

