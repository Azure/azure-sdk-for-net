// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // Backward compat: The old Swagger/AutoRest API exposed OnlyUseHostIPs as a property on
    // IPAddressPool. The new TypeSpec-generated code does not include this property. This file
    // preserves the old property to avoid breaking existing consumers.
    public partial class IPAddressPool
    {
        /// <summary> The indicator to prevent the use of IP addresses ending with .0 and .255 for this pool. </summary>
        public BfdEnabled? OnlyUseHostIPs { get; set; }
    }
}
