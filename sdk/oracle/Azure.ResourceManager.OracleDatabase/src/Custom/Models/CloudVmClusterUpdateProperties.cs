// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> The updatable properties of the CloudVmCluster. </summary>
    public partial class CloudVmClusterUpdateProperties
    {
        /// <summary> The local node storage to be allocated in GBs. </summary>
        [CodeGenMember("DbNodeStorageSizeInGbs")]
        public int? DBNodeStorageSizeInGbs { get; set; }

        /// <summary> The list of compute servers to be added to the cloud VM cluster. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ResourceIdentifier> ComputeNodes { get => ComputeNodeOcids?.Select(id => new ResourceIdentifier(id)).ToList(); }
    }
}
