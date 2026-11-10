// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class ObservedEvent
    {
        // Restores the constructor that took the previously required values. The generator now emits only a parameterless
        // constructor because ExperimentMetric is also used in a merge-patch update, but create, validate, and the samples rely on this one.
        /// <summary> Initializes a new instance of <see cref="ObservedEvent"/>. </summary>
        /// <param name="eventName"> The name of the event. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="eventName"/> is null. </exception>
        public ObservedEvent(string eventName) : this()
        {
            Argument.AssertNotNull(eventName, nameof(eventName));

            EventName = eventName;
        }
    }
}
