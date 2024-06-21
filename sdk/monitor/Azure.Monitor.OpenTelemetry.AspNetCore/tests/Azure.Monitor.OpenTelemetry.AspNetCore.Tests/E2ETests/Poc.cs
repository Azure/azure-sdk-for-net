// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.E2ETests
{
    public class Poc
    {
        [Fact]
        public void Test()
        {
            var testConnectionString = "InstrumentationKey=unitTest";

            Azure.Monitor.OpenTelemetry.Exporter.Internals.TransmitterFactory transmitterFactory = Azure.Monitor.OpenTelemetry.Exporter.Internals.TransmitterFactory.Instance;

            var telemetryItems = new List<TelemetryItem>();
            var mockTransmitter = new Exporter.Tests.CommonTestFramework.MockTransmitter(telemetryItems);

            transmitterFactory.Set(testConnectionString, mockTransmitter);

            //// SETUP
            //var uniqueTestId = Guid.NewGuid();

            //var logCategoryName = $"logCategoryName{uniqueTestId}";

            //List<TelemetryItem>? telemetryItems = null;

            //var loggerFactory = LoggerFactory.Create(builder =>
            //{
            //    builder
            //        .AddFilter<OpenTelemetryLoggerProvider>(logCategoryName, logLevel)
            //        .AddOpenTelemetry(options =>
            //        {
            //            options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
            //            options.AddAzureMonitorLogExporterForTest(out telemetryItems);
            //        });
            //});

            //// ACT
            //var logger = loggerFactory.CreateLogger(logCategoryName);
            //logger.Log(
            //    logLevel: logLevel,
            //    eventId: 0,
            //    exception: null,
            //    message: "Hello {name}.",
            //    args: new object[] { "World" });

            //// CLEANUP
            //loggerFactory.Dispose();

            //// ASSERT
            //Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            //this.telemetryOutput.Write(telemetryItems);
            //var telemetryItem = telemetryItems?.Where(x => x.Name == "Message").Single();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOpenTelemetry().UseAzureMonitor(x => x.ConnectionString = testConnectionString);
            var service = serviceCollection.BuildServiceProvider();

            var logger = service.GetRequiredService<ILogger<Poc>>();
            logger.LogInformation("Hello {name}.", "World");
            service.Dispose();

            Assert.Single(telemetryItems);
        }
    }
}
