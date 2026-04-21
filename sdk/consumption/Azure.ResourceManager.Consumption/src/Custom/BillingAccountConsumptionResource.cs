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
    public partial class BillingAccountConsumptionResource : ArmResource
    {
        public static readonly ResourceType ResourceType = "Microsoft.Billing/billingAccounts";

        protected BillingAccountConsumptionResource()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ConsumptionBalanceResult> GetBalance(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<ConsumptionBalanceResult>> GetBalanceAsync(CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionEventSummary> GetEvents(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionEventSummary> GetEventsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionLotSummary> GetLots(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionLotSummary> GetLotsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ConsumptionReservationTransaction> GetReservationTransactions(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ConsumptionReservationTransaction> GetReservationTransactionsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This resource type has been removed in the TypeSpec migration.");
        }
    }
}
