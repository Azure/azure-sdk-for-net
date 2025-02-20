// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Billing.Mocking
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    public partial class MockableBillingTenantResource : ArmResource
    {
        /// <summary> Gets a collection of BillingAccountPaymentMethodResources in the TenantResource. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of BillingAccountPaymentMethodResources and their operations over a BillingAccountPaymentMethodResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingAccountPaymentMethodCollection GetBillingAccountPaymentMethods(string billingAccountName)
        {
            return new BillingAccountPaymentMethodCollection(Client, new ResourceIdentifier($"{Id.ToString()}/billingAccounts/{billingAccountName}"));
        }

        /// <summary>
        /// Gets a payment method available for a billing account. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/paymentMethods/{paymentMethodName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PaymentMethods_GetByBillingAccount</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingAccountPaymentMethodResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="paymentMethodName"> The ID that uniquely identifies a payment method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="paymentMethodName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="paymentMethodName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BillingAccountPaymentMethodResource>> GetBillingAccountPaymentMethodAsync(string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return await GetBillingAccountPaymentMethods(billingAccountName).GetAsync(paymentMethodName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a payment method available for a billing account. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/paymentMethods/{paymentMethodName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PaymentMethods_GetByBillingAccount</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingAccountPaymentMethodResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="paymentMethodName"> The ID that uniquely identifies a payment method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="paymentMethodName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="paymentMethodName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BillingAccountPaymentMethodResource> GetBillingAccountPaymentMethod(string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return GetBillingAccountPaymentMethods(billingAccountName).Get(paymentMethodName, cancellationToken);
        }

        /// <summary> Gets a collection of BillingPaymentMethodLinkResources in the TenantResource. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="billingProfileName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="billingProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of BillingPaymentMethodLinkResources and their operations over a BillingPaymentMethodLinkResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingPaymentMethodLinkCollection GetBillingPaymentMethodLinks(string billingAccountName, string billingProfileName)
        {
            return new BillingPaymentMethodLinkCollection(Client, new ResourceIdentifier($"{Id.ToString()}/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}"));
        }

        /// <summary>
        /// Gets a payment method linked with a billing profile. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/paymentMethodLinks/{paymentMethodName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PaymentMethods_GetByBillingProfile</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingPaymentMethodLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        /// <param name="paymentMethodName"> The ID that uniquely identifies a payment method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BillingPaymentMethodLinkResource>> GetBillingPaymentMethodLinkAsync(string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return await GetBillingPaymentMethodLinks(billingAccountName, billingProfileName).GetAsync(paymentMethodName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a payment method linked with a billing profile. The operation is supported only for billing accounts with agreement type Microsoft Customer Agreement.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/paymentMethodLinks/{paymentMethodName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PaymentMethods_GetByBillingProfile</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingPaymentMethodLinkResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        /// <param name="paymentMethodName"> The ID that uniquely identifies a payment method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BillingPaymentMethodLinkResource> GetBillingPaymentMethodLink(string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return GetBillingPaymentMethodLinks(billingAccountName, billingProfileName).Get(paymentMethodName, cancellationToken);
        }

        /// <summary> Gets a collection of BillingSubscriptionResources in the TenantResource. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of BillingSubscriptionResources and their operations over a BillingSubscriptionResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingSubscriptionCollection GetBillingSubscriptions(string billingAccountName)
        {
            return new BillingSubscriptionCollection(Client, new ResourceIdentifier($"{Id.ToString()}/billingAccounts/{billingAccountName}"));
        }

        /// <summary>
        /// Gets a subscription by its ID. The operation is currently supported for billing accounts with agreement type Microsoft Customer Agreement, Microsoft Partner Agreement and Microsoft Online Services Program.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingSubscriptions/{billingSubscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingSubscriptions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingSubscriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingSubscriptionName"> The ID that uniquely identifies a subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="billingSubscriptionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="billingSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BillingSubscriptionResource>> GetBillingSubscriptionAsync(string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            return await GetBillingSubscriptions(billingAccountName).GetAsync(billingSubscriptionName, null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a subscription by its ID. The operation is currently supported for billing accounts with agreement type Microsoft Customer Agreement, Microsoft Partner Agreement and Microsoft Online Services Program.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingSubscriptions/{billingSubscriptionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingSubscriptions_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingSubscriptionResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingSubscriptionName"> The ID that uniquely identifies a subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="billingSubscriptionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="billingSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BillingSubscriptionResource> GetBillingSubscription(string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            return GetBillingSubscriptions(billingAccountName).Get(billingSubscriptionName, null, cancellationToken);
        }

        /// <summary> Gets a collection of BillingSubscriptionAliasResources in the TenantResource. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of BillingSubscriptionAliasResources and their operations over a BillingSubscriptionAliasResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingSubscriptionAliasCollection GetBillingSubscriptionAliases(string billingAccountName)
        {
            return new BillingSubscriptionAliasCollection(Client, new ResourceIdentifier($"{Id.ToString()}/billingAccounts/{billingAccountName}"));
        }

        /// <summary>
        /// Gets a subscription by its alias ID.  The operation is supported for seat based billing subscriptions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingSubscriptionAliases/{aliasName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingSubscriptionsAliases_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingSubscriptionAliasResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="aliasName"> The ID that uniquely identifies a subscription alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="aliasName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="aliasName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<BillingSubscriptionAliasResource>> GetBillingSubscriptionAliasAsync(string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            return await GetBillingSubscriptionAliases(billingAccountName).GetAsync(aliasName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets a subscription by its alias ID.  The operation is supported for seat based billing subscriptions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingSubscriptionAliases/{aliasName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>BillingSubscriptionsAliases_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingSubscriptionAliasResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="aliasName"> The ID that uniquely identifies a subscription alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="billingAccountName"/> or <paramref name="aliasName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="aliasName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<BillingSubscriptionAliasResource> GetBillingSubscriptionAlias(string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            return GetBillingSubscriptionAliases(billingAccountName).Get(aliasName, cancellationToken);
        }
    }
}
