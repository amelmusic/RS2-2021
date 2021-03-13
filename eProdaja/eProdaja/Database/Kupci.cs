using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class Kupci
    {
        public Kupci()
        {
            Narudzbes = new HashSet<Narudzbe>();
            Ocjenes = new HashSet<Ocjene>();
        }

        public int KupacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public string Email { get; set; }
        public string KorisnickoIme { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Narudzbe> Narudzbes { get; set; }
        public virtual ICollection<Ocjene> Ocjenes { get; set; }
    }
}
