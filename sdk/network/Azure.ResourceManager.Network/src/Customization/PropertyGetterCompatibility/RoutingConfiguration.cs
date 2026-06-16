// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    public partial class RoutingConfiguration
    {
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.StaticRoute> StaticRoutes => default;
    }
}
