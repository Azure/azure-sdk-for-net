// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.PaloAltoNetworks.Ngfw.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    public partial class LocalRulestackResource
    {
        /// <summary>
        /// List of Firewalls associated with Rulestack
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/PaloAltoNetworks.Cloudngfw/localRulestacks/{localRulestackName}/listFirewalls. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GetFirewalls. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-08. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="LocalRulestackResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<string> GetFirewallsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _localRulestacksRestClient.CreateGetFirewallsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => e.GetString(), _localRulestacksClientDiagnostics, Pipeline, "LocalRulestackResource.GetFirewalls", "value", null, cancellationToken);
        }

        /// <summary>
        /// List of Firewalls associated with Rulestack
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/PaloAltoNetworks.Cloudngfw/localRulestacks/{localRulestackName}/listFirewalls. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> GetFirewalls. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-08. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="LocalRulestackResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<string> GetFirewalls(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            HttpMessage FirstPageRequest(int? pageSizeHint) => _localRulestacksRestClient.CreateGetFirewallsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => e.GetString(), _localRulestacksClientDiagnostics, Pipeline, "LocalRulestackResource.GetFirewalls", "value", null, cancellationToken);
        }
    }
}
