// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Net;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    public partial class MachineLearningComputeInstanceConnectivityEndpoints
    {
        // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
        /// <summary> Public IP Address of this ComputeInstance. </summary>
        [CodeGenMember("PublicIpAddress")]
        [WirePath("publicIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PublicIPAddress { get; }

        /// <summary> Private IP Address of this ComputeInstance (local to the VNET in which the compute instance is deployed). </summary>
        [CodeGenMember("PrivateIpAddress")]
        [WirePath("privateIpAddress")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PrivateIPAddress { get; }
    }
}
