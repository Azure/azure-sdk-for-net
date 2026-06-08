// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    //
    // GetByBillingAccountSavingsPlan{Async}: the C# emitter cannot generate this
    // operation while the spec keeps `SavingsPlanModelListResult extends
    // SavingsPlanModelList is Page<SavingsPlanModel>` unchanged for swagger.
    // Tracking issue: https://github.com/Azure/azure-sdk-for-net/issues/59567
    // TODO(#59567): delete the custom REST/paging shim once MPG resolves the
    // inherited Page<> items-property lookup and the `!csharp` scope is removed.
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

        /// <summary>
        /// List savings plans by billing account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/savingsPlans</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SavingsPlans_ListByBillingAccount</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingSavingsPlanModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BillingSavingsPlanModelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BillingSavingsPlanModelResource> GetByBillingAccountSavingsPlanAsync(BillingAccountResourceGetByBillingAccountSavingsPlanOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new BillingAccountResourceGetByBillingAccountSavingsPlanOptions();

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<BillingSavingsPlanModelData, BillingSavingsPlanModelResource>(
                new SavingsPlansGetByBillingAccountAsyncCollectionResultOfT(BillingSavingsPlansClient, Id.Name, options.Filter, options.OrderBy, options.Skiptoken, options.Take, options.SelectedState, options.RefreshSummary, context, "BillingAccountResource.GetByBillingAccountSavingsPlan"),
                data => new BillingSavingsPlanModelResource(Client, data));
        }

        /// <summary>
        /// List savings plans by billing account.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/savingsPlans</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SavingsPlans_ListByBillingAccount</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-04-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="BillingSavingsPlanModelResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BillingSavingsPlanModelResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BillingSavingsPlanModelResource> GetByBillingAccountSavingsPlan(BillingAccountResourceGetByBillingAccountSavingsPlanOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new BillingAccountResourceGetByBillingAccountSavingsPlanOptions();

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<BillingSavingsPlanModelData, BillingSavingsPlanModelResource>(
                new SavingsPlansGetByBillingAccountCollectionResultOfT(BillingSavingsPlansClient, Id.Name, options.Filter, options.OrderBy, options.Skiptoken, options.Take, options.SelectedState, options.RefreshSummary, context, "BillingAccountResource.GetByBillingAccountSavingsPlan"),
                data => new BillingSavingsPlanModelResource(Client, data));
        }

        private SavingsPlans BillingSavingsPlansClient
        {
            get
            {
                _billingSavingsPlansClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.Billing", BillingSavingsPlanModelResource.ResourceType.Namespace, Diagnostics);
                if (_billingSavingsPlansRestClient is null)
                {
                    TryGetApiVersion(BillingSavingsPlanModelResource.ResourceType, out string billingSavingsPlanModelApiVersion);
                    _billingSavingsPlansRestClient = new SavingsPlans(_billingSavingsPlansClientDiagnostics, Pipeline, Endpoint, billingSavingsPlanModelApiVersion ?? "2024-04-01");
                }

                return _billingSavingsPlansRestClient;
            }
        }

        private ClientDiagnostics _billingSavingsPlansClientDiagnostics;
        private SavingsPlans _billingSavingsPlansRestClient;
    }
}
