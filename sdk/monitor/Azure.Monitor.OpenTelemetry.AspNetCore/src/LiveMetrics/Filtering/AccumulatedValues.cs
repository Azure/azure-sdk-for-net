// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.AspNetCore.LiveMetrics.Filtering
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
            this.MetricId = metricId;
            this.aggregationType = aggregationType;
        }

        public string MetricId { get; }

        public void AddValue(double value)
        {
            Interlocked.Increment(ref this.count);

            bool lockTaken = false;
            try
            {
                this.spinLock.Enter(ref lockTaken);

                switch (this.aggregationType)
                {
                    case AggregationTypeEnum.Avg:
                    case AggregationTypeEnum.Sum:
                        this.sum += value;
                        break;
                    case AggregationTypeEnum.Min:
                        if (value < this.min)
                        {
                            this.min = value;
                        }

                        break;
                    case AggregationTypeEnum.Max:
                        if (value > this.max)
                        {
                            this.max = value;
                        }

                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "Unsupported AggregationType: '{0}'", this.aggregationType));
                }
            }
            finally
            {
                if (lockTaken)
                {
                    this.spinLock.Exit();
                }
            }
        }

        [SuppressMessage("Microsoft.Usage", "CA2208:InstantiateArgumentExceptionsCorrectly", Justification = "Argument exceptions are valid.")]
        public double CalculateAggregation(out long count)
        {
            bool lockTaken = false;
            try
            {
                this.spinLock.Enter(ref lockTaken);

                count = this.count;
                switch (this.aggregationType)
                {
                    case AggregationTypeEnum.Avg:
                        return this.count != 0 ? this.sum / this.count : 0.0;
                    case AggregationTypeEnum.Sum:
                        return this.sum;
                    case AggregationTypeEnum.Min:
                        return this.count != 0 ? this.min : 0.0;
                    case AggregationTypeEnum.Max:
                        return this.count != 0 ? this.max : 0.0;
                    default:
                        throw new ArgumentOutOfRangeException(
                            nameof(this.aggregationType),
                            this.aggregationType,
                            string.Format(CultureInfo.InvariantCulture, "AggregationType is not supported: {0}", this.aggregationType));
                }
            }
            finally
            {
                if (lockTaken)
                {
                    this.spinLock.Exit();
                }
            }
        }
    }
}
