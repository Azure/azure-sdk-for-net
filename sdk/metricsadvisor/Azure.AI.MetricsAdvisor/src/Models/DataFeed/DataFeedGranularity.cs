// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class DataFeedGranularity
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DataFeedGranularity"/> class.
        /// </summary>
        /// <param name="granularityType"></param>
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
        /// </summary>
        public DataFeedGranularityType GranularityType { get; }

        /// <summary>
        /// The custom granularity value. This property must be set if <see cref="DataFeedGranularity.GranularityType"/> is <see cref="DataFeedGranularityType.Custom"/>.
        /// </summary>
        /// <value></value>
        public int? CustomGranularityValue { get; set; }
    }
}
