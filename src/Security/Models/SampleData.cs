using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Security.Models
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
            context.Database.Migrate();

            // Ensure Stephen
            var user = await userManager.FindByNameAsync("Stephen.Walther@CoderCamps.com");
            if (user == null)
            {
                // create user
                user = new ApplicationUser
                {
                    UserName = "Stephen.Walther@CoderCamps.com",
                    Email = "Stephen.Walther@CoderCamps.com"
                };
                await userManager.CreateAsync(user, "Secret123!");

                // add claims
                await userManager.AddClaimAsync(user, new Claim("CanEditProducts", "true"));
                await userManager.AddClaimAsync(user, new Claim(ClaimTypes.DateOfBirth, "12/25/1966"));
            }
            
        }

    }
}
