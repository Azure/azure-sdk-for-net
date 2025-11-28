// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class LogFilteringProcessorTests
    {
        private readonly ITestOutputHelper output;

        public LogFilteringProcessorTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void LogFilteringProcessor_FiltersOutUnSampledLogsWithSpanId()
        {
            // Arrange
            var exportedItems = new List<LogRecord>();
            var testExporter = new TestExporter(exportedItems);
            var processor = new LogFilteringProcessor(testExporter);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddProcessor(processor);
                });
            });

            var logger = loggerFactory.CreateLogger<LogFilteringProcessorTests>();

            // Create an activity that is NOT sampled
            using var activity = new Activity("TestActivity");
            activity.ActivityTraceFlags = ActivityTraceFlags.None; // Not sampled
            activity.Start();

            // Act
            logger.LogInformation("This log should be filtered out");

            loggerFactory.Dispose();

            // Assert
            Assert.Empty(exportedItems);
        }

        [Fact]
        public void LogFilteringProcessor_AllowsSampledLogsWithSpanId()
        {
            // Arrange
            var exportedItems = new List<LogRecord>();
            var testExporter = new TestExporter(exportedItems);
            var processor = new LogFilteringProcessor(testExporter);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddProcessor(processor);
                });
            });

            var logger = loggerFactory.CreateLogger<LogFilteringProcessorTests>();

            // Create an activity that IS sampled
            using var activity = new Activity("TestActivity");
            activity.ActivityTraceFlags = ActivityTraceFlags.Recorded; // Sampled
            activity.Start();

            // Act
            logger.LogInformation("This log should be exported");

            loggerFactory.Dispose();

            // Assert
            Assert.Single(exportedItems);
        }

        [Fact]
        public void LogFilteringProcessor_AllowsLogsWithoutSpanId()
        {
            // Arrange
            var exportedItems = new List<LogRecord>();
            var testExporter = new TestExporter(exportedItems);
            var processor = new LogFilteringProcessor(testExporter);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddProcessor(processor);
                });
            });

            var logger = loggerFactory.CreateLogger<LogFilteringProcessorTests>();

            // Act - no activity context
            logger.LogInformation("This log should be exported");

            loggerFactory.Dispose();

            // Assert
            Assert.Single(exportedItems);
        }

        [Fact]
        public void LogFilteringProcessor_MixedScenario()
        {
            // Arrange
            var exportedItems = new List<LogRecord>();
            var testExporter = new TestExporter(exportedItems);
            var processor = new LogFilteringProcessor(testExporter);

            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.AddProcessor(processor);
                });
            });

            var logger = loggerFactory.CreateLogger<LogFilteringProcessorTests>();

            // Act
            // Log without activity - should be exported
            logger.LogInformation("Log 1: No activity");

            // Log with sampled activity - should be exported
            using (var sampledActivity = new Activity("SampledActivity"))
            {
                sampledActivity.ActivityTraceFlags = ActivityTraceFlags.Recorded;
                sampledActivity.Start();
                logger.LogInformation("Log 2: Sampled activity");
            }

            // Log with unsampled activity - should NOT be exported
            using (var unsampledActivity = new Activity("UnsampledActivity"))
            {
                unsampledActivity.ActivityTraceFlags = ActivityTraceFlags.None;
                unsampledActivity.Start();
                logger.LogInformation("Log 3: Unsampled activity");
            }

            // Log without activity again - should be exported
            logger.LogInformation("Log 4: No activity");

            loggerFactory.Dispose();

            // Assert
            Assert.Equal(3, exportedItems.Count);
        }

        private class TestExporter : BaseExporter<LogRecord>
        {
            private readonly List<LogRecord> exportedItems;

            public TestExporter(List<LogRecord> exportedItems)
            {
                this.exportedItems = exportedItems;
            }

            public override ExportResult Export(in Batch<LogRecord> batch)
            {
                foreach (var item in batch)
                {
                    this.exportedItems.Add(item);
                }

                return ExportResult.Success;
            }
        }
    }
}
