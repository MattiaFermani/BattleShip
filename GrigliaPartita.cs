using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class GrigliaPartita : Form
    {
        private const int DimensioneGriglia = 10; // Dimensione 10x10
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

        private Dictionary<string, int> naviDisponibili = new Dictionary<string, int>
        {
            { "Nave-4-1", 4 },
            { "Nave-4-2", 4 },
            { "Nave-3-1", 3 },
            { "Nave-3-2", 3 },
            { "Nave-2", 2 }
        };

        public GrigliaPartita()
        {
            InitializeComponent();
            grigliaGiocatore = new Button[DimensioneGriglia, DimensioneGriglia];
            grigliaBot = new Button[DimensioneGriglia, DimensioneGriglia];

            InizializzaGriglia(grigliaGiocatore, 20, 20, "Giocatore", true);
            InizializzaGriglia(grigliaBot, 400, 20, "Bot", false);

            InizializzaMenu();
            CambiaLingua(); // Aggiorna i testi al caricamento
        }

        private void InizializzaGriglia(Button[,] griglia, int offsetX, int offsetY, string titolo, bool attiva)
        {
            Label label = new Label
            {
                Text = titolo,
                Location = new Point(offsetX, offsetY - 20),
                Size = new Size(200, 20),
                Name = $"Label_{titolo}" // Assegniamo un nome per riferimento futuro
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
            ListaNavi.Items.AddRange(new object[] { "Nave-4-1", "Nave-4-2", "Nave-3-1", "Nave-3-2", "Nave-2" });
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
            // Aggiorna i testi in base alla lingua corrente
            if (Impostazioni.LinguaCorrente == "it")
            {
                this.Text = "Battaglia Navale - Posizionamento Navi";

                // Aggiorna i pulsanti
                btnConfermaPosizionamento.Text = "Conferma Posizionamento";
                btnAnnullaPosizionamento.Text = "Annulla Posizionamento";
                btnIniziaPartita.Text = "Inizia Partita";

                // Aggiorna le etichette
                var labelGiocatore = Controls.Find("Label_Giocatore", true).FirstOrDefault() as Label;
                if (labelGiocatore != null) labelGiocatore.Text = "Giocatore";

                var labelBot = Controls.Find("Label_Bot", true).FirstOrDefault() as Label;
                if (labelBot != null) labelBot.Text = "Bot";

                // Aggiorna la ComboBox
                if (ListaNavi != null) ListaNavi.Text = "Seleziona Nave";
            }
            else if (Impostazioni.LinguaCorrente == "en")
            {
                this.Text = "Battleship - Ship Placement";

                // Aggiorna i pulsanti
                btnConfermaPosizionamento.Text = "Confirm Placement";
                btnAnnullaPosizionamento.Text = "Cancel Placement";
                btnIniziaPartita.Text = "Start Game";

                // Aggiorna le etichette
                var labelGiocatore = Controls.Find("Label_Giocatore", true).FirstOrDefault() as Label;
                if (labelGiocatore != null) labelGiocatore.Text = "Player";

                var labelBot = Controls.Find("Label_Bot", true).FirstOrDefault() as Label;
                if (labelBot != null) labelBot.Text = "Bot";

                // Aggiorna la ComboBox
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

                // Aggiungi la posizione solo se è valida
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
                    // Permetti di deselezionare una posizione
                    bottone.BackColor = Color.LightBlue;
                    posizioneCorrente.Remove(posizione);
                }
            }
        }



        private void AnnullaPosizionamento(object sender, EventArgs e)
        {
            ResettaPosizioniCorrenti();
            ListaNavi.Enabled = true;
        }

        private void ConfermaPosizionamento(object sender, EventArgs e)
        {
            // Controlla se la nave è valida e completata
            if (posizioneCorrente.Count != lunghezzaNaveCorrente || !Valido(posizioneCorrente, lunghezzaNaveCorrente, flottaGiocatore))
            {
                ResettaPosizioniCorrenti();
                return;
            }

            // Aggiungi la nave alla flotta e aggiorna la griglia
            flottaGiocatore.Add(new Navi.Nave(lunghezzaNaveCorrente, new List<(int, int)>(posizioneCorrente)));
            posizioneCorrente.ForEach(pos =>
            {
                grigliaGiocatore[pos.Item1, pos.Item2].BackColor = Color.Green;
            });

            // Rimuovi la nave dalla lista
            ListaNavi.Items.Remove(ListaNavi.SelectedItem);

            // Ripristina lo stato per la prossima nave
            posizioneCorrente.Clear();
            posizionandoNave = false;

            // Abilita il pulsante "Inizia Partita" quando tutte le navi sono posizionate
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
        }

        private bool Valido(List<(int, int)> posizioni, int lunghezza, List<Navi.Nave> flotta)
        {
            // Controllo 1: Non sovrapporre ad altre navi
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

            // Controllo 2:verifica l'allineamento
            if (posizioni.Count > 1)
            {
                // Controlla che tutte le posizioni siano allineate (stessa riga o colonna)
                bool stessaRiga = posizioni.All(pos => pos.Item1 == posizioni[0].Item1);
                bool stessaColonna = posizioni.All(pos => pos.Item2 == posizioni[0].Item2);

                if (!stessaRiga && !stessaColonna)
                {
                    MessageBox.Show("La nave deve essere posizionata in linea retta (verticale o orizzontale)!");
                    return false;
                }

                // Controlla che le posizioni siano consecutive
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

            // Controllo 3: Validazione completa (solo alla conferma)
            if (posizioni.Count == lunghezza)
            {
                return true; // Lunghezza corretta, validazione completa superata
            }

            return true; // Posizionamento progressivo valido
        }





    }
}
