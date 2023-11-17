// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using System.Collections.Concurrent;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    internal partial class Manager
    {
        private Meter? _meter;
        private MeterProvider? _meterProvider;
        private BaseExportingMetricReader? _metricReader;
        private readonly ConcurrentQueue<List<Models.MetricPoint>> _queue = new();

        private PerformanceCounter _performanceCounter_ProcessorTime = new PerformanceCounter(categoryName: "Processor", counterName: "% Processor Time", instanceName: "_Total");
        private PerformanceCounter _performanceCounter_CommittedBytes = new PerformanceCounter(categoryName: "Memory", counterName: "Committed Bytes");

        private Instrument? _myObservableGauge1;
        private Instrument? _myObservableGauge2;

        private void InitializeMetrics()
        {
            var uniqueTestId = Guid.NewGuid();

            //var meterName = $"meterName{uniqueTestId}";
            var meterName = LiveMetricConstants.LiveMetricMeterName;
            _meter = new Meter(meterName, "1.0");

            _myObservableGauge1 = _meter.CreateObservableGauge(LiveMetricConstants.MemoryCommittedBytesInstrumentName, () =>
            {
                return new Measurement<float>(value: _performanceCounter_CommittedBytes.NextValue());
            });

            _myObservableGauge2 = _meter.CreateObservableGauge(LiveMetricConstants.ProcessorTimeInstrumentName, () =>
            {
                return new Measurement<float>(value: _performanceCounter_ProcessorTime.NextValue());
            });

            _metricReader = new BaseExportingMetricReader(new LiveMetricsMetricExporter(_queue));

            var meterProviderBuilder = Sdk.CreateMeterProviderBuilder()
                .AddMeter(meterName)
                .AddReader(_metricReader);

            _meterProvider = meterProviderBuilder.Build();
        }

        private IEnumerable<Models.MetricPoint> CollectMetrics()
        {
            _metricReader?.Collect();

            if (_queue.TryDequeue(out var metricPoint))
            {
                return metricPoint;
            }
            else
            {
                return Array.Empty<Models.MetricPoint>();
            }
        }
    }
}
