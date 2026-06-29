// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ExpressRouteCircuitArpTable type. </summary>
    [CodeGenSuppress("IPAddress")]
    public partial class ExpressRouteCircuitArpTable
    {
        /// <summary> Compatibility member. </summary>
        public global::System.String IPAddress { get; set; }
    }
}
