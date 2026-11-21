using Microsoft.AspNetCore.Builder;
using ServiceLog.Services.RequestLog;
using ServiceLog.Services.ShoppingCart;

namespace ServiceLog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            #region Services Register
            builder.Services.AddSingleton<IRequestLogService, RequestLogService>();
            builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
            #endregion

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                var requestLog = context.RequestServices.GetRequiredService<IRequestLogService>();
                requestLog.Log(context.Request.Method, context.Request.Path + context.Request.QueryString);

                await next(context);
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=RequestLog}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
