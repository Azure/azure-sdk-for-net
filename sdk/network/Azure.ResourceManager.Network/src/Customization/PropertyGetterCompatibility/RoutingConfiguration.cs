// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the RoutingConfiguration type. </summary>
    public partial class RoutingConfiguration
    {
        /// <summary> Compatibility member. </summary>
        [System.ObsoleteAttribute("This property is obsolete and might be removed in a future version, please use `TagToIPAddresses` instead", false)]
        public global::System.Collections.Generic.IList<global::Azure.ResourceManager.Network.Models.StaticRoute> StaticRoutes => default;
    }
}
