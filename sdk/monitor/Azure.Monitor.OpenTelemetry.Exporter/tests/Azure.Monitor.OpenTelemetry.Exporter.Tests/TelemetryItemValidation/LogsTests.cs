// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.TelemetryItemValidation
{
    /// <summary>
    /// The purpose of these tests is to validate the <see cref="TelemetryItem"/> that is created
    /// based on interacting with <see cref="LoggerFactory"/> and <see cref="Logger"/>.
    /// </summary>
    public class LogsTests
    {
        [Theory]
        [InlineData(LogLevel.Trace)]
        [InlineData(LogLevel.Debug)]
        [InlineData(LogLevel.Information)]
        [InlineData(LogLevel.Warning)]
        [InlineData(LogLevel.Error)]
        [InlineData(LogLevel.Critical)]
        public void VerifyLog(LogLevel logLevel)
        {
            // SETUP
            ConcurrentBag<TelemetryItem> telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>("*", logLevel)
                    .AddOpenTelemetry(options =>
                    {
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger<LogsTests>();
            logger.Log(
                logLevel: logLevel,
                eventId: 0,
                exception: null,
                message: "Hello {name}.",
                args: new object[] { "World" });

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertLog_As_MessageTelemetry(
                telemetryItem: telemetryItem,
                expectedLogLevel: logLevel,
                expectedMessage: "Hello {name}.",
                expectedMeessageProperties: new Dictionary<string, string> { { "name", "World" }});
        }

        [Theory(Skip = "Bug: ILogger message is overwriting the Exception.Message.")]
        [InlineData(LogLevel.Trace)]
        [InlineData(LogLevel.Debug)]
        [InlineData(LogLevel.Information)]
        [InlineData(LogLevel.Warning)]
        [InlineData(LogLevel.Error)]
        [InlineData(LogLevel.Critical)]
        public void VerifyException(LogLevel logLevel)
        {
            // SETUP
            ConcurrentBag<TelemetryItem> telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter<OpenTelemetryLoggerProvider>("*", logLevel)
                    .AddOpenTelemetry(options =>
                    {
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger<LogsTests>();

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
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Single();

            TelemetryItemValidationHelper.AssertLog_As_ExceptionTelemetry(
                telemetryItem: telemetryItem,
                expectedLogLevel: logLevel,
                expectedMessage: "Test Exception", // TODO: this fails. Currently the ILogger message is overwriting the Exception.Message.
                expectedTypeName: "System.Exception");
        }
    }
}
