// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
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
            // ParseStateValues will be ignored unless the log contains an unknown objects.
            // https://github.com/open-telemetry/opentelemetry-dotnet/pull/4334

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

            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Test Exception", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            Assert.True(properties.TryGetValue("OriginalFormat", out string value));
            Assert.Equal(log, value);
            Assert.True(properties.TryGetValue("name", out string name));
            Assert.Equal("tomato", name);
            Assert.True(properties.TryGetValue("price", out string price));
            Assert.Equal("2.99", price);
            Assert.Equal(4, properties.Count);
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
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<LogsHelperTests>();

            string log = "Hello from {name} {price}.";
            logger.LogInformation(log, "tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Hello from tomato 2.99.", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);
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
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<LogsHelperTests>();

            string log = "Hello from {name} {price}.";
            logger.LogInformation(log, "tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal(log, message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);
            Assert.False(properties.ContainsKey("OriginalFormat"));
            Assert.True(properties.TryGetValue("name", out string name));
            Assert.Equal("tomato", name);
            Assert.True(properties.TryGetValue("price", out string price));
            Assert.Equal("2.99", price);
            Assert.Equal(3, properties.Count);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PropertiesContainFieldsFromStructuredLogs(bool parseStateValues)
        {
            var logRecords = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.ParseStateValues = parseStateValues;
                    options.AddInMemoryExporter(logRecords);
                });
                builder.AddFilter(typeof(LogsHelperTests).FullName, LogLevel.Trace);
            });

            var logger = loggerFactory.CreateLogger<LogsHelperTests>();

            string log = "Hello from {name} {price}.";
            logger.LogInformation(log, "tomato", 2.99);

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Hello from {name} {price}.", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            Assert.True(properties.TryGetValue("name", out string name));
            Assert.Equal("tomato", name);
            Assert.True(properties.TryGetValue("price", out string price));
            Assert.Equal("2.99", price);
            Assert.Equal(3, properties.Count);
        }

        [Fact]
        public void PropertiesContainEventIdAndEventNameIfSetOnLog()
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

            EventId id = new EventId(1, "TestEvent");
            logger.LogInformation(id, "Log Information");

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Log Information", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            Assert.True(properties.TryGetValue("EventId", out string eventId));
            Assert.Equal("1", eventId);
            Assert.True(properties.TryGetValue("EventName", out string eventNameProperty));
            Assert.Equal("TestEvent", eventNameProperty);
            Assert.Equal(3, properties.Count);
        }

        [Fact]
        public void PropertiesContainLoggerCategoryName()
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

            var categoryName = nameof(LogsHelperTests);
            var logger = loggerFactory.CreateLogger(categoryName);

            logger.LogInformation("Information goes here");

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Information goes here", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            Assert.True(properties.TryGetValue("CategoryName", out string loggedCategoryName));
            Assert.Equal(categoryName, loggedCategoryName);
            Assert.Single(properties);
        }

        [Fact]
        public void ExceptionPropertiesContainLoggerCategoryName()
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
            try
            {
                throw new Exception("Test Exception");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Here's an error");
            }

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Test Exception", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            Assert.True(properties.TryGetValue("CategoryName", out string categoryName));
            Assert.EndsWith(nameof(LogsHelperTests), categoryName);
        }

        [Fact]
        public void LogRecordAndAttributesContainEventIdAndEventName()
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

            EventId id = new EventId(1, "TestEvent");

            string log = "Log Information {EventId} {EventName}.";
            logger.LogInformation(id, log, 100, "TestAttributeEventName");

            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Log Information {EventId} {EventName}.", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            Assert.True(properties.TryGetValue("EventId", out string eventId));
            Assert.Equal("100", eventId);
            Assert.True(properties.TryGetValue("EventName", out string eventNameProperty));
            Assert.Equal("TestAttributeEventName", eventNameProperty);
            Assert.Equal(3, properties.Count);
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

            var logResource = new AzureMonitorResource(
                roleName: "testRoleName",
                roleInstance: "testRoleInstance",
                serviceVersion: null,
                monitorBaseData: null);
            (var telemetryItems, var telemetryCounter) = LogsHelper.OtelToAzureMonitorLogs(new Batch<LogRecord>(logRecords.ToArray(), logRecords.Count), logResource, "Ikey");

            Assert.Equal(type, telemetryItems[0].Data.BaseType);
            Assert.Equal("Ikey", telemetryItems[0].InstrumentationKey);
            Assert.Equal(logResource.RoleName, telemetryItems[0].Tags[ContextTagKeys.AiCloudRole.ToString()]);
            Assert.Equal(logResource.RoleInstance, telemetryItems[0].Tags[ContextTagKeys.AiCloudRoleInstance.ToString()]);

            // Validate TelemetryCounter
            if (type == "MessageData")
            {
                Assert.Equal(1, telemetryCounter._traceCount);
                Assert.Equal(0, telemetryCounter._exceptionCount);
            }
            else
            {
                Assert.Equal(1, telemetryCounter._exceptionCount);
                Assert.Equal(0, telemetryCounter._traceCount);
            }
            Assert.Equal(0, telemetryCounter._requestCount);
            Assert.Equal(0, telemetryCounter._dependencyCount);
            Assert.Equal(0, telemetryCounter._eventCount);
            Assert.Equal(0, telemetryCounter._metricCount);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ValidateScopeHandlingInLogProcessing(bool includeScope)
        {
            // Arrange.
            var logRecords = new List<LogRecord>(1);
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeScopes = includeScope;
                    options.AddInMemoryExporter(logRecords);
                });
            });

            var logger = loggerFactory.CreateLogger("Some category");

            const string expectedScopeKey = "Some scope key";
            const string expectedScopeValue = "Some scope value";

            // Act.
            using (logger.BeginScope(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(expectedScopeKey, expectedScopeValue),
            }))
            {
                logger.LogInformation("Some log information message.");
            }

            // Assert.
            var logRecord = logRecords.Single();
            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Some log information message.", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            if (includeScope)
            {
                Assert.True(properties.TryGetValue(expectedScopeKey, out string actualScopeValue));
                Assert.Equal(expectedScopeValue, actualScopeValue);
            }
            else
            {
                Assert.False(properties.TryGetValue(expectedScopeKey, out string actualScopeValue));
            }
        }

        [Theory]
        [InlineData("Some scope value")]
        [InlineData('a')]
        [InlineData(123)]
        [InlineData(12.34)]
        [InlineData(null)]
        public void VerifyHandlingOfVariousScopeDataTypes(object scopeValue)
        {
            // Arrange.
            var logRecords = new List<LogRecord>(1);
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeScopes = true;
                    options.AddInMemoryExporter(logRecords);
                });
            });

            var logger = loggerFactory.CreateLogger("Some category");

            const string expectedScopeKey = "Some scope key";

            // Act.
            using (logger.BeginScope(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(expectedScopeKey, scopeValue),
            }))
            {
                logger.LogInformation("Some log information message.");
            }

            // Assert.
            var logRecord = logRecords.Single();
            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Some log information message.", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            if (scopeValue != null)
            {
                Assert.Equal(2, properties.Count); // Scope property + CategoryName
                Assert.True(properties.TryGetValue(expectedScopeKey, out string actualScopeValue));
                Assert.Equal(scopeValue.ToString(), actualScopeValue);
            }
            else
            {
                Assert.Single(properties); // Single property expected (CategoryName)
            }
        }

        [Fact]
        public void LogScope_WhenToStringOnCustomObjectThrows_ShouldStillProcessValidScopeItems()
        {
            // Arrange.
            var logRecords = new List<LogRecord>(1);
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeScopes = true;
                    options.IncludeFormattedMessage = true;
                    options.AddInMemoryExporter(logRecords);
                });
            });

            var logger = loggerFactory.CreateLogger("Some category");

            const string expectedScopeKey = "Some scope key";
            const string validScopeKey = "Valid key";
            const string validScopeValue = "Valid value";

            // Act.
            using (logger.BeginScope(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(expectedScopeKey, new CustomObject()),
                new KeyValuePair<string, object>(validScopeKey, validScopeValue),
            }))
            {
                logger.LogInformation("Some log information message.");
            }

            // Assert.
            var logRecord = logRecords.Single();
            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Some log information message.", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            Assert.False(properties.ContainsKey(expectedScopeKey), "Properties should not contain the key of the CustomObject that threw an exception");
            Assert.True(properties.ContainsKey(validScopeKey), "Properties should contain the key of the valid scope item.");
            Assert.Equal(validScopeValue, properties[validScopeKey]);
            Assert.Equal("Some log information message.", logRecords[0].FormattedMessage);
        }

        [Fact]
        public void DuplicateKeysInLogRecordAttributesAndLogScope()
        {
            // Arrange.
            var logRecords = new List<LogRecord>(1);
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeScopes = true;
                    options.AddInMemoryExporter(logRecords);
                });
            });

            var logger = loggerFactory.CreateLogger("Some category");

            const string expectedScopeKey = "Some scope key";
            const string expectedScopeValue = "Some scope value";
            const string duplicateScopeValue = "Some duplicate scope value";

            const string expectedAttributeValue = "Some attribute value";
            const string duplicateAttributeValue = "Some duplicate attribute value";

            // Act.
            using (logger.BeginScope(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(expectedScopeKey, expectedScopeValue),
                new KeyValuePair<string, object>(expectedScopeKey, duplicateScopeValue),
            }))
            {
                logger.LogInformation("Some log information message. {attributeKey} {attributeKey}.", expectedAttributeValue, duplicateAttributeValue);
            }

            // Assert.
            var logRecord = logRecords.Single();
            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Some log information message. {attributeKey} {attributeKey}.", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            Assert.Equal(3, properties.Count);
            Assert.True(properties.TryGetValue(expectedScopeKey, out string actualScopeValue));
            Assert.Equal(expectedScopeValue, actualScopeValue);
            Assert.True(properties.TryGetValue("attributeKey", out string actualAttributeValue));
            Assert.Equal(expectedAttributeValue, actualAttributeValue);
        }

        [Fact]
        public void DuplicateKeysInLogRecordAttributesAndLogScope2()
        {
            // Arrange.
            var logRecords = new List<LogRecord>(1);
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeScopes = true;
                    options.AddInMemoryExporter(logRecords);
                });
            });

            var logger = loggerFactory.CreateLogger("Some category");

            const string expectedScopeKey = "Some scope key";
            const string expectedScopeValue = "Some scope value";
            const string duplicateScopeValue = "Some duplicate scope value";
            const string duplicateScopeValue2 = "Another duplicate scope value";

            // Act.
            using (logger.BeginScope(new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>(expectedScopeKey, expectedScopeValue),
                new KeyValuePair<string, object>(expectedScopeKey, duplicateScopeValue),
            }))
            {
                logger.LogInformation($"Some log information message. {{{expectedScopeKey}}}.", duplicateScopeValue2);
            }

            // Assert.
            var logRecord = logRecords.Single();
            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("Some log information message. {Some scope key}.", message);
            Assert.Null(eventName);
            Assert.Null(clientAddress);

            Assert.Equal(2, properties.Count);
            Assert.True(properties.TryGetValue(expectedScopeKey, out string actualScopeValue));
            Assert.Equal(duplicateScopeValue2, actualScopeValue);
        }

        [Fact]
        public void VerifyEventName()
        {
            // Arrange.
            var logRecords = new List<LogRecord>(1);
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
            });

            var logger = loggerFactory.CreateLogger("Some category");
            logger.LogInformation("{microsoft.custom_event.name}", "MyCustomEventName");

            // Assert.
            var logRecord = logRecords.Single();
            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("MyCustomEventName", eventName);
            Assert.Null(clientAddress);
        }

        [Fact]
        public void VerifyEventName_UsingLoggerExtensions()
        {
            // Arrange.
            var logRecords = new List<LogRecord>(1);
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
            });

            var logger = loggerFactory.CreateLogger("Some category");
            logger.WriteSimpleCustomEvent("MyCustomEventName");

            // Assert.
            var logRecord = logRecords.Single();
            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientAddress);

            Assert.Equal("MyCustomEventName", eventName);
            Assert.Null(clientAddress);
        }

        [Fact]
        public void VerifyClientIP()
        {
            // Arrange.
            var logRecords = new List<LogRecord>(1);
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddInMemoryExporter(logRecords);
                });
            });

            var logger = loggerFactory.CreateLogger("Some category");
            logger.LogInformation("{microsoft.client.ip}", "1.2.3.4");

            // Assert.
            var logRecord = logRecords.Single();
            var properties = new ChangeTrackingDictionary<string, string>();
            LogsHelper.ProcessLogRecordProperties(logRecords[0], properties, out var message, out var eventName, out var clientIP);

            Assert.Equal("1.2.3.4", clientIP);
            Assert.Null(eventName);
        }

        private class CustomObject
        {
            public override string ToString()
            {
                throw new InvalidOperationException("Custom exception in ToString method");
            }
        }
    }
}
