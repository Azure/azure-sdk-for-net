// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class AmlComputeNodeInformation
    {
        // Customized: restore legacy all-caps IP aliases.
        [WirePath("privateIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress PrivateIPAddress => PrivateIpAddress;

        /// <summary> Public IP address of the compute node. </summary>
        [WirePath("publicIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress PublicIPAddress => PublicIpAddress;
    }
}
