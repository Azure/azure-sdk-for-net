// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class EventCountMetricDefinition
    {
        // Restores the constructor that took the previously required values. The generator now emits only a parameterless
        // constructor because ExperimentMetric is also used in a merge-patch update, but create, validate, and the samples rely on this one.
        /// <summary> Initializes a new instance of <see cref="EventCountMetricDefinition"/>. </summary>
        /// <param name="event"> Event to observe. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="event"/> is null. </exception>
        public EventCountMetricDefinition(ObservedEvent @event) : this()
        {
            Argument.AssertNotNull(@event, nameof(@event));

            Event = @event;
        }

        /// <summary> Initializes a new instance of <see cref="EventCountMetricDefinition"/>. </summary>
        /// <param name="eventName"> Name of the event to observe. </param>
        public EventCountMetricDefinition(string eventName)
            : this(new ObservedEvent(eventName))
        {
        }
    }
}
