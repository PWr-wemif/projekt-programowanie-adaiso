using System;
using System.Collections.Generic;

namespace Blackjack.Models
{
    public class BlackjackModel
    {
        public List<string> Talia { get; set; }
        public List<string> KartyGracza { get; set; }
        public List<string> KartyKrupiera { get; set; }
        public string WynikGry { get; set; }
        public int SumaPunktowGracza => ObliczWartoscRęki(KartyGracza);
        public int SumaPunktowKrupiera => ObliczWartoscRęki(KartyKrupiera);

        public void InicjalizujTalie()
        {
            var talia = new List<(string, int)>();
            string[] kolory = { "Kier", "Karo", "Trefl", "Pik" };
            string[] figury = { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Walet", "Królowa", "Król" };

            for (int i = 0; i < figury.Length; i++)
            {
                for (int j = 0; j < kolory.Length; j++)
                {
                    var wartosc = (i >= 1 && i <= 9) ? i + 1 : 10;
                    var nazwaKarty = $"{figury[i]} {kolory[j]} ({wartosc})";
                    talia.Add((nazwaKarty, wartosc));
                }
            }

            Talia = talia.Select(card => card.Item1).ToList(); // Ta linia jest do zmiany
        }



        public void RozdajKarty()
        {
            Random rand = new Random();
            KartyGracza = new List<string>();
            KartyKrupiera = new List<string>();

            for (int i = 0; i < 2; i++)
            {
                int indexGracz = rand.Next(Talia.Count);
                KartyGracza.Add(Talia[indexGracz]);
                Talia.RemoveAt(indexGracz);

                int indexKrupier = rand.Next(Talia.Count);
                KartyKrupiera.Add(Talia[indexKrupier]);
                Talia.RemoveAt(indexKrupier);
            }
        }

        public void DobierzKarte()
        {
            Random rand = new Random();
            int indexGracz = rand.Next(Talia.Count);
            KartyGracza.Add(Talia[indexGracz]);
            Talia.RemoveAt(indexGracz);

            SprawdzWynikGry();
        }
        public void Stand()
        {
            Random rand = new Random();
            while (ObliczWartoscRęki(KartyKrupiera) < 17)
            {
                int indexKrupier = rand.Next(Talia.Count);
                KartyKrupiera.Add(Talia[indexKrupier]);
                Talia.RemoveAt(indexKrupier);
            }

            SprawdzWynikGry();
        }
        private void SprawdzWynikGry()
        {
            int punktyGracz = ObliczWartoscRęki(KartyGracza);
            int punktyKrupier = ObliczWartoscRęki(KartyKrupiera);

            if (punktyGracz > 21)
            {
                WynikGry = "Przegrałeś!";
            }
            else if (punktyKrupier > 21)
            {
                WynikGry = "Wygrałeś!";
            }
            else if (punktyGracz == punktyKrupier)
            {
                WynikGry = "Remis!";
            }
            else if (punktyGracz > punktyKrupier)
            {
                WynikGry = "Wygrałeś!";
            }
            else
            {
                WynikGry = "Przegrałeś!";
            }
        }

        private int ObliczWartoscRęki(List<string> karty)
        {
            int suma = 0;
            int asy = 0;

            foreach (var karta in karty)
            {
                var figura = karta.Split(' ')[0];

                if (figura == "As")
                {
                    asy++;
                    suma += 11;
                }
                else if (figura == "Król" || figura == "Królowa" || figura == "Walet")
                {
                    suma += 10;
                }
                else
                {
                    suma += int.Parse(figura);
                }
            }

            while (suma > 21 && asy > 0)
            {
                suma -= 10;
                asy--;
            }

            return suma;
        }

    }
}
