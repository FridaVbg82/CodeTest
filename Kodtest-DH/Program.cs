using AutoMapper;
using Kodtest_DH.Models;
using Kodtest_DH.Repository;
using Kodtest_DH.Services;
using Microsoft.EntityFrameworkCore;

namespace Kodtest_DH
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetSection("ConnectionString").Value;

            builder.Services.AddDbContext<CodetestDbContext>(
                (_, options) =>
                {
                    options.UseSqlServer(connectionString);
                });
            
            // Add services to the container.
            builder.Services.AddTransient<IPersonService, PersonService>();
            builder.Services.AddAutoMapper(typeof(MapperProfile),typeof(MapperProfileReverse));
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<CodetestDbContext>();
                dbContext.Database.EnsureCreated();

            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}