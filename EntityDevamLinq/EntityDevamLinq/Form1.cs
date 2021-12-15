using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityDevamLinq
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SinavEEntities db = new SinavEEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //Hangi Şehirden Kaç Kişi Olduğunu Gösterir
            var degerler = db.OGRENCILER.OrderBy(x => x.SEHIR).GroupBy(y => y.SEHIR).
                
                //soldaki değerler tabloda yazacak sütun adları
                Select(z => new { Sehir=z.Key,Toplam =z.Count() });

            dataGridView1.DataSource = degerler.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //En yüksek not ortalamasını label1e yaz
            //label1.Text = db.NOTLAR.Max(x => x.ORTALAMA).ToString();
            //label1.Text = db.NOTLAR.Min(x => x.ORTALAMA).ToString(); //en düşük
            //label1.Text = db.NOTLAR.Where(x => x.DURUM == false).Max(y => y.ORTALAMA).ToString(); //Kalan öğrenciler içinde en yüksek not alan


            //label1.Text = db.Urun.Count().ToString();
            //label1.Text = db.Urun.Sum(x => x.STOK).ToString(); //Urunlerin toplam stok sayısı gelir. Sum içine parametre gelmelidir.
            //label1.Text = db.Urun.Sum(x => x.AD== "BUZDOLABI").ToString();
            //label1.Text = db.Urun.Average(x => x.FIYAT).ToString(); //Ortalama
            //label1.Text = db.Urun.Where(x => x.AD == "BUZDOLABI").Average(y=>y.FIYAT).ToString() ;

            //Büyükten küçüğe sırala
            /*label1.Text = (from x in db.Urun  
                           orderby x.STOK descending
                           select x.AD).First();
        */

           // dataGridView1.DataSource = db.OgrencıKulubu().ToList(); //Öğrenciler ve kulüplerini gösteren prosedür oluşturduk sqlserverda.
        
        }
    }
}
