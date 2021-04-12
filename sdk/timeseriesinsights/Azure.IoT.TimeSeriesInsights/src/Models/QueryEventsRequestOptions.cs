// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Optional parameters to use when querying for Time Series Insights events.
    /// </summary>
    public class QueryEventsRequestOptions : QueryRequestOptions
    {
        /// <summary>
        /// An array of properties to be returned in the response. These properties must appear
        /// in the events; otherwise, they are not returned.
        /// </summary>
        public List<EventProperty> ProjectedProperties { get; }

        /// <summary>
        /// Creates a new instance of QueryEventsRequestOptions.
        /// </summary>
        public QueryEventsRequestOptions()
        {
            ProjectedProperties = new List<EventProperty>();
        }
    }
}
