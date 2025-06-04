// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Billing.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Billing
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Billing. </summary>
    public static partial class BillingExtensions
    {
        /// <summary>
        /// Gets a collection of BillingAccountPaymentMethodResources in the TenantResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingAccountPaymentMethods(string)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="billingAccountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of BillingAccountPaymentMethodResources and their operations over a BillingAccountPaymentMethodResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingAccountPaymentMethodCollection GetBillingAccountPaymentMethods(this TenantResource tenantResource, string billingAccountName)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableBillingTenantResource(tenantResource).GetBillingAccountPaymentMethods(billingAccountName);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingAccountPaymentMethodAsync(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="paymentMethodName"> The ID that uniquely identifies a payment method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/>, <paramref name="billingAccountName"/> or <paramref name="paymentMethodName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="paymentMethodName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<BillingAccountPaymentMethodResource>> GetBillingAccountPaymentMethodAsync(this TenantResource tenantResource, string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockableBillingTenantResource(tenantResource).GetBillingAccountPaymentMethodAsync(billingAccountName, paymentMethodName, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingAccountPaymentMethod(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="paymentMethodName"> The ID that uniquely identifies a payment method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/>, <paramref name="billingAccountName"/> or <paramref name="paymentMethodName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="paymentMethodName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<BillingAccountPaymentMethodResource> GetBillingAccountPaymentMethod(this TenantResource tenantResource, string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableBillingTenantResource(tenantResource).GetBillingAccountPaymentMethod(billingAccountName, paymentMethodName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of BillingPaymentMethodLinkResources in the TenantResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingPaymentMethodLinks(string,string)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/>, <paramref name="billingAccountName"/> or <paramref name="billingProfileName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="billingProfileName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of BillingPaymentMethodLinkResources and their operations over a BillingPaymentMethodLinkResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingPaymentMethodLinkCollection GetBillingPaymentMethodLinks(this TenantResource tenantResource, string billingAccountName, string billingProfileName)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableBillingTenantResource(tenantResource).GetBillingPaymentMethodLinks(billingAccountName, billingProfileName);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingPaymentMethodLinkAsync(string,string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        /// <param name="paymentMethodName"> The ID that uniquely identifies a payment method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/>, <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<BillingPaymentMethodLinkResource>> GetBillingPaymentMethodLinkAsync(this TenantResource tenantResource, string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockableBillingTenantResource(tenantResource).GetBillingPaymentMethodLinkAsync(billingAccountName, billingProfileName, paymentMethodName, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingPaymentMethodLink(string,string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        /// <param name="paymentMethodName"> The ID that uniquely identifies a payment method. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/>, <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/>, <paramref name="billingProfileName"/> or <paramref name="paymentMethodName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<BillingPaymentMethodLinkResource> GetBillingPaymentMethodLink(this TenantResource tenantResource, string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableBillingTenantResource(tenantResource).GetBillingPaymentMethodLink(billingAccountName, billingProfileName, paymentMethodName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of BillingSubscriptionResources in the TenantResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingSubscriptions(string)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="billingAccountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of BillingSubscriptionResources and their operations over a BillingSubscriptionResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingSubscriptionCollection GetBillingSubscriptions(this TenantResource tenantResource, string billingAccountName)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptions(billingAccountName);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingSubscriptionAsync(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingSubscriptionName"> The ID that uniquely identifies a subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/>, <paramref name="billingAccountName"/> or <paramref name="billingSubscriptionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="billingSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<BillingSubscriptionResource>> GetBillingSubscriptionAsync(this TenantResource tenantResource, string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptionAsync(billingAccountName, billingSubscriptionName, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingSubscription(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingSubscriptionName"> The ID that uniquely identifies a subscription. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/>, <paramref name="billingAccountName"/> or <paramref name="billingSubscriptionName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="billingSubscriptionName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<BillingSubscriptionResource> GetBillingSubscription(this TenantResource tenantResource, string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableBillingTenantResource(tenantResource).GetBillingSubscription(billingAccountName, billingSubscriptionName, cancellationToken);
        }

        /// <summary>
        /// Gets a collection of BillingSubscriptionAliasResources in the TenantResource.
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingSubscriptionAliases(string)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/> or <paramref name="billingAccountName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> An object representing collection of BillingSubscriptionAliasResources and their operations over a BillingSubscriptionAliasResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingSubscriptionAliasCollection GetBillingSubscriptionAliases(this TenantResource tenantResource, string billingAccountName)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptionAliases(billingAccountName);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingSubscriptionAliasAsync(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="aliasName"> The ID that uniquely identifies a subscription alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/>, <paramref name="billingAccountName"/> or <paramref name="aliasName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="aliasName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static async Task<Response<BillingSubscriptionAliasResource>> GetBillingSubscriptionAliasAsync(this TenantResource tenantResource, string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return await GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptionAliasAsync(billingAccountName, aliasName, cancellationToken).ConfigureAwait(false);
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
        /// <item>
        /// <term>Mocking</term>
        /// <description>To mock this method, please mock <see cref="MockableBillingTenantResource.GetBillingSubscriptionAlias(string,string,CancellationToken)"/> instead.</description>
        /// </item>
        /// </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource" /> instance the method will execute against. </param>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="aliasName"> The ID that uniquely identifies a subscription alias. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tenantResource"/>, <paramref name="billingAccountName"/> or <paramref name="aliasName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="billingAccountName"/> or <paramref name="aliasName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<BillingSubscriptionAliasResource> GetBillingSubscriptionAlias(this TenantResource tenantResource, string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));

            return GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptionAlias(billingAccountName, aliasName, cancellationToken);
        }
    }
}
