// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Net;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version added a required constructor parameter (networkDeviceSku). This preserves the
    // old constructor signature from v1.1.2 that only required location. Removing this file would also
    // drop the shipped ManagementIPv4Address/ManagementIPv6Address aliases.
    public partial class NetworkDeviceData
    {
        /// <summary> Initializes a new instance of <see cref="NetworkDeviceData"/>. </summary>
        /// <param name="location"> The location. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This constructor is obsolete and will be removed in a future version.")]
        public NetworkDeviceData(AzureLocation location) : this(location, default)
        {
        }

        /// <summary> Management IPv4 Address. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ManagementIPv4Address is deprecated, use ManagementIpv4Address instead.")]
        public IPAddress ManagementIPv4Address => IPAddress.TryParse(ManagementIpv4Address, out IPAddress address) ? address : null;

        /// <summary> Management IPv6 Address. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("ManagementIPv6Address is deprecated, use ManagementIpv6Address instead.")]
        public string ManagementIPv6Address => ManagementIpv6Address;

        /// <summary> Reference to network rack resource id. </summary>
        [CodeGenMember("NetworkRackId")]
        public ResourceIdentifier NetworkRackId => Properties?.NetworkRackId is null ? default : new ResourceIdentifier(Properties.NetworkRackId);
    }
}
