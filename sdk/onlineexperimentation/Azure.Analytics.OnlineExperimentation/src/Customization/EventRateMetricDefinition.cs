// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class EventRateMetricDefinition
    {
        // Restores the constructor that took the previously required values. The generator now emits only a parameterless
        // constructor because ExperimentMetric is also used in a merge-patch update, but create, validate, and the samples rely on this one.
        /// <summary> Initializes a new instance of <see cref="EventRateMetricDefinition"/>. </summary>
        /// <param name="event"> Event to observe as the rate denominator. </param>
        /// <param name="rateCondition"> The event contributes to the rate numerator if it satisfies this condition. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="event"/> or <paramref name="rateCondition"/> is null. </exception>
        public EventRateMetricDefinition(ObservedEvent @event, string rateCondition) : this()
        {
            Argument.AssertNotNull(@event, nameof(@event));
            Argument.AssertNotNull(rateCondition, nameof(rateCondition));

            Event = @event;
            RateCondition = rateCondition;
        }

        /// <summary> Initializes a new instance of <see cref="EventRateMetricDefinition"/>. </summary>
        /// <param name="eventName"> Name of the event to observe. </param>
        /// <param name="rateCondition"> The event contributes to the rate numerator if it satisfies this condition. </param>
        public EventRateMetricDefinition(string eventName, string rateCondition)
            : this(new ObservedEvent(eventName), rateCondition)
        {
        }
    }
}
