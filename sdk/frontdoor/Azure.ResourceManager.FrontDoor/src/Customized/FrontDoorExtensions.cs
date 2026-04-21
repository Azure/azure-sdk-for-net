// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.FrontDoor
{
    public static partial class FrontDoorExtensions
    {
        /// <summary> Lists all of the protection policies within a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static AsyncPageable<FrontDoorWebApplicationFirewallPolicyResource> GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicyAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableFrontDoorSubscriptionResource(subscriptionResource).GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicyAsync(cancellationToken);
        }

        /// <summary> Lists all of the protection policies within a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource" /> instance the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Pageable<FrontDoorWebApplicationFirewallPolicyResource> GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicy(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableFrontDoorSubscriptionResource(subscriptionResource).GetFrontDoorWebApplicationFirewallPoliciesByFrontDoorWebApplicationFirewallPolicy(cancellationToken);
        }
    }
}
