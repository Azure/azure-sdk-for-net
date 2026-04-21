// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.FrontDoor.Mocking
{
    public partial class MockableFrontDoorSubscriptionResource
    {
        /// <summary> Lists all of the protection policies within a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<FrontDoorWebApplicationFirewallPolicyResource> GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicyAsync(CancellationToken cancellationToken = default)
        {
            return GetFrontDoorWebApplicationFirewallPoliciesAsync(cancellationToken);
        }

        /// <summary> Lists all of the protection policies within a subscription. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<FrontDoorWebApplicationFirewallPolicyResource> GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicy(CancellationToken cancellationToken = default)
        {
            return GetFrontDoorWebApplicationFirewallPolicies(cancellationToken);
        }
    }
}
