// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using Xunit;

using static Azure.Monitor.OpenTelemetry.Exporter.Internals.GenAI.MainAgentAttributeConstants;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class MainAgentAttributionLogProcessorTests
    {
        [Fact]
        public void OnEnd_NoCurrentActivity_DoesNotAddAttributes()
        {
            // Arrange
            var exportedItems = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddProcessor(new MainAgentAttributionLogProcessor());
                    options.AddProcessor(new InMemoryLogRecordProcessor(exportedItems));
                });
            });

            var logger = loggerFactory.CreateLogger<MainAgentAttributionLogProcessorTests>();

            // Act - no activity
            logger.LogInformation("Test log without activity");
            loggerFactory.Dispose();

            // Assert
            Assert.Single(exportedItems);
            var log = exportedItems[0];
            AssertDoesNotContainAttribute(log, MainAgentName);
        }

        [Fact]
        public void OnEnd_ActivityHasMainAgentAttrs_CopiedToLog()
        {
            // Arrange
            var exportedItems = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddProcessor(new MainAgentAttributionLogProcessor());
                    options.AddProcessor(new InMemoryLogRecordProcessor(exportedItems));
                });
            });

            var logger = loggerFactory.CreateLogger<MainAgentAttributionLogProcessorTests>();

            using var activity = new Activity("TestActivity");
            activity.SetTag(MainAgentName, "TestBot");
            activity.SetTag(MainAgentId, "bot-123");
            activity.SetTag(MainAgentVersion, "1.0");
            activity.SetTag(MainAgentConversationId, "conv-789");
            activity.Start();

            // Act
            logger.LogInformation("Test log with main agent");
            loggerFactory.Dispose();

            // Assert
            Assert.Single(exportedItems);
            var log = exportedItems[0];
            AssertContainsAttribute(log, MainAgentName, "TestBot");
            AssertContainsAttribute(log, MainAgentId, "bot-123");
            AssertContainsAttribute(log, MainAgentVersion, "1.0");
            AssertContainsAttribute(log, MainAgentConversationId, "conv-789");
        }

        [Fact]
        public void OnEnd_ActivityHasNoMainAgentAttrs_DoesNotModifyLog()
        {
            // Arrange
            var exportedItems = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddProcessor(new MainAgentAttributionLogProcessor());
                    options.AddProcessor(new InMemoryLogRecordProcessor(exportedItems));
                });
            });

            var logger = loggerFactory.CreateLogger<MainAgentAttributionLogProcessorTests>();

            using var activity = new Activity("TestActivity");
            activity.SetTag("some.other.tag", "value");
            activity.Start();

            // Act
            logger.LogInformation("Test log without main agent attrs");
            loggerFactory.Dispose();

            // Assert
            Assert.Single(exportedItems);
            var log = exportedItems[0];
            AssertDoesNotContainAttribute(log, MainAgentName);
            AssertDoesNotContainAttribute(log, MainAgentId);
        }

        [Fact]
        public void OnEnd_ActivityHasPartialMainAgentAttrs_CopiesOnlyPresent()
        {
            // Arrange
            var exportedItems = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddProcessor(new MainAgentAttributionLogProcessor());
                    options.AddProcessor(new InMemoryLogRecordProcessor(exportedItems));
                });
            });

            var logger = loggerFactory.CreateLogger<MainAgentAttributionLogProcessorTests>();

            using var activity = new Activity("TestActivity");
            activity.SetTag(MainAgentName, "PartialBot");
            // Only name set, no id/version/conversationId
            activity.Start();

            // Act
            logger.LogInformation("Test log with partial main agent attrs");
            loggerFactory.Dispose();

            // Assert
            Assert.Single(exportedItems);
            var log = exportedItems[0];
            AssertContainsAttribute(log, MainAgentName, "PartialBot");
            AssertDoesNotContainAttribute(log, MainAgentId);
            AssertDoesNotContainAttribute(log, MainAgentVersion);
            AssertDoesNotContainAttribute(log, MainAgentConversationId);
        }

        [Fact]
        public void OnEnd_LogAlreadyHasMainAgentAttrs_NoDuplicates()
        {
            // This test uses a custom processor that pre-sets a main_agent attribute
            // on the log record before MainAgentAttributionLogProcessor runs,
            // simulating a scenario where user code already attached the attribute.
            var exportedItems = new List<LogRecord>();
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddProcessor(new PreSetAttributeProcessor(MainAgentName, "UserSetBot"));
                    options.AddProcessor(new MainAgentAttributionLogProcessor());
                    options.AddProcessor(new InMemoryLogRecordProcessor(exportedItems));
                });
            });

            var logger = loggerFactory.CreateLogger<MainAgentAttributionLogProcessorTests>();

            using var activity = new Activity("TestActivity");
            activity.SetTag(MainAgentName, "ActivityBot");
            activity.SetTag(MainAgentId, "bot-999");
            activity.Start();

            // Act
            logger.LogInformation("Test log with pre-existing attrs");
            loggerFactory.Dispose();

            // Assert
            Assert.Single(exportedItems);
            var log = exportedItems[0];

            // Count occurrences of MainAgentName - should be exactly 1 (the pre-set value)
            int nameCount = 0;
            foreach (var kvp in log.Attributes!)
            {
                if (kvp.Key == MainAgentName)
                {
                    nameCount++;
                    Assert.Equal("UserSetBot", kvp.Value); // User's value preserved
                }
            }

            Assert.Equal(1, nameCount);

            // MainAgentId was NOT pre-set, so it should be added from the activity
            AssertContainsAttribute(log, MainAgentId, "bot-999");
        }

        private static void AssertContainsAttribute(LogRecord logRecord, string key, object expectedValue)
        {
            Assert.NotNull(logRecord.Attributes);
            foreach (var kvp in logRecord.Attributes!)
            {
                if (kvp.Key == key)
                {
                    Assert.Equal(expectedValue, kvp.Value);
                    return;
                }
            }

            Assert.Fail($"Expected attribute '{key}' not found in log record.");
        }

        private static void AssertDoesNotContainAttribute(LogRecord logRecord, string key)
        {
            if (logRecord.Attributes == null)
            {
                return;
            }

            foreach (var kvp in logRecord.Attributes)
            {
                Assert.NotEqual(key, kvp.Key);
            }
        }

        /// <summary>
        /// Simple in-memory processor that captures log records for test assertions.
        /// </summary>
        private class InMemoryLogRecordProcessor : BaseProcessor<LogRecord>
        {
            private readonly List<LogRecord> _exportedItems;

            public InMemoryLogRecordProcessor(List<LogRecord> exportedItems)
            {
                _exportedItems = exportedItems;
            }

            public override void OnEnd(LogRecord data)
            {
                // Snapshot attributes before the LogRecord may be recycled.
                var snapshot = new List<KeyValuePair<string, object?>>();
                if (data.Attributes != null)
                {
                    foreach (var kvp in data.Attributes)
                    {
                        snapshot.Add(kvp);
                    }
                }

                data.Attributes = snapshot;
                _exportedItems.Add(data);
            }
        }

        /// <summary>
        /// Processor that pre-sets an attribute on the log record to simulate
        /// user code or another processor having already added it.
        /// </summary>
        private class PreSetAttributeProcessor : BaseProcessor<LogRecord>
        {
            private readonly string _key;
            private readonly object _value;

            public PreSetAttributeProcessor(string key, object value)
            {
                _key = key;
                _value = value;
            }

            public override void OnEnd(LogRecord data)
            {
                var existing = data.Attributes;
                var merged = new List<KeyValuePair<string, object?>>((existing?.Count ?? 0) + 1);
                if (existing != null)
                {
                    merged.AddRange(existing);
                }

                merged.Add(new KeyValuePair<string, object?>(_key, _value));
                data.Attributes = merged;
            }
        }
    }
}
