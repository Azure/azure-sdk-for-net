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
                // Copy attributes since they may be recycled
                var attributes = new List<KeyValuePair<string, object?>>();
                if (data.Attributes != null)
                {
                    foreach (var kvp in data.Attributes)
                    {
                        attributes.Add(kvp);
                    }
                }

                _exportedItems.Add(data);
            }
        }
    }
}
