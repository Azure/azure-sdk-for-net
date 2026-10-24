// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class BgpConnectionResource
    {
        // These released deprecated APIs already threw in 1.15 because their response shape was retired.
        /// <summary> Invokes the GetAdvertisedRoutesVirtualHubBgpConnectionAsync compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<PeerRouteList>> GetAdvertisedRoutesVirtualHubBgpConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => Task.FromException<ArmOperation<PeerRouteList>>(new NotSupportedException("This method is obsolete and will be removed in a future release"));
        /// <summary> Invokes the GetAdvertisedRoutesVirtualHubBgpConnection compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PeerRouteList> GetAdvertisedRoutesVirtualHubBgpConnection(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This method is obsolete and will be removed in a future release");
        /// <summary> Invokes the GetLearnedRoutesVirtualHubBgpConnectionAsync compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<PeerRouteList>> GetLearnedRoutesVirtualHubBgpConnectionAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default) => Task.FromException<ArmOperation<PeerRouteList>>(new NotSupportedException("This method is obsolete and will be removed in a future release"));
        /// <summary> Invokes the GetLearnedRoutesVirtualHubBgpConnection compatibility operation. </summary>
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<PeerRouteList> GetLearnedRoutesVirtualHubBgpConnection(WaitUntil waitUntil, CancellationToken cancellationToken = default) => throw new NotSupportedException("This method is obsolete and will be removed in a future release");
    }
}
