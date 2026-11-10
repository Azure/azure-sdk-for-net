// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class UserRateMetricDefinition
    {
        // Restores the constructor that took the previously required values. The generator now emits only a parameterless
        // constructor because ExperimentMetric is also used in a merge-patch update, but create, validate, and the samples rely on this one.
        /// <summary> Initializes a new instance of <see cref="UserRateMetricDefinition"/>. </summary>
        /// <param name="startEvent"> The start event to observe as the rate denominator. </param>
        /// <param name="endEvent"> The end event to observe, which is a condition for the rate numerator. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="startEvent"/> or <paramref name="endEvent"/> is null. </exception>
        public UserRateMetricDefinition(ObservedEvent startEvent, ObservedEvent endEvent) : this()
        {
            Argument.AssertNotNull(startEvent, nameof(startEvent));
            Argument.AssertNotNull(endEvent, nameof(endEvent));

            StartEvent = startEvent;
            EndEvent = endEvent;
        }

        /// <summary> Initializes a new instance of <see cref="UserRateMetricDefinition"/>. </summary>
        /// <param name="startEventName"> Name of the event that starts the rate calculation. </param>
        /// <param name="endEventName"> Name of the event that ends the rate calculation. </param>
        public UserRateMetricDefinition(string startEventName, string endEventName)
            : this(new ObservedEvent(startEventName), new ObservedEvent(endEventName))
        {
        }
    }
}
