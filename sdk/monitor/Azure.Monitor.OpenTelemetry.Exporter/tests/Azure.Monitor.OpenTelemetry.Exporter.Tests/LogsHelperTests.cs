// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Microsoft.Extensions.Logging;
using OpenTelemetry.Logs;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class LogsHelperTests
    {
        [Fact]
        public void MessageIsSetToFormattedMessageWhenIncludeFormattedMessageIsSet()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeFormattedMessage = true;
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
        }

        [Fact]
        public void MessageIsSetToOriginalFormatWhenIncludeFormattedMessageIsNotSet()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
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
        }

        [Fact]
        public void PropertiesContainFieldsFromStructuredLogs()
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
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
        }
    }
}
