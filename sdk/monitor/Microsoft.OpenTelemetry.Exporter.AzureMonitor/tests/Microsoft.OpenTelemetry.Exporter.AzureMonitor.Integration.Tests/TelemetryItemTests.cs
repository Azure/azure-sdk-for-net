// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

            var activity = new Activity("test activity").Start();
            var telemetryItem = this.RunLoggerTest(x => x.Log(logLevel: logLevel, message: message));
            activity.Stop();

            VerifyTelemetryItem.VerifyEvent(
                telemetryItem: telemetryItem,
                expectedVars: new ExpectedTelemetryItemValues
                {
                    Message = message,
                    SeverityLevel = expectedSeverityLevel,
                    SpanId = activity.SpanId.ToHexString(),
                    TraceId = activity.TraceId.ToHexString(),
                });
        }

        private TelemetryItem RunActivityTest(Action<ActivitySource> testScenario)
        {
            // SETUP
            var ActivitySourceName = $"{nameof(TelemetryItemTests)}.{nameof(RunActivityTest)}";
            using var activitySource = new ActivitySource(ActivitySourceName);

            var mockTransmitter = new MockTransmitter();
            var processor = new BatchExportProcessor<Activity>(new AzureMonitorTraceExporter(
                options: new AzureMonitorExporterOptions
                {
                    ConnectionString = EmptyConnectionString,
                },
                transmitter: mockTransmitter));

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(ActivitySourceName)
                .AddProcessor(processor)
                .Build();

            // ACT
            testScenario(activitySource);

            // CLEANUP
            processor.ForceFlush();

            Assert.True(mockTransmitter.TelemetryItems.Any(), "test project did not capture telemetry");
            return mockTransmitter.TelemetryItems.Single();
        }

        private TelemetryItem RunLoggerTest(Action<ILogger<TelemetryItemTests>> testScenario)
        {
            // SETUP
            var mockTransmitter = new MockTransmitter();
            var processor = new BatchExportProcessor<LogRecord>(new AzureMonitorLogExporter(
                options: new AzureMonitorExporterOptions
                {
                    ConnectionString = EmptyConnectionString,
                },
                transmitter: mockTransmitter));

            var serviceCollection = new ServiceCollection().AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace)
                    .AddOpenTelemetry(options => options
                        .AddProcessor(processor));
            });

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<TelemetryItemTests>>();

            // ACT
            testScenario(logger);

            // CLEANUP
            processor.ForceFlush();

            Assert.True(mockTransmitter.TelemetryItems.Any(), "test project did not capture telemetry");
            return mockTransmitter.TelemetryItems.Single();
        }

        /// <summary>
        /// This test is to verify that the correlation Ids from Activity are set on Log Telemetry.
        /// This test will generate two telemetry items and their Ids are expected to match.
        /// This test does not inspect any other fields.
        /// </summary>
        [Fact]
        public void VerifyLoggerWithActivity()
        {
            // SETUP
            var ActivitySourceName = $"{nameof(TelemetryItemTests)}.{nameof(VerifyLoggerWithActivity)}";
            using var activitySource = new ActivitySource(ActivitySourceName);

            var mockTransmitter = new MockTransmitter();

            var azureMonitorExporterOptions = new AzureMonitorExporterOptions
            {
                ConnectionString = EmptyConnectionString,
            };

            var processor1 = new BatchExportProcessor<Activity>(new AzureMonitorTraceExporter(
                options: azureMonitorExporterOptions,
                transmitter: mockTransmitter));

            var processor2 = new BatchExportProcessor<LogRecord>(new AzureMonitorLogExporter(
                options: azureMonitorExporterOptions,
                transmitter: mockTransmitter));

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(ActivitySourceName)
                .AddProcessor(processor1)
                .Build();

            var serviceCollection = new ServiceCollection().AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace)
                    .AddOpenTelemetry(options => options
                        .AddProcessor(processor2));
            });

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<TelemetryItemTests>>();

            // ACT
            using (var activity = activitySource.StartActivity(name: "test activity", kind: ActivityKind.Server))
            {
                activity.SetTag("message", "hello activity!");

                logger.LogWarning("hello ilogger");
            }

            // CLEANUP
            processor1.ForceFlush();
            processor2.ForceFlush();

            // VERIFY
            Assert.True(mockTransmitter.TelemetryItems.Any(), "test project did not capture telemetry");
            Assert.Equal(2, mockTransmitter.TelemetryItems.Count);

            var logTelemetry = mockTransmitter.TelemetryItems.Single(x => x.Name == "Message");
            var activityTelemetry = mockTransmitter.TelemetryItems.Single(x => x.Name == "Request");

            var activityId = ((RequestData)activityTelemetry.Data.BaseData).Id;
            var operationId = activityTelemetry.Tags["ai.operation.id"];

            Assert.Equal(activityId, logTelemetry.Tags["ai.operation.parentId"]);
            Assert.Equal(operationId, logTelemetry.Tags["ai.operation.id"]);
        }
    }
}
