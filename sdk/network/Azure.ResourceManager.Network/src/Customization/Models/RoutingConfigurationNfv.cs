// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> NFV version of Routing Configuration indicating the associated and propagated route tables for this connection. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future version. Please use RoutingConfiguration instead.")]
    public partial class RoutingConfigurationNfv
    {
        /// <summary> Initializes a new instance of RoutingConfigurationNfv. </summary>
        public RoutingConfigurationNfv()
        {
        }

        internal RoutingConfigurationNfv(RoutingConfigurationNfvSubResource associatedRouteTable, PropagatedRouteTableNfv propagatedRouteTables, RoutingConfigurationNfvSubResource inboundRouteMap, RoutingConfigurationNfvSubResource outboundRouteMap)
        {
            AssociatedRouteTable = associatedRouteTable;
            PropagatedRouteTables = propagatedRouteTables;
            InboundRouteMap = inboundRouteMap;
            OutboundRouteMap = outboundRouteMap;
        }

        internal RoutingConfigurationNfvSubResource AssociatedRouteTable { get; set; }
        internal RoutingConfigurationNfvSubResource InboundRouteMap { get; set; }
        internal RoutingConfigurationNfvSubResource OutboundRouteMap { get; set; }

        /// <summary> Resource ID. </summary>
        public Uri AssociatedRouteTableResourceUri
        {
            get => AssociatedRouteTable?.ResourceUri;
            set => (AssociatedRouteTable ??= new RoutingConfigurationNfvSubResource()).ResourceUri = value;
        }

        /// <summary> The list of RouteTables to advertise the routes to. </summary>
        public PropagatedRouteTableNfv PropagatedRouteTables { get; set; }

        /// <summary> Resource ID. </summary>
        public Uri InboundRouteMapResourceUri
        {
            get => InboundRouteMap?.ResourceUri;
            set => (InboundRouteMap ??= new RoutingConfigurationNfvSubResource()).ResourceUri = value;
        }

        /// <summary> Resource ID. </summary>
        public Uri OutboundRouteMapResourceUri
        {
            get => OutboundRouteMap?.ResourceUri;
            set => (OutboundRouteMap ??= new RoutingConfigurationNfvSubResource()).ResourceUri = value;
        }
    }
}
