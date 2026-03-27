// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Backward compat: The old Swagger/AutoRest API exposed OSDisk as a settable property on
    // NetworkCloudStorageProfile. The new TypeSpec-generated code does not include this property
    // or uses a different access pattern. This file preserves the old property.
    public partial class NetworkCloudStorageProfile
    {
        /// <summary> The disk to use with this virtual machine. </summary>
        public NetworkCloudOSDisk OSDisk { get; set; }
    }
}
