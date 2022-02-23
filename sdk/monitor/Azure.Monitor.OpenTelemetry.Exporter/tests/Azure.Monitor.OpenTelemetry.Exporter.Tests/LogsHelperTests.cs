// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class LogsHelperTests
    {
        private readonly ILogger _logger;
        private readonly ILoggerFactory loggerFactory;
        private readonly TestLogProcessor _processor;
        private OpenTelemetryLoggerOptions _options;

        public LogsHelperTests()
        {
            _processor = new TestLogProcessor();
            loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    _options = options;
                    _options.AddProcessor(_processor);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            _logger = loggerFactory.CreateLogger<LogsHelperTests>();
        }

        [Fact]
        public void MessageIsSetToFormattedMessageWhenIncludeFormattedMessageIsSet()
        {
            _options.IncludeFormattedMessage = true;
            string log = "Hello from {name} {price}.";
            _logger.LogInformation(log, "tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            var message = LogsHelper.GetMessageAndSetProperties(_processor.processedItems[0], properties);

            Assert.Equal("Hello from tomato 2.99.", message);
            Assert.True(properties.TryGetValue("OriginalFormat", out string value));
            Assert.Equal(log, value);
        }

        [Fact]
        public void MessageIsSetToOriginalFormatWhenIncludeFormattedMessageIsNotSet()
        {
            string log = "Hello from {name} {price}.";
            _logger.LogInformation(log, "tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            var message = LogsHelper.GetMessageAndSetProperties(_processor.processedItems[0], properties);

            Assert.Equal(log, message);
            Assert.False(properties.ContainsKey("OriginalFormat"));
        }

        [Fact]
        public void PropertiesContainFieldsFromStructuredLogs()
        {
            string log = "Hello from {name} {price}.";
            _logger.LogInformation(log, "tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.GetMessageAndSetProperties(_processor.processedItems[0], properties);

            Assert.True(properties.TryGetValue("name", out string name));
            Assert.Equal("tomato", name);
            Assert.True(properties.TryGetValue("price", out string price));
            Assert.Equal("2.99", price);
        }

        [Fact]
        public void PropertiesContainFieldsFromStructuredLogsIfStateValuesIsSet()
        {
            _options.ParseStateValues = true;
            _logger.LogInformation("{Name} {Price}!", "Tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.GetMessageAndSetProperties(_processor.processedItems[0], properties);

            Assert.True(properties.TryGetValue("Name", out string name));
            Assert.Equal("Tomato", name);
            Assert.True(properties.TryGetValue("Price", out string price));
            Assert.Equal("2.99", price);
        }

        [Fact]
        public void PropertiesContainEventIdAndEventNameIfSetOnLog()
        {
            EventId id = new EventId(1, "TestEvent");
            _logger.LogInformation(id, "Log Information");

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.GetMessageAndSetProperties(_processor.processedItems[0], properties);

            Assert.True(properties.TryGetValue("EventId", out string eventId));
            Assert.Equal("1", eventId);
            Assert.True(properties.TryGetValue("EventName", out string eventName));
            Assert.Equal("TestEvent", eventName);
        }

        internal class TestLogProcessor : BaseProcessor<LogRecord>
        {
            public readonly LogRecord[] processedItems = new LogRecord[5];
            private int _index;
            public override void OnEnd(LogRecord data)
            {
                if (_index == processedItems.Length)
                {
                    return;
                }

                processedItems[_index] = data;
                _index++;
            }
        }
    }
}
