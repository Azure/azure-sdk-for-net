// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Optional parameters to use when querying for Time Series Insights aggregate series.
    /// </summary>
    public class QueryAggregateSeriesRequestOptions : QueryRequestOptions
    {
        /// <summary>
        /// Selected variables that needs to be projected in the query result. When it is null or not set, all the
        /// variables and Time Series types in the model are returned.
        /// </summary>
        public IList<string> ProjectedVariableNames { get; }

        /// <summary>
        /// Optional inline variables apart from the ones already defined in the Time Series type in the model.
        /// When the inline variable name is the same name as in the model, the inline variable definition takes precedence.
        /// </summary>
        public IDictionary<string, TimeSeriesVariable> InlineVariables { get; }

        /// <summary>
        /// Creates a new instance of QueryAggregateSeriesRequestOptions.
        /// </summary>
        public QueryAggregateSeriesRequestOptions()
        {
            ProjectedVariableNames = new List<string>();
            InlineVariables = new Dictionary<string, TimeSeriesVariable>();
        }
    }
}
