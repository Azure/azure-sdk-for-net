// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ServiceGatewayData type. </summary>
    public partial class ServiceGatewayData
    {
        /// <summary> Invokes the this compatibility operation. </summary>
        public ServiceGatewayData(AzureLocation location) : this()
        {
            Location = location;
        }
    }
}
