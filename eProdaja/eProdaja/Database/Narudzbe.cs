using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class Narudzbe
    {
        public Narudzbe()
        {
            Izlazis = new HashSet<Izlazi>();
            NarudzbaStavkes = new HashSet<NarudzbaStavke>();
        }

        public int NarudzbaId { get; set; }
        public string BrojNarudzbe { get; set; }
        public int KupacId { get; set; }
        public DateTime Datum { get; set; }
        public bool Status { get; set; }
        public bool? Otkazano { get; set; }

        public virtual Kupci Kupac { get; set; }
        public virtual ICollection<Izlazi> Izlazis { get; set; }
        public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; }
    }
}
