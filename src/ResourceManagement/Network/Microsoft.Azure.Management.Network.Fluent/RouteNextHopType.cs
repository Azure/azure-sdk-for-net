// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Microsoft.Azure.Management.Resource.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for RouteNextHopType.
    /// </summary>
    public class RouteNextHopType : ExpandableStringEnum<RouteNextHopType>
    {
        public static readonly RouteNextHopType VirtualNetworkGateway = new RouteNextHopType() { Value = "VirtualNetworkGateway" };
        public static readonly RouteNextHopType VirtualNetworkLocal = new RouteNextHopType() { Value = "VnetLocal" };
        public static readonly RouteNextHopType Internet = new RouteNextHopType() { Value = "Internet" };
        public static readonly RouteNextHopType VirtualAppliance = new RouteNextHopType() { Value = "VirtualAppliance" };
        public static readonly RouteNextHopType None = new RouteNextHopType() { Value = "None" };
    }
}
