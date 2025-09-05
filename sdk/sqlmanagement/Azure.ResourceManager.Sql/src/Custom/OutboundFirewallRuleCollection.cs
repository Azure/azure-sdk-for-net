// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.Sql
{
    // Add this custom code beacuse the new version doesn't have body data in the PUT operation.
    public partial class OutboundFirewallRuleCollection
    {
        /// <summary>
        /// Create a outbound firewall rule with a given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/outboundFirewallRules/{outboundRuleFqdn}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OutboundFirewallRules_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OutboundFirewallRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="outboundRuleFqdn"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="OutboundFirewallRuleData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="outboundRuleFqdn"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="outboundRuleFqdn"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<OutboundFirewallRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string outboundRuleFqdn, OutboundFirewallRuleData data, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, outboundRuleFqdn, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Create a outbound firewall rule with a given name.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/outboundFirewallRules/{outboundRuleFqdn}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OutboundFirewallRules_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="OutboundFirewallRuleResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="outboundRuleFqdn"> The <see cref="string"/> to use. </param>
        /// <param name="data"> The <see cref="OutboundFirewallRuleData"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="outboundRuleFqdn"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="outboundRuleFqdn"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<OutboundFirewallRuleResource> CreateOrUpdate(WaitUntil waitUntil, string outboundRuleFqdn, OutboundFirewallRuleData data, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, outboundRuleFqdn, cancellationToken);
        }
    }
}
