// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkSecurityPerimeterData type. </summary>
    public partial class NetworkSecurityPerimeterData
    {
        /// <summary> Invokes the base compatibility operation. </summary>
        public NetworkSecurityPerimeterData(AzureLocation location) : base(location)
        {
        }
    }
}
