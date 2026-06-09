// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy IP address aliases whose casing/type differs from TypeSpec naming.
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

    // Customized: restore legacy IP address aliases whose casing differs from TypeSpec naming.
}
