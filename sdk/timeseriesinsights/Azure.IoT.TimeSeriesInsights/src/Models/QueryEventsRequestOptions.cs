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
        public IList<TimeSeriesInsightsEventProperty> ProjectedProperties { get; }

        /// <summary>
        /// The maximum number of property values in the whole response set, not the maximum number of property values per page.
        /// Defaults to 10,000 when not set. Maximum value of take can be 250,000.
        /// </summary>
        public int? MaxNumberOfEvents { get; set; }

        /// <summary>
        /// Creates a new instance of QueryEventsRequestOptions.
        /// </summary>
        public QueryEventsRequestOptions()
        {
            ProjectedProperties = new List<TimeSeriesInsightsEventProperty>();
        }
    }
}
