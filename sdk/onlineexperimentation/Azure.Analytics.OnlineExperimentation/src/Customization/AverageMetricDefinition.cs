// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class AverageMetricDefinition
    {
        /// <summary> Initializes a new instance of <see cref="AverageMetricDefinition"/>. </summary>
        /// <param name="eventName"> The name of the event. </param>
        /// <param name="eventProperty"> The key of the event property to aggregate. </param>
        public AverageMetricDefinition(string eventName, string eventProperty)
            : this(new AggregatedValue(eventName, eventProperty))
        {
        }
    }
}
