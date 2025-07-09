// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> virtualNetworkAddress resource properties. </summary>
    public partial class CloudVmClusterVirtualNetworkAddressProperties
    {
        /// <summary> Virtual Machine OCID. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier VmOcid { get => new ResourceIdentifier(VipVmOcid); set => VipVmOcid = value.ToString(); }
        /// <summary> Application VIP OCID. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(VipOcid); }
    }
}
