using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class JediniceMjere
    {
        public JediniceMjere()
        {
            Proizvodis = new HashSet<Proizvodi>();
        }

        public int JedinicaMjereId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Proizvodi> Proizvodis { get; set; }
    }
}
