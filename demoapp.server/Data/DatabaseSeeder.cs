using Microsoft.EntityFrameworkCore;

namespace DemoApp.Server.Data;

public class DatabaseSeeder
{
    /// <summary>
    /// Seeds the database with initial data if it is empty.
    /// </summary>
    /// <param name="serviceProvider">The service provider used to get the database context.</param>
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        // Create a new instance of AppDbContext using the service provider
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        // Check if the Users table is empty
        if (!context.Users.Any())
        {
            // Seed the Users table with initial data
            context.Users.AddRange(
                new() { FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", IsActive = true },
                new() { FirstName = "Jane", LastName = "Smith", Email = "jane.smith@yahoo.com", IsActive = true },
                new() { FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@outlook.com", IsActive = true },
                new() { FirstName = "Bob", LastName = "Brown", Email = "bob.brown@icloud.com", IsActive = false },
                new() { FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@aol.com", IsActive = true },
                new() { FirstName = "David", LastName = "Wilson", Email = "david.wilson@live.com", IsActive = false },
                new() { FirstName = "Emily", LastName = "Taylor", Email = "emily.taylor@protonmail.com", IsActive = true },
                new() { FirstName = "Frank", LastName = "Miller", Email = "frank.miller@zoho.com", IsActive = true },
                new() { FirstName = "Grace", LastName = "Anderson", Email = "grace.anderson@me.com", IsActive = true },
                new() { FirstName = "Hannah", LastName = "Thomas", Email = "hannah.thomas@mail.com", IsActive = false },
                new() { FirstName = "Isaac", LastName = "Jackson", Email = "isaac.jackson@fastmail.com", IsActive = true },
                new() { FirstName = "Julia", LastName = "White", Email = "julia.white@tutanota.com", IsActive = true },
                new() { FirstName = "Kevin", LastName = "Harris", Email = "kevin.harris@ymail.com", IsActive = false },
                new() { FirstName = "Laura", LastName = "Martin", Email = "laura.martin@inbox.com", IsActive = true },
                new() { FirstName = "Mike", LastName = "Thompson", Email = "mike.thompson@mailinator.com", IsActive = false }
            );

            // Save changes to the database
            await context.SaveChangesAsync();
        }

        // Check if the Orders table is empty
        if (!context.Orders.Any())
        {
            // Seed the Orders table with initial data
            context.Orders.AddRange(
                new() { Amount = 49.99m, Date = DateTime.UtcNow.AddDays(-30), Status = "Pending", UserId = 1 },
                new() { Amount = 89.99m, Date = DateTime.UtcNow.AddDays(-28), Status = "Shipped", UserId = 2 },
                new() { Amount = 19.99m, Date = DateTime.UtcNow.AddDays(-25), Status = "Delivered", UserId = 3 },
                new() { Amount = 299.99m, Date = DateTime.UtcNow.AddDays(-20), Status = "Pending", UserId = 4 },
                new() { Amount = 159.99m, Date = DateTime.UtcNow.AddDays(-15), Status = "Shipped", UserId = 5 },
                new() { Amount = 79.99m, Date = DateTime.UtcNow.AddDays(-10), Status = "Delivered", UserId = 6 },
                new() { Amount = 129.99m, Date = DateTime.UtcNow.AddDays(-8), Status = "Pending", UserId = 7 },
                new() { Amount = 199.99m, Date = DateTime.UtcNow.AddDays(-7), Status = "Shipped", UserId = 8 },
                new() { Amount = 39.99m, Date = DateTime.UtcNow.AddDays(-5), Status = "Delivered", UserId = 9 },
                new() { Amount = 219.99m, Date = DateTime.UtcNow.AddDays(-4), Status = "Pending", UserId = 10 },
                new() { Amount = 89.99m, Date = DateTime.UtcNow.AddDays(-3), Status = "Shipped", UserId = 11 },
                new() { Amount = 49.99m, Date = DateTime.UtcNow.AddDays(-2), Status = "Delivered", UserId = 12 },
                new() { Amount = 109.99m, Date = DateTime.UtcNow.AddDays(-1), Status = "Pending", UserId = 13 },
                new() { Amount = 299.99m, Date = DateTime.UtcNow, Status = "Shipped", UserId = 14 },
                new() { Amount = 159.99m, Date = DateTime.UtcNow, Status = "Delivered", UserId = 15 },
                new() { Amount = 69.99m, Date = DateTime.UtcNow.AddDays(-14), Status = "Shipped", UserId = 1 },
                new() { Amount = 89.99m, Date = DateTime.UtcNow.AddDays(-13), Status = "Delivered", UserId = 2 },
                new() { Amount = 229.99m, Date = DateTime.UtcNow.AddDays(-12), Status = "Delivered", UserId = 3 },
                new() { Amount = 139.99m, Date = DateTime.UtcNow.AddDays(-11), Status = "Pending", UserId = 4 },
                new() { Amount = 249.99m, Date = DateTime.UtcNow.AddDays(-10), Status = "Pending", UserId = 5 },
                new() { Amount = 79.99m, Date = DateTime.UtcNow.AddDays(-9), Status = "Delivered", UserId = 6 },
                new() { Amount = 159.99m, Date = DateTime.UtcNow.AddDays(-8), Status = "Delivered", UserId = 7 },
                new() { Amount = 199.99m, Date = DateTime.UtcNow.AddDays(-7), Status = "Shipped", UserId = 8 },
                new() { Amount = 129.99m, Date = DateTime.UtcNow.AddDays(-6), Status = "Shipped", UserId = 9 },
                new() { Amount = 89.99m, Date = DateTime.UtcNow.AddDays(-5), Status = "Shipped", UserId = 10 },
                new() { Amount = 239.99m, Date = DateTime.UtcNow.AddDays(-4), Status = "Pending", UserId = 11 },
                new() { Amount = 169.99m, Date = DateTime.UtcNow.AddDays(-3), Status = "Pending", UserId = 12 },
                new() { Amount = 299.99m, Date = DateTime.UtcNow.AddDays(-2), Status = "Pending", UserId = 13 },
                new() { Amount = 89.99m, Date = DateTime.UtcNow.AddDays(-1), Status = "Delivered", UserId = 14 },
                new() { Amount = 119.99m, Date = DateTime.UtcNow, Status = "Delivered", UserId = 15 }
            );

            // Save changes to the database
            await context.SaveChangesAsync();
        }
    }
}
