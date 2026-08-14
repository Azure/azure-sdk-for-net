// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Sql;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class QueryStatistics : ResourceData
    {
        // Override the Intervals property to make it backward compatible with the previous version of the SDK, IReadOnlyList -> IList.
        /// <summary> List of intervals with appropriate metric data. </summary>
        [WirePath("properties.intervals")]
        public IList<QueryMetricInterval> Intervals
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new QueryStatisticsProperties();
                }
                return Properties.Intervals as IList<QueryMetricInterval>;
            }
        }
    }
}
