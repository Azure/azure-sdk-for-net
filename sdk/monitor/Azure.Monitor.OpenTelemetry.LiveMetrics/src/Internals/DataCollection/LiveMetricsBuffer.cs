// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

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
                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.RequestsPerSecondMetricIdValue,
                    Value = RequestsCount,
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.RequestDurationMetricIdValue,
                    Value = (float)(RequestsDuration / RequestsCount),
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.RequestsSucceededPerSecondMetricIdValue,
                    Value = RequestsSuccededCount,
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.RequestsFailedPerSecondMetricIdValue,
                    Value = RequestsFailedCount,
                    Weight = 1
                };
            }

            // DEPENDENCIES
            if (DependenciesCount > 0)
            {
                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.DependenciesPerSecondMetricIdValue,
                    Value = DependenciesCount,
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.DependencyDurationMetricIdValue,
                    Value = (float)(DependenciesDuration / DependenciesCount),
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.DependencySucceededPerSecondMetricIdValue,
                    Value = DependenciesSuccededCount,
                    Weight = 1
                };

                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.DependencyFailedPerSecondMetricIdValue,
                    Value = DependenciesFailedCount,
                    Weight = 1
                };
            }

            // EXCEPTIONS
            if (ExceptionsCount > 0)
            {
                yield return new Models.MetricPoint
                {
                    Name = LiveMetricConstants.MetricId.ExceptionsPerSecondMetricIdValue,
                    Value = ExceptionsCount,
                    Weight = 1
                };
            }
        }
    }
}
