// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.E2ETelemetryItemValidation
{
    /// <summary>
    /// The purpose of these tests is to validate the <see cref="TelemetryItem"/> that is created
    /// based on interacting with <see cref="TracerProvider"/> and <see cref="Activity"/>.
    /// </summary>
    public class TracesTests
    {
        internal readonly ITestOutputHelper _outputHelper;
        internal readonly TelemetryItemOutputHelper telemetryOutput;

        public TracesTests(ITestOutputHelper output)
        {
            this._outputHelper = output;
            this.telemetryOutput = new TelemetryItemOutputHelper(output);
        }

        [Theory]
        [InlineData(ActivityKind.Client)]
        [InlineData(ActivityKind.Producer)]
        [InlineData(ActivityKind.Internal)]
        public void VerifyTrace_CreatesDependency(ActivityKind activityKind)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySourceName)
                .AddAzureMonitorTraceExporterForTest(out ConcurrentBag<TelemetryItem> telemetryItems)
                .Build();

            // ACT
            string spanId, traceId;
            using (var activity = activitySource.StartActivity(name: "SayHello", kind: activityKind ))
            {
                traceId = activity.TraceId.ToHexString();
                spanId = activity.SpanId.ToHexString();

                activity.SetTag("integer", 1);
                activity.SetTag("message", "Hello World!");
                activity.SetTag("intArray", new int[] { 1, 2, 3 });
                activity?.SetStatus(ActivityStatusCode.Ok);
            }

            // CLEANUP
            tracerProvider.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertActivity_As_DependencyTelemetry(
                telemetryItem: telemetryItem,
                expectedName: "SayHello",
                expectedTraceId: traceId,
                expectedSpanId: spanId,
                expectedProperties: new Dictionary<string, string> { { "integer", "1" }, { "message", "Hello World!" }, { "intArray", "1,2,3" } });
        }

        [Theory]
        [InlineData(ActivityKind.Server)]
        [InlineData(ActivityKind.Consumer)]
        public void VerifyTrace_CreatesRequest(ActivityKind activityKind)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySourceName)
                .AddAzureMonitorTraceExporterForTest(out ConcurrentBag<TelemetryItem> telemetryItems)
                .Build();

            // ACT
            string spanId, traceId;
            using (var activity = activitySource.StartActivity(name: "SayHello", kind: activityKind))
            {
                traceId = activity.TraceId.ToHexString();
                spanId = activity.SpanId.ToHexString();

                activity.SetTag("integer", 1);
                activity.SetTag("message", "Hello World!");
                activity.SetTag("intArray", new int[] { 1, 2, 3 });
                activity?.SetStatus(ActivityStatusCode.Ok);
            }

            // CLEANUP
            tracerProvider.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertActivity_As_RequestTelemetry(
                telemetryItem: telemetryItem,
                activityKind: activityKind,
                expectedName: "SayHello",
                expectedTraceId: traceId,
                expectedSpanId: spanId,
                expectedProperties: new Dictionary<string, string> { { "integer", "1" }, { "message", "Hello World!" }, { "intArray", "1,2,3" } });
        }

        [Theory]
        [InlineData(LogLevel.Information, "Information")]
        [InlineData(LogLevel.Warning, "Warning")]
        [InlineData(LogLevel.Error, "Error")]
        [InlineData(LogLevel.Critical, "Critical")]
        [InlineData(LogLevel.Debug, "Verbose")]
        [InlineData(LogLevel.Trace, "Verbose")]
        public void VerifyLogWithinActivity(LogLevel logLevel, string expectedSeverityLevel)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);

            var logCategoryName = $"logCategoryName{uniqueTestId}"; ;

            ConcurrentBag<TelemetryItem> logTelemetryItems = null;
            List<Activity> inMemoryActivities = new List<Activity>();

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySourceName)
                .AddAzureMonitorTraceExporterForTest(out ConcurrentBag<TelemetryItem> activityTelemetryItems)
                .AddInMemoryExporter(inMemoryActivities)
                .Build();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>(logCategoryName, logLevel)
                    .AddOpenTelemetry(options =>
                    {
                        options.AddAzureMonitorLogExporterForTest(out logTelemetryItems);
                    });
            });

            // ACT
            string spanId, traceId;
            string activityName = $"TestActivity {nameof(VerifyLogWithinActivity)} {logLevel}";

            using (var activity = activitySource.StartActivity(name: activityName))
            {
                spanId = activity.SpanId.ToHexString();
                traceId = activity.TraceId.ToHexString();

                var logger = loggerFactory.CreateLogger(logCategoryName);

                logger.Log(
                    logLevel: logLevel,
                    eventId: 0,
                    exception: null,
                    message: "Hello {name}.",
                    args: new object[] { "World" });
            }

            // CLEANUP
            tracerProvider.Dispose();
            loggerFactory.Dispose();

            // ASSERT
            try
            {
                Assert.True(activityTelemetryItems.Count == 1, "Unexpected count of exported Activities.");
                Assert.True(logTelemetryItems.Count == 1, "Unexpected count of exported Logs.");

                Assert.True(activityTelemetryItems.Any(), "Unit test failed to collect telemetry.");
                //this.telemetryOutput.Write(activityTelemetryItems);
                var activityTelemetryItem = activityTelemetryItems.Single();

                TelemetryItemValidationHelper.AssertActivity_As_DependencyTelemetry(
                    telemetryItem: activityTelemetryItem,
                    expectedName: activityName,
                    expectedTraceId: traceId,
                    expectedSpanId: spanId,
                    expectedProperties: null);

                Assert.True(logTelemetryItems.Any(), "Unit test failed to collect telemetry.");
                //this.telemetryOutput.Write(logTelemetryItems);
                var logTelemetryItem = logTelemetryItems.Single();

                TelemetryItemValidationHelper.AssertLog_As_MessageTelemetry(
                    telemetryItem: logTelemetryItem,
                    expectedSeverityLevel: expectedSeverityLevel,
                    expectedMessage: "Hello {name}.",
                    expectedMeessageProperties: new Dictionary<string, string> { { "name", "World" } },
                    expectedSpanId: spanId,
                    expectedTraceId: traceId);
            }
            catch (Exception)
            {
                this._outputHelper.WriteLine($"InMemoryExporter Activity Count: {inMemoryActivities.Count}  AzureMonitorExporter ActivityTelemetry Count: {activityTelemetryItems.Count}  AzureMonitorExporter LogTelemetry Count:{logTelemetryItems.Count}");
                _outputHelper.WriteLine($"Expected TraceId:{traceId}  Expected SpanId:{spanId}\n");

                foreach (var activity in inMemoryActivities)
                {
                    this._outputHelper.WriteLine("Exported Activity:");
                    this._outputHelper.WriteLine($"\tDisplayName: {activity.DisplayName}");
                    this._outputHelper.WriteLine($"\tId: {activity.Id}");
                    this._outputHelper.WriteLine($"\tTraceId: {activity.TraceId.ToHexString()}");
                    this._outputHelper.WriteLine($"\tSpanId: {activity.SpanId.ToHexString()}");
                }

                throw;
            }
        }

        [Fact]
        public void StressTest_AzureMonitorExporter()
        {
            // Running this test on a loop to try and force the failure.

            for (int i = 0; i < 1000; i++)
            {
                VerifyLogWithinActivity(LogLevel.Trace, "Verbose");
            }
        }

        [Theory]
        [InlineData(LogLevel.Information)]
        [InlineData(LogLevel.Warning)]
        [InlineData(LogLevel.Error)]
        [InlineData(LogLevel.Critical)]
        [InlineData(LogLevel.Debug)]
        [InlineData(LogLevel.Trace)]
        public void LogWithinActivity(LogLevel logLevel)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<Activity> exportedActivities = new List<Activity>();
            List<LogRecord> exportedLogs = new List<LogRecord>();

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySourceName)
                .AddInMemoryExporter(exportedActivities)
                .Build();

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>(logCategoryName, logLevel)
                    .AddOpenTelemetry(options =>
                    {
                        options.AddInMemoryExporter(exportedLogs);
                    });
            });

            // ACT
            string spanId, traceId;
            string activityName = $"TestActivity {nameof(this.LogWithinActivity)} {logLevel}";

            using (var activity = activitySource.StartActivity(name: activityName))
            {
                spanId = activity.SpanId.ToHexString();
                traceId = activity.TraceId.ToHexString();

                var logger = loggerFactory.CreateLogger(logCategoryName);

                logger.Log(
                    logLevel: logLevel,
                    eventId: 0,
                    exception: null,
                    message: "Hello {name}.",
                    args: new object[] { "World" });
            }

            // CLEANUP
            tracerProvider.Dispose();
            loggerFactory.Dispose();

            // ASSERT
            try
            {
                Assert.True(exportedActivities.Count == 1, "Unexpected count of exported Activities.");
                Assert.True(exportedLogs.Count == 1, "Unexpected count of exported Logs.");
            }
            catch (Exception)
            {
                this._outputHelper.WriteLine($"Activities Count:{exportedActivities.Count}  Logs Count:{exportedLogs.Count}\n");
                this._outputHelper.WriteLine($"Expected TraceId:{traceId}  Expected SpanId:{spanId}\n");

                foreach (var activity in exportedActivities)
                {
                    this._outputHelper.WriteLine("Exported Activity:");
                    this._outputHelper.WriteLine($"\tDisplayName: {activity.DisplayName}");
                    this._outputHelper.WriteLine($"\tId: {activity.Id}");
                    this._outputHelper.WriteLine($"\tTraceId: {activity.TraceId.ToHexString()}");
                    this._outputHelper.WriteLine($"\tSpanId: {activity.SpanId.ToHexString()}");
                }

                throw;
            }
        }

        [Fact]
        public void StressTest_InMemoryExporter()
        {
            // Running this test on a loop to try and capture the intermittent failure.

            for (int i = 0; i < 10000; i++)
            {
                this.LogWithinActivity(LogLevel.Trace);
            }
        }
    }
}
