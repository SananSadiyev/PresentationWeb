using AutoMapper;
using DataAcces;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Abstract;
using Services.Config;

namespace PresentationWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefoultConnection")));

            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IRoleServices, RoleServices>();
            builder.Services.AddScoped<IUserRoleServices, UserRoleServices>();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());

            });
            builder.Services.AddSingleton(mappingConfig.CreateMapper());


            var app = builder.Build();


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