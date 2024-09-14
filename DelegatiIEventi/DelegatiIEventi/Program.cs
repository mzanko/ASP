using DelegatiIEventi;
using System.ComponentModel.DataAnnotations;

namespace DelegatiIEventi
{
    public delegate int ZbrojBrojeva(int a, int b);
    public delegate bool ParniBrojevi(int a);
    public delegate string NajduziString(string a, string b);
    public delegate double Potenciranje(double a, double b);
    public delegate double[] UsporediBrojeve(double[] array, int leftIndex, int rightIndex);
    public delegate int BrojanjeSlova(string a, char b);
    public delegate long Faktorijele(int broj);
    public delegate double Korijen(double broj);


    internal class Program
    {
        static void Main(string[] args)
        {
            //ZADATAK 1
            ZbrojBrojeva zbr = Zbroj;
            Console.WriteLine($"Rezultat 2+3 je: {zbr(2, 3)}");

            //ZADATAK 2
            ParniBrojevi par = Parnost;
            Console.WriteLine($"2 je {(par(2) ? "paran":"neparan")} broj.");

            //ZADATAK 3
            NajduziString str = NajduziStr;
            Console.WriteLine($"Koji string je duži: mačka ili pas? {str("macka", "pas")}");

            //ZADATAK 4
            Potenciranje pot = Potenciraj;
            Console.WriteLine($"2 na 3: {pot(2, 3)}");

            //ZADATAK 5
            UsporediBrojeve sortiraj = Sortiraj;
            double[] a = { 2.2, 3.4, 5.6, 1.2, -3.4 };

            Console.Write($"Nesortirani niz je: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]};");
            }
            Console.WriteLine($" ");

            a = sortiraj(a, 0, a.Length - 1);

            Console.Write($"Sortirani niz je: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]};");
            }
            Console.WriteLine($" ");

            //ZADATAK 6
            BrojanjeSlova slovo = BrojiSlovo;
            Console.WriteLine($"Slovo a u rijeci macka se ponavlja: {slovo("mačka", 'a')} puta");

            //ZADATAK 7
            Faktorijele faktorijela = IzracunajFaktorijelu;
            long rezFaktorijela = faktorijela(5);
            Console.WriteLine($"Faktorijela broja 5 je {rezFaktorijela};");

            //ZADATAK 8
            Korijen korijen = IzracunajKorijen;
            double rezKorijen = korijen(25);
            Console.WriteLine($"Korijen broja 25 je {rezKorijen};");

        }

        public static int Zbroj(int a, int b)
        {
            return a + b;
        }

        public static bool Parnost(int a)
        {
            return a % 2 == 0;
        }

        public static string NajduziStr(string a, string b)
        {
            if(a.Length > b.Length)
            {
                return a;
            }
            else
            {
                return b;
            }
             
        }

        public static double Potenciraj(double a, double b)
        {
            return Math.Pow(a, b);
        }

        public static int Usporedi(double a, double b)
        {
            if (a <= b)
            {
                if (a < b)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 1;
            }        
        }

        public static double[] Sortiraj(double[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    double temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                Sortiraj(array, leftIndex, j);
            if (i < rightIndex)
                Sortiraj(array, i, rightIndex);
            return array;
        }

        public static int BrojiSlovo(string a, char b)
        {
            int j = 0;
            foreach (char c in a)
            {
                if (b.Equals(c))
                {
                    j++;
                }
            }
            return j;
        }

        public static long IzracunajFaktorijelu(int broj)
        {
            long rez = 1;
            for(int i = 1; i <= broj; i++)
            {
                rez *= i;
            }
            return rez;
        }

        public static double IzracunajKorijen(double broj)
        {
            return Math.Sqrt(broj);
        }
    }
}