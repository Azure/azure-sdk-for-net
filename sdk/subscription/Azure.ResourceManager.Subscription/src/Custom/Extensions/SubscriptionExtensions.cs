// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Subscription.Mocking;

namespace Azure.ResourceManager.Subscription
{
    public static partial class SubscriptionExtensions
    {
        /// <summary>
        /// Gets a collection of BillingAccountPolicyResources in the TenantResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableSubscriptionTenantResource.GetBillingAccountPolicies()"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> is null. </exception>
        /// <returns> An object representing collection of BillingAccountPolicyResources and their operations over a BillingAccountPolicyResource. </returns>
        // BillingAccountPolicy is a singleton resource defined in TypeSpec but not in the swagger. So add this function back to ensure the SDK backwards compatibility.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingAccountPolicyCollection GetBillingAccountPolicies(this TenantResource tenantResource)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableSubscriptionTenantResource(tenantResource).GetBillingAccountPolicies();
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableSubscriptionTenantResource.GetBillingAccountPolicyAsync(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountId"> Billing Account Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="billingAccountId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountId"/> is an empty string, and was expected to be non-empty. </exception>
        // BillingAccountPolicy is a singleton resource defined in TypeSpec but not in the swagger. So add this function back to ensure the SDK backwards compatibility.
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<BillingAccountPolicyResource>> GetBillingAccountPolicyAsync(this TenantResource tenantResource, string billingAccountId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockableSubscriptionTenantResource(tenantResource).GetBillingAccountPolicyAsync(billingAccountId, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableSubscriptionTenantResource.GetBillingAccountPolicy(string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountId"> Billing Account Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="billingAccountId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountId"/> is an empty string, and was expected to be non-empty. </exception>
        // BillingAccountPolicy is a singleton resource defined in TypeSpec but not in the swagger. So add this function back to ensure the SDK backwards compatibility.
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<BillingAccountPolicyResource> GetBillingAccountPolicy(this TenantResource tenantResource, string billingAccountId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableSubscriptionTenantResource(tenantResource).GetBillingAccountPolicy(billingAccountId, cancellationToken);
        }
    }
}
