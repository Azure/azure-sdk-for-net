﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            // Counter Example
            Counter<long> myFruitCounter = meter.CreateCounter<long>("MyFruitCounter");

            myFruitCounter.Add(1, new("name", "apple"), new("color", "red"));
            myFruitCounter.Add(2, new("name", "lemon"), new("color", "yellow"));
            myFruitCounter.Add(1, new("name", "lemon"), new("color", "yellow"));
            myFruitCounter.Add(2, new("name", "apple"), new("color", "green"));
            myFruitCounter.Add(5, new("name", "apple"), new("color", "red"));
            myFruitCounter.Add(4, new("name", "lemon"), new("color", "yellow"));

            // Histogram Example
            Histogram<long> myHistogram = meter.CreateHistogram<long>("MyHistogram");

            var random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                myHistogram.Record(random.Next(1, 1000), new("tag1", "value1"), new("tag2", "value2"));
            }

            // Guage Example
            var process = Process.GetCurrentProcess();

            ObservableGauge<int> myOservableGauge = meter.CreateObservableGauge("Thread.State", () => GetThreadState(process));
        }

        public void Dispose()
        {
            this.meterProvider.Dispose();
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
