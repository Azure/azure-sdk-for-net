// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.MetricsAdvisor.Models;

namespace Azure.AI.MetricsAdvisor.Administration
{
    /// <summary>
    /// Filters the result of the <see cref="MetricsAdvisorAdministrationClient.GetDataFeeds"/> and
    /// <see cref="MetricsAdvisorAdministrationClient.GetDataFeedsAsync"/> operations.
    /// </summary>
    public class DataFeedFilter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedFilter"/> class.
        /// </summary>
        public DataFeedFilter()
        {
        }

        /// <summary>
        /// Filters the result by <see cref="DataFeed.Name"/>. Only data feeds containing the filter as a
        /// substring of their names will be returned. Case insensitive.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Filters the result by <see cref="DataFeed.Creator"/>. Only data feeds containing the filter as a
        /// substring of their creators will be returned. Case insensitive.
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// Filters the result by <see cref="DataFeed.Status"/>.
        /// </summary>
        public DataFeedStatus? Status { get; set; }

        /// <summary>
        /// Filters the result by the kind of the <see cref="DataFeedSource"/>.
        /// </summary>
        public DataFeedSourceKind? SourceKind { get; set; }

        /// <summary>
        /// Filters the result by <see cref="DataFeedGranularity.GranularityType"/>.
        /// </summary>
        public DataFeedGranularityType? GranularityType { get; set; }
    }
}
