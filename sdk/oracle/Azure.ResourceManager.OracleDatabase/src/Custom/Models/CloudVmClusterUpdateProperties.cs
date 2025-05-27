// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> The updatable properties of the CloudVmCluster. </summary>
    public partial class CloudVmClusterUpdateProperties
    {
        /// <summary> The local node storage to be allocated in GBs. </summary>
        [CodeGenMember("DbNodeStorageSizeInGbs")]
        public int? DBNodeStorageSizeInGbs { get; set; }
    }
}
