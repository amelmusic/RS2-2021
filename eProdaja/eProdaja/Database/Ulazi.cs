using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class Ulazi
    {
        public Ulazi()
        {
            UlazStavkes = new HashSet<UlazStavke>();
        }

        public int UlazId { get; set; }
        public string BrojFakture { get; set; }
        public DateTime Datum { get; set; }
        public decimal IznosRacuna { get; set; }
        public decimal Pdv { get; set; }
        public string Napomena { get; set; }
        public int SkladisteId { get; set; }
        public int KorisnikId { get; set; }
        public int DobavljacId { get; set; }

        public virtual Dobavljaci Dobavljac { get; set; }
        public virtual Korisnici Korisnik { get; set; }
        public virtual Skladistum Skladiste { get; set; }
        public virtual ICollection<UlazStavke> UlazStavkes { get; set; }
    }
}
