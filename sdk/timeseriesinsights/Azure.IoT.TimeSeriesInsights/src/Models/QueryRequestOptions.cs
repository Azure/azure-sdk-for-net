// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Optional parameters to use when querying for Time Series Insights.
    /// </summary>
    public abstract class QueryRequestOptions
    {
        /// <summary>
        /// For the environments with warm store enabled, the query can be executed either on the 'WarmStore' or 'ColdStore'.
        /// This parameter in the query defines which store the query should be executed on. If not defined, the query
        /// will be executed on the cold store.
        /// </summary>
        public StoreType StoreType { get; set; }

        /// <summary>
        /// A Time Series Expression (TSX) filter written as a single string.
        /// Refer to the documentation on how to write Time Series expressions.
        /// </summary>
        /// <remarks>
        /// For filter examples, check out the TSX documentation
        /// <see href="https://docs.microsoft.com/rest/api/time-series-insights/reference-time-series-expression-syntax">here.</see>.
        /// </remarks>
        public string Filter { get; set; }

        /// <summary>
        /// The maximum number of property values in the whole response set, not the maximum number of property values per page.
        /// Defaults to 10,000 when not set. Maximum value of take can be 250,000.
        /// </summary>
        public int? MaximumNumberOfEvents { get; set; }
    }
}
