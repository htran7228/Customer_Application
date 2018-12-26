using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CustomerApplication.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CustomerApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CustomerApplicationContext>>()))
            {
                // Look for any movies.
                if (context.Customer.Any())
                {
                    return;   // DB has been seeded
                }

                context.Customer.AddRange(
                    new Customer
                    {
                        Age = 15,
                        Name = "Harris Hayes",
                        BirthDate = DateTime.Parse("1989-2-12"),
                        Gender = "Male",
                      
                    }
                );
                context.SaveChanges();
            }
        }
    }



}

