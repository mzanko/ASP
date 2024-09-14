

using EventiZadaci;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Timers;

namespace EventiZadaci
{
    

    class Program
    {
        public delegate void PritisakTipke(string tipka);
        public static event PritisakTipke OnTipke;

        public delegate void BrojacKlika(int broj);
        public static event BrojacKlika Klik;

        public delegate void PromjenaBoje(int tipka);
        public static event PromjenaBoje OnBoje;

        public delegate void Tajmer();
        public static event Tajmer OnTajmer;

        public delegate void IspisiPoruku(string poruka);
        public static event IspisiPoruku OnPoruka;

        public delegate int BrojacSlovaM(int broj, string slovo);
        public static event BrojacSlovaM OnKlikM;
        public static int broj;


        static void Main(string[] args)
        {
            /* 1. **Događaj pritiska tipke:**
               - Kreirajte program koji ima event koji se okida kada korisnik 
                pritisne tipku na tipkovnici.
               - Implementirajte konzolnu aplikaciju koja reagira na pritisak 
                tipki (npr. ispisujući poruku u konzoli) putem eventa.
            */
            OnTipke += TipkaStisnuta;

            Console.WriteLine("Pritisnite bilo koju tipku, ako stisnete q program ce zavrsiti sa radom");

            while(true)
            {
                var keyInfo = Console.ReadKey(true);
                if(keyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }
                OnTipke?.Invoke(keyInfo.KeyChar.ToString());
            }

            /*2. **Brojač klika:**
               - Kreirajte program koji ima event koji se okida 
                svaki put kada korisnik klikne na tipku.
               - Implementirajte konzolnu aplikaciju koja broji klikove i
                ispisuje broj klikova u konzoli putem eventa.
            */

            Klik += BrojKlikova;
            Console.WriteLine("Brojac klikova, ako stisnete q program ce zavrsiti sa radom");
            int brojKlikova = 0;

            while (true)
            {
                var keyInfo = Console.ReadKey(true);           
                if (keyInfo.Key == ConsoleKey.Q)
                {
                    break;
                }
                else
                {
                    brojKlikova++;
                    Klik?.Invoke(brojKlikova);
                }                    
            }

            /*3. **Promjena boje:**
               - Kreirajte program koji ima event koji se okida 
                kada korisnik zatraži promjenu boje.
               - Implementirajte konzolnu aplikaciju koja 
                mijenja boju teksta u konzoli putem eventa.
            */
            OnBoje += PromjeniBoju;
            Console.WriteLine("Promjeni boju, ako stisnete q program ce zavrsiti sa radom");

            while (true)
            {
                var keyInfo = Console.ReadLine();
                if (keyInfo.ToLower() == "q")
                {
                    break;
                }
                else
                {
                    if(Int32.Parse(keyInfo) > 9 && Int32.Parse(keyInfo) < 16)
                    {
                        OnBoje?.Invoke(Int32.Parse(keyInfo));
                    }
                    
                }
            }

            /* 5. **Događaj pritiska tipke:**
            - Kreirajte program koji ima event koji se okida kada korisnik 
            pritisne tipku p na tipkovnici.
            - Implementirajte konzolnu aplikaciju koja reagira na pritisak 
            tipki (npr. ispisujući poruku u konzoli) putem eventa.
            */
            OnPoruka += PosaljiPoruku;

            Console.WriteLine("Pritisnite p za poslati poruku, ako stisnete q program ce zavrsiti sa radom");

            while (true)
            {
                var poruka = Console.ReadLine();
                if (poruka.StartsWith('q') && poruka.EndsWith('q'))
                {
                    break;
                }
                OnPoruka?.Invoke(poruka);
            }

            /*6. **Brojač klika M:**
               - Kreirajte program koji ima event koji se okida 
                svaki put kada korisnik klikne na tipku.
               - Implementirajte konzolnu aplikaciju koja broji klikove i
                ispisuje broj klikova u konzoli putem eventa.
            */

            OnKlikM += BrojiKlikM;
            Console.WriteLine("Pritisnite M za brojat klikove, ako stisnete q program ce zavrsiti sa radom");

            while (true)
            {
                var poruka = Console.ReadLine();
                if (poruka.StartsWith('q') && poruka.EndsWith('q'))
                {
                    break;
                }
                OnKlikM?.Invoke(broj, poruka);

            }



            /*4. **Jednostavni tajmer:**
           - Kreirajte program koji ima event koji se
            okida nakon određenog vremena.
           - Implementirajte konzolnu aplikaciju koja čeka
            na okidanje eventa i ispisuje poruku kada se dogodi.
            */

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(VrijemeIsteklo);
            timer.Interval = 5000;
            timer.Enabled = true;

            Console.WriteLine("Tajmer, ako stisnete q program ce zavrsiti sa radom");
            while (Console.Read() != 'q') ;


        }

        static void TipkaStisnuta(string tipka)
        {
            Console.WriteLine($"Vas pritisak tipke je registriran: {tipka}");
        }

        static void BrojKlikova(int broj)
        {
            Console.WriteLine($"Klik je registriran. Broj klikova: {broj}");
        }

        static void PromjeniBoju(int tipka)
        {
            Console.ForegroundColor = (ConsoleColor)tipka;
            Console.SetWindowSize(50, 50);
            //Console.SetCursorPosition(100, 100);
            Console.WriteLine($"Klik je registriran. Nova boja");
        }

        static void VrijemeIsteklo(object source, ElapsedEventArgs e)
        {
            Console.WriteLine($"Interval od 5 sekundi je istekao.");
        }

        static void PosaljiPoruku(string poruka)
        {
            Console.WriteLine($"Vasa poruka je: {poruka}");
        }

        static int BrojiKlikM(int broj, string slovo)
        {
            if(slovo.StartsWith('M') && slovo.EndsWith('M'))
            {
                broj++;
                Console.WriteLine($"Klik slova M je registriran. Broj klikova: {broj}");
                return broj;
            }
            else
            {
                Console.WriteLine($"Klik slova M nije registriran. Broj klikova: {broj}");
                return broj;
            }
        }
    }

    

}