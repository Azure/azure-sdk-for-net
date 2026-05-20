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
    /// Obsolete backward-compatibility stub for the billing-profile scoped consumption resource that
    /// existed in the v1.1.0 surface. The TypeSpec migration replaced the wrapper resource with
    /// scope-based extension methods on <see cref="ArmClient"/> and a dedicated
    /// <see cref="ConsumptionCreditSummaryResource"/>. This type now throws on every member and is
    /// hidden from IntelliSense.
    /// </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class BillingProfileConsumptionResource : ArmResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Billing/billingAccounts/billingProfiles";

        /// <summary> Initializes a new instance of the <see cref="BillingProfileConsumptionResource"/> class for mocking. </summary>
        protected BillingProfileConsumptionResource()
        {
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionCreditSummaryResource(...)</c> or the credit-summary extensions instead. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ConsumptionCreditSummary> GetCredit(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use the ConsumptionCreditSummary extensions on ArmClient instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionCreditSummaryResource(...)</c> or the credit-summary extensions instead. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ConsumptionCreditSummary>> GetCreditAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use the ConsumptionCreditSummary extensions on ArmClient instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionEventSummaries(scope, ...)</c> instead. </summary>
        /// <param name="startDate"> Start date filter (ISO 8601). </param>
        /// <param name="endDate"> End date filter (ISO 8601). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionEventSummary> GetEvents(string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionEventSummaries(scope, ...) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionEventSummariesAsync(scope, ...)</c> instead. </summary>
        /// <param name="startDate"> Start date filter (ISO 8601). </param>
        /// <param name="endDate"> End date filter (ISO 8601). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionEventSummary> GetEventsAsync(string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionEventSummariesAsync(scope, ...) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionLotSummaries(scope)</c> instead. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionLotSummary> GetLots(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionLotSummaries(scope) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionLotSummariesAsync(scope)</c> instead. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionLotSummary> GetLotsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionLotSummariesAsync(scope) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionModernReservationTransactions(scope, filter)</c> instead. </summary>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionModernReservationTransaction> GetReservationTransactions(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionModernReservationTransactions(scope, filter) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetConsumptionModernReservationTransactionsAsync(scope, filter)</c> instead. </summary>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionModernReservationTransaction> GetReservationTransactionsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionModernReservationTransactionsAsync(scope, filter) instead.");
        }
    }
}
