using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MixerDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MixerREST
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                       name: "RevMixerPolicy",
                       builder =>
                   {
                       // when you build your frontend, set this as the angular website origin domain,
                       // you might also need to allow the third party api you're using to access your stuff
                       builder.WithOrigins("*")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                   }
                   );
                }
                );


            //configuring amazon s3 support for project
            var options = Configuration.GetAWSOptions();
            IAmazonS3 client = options.CreateServiceClient<IAmazonS3>();

            services.AddDbContext<MixerDBContext>(
                    options =>
                    options.UseNpgsql(Configuration.GetConnectionString("StoreDB")
                    ),
                    ServiceLifetime.Scoped
                    );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MixerREST", Version = "v1" });
            });

            //add aws services to our system - now our controllers can access these services as needed
            services.AddAWSService<IAmazonS3>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MixerREST v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("RevMixerPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
