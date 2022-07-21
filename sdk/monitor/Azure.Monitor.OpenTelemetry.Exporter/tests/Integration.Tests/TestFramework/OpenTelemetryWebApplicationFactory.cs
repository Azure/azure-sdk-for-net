// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;

using Azure.Monitor.OpenTelemetry.Exporter.Models;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

using OpenTelemetry;
using OpenTelemetry.Trace;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework
{
    /// <summary>
    /// This class implements <see cref="WebApplicationFactory"/> and will configure the <see cref="IServiceCollection"/> for OpenTelemetry and the <see cref="AzureMonitorTraceExporter"/>.
    /// Here we mock the <see cref="ServiceRestClient"/> to capture telemetry that would have been sent to the ingestion service.
    /// We also mock the <see cref="TrackResponse"/> which would have been received from the ingestion service.
    /// </summary>
    /// <typeparam name="TStartup">Startup class from the application to be used during this test.</typeparam>
    public class OpenTelemetryWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        internal ConcurrentBag<TelemetryItem> TelemetryItems => this.Transmitter.TelemetryItems;

        private const string EmptyConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
        private readonly MockTransmitter Transmitter = new MockTransmitter();
        private BaseProcessor<Activity> ActivityProcessor;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            this.ActivityProcessor = new BatchActivityExportProcessor(new AzureMonitorTraceExporter(this.Transmitter));

            builder.ConfigureServices(services => services.AddOpenTelemetryTracing((builder) => builder
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddProcessor(this.ActivityProcessor)));
        }

        /// <summary>
        /// Wait for End callback to execute because it is executed after response was returned.
        /// </summary>
        internal void WaitForActivityExport()
        {
            var result = SpinWait.SpinUntil(
                condition: () =>
                {
                    Thread.Sleep(10);
                    return this.TelemetryItems.Any();
                },
                timeout: TimeSpan.FromSeconds(10));

            Assert.True(result, $"{nameof(WaitForActivityExport)} failed.");
        }
    }
}
