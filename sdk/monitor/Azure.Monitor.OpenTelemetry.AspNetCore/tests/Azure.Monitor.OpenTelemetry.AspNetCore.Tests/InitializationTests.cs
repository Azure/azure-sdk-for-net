// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using OpenTelemetry.Logs;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    /// <summary>
    /// These tests evaluate the initialization of AzureMonitor Distro and Exporter.
    /// </summary>
    public class InitializationTests
    {
        private const string TestConnectionString = $"InstrumentationKey=unitTest";
        private const string TestConnectionString2 = $"InstrumentationKey=unitTest-2";

        [Fact]
        public async Task VerifyCannotCallUseAzureMonitorTwice()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor()
                .UseAzureMonitor();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            await Assert.ThrowsAsync<NotSupportedException>(async () => await StartHostedServicesAsync(serviceProvider));
        }

        [Fact]
        public async Task VerifyCannotCallUseAzureMonitorExporterTwice()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitorExporter()
                .UseAzureMonitorExporter();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            await Assert.ThrowsAsync<NotSupportedException>(async () => await StartHostedServicesAsync(serviceProvider));
        }

        [Fact]
        public async Task VerifyCannotCallUseAzureMonitorExporterAndUseAzureMonitor()
        {
            var serviceCollection = new ServiceCollection();
            var openTelemetryBuilder = serviceCollection.AddOpenTelemetry();

            openTelemetryBuilder.UseAzureMonitor();
            openTelemetryBuilder.UseAzureMonitorExporter();

            using var serviceProvider = serviceCollection.BuildServiceProvider();

            await Assert.ThrowsAsync<NotSupportedException>(async () => await StartHostedServicesAsync(serviceProvider));
        }

        [Fact]
        public async Task VerifyCanCallAddAzureMonitorTraceExporterTwice()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOpenTelemetry()
                .WithTracing(builder => builder
                    .AddAzureMonitorTraceExporter(x => x.ConnectionString = TestConnectionString)
                    .AddAzureMonitorTraceExporter(x => x.ConnectionString = TestConnectionString2));

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            await StartHostedServicesAsync(serviceProvider);
        }

        [Fact]
        public async Task VerifyCanCallAddAzureMonitorMetricExporterTwice()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOpenTelemetry()
                .WithMetrics(builder => builder
                    .AddAzureMonitorMetricExporter(x => x.ConnectionString = TestConnectionString)
                    .AddAzureMonitorMetricExporter(x => x.ConnectionString = TestConnectionString2));

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            await StartHostedServicesAsync(serviceProvider);
        }

        [Fact]
        public async Task VerifyCanCallAddAzureMonitorLogExporterTwice()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOpenTelemetry()
                .WithLogging(builder => builder
                    .AddAzureMonitorLogExporter(x => x.ConnectionString = TestConnectionString)
                    .AddAzureMonitorLogExporter(x => x.ConnectionString = TestConnectionString2));

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            await StartHostedServicesAsync(serviceProvider);
        }

        [Fact]
        public async Task VerifyCannotAddExportersAndUseAzureMonitor()
        {
            // Traces
            var serviceCollection1 = new ServiceCollection();
            serviceCollection1.AddOpenTelemetry()
                .WithTracing(builder => builder
                    .AddAzureMonitorTraceExporter(x => x.ConnectionString = TestConnectionString))
                .UseAzureMonitor(x => x.ConnectionString = TestConnectionString2);

            using var serviceProvider1 = serviceCollection1.BuildServiceProvider();
            await Assert.ThrowsAsync<NotSupportedException>(async () => await StartHostedServicesAsync(serviceProvider1));

            // Metrics
            var serviceCollection2 = new ServiceCollection();
            serviceCollection2.AddOpenTelemetry()
                .WithMetrics(builder => builder
                    .AddAzureMonitorMetricExporter(x => x.ConnectionString = TestConnectionString))
                .UseAzureMonitor(x => x.ConnectionString = TestConnectionString2);

            using var serviceProvider2 = serviceCollection2.BuildServiceProvider();
            await Assert.ThrowsAsync<NotSupportedException>(async () => await StartHostedServicesAsync(serviceProvider2));

            // Logs
            var serviceCollection3 = new ServiceCollection();
            serviceCollection3.AddOpenTelemetry()
                .WithLogging(builder => builder
                    .AddAzureMonitorLogExporter(x => x.ConnectionString = TestConnectionString))
                .UseAzureMonitor(x => x.ConnectionString = TestConnectionString2);

            using var serviceProvider3 = serviceCollection3.BuildServiceProvider();
            await Assert.ThrowsAsync<NotSupportedException>(async () => await StartHostedServicesAsync(serviceProvider3));
        }

        [Fact]
        public async Task VerifyCannotAddExporterAndUseAzureMonitorExporter()
        {
            // Traces
            var serviceCollection1 = new ServiceCollection();
            serviceCollection1.AddOpenTelemetry()
                .WithTracing(builder => builder
                    .AddAzureMonitorTraceExporter(x => x.ConnectionString = TestConnectionString))
                .UseAzureMonitorExporter(x => x.ConnectionString = TestConnectionString2);

            using var serviceProvider1 = serviceCollection1.BuildServiceProvider();
            await Assert.ThrowsAsync<NotSupportedException>(async () => await StartHostedServicesAsync(serviceProvider1));

            // Metrics
            var serviceCollection2 = new ServiceCollection();
            serviceCollection2.AddOpenTelemetry()
                .WithMetrics(builder => builder
                    .AddAzureMonitorMetricExporter(x => x.ConnectionString = TestConnectionString))
                .UseAzureMonitorExporter(x => x.ConnectionString = TestConnectionString2);

            using var serviceProvider2 = serviceCollection2.BuildServiceProvider();
            await Assert.ThrowsAsync<NotSupportedException>(async () => await StartHostedServicesAsync(serviceProvider2));

            // Logs
            var serviceCollection3 = new ServiceCollection();
            serviceCollection3.AddOpenTelemetry()
                .WithLogging(builder => builder
                    .AddAzureMonitorLogExporter(x => x.ConnectionString = TestConnectionString))
                .UseAzureMonitorExporter(x => x.ConnectionString = TestConnectionString2);

            using var serviceProvider3 = serviceCollection1.BuildServiceProvider();
            await Assert.ThrowsAsync<NotSupportedException>(async () => await StartHostedServicesAsync(serviceProvider3));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task VerifyUseAzureMonitor(bool enableLiveMetrics)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor(options => {
                    options.ConnectionString = TestConnectionString;
                    options.EnableLiveMetrics = enableLiveMetrics;
                });

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            await StartHostedServicesAsync(serviceProvider);

            EvaluationHelper.EvaluateTracerProvider(
                serviceProvider: serviceProvider,
                expectedAzureMonitorTraceExporter: true,
                expectedLiveMetricsProcessor: enableLiveMetrics,
                expectedProfilingSessionTraceProcessor: true,
                expectedStandardMetricsExtractionProcessor: true);

            EvaluationHelper.EvaluateMeterProvider(serviceProvider);

            EvaluationHelper.EvaluateLoggerProvider(serviceProvider, enableLiveMetrics);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task VerifyUseAzureMonitorExporter(bool enableLiveMetrics)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitorExporter(options => {
                    options.ConnectionString = TestConnectionString;
                    options.EnableLiveMetrics = enableLiveMetrics;
                });

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            await StartHostedServicesAsync(serviceProvider);

            EvaluationHelper.EvaluateTracerProvider(
                serviceProvider: serviceProvider,
                expectedAzureMonitorTraceExporter: true,
                expectedLiveMetricsProcessor: enableLiveMetrics,
                expectedProfilingSessionTraceProcessor: false,
                expectedStandardMetricsExtractionProcessor: true);

            EvaluationHelper.EvaluateMeterProvider(serviceProvider);

            EvaluationHelper.EvaluateLoggerProvider(serviceProvider, enableLiveMetrics);
        }

        private static async Task StartHostedServicesAsync(ServiceProvider serviceProvider)
        {
            var hostedServices = serviceProvider.GetServices<IHostedService>();
            foreach (var hostedService in hostedServices)
            {
                await hostedService.StartAsync(CancellationToken.None);
            }
        }

        private class EvaluationHelper()
        {
            private class TracerProviderVariables
            {
                public bool foundProfilingSessionTraceProcessor;
                public bool foundAzureMonitorTraceExporter;
                public bool foundLiveMetricsProcessor;
                public bool foundStandardMetricsExtractionProcessor;
            }

            public static void EvaluateTracerProvider(IServiceProvider serviceProvider, bool expectedAzureMonitorTraceExporter, bool expectedLiveMetricsProcessor, bool expectedProfilingSessionTraceProcessor, bool expectedStandardMetricsExtractionProcessor)
            {
                var tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();
                Assert.NotNull(tracerProvider);

                // Get TracerProviderSdk
                var tracerProviderSdkType = tracerProvider.GetType();
                var processorProperty = tracerProviderSdkType.GetProperty("Processor", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.NotNull(processorProperty);

                var processor = processorProperty.GetValue(tracerProvider);
                Assert.NotNull(processor);

                // Start walking the CompositeProcessor
                var variables = new TracerProviderVariables();
                WalkCompositeProcessor(processor, variables);
                Assert.Equal(expectedLiveMetricsProcessor, variables.foundLiveMetricsProcessor);
                Assert.Equal(expectedStandardMetricsExtractionProcessor, variables.foundStandardMetricsExtractionProcessor);
                Assert.Equal(expectedAzureMonitorTraceExporter, variables.foundAzureMonitorTraceExporter);
                Assert.Equal(expectedProfilingSessionTraceProcessor, variables.foundProfilingSessionTraceProcessor);

                // Validate Sampler
                var samplerProperty = tracerProviderSdkType.GetProperty("Sampler", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.NotNull(samplerProperty);
                var sampler = samplerProperty.GetValue(tracerProvider);
                Assert.NotNull(sampler);
                Assert.Equal(nameof(Exporter.Internals.ApplicationInsightsSampler), sampler.GetType().Name);

                // TODO: INSPECT INSTRUMENTATIONS
            }

            public static void EvaluateMeterProvider(IServiceProvider serviceProvider)
            {
                var meterProvider = serviceProvider.GetRequiredService<MeterProvider>();
                Assert.NotNull(meterProvider);

                // Get the Reader property (private) from MeterProviderSdk
                var readerProperty = meterProvider.GetType().GetProperty("Reader", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.NotNull(readerProperty);

                var reader = readerProperty.GetValue(meterProvider);
                Assert.NotNull(reader);

                // Get the Exporter property (private) from PeriodicExportingMetricReader
                var exporterProperty = reader.GetType().GetProperty("Exporter", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.NotNull(exporterProperty);

                var exporter = exporterProperty.GetValue(reader);
                Assert.NotNull(exporter);

                // Assert Exporter is of type AzureMonitorMetricExporter
                Assert.Equal(nameof(AzureMonitorMetricExporter), exporter.GetType().Name);
            }

            public static void EvaluateLoggerProvider(IServiceProvider serviceProvider, bool liveMetricsEnabled = false)
            {
                var loggerProvider = serviceProvider.GetService<LoggerProvider>();
                Assert.NotNull(loggerProvider);

                // Get the 'Processor' property from LoggerProvider
                var processorProperty = loggerProvider.GetType().GetProperty("Processor", BindingFlags.Public | BindingFlags.Instance);
                Assert.NotNull(processorProperty);

                var processor = processorProperty.GetValue(loggerProvider);
                Assert.NotNull(processor);

                if (liveMetricsEnabled)
                {
                    // When LiveMetrics is enabled, processor should be a CompositeProcessor
                    Assert.Contains("CompositeProcessor", processor.GetType().Name);

                    // Get the processors from the CompositeProcessor
                    var headField = processor.GetType().GetField("Head", BindingFlags.NonPublic | BindingFlags.Instance);
                    Assert.NotNull(headField);

                    var currentNode = headField.GetValue(processor);
                    Assert.NotNull(currentNode);

                    var nodeType = currentNode.GetType();
                    var valueField = nodeType.GetField("Value", BindingFlags.Public | BindingFlags.Instance);
                    var nextProperty = nodeType.GetProperty("Next", BindingFlags.Public | BindingFlags.Instance);

                    // Find the BatchLogRecordExportProcessor in the CompositeProcessor
                    bool foundBatchProcessor = false;
                    bool foundLiveMetricsProcessor = false;

                    while (currentNode != null)
                    {
                        var processorValue = valueField!.GetValue(currentNode);
                        if (processorValue != null)
                        {
                            var processorType = processorValue.GetType();

                            if (processorType.Name.Contains("BatchLogRecordExportProcessor"))
                            {
                                foundBatchProcessor = true;

                                // Verify the exporter type
                                var exporterProperty = processorType.GetProperty("Exporter", BindingFlags.NonPublic | BindingFlags.Instance);
                                Assert.NotNull(exporterProperty);

                                var exporter = exporterProperty.GetValue(processorValue);
                                Assert.NotNull(exporter);
                                Assert.Contains("AzureMonitorLogExporter", exporter.GetType().Name);
                            }
                            else if (processorType.Name.Contains("LiveMetricsLogProcessor"))
                            {
                                foundLiveMetricsProcessor = true;
                            }
                        }

                        currentNode = nextProperty!.GetValue(currentNode);
                    }

                    Assert.True(foundBatchProcessor, "BatchLogRecordExportProcessor not found in CompositeProcessor");
                    Assert.True(foundLiveMetricsProcessor, "LiveMetricsLogProcessor not found in CompositeProcessor");
                }
                else
                {
                    // When LiveMetrics is disabled, processor should be a BatchLogRecordExportProcessor
                    Assert.Contains("BatchLogRecordExportProcessor", processor.GetType().Name);

                    // Get the 'Exporter' property from the processor
                    var exporterProperty = processor.GetType().GetProperty("Exporter", BindingFlags.NonPublic | BindingFlags.Instance);
                    Assert.NotNull(exporterProperty);

                    var exporter = exporterProperty.GetValue(processor);
                    Assert.NotNull(exporter);

                    // Ensure it's an AzureMonitorLogExporter
                    Assert.Contains("AzureMonitorLogExporter", exporter.GetType().Name);
                }
            }

            private static void WalkCompositeProcessor(object compositeProcessor, TracerProviderVariables variables)
            {
                var compositeProcessorType = compositeProcessor.GetType();

                var headField = compositeProcessorType.GetField("Head", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.NotNull(headField);

                var currentNode = headField.GetValue(compositeProcessor);
                Assert.NotNull(currentNode);

                var nodeType = currentNode.GetType();
                var valueField = nodeType.GetField("Value", BindingFlags.Public | BindingFlags.Instance);
                var nextProperty = nodeType.GetProperty("Next", BindingFlags.Public | BindingFlags.Instance);

                while (currentNode != null)
                {
                    var processorValue = valueField!.GetValue(currentNode);
                    if (processorValue != null)
                    {
                        var processorType = processorValue.GetType();

                        if (processorType.Name.Contains(nameof(Internals.Profiling.ProfilingSessionTraceProcessor)))
                        {
                            variables.foundProfilingSessionTraceProcessor = true;
                        }
                        else if (processorType.Name.Contains(nameof(LiveMetrics.LiveMetricsActivityProcessor)))
                        {
                            variables.foundLiveMetricsProcessor = true;
                        }
                        else if (processorType.Name.Contains(nameof(Exporter.Internals.StandardMetricsExtractionProcessor)))
                        {
                            variables.foundStandardMetricsExtractionProcessor = true;
                        }
                        else if (processorType.Name.Contains("BatchActivityExportProcessor"))
                        {
                            var exporterField = processorType.GetField("exporter", BindingFlags.NonPublic | BindingFlags.Instance);
                            Assert.NotNull(exporterField);

                            var exporter = exporterField.GetValue(processorValue);
                            Assert.NotNull(exporter);

                            if (exporter is AzureMonitorTraceExporter)
                            {
                                variables.foundAzureMonitorTraceExporter = true;
                            }
                        }
                        else if (processorType.Name.Contains("CompositeProcessor"))
                        {
                            // Recursive step: walk inner CompositeProcessor
                            WalkCompositeProcessor(processorValue, variables);
                        }
                    }

                    currentNode = nextProperty!.GetValue(currentNode);
                }
            }
        }
    }
}
