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
    /// <summary> Compatibility declaration for the AzureFirewallResource type. </summary>
    public partial class AzureFirewallResource
    {
        /// <summary> Invokes the PacketCaptureAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> PacketCaptureAsync(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the PacketCapture compatibility operation. </summary>
        public virtual ArmOperation PacketCapture(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the PacketCaptureOperationAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<AzureFirewallPacketCaptureResult>> PacketCaptureOperationAsync(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the PacketCaptureOperation compatibility operation. </summary>
        public virtual ArmOperation<AzureFirewallPacketCaptureResult> PacketCaptureOperation(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => default;
    }
}
