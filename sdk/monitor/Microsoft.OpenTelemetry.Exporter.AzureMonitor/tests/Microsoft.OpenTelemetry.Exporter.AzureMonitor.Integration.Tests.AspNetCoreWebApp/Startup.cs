// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.AspNetCoreWebApp
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
            services.AddMvc(options =>
            {
#if NET5_0
                options.EnableEndpointRouting = false;
#endif
#pragma warning disable 618
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
#pragma warning restore 618
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#pragma warning disable 618
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
#pragma warning restore 618
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
