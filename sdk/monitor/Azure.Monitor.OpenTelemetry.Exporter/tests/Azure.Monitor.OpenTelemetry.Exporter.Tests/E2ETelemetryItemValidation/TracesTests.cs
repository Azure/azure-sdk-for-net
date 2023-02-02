// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable // TODO: remove and fix errors

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        internal readonly TelemetryItemOutputHelper telemetryOutput;

        public TracesTests(ITestOutputHelper output)
        {
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
            var telemetryItem = telemetryItems.First(); // TODO: Change to Single(). Still investigating random duplicate export which only repros on build server.

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
            var telemetryItem = telemetryItems.First(); // TODO: Change to Single(). Still investigating random duplicate export which only repros on build server.

            TelemetryItemValidationHelper.AssertActivity_As_RequestTelemetry(
                telemetryItem: telemetryItem,
                activityKind: activityKind,
                expectedName: "SayHello",
                expectedTraceId: traceId,
                expectedSpanId: spanId,
                expectedProperties: new Dictionary<string, string> { { "integer", "1" }, { "message", "Hello World!" }, { "intArray", "1,2,3" } });
        }

        [Fact]
        public void VerifyExceptionWithinActivity()
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
            string spanId = null, traceId = null;

            using (var activity = activitySource.StartActivity(name: "ActivityWithException"))
            {
                traceId = activity.TraceId.ToHexString();
                spanId = activity.SpanId.ToHexString();

                try
                {
                    throw new Exception("Test exception");
                }
                catch (Exception ex)
                {
                    activity?.SetStatus(ActivityStatusCode.Error);
                    activity?.RecordException(ex);
                }
            }

            // CLEANUP
            tracerProvider.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var activityTelemetryItem = telemetryItems.First(x => x.Name == "RemoteDependency"); // TODO: Change to Single(). Still investigating random duplicate export which only repros on build server.

            TelemetryItemValidationHelper.AssertActivity_As_DependencyTelemetry(
                telemetryItem: activityTelemetryItem,
                expectedName: "ActivityWithException",
                expectedTraceId: traceId,
                expectedSpanId: spanId,
                expectedProperties: null,
                expectedSuccess: false);

            var exceptionTelemetryItem = telemetryItems.First(x => x.Name == "Exception");

            TelemetryItemValidationHelper.AssertActivity_RecordedException(
                telemetryItem: exceptionTelemetryItem,
                expectedExceptionMessage: "Test exception",
                expectedExceptionTypeName: "System.Exception",
                expectedTraceId: traceId,
                expectedSpanId: spanId);
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

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySourceName)
                .AddAzureMonitorTraceExporterForTest(out ConcurrentBag<TelemetryItem> activityTelemetryItems)
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
            Assert.True(activityTelemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(activityTelemetryItems);
            var activityTelemetryItem = activityTelemetryItems.First(); // TODO: Change to Single(). Still investigating random duplicate export which only repros on build server.

            TelemetryItemValidationHelper.AssertActivity_As_DependencyTelemetry(
                telemetryItem: activityTelemetryItem,
                expectedName: activityName,
                expectedTraceId: traceId,
                expectedSpanId: spanId,
                expectedProperties: null);

            Assert.True(logTelemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(logTelemetryItems);
            var logTelemetryItem = logTelemetryItems.Single();

            TelemetryItemValidationHelper.AssertLog_As_MessageTelemetry(
                telemetryItem: logTelemetryItem,
                expectedSeverityLevel: expectedSeverityLevel,
                expectedMessage: "Hello {name}.",
                expectedMeessageProperties: new Dictionary<string, string> { { "name", "World" } },
                expectedSpanId: spanId,
                expectedTraceId: traceId);
        }
    }
}
