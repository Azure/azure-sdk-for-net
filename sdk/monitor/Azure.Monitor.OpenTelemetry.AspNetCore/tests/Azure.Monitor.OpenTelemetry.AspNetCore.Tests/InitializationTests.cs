// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Trace;
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

            var tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();
            EvaluateTraceProvider.Evaluate(
                tracerProvider: tracerProvider,
                expectedAzureMonitorTraceExporter: true,
                expectedLiveMetricsProcessor: enableLiveMetrics,
                expectedProfilingSessionTraceProcessor: true,
                expectedStandardMetricsExtractionProcessor: true);

            // TODO: EVALUATE METRICS
            // TODO: EVALUATE LOGS
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

            var tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();
            EvaluateTraceProvider.Evaluate(
                tracerProvider: tracerProvider,
                expectedAzureMonitorTraceExporter: true,
                expectedLiveMetricsProcessor: enableLiveMetrics,
                expectedProfilingSessionTraceProcessor: false,
                expectedStandardMetricsExtractionProcessor: true);

            // TODO: EVALUATE METRICS
            // TODO: EVALUATE LOGS
        }

        private static async Task StartHostedServicesAsync(ServiceProvider serviceProvider)
        {
            var hostedServices = serviceProvider.GetServices<IHostedService>();
            foreach (var hostedService in hostedServices)
            {
                await hostedService.StartAsync(CancellationToken.None);
            }
        }

        private class EvaluateTraceProvider()
        {
            private class Variables
            {
                public bool foundProfilingSessionTraceProcessor;
                public bool foundAzureMonitorTraceExporter;
                public bool foundLiveMetricsProcessor;
                public bool foundStandardMetricsExtractionProcessor;
            }

            public static void Evaluate(TracerProvider tracerProvider, bool expectedAzureMonitorTraceExporter, bool expectedLiveMetricsProcessor, bool expectedProfilingSessionTraceProcessor, bool expectedStandardMetricsExtractionProcessor)
            {
                Assert.NotNull(tracerProvider);

                // Get TracerProviderSdk
                var tracerProviderSdkType = tracerProvider.GetType();
                var processorProperty = tracerProviderSdkType.GetProperty("Processor", BindingFlags.NonPublic | BindingFlags.Instance);
                Assert.NotNull(processorProperty);

                var processor = processorProperty.GetValue(tracerProvider);
                Assert.NotNull(processor);

                var variables = new Variables();

                // Start walking the CompositeProcessor
                WalkCompositeProcessor(processor, variables);

                // Final assertions
                Assert.Equal(expectedLiveMetricsProcessor, variables.foundLiveMetricsProcessor);
                Assert.Equal(expectedStandardMetricsExtractionProcessor, variables.foundStandardMetricsExtractionProcessor);
                Assert.Equal(expectedAzureMonitorTraceExporter, variables.foundAzureMonitorTraceExporter);
                Assert.Equal(expectedProfilingSessionTraceProcessor, variables.foundProfilingSessionTraceProcessor);

                // TODO: THIS NEEDS TO ALSO EVAULATE SAMPLER
            }

            private static void WalkCompositeProcessor(object compositeProcessor, Variables variables)
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
