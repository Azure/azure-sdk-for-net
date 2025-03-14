// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Analytics.OnlineExperimentation
{
    public partial class SumDefinition
    {
        /// <summary> Initializes a new instance of <see cref="SumDefinition"/>. </summary>
        /// <param name="eventName"> The name of the event. </param>
        /// <param name="eventProperty"> The key of the event property to aggregate. </param>
        public SumDefinition(string eventName, string eventProperty)
            : this(new AggregatedValue(eventName, eventProperty))
        {
        }

        /// <summary> Initializes a new instance of <see cref="SumDefinition"/>. </summary>
        /// <param name="eventName"> The name of the event. </param>
        /// <param name="filter"> [Optional] A condition to filter events. </param>
        /// <param name="eventProperty"> The key of the event property to aggregate. </param>
        public SumDefinition(string eventName, string filter, string eventProperty)
            : this(new AggregatedValue(eventName, filter, eventProperty))
        {
        }
    }
}
