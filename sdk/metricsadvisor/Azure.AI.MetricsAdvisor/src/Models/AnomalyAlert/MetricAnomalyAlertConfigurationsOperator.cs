// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// </summary>
    [CodeGenModel("AnomalyAlertingConfigurationCrossMetricsOperator")]
    public readonly partial struct MetricAnomalyAlertConfigurationsOperator
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("AND")]
        public static DataFeedAutoRollupMethod And { get; } = new DataFeedAutoRollupMethod(AndValue);

        /// <summary>
        /// </summary>
        [CodeGenMember("OR")]
        public static DataFeedAutoRollupMethod Or { get; } = new DataFeedAutoRollupMethod(OrValue);

        /// <summary>
        /// </summary>
        [CodeGenMember("XOR")]
        public static DataFeedAutoRollupMethod Xor { get; } = new DataFeedAutoRollupMethod(XorValue);
    }
}
