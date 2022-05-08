using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OtoİlanSoft
{
    [Serializable]
    public class İlan
    {
        public Guid İlanID { get; set; }
        public string Marka { get; set; }
        public string Seri { get; set; }
        public string Model { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public string Ilan_bas { get; set; }
        public decimal Yil { get; set; }
        public decimal KM { get; set; }
        public string Renk { get; set; }
        public decimal Fiyat { get; set; }
        public string ililce { get; set; }
        public DateTime Ilan_tarih { get; set; }
        public string Bilgi { get; set; }
        public string Resim { get; set; }

        [XmlIgnore]
        [JsonIgnore]

        public string Detay
        {
            get
            {
                return
                    $"ID        :{İlanID}\r\n" +
                    $"Marka        :{Marka}\r\n" +
                    $"Seri  :{Seri}\r\n" +
                    $"Model :{Model}\r\n" +
                    $"İlan başlığı   :{Ilan_bas}\r\n" +
                    $"Yıl      :{Yil}\r\n" +
                    $"Km     :{KM}\r\n" +
                    $"*****************************\r\n" +
                    $"*****************************\r\n" +
                    $"Renk     :{Renk}\r\n" +
                    $"Fiyat :{Fiyat}\r\n" +
                    $"il/ilçe      :{ililce}\r\n" +
                    $"İlan tarihi    :{Ilan_tarih}\r\n" +
                    $"*****************************\r\n" +
                    $"*****************************\r\n" +
                    $"Bigi      :{Bilgi}";
            }
        }
    }
    [Serializable]
    public static class İlanlar
    {
        public static List<İlan> ilanlar = new List<İlan>();
    }
}
