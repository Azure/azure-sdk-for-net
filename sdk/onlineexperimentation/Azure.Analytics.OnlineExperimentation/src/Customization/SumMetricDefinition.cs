// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class SumMetricDefinition
    {
        // Restores the constructor that took the previously required values. The generator now emits only a parameterless
        // constructor because ExperimentMetric is also used in a merge-patch update, but create, validate, and the samples rely on this one.
        /// <summary> Initializes a new instance of <see cref="SumMetricDefinition"/>. </summary>
        /// <param name="value"> The value to aggregate. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SumMetricDefinition(AggregatedValue value) : this()
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value;
        }

        /// <summary> Initializes a new instance of <see cref="SumMetricDefinition"/>. </summary>
        /// <param name="eventName"> The name of the event. </param>
        /// <param name="eventProperty"> The key of the event property to aggregate. </param>
        public SumMetricDefinition(string eventName, string eventProperty)
            : this(new AggregatedValue(eventName, eventProperty))
        {
        }
    }
}
