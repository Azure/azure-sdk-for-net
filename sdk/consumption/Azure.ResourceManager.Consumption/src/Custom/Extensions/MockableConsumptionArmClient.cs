// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Consumption.Models;

namespace Azure.ResourceManager.Consumption.Mocking
{
    /// <summary>
    /// Backward-compat stubs on the generated <see cref="MockableConsumptionArmClient"/> partial class.
    /// All methods throw <see cref="NotSupportedException"/>; callers should migrate to the new
    /// extension methods (<c>GetAll</c>/<c>GetByReservationOrder</c>/<c>Get</c> on their respective scopes).
    /// </summary>
    public partial class MockableConsumptionArmClient
    {
        /// <summary> Obsolete. Use the scope-based extension methods on <see cref="ArmClient"/> instead. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingAccountConsumptionResource GetBillingAccountConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        /// <summary> Obsolete. Use the scope-based extension methods on <see cref="ArmClient"/> instead. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingCustomerConsumptionResource GetBillingCustomerConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        /// <summary> Obsolete. Use the scope-based extension methods on <see cref="ArmClient"/> instead. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingProfileConsumptionResource GetBillingProfileConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        /// <summary> Obsolete. Use <c>ArmClient.GetForBillingPeriodByManagementGroup(scope)</c> instead. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ManagementGroupBillingPeriodConsumptionResource GetManagementGroupBillingPeriodConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetForBillingPeriodByManagementGroup(scope) instead.");

        /// <summary> Obsolete. Use the scope-based extension methods on <see cref="ArmClient"/> instead. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ReservationConsumptionResource GetReservationConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        /// <summary> Obsolete. Use the scope-based extension methods on <see cref="ArmClient"/> instead. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ReservationOrderConsumptionResource GetReservationOrderConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        /// <summary> Obsolete. Use <c>ArmClient.GetPriceSheet(scope)</c> instead. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SubscriptionBillingPeriodConsumptionResource GetSubscriptionBillingPeriodConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetPriceSheet(scope) instead.");

        /// <summary> Obsolete. Use <c>ArmClient.GetForBillingPeriodByBillingAccount(scope)</c> instead. </summary>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TenantBillingPeriodConsumptionResource GetTenantBillingPeriodConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetForBillingPeriodByBillingAccount(scope) instead.");

        /// <summary> Obsolete. Use the <c>GetAll(scope, startDate, endDate, filter, apply)</c> wrapper on <c>ChargesListResult</c> instead. </summary>
        /// <param name="scope"> The target scope. </param>
        /// <param name="startDate"> Optional start date filter (ISO 8601). </param>
        /// <param name="endDate"> Optional end date filter (ISO 8601). </param>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="apply"> Optional OData apply expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetConsumptionCharges(scope, startDate, endDate, filter, apply) iterator helpers instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionChargeSummary> GetConsumptionCharges(ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string apply = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use the GetAll(scope, startDate, endDate, filter, apply) wrapper on ChargesListResult instead.");

        /// <summary>
        /// Back-compat overload: shipped v1.1.0 had no <c>filter</c> parameter on
        /// <c>GetConsumptionReservationRecommendationDetails</c>. The current generated method adds
        /// an optional <c>filter</c> argument, which is a different metadata signature than the
        /// shipped 7-parameter version, so ApiCompat reports the old overload as missing. Forward
        /// to the new method with <c>filter=null</c>. Hidden from IntelliSense to avoid resolution
        /// ambiguity with the new overload.
        /// </summary>
        /// <param name="scope"> The target scope. </param>
        /// <param name="reservationScope"> Reservation recommendation scope (Single/Shared). </param>
        /// <param name="region"> Azure region. </param>
        /// <param name="term"> Reservation term. </param>
        /// <param name="lookBackPeriod"> Look-back period. </param>
        /// <param name="product"> Product family. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ConsumptionReservationRecommendationDetails> GetConsumptionReservationRecommendationDetails(ResourceIdentifier scope, ConsumptionReservationRecommendationScope reservationScope, string region, ConsumptionReservationRecommendationTerm term, ConsumptionReservationRecommendationLookBackPeriod lookBackPeriod, string product, CancellationToken cancellationToken = default)
            => GetConsumptionReservationRecommendationDetails(scope, reservationScope, region, term, lookBackPeriod, product, filter: null, cancellationToken);

        /// <summary>
        /// Back-compat overload mirroring the synchronous variant; see
        /// <see cref="GetConsumptionReservationRecommendationDetails(ResourceIdentifier, ConsumptionReservationRecommendationScope, string, ConsumptionReservationRecommendationTerm, ConsumptionReservationRecommendationLookBackPeriod, string, CancellationToken)"/>
        /// for details.
        /// </summary>
        /// <param name="scope"> The target scope. </param>
        /// <param name="reservationScope"> Reservation recommendation scope (Single/Shared). </param>
        /// <param name="region"> Azure region. </param>
        /// <param name="term"> Reservation term. </param>
        /// <param name="lookBackPeriod"> Look-back period. </param>
        /// <param name="product"> Product family. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ConsumptionReservationRecommendationDetails>> GetConsumptionReservationRecommendationDetailsAsync(ResourceIdentifier scope, ConsumptionReservationRecommendationScope reservationScope, string region, ConsumptionReservationRecommendationTerm term, ConsumptionReservationRecommendationLookBackPeriod lookBackPeriod, string product, CancellationToken cancellationToken = default)
            => GetConsumptionReservationRecommendationDetailsAsync(scope, reservationScope, region, term, lookBackPeriod, product, filter: null, cancellationToken);

        /// <summary> Obsolete. Use the <c>GetAllAsync(scope, startDate, endDate, filter, apply)</c> wrapper on <c>ChargesListResult</c> instead. </summary>
        /// <param name="scope"> The target scope. </param>
        /// <param name="startDate"> Optional start date filter (ISO 8601). </param>
        /// <param name="endDate"> Optional end date filter (ISO 8601). </param>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="apply"> Optional OData apply expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetConsumptionCharges(scope, startDate, endDate, filter, apply) iterator helpers instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionChargeSummary> GetConsumptionChargesAsync(ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string apply = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use the GetAllAsync(scope, startDate, endDate, filter, apply) wrapper on ChargesListResult instead.");

        /// <summary> Obsolete. Use the direct-parameter overload of <c>GetAll(...)</c> instead. </summary>
        /// <param name="scope"> The target scope. </param>
        /// <param name="options"> The options bag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetConsumptionReservationsSummaries(scope, grain, ...) direct overload instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionReservationSummary> GetConsumptionReservationsSummaries(ResourceIdentifier scope, ArmResourceGetConsumptionReservationsSummariesOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use the direct-parameter overload of GetAll(...) instead.");

        /// <summary> Obsolete. Use the direct-parameter overload of <c>GetAllAsync(...)</c> instead. </summary>
        /// <param name="scope"> The target scope. </param>
        /// <param name="options"> The options bag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("Use GetConsumptionReservationsSummaries(scope, grain, ...) direct overload instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionReservationSummary> GetConsumptionReservationsSummariesAsync(ResourceIdentifier scope, ArmResourceGetConsumptionReservationsSummariesOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use the direct-parameter overload of GetAllAsync(...) instead.");
    }
}
