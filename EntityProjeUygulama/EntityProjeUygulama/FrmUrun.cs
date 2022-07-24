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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();

        private void BtnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (from x in db.TBLPRODUCTS
                                        select new
                                        {
                                            x.UrunId,
                                            x.UrunAd,
                                            x.Marka,
                                            x.Stok,
                                            x.Fiyat,
                                            x.TBLCATEGORY.CategoryAd,
                                            x.Durum,
                                        
                                        }).ToList();


        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TBLPRODUCTS t = new TBLPRODUCTS();
            t.UrunAd = TxtUrunAd.Text;
            t.Marka = TxtUrunMarka.Text;
            t.Stok = short.Parse(TxtUrunStok.Text);
            t.Kategori = int.Parse(CmbKategori.SelectedValue.ToString());
            t.Fiyat = decimal.Parse(TxtUrunFiyat.Text);
            t.Durum = true;
            db.TBLPRODUCTS.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Sisteme Kayıt Edildi.");

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtUrunId.Text);
            var urun = db.TBLPRODUCTS.Find(x);
            db.TBLPRODUCTS.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi.");
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtUrunId.Text);
            var urun = db.TBLPRODUCTS.Find(x);
            urun.UrunAd = TxtUrunAd.Text;
            urun.Stok = short.Parse(TxtUrunStok.Text);
            urun.Marka = TxtUrunMarka.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi.");
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            //combobox'a form açılırken kategori isimlerini liste halinde çektik.
            var kategoriler = (from x in db.TBLCATEGORY
                               select new
                               { 
                                   x.Id,
                                   x.CategoryAd
                               }
                               ).ToList();
            CmbKategori.ValueMember = "Id";
            CmbKategori.DisplayMember = "CategoryAd";
            CmbKategori.DataSource = kategoriler;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            
        }
    }
}
