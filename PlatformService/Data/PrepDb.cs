using PlatformService.Models;

namespace PlatformService.Data;
using Microsoft.AspNetCore.Builder;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            
        }
    }

    private static void SpeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
         Console.WriteLine("---> Seeding Data");
         context.Platforms.AddRange(
             new Platform() { Name = "Dot Net",Publisher = "Microsoft",Cost = "Free" },
             new Platform() {Name="Sql Server Express",Publisher="Microsoft",Cost = "Free"},
             new Platform() {Name="Kubernates",Publisher = "Cloud Native Computing Foundation",Cost = "Free"}
                 
                 );
         context.SaveChanges();
        }
        else
        {
            Console.WriteLine("--> We already have data");
        }
    }
}