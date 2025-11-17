// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;

namespace Azure.ResourceManager.PaloAltoNetworks.Ngfw
{
    // The custom code is to make operations pageable
    public partial class LocalRulestackResource
    {
        /// <summary> List of Firewalls associated with Rulestack. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="string"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<string> GetFirewallsAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new LocalRulestacksGetFirewallsAsyncCollectionResultOfT(_localRulestacksRestClient, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
        }

        /// <summary> List of Firewalls associated with Rulestack. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="string"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<string> GetFirewalls(CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new LocalRulestacksGetFirewallsCollectionResultOfT(_localRulestacksRestClient, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
        }
    }
}
