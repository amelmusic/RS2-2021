using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI
{
    public partial class frmKorisniciDetails : Form
    {
        APIService korisniciService = new APIService("Korisnici");
        APIService ulogeService = new APIService("Uloge");

        private Korisnici _korisnik;
        public frmKorisniciDetails(Korisnici korisnik = null)
        {
            InitializeComponent();
            _korisnik = korisnik;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void frmKorisniciDetails_Load(object sender, EventArgs e)
        {
            await LoadUloge();
            if (_korisnik != null)
            {
                txtIme.Text = _korisnik.Ime;
                txtPrezime.Text = _korisnik.Prezime;
                txtUsername.Text = _korisnik.KorisnickoIme;
                txtEmail.Text = _korisnik.Email;
                chkStatus.Checked = _korisnik.Status.GetValueOrDefault(false);
            }

        }

        private async Task LoadUloge()
        {
            var uloge = await ulogeService.GetAll<List<Uloge>>();
            clbUloge.DataSource = uloge;
            clbUloge.DisplayMember = "Naziv";
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_korisnik == null)
            {
                var ulogeList = clbUloge.CheckedItems.Cast<Uloge>();
                var ulogeIdList = ulogeList.Select(x => x.UlogaId).ToList();
                //insert
                KorisniciInsertRequest request = new KorisniciInsertRequest()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Email = txtEmail.Text,
                    KorisnickoIme = txtUsername.Text,
                    Password = txtPassword.Text,
                    PasswordPotvrda = txtPasswordPotvrda.Text,
                    Status = chkStatus.Checked,
                    Uloge = ulogeIdList
                };

               var korisnik = await korisniciService.Insert<Korisnici>(request);
            } 
            else
            {
                //update
                KorisniciUpdateRequest request = new KorisniciUpdateRequest()
                {
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    Status = chkStatus.Checked
                };

                var korisnik = await korisniciService.Update<Korisnici>(_korisnik.KorisnikId, request);
            }
        }
    }
}
