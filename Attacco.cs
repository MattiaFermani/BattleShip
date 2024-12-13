using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BattleShip
{
    static class Attacco
    {
        private static HashSet<(int, int)> celleAttaccateDalBot = new HashSet<(int, int)>();
        private static Random random = new Random();

        // Metodo per l'attacco del giocatore
        public static string GiocatoreAttacca((int, int) posizione, Button bottone, List<Navi.Nave> flottaBot, ref bool turnoGiocatore)
        {
            // Controlla se la cella è già stata attaccata
            if (bottone.BackColor != Color.LightBlue && bottone.BackColor != Color.Gold)
            {
                return "Hai già attaccato questa cella! Scegli un'altra posizione.";
            }

            // Controlla se c'è una nave nella posizione
            var naveColpita = flottaBot.FirstOrDefault(nave => nave.Posizioni.Contains(posizione));
            turnoGiocatore = false; // Passa il turno al bot
            if (naveColpita != null)
            {
                bottone.BackColor = Color.Red; // Colpito
                naveColpita.Posizioni.Remove(posizione);

                if (naveColpita.Posizioni.Count == 0)
                {
                    flottaBot.Remove(naveColpita);
                    return "Affondato!";
                }

                return "Colpito!";
            }

            // Mancato
            bottone.BackColor = Color.Gray;
            return "Acqua!";
        }

        // Metodo per l'attacco del bot
        public static string BotAttacca(Button[,] grigliaGiocatore, List<Navi.Nave> flottaGiocatore, ref bool turnoGiocatore)
        {
            while (true)
            {
                // Genera una posizione casuale
                int riga = random.Next(0, grigliaGiocatore.GetLength(0));
                int colonna = random.Next(0, grigliaGiocatore.GetLength(1));
                var posizione = (riga, colonna);

                // Evita di attaccare due volte la stessa cella
                if (celleAttaccateDalBot.Contains(posizione))
                    continue;

                celleAttaccateDalBot.Add(posizione);

                Button bottone = grigliaGiocatore[riga, colonna];
                var naveColpita = flottaGiocatore.FirstOrDefault(nave => nave.Posizioni.Contains(posizione));

                turnoGiocatore = true;
                if (naveColpita != null)
                {
                    bottone.BackColor = Color.Red; // Colpito
                    naveColpita.Posizioni.Remove(posizione);

                    if (naveColpita.Posizioni.Count == 0)
                    {
                        flottaGiocatore.Remove(naveColpita);
                        return "Il bot ha affondato una tua nave!";
                    }

                    return "Il bot ha colpito una tua nave!";
                }

                // Mancato
                bottone.BackColor = Color.Gray;
                turnoGiocatore = true; // Passa il turno al giocatore
                return "Il bot ha mancato!";

            }
        }

        // Metodo per verificare la vittoria
        public static string ControllaVittoria(List<Navi.Nave> flottaGiocatore, List<Navi.Nave> flottaBot)
        {
            if (flottaBot.Count == 0)
            {
                return "Hai vinto!";
            }

            if (flottaGiocatore.Count == 0)
            {
                return "Hai perso!";
            }

            return null;
        }
    }
}
