// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Instrumentation.AspNetCore;

namespace Azure.Monitor.OpenTelemetry.Demo
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
            services.Configure<AspNetCoreInstrumentationOptions>(o =>
            {
                o.EnrichWithHttpRequest = (activity, httpRequest) =>
                {
                    activity.SetTag("requestProtocol", httpRequest.Protocol);
                };
                o.EnrichWithHttpResponse = (activity, httpResponse) =>
                {
                    activity.SetTag("responseLength", httpResponse.ContentLength);
                };
                o.EnrichWithException = (activity, exception) =>
                {
                    activity.SetTag("exceptionType", exception.GetType().ToString());
                };
            });

            // services.AddAzureMonitorOpenTelemetry();

            // services.AddAzureMonitorOpenTelemetry(enableTraces: true, enableMetrics: true);

            // services.AddAzureMonitorOpenTelemetry(Configuration.GetSection("AzureMonitorOpenTelemetry"));

            services.AddAzureMonitorOpenTelemetry(o =>
            {
                o.ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
            });
        }

#if NET461
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
#else
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
#endif
        {
            app.MapWhen(context => context.Request.Path.StartsWithSegments("/"), (appBuilder) =>
            {
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"Hello World! OpenTelemetry Trace: {Activity.Current?.Id}");
                });
            });
        }
    }
}
