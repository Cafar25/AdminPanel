using AdminPanel.DAL;
using AdminPanel.Services;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel
{
    public static class RegisterService
    {
        public static void Register(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllersWithViews();

            services.AddDbContext<AdminPanelDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(30);
            });
            services.AddScoped<IBasket, BasketService>();
            services.AddHttpContextAccessor();
        }
    }
}
