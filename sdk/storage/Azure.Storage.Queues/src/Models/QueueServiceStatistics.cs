// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueServiceStatistics.
    /// </summary>
    [CodeGenModel("StorageServiceStats")]
    public partial class QueueServiceStatistics
    {
        /// <summary>
        /// GeoReplication
        /// </summary>
        [CodeGenMember("GeoReplication")]
        public QueueGeoReplication GeoReplication { get; internal set;  }
    }
}
