// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class AmlComputeNodeInformation
    {
        // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
        /// <summary> Private IP Address of this ComputeInstance (local to the VNET in which the compute instance is deployed). </summary>
        [CodeGenMember("PrivateIpAddress")]
        [WirePath("privateIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress PrivateIPAddress { get; }

        /// <summary> Public IP address of the compute node. </summary>
        [CodeGenMember("PublicIpAddress")]
        [WirePath("publicIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IPAddress PublicIPAddress { get; }
    }
}
