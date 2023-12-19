using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ChytrePole
{
    class Pole
    {
        int[] ciselnePole;
        String[] slovniPole;
        bool jeCiselnePole;
        public Pole(bool jeCiselnePole, int pocetPrvku) 
        {
            this.jeCiselnePole = jeCiselnePole;
            vytvorPole(jeCiselnePole, pocetPrvku);
        }

        private void vytvorPole(bool jeCiselnePole, int pocetPrvku)
        {
            if (jeCiselnePole)
            {
                this.ciselnePole = new int[pocetPrvku];
            }
            else
            {
                this.slovniPole = new String[pocetPrvku];
            }
        }

        // implementace Count

        // implementace Items (indexer)

        // implementace Add

        // implementace AddRange

        // implementace Remove

        // implementace RemoveAt
        public void nahradPrvek(String novyPrvek, int mistoPole)
        {
            if (jeCiselnePole)
            {
                int ciselnyPrvek = int.Parse(novyPrvek);
                ciselnePole[mistoPole] = ciselnyPrvek;
            }
            else
            {
                slovniPole[mistoPole] = novyPrvek;
            }
        }

        // implementace IndexOf

        // implementace LastIndexOf

        // implementace Clear

        // implementace Sort (vzestupně)
        public void seradVzestupne()
        {
            if (jeCiselnePole)
            {
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    for (int j = i + 1; j < ciselnePole.Length; j++)
                    {
                        // pokud budu chtít řadit vzestupně, otočím znaménko v podmínce
                        if (ciselnePole[i] > ciselnePole[j])
                        {
                            int docasne = ciselnePole[i];
                            ciselnePole[i] = ciselnePole[j];
                            ciselnePole[j] = docasne;
                        }
                    }
                }
            }
            else
            {
                Array.Sort(slovniPole);
            }
        }

        // implementace Sort (sestupně)
        public void seradSestupne()
        {
            if (jeCiselnePole)
            {
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    for (int j = i + 1; j < ciselnePole.Length; j++)
                    {
                        // pokud budu chtít řadit vzestupně, otočím znaménko v podmínce
                        if (ciselnePole[i] < ciselnePole[j])
                        {
                            int docasne = ciselnePole[i];
                            ciselnePole[i] = ciselnePole[j];
                            ciselnePole[j] = docasne;
                        }
                    }
                }
            }
            else
            {
                Array.Reverse(slovniPole);
            }
        }

        // výpis prvků pole
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
