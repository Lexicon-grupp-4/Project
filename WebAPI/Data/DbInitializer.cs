using System.Collections.Generic;
using System.Linq;
using API.Entities;

namespace API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                   Name = "Hammare", Price = 12200, Quantity = 20 ,PictureUrl = "/images/products/hammer.jpg",Description="description1",Brand="brand",Type="type1"
                },
                new Product
                {
                   Name = "Verktygsats", Price = 210, Quantity = 6,PictureUrl = "/images/products/verktyg.jpg" ,Description="description2",Brand="brand",Type="type2"
                },
                new Product
                {
                    Name = "Borrmaskin", Price = 2000, Quantity = 3 ,PictureUrl = "/images/products/borr.jpg",Description="description3",Brand="brand",Type="type3"
                },
                new Product
                {
                   Name = "Såg", Price = 300, Quantity = 120,PictureUrl = "/images/products/sag.jpg",Description="description4",Brand="brand",Type="type4"
                },
                new Product
                {
                   Name = "Skruvmejsel", Price = 250, Quantity = 300,PictureUrl = "/images/products/skruv.jpg",Description="description5",Brand="brand",Type="type5"
                }                    
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}