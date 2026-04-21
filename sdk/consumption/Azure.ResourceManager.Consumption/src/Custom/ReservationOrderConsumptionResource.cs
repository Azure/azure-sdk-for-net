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

namespace Azure.ResourceManager.Consumption
{
    // This type was removed during TypeSpec migration.
    // Stub retained for backward compatibility.
    [Obsolete("This type is obsolete and will be removed in a future release.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ReservationOrderConsumptionResource : ArmResource
    {
        public static readonly ResourceType ResourceType = "Microsoft.Capacity/reservationOrders";

        protected ReservationOrderConsumptionResource()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionReservationDetail> GetReservationDetails(string filter, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionReservationDetail> GetReservationDetailsAsync(string filter, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionReservationSummary> GetReservationSummaries(ReservationSummaryDataGrain grain, string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionReservationSummary> GetReservationSummariesAsync(ReservationSummaryDataGrain grain, string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }
    }
}
