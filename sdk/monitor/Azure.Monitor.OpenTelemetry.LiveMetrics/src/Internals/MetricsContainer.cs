// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using OpenTelemetry.Metrics;
using OpenTelemetry;
using System.Collections.Concurrent;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// This class encapsulates all the metrics that are tracked and reported to th eLive Metrics service.
    /// </summary>
    internal class MetricsContainer
    {
        private readonly ConcurrentQueue<List<Models.MetricPoint>> _queue = new();

        private Meter? _meter;
        private string _meterName;
        private MeterProvider? _meterProvider;
        private BaseExportingMetricReader _metricReader;

        internal readonly DoubleBuffer _doubleBuffer = new();

        private PerformanceCounter _performanceCounter_ProcessorTime = new PerformanceCounter(categoryName: "Processor", counterName: "% Processor Time", instanceName: "_Total");
        private PerformanceCounter _performanceCounter_CommittedBytes = new PerformanceCounter(categoryName: "Memory", counterName: "Committed Bytes");

        internal readonly Counter<long> _requests;
        internal readonly Histogram<double> _requestDuration;
        internal readonly Counter<long> _requestSucceededPerSecond;
        internal readonly Counter<long> _requestFailedPerSecond;
        internal readonly Counter<long> _dependency;
        internal readonly Histogram<double> _dependencyDuration;
        internal readonly Counter<long> _dependencySucceededPerSecond;
        internal readonly Counter<long> _dependencyFailedPerSecond;
        internal readonly Counter<long> _exceptionsPerSecond;

        private readonly Instrument _myObservableGauge1;
        private readonly Instrument _myObservableGauge2;

        public MetricsContainer()
        {
            var uniqueId = Guid.NewGuid();
            _meterName = $"{LiveMetricConstants.LiveMetricMeterName}{uniqueId}";
            _meter = new Meter(_meterName, "1.0");

            // REQUEST
            _requests = _meter.CreateCounter<long>(LiveMetricConstants.InstrumentName.RequestsInstrumentName);
            _requestDuration = _meter.CreateHistogram<double>(LiveMetricConstants.InstrumentName.RequestDurationInstrumentName);
            _requestSucceededPerSecond = _meter.CreateCounter<long>(LiveMetricConstants.InstrumentName.RequestsSucceededPerSecondInstrumentName);
            _requestFailedPerSecond = _meter.CreateCounter<long>(LiveMetricConstants.InstrumentName.RequestsFailedPerSecondInstrumentName);

            // DEPENDENCY
            _dependency = _meter.CreateCounter<long>(LiveMetricConstants.InstrumentName.DependencyInstrumentName);
            _dependencyDuration = _meter.CreateHistogram<double>(LiveMetricConstants.InstrumentName.DependencyDurationInstrumentName);
            _dependencySucceededPerSecond = _meter.CreateCounter<long>(LiveMetricConstants.InstrumentName.DependencySucceededPerSecondInstrumentName);
            _dependencyFailedPerSecond = _meter.CreateCounter<long>(LiveMetricConstants.InstrumentName.DependencyFailedPerSecondInstrumentName);

            // EXCEPTIONS
            _exceptionsPerSecond = _meter.CreateCounter<long>(LiveMetricConstants.InstrumentName.ExceptionsPerSecondInstrumentName);

            // PERFORMANCE COUNTERS
            _myObservableGauge1 = _meter.CreateObservableGauge(LiveMetricConstants.InstrumentName.MemoryCommittedBytesInstrumentName, () =>
            {
                return new Measurement<float>(value: _performanceCounter_CommittedBytes.NextValue());
            });

            _myObservableGauge2 = _meter.CreateObservableGauge(LiveMetricConstants.InstrumentName.ProcessorTimeInstrumentName, () =>
            {
                return new Measurement<float>(value: _performanceCounter_ProcessorTime.NextValue());
            });

            // INITIALIZE METRICS SDK
            _metricReader = new BaseExportingMetricReader(new LiveMetricsMetricExporter(_queue));

            _meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter(_meterName)
                .AddReader(_metricReader)
                .Build();
        }

        public IEnumerable<Models.MetricPoint> Collect()
        {
            _metricReader.Collect();

            return _queue.TryDequeue(out var metricPoint)
                ? metricPoint
                : Array.Empty<Models.MetricPoint>();
        }
    }
}
