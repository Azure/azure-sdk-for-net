// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
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

        [Fact]
        public void VerifyContextTagAttributes_MappedToEnvelopeTags()
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
            logger.LogInformation(
                "{user_agent.original} {microsoft.session.id} {ai.device.id} {ai.device.model} {ai.device.type} {ai.device.osVersion} {microsoft.synthetic_source} {microsoft.user.account_id}",
                "TestAgent/1.0", "session-123", "device-456", "Surface Pro", "PC", "Microsoft Windows NT 10.0.22621.0", "test-bot", "account-789");

            // CLEANUP
            loggerFactory.Dispose();

            // ASSERT
            Assert.True(telemetryItems?.Any(), "Unit test failed to collect telemetry.");
            this.telemetryOutput.Write(telemetryItems);
            var telemetryItem = telemetryItems!.First(x => x.Name == "Message");

            // Verify context tags are mapped to envelope tags
            Assert.Equal("TestAgent/1.0", telemetryItem.Tags["ai.user.userAgent"]);
            Assert.Equal("session-123", telemetryItem.Tags[ContextTagKeys.AiSessionId.ToString()]);
            Assert.Equal("device-456", telemetryItem.Tags[ContextTagKeys.AiDeviceId.ToString()]);
            Assert.Equal("Surface Pro", telemetryItem.Tags[ContextTagKeys.AiDeviceModel.ToString()]);
            Assert.Equal("PC", telemetryItem.Tags[ContextTagKeys.AiDeviceType.ToString()]);
            Assert.Equal("Microsoft Windows NT 10.0.22621.0", telemetryItem.Tags[ContextTagKeys.AiDeviceOSVersion.ToString()]);
            Assert.Equal("test-bot", telemetryItem.Tags[ContextTagKeys.AiOperationSyntheticSource.ToString()]);
            Assert.Equal("account-789", telemetryItem.Tags[ContextTagKeys.AiUserAccountId.ToString()]);

            // Verify context tags are NOT in customDimensions
            var messageData = (MessageData)telemetryItem.Data.BaseData;
            Assert.False(messageData.Properties.ContainsKey("user_agent.original"));
            Assert.False(messageData.Properties.ContainsKey("microsoft.session.id"));
            Assert.False(messageData.Properties.ContainsKey("ai.device.id"));
            Assert.False(messageData.Properties.ContainsKey("ai.device.model"));
            Assert.False(messageData.Properties.ContainsKey("ai.device.type"));
            Assert.False(messageData.Properties.ContainsKey("ai.device.osVersion"));
            Assert.False(messageData.Properties.ContainsKey("microsoft.synthetic_source"));
            Assert.False(messageData.Properties.ContainsKey("microsoft.user.account_id"));
        }
    }
}