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
            ilan.Marka = txtMarka.Text;
            ilan.Seri = txtSeri.Text;
            ilan.Model = txtModel.Text;
            ilan.Ilan_bas = txtİlanbas.Text;
            ilan.Yil = nmYil.Value;
            ilan.KM = nmKM.Value;
            ilan.Renk = txtRenk.Text;
            ilan.Fiyat = nmFiyat.Value;
            ilan.ililce = txtİl.Text;
            ilan.Ilan_tarih = İlantarih.Value;
            if (!string.IsNullOrEmpty(ilan.Resim))
            {
                pcResim.Load(ilan.Resim);
            }
            ilan.Bilgi = txtBilgi.Text;
        }


    }
}
