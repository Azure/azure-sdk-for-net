// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Search.Models
{
    /// <summary> Response from a get service statistics request. If successful, it includes service level counters and limits. </summary>
    public partial class SearchServiceStatistics
    {
        /// <summary> Represents service-level resource counters and quotas. </summary>
        public SearchServiceCounters Counters { get; set; }
        /// <summary> Represents various service level limits. </summary>
        public SearchServiceLimits Limits { get; set; }
    }
}
