// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
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
    public partial class AzureFirewallResource
    {
        /// <summary> Invokes the PacketCaptureAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete. Please use the overload accepting FirewallPacketCaptureContent instead.")]
        public virtual Task<ArmOperation> PacketCaptureAsync(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the PacketCapture compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete. Please use the overload accepting FirewallPacketCaptureContent instead.")]
        public virtual ArmOperation PacketCapture(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the PacketCaptureOperationAsync compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete. Please use the overload accepting FirewallPacketCaptureContent instead.")]
        public virtual Task<ArmOperation<AzureFirewallPacketCaptureResult>> PacketCaptureOperationAsync(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the PacketCaptureOperation compatibility operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete. Please use the overload accepting FirewallPacketCaptureContent instead.")]
        public virtual ArmOperation<AzureFirewallPacketCaptureResult> PacketCaptureOperation(WaitUntil waitUntil, FirewallPacketCaptureRequestContent content, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
