using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Assignments.Any()) return;

            var assignment = new List<Assignment>
            {
                new Assignment{
                    Title = "Create login page",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Create with react.js the login page"
                },
                new Assignment{
                    Title = "Create register page",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Create with react.js the register page"
                },
                new Assignment{
                    Title = "Create admin page",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Create with react.js the admin page"
                },
                new Assignment{
                    Title = "Create product page",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Create with react.js the product page"
                },
            };
            await context.Assignments.AddRangeAsync(assignment);
            await context.SaveChangesAsync();
        }
    }
}