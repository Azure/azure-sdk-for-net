// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkVirtualApplianceResource type. </summary>
    public partial class NetworkVirtualApplianceResource
    {
        /// <summary> Invokes the RestartAsync compatibility operation. </summary>
        public virtual Task<Response> RestartAsync(NetworkVirtualApplianceInstanceIds content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the Restart compatibility operation. </summary>
        public virtual Response Restart(NetworkVirtualApplianceInstanceIds content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
