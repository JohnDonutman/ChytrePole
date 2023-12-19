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
        public Pole(bool jeCiselnePole)
        {
            this.jeCiselnePole = jeCiselnePole;
        }

        public String vytvorPole(int pocetPrvku)
        {
            if (jeCiselnePole)
            {
                this.ciselnePole = new int[pocetPrvku];
                return "Vytvořil jsi číselné pole";
            }
            else
            {
                this.slovniPole = new String[pocetPrvku];
                return "Vytvořil jsi slovní pole";
            }
        }

        // implementace Count
        public int spocitejPrvky()
        {
            int pocetPrvku = 0;
            if (jeCiselnePole)
            {
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    if (ciselnePole[i] != 0 )
                    {
                        pocetPrvku++;
                    }
                }
            }
            else
            {
                for (int i = 0; i < slovniPole.Length; i++)
                {
                    if (slovniPole[i] != null)
                    {
                        pocetPrvku++;
                    }
                }
            }
            return pocetPrvku;
        }

        // implementace Items (indexer)
        public String ukazPrvek(int mistoPole)
        {
            if (jeCiselnePole)
            {
                if (mistoPole > ciselnePole.Length || mistoPole <= 0)
                {
                    return "Zadal jsi index mimo rozsah pole";
                }
                else
                {
                    int prvekInt = ciselnePole[mistoPole - 1];
                    String prvek = String.Format("{0}", prvekInt);
                    return String.Format("Na hledaném místě se nachází: " + prvek);
                }
            }
            else
            {
                if (mistoPole > slovniPole.Length || mistoPole <= 0)
                {
                    return "Zadal jsi index mimo rozsah pole";
                }
                else
                {
                    return String.Format("Na hledaném místě se nachází: " + slovniPole[mistoPole - 1]);
                }
            }
        }

        // implementace Add
        public String pridejPrvek(String vstup)
        {
            String vystup = "Pole je plné, už nemůžeš přidat další prvky";
            if (jeCiselnePole)
            {
                int vstupInt = int.Parse(vstup);
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    if (ciselnePole[i] == 0)
                    {
                        ciselnePole[i] = vstupInt;
                        vystup = "Přidal jsem tvůj prvek";
                        break;
                    }
                }
            }
            else
            {
                vstup = vstup.Trim();
                for (int i = 0; i < slovniPole.Length; i++)
                {
                    if (slovniPole[i] == null)
                    {
                        slovniPole[i] = vstup;
                        vystup = "Přidal jsem tvůj prvek";
                        break;
                    }
                }
            }
            return vystup;
        }

        // implementace AddRange mi nedává smysl, protože nelze měnit velikost pole určenou na začátku konstrukce pole

        // implementace Remove
        public String odstranPrvek(String vstup)
        {
            String vystup = "Prvek se v poli nenachází, takže ho nemůžu odstranit";
            if (jeCiselnePole)
            {
                int vstupInt = int.Parse(vstup);
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    if (ciselnePole[i] == vstupInt)
                    {
                        ciselnePole[i] = 0;
                        vystup = "Odstranil jsem tvůj prvek";
                        break;
                    }
                }
            }
            else
            {
                vstup = vstup.Trim();
                for (int i = 0; i < slovniPole.Length; i++)
                {
                    if (slovniPole[i].Equals(vstup))
                    {
                        slovniPole[i] = null;
                        vystup = "Odstranil jsem tvůj prvek";
                        break;
                    }
                }
            }
            return vystup;
        }

        // implementace RemoveAt
        public String nahradPrvek(String novyPrvek, int mistoPole)
        {
            String vystup = "Nahradil jsem prvek na tebou zvoleném místě";
            if (jeCiselnePole)
            {
                if (mistoPole > ciselnePole.Length || mistoPole <= 0)
                {
                    vystup = "Zadal jsi index mimo rozsah pole";
                }
                else
                {
                    int ciselnyPrvek = int.Parse(novyPrvek);
                    ciselnePole[mistoPole - 1] = ciselnyPrvek;
                }
            }
            else
            {
                if (mistoPole > slovniPole.Length || mistoPole <= 0)
                {
                    vystup = "Zadal jsi index mimo rozsah pole";
                }
                else
                {
                    slovniPole[mistoPole - 1] = novyPrvek;
                }
            }
            return vystup;
        }

        // implementace IndexOf
        public String najdiPrvniVyskyt(String vstup)
        {
            String vystup = "Tvoje zadání se zde nenachází";
            if (jeCiselnePole)
            {
                int vstupInt = int.Parse(vstup);
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    if (ciselnePole[i] == vstupInt)
                    {
                        vystup = String.Format("Tvoje zadání se poprvé nachází na {0}. místě v poli", i + 1);
                        break;
                    }
                }
            }
            else
            {
                vstup = vstup.Trim();
                for (int i = 0; i < slovniPole.Length; i++)
                {
                    if (slovniPole[i].Equals(vstup))
                    {
                        vystup = String.Format("Tvoje zadání se poprvé nachází na {0}. místě v poli", i + 1);
                        break;
                    }
                }
            }
            return vystup;
        }

        // implementace LastIndexOf
        public String najdiPosledniVyskyt(String vstup)
        {
            String vystup = "Tvoje zadání se zde nenachází";
            if (jeCiselnePole)
            {
                otocPrvkyPole(0, ciselnePole.Length - 1);
                int vstupInt = int.Parse(vstup);
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    if (ciselnePole[i] == vstupInt)
                    {
                        vystup = String.Format("Tvoje zadání se naposledy nachází na {0}. místě v poli", ciselnePole.Length - i);
                        break;
                    }
                }
                otocPrvkyPole(0, ciselnePole.Length - 1);
            }
            else
            {
                otocPrvkyPole(0, slovniPole.Length - 1);
                vstup = vstup.Trim();
                for (int i = 0; i < slovniPole.Length; i++)
                {
                    if (slovniPole[i].Equals(vstup))
                    {
                        vystup = String.Format("Tvoje zadání se naposledy nachází na {0}. místě v poli", slovniPole.Length - i);
                        break;
                    }
                }
                otocPrvkyPole(0, slovniPole.Length - 1);
            }
            return vystup;
        }

        // implementace Clear
        public String vymazPrvky()
        {
            if (jeCiselnePole)
            {
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    ciselnePole[i] = 0;
                }
            }
            else
            {
                for (int i = 0; i < slovniPole.Length; i++)
                {
                    slovniPole[i] = null;
                }
            }
            return "Celé pole je vyčištěno";
        }

        // implementace Sort (vzestupně)
        public String seradVzestupne()
        {
            if (jeCiselnePole)
            {
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    for (int j = i + 1; j < ciselnePole.Length; j++)
                    {
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
            return "Tvoje pole je seřazeno vzestupně";
        }

        // implementace Sort (sestupně)
        public String seradSestupne()
        {
            if (jeCiselnePole)
            {
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    for (int j = i + 1; j < ciselnePole.Length; j++)
                    {
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
            return "Tvoje pole je seřazeno sestupně";
        }

        // výpis prvků pole
        public void vypisPrvky()
        {
            Console.WriteLine("Vaše prvky jsou aktuálně: ");
            if (jeCiselnePole)
            {
                for (int i = 0; i < ciselnePole.Length; i++)
                {
                    if (ciselnePole[i] != 0)
                    {
                        int prvek = ciselnePole[i];
                        Console.Write("{0}, ", prvek);
                    }
                }
            }
            else
            {
                for (int i = 0; i < slovniPole.Length; i++)
                {
                    if (slovniPole[i] != null)
                    {
                        Console.Write(slovniPole[i] + ", ");
                    }
                }
            }
        }

        // pomocná metoda na otočení prvků v poli
        private void otocPrvkyPole(int startIndex, int endIndex)
        {
            if (jeCiselnePole)
            {
                while (startIndex < endIndex)
                {
                    int temp = ciselnePole[startIndex];
                    ciselnePole[startIndex] = ciselnePole[endIndex];
                    ciselnePole[endIndex] = temp;
                    startIndex++;
                    endIndex--;
                }
            }
            else
            {
                while (startIndex < endIndex)
                {
                    String temp = slovniPole[startIndex];
                    slovniPole[startIndex] = slovniPole[endIndex];
                    slovniPole[endIndex] = temp;
                    startIndex++;
                    endIndex--;
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vítej v tvorbě chytrého pole.");
            Pole pole = null;
            // zadání parametrů pole
            bool pokracujeme = false;
            while (pokracujeme == false)
            {
                Console.WriteLine("Zadej, jaké pole chceš vytvořit (stiskni číslici a potvrď): \n" +
                "1 - číselné pole (můžeš přidat jakékoli číslo kromě nuly) \n" +
                "0 - slovní pole (můžeš přidat jakýkoli znak či slovo kromě samostatné mezery)");
                String typPole = Console.ReadLine();
                Console.WriteLine("Nyní zadej maximální počet prvků v poli:");
                String pocetPrvkuString = Console.ReadLine();
                typPole = typPole.Trim();
                int pocetPrvku;
                int.TryParse(pocetPrvkuString, out pocetPrvku);
                bool jeCiselnePole;

                // vytváření pole a případné pokračování
                if (typPole.Equals("0") && pocetPrvku != 0)
                {
                    jeCiselnePole = false;
                    pole = new Pole(jeCiselnePole);
                    pole.vytvorPole(pocetPrvku);
                    Console.WriteLine("Výborně, vytvořil jsi textové pole");
                    pokracujeme = true;
                }
                else if (typPole.Equals("1") && pocetPrvku != 0)
                {
                    jeCiselnePole = true;
                    pole = new Pole(jeCiselnePole);
                    pole.vytvorPole(pocetPrvku);
                    Console.WriteLine("Výborně, vytvořil jsi číselné pole");
                    pokracujeme = true;
                }
                else
                {
                    Console.WriteLine("Nezadal jsi správně typ pole, nebo počet prvků");
                }
            }

            bool ukonciProgram = false;
            
            // vykonávání činností pole
            while (ukonciProgram  == false)
            {
                Console.WriteLine("Co chceš dělat se svým polem?");
                Console.WriteLine(
                    "0 - zjistit počet prvků v poli \n" +
                    "1 - přidat nový prvek \n" +
                    "2 - odstranit konkrétní prvek podle hodnoty \n" +
                    "3 - nahradit prvek na konkrétním místě v poli \n" +
                    "4 - zjistit index prvního výskytu mého prvku \n" +
                    "5 - zjistit index posledního výskytu mého prvku \n" +
                    "6 - vymazat všechny prvky v poli \n" +
                    "7 - seřadit všechny prvky vzestupně \n" +
                    "8 - seřadit všechny prvky sestupně \n" +
                    "9 - zjistit prvek podle konkrétního místa v poli \n" +
                    "10 - vypiš prvky pole \n" +
                    "11 - ukonči program");
                String cinnostString = Console.ReadLine();
                int cinnost;
                if (int.TryParse(cinnostString, out cinnost))
                {
                    // kontrola, že je vstup v daném rozmezí
                    if (cinnost < 12 && cinnost > -1)
                    {
                        String vystup = "";
                        String vstup = "";
                        int misto;
                        switch (cinnost)
                        {
                            case 0:
                                Console.WriteLine(String.Format("V tvém poli je aktuálně: {0} prvků", pole.spocitejPrvky()));
                                break;
                            case 1:
                                Console.WriteLine("Zadejte prvek, který chcete přidat:");
                                vstup = Console.ReadLine();
                                Console.WriteLine(pole.pridejPrvek(vstup));
                                break;
                            case 2:
                                Console.WriteLine("Jaký prvek chceš smazat? Napiš ho!");
                                vstup = Console.ReadLine();
                                Console.WriteLine(pole.odstranPrvek(vstup));
                                break;
                            case 3:
                                Console.WriteLine("Prvek na kolikátém místě chceš nahradit? Napiš číslo!");
                                misto = int.Parse(Console.ReadLine());
                                Console.WriteLine("Čím ho chceš nahradit?");
                                vstup = Console.ReadLine();
                                Console.WriteLine(pole.nahradPrvek(vstup, misto));
                                break;
                            case 4:
                                Console.WriteLine("Jaký prvek chceš zjistit? Napiš ho!");
                                vstup = Console.ReadLine();
                                Console.WriteLine(pole.najdiPrvniVyskyt(vstup));
                                break;
                            case 5:
                                Console.WriteLine("Jaký prvek chceš zjistit? Napiš ho!");
                                vstup = Console.ReadLine();
                                Console.WriteLine(pole.najdiPosledniVyskyt(vstup));
                                break;
                            case 6:
                                Console.WriteLine(pole.vymazPrvky());
                                break;
                            case 7:
                                Console.WriteLine(pole.seradVzestupne());
                                break;
                            case 8:
                                Console.WriteLine(pole.seradSestupne());
                                break;
                            case 9:
                                Console.WriteLine("Na kterém místě budeme prvek hledat? Napiš číslo!");
                                misto = int.Parse(Console.ReadLine());
                                Console.WriteLine(pole.ukazPrvek(misto));
                                break;
                            case 10:
                                pole.vypisPrvky();
                                break;
                            case 11:
                                ukonciProgram = true;
                                break;

                        }
                        Console.WriteLine(vystup);
                    }
                }
                else
                {
                    Console.WriteLine("Zadal jsi nesmysl, takže ukončím program...");
                    ukonciProgram = true;
                }
            }
        }
    }
}
