// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The roll-up method the service should apply to the ingested data for anomaly detection.
    /// </summary>
    [CodeGenModel("DataFeedDetailRollUpMethod")]
    public readonly partial struct DataFeedAutoRollupMethod
    {
        // TODODOCS: when is this used for?
        /// <summary>
        /// </summary>
        public static DataFeedAutoRollupMethod None { get; } = new DataFeedAutoRollupMethod(NoneValue);

        /// <summary>
        /// The rolled-up column should contain the sum of the ingested values.
        /// </summary>
        public static DataFeedAutoRollupMethod Sum { get; } = new DataFeedAutoRollupMethod(SumValue);

        /// <summary>
        /// The rolled-up column should contain the maximum of the ingested values.
        /// </summary>
        [CodeGenMember("Max")]
        public static DataFeedAutoRollupMethod Maximum { get; } = new DataFeedAutoRollupMethod(MaximumValue);

        /// <summary>
        /// The rolled-up column should contain the minimum of the ingested values.
        /// </summary>
        [CodeGenMember("Min")]
        public static DataFeedAutoRollupMethod Minimum { get; } = new DataFeedAutoRollupMethod(MinimumValue);

        // TODODOCS: double check if it's in fact an arithmetic mean.
        /// <summary>
        /// The rolled-up column should contain the arithmetic mean of the ingested values.
        /// </summary>
        [CodeGenMember("Avg")]
        public static DataFeedAutoRollupMethod Average { get; } = new DataFeedAutoRollupMethod(AverageValue);

        /// <summary>
        /// The rolled-up column should contain the number of occurrences of the ingested values.
        /// </summary>
        public static DataFeedAutoRollupMethod Count { get; } = new DataFeedAutoRollupMethod(CountValue);
    }
}
