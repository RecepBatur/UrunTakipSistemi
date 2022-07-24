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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            var kategoriler = db.TBLCATEGORY.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TBLCATEGORY t = new TBLCATEGORY();
            t.CategoryAd = textBox2.Text;
            db.TBLCATEGORY.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi");
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktg = db.TBLCATEGORY.Find(x);
            db.TBLCATEGORY.Remove(ktg);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ktg = db.TBLCATEGORY.Find(x);
            ktg.CategoryAd = textBox2.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Başarılı Şekilde Gerçekleşmiştir.");

        }
    }
}
