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
    [CodeGenSuppress("GetEffectiveVirtualHubRoutesAsync", typeof(WaitUntil), typeof(EffectiveRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetEffectiveVirtualHubRoutes", typeof(WaitUntil), typeof(EffectiveRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetInboundRoutesAsync", typeof(WaitUntil), typeof(VirtualHubInboundRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetInboundRoutes", typeof(WaitUntil), typeof(VirtualHubInboundRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetOutboundRoutesAsync", typeof(WaitUntil), typeof(VirtualHubOutboundRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetOutboundRoutes", typeof(WaitUntil), typeof(VirtualHubOutboundRoutesContent), typeof(CancellationToken))]
    public partial class VirtualHubResource
    {
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation> GetEffectiveVirtualHubRoutesAsync(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation GetEffectiveVirtualHubRoutes(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation> GetInboundRoutesAsync(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation GetInboundRoutes(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation> GetOutboundRoutesAsync(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation GetOutboundRoutes(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<VirtualHubEffectiveRouteList>> GetVirtualHubEffectiveRoutesAsync(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<VirtualHubEffectiveRouteList> GetVirtualHubEffectiveRoutes(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<EffectiveRouteMapRouteList>> GetVirtualHubInboundRoutesAsync(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<EffectiveRouteMapRouteList> GetVirtualHubInboundRoutes(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<EffectiveRouteMapRouteList>> GetVirtualHubOutboundRoutesAsync(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<EffectiveRouteMapRouteList> GetVirtualHubOutboundRoutes(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
    }
}
