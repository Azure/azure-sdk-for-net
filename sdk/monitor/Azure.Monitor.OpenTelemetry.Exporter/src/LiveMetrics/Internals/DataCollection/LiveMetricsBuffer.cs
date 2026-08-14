// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Monitor.OpenTelemetry.LiveMetrics.Internals;

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.DataCollection
{
    /// <summary>
    /// This struct encapsulates pre-aggregated metrics sent to Live Metrics.
    /// </summary>
    internal struct LiveMetricsBuffer
    {
        // REQUEST
        internal long RequestsCount;
        internal double RequestsDuration;
        internal long RequestsSuccededCount;
        internal long RequestsFailedCount;

        // DEPENDENCY
        internal long DependenciesCount;
        internal double DependenciesDuration;
        internal long DependenciesSuccededCount;
        internal long DependenciesFailedCount;

        // EXCEPTIONS
        internal long ExceptionsCount;

        public void RecordRequestSucceeded(double duration)
        {
            RequestsCount++;
            RequestsDuration += duration;
            RequestsSuccededCount++;
        }

        public void RecordRequestFailed(double duration)
        {
            RequestsCount++;
            RequestsDuration += duration;
            RequestsFailedCount++;
        }

        public void RecordDependencySucceeded(double duration)
        {
            DependenciesCount++;
            DependenciesDuration += duration;
            DependenciesSuccededCount++;
        }

        public void RecordDependencyFailed(double duration)
        {
            DependenciesCount++;
            DependenciesDuration += duration;
            DependenciesFailedCount++;
        }

        public void RecordException()
        {
            ExceptionsCount++;
        }

        public IEnumerable<Models.MetricPoint> GetMetricPoints()
        {
            // REQUESTS
            if (RequestsCount > 0)
            {
                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.RequestsPerSecondMetricIdValue, value: RequestsCount, weight: 1);

                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.RequestDurationMetricIdValue, value: (float)(RequestsDuration / RequestsCount), weight: 1);

                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.RequestsSucceededPerSecondMetricIdValue, value: RequestsSuccededCount, weight: 1);

                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.RequestsFailedPerSecondMetricIdValue, value: RequestsFailedCount, weight: 1);
            }

            // DEPENDENCIES
            if (DependenciesCount > 0)
            {
                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.DependenciesPerSecondMetricIdValue, value: DependenciesCount, weight: 1);

                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.DependencyDurationMetricIdValue, value: (float)(DependenciesDuration / DependenciesCount), weight: 1);

                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.DependencySucceededPerSecondMetricIdValue, value: DependenciesSuccededCount, weight: 1);

                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.DependencyFailedPerSecondMetricIdValue, value: DependenciesFailedCount, weight: 1);
            }

            // EXCEPTIONS
            if (ExceptionsCount > 0)
            {
                yield return new Models.MetricPoint(name: LiveMetricConstants.MetricId.ExceptionsPerSecondMetricIdValue, value: ExceptionsCount, weight: 1);
            }
        }
    }
}
