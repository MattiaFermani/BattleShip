using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class Impostazioni : Form
    {
        public static string LinguaCorrente { get; private set; } = "it";
        private static string LinguaSelezionata = LinguaCorrente;
        private static int IndexLingua = 0;
        private static int IndexMode = 0;
        private static List<string> Lingue = new List<string> { "it", "en" };

        public Impostazioni()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(new object[] { "Italiano", "English" });
            comboBox2.Items.AddRange(new object[] { "Facile", "Difficile" });
            comboBox1.SelectedIndex = IndexLingua;
            comboBox2.SelectedIndex = IndexMode;

            CambiaLingua();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            this.FormClosing += Impostazioni_FormClosing;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexLingua = comboBox1.SelectedIndex;
            LinguaSelezionata = Lingue[IndexLingua];

            CambiaLingua();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            IndexMode = comboBox2.SelectedIndex;
        }

        private void CambiaLingua()
        {
            if (LinguaSelezionata == "it")
            {
                LblLingua.Text = "Lingua";
                LblDifficolta.Text = "Difficoltà";
                comboBox2.Items[0] = "Facile";
                comboBox2.Items[1] = "Difficile";
                this.Text = "Opzioni";
            }
            else if (LinguaSelezionata == "en")
            {
                LblLingua.Text = "Language";
                LblDifficolta.Text = "Mode";
                comboBox2.Items[0] = "Easy";
                comboBox2.Items[1] = "Hard";
                this.Text = "Options";
            }
        }

        private void Impostazioni_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                    LinguaCorrente = LinguaSelezionata;
                }
                else if (result == DialogResult.No)
                {
                    LinguaSelezionata = LinguaCorrente;
                    IndexLingua = Lingue.IndexOf(LinguaCorrente);
                }
            }
        }

    }
}
