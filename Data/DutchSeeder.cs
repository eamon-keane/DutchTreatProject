using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
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

        public DutchSeeder(DutchContext context, IWebHostEnvironment hosting)
        {
            this.context = context;
            this.hosting = hosting;
        }

        public void Seed()
        {
            context.Database.EnsureCreated();
            if (!context.Products.Any())
            {
                //Need to create sample data
                var filePath = Path.Combine(hosting.ContentRootPath ,"Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                context.Products.AddRange(products);

                var order = context.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null)
                {
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
