// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The frequency with which ingestion from the data source will occur.
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
        /// The type of <see cref="DataFeedGranularity"/>.
        /// </summary>
        public DataFeedGranularityType GranularityType { get; }

        /// <summary>
        /// The custom granularity value, in seconds. This property must be set if <see cref="GranularityType"/>
        /// is <see cref="DataFeedGranularityType.Custom"/>.
        /// </summary>
        public int? CustomGranularityValue { get; set; }
    }
}
