using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.AspNetCore;
using PremiumCalculator.WebAPI.DependencyInjection;

namespace PremiumCalculator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "AllowOrigin";
        public IConfiguration Configuration { get; }
        
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyHeader();
                    });
            });

            services.AddControllers();

            
            return DependencyConfig.Configure(services, Configuration);
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("Index.html");

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger(typeof(Startup).Assembly, new SwaggerSettings()
            {
                FlattenInheritanceHierarchy = true,
                PostProcess = document =>
                {
                    document.Schemes.Add(SwaggerSchema.Http);
                    document.Schemes.Add(SwaggerSchema.Https);
                }
            });
            app.UseSwaggerUi3(new SwaggerUi3Settings());
        }
    }
}
