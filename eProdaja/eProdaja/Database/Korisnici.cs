using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class Korisnici
    {
        public Korisnici()
        {
            Izlazis = new HashSet<Izlazi>();
            KorisniciUloges = new HashSet<KorisniciUloge>();
            Ulazis = new HashSet<Ulazi>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Izlazi> Izlazis { get; set; }
        public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; }
        public virtual ICollection<Ulazi> Ulazis { get; set; }
    }
}
