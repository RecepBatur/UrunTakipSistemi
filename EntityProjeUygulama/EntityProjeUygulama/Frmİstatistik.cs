using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void LblKategori_Click(object sender, EventArgs e)
        {

        }

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            //Linq sorgular ile verileri çektik.
            LblKategori.Text = db.TBLCATEGORY.Count().ToString();
            LblUrun.Text = db.TBLPRODUCTS.Count().ToString();
            LblMusteri.Text = db.TBLCUSTOMER.Count(x => x.Durum == true).ToString();
            LblPasifMusteri.Text = db.TBLCUSTOMER.Count(x => x.Durum == false).ToString();
            LblBeyazEsya.Text = db.TBLPRODUCTS.Count(x => x.Kategori == 1).ToString();
            LblStok.Text = db.TBLPRODUCTS.Sum(x => x.Stok).ToString();
            LblMaxFiyat.Text = (from x in db.TBLPRODUCTS orderby x.Fiyat descending select x.UrunAd).FirstOrDefault(); //descendig z-a göre sıralar.
            LblMinFiyat.Text = (from x in db.TBLPRODUCTS orderby x.Fiyat ascending select x.UrunAd).FirstOrDefault(); //ascendig a-z göre sıralar.
            //LblMaxFiyat.Text = db.TBLPRODUCTS.Max(x => x.Fiyat).ToString();
            //LblMinFiyat.Text = db.TBLPRODUCTS.Min(x => x.Fiyat).ToString();

            // şehri seç yani listele distinc olarak yani tekrarsız olarak getir ve saydır şehri dedik.
            LblSehir.Text = (from x in db.TBLCUSTOMER select x.Sehir).Distinct().Count().ToString();
            LblKasa.Text = db.TBLSALE.Sum(x => x.Fiyat).ToString() + "₺";
            LblMarka.Text = db.MARKAGETİR().FirstOrDefault(); // sql'de markagetir adından prosedür yazıpta getirdik.
            LblToplamBuzdolabı.Text = db.TBLPRODUCTS.Count(x => x.UrunAd == "Buzdolabı").ToString();

        }
    }
}
