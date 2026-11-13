// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Consumption.Models;

namespace Azure.ResourceManager.Consumption
{
    /// <summary>
    /// Obsolete backward-compatibility stub for the billing-account scoped consumption resource that
    /// existed in the v1.1.0 surface. The TypeSpec migration replaced the wrapper resource with
    /// scope-based extension methods on <see cref="ArmClient"/>; this type now throws on every member
    /// and is hidden from IntelliSense. Use the scope-based extension methods on <see cref="ArmClient"/>
    /// (for example <c>GetConsumptionBalanceResults(scope)</c>, <c>GetConsumptionEventSummaries(scope, ...)</c>,
    /// <c>GetConsumptionLotSummaries(scope, ...)</c>, <c>GetConsumptionReservationTransactions(scope, ...)</c>)
    /// instead.
    /// </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class BillingAccountConsumptionResource : ArmResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Billing/billingAccounts";

        /// <summary> Initializes a new instance of the <see cref="BillingAccountConsumptionResource"/> class for mocking. </summary>
        protected BillingAccountConsumptionResource()
        {
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionBalanceResult(scope)</c> instead. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ConsumptionBalanceResult> GetBalance(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionBalanceResult(scope) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionBalanceResultAsync(scope)</c> instead. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ConsumptionBalanceResult>> GetBalanceAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionBalanceResultAsync(scope) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionEventSummaries(scope, filter)</c> instead. </summary>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionEventSummary> GetEvents(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionEventSummaries(scope, filter) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionEventSummariesAsync(scope, filter)</c> instead. </summary>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionEventSummary> GetEventsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionEventSummariesAsync(scope, filter) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionLotSummaries(scope, filter)</c> instead. </summary>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionLotSummary> GetLots(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionLotSummaries(scope, filter) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionLotSummariesAsync(scope, filter)</c> instead. </summary>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionLotSummary> GetLotsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionLotSummariesAsync(scope, filter) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionReservationTransactions(scope, filter)</c> instead. </summary>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionReservationTransaction> GetReservationTransactions(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionReservationTransactions(scope, filter) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionReservationTransactionsAsync(scope, filter)</c> instead. </summary>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionReservationTransaction> GetReservationTransactionsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionReservationTransactionsAsync(scope, filter) instead.");
        }
    }
}
