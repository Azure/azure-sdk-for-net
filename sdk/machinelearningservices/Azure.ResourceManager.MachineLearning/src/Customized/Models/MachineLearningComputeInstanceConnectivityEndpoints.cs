// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy IP address aliases whose casing/type differs from TypeSpec naming.
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

    // Customized: restore legacy IP address alias whose casing differs from TypeSpec naming.
}
