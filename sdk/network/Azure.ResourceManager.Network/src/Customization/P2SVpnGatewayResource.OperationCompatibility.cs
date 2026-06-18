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
    /// <summary> Compatibility declaration for the P2SVpnGatewayResource type. </summary>
    public partial class P2SVpnGatewayResource
    {
        /// <summary> Invokes the DisconnectP2SVpnConnectionsAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> DisconnectP2SVpnConnectionsAsync(WaitUntil waitUntil, P2SVpnConnectionRequest content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the DisconnectP2SVpnConnections compatibility operation. </summary>
        public virtual ArmOperation DisconnectP2SVpnConnections(WaitUntil waitUntil, P2SVpnConnectionRequest content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetP2SVpnConnectionHealthAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<P2SVpnGatewayResource>> GetP2SVpnConnectionHealthAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetP2SVpnConnectionHealth compatibility operation. </summary>
        public virtual ArmOperation<P2SVpnGatewayResource> GetP2SVpnConnectionHealth(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetP2SVpnConnectionHealthDetailedAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<P2SVpnConnectionHealth>> GetP2SVpnConnectionHealthDetailedAsync(WaitUntil waitUntil, P2SVpnConnectionHealthContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetP2SVpnConnectionHealthDetailed compatibility operation. </summary>
        public virtual ArmOperation<P2SVpnConnectionHealth> GetP2SVpnConnectionHealthDetailed(WaitUntil waitUntil, P2SVpnConnectionHealthContent content, CancellationToken cancellationToken) => default;
    }
}
