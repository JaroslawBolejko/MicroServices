namespace MicroServicesWebApi.DataAccess;
//helper class for testing. It deliver some date to the memory when the app is started.
public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }
    private static void SeedData(AppDbContext context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("-->Seeding data...");

            context.Platforms.AddRange(
                new Platform()
                {
                    Name = ".Net",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new Platform()
                {
                    Name = "SQL Server Express",
                    Publisher = "Microsoft",
                    Cost = "Free"
                },
                new Platform()
                {
                    Name = "Kubernetes",
                    Publisher = "Cloud Native Computing Foundation",
                    Cost = "Free"
                },
                 new Platform()
                {
                    Name = "Azure",
                    Publisher = "Microsoft",
                    Cost = "pay-per-use"
                }

            );
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("-->We already have data");
        }
    }
}
