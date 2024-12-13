using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class Impostazioni : Form
    {
        // Variabile globale per memorizzare la lingua
        public static string LinguaCorrente { get; private set; } = "it"; // Default: Italiano
        private static string LinguaSelezionata = LinguaCorrente; // Lingua temporanea durante le modifiche
        private static int IndexCorrente = 0; // Indice del ComboBox corrente
        private static List<string> Lingue = new List<string> { "it", "en" };

        public Impostazioni()
        {
            InitializeComponent();

            // Inizializza il ComboBox con le lingue disponibili
            comboBox1.Items.AddRange(new object[] { "Italiano", "English" });
            comboBox1.SelectedIndex = IndexCorrente;

            // Aggiorna la lingua al caricamento
            CambiaLingua();

            // Associa gli eventi
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            this.FormClosing += Impostazioni_FormClosing;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aggiorna l'indice selezionato e la lingua temporanea
            IndexCorrente = comboBox1.SelectedIndex;
            LinguaSelezionata = Lingue[IndexCorrente];

            // Aggiorna i testi dinamicamente
            CambiaLingua();
        }

        private void CambiaLingua()
        {
            // Aggiorna i testi del form e dei controlli in base alla lingua selezionata
            if (LinguaSelezionata == "it")
            {
                LblLingua.Text = "Lingua";
                this.Text = "Opzioni";
            }
            else if (LinguaSelezionata == "en")
            {
                LblLingua.Text = "Language";
                this.Text = "Options";
            }
        }

        private void Impostazioni_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Controlla se la lingua è stata modificata rispetto alla lingua corrente
            if (LinguaSelezionata != LinguaCorrente)
            {
                DialogResult result = DialogResult.No;
                if (LinguaSelezionata == "it")
                {
                    result = MessageBox.Show(
                        "Vuoi salvare le modifiche alla lingua?",
                        "Conferma Modifiche",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                }
                else
                {
                    result = MessageBox.Show(
                        "Save Changes?",
                        "Confirm Changes",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                }

                if (result == DialogResult.Yes)
                {
                    // Salva la nuova lingua
                    LinguaCorrente = LinguaSelezionata;
                }
                else if (result == DialogResult.No)
                {
                    // Ripristina la lingua precedente
                    LinguaSelezionata = LinguaCorrente;
                    IndexCorrente = Lingue.IndexOf(LinguaCorrente);
                }
            }
        }
    }
}
