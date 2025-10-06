// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Threading;

    /// <summary>
    /// Accumulator for calculated metrics.
    /// </summary>
    internal class AccumulatedValues
    {
        private readonly AggregationTypeEnum aggregationType;

        private SpinLock spinLock = new SpinLock();

        private long count = 0;

        private double sum = 0;

        private double max = double.MinValue;

        private double min = double.MaxValue;

        public AccumulatedValues(string metricId, AggregationTypeEnum aggregationType)
        {
            MetricId = metricId;
            this.aggregationType = aggregationType;
        }

        public string MetricId { get; }

        public void AddValue(double value)
        {
            Interlocked.Increment(ref count);

            bool lockTaken = false;
            try
            {
                spinLock.Enter(ref lockTaken);

                switch (aggregationType)
                {
                    case AggregationTypeEnum.Avg:
                    case AggregationTypeEnum.Sum:
                        sum += value;
                        break;
                    case AggregationTypeEnum.Min:
                        if (value < min)
                        {
                            min = value;
                        }

                        break;
                    case AggregationTypeEnum.Max:
                        if (value > max)
                        {
                            max = value;
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "Unsupported AggregationType: '{0}'", aggregationType));
                }
            }
            finally
            {
                if (lockTaken)
                {
                    spinLock.Exit();
                }
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "Argument exceptions are valid.")]
        public double CalculateAggregation(out long count)
        {
            bool lockTaken = false;
            try
            {
                spinLock.Enter(ref lockTaken);

                count = this.count;
                switch (aggregationType)
                {
                    case AggregationTypeEnum.Avg:
                        return this.count != 0 ? sum / this.count : 0.0;
                    case AggregationTypeEnum.Sum:
                        return sum;
                    case AggregationTypeEnum.Min:
                        return this.count != 0 ? min : 0.0;
                    case AggregationTypeEnum.Max:
                        return this.count != 0 ? max : 0.0;
                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(aggregationType),
                            aggregationType,
                            string.Format(CultureInfo.InvariantCulture, "AggregationType is not supported: {0}", aggregationType));
                }
            }
            finally
            {
                if (lockTaken)
                {
                    spinLock.Exit();
                }
            }
        }
    }
}
