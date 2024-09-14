using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Klase
{
    public class Podaci
    {
        public List<Banka> ListaBanki = new List<Banka>() 
        {
            new Banka() {Simbol = "RBA", Naziv = "Raifeissen Banka"},
            new Banka() {Simbol = "ZABA", Naziv = "Zagrebacka Banka"},
            new Banka() {Simbol = "ERST", Naziv = "Erste Banka"}
        };
        
        public List<Klijent> ListaKlijenata = new List<Klijent>()
        {
            new Klijent() {ImePrezime = "Pero Peric", Stanje = 1000.0, Banka = "RBA"},
            new Klijent() {ImePrezime = "Marko Markic", Stanje = 1000000.0, Banka = "RBA"},
            new Klijent() {ImePrezime = "Ivan Ivic", Stanje = 100000.0, Banka = "RBA"},
            new Klijent() {ImePrezime = "Mima Mimic", Stanje = 10000000.0, Banka = "ZABA"},
            new Klijent() {ImePrezime = "Ana Anic", Stanje = 100000.0, Banka = "ZABA"},
            new Klijent() {ImePrezime = "Jozo Jozic", Stanje = 100.0, Banka = "ZABA"},
            new Klijent() {ImePrezime = "Ciro Ciric", Stanje = 10000.0, Banka = "ZABA"},
            new Klijent() {ImePrezime = "Grga Grgic", Stanje = 100000000.0, Banka = "ERST"},
            new Klijent() {ImePrezime = "Janko Jankic", Stanje = 100.0, Banka = "ERST"},
            new Klijent() {ImePrezime = "Hrvoje Hrvic", Stanje = 10000000.0, Banka = "ERST"},
            new Klijent() {ImePrezime = "Ferdo Ferdic", Stanje = 1000.0, Banka = "ERST"},
            new Klijent() {ImePrezime = "Slavko Slavkic", Stanje = 1000.0, Banka = "RBA"},

        };
    }
}
