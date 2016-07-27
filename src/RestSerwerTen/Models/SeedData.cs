using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestSerwerTen.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RestSerwerTenContext(
                serviceProvider.GetRequiredService<DbContextOptions<RestSerwerTenContext>>()))
            {
                // Look for any movies.
                if (context.Uzytkownik.Any())
                {
                    return;   // DB has been seeded
                }

                context.Uzytkownik.AddRange(
                   new Uzytkownik
                   {
                      
                       imie="Patriko",
                       nazwisko="Fantastico"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
