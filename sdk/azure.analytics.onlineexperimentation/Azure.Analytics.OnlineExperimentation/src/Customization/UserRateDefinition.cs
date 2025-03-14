// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class UserRateDefinition
    {
        /// <summary> Initializes a new instance of <see cref="UserRateDefinition"/>. </summary>
        /// <param name="startEventName"> Name of the event that starts the rate calculation. </param>
        /// <param name="endEventName"> Name of the event that ends the rate calculation. </param>
        public UserRateDefinition(string startEventName, string endEventName)
            : this(new ObservedEvent(startEventName), new ObservedEvent(endEventName))
        {
        }

        /// <summary> Initializes a new instance of <see cref="UserRateDefinition"/>. </summary>
        /// <param name="startEventName"> Name of the event that starts the rate calculation. </param>
        /// <param name="startEventFilter"> Filter condition for the start event. </param>
        /// <param name="endEventName"> Name of the event that ends the rate calculation. </param>
        /// <param name="endEventFilter"> Filter condition for the end event. </param>
        public UserRateDefinition(string startEventName, string startEventFilter, string endEventName, string endEventFilter)
            : this(new ObservedEvent(startEventName, startEventFilter), new ObservedEvent(endEventName, endEventFilter))
        {
        }
    }
}
