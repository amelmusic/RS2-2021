using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eProdaja.Model;
using eProdaja.Model.Requests;
using Flurl.Http;
namespace eProdaja.WinUI
{
    public partial class frmKorisnici : Form
    {
        APIService korisniciService = new APIService("Korisnici");

        public frmKorisnici()
        {
            InitializeComponent();
            dgvKorisnici.AutoGenerateColumns = false;
        }


        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            KorisniciSearchRequest searchRequest = new KorisniciSearchRequest()
            {
                Ime = txtIme.Text
            };

            var list = await korisniciService.GetAll<List<Korisnici>>(searchRequest);
            var prvi = list[0];

            dgvKorisnici.DataSource = list;
        }

        private void dgvKorisnici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvKorisnici.SelectedRows[0].DataBoundItem;

            //
            frmKorisniciDetails frm = new frmKorisniciDetails(item as Korisnici);
            frm.ShowDialog();
        }

        private void btnNoviKorisnik_Click(object sender, EventArgs e)
        {
            frmKorisniciDetails frm = new frmKorisniciDetails();
            frm.ShowDialog();
        }
    }
}
