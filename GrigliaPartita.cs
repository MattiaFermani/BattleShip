using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class GrigliaPartita : Form
    {
        private const int DimensioneGriglia = 10;
        private Button[,] grigliaGiocatore;
        private Button[,] grigliaBot;

        private List<Navi.Nave> flottaGiocatore = new List<Navi.Nave>();
        private List<Navi.Nave> flottaBot = new List<Navi.Nave>();

        private ComboBox ListaNavi;
        private ComboBox Orientamento;
        public Button btnConfermaPosizionamento;
        public Button btnAnnullaPosizionamento;
        public Button btnIniziaPartita;

        private bool posizionandoNave = false;
        private int lunghezzaNaveCorrente;
        private List<(int, int)> posizioneCorrente = new List<(int, int)>();

        private bool turnoGiocatore = true;

        private Dictionary<string, int> naviDisponibili = new Dictionary<string, int>
        {
            { "Nave-5",   5 }, 
            { "Nave-4-1", 4 },
            { "Nave-4-2", 4 },
            { "Nave-3-1", 3 },
            { "Nave-3-2", 3 },
            { "Nave-2",   2 }
        };

        public GrigliaPartita()
        {
            InitializeComponent();
            grigliaGiocatore = new Button[DimensioneGriglia, DimensioneGriglia];
            grigliaBot = new Button[DimensioneGriglia, DimensioneGriglia];

            InizializzaGriglia(grigliaGiocatore, 20, 20, "Giocatore", true);
            InizializzaGriglia(grigliaBot, 400, 20, "Bot", false);

            InizializzaMenu();
            CambiaLingua();
        }

        private void InizializzaGriglia(Button[,] griglia, int offsetX, int offsetY, string titolo, bool attiva)
        {
            Label label = new Label
            {
                Text = titolo,
                Location = new Point(offsetX, offsetY - 20),
                Size = new Size(200, 20),
                Name = $"Label_{titolo}"
            };
            this.Controls.Add(label);

            for (int riga = 0; riga < DimensioneGriglia; riga++)
            {
                for (int colonna = 0; colonna < DimensioneGriglia; colonna++)
                {
                    griglia[riga, colonna] = new Button
                    {
                        Size = new Size(30, 30),
                        Location = new Point(offsetX + colonna * 30, offsetY + riga * 30),
                        BackColor = Color.LightBlue,
                        Tag = (riga, colonna),
                        Enabled = attiva
                    };

                    if (attiva)
                    {
                        griglia[riga, colonna].Click += PosizionamentoNave;
                    }

                    this.Controls.Add(griglia[riga, colonna]);
                }
            }
        }

        private void InizializzaMenu()
        {
            ListaNavi = new ComboBox
            {
                Location = new Point(750, 50),
                Size = new Size(150, 30),
                Name = "ListaNavi"
            };
            ListaNavi.Items.AddRange(new object[] { "Nave-5", "Nave-4-1", "Nave-4-2", "Nave-3-1", "Nave-3-2", "Nave-2" });
            this.Controls.Add(ListaNavi);

            btnConfermaPosizionamento = new Button
            {
                Text = "Conferma Posizionamento",
                Location = new Point(750, 100),
                Size = new Size(150, 50),
                Name = "btnConfermaPosizionamento"
            };
            btnConfermaPosizionamento.Click += ConfermaPosizionamento;
            this.Controls.Add(btnConfermaPosizionamento);

            btnAnnullaPosizionamento = new Button
            {
                Text = "Annulla Posizionamento",
                Location = new Point(750, 150),
                Size = new Size(150, 50),
                Name = "btnAnnullaPosizionamento"
            };
            btnAnnullaPosizionamento.Click += AnnullaPosizionamento;
            this.Controls.Add(btnAnnullaPosizionamento);

            btnIniziaPartita = new Button
            {
                Text = "Inizia Partita",
                Location = new Point(750, 200),
                Size = new Size(150, 50),
                Enabled = false,
                Name = "btnIniziaPartita"
            };
            btnIniziaPartita.Click += IniziaPartita;
            this.Controls.Add(btnIniziaPartita);
        }

        private void CambiaLingua()
        {
            if (Impostazioni.LinguaCorrente == "it")
            {
                this.Text = "Battaglia Navale - Posizionamento Navi";

                btnConfermaPosizionamento.Text = "Conferma Posizionamento";
                btnAnnullaPosizionamento.Text = "Annulla Posizionamento";
                btnIniziaPartita.Text = "Inizia Partita";

                var labelGiocatore = Controls.Find("Label_Giocatore", true).FirstOrDefault() as Label;
                if (labelGiocatore != null) labelGiocatore.Text = "Giocatore";

                var labelBot = Controls.Find("Label_Bot", true).FirstOrDefault() as Label;
                if (labelBot != null) labelBot.Text = "Bot";

                if (ListaNavi != null) ListaNavi.Text = "Seleziona Nave";
            }
            else if (Impostazioni.LinguaCorrente == "en")
            {
                this.Text = "Battleship - Ship Placement";

                btnConfermaPosizionamento.Text = "Confirm Placement";
                btnAnnullaPosizionamento.Text = "Cancel Placement";
                btnIniziaPartita.Text = "Start Game";

                var labelGiocatore = Controls.Find("Label_Giocatore", true).FirstOrDefault() as Label;
                if (labelGiocatore != null) labelGiocatore.Text = "Player";

                var labelBot = Controls.Find("Label_Bot", true).FirstOrDefault() as Label;
                if (labelBot != null) labelBot.Text = "Bot";

                if (ListaNavi != null) ListaNavi.Text = "Select Ship";
            }
        }

        private void PosizionamentoNave(object sender, EventArgs e)
        {
            if (ListaNavi.Items.Count > 0)
            {
                if (!posizionandoNave)
                {
                    ListaNavi.SelectedIndex = 0;
                    lunghezzaNaveCorrente = naviDisponibili[(string)ListaNavi.SelectedItem];
                    posizioneCorrente.Clear();
                    posizionandoNave = true;
                }

                Button bottone = (Button)sender;
                var posizione = ((int, int))bottone.Tag;

                if (bottone.BackColor == Color.LightBlue && posizioneCorrente.Count < lunghezzaNaveCorrente)
                {
                    posizioneCorrente.Add(posizione);

                    if (Valido(posizioneCorrente, lunghezzaNaveCorrente, flottaGiocatore))
                    {
                        bottone.BackColor = Color.Yellow;
                    }
                    else
                    {
                        posizioneCorrente.Remove(posizione);
                    }
                }
                else if (posizioneCorrente.Contains(posizione))
                {
                    bottone.BackColor = Color.LightBlue;
                    posizioneCorrente.Remove(posizione);
                }
            }
        }


        private void AbilitaAttaccoGiocatore()
        {
            foreach (var bottone in grigliaBot)
            {
                bottone.Enabled = true;
                bottone.Click += AttaccoGiocatore;
            }
        }

        private void AttaccoGiocatore(object sender, EventArgs e)
        {
            if (!turnoGiocatore)
            {
                MessageBox.Show("Non è il tuo turno!");
                return;
            }

            Button bottone = sender as Button;
            if (bottone == null)
                return;

            var posizione = ((int, int))bottone.Tag;

            string risultato = Attacco.GiocatoreAttacca(posizione, bottone, flottaBot, ref turnoGiocatore);
            MessageBox.Show(risultato);

            string esito = Attacco.ControllaVittoria(flottaGiocatore, flottaBot);
            if (esito != null)
            {
                MessageBox.Show(esito);
                this.Close();
                return;
            }

            if (!turnoGiocatore)
            {
                AttaccoBot();
            }
        }

        private void AttaccoBot()
        {
            string risultato = Attacco.BotAttacca(grigliaGiocatore, flottaGiocatore, ref turnoGiocatore);
            MessageBox.Show(risultato);

            string esito = Attacco.ControllaVittoria(flottaGiocatore, flottaBot);
            if (esito != null)
            {
                MessageBox.Show(esito);
                this.Close();
            }
        }



        private void AnnullaPosizionamento(object sender, EventArgs e)
        {
            ResettaPosizioniCorrenti();
            ListaNavi.Enabled = true;
        }

        private void ConfermaPosizionamento(object sender, EventArgs e)
        {
            if (posizioneCorrente.Count != lunghezzaNaveCorrente || !Valido(posizioneCorrente, lunghezzaNaveCorrente, flottaGiocatore))
            {
                ResettaPosizioniCorrenti();
                return;
            }

            flottaGiocatore.Add(new Navi.Nave(lunghezzaNaveCorrente, new List<(int, int)>(posizioneCorrente)));
            posizioneCorrente.ForEach(pos =>
            {
                grigliaGiocatore[pos.Item1, pos.Item2].BackColor = Color.Green;
            });

            ListaNavi.Items.Remove(ListaNavi.SelectedItem);

            posizioneCorrente.Clear();
            posizionandoNave = false;

            if (ListaNavi.Items.Count == 0)
            {
                btnIniziaPartita.Enabled = true;
            }
            else
            {
                ListaNavi.SelectedIndex = 0;
            }
        }


        private void ResettaPosizioniCorrenti()
        {
            foreach (var pos in posizioneCorrente)
            {
                grigliaGiocatore[pos.Item1, pos.Item2].BackColor = Color.LightBlue;
            }

            posizioneCorrente.Clear();
            posizionandoNave = false;
        }



        private void IniziaPartita(object sender, EventArgs e)
        {
            AbilitaAttaccoGiocatore();
            this.Controls.Remove(ListaNavi);
            this.Controls.Remove(btnConfermaPosizionamento);
            this.Controls.Remove(btnAnnullaPosizionamento);
            this.Controls.Remove(btnIniziaPartita);
            this.Size = new Size(750, 450);

            Navi.PosizionaNavi(flottaBot, DimensioneGriglia);

            ListaNavi.Visible = false;
            btnConfermaPosizionamento.Visible = false;
            btnIniziaPartita.Visible = false;

            foreach (Button bottone in grigliaBot) bottone.Enabled = true;
            this.Text = "Battaglia Navale - Partita Iniziata!";

            Button btnDebug = new Button
            {
                Text = "DEBUG",
                Location = new Point(300, 360),
                Size = new Size(150, 50),
                Name = "btnDebug"
            };
            btnDebug.Click += BtnDebug_Click;
            this.Controls.Add(btnDebug);
        }

        // Metodo per il pulsante DEBUG
        private void BtnDebug_Click(object sender, EventArgs e)
        {
            foreach (var nave in flottaBot)
            {
                foreach (var posizione in nave.Posizioni)
                {
                    int riga = posizione.Item1;
                    int colonna = posizione.Item2;
                    Button bottone = grigliaBot[riga, colonna];
                    bottone.BackColor = Color.Gold;
                }
            }
        }

        private bool Valido(List<(int, int)> posizioni, int lunghezza, List<Navi.Nave> flotta)
        {
            foreach (var nave in flotta)
            {
                foreach (var pos in nave.Posizioni)
                {
                    if (posizioni.Contains(pos))
                    {
                        MessageBox.Show("Posizione non valida! Le navi non possono sovrapporsi.");
                        return false;
                    }
                }
            }
            if (posizioni.Count > 1)
            {
                bool stessaRiga = posizioni.All(pos => pos.Item1 == posizioni[0].Item1);
                bool stessaColonna = posizioni.All(pos => pos.Item2 == posizioni[0].Item2);

                if (!stessaRiga && !stessaColonna)
                {
                    MessageBox.Show("La nave deve essere posizionata in linea retta (verticale o orizzontale)!");
                    return false;
                }

                if (stessaRiga)
                {
                    var colonne = posizioni.Select(pos => pos.Item2).OrderBy(c => c).ToList();
                    for (int i = 1; i < colonne.Count; i++)
                    {
                        if (colonne[i] != colonne[i - 1] + 1)
                        {
                            MessageBox.Show("Le posizioni della nave devono essere tutte vicine!");
                            return false;
                        }
                    }
                }
                else if (stessaColonna)
                {
                    var righe = posizioni.Select(pos => pos.Item1).OrderBy(r => r).ToList();
                    for (int i = 1; i < righe.Count; i++)
                    {
                        if (righe[i] != righe[i - 1] + 1)
                        {
                            MessageBox.Show("Le posizioni della nave devono essere tutte vicine!");
                            return false;
                        }
                    }
                }
            }

            if (posizioni.Count == lunghezza)
            {
                return true;
            }

            return true;
        }





    }
}
