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

namespace Azure.ResourceManager.Billing.Mocking
{
    public partial class MockableBillingTenantResource
    {
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
        [ForwardsClientCalls]
        public virtual Response<BillingSubscriptionResource> GetBillingSubscription(string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            return GetBillingSubscriptions(billingAccountName).Get(billingSubscriptionName, cancellationToken);
        }

        /// <summary> Gets a single <see cref="BillingSubscriptionResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<BillingSubscriptionResource>> GetBillingSubscriptionAsync(string billingAccountName, string billingSubscriptionName, CancellationToken cancellationToken = default)
        {
            return await GetBillingSubscriptions(billingAccountName).GetAsync(billingSubscriptionName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a single <see cref="BillingSubscriptionAliasResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public virtual Response<BillingSubscriptionAliasResource> GetBillingSubscriptionAlias(string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            return GetBillingSubscriptionAliases(billingAccountName).Get(aliasName, cancellationToken);
        }

        /// <summary> Gets a single <see cref="BillingSubscriptionAliasResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<BillingSubscriptionAliasResource>> GetBillingSubscriptionAliasAsync(string billingAccountName, string aliasName, CancellationToken cancellationToken = default)
        {
            return await GetBillingSubscriptionAliases(billingAccountName).GetAsync(aliasName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a single <see cref="BillingAccountPaymentMethodResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public virtual Response<BillingAccountPaymentMethodResource> GetBillingAccountPaymentMethod(string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return GetBillingAccountPaymentMethods(billingAccountName).Get(paymentMethodName, cancellationToken);
        }

        /// <summary> Gets a single <see cref="BillingAccountPaymentMethodResource"/> by name under the given billing account. </summary>
        [ForwardsClientCalls]
        public virtual async Task<Response<BillingAccountPaymentMethodResource>> GetBillingAccountPaymentMethodAsync(string billingAccountName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return await GetBillingAccountPaymentMethods(billingAccountName).GetAsync(paymentMethodName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a single <see cref="BillingPaymentMethodLinkResource"/> by name under the given billing profile. </summary>
        [ForwardsClientCalls]
        public virtual Response<BillingPaymentMethodLinkResource> GetBillingPaymentMethodLink(string billingAccountName, string billingProfileName, string paymentMethodName, CancellationToken cancellationToken = default)
        {
            return GetBillingPaymentMethodLinks(billingAccountName, billingProfileName).Get(paymentMethodName, cancellationToken);
        }

        /// <summary> Gets a single <see cref="BillingPaymentMethodLinkResource"/> by name under the given billing profile. </summary>
        [ForwardsClientCalls]
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
