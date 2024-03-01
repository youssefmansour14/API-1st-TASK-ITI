using Microsoft.EntityFrameworkCore;
using MinyaG01Demo.Entities;

namespace MinyaG01Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<CompanyContext>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=MinyaG01API;Integrated Security=True;Encrypt=False;");
            });
            builder.Services.AddCors(corsPolicy =>
            {
                corsPolicy.AddPolicy("MyPolicy", corsOptions =>
                {
                    corsOptions.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                   // corsOptions.WithHeaders("token",).WithOrigins().WithMethods();
                });
                //corsPolicy.AddPolicy("MyPolicyV02", corsOptions =>
                //{

                //});
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("MyPolicy");//Customize Policy 
            app.UseStaticFiles();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}