// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Billing.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Billing
{
    // Back-compat wrappers for GA 1.2.2 TenantResource extension methods. Each method
    // forwards to MockableBillingTenantResource (custom partial below), which then
    // builds the parent ResourceIdentifier and constructs the child collection.
    // The two-layer split mirrors the canonical Mockable-extension pattern used by
    // every existing extension in the generated BillingExtensions.cs.
    public static partial class BillingExtensions
    {
        /// <summary> Gets a collection of <see cref="BillingSubscriptionResource"/> objects under the given billing account. </summary>
        public static BillingSubscriptionCollection GetBillingSubscriptions(this TenantResource tenantResource, string billingAccountName)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptions(billingAccountName);
        }

        /// <summary> Gets a <see cref="BillingSubscriptionResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public static Response<BillingSubscriptionResource> GetBillingSubscription(this TenantResource tenantResource, string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptions(billingAccountName).Get(billingSubscriptionName, cancellationToken);
        }

        /// <summary> Gets a <see cref="BillingSubscriptionResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<BillingSubscriptionResource>> GetBillingSubscriptionAsync(this TenantResource tenantResource, string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptions(billingAccountName).GetAsync(billingSubscriptionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of <see cref="BillingSubscriptionAliasResource"/> objects under the given billing account. </summary>
        public static BillingSubscriptionAliasCollection GetBillingSubscriptionAliases(this TenantResource tenantResource, string billingAccountName)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptionAliases(billingAccountName);
        }

        /// <summary> Gets a <see cref="BillingSubscriptionAliasResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public static Response<BillingSubscriptionAliasResource> GetBillingSubscriptionAlias(this TenantResource tenantResource, string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptionAliases(billingAccountName).Get(aliasName, cancellationToken);
        }

        /// <summary> Gets a <see cref="BillingSubscriptionAliasResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<BillingSubscriptionAliasResource>> GetBillingSubscriptionAliasAsync(this TenantResource tenantResource, string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptionAliases(billingAccountName).GetAsync(aliasName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of <see cref="BillingAccountPaymentMethodResource"/> objects under the given billing account. </summary>
        public static BillingAccountPaymentMethodCollection GetBillingAccountPaymentMethods(this TenantResource tenantResource, string billingAccountName)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).GetBillingAccountPaymentMethods(billingAccountName);
        }

        /// <summary> Gets a <see cref="BillingAccountPaymentMethodResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public static Response<BillingAccountPaymentMethodResource> GetBillingAccountPaymentMethod(this TenantResource tenantResource, string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).GetBillingAccountPaymentMethods(billingAccountName).Get(paymentMethodName, cancellationToken);
        }

        /// <summary> Gets a <see cref="BillingAccountPaymentMethodResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<BillingAccountPaymentMethodResource>> GetBillingAccountPaymentMethodAsync(this TenantResource tenantResource, string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).GetBillingAccountPaymentMethods(billingAccountName).GetAsync(paymentMethodName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a collection of <see cref="BillingPaymentMethodLinkResource"/> objects under the given billing profile. </summary>
        public static BillingPaymentMethodLinkCollection GetBillingPaymentMethodLinks(this TenantResource tenantResource, string billingAccountName, string billingProfileName)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).GetBillingPaymentMethodLinks(billingAccountName, billingProfileName);
        }

        /// <summary> Gets a <see cref="BillingPaymentMethodLinkResource"/> by name under the given billing profile. </summary>
        [ForwardsClientCalls]
        public static Response<BillingPaymentMethodLinkResource> GetBillingPaymentMethodLink(this TenantResource tenantResource, string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).GetBillingPaymentMethodLinks(billingAccountName, billingProfileName).Get(paymentMethodName, cancellationToken);
        }

        /// <summary> Gets a <see cref="BillingPaymentMethodLinkResource"/> by name under the given billing profile. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<BillingPaymentMethodLinkResource>> GetBillingPaymentMethodLinkAsync(this TenantResource tenantResource, string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).GetBillingPaymentMethodLinks(billingAccountName, billingProfileName).GetAsync(paymentMethodName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Validates an address. Use this before using it as a soldTo or billTo address. </summary>
        public static Response<Models.BillingAddressValidationResult> ValidateAddres(this TenantResource tenantResource, Models.BillingAddressDetails details, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).ValidateAddres(details, cancellationToken);
        }

        /// <summary> Validates an address. Use this before using it as a soldTo or billTo address. </summary>
        public static async Task<Response<Models.BillingAddressValidationResult>> ValidateAddresAsync(this TenantResource tenantResource, Models.BillingAddressDetails details, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).ValidateAddresAsync(details, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Downloads multiple invoice documents as a zip file for a billing subscription. </summary>
        public static ArmOperation<Models.BillingDocumentDownloadResult> DownloadDocumentsByBillingSubscriptionInvoice(this TenantResource tenantResource, WaitUntil waitUntil, string subscriptionId, System.Collections.Generic.IEnumerable<Models.BillingDocumentDownloadRequestContent> arrayOfDocumentDownloadRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).DownloadDocumentsByBillingSubscriptionInvoice(waitUntil, subscriptionId, arrayOfDocumentDownloadRequest, cancellationToken);
        }

        /// <summary> Downloads multiple invoice documents as a zip file for a billing subscription. </summary>
        public static async Task<ArmOperation<Models.BillingDocumentDownloadResult>> DownloadDocumentsByBillingSubscriptionInvoiceAsync(this TenantResource tenantResource, WaitUntil waitUntil, string subscriptionId, System.Collections.Generic.IEnumerable<Models.BillingDocumentDownloadRequestContent> arrayOfDocumentDownloadRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).DownloadDocumentsByBillingSubscriptionInvoiceAsync(waitUntil, subscriptionId, arrayOfDocumentDownloadRequest, cancellationToken).ConfigureAwait(false);
        }
    }
}
