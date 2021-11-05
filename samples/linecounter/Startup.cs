using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LineCounter
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
            services.AddMvc();

            services.AddAzureClients(
                builder => {
                    builder.ConfigureDefaults(Configuration.GetSection("Defaults"));

                    builder.AddBlobServiceClient(Configuration.GetSection("Blob"));
                    builder.AddEventHubProducerClient(Configuration.GetSection("Uploads")).WithName("Uploads");

                    builder.AddEventHubProducerClient(Configuration.GetSection("Results")).WithName("Results");
                    builder.AddEventGridPublisherClient(Configuration.GetSection("Notification"));
                });
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
