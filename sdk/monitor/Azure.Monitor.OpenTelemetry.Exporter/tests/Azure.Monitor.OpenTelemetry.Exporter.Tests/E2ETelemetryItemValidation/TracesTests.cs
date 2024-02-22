// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems)
                .Build();

            // ACT
            string spanId, traceId;
            using (var activity = activitySource.StartActivity(name: "SayHello", kind: activityKind ))
            {
                Assert.NotNull(activity);
                traceId = activity.TraceId.ToHexString();
                spanId = activity.SpanId.ToHexString();

                activity.SetTag("enduser.id", "TestUser"); //authenticated user
                activity.SetTag("integer", 1);
                activity.SetTag("message", "Hello World!");
                activity.SetTag("intArray", new int[] { 1, 2, 3 });
                activity?.SetStatus(ActivityStatusCode.Ok);
            }

            // CLEANUP
            tracerProvider?.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Where(x => x.Name == "RemoteDependency").First()!;

            TelemetryItemValidationHelper.AssertActivity_As_DependencyTelemetry(
                telemetryItem: telemetryItem,
                expectedName: "SayHello",
                expectedTraceId: traceId,
                expectedSpanId: spanId,
                expectedAuthUserId: "TestUser",
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
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems)
                .Build();

            // ACT
            string spanId, traceId;
            using (var activity = activitySource.StartActivity(name: "SayHello", kind: activityKind))
            {
                Assert.NotNull(activity);
                traceId = activity.TraceId.ToHexString();
                spanId = activity.SpanId.ToHexString();

                activity.SetTag("enduser.id", "TestUser"); //authenticated user
                activity.SetTag("integer", 1);
                activity.SetTag("message", "Hello World!");
                activity.SetTag("intArray", new int[] { 1, 2, 3 });
                activity?.SetStatus(ActivityStatusCode.Ok);
            }

            // CLEANUP
            tracerProvider?.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems.Where(x => x.Name =="Request").First()!;

            TelemetryItemValidationHelper.AssertActivity_As_RequestTelemetry(
                telemetryItem: telemetryItem,
                activityKind: activityKind,
                expectedName: "SayHello",
                expectedTraceId: traceId,
                expectedSpanId: spanId,
                expectedAuthUserId: "TestUser",
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
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems)
                .Build();

            // ACT
            string? spanId, traceId;

            using (var activity = activitySource.StartActivity(name: "ActivityWithException"))
            {
                Assert.NotNull(activity);
                traceId = activity.TraceId.ToHexString();
                spanId = activity.SpanId.ToHexString();

                activity.SetTag("enduser.id", "TestUser"); //authenticated user

                try
                {
                    throw new Exception("Test exception");
                }
                catch (Exception ex)
                {
                    activity?.SetStatus(ActivityStatusCode.Error);
                    activity?.RecordException(ex, new TagList
                    {
                        { "someKey", "someValue" },
                    });
                }
            }

            // CLEANUP
            tracerProvider?.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var activityTelemetryItem = telemetryItems.First(x => x.Name == "RemoteDependency");

            TelemetryItemValidationHelper.AssertActivity_As_DependencyTelemetry(
                telemetryItem: activityTelemetryItem,
                expectedName: "ActivityWithException",
                expectedTraceId: traceId,
                expectedSpanId: spanId,
                expectedAuthUserId: "TestUser",
                expectedProperties: null,
                expectedSuccess: false);

            var exceptionTelemetryItem = telemetryItems.First(x => x.Name == "Exception");

            TelemetryItemValidationHelper.AssertActivity_RecordedException(
                telemetryItem: exceptionTelemetryItem,
                expectedExceptionMessage: "Test exception",
                expectedExceptionTypeName: "System.Exception",
                expectedTraceId: traceId,
                expectedSpanId: spanId,
                expectedProperties: new Dictionary<string, string> { { "someKey", "someValue" } },
                additionalChecks: data =>
                {
                    Assert.False(data.Properties.ContainsKey("exception.type"));
                    Assert.False(data.Properties.ContainsKey("exception.message"));
                    Assert.False(data.Properties.ContainsKey("exception.stacktrace"));
                });
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

            List<TelemetryItem>? logTelemetryItems = null;

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySourceName)
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> activityTelemetryItems)
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
                Assert.NotNull(activity);
                spanId = activity.SpanId.ToHexString();
                traceId = activity.TraceId.ToHexString();

                activity.SetTag("enduser.id", "TestUser"); //authenticated user

                var logger = loggerFactory.CreateLogger(logCategoryName);

                logger.Log(
                    logLevel: logLevel,
                    eventId: 0,
                    exception: null,
                    message: "Hello {name}.",
                    args: new object[] { "World" });
            }

            // CLEANUP
            tracerProvider?.Dispose();
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(activityTelemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(activityTelemetryItems);
            var activityTelemetryItem = activityTelemetryItems.Where(x => x.Name == "RemoteDependency").First()!;

            TelemetryItemValidationHelper.AssertActivity_As_DependencyTelemetry(
                telemetryItem: activityTelemetryItem,
                expectedName: activityName,
                expectedTraceId: traceId,
                expectedSpanId: spanId,
                expectedAuthUserId: "TestUser",
                expectedProperties: null);

            Assert.True(logTelemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(logTelemetryItems!);
            var logTelemetryItem = logTelemetryItems?.Where(x => x.Name == "Message").First()!;

            TelemetryItemValidationHelper.AssertMessageTelemetry(
                telemetryItem: logTelemetryItem!,
                expectedSeverityLevel: expectedSeverityLevel,
                expectedMessage: "Hello {name}.",
                expectedMessageProperties: new Dictionary<string, string> { { "name", "World" } },
                expectedSpanId: spanId,
                expectedTraceId: traceId);
        }

        [Fact]
        public void TestActivityEvents()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySourceName)
                .AddAzureMonitorTraceExporterForTest(out List<TelemetryItem> telemetryItems)
                .Build();

            // ACT
            string? spanId, traceId;

            using (var activity = activitySource.StartActivity(name: "ActivityWithException"))
            {
                Assert.NotNull(activity);
                traceId = activity.TraceId.ToHexString();
                spanId = activity.SpanId.ToHexString();

                var eventTags = new Dictionary<string, object?>
                {
                    { "integer", 1 },
                    { "string", "Hello, World!" },
                    { "intArray", new int[] { 1, 2, 3 } }
                };
                activity?.AddEvent(new("Gonna try it!", DateTimeOffset.Now, new(eventTags)));
            }

            // CLEANUP
            tracerProvider?.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);

            var messageTelemetryItem = telemetryItems.First(x => x.Name == "Message");

            TelemetryItemValidationHelper.AssertMessageTelemetry(
                telemetryItem: messageTelemetryItem,
                expectedSeverityLevel: null,
                expectedMessage: "Gonna try it!",
                expectedMessageProperties: new Dictionary<string, string> {
                    { "integer", "1" },
                    { "string", "Hello, World!" },
                    { "intArray", "1,2,3" } },
                expectedSpanId: spanId,
                expectedTraceId: traceId);
        }
    }
}
