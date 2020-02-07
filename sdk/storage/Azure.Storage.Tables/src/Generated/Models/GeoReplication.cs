// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.Storage.Tables.Models
{
    /// <summary> The GeoReplication. </summary>
    public partial class GeoReplication
    {
        /// <summary> The status of the secondary location. </summary>
        public GeoReplicationStatusType Status { get; set; }
        /// <summary> A GMT date/time value, to the second. All primary writes preceding this value are guaranteed to be available for read operations at the secondary. Primary writes after this point in time may or may not be available for reads. </summary>
        public DateTimeOffset LastSyncTime { get; set; }
    }
}
