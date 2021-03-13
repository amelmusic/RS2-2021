using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class Ocjene
    {
        public int OcjenaId { get; set; }
        public int ProizvodId { get; set; }
        public int KupacId { get; set; }
        public DateTime Datum { get; set; }
        public int Ocjena { get; set; }

        public virtual Kupci Kupac { get; set; }
        public virtual Proizvodi Proizvod { get; set; }
    }
}
