using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OtoİlanSoft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void İlanEkle(object sender, EventArgs e)
        {
            İlanForm form = new İlanForm() { Text = "İlan Ekle" };
            if (form.ShowDialog() == DialogResult.OK)
            {
                İlanlar.ilanlar.Add(form.İlanlar);

                ListeyiGüncelle();
            }
        }

        private void ListeyiGüncelle()
        {
            listView1.Items.Clear();
            foreach (var ilan in İlanlar.ilanlar)
            {
                İlanEkle(ilan);
            }
        }

        private void İlanEkle(İlan ilanlar)
        {
            ListViewItem k = new ListViewItem(new string[]
            {
                ilanlar.Marka,
                ilanlar.Seri,
                ilanlar.Model,
                ilanlar.Fiyat.ToString(),
                ilanlar.ililce,
                ilanlar.Ilan_tarih.ToString()
            });

            k.Tag = ilanlar;
            k.ToolTipText = ilanlar.Detay;

            listView1.Items.Add(k);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                pictureBox1.Image = null;
                textBox1.Text = "";
                return;
            }

            İlan ilan = listView1.SelectedItems[0].Tag as İlan;
            if (!string.IsNullOrEmpty(ilan.Resim))
                pictureBox1.Load(ilan.Resim);
            textBox1.Text = ilan.Detay;
        }

        private void İlanGüncelle(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            İlan ilan = listView1.SelectedItems[0].Tag as İlan;
            İlanForm form = new İlanForm()
            {
                Text = "İlan Güncelle",
            };
            form.İlanbilgileriniyukle(ilan);

            if (form.ShowDialog() == DialogResult.OK)
            {
                İlan i = İlanlar.ilanlar.Find(x => x.İlanID == ilan.İlanID);

                i.Marka = form.İlanlar.Marka;
                i.Seri = form.İlanlar.Seri;
                i.Model = form.İlanlar.Model;
                i.Ilan_bas = form.İlanlar.Ilan_bas;
                i.Yil = form.İlanlar.Yil;
                i.KM = form.İlanlar.KM;
                i.Renk = form.İlanlar.Renk;
                i.Fiyat = form.İlanlar.Fiyat;
                i.ililce = form.İlanlar.ililce;
                i.Ilan_tarih = form.İlanlar.Ilan_tarih;
                i.Resim = form.İlanlar.Resim;
                i.Bilgi = form.İlanlar.Bilgi;
                ListeyiGüncelle();
            }
        }

        private void İlansil(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            if (MessageBox.Show(
                "Silinsin mi",
                "Silmeyi onayla",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) != DialogResult.OK)
                return;

            İlan ilan = listView1.SelectedItems[0].Tag as İlan;
            İlan i = İlanlar.ilanlar.Find(x => x.İlanID == ilan.İlanID);
            İlanlar.ilanlar.Remove(i);
            ListeyiGüncelle();
        }

        private void JsonKaydet(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosya = saveFileDialog1.FileName;

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(İlanlar.ilanlar);
                File.WriteAllText(dosya, json);
            }
        }

        private void Jsonac(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosya = openFileDialog1.FileName;

                string json = File.ReadAllText(dosya);
                İlanlar.ilanlar = Newtonsoft.Json.JsonConvert.DeserializeObject<List<İlan>>(json);

                ListeyiGüncelle();
            }
        }

        private void XMLkaydet(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosya = saveFileDialog1.FileName;

                XmlSerializer xml = new XmlSerializer(typeof(List<İlan>));
                StreamWriter sw = new StreamWriter(dosya);
                xml.Serialize(sw, İlanlar.ilanlar);

                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }

        private void Xmlac(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosya = openFileDialog1.FileName;

                XmlSerializer xml = new XmlSerializer(typeof(List<İlan>));
                StreamReader sr = new StreamReader(dosya);
                İlanlar.ilanlar = (List<İlan>)xml.Deserialize(sr);

                sr.Close();
                sr.Dispose();

                ListeyiGüncelle();
            }
        }

        private void csvkaydet(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosya = saveFileDialog1.FileName;

                StreamWriter sw = new StreamWriter(dosya);
                CsvHelper.CsvWriter csv = new CsvHelper.CsvWriter(sw, System.Globalization.CultureInfo.CurrentCulture);
                csv.WriteRecords(İlanlar.ilanlar);

                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }

        private void csvac(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosya = openFileDialog1.FileName;

                StreamReader sr = new StreamReader(dosya);
                CsvHelper.CsvReader csv = new CsvHelper.CsvReader(sr, System.Globalization.CultureInfo.CurrentCulture);
                İlanlar.ilanlar = csv.GetRecords<İlan>().ToList();

                sr.Close();
                sr.Dispose();

                ListeyiGüncelle();

            }
        }

       

        private void hakkındaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("OTO İLAN SOFT V1.0 HER HAKKI SAKLIDIR copyright.");
        }

        private void yardim(object sender, EventArgs e)
        {
            MessageBox.Show("yardım");
        }
    }
}
