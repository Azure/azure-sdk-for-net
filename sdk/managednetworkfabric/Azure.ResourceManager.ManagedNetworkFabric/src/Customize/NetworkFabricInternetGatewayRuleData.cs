// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkFabricInternetGatewayRuleData
    {
        /// <summary> List of internet gateway resource IDs. </summary>
        [CodeGenMember("InternetGatewayIds")]
        public IReadOnlyList<ResourceIdentifier> InternetGatewayIds => Properties?.InternetGatewayIds?.Select(id => new ResourceIdentifier(id)).ToList();
    }
}
