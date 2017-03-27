// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    public class NextHopType : ExpandableStringEnum<NextHopType>
    {
        public static readonly NextHopType Internet = Parse("Internet");
        public static readonly NextHopType VirtualAppliance = Parse("VirtualAppliance");
        public static readonly NextHopType VirtualNetworkGateway = Parse("VirtualNetworkGateway");
        public static readonly NextHopType OutbouVnetLocalnd = Parse("VnetLocal");
        public static readonly NextHopType HyperNetGateway = Parse("HyperNetGateway");
        public static readonly NextHopType None = Parse("None");
    }
}
