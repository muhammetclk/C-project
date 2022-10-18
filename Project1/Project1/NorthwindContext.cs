using Project1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    //entity framework kutuphanesini NuGEt Packages ile indirdik.
    //veritabanıyla nesneleri birbirine bağladık.
    public class NorthwindContext : DbContext//context olabilmesi icin DbContext 'den inherit edilmesi gerekir.
    {
        //hangi nesnemiz veritabaninda neye baglayicagimizi belirtmek icin veritabanindaki tablomuza karsilik gelen bir nesneye ihtiyac var.
        //benim elimde bir Product var ve bu veritabaninda Products'a karsilik gelir.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
