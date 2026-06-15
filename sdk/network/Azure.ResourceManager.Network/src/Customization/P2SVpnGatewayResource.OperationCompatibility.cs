// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

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
    public partial class P2SVpnGatewayResource
    {
        public virtual Task<ArmOperation> DisconnectP2SVpnConnectionsAsync(WaitUntil waitUntil, P2SVpnConnectionRequest content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation DisconnectP2SVpnConnections(WaitUntil waitUntil, P2SVpnConnectionRequest content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<P2SVpnGatewayResource>> GetP2SVpnConnectionHealthAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<P2SVpnGatewayResource> GetP2SVpnConnectionHealth(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<P2SVpnConnectionHealth>> GetP2SVpnConnectionHealthDetailedAsync(WaitUntil waitUntil, P2SVpnConnectionHealthContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<P2SVpnConnectionHealth> GetP2SVpnConnectionHealthDetailed(WaitUntil waitUntil, P2SVpnConnectionHealthContent content, CancellationToken cancellationToken) => default;
    }
}
