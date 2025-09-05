// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class UserRateMetricDefinition
    {
        /// <summary> Initializes a new instance of <see cref="UserRateMetricDefinition"/>. </summary>
        /// <param name="startEventName"> Name of the event that starts the rate calculation. </param>
        /// <param name="endEventName"> Name of the event that ends the rate calculation. </param>
        public UserRateMetricDefinition(string startEventName, string endEventName)
            : this(new ObservedEvent(startEventName), new ObservedEvent(endEventName))
        {
        }
    }
}
