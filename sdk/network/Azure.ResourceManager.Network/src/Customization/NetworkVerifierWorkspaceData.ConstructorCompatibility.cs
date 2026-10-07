// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkVerifierWorkspaceData type. </summary>
    public partial class NetworkVerifierWorkspaceData
    {
        /// <summary> Invokes the this compatibility operation. </summary>
        public NetworkVerifierWorkspaceData(AzureLocation location) : this()
        {
            Location = location;
        }
    }
}
