using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins());

app.UseAuthentication();
app.UseAuthorization();

// gets the index.html from the wwwroot folder
app.UseDefaultFiles();

// looks for a wwwroot folder and serves the content from inside it
app.UseStaticFiles();

app.MapControllers();

// app.MapHub<PresenceHub>("hubs/presence"); goes here
// app.MapHub<MessageHub>("hubs/message"); goes here

app.MapFallbackToController("Index", "Fallback");

app.Run();
