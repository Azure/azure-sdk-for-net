// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class PercentileMetricDefinition
    {
        // Restores the constructor that took the previously required values. The generator now emits only a parameterless
        // constructor because ExperimentMetric is also used in a merge-patch update, but create, validate, and the samples rely on this one.
        /// <summary> Initializes a new instance of <see cref="PercentileMetricDefinition"/>. </summary>
        /// <param name="value"> The value to aggregate, including the event name and property to measure. </param>
        /// <param name="percentile"> The percentile to measure. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public PercentileMetricDefinition(AggregatedValue value, double percentile) : this()
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value;
            Percentile = percentile;
        }

        /// <summary> Initializes a new instance of <see cref="PercentileMetricDefinition"/>. </summary>
        /// <param name="eventName"> The name of the event. </param>
        /// <param name="eventProperty"> The key of the event property to aggregate. </param>
        /// <param name="percentile"> The percentile to measure. </param>
        public PercentileMetricDefinition(string eventName, string eventProperty, int percentile)
            : this(new AggregatedValue(eventName, eventProperty), percentile)
        {
        }
    }
}
