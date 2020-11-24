// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Configures the behavior of a <see cref="DataFeed"/> when dealing with missing points in
    /// the data ingested from the data source.
    /// </summary>
    public class DataFeedMissingDataPointFillSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedMissingDataPointFillSettings"/> class.
        /// </summary>
        public DataFeedMissingDataPointFillSettings()
        {
        }

        internal DataFeedMissingDataPointFillSettings(DataFeedDetail dataFeedDetail)
        {
            FillType = dataFeedDetail.FillMissingPointType;
            CustomFillValue = dataFeedDetail.FillMissingPointType == DataFeedMissingDataPointFillType.CustomValue
                ? dataFeedDetail.FillMissingPointValue
                : null;
        }

        /// <summary>
        /// The strategy used when filling a missing point.
        /// </summary>
        public DataFeedMissingDataPointFillType? FillType { get; set; }

        /// <summary>
        /// The custom fill value. This property must be set if <see cref="FillType"/> is
        /// <see cref="DataFeedMissingDataPointFillType.CustomValue"/>.
        /// </summary>
        public double? CustomFillValue { get; set; }
    }
}
