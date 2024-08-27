// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NETFRAMEWORK
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Events;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.E2ETests
{
    public partial class ILoggerTests
        : IClassFixture<WebApplicationFactory<AspNetCoreTestApp.Program>>, IDisposable
    {
        private readonly WebApplicationFactory<AspNetCoreTestApp.Program> _factory;
        private readonly TelemetryItemOutputHelper _telemetryOutput;

        public ILoggerTests(WebApplicationFactory<AspNetCoreTestApp.Program> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _telemetryOutput = new TelemetryItemOutputHelper(output);
        }

        [Fact]
        public void CustomEventsAreCapturedCorrectly()
        {
            // SETUP MOCK TRANSMITTER TO CAPTURE AZURE MONITOR TELEMETRY
            var testConnectionString = $"InstrumentationKey=unitTest-{nameof(CustomEventsAreCapturedCorrectly)}";
            var telemetryItems = new List<TelemetryItem>();
            var mockTransmitter = new Exporter.Tests.CommonTestFramework.MockTransmitter(telemetryItems);
            // The TransmitterFactory is invoked by the Exporter during initialization to ensure that there's only one instance of a transmitter/connectionString shared by all Exporters.
            // Here we're setting that instance to use the MockTransmitter so this test can capture telemetry before it's sent to Azure Monitor.
            Exporter.Internals.TransmitterFactory.Instance.Set(connectionString: testConnectionString, transmitter: mockTransmitter);

            // SETUP WEBAPPLICATIONFACTORY WITH OPENTELEMETRY
            using (var client = _factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureLogging(loggingBuilder => loggingBuilder.ClearProviders());
                    builder.ConfigureTestServices(serviceCollection =>
                    {
                        serviceCollection.AddOpenTelemetry()
                            .UseAzureMonitor(x =>
                            {
                                x.EnableLiveMetrics = false;
                                x.ConnectionString = testConnectionString;
                            });
                    });

                    builder.Configure(app =>
                    {
                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapGet("/", (IApplicationInsightsEventLogger CustomEventLogger) =>
                            {
                                CustomEventLogger.TrackEvent("TestCustomEvent");
                            });
                        });
                    });
                })
                .CreateClient())
            {
                // Act
                try
                {
                    using var response = client.GetAsync("/").Result;
                }
                catch
                {
                    // Ignore exceptions
                }
            }

            // SHUTDOWN
            var loggerProvider = _factory.Factories.Last().Services.GetRequiredService<LoggerProvider>();
            loggerProvider.ForceFlush();

            // ASSERT
            _telemetryOutput.Write(telemetryItems);
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Where(x => x.Name == "Event").Single();
            var eventData = (TelemetryEventData)(telemetryItem.Data.BaseData);
            Assert.Equal("TestCustomEvent", eventData.Name);
        }

        [Fact]
        public void IloggerFilterCanBeAppliedToCustomEvent()
        {
            // SETUP MOCK TRANSMITTER TO CAPTURE AZURE MONITOR TELEMETRY
            var testConnectionString = $"InstrumentationKey=unitTest-{nameof(CustomEventsAreCapturedCorrectly)}";
            var telemetryItems = new List<TelemetryItem>();
            var mockTransmitter = new Exporter.Tests.CommonTestFramework.MockTransmitter(telemetryItems);
            // The TransmitterFactory is invoked by the Exporter during initialization to ensure that there's only one instance of a transmitter/connectionString shared by all Exporters.
            // Here we're setting that instance to use the MockTransmitter so this test can capture telemetry before it's sent to Azure Monitor.
            Exporter.Internals.TransmitterFactory.Instance.Set(connectionString: testConnectionString, transmitter: mockTransmitter);

            // SETUP WEBAPPLICATIONFACTORY WITH OPENTELEMETRY
            using (var client = _factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureLogging(loggingBuilder =>
                    {
                        loggingBuilder.ClearProviders();

                        // Filter out custom events.
                        loggingBuilder.AddFilter<OpenTelemetryLoggerProvider>("Azure.Monitor.OpenTelemetry.CustomEvents", LogLevel.None);
                    });
                    builder.ConfigureTestServices(serviceCollection =>
                    {
                        serviceCollection.AddOpenTelemetry()
                            .UseAzureMonitor(x =>
                            {
                                x.EnableLiveMetrics = false;
                                x.ConnectionString = testConnectionString;
                            });
                    });

                    builder.Configure(app =>
                    {
                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapGet("/", (IApplicationInsightsEventLogger CustomEventLogger) =>
                            {
                                CustomEventLogger.TrackEvent("TestCustomEvent");
                            });
                        });
                    });
                })
                .CreateClient())
            {
                // Act
                try
                {
                    using var response = client.GetAsync("/").Result;
                }
                catch
                {
                    // Ignore exceptions
                }
            }

            // SHUTDOWN
            var loggerProvider = _factory.Factories.Last().Services.GetRequiredService<LoggerProvider>();
            loggerProvider.ForceFlush();

            // ASSERT
            _telemetryOutput.Write(telemetryItems);

            // Internal Asp.NetCore logging.
            Assert.NotNull(telemetryItems);

            var traceTelemetry = telemetryItems.Where(x => x.Name == "Message").FirstOrDefault();
            Assert.NotNull(traceTelemetry);

            // Custom event should not be collected.
            var eventTelemetry = telemetryItems.Where(x => x.Name == "Event").FirstOrDefault();
            Assert.Null(eventTelemetry);
        }

        public void Dispose()
        {
            // OpenTelemetry is registered on a nested Factory which is not disposed between test runs!
            // MUST explicitly dispose the nested Factory to avoid test conflicts.
            _factory.Factories.Last().Dispose();

            _factory.Dispose();
        }
    }
}
#endif
