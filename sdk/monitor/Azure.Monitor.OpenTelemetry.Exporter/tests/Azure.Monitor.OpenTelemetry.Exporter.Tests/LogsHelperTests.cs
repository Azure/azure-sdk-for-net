// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
            var message = LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            Assert.Equal("Test Exception", message);

            Assert.True(properties.TryGetValue("OriginalFormat", out string value));
            Assert.Equal(log, value);
            Assert.True(properties.TryGetValue("name", out string name));
            Assert.Equal("tomato", name);
            Assert.True(properties.TryGetValue("price", out string price));
            Assert.Equal("2.99", price);
            Assert.Equal(3, properties.Count);
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
            var message = LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            Assert.Equal("Hello from tomato 2.99.", message);
            Assert.True(properties.TryGetValue("name", out string name));
            Assert.Equal("tomato", name);
            Assert.True(properties.TryGetValue("price", out string price));
            Assert.Equal("2.99", price);
            Assert.Equal(2, properties.Count);
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
            Assert.Equal(2, properties.Count);
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
            LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            Assert.True(properties.TryGetValue("name", out string name));
            Assert.Equal("tomato", name);
            Assert.True(properties.TryGetValue("price", out string price));
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
            LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

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
            LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            if (scopeValue != null)
            {
                Assert.Single(properties); // Assert that there is exactly one property
                Assert.True(properties.TryGetValue(expectedScopeKey, out string actualScopeValue));
                Assert.Equal(scopeValue.ToString(), actualScopeValue);
            }
            else
            {
                Assert.Empty(properties); // Assert that properties are empty
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
            LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

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
            LogsHelper.GetMessageAndSetProperties(logRecords[0], properties);

            Assert.Equal(2, properties.Count);
            Assert.True(properties.TryGetValue(expectedScopeKey, out string actualScopeValue));
            Assert.Equal(expectedScopeValue, actualScopeValue);
            Assert.True(properties.TryGetValue("attributeKey", out string actualAttributeValue));
            Assert.Equal(expectedAttributeValue, actualAttributeValue);
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
