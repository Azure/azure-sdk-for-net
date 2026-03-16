// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;
using Azure.ResourceManager.NetworkCloud.Models;

namespace Azure.ResourceManager.NetworkCloud
{
    public partial class NetworkCloudBareMetalMachineData
    {
        /// <summary> The IPv4 address that is assigned to the bare metal machine during the cluster deployment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress OamIPv4Address => OamIpv4Address;

        /// <summary> The IPv6 address that is assigned to the bare metal machine during the cluster deployment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OamIPv6Address => OamIpv6Address;

        /// <summary> The OS image currently in the machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OSImage => OsImage;

        /// <summary> The information of the certificate authority for the bare metal machine. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NetworkCloudCertificateInfo CACertificate => CaCertificate;
    }
}
