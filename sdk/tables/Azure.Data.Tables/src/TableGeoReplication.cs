// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Data.Tables.Models
{
    /// <summary> The GeoReplication. </summary>
    [CodeGenModel("GeoReplication")]
    public partial class TableGeoReplication
    {
        /// <summary> A GMT date/time value, to the second. All primary writes preceding this value are guaranteed to be available for read operations at the secondary. Primary writes after this point in time may or may not be available for reads. </summary>
        [CodeGenMember("LastSyncTime")]
        public DateTimeOffset LastSyncedOn { get; }
    }
}
