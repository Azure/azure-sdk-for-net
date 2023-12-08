// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals
{
    /// <summary>
    /// This class encapsulates all the metrics that are tracked and reported to th eLive Metrics service.
    /// </summary>
    internal class MetricsContainer
    {
        private readonly ConcurrentQueue<List<Models.MetricPoint>> _queue = new();

        internal readonly DoubleBuffer<DocumentBuffer> _documentBuffer = new();

        internal readonly DoubleBuffer<LiveMetricsBuffer> _liveMetricsBuffer = new();

        private PerformanceCounter _performanceCounter_ProcessorTime = new PerformanceCounter(categoryName: "Processor", counterName: "% Processor Time", instanceName: "_Total");
        private PerformanceCounter _performanceCounter_CommittedBytes = new PerformanceCounter(categoryName: "Memory", counterName: "Committed Bytes");

        public IEnumerable<Models.MetricPoint> CollectMetricPoints()
        {
            var liveMetricsBuffer = _liveMetricsBuffer.FlipBuffers();

            // REQUESTS
            if (liveMetricsBuffer.RequestsCount > 0)
            {
                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.RequestsPerSecondMetricIdValue,
                    Value = liveMetricsBuffer.RequestsCount,
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.RequestDurationMetricIdValue,
                    Value = (float)(liveMetricsBuffer.RequestsDuration / liveMetricsBuffer.RequestsCount),
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.RequestsSucceededPerSecondMetricIdValue,
                    Value = liveMetricsBuffer.RequestsSuccededCount,
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.RequestsFailedPerSecondMetricIdValue,
                    Value = liveMetricsBuffer.RequestsFailedCount,
                    Weight = 1
                };
            }

            // DEPENDENCIES
            if (liveMetricsBuffer.DependenciesCount > 0)
            {
                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.DependenciesPerSecondMetricIdValue,
                    Value = liveMetricsBuffer.DependenciesCount,
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.DependencyDurationMetricIdValue,
                    Value = (float)(liveMetricsBuffer.DependenciesDuration / liveMetricsBuffer.DependenciesCount),
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.DependencySucceededPerSecondMetricIdValue,
                    Value = liveMetricsBuffer.DependenciesSuccededCount,
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.DependencyFailedPerSecondMetricIdValue,
                    Value = liveMetricsBuffer.DependenciesFailedCount,
                    Weight = 1
                };
            }

            // EXCEPTIONS
            if (liveMetricsBuffer.ExceptionsCount > 0)
            {
                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.ExceptionsPerSecondMetricIdValue,
                    Value = liveMetricsBuffer.ExceptionsCount,
                    Weight = 1
                };
            }

            // PERFORMANCE COUNTERS
            yield return new Models.MetricPoint
            {
                Name = LiveMetricConstants.MetricId.MemoryCommittedBytesMetricIdValue,
                Value = _performanceCounter_CommittedBytes.NextValue(),
                Weight = 1
            };

            yield return new Models.MetricPoint
            {
                Name = LiveMetricConstants.MetricId.ProcessorTimeMetricIdValue,
                Value = _performanceCounter_ProcessorTime.NextValue(),
                Weight = 1
            };
        }
    }
}
