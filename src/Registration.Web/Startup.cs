using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Registration.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Registration.Web.Modules;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Registration.Domain.SeedWork;
using Microsoft.AspNetCore.Http;
using Registration.Web.Exceptions;
using Registration.Web.Middlewares;
using System.Linq;

namespace Registration.Web
{
    public class Startup
    {
        private const string RegistrationDBConnectionString = "RegDb";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<CustomerContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString(RegistrationDBConnectionString)));
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            services.AddProblemDetails(options =>
            {
                options.IncludeExceptionDetails = f => false;

                options.Map<NotImplementedException>(ex => new ExceptionProblemDetails(ex, StatusCodes.Status501NotImplemented));
                options.Map<BusinessRuleValidationException>(ex => new BusinessRuleValidationExceptionProblemDetails(ex) { });
                options.Map<ValidationException>(ex => new RequestValidationExceptionProblemDetails(ex));
                options.Map<Exception>(ex => new ExceptionProblemDetails(ex, StatusCodes.Status500InternalServerError));
            });

            return CreateAutofacServiceProvider(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using (var dataContext = serviceProvider.GetService<CustomerContext>())
                {
                    if (dataContext.Database.GetPendingMigrations().Count() > 0)
                    {
                        dataContext.Database.Migrate();
                    }
                }
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseProblemDetails();
            app.UseMiddleware<ErrorLoggingMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");

                }
            });
        }

        private IServiceProvider CreateAutofacServiceProvider(IServiceCollection services)
        {
            var container = new ContainerBuilder();

            container.Populate(services);

            container.RegisterModule(new InfrastructureModule(Configuration.GetConnectionString(RegistrationDBConnectionString)));
            container.RegisterModule(new DomainModule());
            container.RegisterModule(new MediatorModule());

            var buildContainer = container.Build();

            return new AutofacServiceProvider(buildContainer);
        }
    }
}
