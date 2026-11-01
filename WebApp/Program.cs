namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // // // // // // // // // // // // //
            // INICIALIZACION del uso de SESSION
            // // // // // // // // // // // // //
            builder.Services.AddSession();

            // // // // // // // // // // // // //
            // Add services to the container. > de .NET
            // // // // // // // // // // // // //
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // // // // // // // // // // // // //
            // Configure the HTTP request pipeline. > de .NET
            // // // // // // // // // // // // //
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days.
                app.UseHsts();
            }

            // > de .NET
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.MapStaticAssets();

            // // // // // // // // // // // // //
            // UTILIZACION de la creada SESSION
            // // // // // // // // // // // // //
            app.UseSession();

            // > de .NET
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
