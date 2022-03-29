// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.MetricsAdvisor.Administration;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// Configures the behavior of a <see cref="DataFeed"/> when handling missing points in
    /// the data ingested from its <see cref="DataFeedSource"/>.
    /// </summary>
    public class DataFeedMissingDataPointFillSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFeedMissingDataPointFillSettings"/> class.
        /// </summary>
        /// <param name="fillType">The strategy used when filling a missing point.</param>
        public DataFeedMissingDataPointFillSettings(DataFeedMissingDataPointFillType fillType)
        {
            FillType = fillType;
        }

        internal DataFeedMissingDataPointFillSettings(DataFeedDetail dataFeedDetail)
        {
            FillType = dataFeedDetail.FillMissingPointType.Value;
            CustomFillValue = dataFeedDetail.FillMissingPointType == DataFeedMissingDataPointFillType.CustomValue
                ? dataFeedDetail.FillMissingPointValue
                : null;
        }

        /// <summary>
        /// The strategy used when filling a missing point. <see cref="CustomFillValue"/> must be set when
        /// this property is set to <see cref="DataFeedMissingDataPointFillType.CustomValue"/>.
        /// </summary>
        public DataFeedMissingDataPointFillType FillType { get; set; }

        /// <summary>
        /// The custom fill value. This property must be set if <see cref="FillType"/> is
        /// <see cref="DataFeedMissingDataPointFillType.CustomValue"/>.
        /// </summary>
        public double? CustomFillValue { get; set; }
    }
}
