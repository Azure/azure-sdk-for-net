// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

using Moq;

using OpenTelemetry.Exporter.AzureMonitor.Models;
using OpenTelemetry.Trace;

namespace OpenTelemetry.Exporter.AzureMonitor.Integration.Tests
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
        public ActivityProcessor ActivityProcessor;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            this.ActivityProcessor = new BatchExportActivityProcessor(new AzureMonitorTraceExporter(new AzureMonitorExporterOptions
            {
                ConnectionString = AzureMonitorExporterOptions.EmptyConnectionString,
                ServiceRestClient = this.GetMockServiceRestClient(),
            }));

            builder.ConfigureServices(services =>
                services.AddOpenTelemetryTracing((builder) => builder
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddProcessor(this.ActivityProcessor)));
        }

        public void ForceFlush() => this.ActivityProcessor.ForceFlush();

        private IServiceRestClient GetMockServiceRestClient()
        {
            var mockServiceRestClient = new Mock<IServiceRestClient>();
            mockServiceRestClient
                .Setup(x => x.TrackAsync(It.IsAny<IEnumerable<TelemetryItem>>(), It.IsAny<CancellationToken>()))
                .Returns((IEnumerable<TelemetryItem> telemetryItems, CancellationToken cancellationToken) =>
                {
                    foreach (var telemetryItem in telemetryItems)
                    {
                        this.TelemetryItems.Add(telemetryItem);
                    }

                    return Task.FromResult(GetMockResponse(itemsReceived: telemetryItems.Count(), itemsAccepted: telemetryItems.Count(), errors: new List<TelemetryErrorDetails>()));
                });

            return mockServiceRestClient.Object;
        }

        private Azure.Response<TrackResponse> GetMockResponse(int itemsReceived, int itemsAccepted, List<TelemetryErrorDetails> errors)
        {
            var trackResponse = new TrackResponse(itemsReceived, itemsAccepted, errors);
            var mockAzureResponse = new Mock<Azure.Response<TrackResponse>>();
            mockAzureResponse.Setup(x => x.Value).Returns(trackResponse);
            return mockAzureResponse.Object;
        }
    }
}
