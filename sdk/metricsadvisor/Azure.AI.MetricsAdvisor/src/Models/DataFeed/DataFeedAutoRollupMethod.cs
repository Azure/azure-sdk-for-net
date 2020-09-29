// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("DataFeedDetailRollUpMethod")]
    public readonly partial struct DataFeedAutoRollupMethod
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("Max")]
        public static DataFeedAutoRollupMethod Maximum { get; } = new DataFeedAutoRollupMethod(MaximumValue);

        /// <summary>
        /// </summary>
        [CodeGenMember("Min")]
        public static DataFeedAutoRollupMethod Minimum { get; } = new DataFeedAutoRollupMethod(MinimumValue);

        /// <summary>
        /// </summary>
        [CodeGenMember("Avg")]
        public static DataFeedAutoRollupMethod Average { get; } = new DataFeedAutoRollupMethod(AverageValue);
    }
}
