using Microsoft.EntityFrameworkCore;
using VillaMVC.Contexts;
using VillaMVC.Services;

namespace VillaMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connecStr = builder.Configuration.GetConnectionString("PC");


            builder.Services.AddDbContext<AppDbContext>(opt =>opt.UseSqlServer(connecStr));
            builder.Services.AddScoped<VillaService>();

            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
                
                
                name:"Default",
                pattern:"{controller=Home}/{action=Index}"
                
                );

          

            app.Run();
        }
    }
}
