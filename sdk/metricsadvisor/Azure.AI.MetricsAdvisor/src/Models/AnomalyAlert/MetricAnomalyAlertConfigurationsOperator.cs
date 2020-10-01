// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The operator to be applied between <see cref="MetricAnomalyAlertConfiguration"/>s in the same
    /// <see cref="AnomalyAlertConfiguration"/> instance.
    /// </summary>
    [CodeGenModel("AnomalyAlertingConfigurationCrossMetricsOperator")]
    public readonly partial struct MetricAnomalyAlertConfigurationsOperator
    {
        /// <summary>
        /// The data point will trigger an alert if every <see cref="MetricAnomalyAlertConfiguration"/> defined
        /// in <see cref="AnomalyAlertConfiguration"/> is satisfied. Keep in mind that, if two
        /// <see cref="MetricAnomalyAlertConfiguration"/>s have different dimension names, an alert will never
        /// be triggered.
        /// </summary>
        [CodeGenMember("AND")]
        public static DataFeedAutoRollupMethod And { get; } = new DataFeedAutoRollupMethod(AndValue);

        /// <summary>
        /// The data point will trigger an alert if at least one <see cref="MetricAnomalyAlertConfiguration"/>
        /// defined in <see cref="AnomalyAlertConfiguration"/> is satisfied.
        /// </summary>
        [CodeGenMember("OR")]
        public static DataFeedAutoRollupMethod Or { get; } = new DataFeedAutoRollupMethod(OrValue);

        /// <summary>
        /// A XOR operation is applied across <see cref="MetricAnomalyAlertConfiguration"/>s defined in
        /// <see cref="AnomalyAlertConfiguration"/>. In simple terms, an alert will be triggered if an
        /// odd number of <see cref="MetricAnomalyAlertConfiguration"/>s are satisfied.
        /// </summary>
        [CodeGenMember("XOR")]
        public static DataFeedAutoRollupMethod Xor { get; } = new DataFeedAutoRollupMethod(XorValue);
    }
}
