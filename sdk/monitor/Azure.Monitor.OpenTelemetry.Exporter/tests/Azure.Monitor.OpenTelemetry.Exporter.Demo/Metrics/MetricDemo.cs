// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Metrics;
using OpenTelemetry;
using OpenTelemetry.Metrics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Demo.Metrics
{
    internal class MetricDemo : IDisposable
    {
        private const string meterName = "MyCompany.MyProduct.MyLibrary";
        private static readonly Meter meter = new(meterName);

        private readonly MeterProvider meterProvider;

        public MetricDemo(string connectionString)
        {
            this.meterProvider = Sdk.CreateMeterProviderBuilder()
                                .AddMeter(meterName)
                                .AddAzureMonitorMetricExporter(o => o.ConnectionString = connectionString)
                                .Build();
        }

        /// <remarks>
        /// These counters will be aggregated and ingested as Application Insights customMetrics.
        /// </remarks>
        public void GenerateMetrics()
        {
            Counter<long> MyFruitCounter = meter.CreateCounter<long>("MyFruitCounter");

            MyFruitCounter.Add(1, new("name", "apple"), new("color", "red"));
            MyFruitCounter.Add(2, new("name", "lemon"), new("color", "yellow"));
            MyFruitCounter.Add(1, new("name", "lemon"), new("color", "yellow"));
            MyFruitCounter.Add(2, new("name", "apple"), new("color", "green"));
            MyFruitCounter.Add(5, new("name", "apple"), new("color", "red"));
            MyFruitCounter.Add(4, new("name", "lemon"), new("color", "yellow"));
        }

        public void Dispose()
        {
            this.meterProvider.Dispose();
        }
    }
}
