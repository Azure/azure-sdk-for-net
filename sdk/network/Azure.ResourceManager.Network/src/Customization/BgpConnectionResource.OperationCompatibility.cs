// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the BgpConnectionResource type. </summary>
    [CodeGenSuppress("GetAdvertisedRoutesAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("GetAdvertisedRoutes", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("GetLearnedRoutesAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("GetLearnedRoutes", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class BgpConnectionResource
    {
        /// <summary> Invokes the GetAdvertisedRoutesVirtualHubBgpConnectionAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<PeerRouteList>> GetAdvertisedRoutesVirtualHubBgpConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetAdvertisedRoutesVirtualHubBgpConnection compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<PeerRouteList> GetAdvertisedRoutesVirtualHubBgpConnection(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetLearnedRoutesVirtualHubBgpConnectionAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<PeerRouteList>> GetLearnedRoutesVirtualHubBgpConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetLearnedRoutesVirtualHubBgpConnection compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<PeerRouteList> GetLearnedRoutesVirtualHubBgpConnection(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVirtualHubBgpConnectionAdvertisedRoutesAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<IDictionary<string, IList<PeerRoute>>>> GetVirtualHubBgpConnectionAdvertisedRoutesAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVirtualHubBgpConnectionAdvertisedRoutes compatibility operation. </summary>
        public virtual ArmOperation<IDictionary<string, IList<PeerRoute>>> GetVirtualHubBgpConnectionAdvertisedRoutes(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVirtualHubBgpConnectionLearnedRoutesAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<IDictionary<string, IList<PeerRoute>>>> GetVirtualHubBgpConnectionLearnedRoutesAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVirtualHubBgpConnectionLearnedRoutes compatibility operation. </summary>
        public virtual ArmOperation<IDictionary<string, IList<PeerRoute>>> GetVirtualHubBgpConnectionLearnedRoutes(WaitUntil waitUntil, CancellationToken cancellationToken) => default;

        // These methods preserve the generated obsolete PeerRouteList return type while keeping obsolete references localized.
        // TODO: Remove this SDK-side workaround after https://github.com/Azure/azure-sdk-for-net/issues/60023 is fixed.
        /// <summary> Invokes the GetAdvertisedRoutesAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual async Task<ArmOperation<IDictionary<string, IList<PeerRouteList>>>> GetAdvertisedRoutesAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _virtualHubBgpConnectionsClientDiagnostics.CreateScope("BgpConnectionResource.GetAdvertisedRoutes");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _virtualHubBgpConnectionsRestClient.CreateGetAdvertisedRoutesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                NetworkArmOperation<IDictionary<string, IList<PeerRouteList>>> operation = new NetworkArmOperation<IDictionary<string, IList<PeerRouteList>>>(
                    new IDictionaryOfStringIListOfPeerRouteListOperationSource(),
                    _virtualHubBgpConnectionsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Invokes the GetAdvertisedRoutes compatibility operation. </summary>

        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<IDictionary<string, IList<PeerRouteList>>> GetAdvertisedRoutes(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _virtualHubBgpConnectionsClientDiagnostics.CreateScope("BgpConnectionResource.GetAdvertisedRoutes");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _virtualHubBgpConnectionsRestClient.CreateGetAdvertisedRoutesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                NetworkArmOperation<IDictionary<string, IList<PeerRouteList>>> operation = new NetworkArmOperation<IDictionary<string, IList<PeerRouteList>>>(
                    new IDictionaryOfStringIListOfPeerRouteListOperationSource(),
                    _virtualHubBgpConnectionsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Invokes the GetLearnedRoutesAsync compatibility operation. </summary>

        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual async Task<ArmOperation<IDictionary<string, IList<PeerRouteList>>>> GetLearnedRoutesAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _virtualHubBgpConnectionsClientDiagnostics.CreateScope("BgpConnectionResource.GetLearnedRoutes");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _virtualHubBgpConnectionsRestClient.CreateGetLearnedRoutesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                NetworkArmOperation<IDictionary<string, IList<PeerRouteList>>> operation = new NetworkArmOperation<IDictionary<string, IList<PeerRouteList>>>(
                    new IDictionaryOfStringIListOfPeerRouteListOperationSource(),
                    _virtualHubBgpConnectionsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        /// <summary> Invokes the GetLearnedRoutes compatibility operation. </summary>

        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<IDictionary<string, IList<PeerRouteList>>> GetLearnedRoutes(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _virtualHubBgpConnectionsClientDiagnostics.CreateScope("BgpConnectionResource.GetLearnedRoutes");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _virtualHubBgpConnectionsRestClient.CreateGetLearnedRoutesRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                NetworkArmOperation<IDictionary<string, IList<PeerRouteList>>> operation = new NetworkArmOperation<IDictionary<string, IList<PeerRouteList>>>(
                    new IDictionaryOfStringIListOfPeerRouteListOperationSource(),
                    _virtualHubBgpConnectionsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
