using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eProdaja.Model;
using eProdaja.Model.Requests;

namespace eProdaja.WinUI.Proizvodi
{
    public partial class frmProizvodi : Form
    {
        private readonly APIService _jediniceMjere = new APIService("JediniceMjere");
        private readonly APIService _vrsteProizvodum = new APIService("VrsteProizvodum");
        private readonly APIService _proizvodi = new APIService("Proizvodi");

        public frmProizvodi()
        {
            InitializeComponent();
        }

        private async void frmProizvodi_Load(object sender, EventArgs e)
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            await LoadJedinicaMjere();
            await LoadVrsteProizvoda();
            await LoadProizvodi();
        }

        private async Task LoadJedinicaMjere()
        {
            var result = await _jediniceMjere.GetAll<List<JediniceMjere>>();

            result.Insert(0, new JediniceMjere());
            cmbJedinicaMjere.DisplayMember = "Naziv";
            cmbJedinicaMjere.ValueMember = "JedinicaMjereId";
            cmbJedinicaMjere.DataSource = result;

        }

        private async Task LoadVrsteProizvoda()
        {
            var result = await _vrsteProizvodum.GetAll<List<VrsteProizvodum>>();
            result.Insert(0, new VrsteProizvodum());
            cmbVrstaProizvoda.DisplayMember = "Naziv";
            cmbVrstaProizvoda.ValueMember = "VrstaId";
            cmbVrstaProizvoda.DataSource = result;
        }

        private async Task LoadProizvodi(int vrstaProizvodaId = 0)
        {
            ProizvodiSearchObject search = new ProizvodiSearchObject();
            search.IncludeList = new string[]
            {
                "JedinicaMjere",
                "Vrsta"
            };

            if (vrstaProizvodaId != 0)
            {
                search.VrstaId = vrstaProizvodaId;
            }
            var result = await _proizvodi.GetAll<List<Model.Proizvodi>>(search);
            dgvProizvodi.DataSource = result;
        }

        private async void cmbVrstaProizvoda_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idObj = cmbVrstaProizvoda.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int id))
            {
                await LoadProizvodi(id);
            }
        }

        private void btnUcitajSliku_Click(object sender, EventArgs e)
        {
            var result = ofdSlika.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = ofdSlika.FileName;
                var file = File.ReadAllBytes(fileName);

                txtSlika.Text = fileName;
                pbxSlika.Image = Image.FromFile(fileName);

            }
        }

        private ProizvodiInsertRequest insert = new ProizvodiInsertRequest();
        private ProizvodiUpdateRequest update = new ProizvodiUpdateRequest();
        private async void btnSave_Click(object sender, EventArgs e)
        {
            var idObj = cmbVrstaProizvoda.SelectedValue;

            if (int.TryParse(idObj.ToString(), out int vrstaId))
            {
                insert.VrstaId = vrstaId;
                update.VrstaId = vrstaId;
            }

            var jedinicaMjereObj = cmbJedinicaMjere.SelectedValue;

            if (int.TryParse(jedinicaMjereObj.ToString(), out int jedinicaMjereId))
            {
                insert.JedinicaMjereId = jedinicaMjereId;
                update.JedinicaMjereId = jedinicaMjereId;
            }

            insert.Naziv = update.Naziv = txtNaziv.Text;
            insert.Sifra = txtSifra.Text;

            if (decimal.TryParse(txtCijena.Text, out decimal cijena))
            {
                insert.Cijena = update.Cijena = cijena;
            }

            if (selectedProizvod == null)
            {
                await _proizvodi.Insert<Model.Proizvodi>(insert);
            }
            else
            {
                await _proizvodi.Update<Model.Proizvodi>(selectedProizvod.ProizvodId, update);
            }
            
        }

        private Model.Proizvodi selectedProizvod = null;
        private void dgvProizvodi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var item = dgvProizvodi.SelectedRows[0].DataBoundItem as Model.Proizvodi;

            selectedProizvod = item;

            txtNaziv.Text = selectedProizvod.Naziv;
            txtSifra.Text = selectedProizvod.Sifra;
            //TODO: nastaviti
        }
    }
}
