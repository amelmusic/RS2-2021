using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model.Requests
{
    public class ProizvodiInsertRequest
    {
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public decimal Cijena { get; set; }
        public int VrstaId { get; set; }
        public int JedinicaMjereId { get; set; }
        public byte[] Slika { get; set; }
        public byte[] SlikaThumb { get; set; }
        public bool? Status { get; set; }
    }
}
