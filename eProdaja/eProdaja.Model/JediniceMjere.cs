using System;
using System.Collections.Generic;
using System.Text;

namespace eProdaja.Model
{
    public partial class JediniceMjere
    {
        public int JedinicaMjereId { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }
    }
}
