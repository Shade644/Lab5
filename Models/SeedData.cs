using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Lab5.Models;

namespace Lab5.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TodoContext>>()))
            {
                // Look for any movies.
                if (context.TodoItems.Any())
                {
                    return;   // DB has been seeded
                }

                context.TodoItems.AddRange(
                    new TodoItem
                    {
                        Name = "Adam",
                        Surname = "Kowalski",
                        Date_of_birth = DateTime.Parse("1995-5-10"),
                        Place_of_birth = "Bochnia"
                    },

                     new TodoItem
                     {
                         Name = "Adrian",
                         Surname = "Nowak",
                         Date_of_birth = DateTime.Parse("2000-8-9"),
                         Place_of_birth = "Kraków"
                     },

                    new TodoItem
                    {
                        Name = "Julia",
                        Surname = "Nowakowska",
                        Date_of_birth = DateTime.Parse("1989-2-12"),
                        Place_of_birth = "Gdańsk"
                    },

                    new TodoItem
                    {
                        Name = "Marcin",
                        Surname = "Marcinowski",
                        Date_of_birth = DateTime.Parse("1990-7-3"),
                        Place_of_birth = "Warszawa"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}