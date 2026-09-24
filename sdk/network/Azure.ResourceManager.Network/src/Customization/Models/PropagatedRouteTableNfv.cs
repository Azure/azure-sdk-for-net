// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenType("PropagatedRouteTable")]
    public partial class PropagatedRouteTableNfv
    {
        /// <summary> Route table resource identifiers. </summary>
        [CodeGenMember("Ids")]
        public IList<RoutingConfigurationNfvSubResource> Ids { get; }
    }
}
