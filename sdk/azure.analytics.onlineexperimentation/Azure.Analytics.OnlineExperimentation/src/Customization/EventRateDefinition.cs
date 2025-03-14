// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class EventRateDefinition
    {
        /// <summary> Initializes a new instance of <see cref="EventRateDefinition"/>. </summary>
        /// <param name="eventName"> Name of the event to observe. </param>
        /// <param name="rateCondition"> The event contributes to the rate numerator if it satisfies this condition. </param>
        public EventRateDefinition(string eventName, string rateCondition)
            : this(new ObservedEvent(eventName), rateCondition)
        {
        }

        /// <summary> Initializes a new instance of <see cref="EventRateDefinition"/>. </summary>
        /// <param name="eventName"> Name of the event to observe. </param>
        /// <param name="filter"> Filter condition for the event. </param>
        /// <param name="rateCondition"> The event contributes to the rate numerator if it satisfies this condition. </param>
        public EventRateDefinition(string eventName, string filter, string rateCondition)
            : this(new ObservedEvent(eventName, filter), rateCondition)
        {
        }
    }
}
