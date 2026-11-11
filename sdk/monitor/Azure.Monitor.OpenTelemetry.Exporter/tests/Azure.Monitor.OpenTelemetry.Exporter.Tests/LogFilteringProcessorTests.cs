// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
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
            activity.ActivityTraceFlags = ActivityTraceFlags.Recorded + 256; // Sampled + extra unused values in enum
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

        [Fact]
        public void LogFilteringProcessor_AddsSpanSampleRateToLogsInSampledSpan()
        {
            CaptureLogAttributes(new LogFilteringProcessor(new AttributeCaptureExporter(out var captured)), spanSampleRate: 25.0);

            Assert.Equal(25f, Assert.Single(captured).Single(kvp => kvp.Key == SemanticConventions.AttributeMicrosoftSampleRate).Value);
        }

        [Fact]
        public void LogFilteringProcessor_KeepsExistingLogAttributesWhenAddingSampleRate()
        {
            CaptureLogAttributes(new LogFilteringProcessor(new AttributeCaptureExporter(out var captured)), spanSampleRate: 25.0);

            var attributes = Assert.Single(captured);
            Assert.Contains(attributes, kvp => kvp.Key == "Name" && (string?)kvp.Value == "World");
            Assert.Contains(attributes, kvp => kvp.Key == "{OriginalFormat}");
        }

        [Fact]
        public void LogFilteringProcessor_UsesFallbackWhenSpanHasNoSampleRate()
        {
            CaptureLogAttributes(new LogFilteringProcessor(new AttributeCaptureExporter(out var captured), fallbackSampleRate: 50f), spanSampleRate: null);

            Assert.Equal(50f, Assert.Single(captured).Single(kvp => kvp.Key == SemanticConventions.AttributeMicrosoftSampleRate).Value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(100.0)]
        public void LogFilteringProcessor_AddsNoSampleRateWhenSpanIsNotSampledDown(object? spanSampleRate)
        {
            CaptureLogAttributes(new LogFilteringProcessor(new AttributeCaptureExporter(out var captured)), spanSampleRate);

            Assert.DoesNotContain(Assert.Single(captured), kvp => kvp.Key == SemanticConventions.AttributeMicrosoftSampleRate);
        }

        [Fact]
        public void LogFilteringProcessor_AddsNoSampleRateToLogsWithoutSpan()
        {
            var processor = new LogFilteringProcessor(new AttributeCaptureExporter(out var captured), fallbackSampleRate: 50f);

            using (var loggerFactory = CreateLoggerFactory(processor))
            {
                loggerFactory.CreateLogger<LogFilteringProcessorTests>().LogInformation("Hello {Name}", "World");
            }

            Assert.DoesNotContain(Assert.Single(captured), kvp => kvp.Key == SemanticConventions.AttributeMicrosoftSampleRate);
        }

        [Fact]
        public void LogFilteringProcessor_DoesNotReplaceSampleRateAlreadyOnLog()
        {
            var processor = new LogFilteringProcessor(new AttributeCaptureExporter(out var captured));

            using (var loggerFactory = CreateLoggerFactory(processor))
            {
                using var activity = StartSampledActivity(25.0);
                var state = new List<KeyValuePair<string, object?>> { new(SemanticConventions.AttributeMicrosoftSampleRate, 10.0) };
                loggerFactory.CreateLogger<LogFilteringProcessorTests>().Log(LogLevel.Information, default, state, null, (_, _) => "message");
            }

            var sampleRate = Assert.Single(Assert.Single(captured), kvp => kvp.Key == SemanticConventions.AttributeMicrosoftSampleRate);
            Assert.Equal(10.0, sampleRate.Value);
        }

        [Fact]
        public void LogEnvelopesInSampledSpanCarrySpanSampleRate()
        {
            var telemetryItems = new List<TelemetryItem>();
            var processor = new LogFilteringProcessor(new AzureMonitorLogExporter(new MockTransmitter(telemetryItems)));

            using (var loggerFactory = CreateLoggerFactory(processor))
            {
                var logger = loggerFactory.CreateLogger<LogFilteringProcessorTests>();

                using (var activity = StartSampledActivity(25.0))
                {
                    logger.LogInformation("Hello {Name}", "World");
                    logger.LogError(new InvalidOperationException("boom"), "Failed");
                    var eventState = new List<KeyValuePair<string, object?>> { new("microsoft.custom_event.name", "MyEvent") };
                    logger.Log(LogLevel.Information, default, eventState, null, (_, _) => "event");
                }

                logger.LogInformation("Outside any span");
            }

            var message = Assert.Single(telemetryItems, item => item.Name == "Message" && ((MessageData)item.Data.BaseData).Message.StartsWith("Hello", StringComparison.Ordinal));
            Assert.Equal(25f, message.SampleRate);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftSampleRate, ((MessageData)message.Data.BaseData).Properties.Keys);

            var exception = Assert.Single(telemetryItems, item => item.Name == "Exception");
            Assert.Equal(25f, exception.SampleRate);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftSampleRate, ((TelemetryExceptionData)exception.Data.BaseData).Properties.Keys);

            var customEvent = Assert.Single(telemetryItems, item => item.Name == "Event");
            Assert.Equal(25f, customEvent.SampleRate);
            Assert.DoesNotContain(SemanticConventions.AttributeMicrosoftSampleRate, ((TelemetryEventData)customEvent.Data.BaseData).Properties.Keys);

            var outside = Assert.Single(telemetryItems, item => item.Name == "Message" && ((MessageData)item.Data.BaseData).Message == "Outside any span");
            Assert.Null(outside.SampleRate);
        }

        [Fact]
        public void LogEnvelopesCarryNoSampleRateWithoutTraceBasedFiltering()
        {
            var telemetryItems = new List<TelemetryItem>();
            var processor = new AzureMonitorBatchLogRecordExportProcessor(new AzureMonitorLogExporter(new MockTransmitter(telemetryItems)));

            using (var loggerFactory = CreateLoggerFactory(processor))
            {
                using var activity = StartSampledActivity(25.0);
                loggerFactory.CreateLogger<LogFilteringProcessorTests>().LogInformation("Hello {Name}", "World");
            }

            Assert.Null(Assert.Single(telemetryItems).SampleRate);
        }

        private static void CaptureLogAttributes(LogFilteringProcessor processor, object? spanSampleRate)
        {
            using var loggerFactory = CreateLoggerFactory(processor);
            using (var activity = StartSampledActivity(spanSampleRate))
            {
                loggerFactory.CreateLogger<LogFilteringProcessorTests>().LogInformation("Hello {Name}", "World");
            }
        }

        private static ILoggerFactory CreateLoggerFactory(BaseProcessor<LogRecord> processor)
            => LoggerFactory.Create(builder => builder.AddOpenTelemetry(options => options.AddProcessor(processor)));

        private static Activity StartSampledActivity(object? sampleRate)
        {
            var activity = new Activity("SampledActivity");
            activity.ActivityTraceFlags = ActivityTraceFlags.Recorded;
            if (sampleRate != null)
            {
                activity.SetTag(SemanticConventions.AttributeMicrosoftSampleRate, sampleRate);
            }

            return activity.Start();
        }

        /// <summary>
        /// Copies each record's attributes during export, since the SDK recycles <see cref="LogRecord"/> instances afterwards.
        /// </summary>
        private sealed class AttributeCaptureExporter : BaseExporter<LogRecord>
        {
            private readonly List<List<KeyValuePair<string, object?>>> _captured;

            public AttributeCaptureExporter(out List<List<KeyValuePair<string, object?>>> captured)
            {
                _captured = captured = new List<List<KeyValuePair<string, object?>>>();
            }

            public override ExportResult Export(in Batch<LogRecord> batch)
            {
                foreach (var logRecord in batch)
                {
                    _captured.Add(logRecord.Attributes?.ToList() ?? new List<KeyValuePair<string, object?>>());
                }

                return ExportResult.Success;
            }
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
