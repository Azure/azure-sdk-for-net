// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudStorageApplianceData
    {
        /// <summary> The information of the certificate authority for the storage appliance. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudCertificateInfo CACertificate => CaCertificate;

        /// <summary> The IPv4 address assigned to the storage appliance management network. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress ManagementIPv4Address => ManagementIpv4Address;
    }
}
