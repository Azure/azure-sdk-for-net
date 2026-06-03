// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Billing.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing
{
    // Back-compat overloads for GA 1.2.2 callers that pass an Options aggregate.
    // The new MPG generator emits methods with individual query parameters and
    // renamed scope-qualified names (Get*ByBillingAccount*); these shims forward
    // the aggregate to the generated method so existing call sites keep working.
    //
    // Also: workaround for MPG generator bugs that emit invalid
    //   IEnumerable<T>.ToRequestContent(parameters)  — https://github.com/Azure/azure-sdk-for-net/issues/57716
    //   DateTimeOffset.ToRequestContent(parameters)  — https://github.com/Azure/azure-sdk-for-net/issues/59539
    // for body parameter types that are not models. The [CodeGenSuppress]-ed methods
    // below are replaced by hand-written equivalents that call BillingRequestContentHelper.
    // TODO: remove the [CodeGenSuppress] attributes + replacement methods once the
    //       upstream generator fixes ship and the next regen no longer emits the broken calls.
    [CodeGenSuppress("AddPaymentTermsAsync", typeof(WaitUntil), typeof(IEnumerable<BillingPaymentTerm>), typeof(CancellationToken))]
    [CodeGenSuppress("AddPaymentTerms", typeof(WaitUntil), typeof(IEnumerable<BillingPaymentTerm>), typeof(CancellationToken))]
    [CodeGenSuppress("CancelPaymentTermsAsync", typeof(WaitUntil), typeof(DateTimeOffset), typeof(CancellationToken))]
    [CodeGenSuppress("CancelPaymentTerms", typeof(WaitUntil), typeof(DateTimeOffset), typeof(CancellationToken))]
    [CodeGenSuppress("DownloadDocumentsByBillingAccountAsync", typeof(WaitUntil), typeof(IEnumerable<BillingDocumentDownloadRequestContent>), typeof(CancellationToken))]
    [CodeGenSuppress("DownloadDocumentsByBillingAccount", typeof(WaitUntil), typeof(IEnumerable<BillingDocumentDownloadRequestContent>), typeof(CancellationToken))]
    [CodeGenSuppress("ValidatePaymentTermsAsync", typeof(IEnumerable<BillingPaymentTerm>), typeof(CancellationToken))]
    [CodeGenSuppress("ValidatePaymentTerms", typeof(IEnumerable<BillingPaymentTerm>), typeof(CancellationToken))]
    public partial class BillingAccountResource
    {
        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingRequestResource> GetBillingRequestsAsync(BillingAccountResourceGetBillingRequestsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingAccountAsync(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingRequestResource> GetBillingRequests(BillingAccountResourceGetBillingRequestsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingAccount(filter: options?.Filter, orderBy: options?.OrderBy, maxCount: options?.Top, skip: options?.Skip, count: options?.Count, search: options?.Search, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<BillingReservationResource> GetReservationsAsync(BillingAccountResourceGetReservationsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingAccountAsync(filter: options?.Filter, orderBy: options?.OrderBy, skiptoken: options?.Skiptoken, refreshSummary: options?.RefreshSummary, selectedState: options?.SelectedState, take: options?.Take, cancellationToken: cancellationToken);
        }

        /// <summary> Back-compat overload for GA 1.2.2 callers that pass an Options aggregate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<BillingReservationResource> GetReservations(BillingAccountResourceGetReservationsOptions options, CancellationToken cancellationToken = default)
        {
            return GetByBillingAccount(filter: options?.Filter, orderBy: options?.OrderBy, skiptoken: options?.Skiptoken, refreshSummary: options?.RefreshSummary, selectedState: options?.SelectedState, take: options?.Take, cancellationToken: cancellationToken);
        }

        // ---------- Replacements for generator-emitted methods whose body uses an invalid
        //            <BodyType>.ToRequestContent(parameters) call (#57716, #59539).
        //            Bodies are byte-for-byte copies of the generator output with the broken
        //            line replaced by BillingRequestContentHelper.ToRequestContent(parameters).

        /// <summary> Adds payment terms on the billing account. </summary>
        public virtual async Task<ArmOperation<BillingAccountResource>> AddPaymentTermsAsync(WaitUntil waitUntil, IEnumerable<BillingPaymentTerm> parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using DiagnosticScope scope = _billingAccountsClientDiagnostics.CreateScope("BillingAccountResource.AddPaymentTerms");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _billingAccountsRestClient.CreateAddPaymentTermsRequest(Id.Name, BillingRequestContentHelper.ToRequestContent(parameters), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                BillingArmOperation<BillingAccountResource> operation = new BillingArmOperation<BillingAccountResource>(
                    new BillingAccountResourceOperationSource(Client),
                    _billingAccountsClientDiagnostics,
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

        /// <summary> Adds payment terms on the billing account. </summary>
        public virtual ArmOperation<BillingAccountResource> AddPaymentTerms(WaitUntil waitUntil, IEnumerable<BillingPaymentTerm> parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using DiagnosticScope scope = _billingAccountsClientDiagnostics.CreateScope("BillingAccountResource.AddPaymentTerms");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _billingAccountsRestClient.CreateAddPaymentTermsRequest(Id.Name, BillingRequestContentHelper.ToRequestContent(parameters), context);
                Response response = Pipeline.ProcessMessage(message, context);
                BillingArmOperation<BillingAccountResource> operation = new BillingArmOperation<BillingAccountResource>(
                    new BillingAccountResourceOperationSource(Client),
                    _billingAccountsClientDiagnostics,
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

        /// <summary> Cancels payment terms on a billing account. </summary>
        public virtual async Task<ArmOperation<BillingAccountResource>> CancelPaymentTermsAsync(WaitUntil waitUntil, DateTimeOffset parameters, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _billingAccountsClientDiagnostics.CreateScope("BillingAccountResource.CancelPaymentTerms");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _billingAccountsRestClient.CreateCancelPaymentTermsRequest(Id.Name, BillingRequestContentHelper.ToRequestContent(parameters), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                BillingArmOperation<BillingAccountResource> operation = new BillingArmOperation<BillingAccountResource>(
                    new BillingAccountResourceOperationSource(Client),
                    _billingAccountsClientDiagnostics,
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

        /// <summary> Cancels payment terms on a billing account. </summary>
        public virtual ArmOperation<BillingAccountResource> CancelPaymentTerms(WaitUntil waitUntil, DateTimeOffset parameters, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _billingAccountsClientDiagnostics.CreateScope("BillingAccountResource.CancelPaymentTerms");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _billingAccountsRestClient.CreateCancelPaymentTermsRequest(Id.Name, BillingRequestContentHelper.ToRequestContent(parameters), context);
                Response response = Pipeline.ProcessMessage(message, context);
                BillingArmOperation<BillingAccountResource> operation = new BillingArmOperation<BillingAccountResource>(
                    new BillingAccountResourceOperationSource(Client),
                    _billingAccountsClientDiagnostics,
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

        /// <summary> Downloads multiple invoice documents as a zip file. </summary>
        public virtual async Task<ArmOperation<BillingDocumentDownloadResult>> DownloadDocumentsByBillingAccountInvoiceAsync(WaitUntil waitUntil, IEnumerable<BillingDocumentDownloadRequestContent> arrayOfDocumentDownloadRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(arrayOfDocumentDownloadRequest, nameof(arrayOfDocumentDownloadRequest));

            using DiagnosticScope scope = _invoicesClientDiagnostics.CreateScope("BillingAccountResource.DownloadDocumentsByBillingAccountInvoice");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _invoicesRestClient.CreateDownloadDocumentsByBillingAccountRequest(Id.Name, BillingRequestContentHelper.ToRequestContent(arrayOfDocumentDownloadRequest), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                BillingArmOperation<BillingDocumentDownloadResult> operation = new BillingArmOperation<BillingDocumentDownloadResult>(
                    new BillingDocumentDownloadResultOperationSource(),
                    _invoicesClientDiagnostics,
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

        /// <summary> Downloads multiple invoice documents as a zip file. </summary>
        public virtual ArmOperation<BillingDocumentDownloadResult> DownloadDocumentsByBillingAccountInvoice(WaitUntil waitUntil, IEnumerable<BillingDocumentDownloadRequestContent> arrayOfDocumentDownloadRequest, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(arrayOfDocumentDownloadRequest, nameof(arrayOfDocumentDownloadRequest));

            using DiagnosticScope scope = _invoicesClientDiagnostics.CreateScope("BillingAccountResource.DownloadDocumentsByBillingAccountInvoice");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _invoicesRestClient.CreateDownloadDocumentsByBillingAccountRequest(Id.Name, BillingRequestContentHelper.ToRequestContent(arrayOfDocumentDownloadRequest), context);
                Response response = Pipeline.ProcessMessage(message, context);
                BillingArmOperation<BillingDocumentDownloadResult> operation = new BillingArmOperation<BillingDocumentDownloadResult>(
                    new BillingDocumentDownloadResultOperationSource(),
                    _invoicesClientDiagnostics,
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

        /// <summary> Validates payment terms on a billing account. </summary>
        public virtual async Task<Response<PaymentTermsEligibilityResult>> ValidatePaymentTermsAsync(IEnumerable<BillingPaymentTerm> parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using DiagnosticScope scope = _billingAccountsClientDiagnostics.CreateScope("BillingAccountResource.ValidatePaymentTerms");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _billingAccountsRestClient.CreateValidatePaymentTermsRequest(Id.Name, BillingRequestContentHelper.ToRequestContent(parameters), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<PaymentTermsEligibilityResult> response = Response.FromValue(PaymentTermsEligibilityResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Validates payment terms on a billing account. </summary>
        public virtual Response<PaymentTermsEligibilityResult> ValidatePaymentTerms(IEnumerable<BillingPaymentTerm> parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using DiagnosticScope scope = _billingAccountsClientDiagnostics.CreateScope("BillingAccountResource.ValidatePaymentTerms");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _billingAccountsRestClient.CreateValidatePaymentTermsRequest(Id.Name, BillingRequestContentHelper.ToRequestContent(parameters), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<PaymentTermsEligibilityResult> response = Response.FromValue(PaymentTermsEligibilityResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
