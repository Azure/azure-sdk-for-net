// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class PercentileMetricDefinition
    {
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
