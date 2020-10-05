// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The current ingestion status of a <see cref="DataFeed"/>.
    /// </summary>
    [CodeGenModel("DataFeedDetailStatus")]
    public readonly partial struct DataFeedStatus
    {
        // TODO: what is actually paused in a paused data feed? Ingestion? Anomaly detection? Both?

        /// <summary>
        /// The <see cref="DataFeed"/> is active.
        /// </summary>
        public static DataFeedStatus Active { get; } = new DataFeedStatus(ActiveValue);

        /// <summary>
        /// The <see cref="DataFeed"/> is paused.
        /// </summary>
        public static DataFeedStatus Paused { get; } = new DataFeedStatus(PausedValue);

        /// <summary>
        /// Converts this instance into an equivalent <see cref="EntityStatus"/>.
        /// </summary>
        /// <returns>The equivalent <see cref="EntityStatus"/>.</returns>
        /// <remarks>
        /// Currently, the swagger defines two types that are literally the same thing: DataFeedDetailStatus and EntityStatus.
        /// We're exposing both as a single type: <see cref="DataFeedStatus"/>. The service client still requires an
        /// <see cref="EntityStatus"/> in its methods, though, so this method makes conversion easier.
        /// </remarks>
        internal EntityStatus ConvertToEntityStatus() => _value switch
        {
            ActiveValue => EntityStatus.Active,
            PausedValue => EntityStatus.Paused,
            null => new EntityStatus(),
            _ => new EntityStatus(_value)
        };
    }
}
