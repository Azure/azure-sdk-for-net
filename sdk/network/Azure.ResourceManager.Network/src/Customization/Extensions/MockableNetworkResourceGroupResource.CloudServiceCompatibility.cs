// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network.Mocking
{
    /// <summary> Compatibility declaration for deprecated Cloud Service operations. </summary>
    public partial class MockableNetworkResourceGroupResource
    {
        private const string CloudServiceDeprecationMessage = "This method is deprecated and will be removed in a future version. CloudService resource has been deprecated, therefore this method is deprecated as well.";

        /// <summary> Gets a collection of network interfaces in a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceDeprecationMessage, false)]
        public virtual NetworkInterfaceCollection GetNetworkInterfaces(string cloudServiceName, string roleInstanceName)
            => throw new NotSupportedException(CloudServiceDeprecationMessage);

        /// <summary> Gets a network interface in a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceDeprecationMessage, false)]
        [ForwardsClientCalls]
        public virtual Task<Response<NetworkInterfaceResource>> GetNetworkInterfaceAsync(string cloudServiceName, string roleInstanceName, string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceDeprecationMessage);

        /// <summary> Gets a network interface in a Cloud Service role instance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceDeprecationMessage, false)]
        [ForwardsClientCalls]
        public virtual Response<NetworkInterfaceResource> GetNetworkInterface(string cloudServiceName, string roleInstanceName, string networkInterfaceName, string expand = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceDeprecationMessage);

        /// <summary> Gets all network interfaces in a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceDeprecationMessage, false)]
        public virtual AsyncPageable<NetworkInterfaceData> GetCloudServiceNetworkInterfacesAsync(string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceDeprecationMessage);

        /// <summary> Gets all network interfaces in a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceDeprecationMessage, false)]
        public virtual Pageable<NetworkInterfaceData> GetCloudServiceNetworkInterfaces(string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceDeprecationMessage);

        /// <summary> Gets all public IP addresses in a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceDeprecationMessage, false)]
        public virtual AsyncPageable<PublicIPAddressData> GetCloudServicePublicIPAddressesAsync(string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceDeprecationMessage);

        /// <summary> Gets all public IP addresses in a Cloud Service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete(CloudServiceDeprecationMessage, false)]
        public virtual Pageable<PublicIPAddressData> GetCloudServicePublicIPAddresses(string cloudServiceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException(CloudServiceDeprecationMessage);
    }
}
