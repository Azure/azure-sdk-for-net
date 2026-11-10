// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class AggregatedValue
    {
        // Restores the constructor that took the previously required values. The generator now emits only a parameterless
        // constructor because ExperimentMetric is also used in a merge-patch update, but create, validate, and the samples rely on this one.
        /// <summary> Initializes a new instance of <see cref="AggregatedValue"/>. </summary>
        /// <param name="eventName"> The name of the event. </param>
        /// <param name="eventProperty"> The key of the event property to aggregate. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="eventName"/> or <paramref name="eventProperty"/> is null. </exception>
        public AggregatedValue(string eventName, string eventProperty) : this()
        {
            Argument.AssertNotNull(eventName, nameof(eventName));
            Argument.AssertNotNull(eventProperty, nameof(eventProperty));

            EventName = eventName;
            EventProperty = eventProperty;
        }
    }
}
