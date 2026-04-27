// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Consumption.Models;

namespace Azure.ResourceManager.Consumption.Mocking
{
    // Backward-compat stubs on the generated MockableConsumptionArmClient partial class.
    // All methods throw NotSupportedException — callers should migrate to the new extension methods
    // (GetAll / GetByReservationOrder / Get on their respective scopes).
    public partial class MockableConsumptionArmClient
    {
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingAccountConsumptionResource GetBillingAccountConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingCustomerConsumptionResource GetBillingCustomerConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual BillingProfileConsumptionResource GetBillingProfileConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ManagementGroupBillingPeriodConsumptionResource GetManagementGroupBillingPeriodConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ReservationConsumptionResource GetReservationConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ReservationOrderConsumptionResource GetReservationOrderConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual SubscriptionBillingPeriodConsumptionResource GetSubscriptionBillingPeriodConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual TenantBillingPeriodConsumptionResource GetTenantBillingPeriodConsumptionResource(ResourceIdentifier id)
            => throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");

        [Obsolete("Use GetConsumptionCharges(scope, startDate, endDate, filter, apply) iterator helpers instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionChargeSummary> GetConsumptionCharges(ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string apply = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use the GetAll(scope, startDate, endDate, filter, apply) wrapper on ChargesListResult instead.");

        // Back-compat overload: shipped 1.1.0 had no `filter` parameter on
        // GetConsumptionReservationRecommendationDetails. The current generated method
        // adds an optional `filter` argument, which is a different metadata signature
        // than the shipped 7-parameter version, so ApiCompat reports the old overload
        // as missing. Forward to the new method with filter=null. Hidden from
        // IntelliSense to avoid resolution ambiguity with the new overload.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ConsumptionReservationRecommendationDetails> GetConsumptionReservationRecommendationDetails(ResourceIdentifier scope, ConsumptionReservationRecommendationScope reservationScope, string region, ConsumptionReservationRecommendationTerm term, ConsumptionReservationRecommendationLookBackPeriod lookBackPeriod, string product, CancellationToken cancellationToken = default)
            => GetConsumptionReservationRecommendationDetails(scope, reservationScope, region, term, lookBackPeriod, product, filter: null, cancellationToken);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ConsumptionReservationRecommendationDetails>> GetConsumptionReservationRecommendationDetailsAsync(ResourceIdentifier scope, ConsumptionReservationRecommendationScope reservationScope, string region, ConsumptionReservationRecommendationTerm term, ConsumptionReservationRecommendationLookBackPeriod lookBackPeriod, string product, CancellationToken cancellationToken = default)
            => GetConsumptionReservationRecommendationDetailsAsync(scope, reservationScope, region, term, lookBackPeriod, product, filter: null, cancellationToken);

        [Obsolete("Use GetConsumptionCharges(scope, startDate, endDate, filter, apply) iterator helpers instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionChargeSummary> GetConsumptionChargesAsync(ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string apply = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use the GetAllAsync(scope, startDate, endDate, filter, apply) wrapper on ChargesListResult instead.");

        [Obsolete("Use GetConsumptionReservationsSummaries(scope, grain, ...) direct overload instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionReservationSummary> GetConsumptionReservationsSummaries(ResourceIdentifier scope, ArmResourceGetConsumptionReservationsSummariesOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use the direct-parameter overload of GetAll(...) instead.");

        [Obsolete("Use GetConsumptionReservationsSummaries(scope, grain, ...) direct overload instead.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionReservationSummary> GetConsumptionReservationsSummariesAsync(ResourceIdentifier scope, ArmResourceGetConsumptionReservationsSummariesOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("Use the direct-parameter overload of GetAllAsync(...) instead.");
    }
}
