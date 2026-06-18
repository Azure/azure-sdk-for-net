// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Sql;

namespace Azure.ResourceManager.Sql.Models
{
    public partial class QueryStatisticsProperties
    {
        // Override the Intervals property to make it backward compatible with the previous version of the SDK, IReadOnlyList -> IList.
        /// <summary> List of intervals with appropriate metric data. </summary>
        [WirePath("intervals")]
        public IReadOnlyList<QueryMetricInterval> Intervals { get; } = new ChangeTrackingList<QueryMetricInterval>();
    }
}
