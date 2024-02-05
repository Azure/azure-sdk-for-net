// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> NFV version of Routing Configuration indicating the associated and propagated route tables for this connection. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class RoutingConfigurationNfv
    {
        /// <summary> Initializes a new instance of RoutingConfigurationNfv. </summary>
        public RoutingConfigurationNfv()
        {
        }

        /// <summary> Initializes a new instance of RoutingConfigurationNfv. </summary>
        /// <param name="associatedRouteTable"> The resource id RouteTable associated with this RoutingConfiguration. </param>
        /// <param name="propagatedRouteTables"> The list of RouteTables to advertise the routes to. </param>
        /// <param name="inboundRouteMap"> The resource id of the RouteMap associated with this RoutingConfiguration for inbound learned routes. </param>
        /// <param name="outboundRouteMap"> The resource id of the RouteMap associated with this RoutingConfiguration for outbound advertised routes. </param>
        internal RoutingConfigurationNfv(RoutingConfigurationNfvSubResource associatedRouteTable, PropagatedRouteTableNfv propagatedRouteTables, RoutingConfigurationNfvSubResource inboundRouteMap, RoutingConfigurationNfvSubResource outboundRouteMap)
        {
            AssociatedRouteTable = associatedRouteTable;
            PropagatedRouteTables = propagatedRouteTables;
            InboundRouteMap = inboundRouteMap;
            OutboundRouteMap = outboundRouteMap;
        }

        /// <summary> The resource id RouteTable associated with this RoutingConfiguration. </summary>
        internal RoutingConfigurationNfvSubResource AssociatedRouteTable { get; set; }
        /// <summary> Resource ID. </summary>
        public Uri AssociatedRouteTableResourceUri
        {
            get => AssociatedRouteTable is null ? default : AssociatedRouteTable.ResourceUri;
            set
            {
                if (AssociatedRouteTable is null)
                    AssociatedRouteTable = new RoutingConfigurationNfvSubResource();
                AssociatedRouteTable.ResourceUri = value;
            }
        }

        /// <summary> The list of RouteTables to advertise the routes to. </summary>
        public PropagatedRouteTableNfv PropagatedRouteTables { get; set; }
        /// <summary> The resource id of the RouteMap associated with this RoutingConfiguration for inbound learned routes. </summary>
        internal RoutingConfigurationNfvSubResource InboundRouteMap { get; set; }
        /// <summary> Resource ID. </summary>
        public Uri InboundRouteMapResourceUri
        {
            get => InboundRouteMap is null ? default : InboundRouteMap.ResourceUri;
            set
            {
                if (InboundRouteMap is null)
                    InboundRouteMap = new RoutingConfigurationNfvSubResource();
                InboundRouteMap.ResourceUri = value;
            }
        }

        /// <summary> The resource id of the RouteMap associated with this RoutingConfiguration for outbound advertised routes. </summary>
        internal RoutingConfigurationNfvSubResource OutboundRouteMap { get; set; }
        /// <summary> Resource ID. </summary>
        public Uri OutboundRouteMapResourceUri
        {
            get => OutboundRouteMap is null ? default : OutboundRouteMap.ResourceUri;
            set
            {
                if (OutboundRouteMap is null)
                    OutboundRouteMap = new RoutingConfigurationNfvSubResource();
                OutboundRouteMap.ResourceUri = value;
            }
        }
    }
}
