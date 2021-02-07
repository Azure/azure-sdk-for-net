// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor
{
    /// <summary>
    /// Filters the result of the <see cref="MetricsAdvisorAdministrationClient.GetDataFeeds"/> and
    /// <see cref="MetricsAdvisorAdministrationClient.GetDataFeedsAsync"/> operations.
    /// </summary>
    public class GetDataFeedsFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDataFeedsFilter"/> class.
        /// </summary>
        public GetDataFeedsFilter()
        {
        }

        /// <summary>
        /// Filters the result by <see cref="DataFeed.Name"/>.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Filters the result by <see cref="DataFeed.Creator"/>.
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Filters the result by <see cref="DataFeed.Status"/>.
        /// </summary>
        public DataFeedStatus? Status { get; set; }

        /// <summary>
        /// Filters the result by <see cref="DataFeed.SourceType"/>.
        /// </summary>
        public DataFeedSourceType? SourceType { get; set; }

        /// <summary>
        /// Filters the result by <see cref="DataFeedGranularity.GranularityType"/>.
        /// </summary>
        public DataFeedGranularityType? GranularityType { get; set; }
    }
}
