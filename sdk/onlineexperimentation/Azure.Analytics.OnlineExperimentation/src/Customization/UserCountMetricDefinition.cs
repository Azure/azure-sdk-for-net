// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class UserCountMetricDefinition
    {
        /// <summary> Initializes a new instance of <see cref="UserCountMetricDefinition"/>. </summary>
        /// <param name="eventName"> Name of the event to observe. </param>
        public UserCountMetricDefinition(string eventName)
            : this(new ObservedEvent(eventName))
        {
        }
    }
}
