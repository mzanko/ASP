using Model.Klase;

namespace Linq
{
    public class Program
    {
        static void Main(string[] args)
        {
            Podaci podaci = new Podaci();
            var GrupirajPremaBanci = podaci.ListaKlijenata
                .Where(x => x.Stanje >= 1000000.0)
                .GroupBy(x => x.Banka, (banka, osobe) =>
                new GrupiraniMilijunasi()
                {
                    Banka = banka,
                    Milijunasi = osobe.Select(x => x.ImePrezime)
                }
                );

            foreach (var gr in GrupirajPremaBanci)
            {

                foreach (string mil in gr.Milijunasi)
                {
                    var str = gr.Banka + ": " + mil;
                    Console.WriteLine($"{str}");
                }
            }

            var FiltrirajPoBanci = GrupirajPremaBanci.Where(x => x.Banka == "ZABA");
            foreach (var gr in FiltrirajPoBanci)
            {

                foreach (string mil in gr.Milijunasi)
                {
                    var str = gr.Banka + ": " + mil;
                    Console.WriteLine($"{str}");
                }
            }

            var sortirajPoAbecedi = podaci.ListaKlijenata.OrderBy(x => x.ImePrezime);
            foreach(var item in sortirajPoAbecedi)
            {
                Console.WriteLine(item.ImePrezime);
            }

            var najBogatiji = podaci.ListaKlijenata.OrderByDescending(x => x.Stanje).FirstOrDefault();
            Console.WriteLine($"Najbogatiji: {najBogatiji.ImePrezime}");

            IEnumerable<Klijent> Klijents;
            var GrupirajPremaStanju = podaci.ListaKlijenata
                .GroupBy(x => x.Stanje, (banka, osobe) =>
                new
                {
                    Banka = banka,
                    Klijents = osobe.Select(x => x.ImePrezime).ToList(),
                }
                );
            foreach(var item in GrupirajPremaStanju)
            {
                foreach (string klijent in item.Klijents)
                {
                    var str = item.Banka + ": " + klijent;
                    Console.WriteLine($"{str}");
                }
            }
        }
        }
}
