// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Platform;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using OpenTelemetry.Logs;
using Xunit;
using System.Linq;

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
                expectedLiveMetricsProcessor: enableLiveMetrics,
                expectedProfilingSessionTraceProcessor: true,
                hasInstrumentations: true);

            EvaluationHelper.EvaluateMeterProvider(serviceProvider);

            EvaluationHelper.EvaluateLoggerProvider(serviceProvider, enableLiveMetrics);
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(false, false)]
        public async Task VerifySamplingOptions(bool isRateLimitedSampler, bool useExporter)
        {
            var serviceCollection = new ServiceCollection();
            if (useExporter)
            {
                serviceCollection.AddOpenTelemetry()
                .UseAzureMonitorExporter(options =>
                {
                    options.ConnectionString = TestConnectionString;
                    options.TracesPerSecond = isRateLimitedSampler ? 10 : null;
                });
            }
            else // use distro
            {
                serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor(options => {
                    options.ConnectionString = TestConnectionString;
                    options.TracesPerSecond = isRateLimitedSampler ? 10 : null;
                });
            }

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            await StartHostedServicesAsync(serviceProvider);

            EvaluationHelper.EvaluateTracerProviderSampler(serviceProvider, isRateLimitedSampler);
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
                expectedLiveMetricsProcessor: enableLiveMetrics,
                expectedProfilingSessionTraceProcessor: false,
                hasInstrumentations: false);

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
                public bool foundMainAgentAttributionSpanProcessor;
            }

            public static void EvaluateTracerProvider(IServiceProvider serviceProvider, bool expectedLiveMetricsProcessor, bool expectedProfilingSessionTraceProcessor, bool hasInstrumentations)
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
                WalkTracerCompositeProcessor(processor, variables);
                Assert.Equal(expectedLiveMetricsProcessor, variables.foundLiveMetricsProcessor);
                Assert.True(variables.foundStandardMetricsExtractionProcessor);
                Assert.True(variables.foundAzureMonitorTraceExporter);
                Assert.Equal(expectedProfilingSessionTraceProcessor, variables.foundProfilingSessionTraceProcessor);
                Assert.True(variables.foundMainAgentAttributionSpanProcessor);

                // Validate Sampler
                // The default TracesPerSecond is 5.0, so we expect RateLimitedSampler by default
                EvaluationHelper.EvaluateTracerProviderSampler(serviceProvider, true);

                // Validate Instrumentations
                var instrumentationsProperty = tracerProvider.GetType().GetProperty("Instrumentations", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.NotNull(instrumentationsProperty);

                var instrumentations = instrumentationsProperty.GetValue(tracerProvider) as IEnumerable<object>;
                Assert.NotNull(instrumentations);

                if (hasInstrumentations)
                {
                    var instrumentationTypes = instrumentations.Select(i => i.GetType().Name).ToList();
                    Assert.Contains("SqlClientInstrumentation", instrumentationTypes);
                    Assert.Contains("AspNetCoreInstrumentation", instrumentationTypes);
#if NET
                    Assert.Contains("HttpClientInstrumentation", instrumentationTypes);

                    Assert.Equal(3, instrumentations.Count());
#else
                    Assert.Equal(2, instrumentations.Count());
#endif
                }
                else
                {
                    Assert.Empty(instrumentations);
                }
            }

            public static void EvaluateTracerProviderSampler(IServiceProvider serviceProvider, bool isExpectedSamplerRateLimited)
            {
                var tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();
                Assert.NotNull(tracerProvider);

                // Get TracerProviderSdk
                var tracerProviderSdkType = tracerProvider.GetType();

                 // Validate Sampler
                var samplerProperty = tracerProviderSdkType.GetProperty("Sampler", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.NotNull(samplerProperty);
                var sampler = samplerProperty.GetValue(tracerProvider);
                Assert.NotNull(sampler);
                Assert.Equal(isExpectedSamplerRateLimited ? nameof(Exporter.Internals.RateLimitedSampler) : nameof(Exporter.Internals.ApplicationInsightsSampler), sampler.GetType().Name);
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

                var processorProperty = loggerProvider.GetType().GetProperty("Processor", BindingFlags.Public | BindingFlags.Instance);
                Assert.NotNull(processorProperty);

                var processor = processorProperty.GetValue(loggerProvider);
                Assert.NotNull(processor);

                // Walk the processor chain to find expected processors.
                bool foundMainAgentAttributionLogProcessor = false;
                bool foundLiveMetricsLogProcessor = false;
                bool foundAzureMonitorLogExporter = false;

                WalkLogProcessorChain(processor, ref foundMainAgentAttributionLogProcessor, ref foundLiveMetricsLogProcessor, ref foundAzureMonitorLogExporter);

                Assert.True(foundMainAgentAttributionLogProcessor, "MainAgentAttributionLogProcessor not found");
                Assert.True(foundAzureMonitorLogExporter, "AzureMonitorLogExporter not found");
                Assert.Equal(liveMetricsEnabled, foundLiveMetricsLogProcessor);
            }

            private static void WalkLogProcessorChain(object processor, ref bool foundMainAgent, ref bool foundLiveMetrics, ref bool foundExporter)
            {
                var processorType = processor.GetType();

                if (processorType.Name.Contains("MainAgentAttributionLogProcessor"))
                {
                    foundMainAgent = true;
                    return;
                }
                else if (processorType.Name.Contains(nameof(LiveMetrics.LiveMetricsLogProcessor)))
                {
                    foundLiveMetrics = true;
                    return;
                }
                else if (processorType.Name.Contains("CompositeProcessor"))
                {
                    // Walk the linked list inside the CompositeProcessor
                    var headField = processorType.GetField("Head", BindingFlags.NonPublic | BindingFlags.Instance);
                    Assert.NotNull(headField);
                    var currentNode = headField.GetValue(processor);

                    while (currentNode != null)
                    {
                        var valueField = currentNode.GetType().GetField("Value", BindingFlags.Public | BindingFlags.Instance);
                        var nextProperty = currentNode.GetType().GetProperty("Next", BindingFlags.Public | BindingFlags.Instance);

                        var childProcessor = valueField!.GetValue(currentNode);
                        if (childProcessor != null)
                        {
                            WalkLogProcessorChain(childProcessor, ref foundMainAgent, ref foundLiveMetrics, ref foundExporter);
                        }

                        currentNode = nextProperty!.GetValue(currentNode);
                    }

                    return;
                }

                // Check if this processor wraps an exporter
                var exporterProperty = processorType.GetProperty("Exporter", BindingFlags.NonPublic | BindingFlags.Instance);
                if (exporterProperty != null)
                {
                    var exporter = exporterProperty.GetValue(processor);
                    if (exporter != null && exporter.GetType().Name.Contains(nameof(AzureMonitorLogExporter)))
                    {
                        foundExporter = true;
                    }
                }
            }

            private static void WalkTracerCompositeProcessor(object compositeProcessor, TracerProviderVariables variables)
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
                        else if (processorType.Name.Contains("MainAgentAttributionSpanProcessor"))
                        {
                            variables.foundMainAgentAttributionSpanProcessor = true;
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
                            WalkTracerCompositeProcessor(processorValue, variables);
                        }
                    }

                    currentNode = nextProperty!.GetValue(currentNode);
                }
            }
        }
    }
}
