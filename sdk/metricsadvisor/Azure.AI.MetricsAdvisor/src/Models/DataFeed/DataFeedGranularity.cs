// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.MetricsAdvisor.Administration;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The frequency with which ingestion from a <see cref="DataFeedSource"/> will occur.
    /// </summary>
    public class DataFeedGranularity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedGranularity"/> class.
        /// </summary>
        /// <param name="granularityType">The type of <see cref="DataFeedGranularity"/>.</param>
        public DataFeedGranularity(DataFeedGranularityType granularityType)
        {
            GranularityType = granularityType;
        }

        internal DataFeedGranularity(DataFeedDetail dataFeedDetail)
        {
            GranularityType = dataFeedDetail.GranularityName;
            CustomGranularityValue = dataFeedDetail.GranularityAmount;
        }

        /// <summary>
        /// The type of <see cref="DataFeedGranularity"/>. <see cref="CustomGranularityValue"/> must be set when
        /// this property is set to <see cref="DataFeedGranularityType.Custom"/>.
        /// </summary>
        public DataFeedGranularityType GranularityType { get; }

        /// <summary>
        /// The custom granularity value, in seconds. This property must be set if <see cref="GranularityType"/>
        /// is <see cref="DataFeedGranularityType.Custom"/>.
        /// </summary>
        /// <remarks>
        /// Once the data feed is created, this property cannot be changed anymore.
        /// </remarks>
        public int? CustomGranularityValue { get; set; }
    }
}
