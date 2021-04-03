using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public partial class VrsteProizvodum
    {
        public int VrstaId { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return $"{VrstaId} - {Naziv}";
        }
    }
}
