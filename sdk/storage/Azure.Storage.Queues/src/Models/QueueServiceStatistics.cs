// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Storage.Queues.Models
{
    /// <summary>
    /// QueueServiceStatistics.
    /// </summary>
    public partial class QueueServiceStatistics
    {
        /// <summary>
        /// GeoReplication
        /// </summary>
        public QueueGeoReplication GeoReplication { get; internal set; }
    }
}
