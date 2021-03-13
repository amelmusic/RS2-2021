using System;
using System.Collections.Generic;

#nullable disable

namespace eProdaja.Database
{
    public partial class Dobavljaci
    {
        public Dobavljaci()
        {
            Ulazis = new HashSet<Ulazi>();
        }

        public int DobavljacId { get; set; }
        public string Naziv { get; set; }
        public string KontaktOsoba { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Web { get; set; }
        public string Email { get; set; }
        public string ZiroRacuni { get; set; }
        public string Napomena { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Ulazi> Ulazis { get; set; }
    }
}
