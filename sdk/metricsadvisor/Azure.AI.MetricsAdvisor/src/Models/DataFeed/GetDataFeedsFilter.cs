// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class GetDataFeedsFilter
    {
        /// <summary>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// </summary>
        public DataFeedStatus? Status { get; set; }

        /// <summary>
        /// </summary>
        public DataFeedSourceType? SourceType { get; set; }

        /// <summary>
        /// </summary>
        public DataFeedGranularityType? GranularityType { get; set; }
    }
}
