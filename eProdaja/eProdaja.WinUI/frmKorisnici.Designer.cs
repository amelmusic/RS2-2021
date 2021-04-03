namespace eProdaja.WinUI
{
    partial class frmKorisnici
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvKorisnici = new System.Windows.Forms.DataGridView();
            this.clmIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.btnNoviKorisnik = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKorisnici
            // 
            this.dgvKorisnici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKorisnici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIme,
            this.clmPrezime,
            this.clmStatus});
            this.dgvKorisnici.Location = new System.Drawing.Point(3, 73);
            this.dgvKorisnici.Name = "dgvKorisnici";
            this.dgvKorisnici.RowHeadersWidth = 51;
            this.dgvKorisnici.RowTemplate.Height = 24;
            this.dgvKorisnici.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKorisnici.Size = new System.Drawing.Size(793, 365);
            this.dgvKorisnici.TabIndex = 0;
            this.dgvKorisnici.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKorisnici_CellDoubleClick);
            // 
            // clmIme
            // 
            this.clmIme.DataPropertyName = "Ime";
            this.clmIme.HeaderText = "Ime";
            this.clmIme.MinimumWidth = 6;
            this.clmIme.Name = "clmIme";
            this.clmIme.Width = 125;
            // 
            // clmPrezime
            // 
            this.clmPrezime.DataPropertyName = "Prezime";
            this.clmPrezime.HeaderText = "Prezime korisnika";
            this.clmPrezime.MinimumWidth = 6;
            this.clmPrezime.Name = "clmPrezime";
            this.clmPrezime.Width = 125;
            // 
            // clmStatus
            // 
            this.clmStatus.DataPropertyName = "Status";
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.MinimumWidth = 6;
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.Width = 125;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(560, 30);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(102, 23);
            this.btnPrikazi.TabIndex = 1;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(13, 31);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(255, 22);
            this.txtIme.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ime:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(283, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Prezime:";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(283, 31);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(255, 22);
            this.txtPrezime.TabIndex = 4;
            // 
            // btnNoviKorisnik
            // 
            this.btnNoviKorisnik.Location = new System.Drawing.Point(668, 31);
            this.btnNoviKorisnik.Name = "btnNoviKorisnik";
            this.btnNoviKorisnik.Size = new System.Drawing.Size(120, 23);
            this.btnNoviKorisnik.TabIndex = 6;
            this.btnNoviKorisnik.Text = "Novi korisnik";
            this.btnNoviKorisnik.UseVisualStyleBackColor = true;
            this.btnNoviKorisnik.Click += new System.EventHandler(this.btnNoviKorisnik_Click);
            // 
            // frmKorisnici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnNoviKorisnik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.dgvKorisnici);
            this.Name = "frmKorisnici";
            this.Text = "frmKorisnici";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKorisnici)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKorisnici;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrezime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmStatus;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Button btnNoviKorisnik;
    }
}