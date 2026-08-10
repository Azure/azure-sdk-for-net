// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Preserve the shipped ResourceIdentifier-typed InternetGatewayIds list over the generated string
    // storage under Properties. Removing this would change the public property type/shape.
    public partial class NetworkFabricInternetGatewayRuleData
    {
        /// <summary> List of internet gateway resource IDs. </summary>
        [CodeGenMember("InternetGatewayIds")]
        public IReadOnlyList<ResourceIdentifier> InternetGatewayIds => Properties?.InternetGatewayIds?.Select(id => new ResourceIdentifier(id)).ToList();
    }
}
