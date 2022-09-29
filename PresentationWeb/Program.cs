using AutoMapper;
using DataAcces;
using Microsoft.AspNetCore.Authentication.Cookies;
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

            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession();


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/SignIn";
                    opt.Cookie.HttpOnly = true;
                    opt.Cookie.Name = "AuthCookie";
                    opt.Cookie.MaxAge = TimeSpan.FromSeconds(100);

                    //opt.Events = new CookieAuthenticationEvents
                    //{
                    //    OnRedirectToLogin = x =>
                    //    {
                    //        x.HttpContext.Response.StatusCode = 401;
                    //        return Task.CompletedTask;
                    //    }
                    //};

                });




            builder.Services.AddDbContext<AppDbContext>
                (x => x.UseNpgsql(builder.Configuration.GetConnectionString("DefoultConnection")));

            builder.Services.AddScoped<IUserServices, UserServices>();
            builder.Services.AddScoped<IRoleServices, RoleServices>();
            builder.Services.AddScoped<IUserRoleServices, UserRoleServices>();
            builder.Services.AddScoped<ICartServices, CartServices>();


            builder.Services.AddScoped<IProductServices, ProductServices>();



            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());

            });
            builder.Services.AddSingleton(mappingConfig.CreateMapper());


            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home2/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }








            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
     name: "default",
     pattern: "{controller=Login}/{action=SignIn}");

            app.Run();

        }
    }
}