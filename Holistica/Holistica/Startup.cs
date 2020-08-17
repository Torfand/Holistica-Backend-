using Holistica.Core._1_Application_Services;
using Holistica.Core._2_Domain_Services;
using Holistica.Infrastructure.DataAcsess;
using Holistica.Infrastructure.DataAcsess.DataAcsess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Holistica.Infrastructure.Api
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
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<INewsletterSubscriptionRepository, NewsletterSubscriptionRepository>();
            services.AddScoped<IHappeningRegistrationRepository, HappeningRegistrationRepository>();
            
            services.AddScoped<NewsletterSubscriptionService>();
            services.AddScoped<HappeningRegistrationService>();
            services.AddControllers();
            services.AddSwaggerDocument();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
