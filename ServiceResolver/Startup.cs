using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceResolver.Dialogs;
using ServiceResolver.Extensions;
using ServiceResolver.Services;
using ServiceResolver.Utilities;

namespace ServiceResolver
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton<IDialogDataService, DialogDataService>();

            services.AddSingletonFactory<PrintDialogBase, PrintDialog>();

            // You can still register scoped and transient services here,
            // but can't use them in a static context via StaticContext.GenericServiceProvider.
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This is an anti-pattern and it's limited to singleton scope usage only. 
            StaticContext.GenericServiceProvider = new CoreServiceProvider(app.ApplicationServices);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
