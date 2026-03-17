// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NetworkCloud.Models
{
    public partial class IPAddressPool
    {
        /// <summary> The indicator to prevent the use of IP addresses ending with .0 and .255 for this pool. </summary>
        public BfdEnabled? OnlyUseHostIPs { get; set; }
    }
}
