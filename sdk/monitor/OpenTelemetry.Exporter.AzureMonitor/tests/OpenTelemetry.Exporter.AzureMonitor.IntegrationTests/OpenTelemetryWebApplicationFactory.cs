// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

using OpenTelemetry.Exporter.AzureMonitor.Models;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter.AzureMonitor.IntegrationTests
{
    /// <summary>
    /// THIS IS A WORK IN PROGRESS.
    /// </summary>
    /// <remarks>
    /// https://github.com/open-telemetry/opentelemetry-dotnet/tree/master/src/OpenTelemetry.Instrumentation.AspNetCore
    /// </remarks>
    /// <typeparam name="TStartup"></typeparam>
    public class OpenTelemetryWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public ConcurrentBag<TelemetryItem> TelemetryItems = new ConcurrentBag<TelemetryItem>();
        public AzureMonitorTraceExporter AzureMonitorTraceExporter;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            AzureMonitorTraceExporter exporter = null;

            builder.ConfigureServices(services =>
            {
                services.AddOpenTelemetryTracing((builder) => builder
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddAzureMonitorTraceExporter(out exporter, options =>
                        {
                            options.ConnectionString = AzureMonitorExporterOptions.EmptyConnectionString;
                            options.OnTrackAsync = this.OnTrackAsync;
                        }));

                this.AzureMonitorTraceExporter = exporter;
            });
        }

        private Task<Azure.Response<TrackResponse>> OnTrackAsync(IEnumerable<TelemetryItem> telemetryItems, CancellationToken cancellationToken)
        {
            foreach (var telemetryItem in telemetryItems)
            {
                this.TelemetryItems.Add(telemetryItem);
            }

            /// TODO: IT WOULD BE USEFUL TO RETURN A VALID TrackResponse OBJECT HERE. THIS COULD BE USED TO STUB BEHAVIORFROM THE INGESTION SERVICE.
            /// I WAS ABLE TO CREATE A DEFAULT TrackResonse OBJECT, BUT COULDN'T DO THE SAME FOR Azure.Response. NEEDS MORE WORK.
            return null;
        }
    }
}
