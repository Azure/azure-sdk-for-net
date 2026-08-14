// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Consumption.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Consumption
{
    /// <summary>
    /// Backward-compatibility extension methods for resource types removed during the TypeSpec
    /// migration. These stubs preserve the public API surface so existing code that references the
    /// old resource types (for example <c>GetBillingAccountConsumptionResource</c>) continues to
    /// compile. All methods throw <see cref="NotSupportedException"/>; callers should migrate to
    /// the new scope-based extension methods on <see cref="ArmClient"/>.
    /// </summary>
    public static partial class ConsumptionExtensions
    {
        /// <summary> Obsolete. Use the scope-based extension methods on <see cref="ArmClient"/> instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingAccountConsumptionResource GetBillingAccountConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        /// <summary> Obsolete. Use the scope-based extension methods on <see cref="ArmClient"/> instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingCustomerConsumptionResource GetBillingCustomerConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        /// <summary> Obsolete. Use the scope-based extension methods on <see cref="ArmClient"/> instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static BillingProfileConsumptionResource GetBillingProfileConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetForBillingPeriodByManagementGroup(scope)</c> extension method instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ManagementGroupBillingPeriodConsumptionResource GetManagementGroupBillingPeriodConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetForBillingPeriodByManagementGroup(scope) instead.");
        }

        /// <summary> Obsolete. Use the scope-based extension methods on <see cref="ArmClient"/> instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ReservationConsumptionResource GetReservationConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        /// <summary> Obsolete. Use the scope-based extension methods on <see cref="ArmClient"/> instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ReservationOrderConsumptionResource GetReservationOrderConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetPriceSheet(scope)</c> extension method instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SubscriptionBillingPeriodConsumptionResource GetSubscriptionBillingPeriodConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetPriceSheet(scope) instead.");
        }

        /// <summary> Obsolete. Use <c>ArmClient.GetForBillingPeriodByBillingAccount(scope)</c> extension method instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="id"> The resource identifier. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TenantBillingPeriodConsumptionResource GetTenantBillingPeriodConsumptionResource(this ArmClient client, ResourceIdentifier id)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetForBillingPeriodByBillingAccount(scope) instead.");
        }

        /// <summary> Obsolete. Use <c>GetPriceSheetResource</c> on the generated surface instead. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="expand"> Optional expand expression. </param>
        /// <param name="skipToken"> Optional pagination skip-token. </param>
        /// <param name="top"> Optional maximum number of records to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<PriceSheetResult> GetPriceSheet(this SubscriptionResource subscriptionResource, string expand = null, string skipToken = null, int? top = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Use GetPriceSheetResource instead.");
        }

        /// <summary> Obsolete. Use <c>GetPriceSheetResource</c> on the generated surface instead. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> instance. </param>
        /// <param name="expand"> Optional expand expression. </param>
        /// <param name="skipToken"> Optional pagination skip-token. </param>
        /// <param name="top"> Optional maximum number of records to return. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<PriceSheetResult>> GetPriceSheetAsync(this SubscriptionResource subscriptionResource, string expand = null, string skipToken = null, int? top = default, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("Use GetPriceSheetResource instead.");
        }

        /// <summary> Obsolete back-compat overload. Use the scope-based charge-summary extensions on <see cref="ArmClient"/> instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="scope"> The target scope. </param>
        /// <param name="startDate"> Optional start date filter (ISO 8601). </param>
        /// <param name="endDate"> Optional end date filter (ISO 8601). </param>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="apply"> Optional OData apply expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ConsumptionChargeSummary> GetConsumptionCharges(this ArmClient client, ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string apply = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This extension method is obsolete.");

        /// <summary> Obsolete back-compat overload. Use the scope-based charge-summary extensions on <see cref="ArmClient"/> instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="scope"> The target scope. </param>
        /// <param name="startDate"> Optional start date filter (ISO 8601). </param>
        /// <param name="endDate"> Optional end date filter (ISO 8601). </param>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="apply"> Optional OData apply expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ConsumptionChargeSummary> GetConsumptionChargesAsync(this ArmClient client, ResourceIdentifier scope, string startDate = null, string endDate = null, string filter = null, string apply = null, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This extension method is obsolete.");

        /// <summary> Obsolete back-compat overload using the options-bag pattern. Use the direct-parameter overload instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="scope"> The target scope. </param>
        /// <param name="options"> The options bag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Pageable<ConsumptionReservationSummary> GetConsumptionReservationsSummaries(this ArmClient client, ResourceIdentifier scope, ArmResourceGetConsumptionReservationsSummariesOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This extension method is obsolete.");

        /// <summary> Obsolete back-compat overload using the options-bag pattern. Use the direct-parameter overload instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="scope"> The target scope. </param>
        /// <param name="options"> The options bag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AsyncPageable<ConsumptionReservationSummary> GetConsumptionReservationsSummariesAsync(this ArmClient client, ResourceIdentifier scope, ArmResourceGetConsumptionReservationsSummariesOptions options, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This extension method is obsolete.");

        /// <summary> Obsolete back-compat overload without the <c>filter</c> argument. Use the overload that accepts <c>filter</c> instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="scope"> The target scope. </param>
        /// <param name="recommendationScope"> Reservation recommendation scope (Single/Shared). </param>
        /// <param name="region"> Azure region. </param>
        /// <param name="term"> Reservation term. </param>
        /// <param name="lookBackPeriod"> Look-back period. </param>
        /// <param name="product"> Product family. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Response<ConsumptionReservationRecommendationDetails> GetConsumptionReservationRecommendationDetails(this ArmClient client, ResourceIdentifier scope, ConsumptionReservationRecommendationScope recommendationScope, string region, ConsumptionReservationRecommendationTerm term, ConsumptionReservationRecommendationLookBackPeriod lookBackPeriod, string product, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This extension method is obsolete.");

        /// <summary> Obsolete back-compat overload without the <c>filter</c> argument. Use the overload that accepts <c>filter</c> instead. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> instance. </param>
        /// <param name="scope"> The target scope. </param>
        /// <param name="recommendationScope"> Reservation recommendation scope (Single/Shared). </param>
        /// <param name="region"> Azure region. </param>
        /// <param name="term"> Reservation term. </param>
        /// <param name="lookBackPeriod"> Look-back period. </param>
        /// <param name="product"> Product family. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [Obsolete("This method is obsolete.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Task<Response<ConsumptionReservationRecommendationDetails>> GetConsumptionReservationRecommendationDetailsAsync(this ArmClient client, ResourceIdentifier scope, ConsumptionReservationRecommendationScope recommendationScope, string region, ConsumptionReservationRecommendationTerm term, ConsumptionReservationRecommendationLookBackPeriod lookBackPeriod, string product, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This extension method is obsolete.");
    }
}
