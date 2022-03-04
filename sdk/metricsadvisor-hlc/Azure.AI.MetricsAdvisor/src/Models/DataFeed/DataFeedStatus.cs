// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary>
    /// The current ingestion status of a <see cref="DataFeed"/>.
    /// </summary>
    [CodeGenModel("EntityStatus")]
    public readonly partial struct DataFeedStatus
    {
        /// <summary>
        /// The <see cref="DataFeed"/> is active and able to ingest data.
        /// </summary>
        public static DataFeedStatus Active { get; } = new DataFeedStatus(ActiveValue);

        /// <summary>
        /// The <see cref="DataFeed"/> is paused and data ingestion won't take place
        /// until activated again.
        /// </summary>
        public static DataFeedStatus Paused { get; } = new DataFeedStatus(PausedValue);
    }
}
