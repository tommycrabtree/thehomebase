using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

// app.UseAuthentication(); goes here
// app.UseAuthorization(); goes here

// gets the index.html from the wwwroot folder
app.UseDefaultFiles();

// looks for a wwwroot folder and serves the content from inside it
app.UseStaticFiles();

app.MapControllers();

// app.MapHub<PresenceHub>("hubs/presence"); goes here
// app.MapHub<MessageHub>("hubs/message"); goes here

app.MapFallbackToController("Index", "Fallback");

app.Run();
