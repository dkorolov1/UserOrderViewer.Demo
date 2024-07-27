using DemoApp.Server.Data;
using DemoApp.Server.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Add services to the container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use CORS
app.UseCors("AllowSpecificOrigin");

// Apply migrations and seed data
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate(); // Applies any pending migrations

    // Seed the database with sample data
    await DatabaseSeeder.SeedAsync(scope.ServiceProvider);
}

// Use Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/users", async (AppDbContext db) =>
{
    var users = await db.Users.ToListAsync();
    return users.Count > 0 
        ? Results.Ok(users)
        : Results.NotFound();
})
.WithName("GetAllUsers")
.WithSummary("Fetch all users from the database.")
.WithDescription("Retrieves a list of all users stored in the database. If no users are found, a 404 Not Found response is returned.")
.Produces<IEnumerable<User>>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.MapGet("/api/users/{userId}/orders", async (AppDbContext db, int userId) =>
{
    var orders = await db.Orders
        .Where(o => o.UserId == userId)
        .ToListAsync();
    return orders.Count > 0 
        ? Results.Ok(orders) 
        : Results.NotFound(); // Updated to handle the case when no orders are found
})
.WithName("GetOrdersByUserId")
.WithSummary("Fetch all orders placed by a specific user.")
.WithDescription("Retrieves all orders associated with a specified user ID. If no orders are found for the given user ID, a 404 Not Found response is returned.")
.Produces<IEnumerable<Order>>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

app.Run();
