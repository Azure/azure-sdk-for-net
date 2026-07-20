// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Subscription.Mocking
{
    public partial class MockableSubscriptionTenantResource : ArmResource
    {
        /// <summary> Gets a collection of BillingAccountPolicyResources in the TenantResource. </summary>
        /// <returns> An object representing collection of BillingAccountPolicyResources and their operations over a BillingAccountPolicyResource. </returns>
        // BillingAccountPolicy is a singleton resource defined in TypeSpec but not in the swagger. So add this function back to ensure the SDK backwards compatibility.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingAccountPolicyCollection GetBillingAccountPolicies()
        {
            return GetCachedClient(client => new BillingAccountPolicyCollection(client, Id));
        }

        /// <summary>
        /// Get Billing Account Policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/providers/Microsoft.Subscription/policies/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingAccount_GetPolicy</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingAccountPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="billingAccountId"> Billing Account Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountId"/> is an empty string, and was expected to be non-empty. </exception>
        // BillingAccountPolicy is a singleton resource defined in TypeSpec but not in the swagger. So add this function back to ensure the SDK backwards compatibility.
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BillingAccountPolicyResource>> GetBillingAccountPolicyAsync(string billingAccountId, CancellationToken cancellationToken = default)
        {
            return await GetBillingAccountPolicies().GetAsync(billingAccountId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Billing Account Policy.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/providers/Microsoft.Subscription/policies/default</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingAccount_GetPolicy</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingAccountPolicyResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="billingAccountId"> Billing Account Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountId"/> is an empty string, and was expected to be non-empty. </exception>
        // BillingAccountPolicy is a singleton resource defined in TypeSpec but not in the swagger. So add this function back to ensure the SDK backwards compatibility.
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BillingAccountPolicyResource> GetBillingAccountPolicy(string billingAccountId, CancellationToken cancellationToken = default)
        {
            return GetBillingAccountPolicies().Get(billingAccountId, cancellationToken);
        }
    }
}
