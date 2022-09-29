// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;

using Xunit;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using System.Collections.Concurrent;
using Azure.Core;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests
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

        [Theory(Skip = "https://github.com/Azure/azure-sdk-for-net/issues/24372")]
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

            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(ActivitySourceName)
                .AddAzureMonitorTraceExporterForTest(out ConcurrentBag<TelemetryItem> telemetryItems)
                .Build();

            // ACT
            testScenario(activitySource);

            Assert.True(telemetryItems.Any(), "test project did not capture telemetry");
            return telemetryItems.Single();
        }

        private TelemetryItem RunLoggerTest(Action<ILogger<TelemetryItemTests>> testScenario)
        {
            // SETUP
            ConcurrentBag<TelemetryItem> telemetryItems = null;

            var serviceCollection = new ServiceCollection().AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace)
                    .AddOpenTelemetry(options => options
                        .AddAzureMonitorLogExporterForTest(out telemetryItems));
            });

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var logger = serviceProvider.GetRequiredService<ILogger<TelemetryItemTests>>();

            // ACT
            testScenario(logger);

            // CLEANUP
            Assert.True(telemetryItems.Any(), "test project did not capture telemetry");
            return telemetryItems.Single();
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

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetSampler(new AlwaysOnSampler())
                .AddSource(ActivitySourceName)
                .AddAzureMonitorTraceExporterForTest(out ConcurrentBag<TelemetryItem> activityTelemetryItems)
                .Build();

            ConcurrentBag<TelemetryItem> logTelemetryItems = null;
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddAzureMonitorLogExporterForTest(out logTelemetryItems);
                });
            });

            // ACT
            using (var activity = activitySource.StartActivity(name: "test activity", kind: ActivityKind.Server))
            {
                activity.SetTag("message", "hello activity!");

                var logger = loggerFactory.CreateLogger<TelemetryItemTests>();
                logger.LogWarning("hello ilogger");
            }

            // CLEANUP
            tracerProvider.Dispose();
            loggerFactory.Dispose();

            // VERIFY
            Assert.True(logTelemetryItems.Any(), "test project did not capture telemetry");
            Assert.True(activityTelemetryItems.Any(), "test project did not capture telemetry");

            var logTelemetry = logTelemetryItems.Single();
            Assert.Equal("Message", logTelemetry.Name);

            var activityTelemetry = activityTelemetryItems.Single();
            Assert.Equal("Request", activityTelemetry.Name);

            Assert.Equal(((RequestData)activityTelemetry.Data.BaseData).Id, logTelemetry.Tags["ai.operation.parentId"]);
            Assert.Equal(activityTelemetry.Tags["ai.operation.id"], logTelemetry.Tags["ai.operation.id"]);
        }
    }
}
