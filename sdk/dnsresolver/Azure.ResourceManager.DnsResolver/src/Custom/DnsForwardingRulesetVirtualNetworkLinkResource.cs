// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.DnsResolver.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DnsResolver
{
    [CodeGenSuppress("CreateResourceIdentifier", typeof(string), typeof(string), typeof(string), typeof(string))]
    public partial class DnsForwardingRulesetVirtualNetworkLinkResource
    {
        // Backward-compat: preserve the original `rulesetName` parameter name (the
        // generated method, driven by the resource URI template, uses `dnsForwardingRulesetName`).
        // TODO: Remove this workaround once the mgmt generator preserves previously-emitted
        // parameter names on CreateResourceIdentifier.
        /// <summary> Generate the resource identifier of a <see cref="DnsForwardingRulesetVirtualNetworkLinkResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="rulesetName"> The rulesetName. </param>
        /// <param name="virtualNetworkLinkName"> The virtualNetworkLinkName. </param>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string rulesetName, string virtualNetworkLinkName)
        {
            string resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dnsForwardingRulesets/{rulesetName}/virtualNetworkLinks/{virtualNetworkLinkName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}
