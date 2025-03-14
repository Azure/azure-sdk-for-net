// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class ObservedEvent
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ObservedEvent"/> class.
        /// </summary>
        /// <param name="eventName"> The name of the event. </param>
        /// <param name="filter"> [Optional] A condition to filter events. </param>
        public ObservedEvent(string eventName, string filter)
            : this(eventName, filter, null)
        {
        }
    }
}
