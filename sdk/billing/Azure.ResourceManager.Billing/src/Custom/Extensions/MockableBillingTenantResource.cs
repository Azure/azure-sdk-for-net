// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Billing.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing.Mocking
{
    // Workaround for MPG generator bug that emits invalid
    //   IEnumerable<T>.ToRequestContent(parameters)  — https://github.com/Azure/azure-sdk-for-net/issues/57716
    // for body parameter types that are not models. The [CodeGenSuppress]-ed methods below
    // are replaced by hand-written equivalents that call BillingRequestContentHelper.
    // TODO: remove the [CodeGenSuppress] attributes + replacement methods once the upstream
    //       generator fix ships and the next regen no longer emits the broken calls.
    // NOTE: The methods are named *DownloadDocumentsByBillingSubscriptionInvoice* (with the
    // "Invoice" suffix) to match the GA 1.2.2 API contract; the [CodeGenSuppress] still
    // targets the no-suffix name that the broken generator emits.
    [CodeGenSuppress("DownloadDocumentsByBillingSubscriptionAsync", typeof(WaitUntil), typeof(string), typeof(IEnumerable<BillingDocumentDownloadRequestContent>), typeof(CancellationToken))]
    [CodeGenSuppress("DownloadDocumentsByBillingSubscription", typeof(WaitUntil), typeof(string), typeof(IEnumerable<BillingDocumentDownloadRequestContent>), typeof(CancellationToken))]
    public partial class MockableBillingTenantResource
    {
        /// <summary> Downloads multiple invoice documents as a zip file for a billing subscription. </summary>
        public virtual async Task<ArmOperation<BillingDocumentDownloadResult>> DownloadDocumentsByBillingSubscriptionInvoiceAsync(WaitUntil waitUntil, string subscriptionId, IEnumerable<BillingDocumentDownloadRequestContent> parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using DiagnosticScope scope = InvoicesClientDiagnostics.CreateScope("MockableBillingTenantResource.DownloadDocumentsByBillingSubscriptionInvoice");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = InvoicesRestClient.CreateDownloadDocumentsByBillingSubscriptionRequest(subscriptionId, BillingRequestContentHelper.ToRequestContent(parameters), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                BillingArmOperation<BillingDocumentDownloadResult> operation = new BillingArmOperation<BillingDocumentDownloadResult>(
                    new BillingDocumentDownloadResultOperationSource(),
                    InvoicesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Downloads multiple invoice documents as a zip file for a billing subscription. </summary>
        public virtual ArmOperation<BillingDocumentDownloadResult> DownloadDocumentsByBillingSubscriptionInvoice(WaitUntil waitUntil, string subscriptionId, IEnumerable<BillingDocumentDownloadRequestContent> parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(subscriptionId, nameof(subscriptionId));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using DiagnosticScope scope = InvoicesClientDiagnostics.CreateScope("MockableBillingTenantResource.DownloadDocumentsByBillingSubscriptionInvoice");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = InvoicesRestClient.CreateDownloadDocumentsByBillingSubscriptionRequest(subscriptionId, BillingRequestContentHelper.ToRequestContent(parameters), context);
                Response response = Pipeline.ProcessMessage(message, context);
                BillingArmOperation<BillingDocumentDownloadResult> operation = new BillingArmOperation<BillingDocumentDownloadResult>(
                    new BillingDocumentDownloadResultOperationSource(),
                    InvoicesClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Back-compat shims for GA 1.2.2 callers: TenantResource exposed shortcut accessors
        // that took a billingAccountName (and billingProfileName) and returned the child
        // collection without first materializing a BillingAccountResource handle. The new
        // MPG generator no longer emits these convenience overloads on the mockable type.
        // Each method follows the GA pattern verbatim: build the parent ResourceIdentifier
        // and return `new Child(Client, parentId)`. No new wire behavior is introduced.

        /// <summary> Gets a collection of <see cref="BillingSubscriptionResource"/> objects under the given billing account. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        public virtual BillingSubscriptionCollection GetBillingSubscriptions(string billingAccountName)
        {
            return new BillingSubscriptionCollection(Client, new ResourceIdentifier($"{Id}/billingAccounts/{billingAccountName}"));
        }

        /// <summary> Gets a collection of <see cref="BillingSubscriptionAliasResource"/> objects under the given billing account. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        public virtual BillingSubscriptionAliasCollection GetBillingSubscriptionAliases(string billingAccountName)
        {
            return new BillingSubscriptionAliasCollection(Client, new ResourceIdentifier($"{Id}/billingAccounts/{billingAccountName}"));
        }

        /// <summary> Gets a collection of <see cref="BillingAccountPaymentMethodResource"/> objects under the given billing account. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        public virtual BillingAccountPaymentMethodCollection GetBillingAccountPaymentMethods(string billingAccountName)
        {
            return new BillingAccountPaymentMethodCollection(Client, new ResourceIdentifier($"{Id}/billingAccounts/{billingAccountName}"));
        }

        /// <summary> Gets a collection of <see cref="BillingPaymentMethodLinkResource"/> objects under the given billing profile. </summary>
        /// <param name="billingAccountName"> The ID that uniquely identifies a billing account. </param>
        /// <param name="billingProfileName"> The ID that uniquely identifies a billing profile. </param>
        public virtual BillingPaymentMethodLinkCollection GetBillingPaymentMethodLinks(string billingAccountName, string billingProfileName)
        {
            return new BillingPaymentMethodLinkCollection(Client, new ResourceIdentifier($"{Id}/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}"));
        }

        /// <summary> Gets a single <see cref="BillingSubscriptionResource"/> by name under the given billing account. </summary>
        public virtual Response<BillingSubscriptionResource> GetBillingSubscription(string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            return GetBillingSubscriptions(billingAccountName).Get(billingSubscriptionName, cancellationToken);
        }

        /// <summary> Gets a single <see cref="BillingSubscriptionResource"/> by name under the given billing account. </summary>
        public virtual async Task<Response<BillingSubscriptionResource>> GetBillingSubscriptionAsync(string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            return await GetBillingSubscriptions(billingAccountName).GetAsync(billingSubscriptionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a single <see cref="BillingSubscriptionAliasResource"/> by name under the given billing account. </summary>
        public virtual Response<BillingSubscriptionAliasResource> GetBillingSubscriptionAlias(string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            return GetBillingSubscriptionAliases(billingAccountName).Get(aliasName, cancellationToken);
        }

        /// <summary> Gets a single <see cref="BillingSubscriptionAliasResource"/> by name under the given billing account. </summary>
        public virtual async Task<Response<BillingSubscriptionAliasResource>> GetBillingSubscriptionAliasAsync(string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            return await GetBillingSubscriptionAliases(billingAccountName).GetAsync(aliasName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a single <see cref="BillingAccountPaymentMethodResource"/> by name under the given billing account. </summary>
        public virtual Response<BillingAccountPaymentMethodResource> GetBillingAccountPaymentMethod(string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return GetBillingAccountPaymentMethods(billingAccountName).Get(paymentMethodName, cancellationToken);
        }

        /// <summary> Gets a single <see cref="BillingAccountPaymentMethodResource"/> by name under the given billing account. </summary>
        public virtual async Task<Response<BillingAccountPaymentMethodResource>> GetBillingAccountPaymentMethodAsync(string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return await GetBillingAccountPaymentMethods(billingAccountName).GetAsync(paymentMethodName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a single <see cref="BillingPaymentMethodLinkResource"/> by name under the given billing profile. </summary>
        public virtual Response<BillingPaymentMethodLinkResource> GetBillingPaymentMethodLink(string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return GetBillingPaymentMethodLinks(billingAccountName, billingProfileName).Get(paymentMethodName, cancellationToken);
        }

        /// <summary> Gets a single <see cref="BillingPaymentMethodLinkResource"/> by name under the given billing profile. </summary>
        public virtual async Task<Response<BillingPaymentMethodLinkResource>> GetBillingPaymentMethodLinkAsync(string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return await GetBillingPaymentMethodLinks(billingAccountName, billingProfileName).GetAsync(paymentMethodName, cancellationToken).ConfigureAwait(false);
        }

        // ValidateAddres — GA 1.2.2 exposed this on TenantResource. The new MPG generator
        // drops the action because the underlying spec op moved away from the Tenant scope.
        // Hand-written using the available AddressRestClient.CreateValidateRequest + Pipeline.
        // Note: GA spelled the method "ValidateAddres" (single 's' — typo preserved).

        /// <summary> Validates an address. Use this before using it as a soldTo or billTo address. </summary>
        public virtual async Task<Response<BillingAddressValidationResult>> ValidateAddresAsync(BillingAddressDetails details, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(details, nameof(details));

            using DiagnosticScope scope = AddressClientDiagnostics.CreateScope("MockableBillingTenantResource.ValidateAddres");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                RequestContent content = RequestContent.Create(((IPersistableModel<BillingAddressDetails>)details).Write(ModelReaderWriterOptions.Json));
                HttpMessage message = AddressRestClient.CreateValidateRequest(content, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                BillingAddressValidationResult value = ModelReaderWriter.Read<BillingAddressValidationResult>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerBillingContext.Default);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Validates an address. Use this before using it as a soldTo or billTo address. </summary>
        public virtual Response<BillingAddressValidationResult> ValidateAddres(BillingAddressDetails details, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(details, nameof(details));

            using DiagnosticScope scope = AddressClientDiagnostics.CreateScope("MockableBillingTenantResource.ValidateAddres");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                RequestContent content = RequestContent.Create(((IPersistableModel<BillingAddressDetails>)details).Write(ModelReaderWriterOptions.Json));
                HttpMessage message = AddressRestClient.CreateValidateRequest(content, context);
                Response response = Pipeline.ProcessMessage(message, context);
                BillingAddressValidationResult value = ModelReaderWriter.Read<BillingAddressValidationResult>(response.Content, ModelReaderWriterOptions.Json, AzureResourceManagerBillingContext.Default);
                return Response.FromValue(value, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
