// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.TestFramework;
using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Models;

using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;

using Xunit;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests
{
    /// <summary>
    /// The purpose of these tests are to verify various types of Telemetry.
    /// </summary>
    public class TelemetryItemTests
    {
        private const string EmptyConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        /// <summary>
        /// This test creates an Activity that should pass through the OpenTelemetry pipeline.
        /// AzureMonitorExporter will convert this to a <see cref="TelemetryItem"/>.
        /// This test will validate the TelemetryItem against expected values.
        /// </summary>
        /// <param name="activityKind"></param>
        [Theory]
        [InlineData(ActivityKind.Client)]
        [InlineData(ActivityKind.Consumer)]
        [InlineData(ActivityKind.Internal)]
        [InlineData(ActivityKind.Producer)]
        [InlineData(ActivityKind.Server)]
        public void VerifyActivity(ActivityKind activityKind)
        {
            var activityName = "TestActivity";

            var telemetryItem = this.RunActivityTest((activitySource) =>
            {
                using (var activity = activitySource.StartActivity(name: activityName, kind: activityKind))
                {
                    activity.SetTag("integer", 1);
                    activity.SetTag("message", "Hello World!");
                    activity.SetTag("intArray", new int[] { 1, 2, 3 });
                }
            });

            VerifyTelemetryItem.Verify(
                telemetryItem: telemetryItem,
                activityKind: activityKind,
                expectedVars: new ExpectedTelemetryItemValues
                {
                    Name = activityName,
                    CustomProperties = new Dictionary<string, string> {
                        {"integer", "1" },
                        {"message", "Hello World!" },
                        {"intArray", "1,2,3" } }
                });
        }

        [Theory]
        [InlineData(LogLevel.Information, "Information")]
        [InlineData(LogLevel.Warning, "Warning")]
        [InlineData(LogLevel.Error, "Error")]
        [InlineData(LogLevel.Critical, "Critical")]
        [InlineData(LogLevel.Debug, "Verbose")]
        [InlineData(LogLevel.Trace, "Verbose")]
        public void VerifyILogger(LogLevel logLevel, string expectedSeverityLevel)
        {
            var message = "Hello World!";

            var telemetryItem = this.RunLoggerTest(x => x.Log(logLevel: logLevel, message: message));

            VerifyTelemetryItem.VerifyEvent(
                telemetryItem: telemetryItem,
                expectedVars: new ExpectedTelemetryItemValues
                {
                    Message = message,
                    SeverityLevel = expectedSeverityLevel,
                });
        }

        private TelemetryItem RunActivityTest(Action<ActivitySource> testScenario)
        {
            // SETUP
            var ActivitySourceName = "MyCompany.MyProduct.MyLibrary";
            using var activitySource = new ActivitySource(ActivitySourceName);

            var transmitter = new MockTransmitter();
            var processor = new BatchExportProcessor<Activity>(new AzureMonitorTraceExporter(
                options: new AzureMonitorExporterOptions
                {
                    ConnectionString = EmptyConnectionString,
                },
                transmitter: transmitter));

            Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(ActivitySourceName)
                .AddProcessor(processor)
                .Build();

            // ACT
            testScenario(activitySource);

            // CLEANUP
            processor.ForceFlush();
            //Task.Delay(100).Wait(); //TODO: HOW TO REMOVE THIS WAIT?

            Assert.True(transmitter.TelemetryItems.Any(), "test project did not capture telemetry");
            return transmitter.TelemetryItems.Single();
        }

        private TelemetryItem RunLoggerTest(Action<ILogger<TelemetryItemTests>> testScenario)
        {
            // SETUP
            var transmitter = new MockTransmitter();
            var processor = new BatchExportProcessor<LogRecord>(new AzureMonitorLogExporter(
                options: new AzureMonitorExporterOptions
                {
                    ConnectionString = EmptyConnectionString,
                },
                transmitter: transmitter));

            var serviceCollection = new ServiceCollection().AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace)
                    .AddOpenTelemetry(options => options
                    .AddProcessor(processor));
            });

            // ACT
            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<TelemetryItemTests>>();
            testScenario(logger);

            // CLEANUP
            processor.ForceFlush();
            //Task.Delay(100).Wait(); //TODO: HOW TO REMOVE THIS WAIT?

            Assert.True(transmitter.TelemetryItems.Any(), "test project did not capture telemetry");
            return transmitter.TelemetryItems.Single();
        }

        // TODO: INCLUDE ADDITIONAL TESTS VALIDATING ILOGGER + ACTIVITY
    }
}
