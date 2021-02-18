using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            StoreDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Books.Any())
            {
                context.AddRange(
                    new Book
                    {
                        ISBN = "978-0451419439",
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorMidName = "",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = 9.95
                    },
                    new Book
                    {
                        ISBN = "978-0743270755",
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMidName = "Kearns",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 14.58
                    },
                    new Book
                    {
                        ISBN = "978-0553384611",
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorMidName = "",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 21.54
                    },
                    new Book
                    {
                        ISBN = "978-0812981254",
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorMidName = "C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = 11.64
                    },
                    new Book
                    {
                        ISBN = "978-0812974492",
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorMidName = "",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = 13.33
                    },
                    new Book
                    {
                        ISBN = "978-0804171281",
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorMidName = "",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = 15.95
                    },
                    new Book
                    {
                        ISBN = "978-1455586691",
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorMidName = "",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 14.99
                    },
                    new Book
                    {
                        ISBN = "978-1455523023",
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorMidName = "",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = 21.66
                    },
                    new Book
                    {
                        ISBN = "978-1591847984",
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorMidName = "",
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 29.16
                    },
                    new Book
                    {
                        ISBN = "978-0553393613",
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorMidName = "",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
