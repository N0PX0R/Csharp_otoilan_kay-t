using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtoİlanSoft
{
    public partial class İlanForm : Form
    {
        public İlanForm()
        {
            InitializeComponent();
        }
        string resimlinki;

        private void lnkEkle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pcResim.Load(openFileDialog1.FileName);
                resimlinki = openFileDialog1.FileName;
            }
        }
        private void lnkKaldir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pcResim.Image = null;
            resimlinki = null;
        }

        public İlan İlanlar { get; set; }
        private void btnTamam_Click(object sender, EventArgs e)
        {
            İlanlar = new İlan() { İlanID = Guid.NewGuid() };
            IlanBilgiGuncelle();
            DialogResult = DialogResult.OK;
        }

        private void IlanBilgiGuncelle()
        {
            İlanlar.Marka = txtMarka.Text;
            İlanlar.Seri = txtSeri.Text;
            İlanlar.Model = txtModel.Text;
            İlanlar.Ilan_bas = txtİlanbas.Text;
            İlanlar.Yil = nmYil.Value;
            İlanlar.KM = nmKM.Value;
            İlanlar.Renk = txtRenk.Text;
            İlanlar.Fiyat = nmFiyat.Value;
            İlanlar.ililce = txtİl.Text;
            İlanlar.Ilan_tarih = İlantarih.Value;
            İlanlar.Resim = resimlinki;
            İlanlar.Bilgi = txtBilgi.Text;
        }

        public void İlanbilgileriniyukle(İlan ilan)
        {
            txtMarka.Text = ilan.Marka;
            txtSeri.Text = ilan.Seri;
            txtModel.Text = ilan.Model;
            txtİlanbas.Text = ilan.Ilan_bas;
            nmYil.Value = ilan.Yil;
            nmKM.Value = ilan.KM;
            txtRenk.Text = ilan.Renk;
            nmFiyat.Value = ilan.Fiyat;
            txtİl.Text = ilan.ililce;
            İlantarih.Value = ilan.Ilan_tarih;
            
            if (!string.IsNullOrEmpty(ilan.Resim))
            {
                pcResim.Load(ilan.Resim);
            }
            txtBilgi.Text = ilan.Bilgi;
        }


    }
}
