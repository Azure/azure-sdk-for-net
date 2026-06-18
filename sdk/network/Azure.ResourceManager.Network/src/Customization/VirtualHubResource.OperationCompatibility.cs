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
    /// <summary> Compatibility declaration for the VirtualHubResource type. </summary>
    [CodeGenSuppress("GetEffectiveVirtualHubRoutesAsync", typeof(WaitUntil), typeof(EffectiveRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetEffectiveVirtualHubRoutes", typeof(WaitUntil), typeof(EffectiveRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetInboundRoutesAsync", typeof(WaitUntil), typeof(VirtualHubInboundRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetInboundRoutes", typeof(WaitUntil), typeof(VirtualHubInboundRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetOutboundRoutesAsync", typeof(WaitUntil), typeof(VirtualHubOutboundRoutesContent), typeof(CancellationToken))]
    [CodeGenSuppress("GetOutboundRoutes", typeof(WaitUntil), typeof(VirtualHubOutboundRoutesContent), typeof(CancellationToken))]
    public partial class VirtualHubResource
    {
        /// <summary> Invokes the GetEffectiveVirtualHubRoutesAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation> GetEffectiveVirtualHubRoutesAsync(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetEffectiveVirtualHubRoutes compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation GetEffectiveVirtualHubRoutes(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetInboundRoutesAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation> GetInboundRoutesAsync(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetInboundRoutes compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation GetInboundRoutes(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetOutboundRoutesAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation> GetOutboundRoutesAsync(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetOutboundRoutes compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation GetOutboundRoutes(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVirtualHubEffectiveRoutesAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<VirtualHubEffectiveRouteList>> GetVirtualHubEffectiveRoutesAsync(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVirtualHubEffectiveRoutes compatibility operation. </summary>
        public virtual ArmOperation<VirtualHubEffectiveRouteList> GetVirtualHubEffectiveRoutes(WaitUntil waitUntil, EffectiveRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVirtualHubInboundRoutesAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<EffectiveRouteMapRouteList>> GetVirtualHubInboundRoutesAsync(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVirtualHubInboundRoutes compatibility operation. </summary>
        public virtual ArmOperation<EffectiveRouteMapRouteList> GetVirtualHubInboundRoutes(WaitUntil waitUntil, VirtualHubInboundRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVirtualHubOutboundRoutesAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<EffectiveRouteMapRouteList>> GetVirtualHubOutboundRoutesAsync(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVirtualHubOutboundRoutes compatibility operation. </summary>
        public virtual ArmOperation<EffectiveRouteMapRouteList> GetVirtualHubOutboundRoutes(WaitUntil waitUntil, VirtualHubOutboundRoutesContent content, CancellationToken cancellationToken) => default;
    }
}
