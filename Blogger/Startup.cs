using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Blogger.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Blogger.repository;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.FileProviders;

namespace Blogger
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            var connection = @"Server=(localdb)\mssqllocaldb;Database=Blogger;Trusted_Connection=True;";
            services.AddDbContext<BloggingContext>(options => options.UseSqlServer(connection));
            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<IAuthorRepository, AuthorRespository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddDirectoryBrowser();

            // Enable Cors
            services.AddCors();

            // Add MVC services to the services container.
            services.AddMvc()
              .AddJsonOptions(options =>
              {
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

              });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,BloggingContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
            app.UseExceptionHandler(
            builder =>
            {
                builder.Run(
                  async con =>
                  {
                      con.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                      con.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                      var error = con.Features.Get<IExceptionHandlerFeature>();
                      if (error != null)
                      {
                          await con.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                      }
                  });
            });
            // Enable directory browsing
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "images")),
                RequestPath = new PathString("/MyImages")
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "images")),
                RequestPath = new PathString("/MyImages")
            });
            app.UseMvc();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            DbInitializer.Initialize(context);
        }
    }
}
