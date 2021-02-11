// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The strategy used by a <see cref="DataFeed"/> when filling a missing point in the data
    /// ingested from the data source.
    /// </summary>
    [CodeGenModel("FillMissingPointType")]
    public readonly partial struct DataFeedMissingDataPointFillType
    {
        /// <summary>
        /// Makes use of machine learning trained models to predict a value to the missing point.
        /// </summary>
        public static DataFeedMissingDataPointFillType SmartFilling { get; } = new DataFeedMissingDataPointFillType(SmartFillingValue);

        /// <summary>
        /// Repeats the last ingested value in the same time series.
        /// </summary>
        public static DataFeedMissingDataPointFillType PreviousValue { get; } = new DataFeedMissingDataPointFillType(PreviousValueValue);

        /// <summary>
        /// The data point is set to a predefined custom value. This value can be set with
        /// <see cref="DataFeedMissingDataPointFillSettings.CustomFillValue"/>.
        /// </summary>
        public static DataFeedMissingDataPointFillType CustomValue { get; } = new DataFeedMissingDataPointFillType(CustomValueValue);

        /// <summary>
        /// Do not fill the missing data point and use only the actual ingested points for anomaly
        /// detection.
        /// </summary>
        public static DataFeedMissingDataPointFillType NoFilling { get; } = new DataFeedMissingDataPointFillType(NoFillingValue);
    }
}
