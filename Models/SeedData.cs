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
                        NumPages = 1488,
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
                        NumPages = 944,
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
                        NumPages = 832,
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
                        NumPages = 864,
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
                        NumPages = 528,
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
                        NumPages = 288,
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
                        NumPages = 304,
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
                        NumPages = 240,
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
                        NumPages = 400,
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
                        NumPages = 642,
                        Publisher = "Bantam",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = 15.03
                    },
                    // My Additions
                    new Book
                    {
                        ISBN = "978-1633697201",
                        Title = "The Innovators DNA",
                        AuthorFirstName = "Clayton",
                        AuthorMidName = "M.",
                        AuthorLastName = "Christensen",
                        NumPages = 230,
                        Publisher = "Harvard Business Review Press",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = 21.49
                    },
                    new Book
                    {
                        ISBN = "978-0060694425",
                        Title = "The Spirit of the Disciplines: Understanding How God Changes Lives",
                        AuthorFirstName = "Dallas",
                        AuthorMidName = "",
                        AuthorLastName = "Willard",
                        NumPages = 288,
                        Publisher = "HarperOne",
                        Classification = "Non-Fiction",
                        Category = "Theology",
                        Price = 11.49
                    },
                    new Book
                    {
                        ISBN = "978-1590523742",
                        Title = "The Mystery of Marriage",
                        AuthorFirstName = "Mike",
                        AuthorMidName = "",
                        AuthorLastName = "Mason",
                        NumPages = 224,
                        Publisher = "Multnomah",
                        Classification = "Non-Fiction",
                        Category = "Theology",
                        Price = 17.00
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
