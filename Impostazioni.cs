using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class Impostazioni : Form
    {
        static int index = 0;
        // Variabile globale per memorizzare la lingua
        public static string LinguaCorrente { get; private set; } = "it"; // Default: Italiano
        static List<string> Lingue = new List<string>()
        {
            "it",
            "en",
        };
        public Impostazioni()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = index;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = comboBox1.SelectedIndex;
            LinguaCorrente = Lingue[index];
            CambiaLingua();
        }
        
        private void CambiaLingua()
        {
            if (LinguaCorrente == "it")
            {
                LblLingua.Text = "Lingua";
                this.Text = "Opzini";
            }
            if(LinguaCorrente == "en")
            {
                LblLingua.Text = "Language";
                this.Text = "Options";
            }
        }

        private void Impostazioni_Load(object sender, EventArgs e)
        {
            CambiaLingua();
        }
    }
}
