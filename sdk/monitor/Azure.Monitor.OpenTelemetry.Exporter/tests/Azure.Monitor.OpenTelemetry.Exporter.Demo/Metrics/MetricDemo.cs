// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.Core;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Metrics
{
    internal class MetricDemo : IDisposable
    {
        private const string meterName = "MyCompany.MyProduct.MyLibrary";
        private static readonly Meter meter = new(meterName);

        private readonly MeterProvider? meterProvider;

        public MetricDemo(string connectionString, TokenCredential? credential = null)
        {
            var resourceAttributes = new Dictionary<string, object>
            {
                { "service.name", "my-service" },
                { "service.namespace", "my-namespace" },
                { "service.instance.id", "my-instance" },
                { "service.version", "1.0.0-demo" },
            };

            var resourceBuilder = ResourceBuilder.CreateDefault().AddAttributes(resourceAttributes);

            this.meterProvider = Sdk.CreateMeterProviderBuilder()
                .SetResourceBuilder(resourceBuilder)
                .AddMeter(meterName)
                .AddAzureMonitorMetricExporter(o => o.ConnectionString = connectionString, credential)
                .Build();
        }

        /// <remarks>
        /// These counters will be aggregated and ingested as Application Insights customMetrics.
        /// </remarks>
        public void GenerateMetrics()
        {
            // Counter Example
            Counter<long> myFruitCounter = meter.CreateCounter<long>("MyFruitCounter");

            myFruitCounter.Add(1, new("name", "apple"), new("color", "red"));
            myFruitCounter.Add(2, new("name", "lemon"), new("color", "yellow"));
            myFruitCounter.Add(1, new("name", "lemon"), new("color", "yellow"));
            myFruitCounter.Add(2, new("name", "apple"), new("color", "green"));
            myFruitCounter.Add(5, new("name", "apple"), new("color", "red"));
            myFruitCounter.Add(4, new("name", "lemon"), new("color", "yellow"));

            // Histogram Example
            Histogram<long> myFruitSalePrice = meter.CreateHistogram<long>("MyFruitSalePrice");

            var random = new Random();
            myFruitSalePrice.Record(random.Next(1, 1000), new("name", "apple"), new("color", "red"));
            myFruitSalePrice.Record(random.Next(1, 1000), new("name", "lemon"), new("color", "yellow"));
            myFruitSalePrice.Record(random.Next(1, 1000), new("name", "lemon"), new("color", "yellow"));
            myFruitSalePrice.Record(random.Next(1, 1000), new("name", "apple"), new("color", "green"));
            myFruitSalePrice.Record(random.Next(1, 1000), new("name", "apple"), new("color", "red"));
            myFruitSalePrice.Record(random.Next(1, 1000), new("name", "lemon"), new("color", "yellow"));

            // Gauge Example
            var process = Process.GetCurrentProcess();

            ObservableGauge<int> myObservableGauge = meter.CreateObservableGauge("Thread.State", () => GetThreadState(process));
        }

        public void Dispose()
        {
            this.meterProvider?.Dispose();
        }

        private static IEnumerable<Measurement<int>> GetThreadState(Process process)
        {
            foreach (ProcessThread thread in process.Threads)
            {
                yield return new((int)thread.ThreadState, new("ProcessId", process.Id), new("ThreadId", thread.Id));
            }
        }
    }
}
