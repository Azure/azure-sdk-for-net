// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    /// <summary>
    /// Defines values for RouteNextHopType.
    /// </summary>
    public class RouteNextHopType : ExpandableStringEnum<RouteNextHopType>
    {
        public static readonly RouteNextHopType VirtualNetworkGateway = Parse("VirtualNetworkGateway");
        public static readonly RouteNextHopType VirtualNetworkLocal = Parse("VnetLocal");
        public static readonly RouteNextHopType Internet = Parse("Internet");
        public static readonly RouteNextHopType VirtualAppliance = Parse("VirtualAppliance");
        public static readonly RouteNextHopType None = Parse("None");
    }
}
