// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class EventCountMetricDefinition
    {
        /// <summary> Initializes a new instance of <see cref="EventCountMetricDefinition"/>. </summary>
        /// <param name="eventName"> Name of the event to observe. </param>
        public EventCountMetricDefinition(string eventName)
            : this(new ObservedEvent(eventName))
        {
        }
    }
}
