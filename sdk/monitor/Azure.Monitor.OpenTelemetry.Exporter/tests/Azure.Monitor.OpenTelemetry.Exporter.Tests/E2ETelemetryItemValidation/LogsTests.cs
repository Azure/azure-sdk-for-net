// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.E2ETelemetryItemValidation
{
    /// <summary>
    /// The purpose of these tests is to validate the <see cref="TelemetryItem"/> that is created
    /// based on interacting with <see cref="LoggerFactory"/> and <see cref="Logger"/>.
    /// </summary>
    public class LogsTests
    {
        internal readonly TelemetryItemOutputHelper telemetryOutput;

        public LogsTests(ITestOutputHelper output)
        {
            this.telemetryOutput = new TelemetryItemOutputHelper(output);
        }

        [Theory]
        [InlineData(LogLevel.Information, "Information")]
        [InlineData(LogLevel.Warning, "Warning")]
        [InlineData(LogLevel.Error, "Error")]
        [InlineData(LogLevel.Critical, "Critical")]
        [InlineData(LogLevel.Debug, "Verbose")]
        [InlineData(LogLevel.Trace, "Verbose")]
        public void VerifyLog(LogLevel logLevel, string expectedSeverityLevel)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>(logCategoryName, logLevel)
                    .AddOpenTelemetry(options =>
                    {
                        options.AddAzureMonitorLogExporterForTest(new MockPlatform(), out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);
            logger.Log(
                logLevel: logLevel,
                eventId: 0,
                exception: null,
                message: "Hello {name}.",
                args: new object[] { "World" });

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Message").Single();

            TelemetryItemValidationHelper.AssertMessageTelemetry(
                telemetryItem: telemetryItem!,
                expectedSeverityLevel: expectedSeverityLevel,
                expectedMessage: "Hello {name}.",
                expectedMessageProperties: new Dictionary<string, string> { { "name", "World" }},
                expectedSpanId: null,
                expectedTraceId: null);
        }

        [Theory]
        [InlineData(LogLevel.Information, "Information")]
        [InlineData(LogLevel.Warning, "Warning")]
        [InlineData(LogLevel.Error, "Error")]
        [InlineData(LogLevel.Critical, "Critical")]
        [InlineData(LogLevel.Debug, "Verbose")]
        [InlineData(LogLevel.Trace, "Verbose")]
        public void VerifyException(LogLevel logLevel, string expectedSeverityLevel)
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>(logCategoryName, logLevel)
                    .AddOpenTelemetry(options =>
                    {
                        options.AddAzureMonitorLogExporterForTest(new MockPlatform(), out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);

            try
            {
                throw new Exception("Test Exception");
            }
            catch (Exception ex)
            {
                logger.Log(
                    logLevel: logLevel,
                    eventId: 0,
                    exception: ex,
                    message: "Hello {name}.",
                    args: new object[] { "World" });
            }

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Exception").Single();

            TelemetryItemValidationHelper.AssertLog_As_ExceptionTelemetry(
                telemetryItem: telemetryItem!,
                expectedSeverityLevel: expectedSeverityLevel,
                expectedMessage: "Test Exception",
                expectedTypeName: "System.Exception");
        }

        [Theory]
        [InlineData(true, true, true)]
        [InlineData(true, true, false)]
        [InlineData(true, false, true)]
        [InlineData(true, false, false)]
        [InlineData(false, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        [InlineData(false, true, true)]
        public void ValidateLogSampling(bool logWithinActivityContext, bool enableSampling, bool sampledIn)
        {
            List<TelemetryItem>? telemetryLogItems = null;
            List<TelemetryItem>? telemetryActivityItems = null;
            MockPlatform platform = new MockPlatform();

            platform.SetEnvironmentVariable(EnvironmentVariableConstants.ENABLE_LOG_SAMPLING, enableSampling ? "true" : "false");

            // SETUP
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddOpenTelemetry(options =>
                    {
                        options.AddAzureMonitorLogExporterForTest(platform, out telemetryLogItems);
                    });
            });

            var uniqueTestId = Guid.NewGuid();

            var logCategoryName = $"logCategoryName{uniqueTestId}";

             var logger = loggerFactory.CreateLogger(logCategoryName);

            var activitySourceName = $"activitySourceName{uniqueTestId}";
            using var activitySource = new ActivitySource(activitySourceName);

            var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .AddSource(activitySourceName)
                .AddAzureMonitorTraceExporterForTest(out telemetryActivityItems)
                .Build();

            // ACT
            if (logWithinActivityContext)
            {
                using var activity = activitySource.StartActivity(name: "SayHello");

                if (!sampledIn && activity != null)
                {
                    activity.ActivityTraceFlags &= ~ActivityTraceFlags.Recorded;
                }

                logger.Log(
                    LogLevel.Information,
                    eventId: 0,
                    exception: null,
                    message: "Hello {name}.",
                    args: new object[] { "World" });

                activity?.Stop();
            }
            else
            {
                logger.Log(
                   LogLevel.Information,
                   eventId: 0,
                   exception: null,
                   message: "Hello {name}.",
                   args: new object[] { "World" });
            }

            // flush logs
            loggerFactory.Dispose();

            if (enableSampling && logWithinActivityContext)
            {
                if (!sampledIn)
                {
                    Assert.NotNull(telemetryLogItems);
                    Assert.Empty(telemetryLogItems);
                }
                else
                {
                    Assert.NotNull(telemetryLogItems);
                    Assert.Single(telemetryLogItems);
                }
            }
            else
            {
                Assert.NotNull(telemetryLogItems);
                Assert.Single(telemetryLogItems);
            }
        }
    }
}
