// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class UserCountDefinition
    {
        /// <summary> Initializes a new instance of <see cref="UserCountDefinition"/>. </summary>
        /// <param name="eventName"> Name of the event to observe. </param>
        public UserCountDefinition(string eventName)
            : this(new ObservedEvent(eventName))
        {
        }

        /// <summary> Initializes a new instance of <see cref="UserCountDefinition"/>. </summary>
        /// <param name="eventName"> Name of the event to observe. </param>
        /// <param name="filter"> Filter condition for the event. </param>
        public UserCountDefinition(string eventName, string filter)
            : this(new ObservedEvent(eventName, filter))
        {
        }
    }
}
