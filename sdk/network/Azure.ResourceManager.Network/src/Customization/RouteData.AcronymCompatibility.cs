// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    public partial class RouteData
    {
        // TODO: Remove this workaround after https://github.com/microsoft/typespec/issues/11696 is fixed.
        /// <summary> List of next hop IP addresses for ECMP routing. Must contain between 2 and 64 IP addresses. </summary>
        [CodeGenMember("NextHopIPAddresses")]
        public IList<string> NextHopIpAddresses => Properties?.NextHopIPAddresses;
    }
}
