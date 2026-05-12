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
    /// Obsolete backward-compatibility stub for the reservation-scoped consumption resource that
    /// existed in the v1.1.0 surface. The TypeSpec migration replaced this wrapper with scope-based
    /// extension methods on <see cref="ArmClient"/>; this type now throws on every member and is
    /// hidden from IntelliSense. Use the scope-based <c>GetConsumptionReservationDetails</c> and
    /// <c>GetConsumptionReservationSummaries</c> extension methods on <see cref="ArmClient"/> instead.
    /// </summary>
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ReservationConsumptionResource : ArmResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Capacity/reservationOrders/reservations";

        /// <summary> Initializes a new instance of the <see cref="ReservationConsumptionResource"/> class for mocking. </summary>
        protected ReservationConsumptionResource()
        {
        }

        /// <summary> Obsolete. Use the scope-based <c>GetConsumptionReservationDetails</c> extension method on <see cref="ArmClient"/> instead. </summary>
        /// <param name="filter"> Required OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionReservationDetail> GetReservationDetails(string filter, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionReservationDetails(scope, filter) instead.");
        }

        /// <summary> Obsolete. Use the scope-based <c>GetConsumptionReservationDetailsAsync</c> extension method on <see cref="ArmClient"/> instead. </summary>
        /// <param name="filter"> Required OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionReservationDetail> GetReservationDetailsAsync(string filter, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionReservationDetailsAsync(scope, filter) instead.");
        }

        /// <summary> Obsolete. Use the scope-based <c>GetConsumptionReservationSummaries</c> extension method on <see cref="ArmClient"/> instead. </summary>
        /// <param name="grain"> Reservation summary data grain (daily/monthly). </param>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionReservationSummary> GetReservationSummaries(ReservationSummaryDataGrain grain, string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionReservationSummaries(scope, grain, filter) instead.");
        }

        /// <summary> Obsolete. Use the scope-based <c>GetConsumptionReservationSummariesAsync</c> extension method on <see cref="ArmClient"/> instead. </summary>
        /// <param name="grain"> Reservation summary data grain (daily/monthly). </param>
        /// <param name="filter"> Optional OData filter expression. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionReservationSummary> GetReservationSummariesAsync(ReservationSummaryDataGrain grain, string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration. Use ArmClient.GetConsumptionReservationSummariesAsync(scope, grain, filter) instead.");
        }
    }
}
