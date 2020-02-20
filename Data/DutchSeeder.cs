using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    public class DutchSeeder
    {
        private readonly DutchContext context;
        private readonly IWebHostEnvironment hosting;
        private readonly UserManager<StoreUser> userManager;

        public DutchSeeder(DutchContext context, IWebHostEnvironment hosting, UserManager<StoreUser> userManager)
        {
            this.context = context;
            this.hosting = hosting;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            context.Database.EnsureCreated();

            StoreUser user = await userManager.FindByEmailAsync("fakeeamonkeane@gmail.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Eamon",
                    LastName = "Eamon",
                    Email = "fakeeamonkeane@gmail.com",
                    UserName = "fakeeamonkeane@gmail.com"
                };

                var result = await userManager.CreateAsync(user, "P@ssw0rd");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in seeder");
                }
            }

            if (!context.Products.Any())
            {
                //Need to create sample data
                var filePath = Path.Combine(hosting.ContentRootPath, "Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                context.Products.AddRange(products);

                var order = context.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if (order != null)
                {

                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    };
                }
                context.SaveChanges();
            }
        }
    }
}
