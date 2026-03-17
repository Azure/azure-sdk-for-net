// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class NetworkCloudStorageProfile
    {
        /// <summary> The disk to use with this virtual machine. </summary>
        public NetworkCloudOSDisk OSDisk { get; set; }
    }
}
