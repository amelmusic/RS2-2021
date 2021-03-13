using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class Proizvodi
    {
        public Proizvodi()
        {
            IzlazStavkes = new HashSet<IzlazStavke>();
            NarudzbaStavkes = new HashSet<NarudzbaStavke>();
            Ocjenes = new HashSet<Ocjene>();
            UlazStavkes = new HashSet<UlazStavke>();
        }

        public int ProizvodId { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public decimal Cijena { get; set; }
        public int VrstaId { get; set; }
        public int JedinicaMjereId { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public bool? Status { get; set; }

        public virtual JediniceMjere JedinicaMjere { get; set; }
        public virtual VrsteProizvodum Vrsta { get; set; }
        public virtual ICollection<IzlazStavke> IzlazStavkes { get; set; }
        public virtual ICollection<NarudzbaStavke> NarudzbaStavkes { get; set; }
        public virtual ICollection<Ocjene> Ocjenes { get; set; }
        public virtual ICollection<UlazStavke> UlazStavkes { get; set; }
    }
}
