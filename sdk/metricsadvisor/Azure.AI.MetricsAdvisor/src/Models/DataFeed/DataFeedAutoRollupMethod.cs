// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The roll-up method performs an aggregation (for example SUM, MAX, MIN) on each dimension during ingestion. Used to
    /// build a hierarchy which will be used in root case analysis and other diagnostic features.
    /// </summary>
    [CodeGenModel("DataFeedDetailRollUpMethod")]
    public readonly partial struct DataFeedAutoRollupMethod
    {
        /// <summary>
        /// This option means Metrics Advisor doesn't need to roll up the data because, for example, the rows are already summed.
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
