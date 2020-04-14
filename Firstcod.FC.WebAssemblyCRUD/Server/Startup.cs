using Firstcod.FC.Provider;
using Firstcod.FC.WebAssemblyCRUD.Server.Connector;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;

namespace Firstcod.FC.WebAssemblyCRUD.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.AddCors(options => options.AddPolicy("CorsPolicy", builder => 
            //{
            //    builder.AllowAnyMethod().AllowAnyHeader()
            //           .WithOrigins("https://localhost:44300")
            //           .AllowCredentials();
            //}));

            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"],
                    s => s.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name));
            });

            services.AddScoped<IUnitOfWork, HttpUnitOfWork>();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBlazorDebugging();
            }

            //app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseClientSideBlazorFiles<Client.Startup>();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");

                endpoints.MapHub<HubConnector>("/_notify");
            });
        }
    }
}
