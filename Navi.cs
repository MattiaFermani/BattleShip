using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public static class Navi
    {
        private static Random random = new Random();
        public static List<Nave> FlottaBot = new List<Nave>();
        public static List<Nave> FlottaGiocatore = new List<Nave>();

        public class Nave
        {
            public int Lunghezza { get; private set; }
            public List<(int, int)> Posizioni { get; private set; }

            public Nave(int lunghezza)
            {
                this.Lunghezza = lunghezza;
                this.Posizioni = new List<(int, int)>();
            }

            public Nave(int lunghezza, List<(int, int)> posizioni)
            {
                this.Lunghezza = lunghezza;
                this.Posizioni = posizioni;
            }

            public void Posiziona(List<(int, int)> posizioni)
            {
                this.Posizioni = posizioni;
            }
        }

        public static void PosizionaNavi(List<Nave> flotta, int dimensioneGriglia)
        {
            int[] lunghezzeNavi = { 5, 4, 3, 3, 2 };

            foreach (int lunghezza in lunghezzeNavi)
            {
                Nave nave = new Nave(lunghezza);
                bool posizionata = false;

                while (!posizionata)
                {
                    int riga = random.Next(0, dimensioneGriglia);
                    int colonna = random.Next(0, dimensioneGriglia);
                    bool orizzontale = random.Next(0, 2) == 0;

                    List<(int, int)> posizioni = new List<(int, int)>();

                    for (int i = 0; i < lunghezza; i++)
                    {
                        int nuovaRiga = orizzontale ? riga : riga + i;
                        int nuovaColonna = orizzontale ? colonna + i : colonna;

                        if (nuovaRiga >= dimensioneGriglia || nuovaColonna >= dimensioneGriglia)
                            break;

                        posizioni.Add((nuovaRiga, nuovaColonna));
                    }

                    if (posizioni.Count == lunghezza && !Sovrapposizione(posizioni, flotta))
                    {
                        nave.Posiziona(posizioni);
                        flotta.Add(nave);
                        posizionata = true;
                    }
                }
            }
        }

        private static bool Sovrapposizione(List<(int, int)> posizioni, List<Nave> flotta)
        {
            foreach (var nave in flotta)
            {
                foreach (var pos in nave.Posizioni)
                {
                    if (posizioni.Contains(pos)) return true;
                }
            }
            return false;
        }
    }
}
