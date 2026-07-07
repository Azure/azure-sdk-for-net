// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Billing.Mocking;
using Azure.ResourceManager.Billing.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Billing
{
    // Back-compat wrappers for GA 1.2.2 TenantResource extension methods. The new MPG
    // generator no longer emits these convenience extensions on TenantResource (the
    // collection accessors / per-resource Get / ValidateAddres / DownloadDocuments-
    // ByBillingSubscriptionInvoice that GA 1.2.2 exposed are now only reachable via
    // the mockable type). Each method forwards to MockableBillingTenantResource (custom
    // partial in Extensions/MockableBillingTenantResource.cs), which then builds the
    // parent ResourceIdentifier and constructs the child collection. The two-layer
    // split mirrors the canonical Mockable-extension pattern used by every existing
    // extension in the generated BillingExtensions.cs.
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
            return GetMockableBillingTenantResource(tenantResource).GetBillingSubscription(billingAccountName, billingSubscriptionName, cancellationToken);
        }

        /// <summary> Gets a <see cref="BillingSubscriptionResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<BillingSubscriptionResource>> GetBillingSubscriptionAsync(this TenantResource tenantResource, string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptionAsync(billingAccountName, billingSubscriptionName, cancellationToken).ConfigureAwait(false);
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
            return GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptionAlias(billingAccountName, aliasName, cancellationToken);
        }

        /// <summary> Gets a <see cref="BillingSubscriptionAliasResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<BillingSubscriptionAliasResource>> GetBillingSubscriptionAliasAsync(this TenantResource tenantResource, string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).GetBillingSubscriptionAliasAsync(billingAccountName, aliasName, cancellationToken).ConfigureAwait(false);
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
            return GetMockableBillingTenantResource(tenantResource).GetBillingAccountPaymentMethod(billingAccountName, paymentMethodName, cancellationToken);
        }

        /// <summary> Gets a <see cref="BillingAccountPaymentMethodResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<BillingAccountPaymentMethodResource>> GetBillingAccountPaymentMethodAsync(this TenantResource tenantResource, string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).GetBillingAccountPaymentMethodAsync(billingAccountName, paymentMethodName, cancellationToken).ConfigureAwait(false);
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
            return GetMockableBillingTenantResource(tenantResource).GetBillingPaymentMethodLink(billingAccountName, billingProfileName, paymentMethodName, cancellationToken);
        }

        /// <summary> Gets a <see cref="BillingPaymentMethodLinkResource"/> by name under the given billing profile. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<BillingPaymentMethodLinkResource>> GetBillingPaymentMethodLinkAsync(this TenantResource tenantResource, string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).GetBillingPaymentMethodLinkAsync(billingAccountName, billingProfileName, paymentMethodName, cancellationToken).ConfigureAwait(false);
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

        // TODO Azure/azure-sdk-for-net#59626: MPG generator emits an invalid XML cref on the
        // auto-generated static "Mocking" extension (bare `IEnumerable` instead of
        // `IEnumerable{BillingDocumentDownloadRequestContent}`), which fails CS1574/CS1580
        // under TreatWarningsAsErrors. Re-emit the sync + async pair here with a compilable
        // cref. DELETE DownloadDocumentsByBillingSubscriptionInvoice and its Async overload
        // (below) once #59626 is fixed and the generator emits a compilable cref.
        /// <summary> Downloads multiple invoice documents as a zip file for a billing subscription. </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="subscriptionId"> The ID that uniquely identifies a billing subscription. </param>
        /// <param name="arrayOfDocumentDownloadRequest"> A list of download details for individual documents. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static ArmOperation<BillingDocumentDownloadResult> DownloadDocumentsByBillingSubscriptionInvoice(this TenantResource tenantResource, WaitUntil waitUntil, string subscriptionId, IEnumerable<BillingDocumentDownloadRequestContent> arrayOfDocumentDownloadRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return GetMockableBillingTenantResource(tenantResource).DownloadDocumentsByBillingSubscriptionInvoice(waitUntil, subscriptionId, arrayOfDocumentDownloadRequest, cancellationToken);
        }

        /// <summary> Downloads multiple invoice documents as a zip file for a billing subscription. See TODO above the sync overload (Azure/azure-sdk-for-net#59626). </summary>
        /// <param name="tenantResource"> The <see cref="TenantResource"/> the method will execute against. </param>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="subscriptionId"> The ID that uniquely identifies a billing subscription. </param>
        /// <param name="arrayOfDocumentDownloadRequest"> A list of download details for individual documents. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static async Task<ArmOperation<BillingDocumentDownloadResult>> DownloadDocumentsByBillingSubscriptionInvoiceAsync(this TenantResource tenantResource, WaitUntil waitUntil, string subscriptionId, IEnumerable<BillingDocumentDownloadRequestContent> arrayOfDocumentDownloadRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tenantResource, nameof(tenantResource));
            return await GetMockableBillingTenantResource(tenantResource).DownloadDocumentsByBillingSubscriptionInvoiceAsync(waitUntil, subscriptionId, arrayOfDocumentDownloadRequest, cancellationToken).ConfigureAwait(false);
        }
    }
}
