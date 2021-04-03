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

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
