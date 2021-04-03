using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eProdaja.Model.Requests
{
    public class KorisniciInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Ime { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Prezime { get; set; }
        [Required(AllowEmptyStrings = false)]
        [EmailAddress()]
        public string Email { get; set; }


        public string Telefon { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string KorisnickoIme { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(4)]
        public string PasswordPotvrda { get; set; }
        public bool? Status { get; set; }

        public List<int> Uloge { get; set; } = new List<int>();
    }
}
