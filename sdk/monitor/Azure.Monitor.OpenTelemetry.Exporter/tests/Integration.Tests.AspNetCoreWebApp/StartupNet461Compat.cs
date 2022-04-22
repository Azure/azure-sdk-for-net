// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
#if NET461
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.AspNetCoreWebApp
{
    public partial class Startup
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
#endif
