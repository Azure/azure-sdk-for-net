// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using Microsoft.Extensions.Logging;

using OpenTelemetry;
using OpenTelemetry.Logs;

using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class LogsHelperTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MessageIsSetToExceptionMessage(bool parseStateValues)
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeFormattedMessage = true;
                    options.ParseStateValues = parseStateValues;
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<LogsHelperTests>();
            string log = "Hello from {name} {price}.";
            try
            {
                throw new Exception("Test Exception");
            }
            catch (Exception ex)
            {
                logger.LogInformation(ex, log, "tomato", 2.99);
            }

            var properties = new ChangeTrackingDictionary<string, string>();
            var message = LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            Assert.Equal("Test Exception", message);

            if (parseStateValues)
            {
                Assert.True(properties.TryGetValue("OriginalFormat", out string value));
                Assert.Equal(log, value);
                Assert.True(properties.TryGetValue("name", out string name));
                Assert.Equal("tomato", name);
                Assert.True(properties.TryGetValue("price", out string price));
                Assert.Equal("2.99", price);
                Assert.Equal(3, properties.Count);
            }
            else
            {
                Assert.Empty(properties);
            }
        }

        [Fact]
        public void MessageIsSetToFormattedMessageWhenIncludeFormattedMessageIsSet()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeFormattedMessage = true;
                    options.ParseStateValues = true;
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<LogsHelperTests>();

            string log = "Hello from {name} {price}.";
            logger.LogInformation(log, "tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            var message = LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            Assert.Equal("Hello from tomato 2.99.", message);
            Assert.True(properties.TryGetValue("OriginalFormat", out string value));
            Assert.Equal(log, value);
            Assert.True(properties.TryGetValue("name", out string name));
            Assert.Equal("tomato", name);
            Assert.True(properties.TryGetValue("price", out string price));
            Assert.Equal("2.99", price);
            Assert.Equal(3, properties.Count);
        }

        [Fact]
        public void MessageIsSetToOriginalFormatWhenIncludeFormattedMessageIsNotSet()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.ParseStateValues = true;
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<LogsHelperTests>();

            string log = "Hello from {name} {price}.";
            logger.LogInformation(log, "tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            var message = LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            Assert.Equal(log, message);
            Assert.False(properties.ContainsKey("OriginalFormat"));
            Assert.True(properties.TryGetValue("name", out string name));
            Assert.Equal("tomato", name);
            Assert.True(properties.TryGetValue("price", out string price));
            Assert.Equal("2.99", price);
            Assert.Equal(2, properties.Count);
        }

        [Fact]
        public void PropertiesContainFieldsFromStructuredLogs()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.ParseStateValues = true;
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<LogsHelperTests>();

            string log = "Hello from {name} {price}.";
            logger.LogInformation(log, "tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            Assert.True(properties.TryGetValue("name", out string name));
            Assert.Equal("tomato", name);
            Assert.True(properties.TryGetValue("price", out string price));
            Assert.Equal("2.99", price);
            Assert.Equal(2, properties.Count);
        }

        [Fact]
        public void PropertiesContainFieldsFromStructuredLogsIfParseStateValuesIsSet()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.ParseStateValues = true;
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<LogsHelperTests>();

            logger.LogInformation("{Name} {Price}!", "Tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            Assert.True(properties.TryGetValue("Name", out string name));
            Assert.Equal("Tomato", name);
            Assert.True(properties.TryGetValue("Price", out string price));
            Assert.Equal("2.99", price);
            Assert.Equal(2, properties.Count);
        }

        [Fact]
        public void PropertiesContainEventIdAndEventNameIfSetOnLog()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.ParseStateValues = true;
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<LogsHelperTests>();

            EventId id = new EventId(1, "TestEvent");
            logger.LogInformation(id, "Log Information");

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            Assert.True(properties.TryGetValue("EventId", out string eventId));
            Assert.Equal("1", eventId);
            Assert.True(properties.TryGetValue("EventName", out string eventName));
            Assert.Equal("TestEvent", eventName);
            Assert.Equal(2, properties.Count);
        }

        [Fact]
        public void ValidateSeverityLevels()
        {
            Assert.Equal(SeverityLevel.Critical, LogsHelper.GetSeverityLevel(LogLevel.Critical));
            Assert.Equal(SeverityLevel.Error, LogsHelper.GetSeverityLevel(LogLevel.Error));
            Assert.Equal(SeverityLevel.Warning, LogsHelper.GetSeverityLevel(LogLevel.Warning));
            Assert.Equal(SeverityLevel.Information, LogsHelper.GetSeverityLevel(LogLevel.Information));
            Assert.Equal(SeverityLevel.Verbose, LogsHelper.GetSeverityLevel(LogLevel.Debug));
            Assert.Equal(SeverityLevel.Verbose, LogsHelper.GetSeverityLevel(LogLevel.Trace));
        }

        [Theory]
        [InlineData("ExceptionData")]
        [InlineData("MessageData")]
        public void ValidateTelemetryItem(string type)
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.ParseStateValues = true;
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<LogsHelperTests>();

            if (type == "MessageData")
            {
                logger.LogInformation("This is a test log");
            }
            else
            {
                logger.LogWarning(new Exception("Test Exception"), "Test Exception");
            }

            var logResource = new AzureMonitorResource()
            {
                RoleName = "roleName",
                RoleInstance = "roleInstance"
            };
            var telemetryItem = LogsHelper.OtelToAzureMonitorLogs(new Batch<LogRecord>(logRecords.ToArray(), logRecords.Count), logResource, "Ikey");

            Assert.Equal(type, telemetryItem[0].Data.BaseType);
            Assert.Equal("Ikey", telemetryItem[0].InstrumentationKey);
            Assert.Equal(logResource.RoleName, telemetryItem[0].Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal(logResource.RoleInstance, telemetryItem[0].Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);
        }
    }
}
