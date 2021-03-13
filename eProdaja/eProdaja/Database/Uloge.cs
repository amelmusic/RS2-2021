using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class Uloge
    {
        public Uloge()
        {
            KorisniciUloges = new HashSet<KorisniciUloge>();
        }

        public int UlogaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; }
    }
}
