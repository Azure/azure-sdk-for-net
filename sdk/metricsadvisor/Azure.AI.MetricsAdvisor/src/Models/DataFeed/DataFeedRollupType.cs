// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The strategy used by a <see cref="DataFeed"/> when rolling-up the ingested data before
    /// detecting anomalies.
    /// </summary>
    [CodeGenModel("NeedRollupEnum")]
    public readonly partial struct DataFeedRollupType
    {
        /// <summary>
        /// No roll-up will be applied for anomaly detection.
        /// </summary>
        [CodeGenMember("NoRollup")]
        public static DataFeedRollupType NoRollupNeeded { get; } = new DataFeedRollupType(NoRollupNeededValue);

        /// <summary>
        /// Let the service do the roll-up. The roll-up method must be set with
        /// <see cref="DataFeedRollupSettings.AutoRollupMethod"/>, and the rolled-up dimension value with
        /// <see cref="DataFeedRollupSettings.RollupIdentificationValue"/>.
        /// </summary>
        [CodeGenMember("NeedRollup")]
        public static DataFeedRollupType RollupNeeded { get; } = new DataFeedRollupType(RollupNeededValue);

        /// <summary>
        /// The data source already provides rolled-up values, and the service should use them.
        /// <see cref="DataFeedRollupSettings.RollupIdentificationValue"/> must be set to help the
        /// service identify which dimension value corresponds to the rolled-up data.
        /// </summary>
        [CodeGenMember("AlreadyRollup")]
        public static DataFeedRollupType AlreadyRolledUp { get; } = new DataFeedRollupType(AlreadyRolledUpValue);
    }
}
