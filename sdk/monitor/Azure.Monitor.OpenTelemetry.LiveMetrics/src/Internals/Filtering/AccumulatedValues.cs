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
        private readonly AggregationType aggregationType;

        private SpinLock spinLock = new SpinLock();

        private long count = 0;

        private double sum = 0;

        private double max = double.MinValue;

        private double min = double.MaxValue;

        public AccumulatedValues(string metricId, AggregationType aggregationType)
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
                    case AggregationType.Avg:
                    case AggregationType.Sum:
                        this.sum += value;
                        break;
                    case AggregationType.Min:
                        if (value < this.min)
                        {
                            this.min = value;
                        }

                        break;
                    case AggregationType.Max:
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
                    case AggregationType.Avg:
                        return this.count != 0 ? this.sum / this.count : 0.0;
                    case AggregationType.Sum:
                        return this.sum;
                    case AggregationType.Min:
                        return this.count != 0 ? this.min : 0.0;
                    case AggregationType.Max:
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
