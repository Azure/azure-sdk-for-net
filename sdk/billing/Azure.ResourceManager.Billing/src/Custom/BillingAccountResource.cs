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
    // Back-compat rename: GA 1.2.2 exposed this as DownloadDocumentsByBillingAccountInvoice
    // (note the trailing "Invoice"); the new generator emits without that suffix. The
    // [CodeGenSuppress] below removes the generator's no-suffix method so the GA spelling
    // (provided in the methods below) is preserved.
    //
    // CancelPaymentTerms workaround: the generator emits an invalid
    //   DateTimeOffset.ToRequestContent(parameters)
    // call (https://github.com/Azure/azure-sdk-for-net/issues/59539). The [CodeGenSuppress]
    // below removes the broken method and CancelPaymentTerms{,Async} are hand-written using
    // the BillingRequestContentHelper.ToRequestContent extension. TODO: remove the
    // [CodeGenSuppress] + replacement once #59539 ships.
    [CodeGenSuppress("CancelPaymentTermsAsync", typeof(WaitUntil), typeof(DateTimeOffset), typeof(CancellationToken))]
    [CodeGenSuppress("CancelPaymentTerms", typeof(WaitUntil), typeof(DateTimeOffset), typeof(CancellationToken))]
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
    }
}
