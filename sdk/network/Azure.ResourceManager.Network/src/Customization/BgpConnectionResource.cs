// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class BgpConnectionResource
    {
        /// <summary> Invokes the GetAdvertisedRoutesVirtualHubBgpConnectionAsync compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetVirtualHubBgpConnectionAdvertisedRoutesAsync` instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<PeerRouteList>> GetAdvertisedRoutesVirtualHubBgpConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetAdvertisedRoutesVirtualHubBgpConnection compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetVirtualHubBgpConnectionAdvertisedRoutes` instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PeerRouteList> GetAdvertisedRoutesVirtualHubBgpConnection(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetLearnedRoutesVirtualHubBgpConnectionAsync compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetVirtualHubBgpConnectionLearnedRoutesAsync` instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<PeerRouteList>> GetLearnedRoutesVirtualHubBgpConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetLearnedRoutesVirtualHubBgpConnection compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetVirtualHubBgpConnectionLearnedRoutes` instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PeerRouteList> GetLearnedRoutesVirtualHubBgpConnection(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        /// <summary> Invokes the GetAdvertisedRoutesAsync compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetVirtualHubBgpConnectionAdvertisedRoutesAsync` instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<IDictionary<string, IList<PeerRouteList>>>> GetAdvertisedRoutesAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        /// <summary> Invokes the GetAdvertisedRoutes compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetVirtualHubBgpConnectionAdvertisedRoutes` instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<IDictionary<string, IList<PeerRouteList>>> GetAdvertisedRoutes(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        /// <summary> Invokes the GetLearnedRoutesAsync compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetVirtualHubBgpConnectionLearnedRoutesAsync` instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<IDictionary<string, IList<PeerRouteList>>>> GetLearnedRoutesAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");

        /// <summary> Invokes the GetLearnedRoutes compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release, please use `GetVirtualHubBgpConnectionLearnedRoutes` instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<IDictionary<string, IList<PeerRouteList>>> GetLearnedRoutes(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
