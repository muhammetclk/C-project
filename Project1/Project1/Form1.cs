using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void ListProducts()//urunleri listeleyen metod
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                dgwProduct.DataSource = context.Products.ToList();             
            }
        }
        private void ListCategories()//catogryleri listeleyen metod
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                cbxCategory.DataSource = context.Categories.ToList();
                cbxCategory.DisplayMember = "CategoryName";//görünecek deger
                //Kullanıcı sectiginde CategoryName'i, urunleri filtrelemek icin sectiginde degeri CategoryId 'den alır.
                cbxCategory.ValueMember = "CategoryId";
            }
        }
        private void ListProductsByCategory(int categoryId )//secilen kategorideki degerleri listeleyen metod.
        {
            using (NorthwindContext context = new NorthwindContext())

            {//urunleri listele fakat secilen catogrydekileri
                dgwProduct.DataSource = context.Products.Where(p=>p.CategoryId==categoryId).ToList();
                
            }
        }
        private void ListProductsByProductName(string key)//aratilan urunleri listeleyen metod.
        {
            using (NorthwindContext context = new NorthwindContext())

            {
                dgwProduct.DataSource = context.Products.Where(p => p.ProductName.ToLower().Contains(key.ToLower())).ToList();

            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            
            ListCategories();
            ListProducts();
        }

        

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //baslangıcta metoda giderken deger olmadıgı ıcın(Daha category secmedik) patliyor.
                //Bu yuzden try catch'ın ıcıne attık ve bos hata firlatmasini sagladik.
                ListProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));//secilen deger ile metoda git.

            }
            catch 
            {
                //bir sey yapmiyor.
                
            }
            
            
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            string key = tbxSearch.Text;
            if (string.IsNullOrEmpty(key))//arama kutusu bossa tum urunleri listeler
            {
                ListProducts();
            }
            else
            {
                ListProductsByProductName(key);//arama kutusu doluysa arananları getırır.

            }
            
        }
    }
}
