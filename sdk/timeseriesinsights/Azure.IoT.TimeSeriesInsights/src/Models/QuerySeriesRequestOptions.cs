// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.IoT.TimeSeriesInsights
{
    /// <summary>
    /// Optional parameters to use when querying for Time Series Insights series.
    /// </summary>
    public class QuerySeriesRequestOptions : QueryRequestOptions
    {
        /// <summary>
        /// Selected variables that needs to be projected in the query result. When it is null or not set, all the
        /// variables and Time Series types in the model are returned.
        /// </summary>
        public List<string> ProjectedVariables { get; }

        /// <summary>
        /// Optional inline variables apart from the ones already defined in the Time Series type in the model.
        /// When the inline variable name is the same name as in the model, the inline variable definition takes precedence.
        /// </summary>
        public IDictionary<string, TimeSeriesVariable> InlineVariables { get; }

        /// <summary>
        /// Creates a new instance of QuerySeriesRequestOptions.
        /// </summary>
        public QuerySeriesRequestOptions()
        {
            ProjectedVariables = new List<string>();
            InlineVariables = new Dictionary<string, TimeSeriesVariable>();
        }
    }
}
