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
    /// <summary> Compatibility declaration for the VpnGatewayResource type. </summary>
    public partial class VpnGatewayResource
    {
        /// <summary> Invokes the ResetAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<VpnGatewayResource>> ResetAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Reset compatibility operation. </summary>
        public virtual ArmOperation<VpnGatewayResource> Reset(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
    }
}
