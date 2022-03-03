using ApiBoutique.Entities;
using ApiBoutique.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBoutique
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
            services.AddControllers();
            services.AddSwaggerGen();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: "_CorsPolicy",
            //        builder =>
            //        {
            //            builder.WithOrigins(this.Configuration["URLClient:localhost"])
            //            .AllowAnyHeader()
            //            .AllowAnyMethod();
            //        });
            //});

            services.AddDbContextPool<DBContext>(
             options => options.UseSqlServer(Configuration.GetConnectionString("Boutique")));

            services.AddTransient<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("_CorsPolicy");


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BoutiqueApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers().RequireCors("_CorsPolicy");
                endpoints.MapControllers();
            });
        }
    }
}
