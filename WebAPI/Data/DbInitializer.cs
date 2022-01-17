using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(StoreContext context,UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "hodhod212",
                    Email = "hodhod212@test.com"
                };
                await userManager.CreateAsync(user, "Silikon_212");
                await userManager.AddToRoleAsync(user, "Member");
                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };
                await userManager.CreateAsync(admin, "Silikon_212");
                await userManager.AddToRolesAsync(admin,new[] { "Member","Admin" });
            }
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                   Name = "Hammare", Price = 12200, Quantity = 20 ,PictureUrl = "/images/products/hammer.jpg",Description="description1",Brand="brand1",Type="type1"
                },
                new Product
                {
                   Name = "Verktygsats", Price = 210, Quantity = 6,PictureUrl = "/images/products/verktyg.jpg" ,Description="description2",Brand="brand2",Type="type2"
                },
                new Product
                {
                    Name = "Borrmaskin", Price = 2000, Quantity = 3 ,PictureUrl = "/images/products/borr.jpg",Description="description3",Brand="brand3",Type="type3"
                },
                new Product
                {
                   Name = "Såg", Price = 300, Quantity = 120,PictureUrl = "/images/products/sag.jpg",Description="description4",Brand="brand4",Type="type4"
                },
                new Product
                {
                   Name = "Skruvmejsel", Price = 250, Quantity = 300,PictureUrl = "/images/products/skruv.jpg",Description="description5",Brand="brand5",Type="type5"
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