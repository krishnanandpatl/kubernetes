using platformservice.Models;

namespace platformservice.Data
{
    public static class PrebDB
    {
        public static void PrepPolulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext appDbContext)
        {
            if (!appDbContext.Platforms.Any())
            {
                Console.WriteLine("----------->>> starting Seeding");
                appDbContext.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );

                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("----------->>> Platform has data.");
            }
        }
    }
}