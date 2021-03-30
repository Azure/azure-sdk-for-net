// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.TimeSeriesInsights
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
        public EventProperty[] ProjectedProperties { get; set; }
    }
}
