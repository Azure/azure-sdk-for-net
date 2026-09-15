// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Mocking;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for deprecated Cloud Service operations. </summary>
    public static partial class NetworkExtensions
    {
        private const string CloudServiceDeprecationMessage = "This method is deprecated and will be removed in a future version. CloudService resource has been deprecated, therefore this method is deprecated as well.";

        /// <summary> Gets a collection of network interfaces in a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete(CloudServiceDeprecationMessage, false)]
        public static NetworkInterfaceCollection GetNetworkInterfaces(this ResourceGroupResource resourceGroupResource, string cloudServiceName, string roleInstanceName)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetNetworkInterfaces(cloudServiceName, roleInstanceName);
        }

        /// <summary> Gets a network interface in a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete(CloudServiceDeprecationMessage, false)]
        [ForwardsClientCalls]
        public static Task<Response<NetworkInterfaceResource>> GetNetworkInterfaceAsync(this ResourceGroupResource resourceGroupResource, string cloudServiceName, string roleInstanceName, string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetNetworkInterfaceAsync(cloudServiceName, roleInstanceName, networkInterfaceName, expand, cancellationToken);
        }

        /// <summary> Gets a network interface in a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete(CloudServiceDeprecationMessage, false)]
        [ForwardsClientCalls]
        public static Response<NetworkInterfaceResource> GetNetworkInterface(this ResourceGroupResource resourceGroupResource, string cloudServiceName, string roleInstanceName, string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetNetworkInterface(cloudServiceName, roleInstanceName, networkInterfaceName, expand, cancellationToken);
        }

        /// <summary> Gets all network interfaces in a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete(CloudServiceDeprecationMessage, false)]
        public static AsyncPageable<NetworkInterfaceData> GetCloudServiceNetworkInterfacesAsync(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetCloudServiceNetworkInterfacesAsync(cloudServiceName, cancellationToken);
        }

        /// <summary> Gets all network interfaces in a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete(CloudServiceDeprecationMessage, false)]
        public static Pageable<NetworkInterfaceData> GetCloudServiceNetworkInterfaces(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetCloudServiceNetworkInterfaces(cloudServiceName, cancellationToken);
        }

        /// <summary> Gets all public IP addresses in a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete(CloudServiceDeprecationMessage, false)]
        public static AsyncPageable<PublicIPAddressData> GetCloudServicePublicIPAddressesAsync(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetCloudServicePublicIPAddressesAsync(cloudServiceName, cancellationToken);
        }

        /// <summary> Gets all public IP addresses in a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete(CloudServiceDeprecationMessage, false)]
        public static Pageable<PublicIPAddressData> GetCloudServicePublicIPAddresses(this ResourceGroupResource resourceGroupResource, string cloudServiceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableNetworkResourceGroupResource(resourceGroupResource).GetCloudServicePublicIPAddresses(cloudServiceName, cancellationToken);
        }
    }
}
