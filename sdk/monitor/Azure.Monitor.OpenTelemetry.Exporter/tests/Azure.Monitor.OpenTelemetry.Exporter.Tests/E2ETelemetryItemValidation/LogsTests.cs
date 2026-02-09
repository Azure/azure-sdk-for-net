// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests.E2ETelemetryItemValidation
{
    /// <summary>
    /// The purpose of these tests is to validate the <see cref="TelemetryItem"/> that is created
    /// based on interacting with <see cref="LoggerFactory"/> and <see cref="Logger"/>.
    /// </summary>
    public class LogsTests
    {
        internal readonly TelemetryItemOutputHelper telemetryOutput;

        internal readonly Dictionary<string, object> testResourceAttributes = new()
        {
            { "service.instance.id", "testInstance" },
            { "service.name", "testName" },
            { "service.namespace", "testNamespace" },
            { "service.version", "testVersion" },
        };

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
                        options.IncludeScopes = true;
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);

            List<KeyValuePair<string, object>> scope1 = new()
            {
                new("scopeKey1", "scopeValue1"),
                new("scopeKey1", "scopeValue2")
            };

            List<KeyValuePair<string, object>> scope2 = new()
            {
                new("scopeKey1", "scopeValue3")
            };

            using (logger.BeginScope(scope1))
            using (logger.BeginScope(scope2))
            {
                logger.Log(
                    logLevel: logLevel,
                    eventId: 1,
                    exception: null,
                    message: "Hello {name}.",
                    args: new object[] { "World" });
            }

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
                expectedMessageProperties: new Dictionary<string, string> { { "EventId", "1" }, { "name", "World" }, { "CategoryName", logCategoryName }, { "scopeKey1", "scopeValue1" } },
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
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
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
                    eventId: 1,
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
                expectedTypeName: "System.Exception",
                expectedProperties: new Dictionary<string, string> { { "EventId", "1" } });
        }

        [Fact]
        public void VerifyLogWithClientIPMapsToAiLocationIp()
        {
            // SETUP
            var uniqueTestId = Guid.NewGuid();
            var logCategoryName = $"logCategoryName{uniqueTestId}";
            List<TelemetryItem>? telemetryItems = null;

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddOpenTelemetry(options =>
                    {
                        options.SetResourceBuilder(ResourceBuilder.CreateDefault().AddAttributes(testResourceAttributes));
                        options.AddAzureMonitorLogExporterForTest(out telemetryItems);
                    });
            });

            // ACT
            var logger = loggerFactory.CreateLogger(logCategoryName);
            logger.LogInformation("Client IP: {microsoft.client.ip}", "1.2.3.4");

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems?.Where(x => x.Name == "Message").Single();

            TelemetryItemValidationHelper.AssertMessageTelemetry(
                telemetryItem: telemetryItem!,
                expectedSeverityLevel: "Information",
                expectedMessage: "Client IP: {microsoft.client.ip}",
                expectedMessageProperties: new Dictionary<string, string> { { "CategoryName", logCategoryName } },
                expectedSpanId: null,
                expectedTraceId: null,
                expectedClientIp: "1.2.3.4");
        }
    }
}