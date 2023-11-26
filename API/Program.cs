using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => 
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();
/*     options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                    .AllowAnyMethod()
                    //.AllowCredentials()
                    .SetIsOriginAllowed((host) => true)
                    .WithOrigins("http://localhost:4200/")
                    .AllowAnyHeader());
        }); */

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseCors(corsPolicyBuilder => corsPolicyBuilder.WithOrigins("https://localhost:4200").AllowAnyHeader().AllowAnyMethod() ); //"CorsPolicy");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
