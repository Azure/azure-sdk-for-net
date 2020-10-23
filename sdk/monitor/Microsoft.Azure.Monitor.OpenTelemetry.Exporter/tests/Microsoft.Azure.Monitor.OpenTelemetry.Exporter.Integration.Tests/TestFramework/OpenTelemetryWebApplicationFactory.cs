﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Concurrent;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Models;
using OpenTelemetry.Trace;

namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework
{
    /// <summary>
    /// This class implements <see cref="WebApplicationFactory"/> and will configure the <see cref="IServiceCollection"/> for OpenTelemetry and the <see cref="AzureMonitorTraceExporter"/>.
    /// Here we mock the <see cref="ServiceRestClient"/> to capture telemetry that would have been sent to the ingestion service.
    /// We also mock the <see cref="TrackResponse"/> which would have been received from the ingestion service.
    /// </summary>
    /// <typeparam name="TStartup">Startup class from the application to be used during this test.</typeparam>
    public class OpenTelemetryWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public ConcurrentBag<TelemetryItem> TelemetryItems => this.Transmitter.TelemetryItems;

        private const string EmptyConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";
        private readonly MockTransmitter Transmitter = new MockTransmitter();
        private ActivityProcessor ActivityProcessor;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            this.ActivityProcessor = new BatchExportActivityProcessor(new AzureMonitorTraceExporter(
                options: new AzureMonitorExporterOptions
                {
                    ConnectionString = EmptyConnectionString,
                },
                transmitter: this.Transmitter));

            builder.ConfigureServices(services => services.AddOpenTelemetryTracing((builder) => builder
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddProcessor(this.ActivityProcessor)));
        }

        public void ForceFlush() => this.ActivityProcessor.ForceFlush();
    }
}
