// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class EventRateMetricDefinition
    {
        /// <summary> Initializes a new instance of <see cref="EventRateMetricDefinition"/>. </summary>
        /// <param name="eventName"> Name of the event to observe. </param>
        /// <param name="rateCondition"> The event contributes to the rate numerator if it satisfies this condition. </param>
        public EventRateMetricDefinition(string eventName, string rateCondition)
            : this(new ObservedEvent(eventName), rateCondition)
        {
        }
    }
}
