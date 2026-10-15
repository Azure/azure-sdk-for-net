// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> List of virtual router peer routes. </summary>
    /// <remarks> The scalar properties retain the released single-route representation. They are independent of the historical <see cref="Value"/> collection. </remarks>
    [Obsolete("This class is obsolete and will be removed in a future release, please use `PeerRoute` instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PeerRouteList
    {
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of PeerRouteList. </summary>
        internal PeerRouteList()
        {
            Value = new ChangeTrackingList<PeerRoute>();
        }

        /// <summary> Initializes a new instance of PeerRouteList. </summary>
        /// <param name="value"> List of peer routes. </param>
        internal PeerRouteList(IReadOnlyList<PeerRoute> value)
        {
            Value = value;
        }

        internal PeerRouteList(string localAddress, string network, string nextHop, string sourcePeer, string origin, string asPath, int? weight, IDictionary<string, BinaryData> additionalBinaryDataProperties) : this()
        {
            LocalAddress = localAddress;
            Network = network;
            NextHop = nextHop;
            SourcePeer = sourcePeer;
            Origin = origin;
            AsPath = asPath;
            Weight = weight;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary> The peer's local address. </summary>
        public string LocalAddress { get; }
        /// <summary> The route's network prefix. </summary>
        public string Network { get; }
        /// <summary> The route's next hop. </summary>
        public string NextHop { get; }
        /// <summary> The peer this route was learned from. </summary>
        public string SourcePeer { get; }
        /// <summary> The source this route was learned from. </summary>
        public string Origin { get; }
        /// <summary> The route's AS path sequence. </summary>
        public string AsPath { get; }
        /// <summary> The route's weight. </summary>
        public int? Weight { get; }

        /// <summary> List of peer routes. </summary>
        public IReadOnlyList<PeerRoute> Value { get; }
    }
}
