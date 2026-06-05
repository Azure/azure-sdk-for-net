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
    // CancelPaymentTerms workaround: the generator emits an invalid
    //   DateTimeOffset.ToRequestContent(parameters)
    // call when an action body's TypeSpec type is a primitive (CS0117: no
    // extension method on DateTimeOffset). The [CodeGenSuppress] entries below
    // remove the broken method pair and CancelPaymentTerms{,Async} are
    // hand-written using the BillingRequestContentHelper.ToRequestContent
    // extension to wrap the DateTimeOffset payload as JSON.
    // Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/59539
    // TODO(#59539): drop the [CodeGenSuppress] + replacement once the upstream
    //               generator fix ships and regen no longer emits the broken call.
    //
    // GetBillingRequests/GetReservations{Async}(Options): back-compat overloads
    // for GA 1.2.2 callers that pass an Options aggregate. The new MPG generator
    // emits methods with individual query parameters (Get*ByBillingAccount);
    // these shims forward the aggregate to the generated method so existing
    // call sites keep working. No tracking issue — purely a back-compat shim.
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
