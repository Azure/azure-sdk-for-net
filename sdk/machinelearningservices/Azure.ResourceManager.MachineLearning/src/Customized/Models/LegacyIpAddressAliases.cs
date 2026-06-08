// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat property aliases are grouped to keep related shims together.

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Backward-compat aliases for IP address casing/type changes from TypeSpec generation.
    public partial class AmlComputeNodeInformation
    {
        /// <summary> Private IP address of the compute node. </summary>
        [WirePath("privateIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress PrivateIPAddress => PrivateIpAddress is null ? null : IPAddress.Parse(PrivateIpAddress);

        /// <summary> Public IP address of the compute node. </summary>
        [WirePath("publicIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress PublicIPAddress => PublicIpAddress is null ? null : IPAddress.Parse(PublicIpAddress);
    }

    // Backward-compat aliases for IP address casing changes from TypeSpec generation.
    public partial class MachineLearningComputeInstanceConnectivityEndpoints
    {
        /// <summary> Public IP Address of this ComputeInstance. </summary>
        [WirePath("publicIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PublicIPAddress => PublicIpAddress;

        /// <summary> Private IP Address of this ComputeInstance (local to the VNET in which the compute instance is deployed). </summary>
        [WirePath("privateIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PrivateIPAddress => PrivateIpAddress;
    }

    // Backward-compat alias for IP address casing changes from TypeSpec generation.
    public partial class MachineLearningComputeSystemService
    {
        /// <summary> Public IP address. </summary>
        [WirePath("publicIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PublicIPAddress => PublicIpAddress;
    }
}

#pragma warning restore SA1402
