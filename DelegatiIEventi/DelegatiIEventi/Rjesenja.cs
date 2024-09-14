using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatiIEventi
{
    // 1. Zbroj brojeva
    delegate double ZbrojDelegat(double broj1, double broj2);

    // 2. Parni brojevi
    delegate bool ParDelegat(int broj);

    // 3. Najduži string
    delegate string DuljiStringDelegat(string str1, string str2);

    // 4. Potenciranje
    delegate double PotencijaDelegat(double broj, double potencija);

    // 5. Sortiranje niza
    delegate int UsporediDelegat(int broj1, int broj2); 
    
    // 6. Brojanje slova
    delegate int BrojSlovaDelegat(string str, char slovo);

    // 7. Faktorijel
    delegate long FaktorijelDelegat(int broj);

    // 8. Provjera palindroma
    delegate bool PalindromDelegat(string str);

    // 9. Razlika između datuma
    delegate int RazlikaDatumaDelegat(DateTime prviDatum, DateTime drugiDatum);

    // 10. Prosjek niza brojeva
    delegate double ProsjekNizaDelegat(params double[] brojevi); 
    
    // 1. Zbroj brojeva
        ZbrojDelegat zbrojDelegat = (broj1, broj2) => broj1 + broj2;
    Console.WriteLine("Zbroj: " + zbrojDelegat(5, 7));

        // 2. Parni brojevi
        ParDelegat parDelegat = broj => broj % 2 == 0;
    Console.WriteLine("Paran: " + parDelegat(6));

        // 3. Najduži string
        DuljiStringDelegat duljiStringDelegat = (str1, str2) => str1.Length >= str2.Length ? str1 : str2;
    Console.WriteLine("Najduži string: " + duljiStringDelegat("Ovo je prvi string", "Ovo je drugi string"));

        // 4. Potenciranje
        PotencijaDelegat potencijaDelegat = (broj, potencija) => Math.Pow(broj, potencija);
    Console.WriteLine("Potencija: " + potencijaDelegat(2, 3)); 6:04 PM
* Lecturer: Tomislav Šulentić:         // 5. Sortiranje niza
        UsporediDelegat usporediDelegat = (broj1, broj2) => broj1.CompareTo(broj2);
    int[] nizBrojeva = { 5, 3, 8, 1, 7 };
    Array.Sort(nizBrojeva, new Comparison<int>(usporediDelegat));
        Console.WriteLine("Sortirani niz: " + string.Join(", ", nizBrojeva));

        // 6. Brojanje slova
        BrojSlovaDelegat brojSlovaDelegat = (str, slovo) => str.Count(c => c == slovo);
    Console.WriteLine("Broj slova 'a': " + brojSlovaDelegat("Abrakadabra", 'a')); 
        
        // 7. Faktorijel
        FaktorijelDelegat faktorijelDelegat = broj =>
        {
            long faktorijel = 1;
            for (int i = 1; i <= broj; i++)
            {
                faktorijel *= i;
            }
            return faktorijel;
        };
    Console.WriteLine("Faktorijel: " + faktorijelDelegat(5));

        // 8. Provjera palindroma
        PalindromDelegat palindromDelegat = str => str == new string(str.Reverse().ToArray());
    Console.WriteLine("Palindrom: " + palindromDelegat("radar")); 6:04 PM
* Lecturer: Tomislav Šulentić:         // 9. Razlika između datuma
        RazlikaDatumaDelegat razlikaDatumaDelegat = (prviDatum, drugiDatum) => (drugiDatum - prviDatum).Days;
    Console.WriteLine("Razlika između datuma: " + razlikaDatumaDelegat(new DateTime(2022, 1, 1), new DateTime(2022, 1, 10)));

        // 10. Prosjek niza brojeva
        ProsjekNizaDelegat prosjekNizaDelegat = brojevi => brojevi.Length > 0 ? brojevi.Average() : 0;
    Console.WriteLine("Prosjek niza brojeva: " + prosjekNizaDelegat(2, 4, 6, 8)); 
}
