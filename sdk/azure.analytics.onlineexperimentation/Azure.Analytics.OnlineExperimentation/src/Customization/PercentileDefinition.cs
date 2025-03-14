// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class PercentileDefinition
    {
        /// <summary> Initializes a new instance of <see cref="PercentileDefinition"/>. </summary>
        /// <param name="eventName"> The name of the event. </param>
        /// <param name="eventProperty"> The key of the event property to aggregate. </param>
        /// <param name="percentile"> The percentile to measure. </param>
        public PercentileDefinition(string eventName, string eventProperty, int percentile)
            : this(new AggregatedValue(eventName, eventProperty), percentile)
        {
        }

        /// <summary> Initializes a new instance of <see cref="PercentileDefinition"/>. </summary>
        /// <param name="eventName"> The name of the event. </param>
        /// <param name="filter"> [Optional] A condition to filter events. </param>
        /// <param name="eventProperty"> The key of the event property to aggregate. </param>
        /// <param name="percentile"> The percentile to measure. </param>
        public PercentileDefinition(string eventName, string filter, string eventProperty, int percentile)
            : this(new AggregatedValue(eventName, filter, eventProperty), percentile)
        {
        }
    }
}
