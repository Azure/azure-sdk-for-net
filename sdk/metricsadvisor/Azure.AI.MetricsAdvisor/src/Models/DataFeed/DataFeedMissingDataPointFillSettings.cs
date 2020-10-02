// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    public class DataFeedMissingDataPointFillSettings
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DataFeedMissingDataPointFillSettings"/> class.
        /// </summary>
        public DataFeedMissingDataPointFillSettings()
        { }

        internal DataFeedMissingDataPointFillSettings(DataFeedDetail dataFeedDetail)
        {
            FillType = dataFeedDetail.FillMissingPointType;
            CustomFillValue = dataFeedDetail.FillMissingPointValue;
        }

        /// <summary>
        /// </summary>
        public DataFeedMissingDataPointFillType? FillType { get; set; }

        /// <summary>
        /// </summary>
        public double? CustomFillValue { get; set; }
    }
}
