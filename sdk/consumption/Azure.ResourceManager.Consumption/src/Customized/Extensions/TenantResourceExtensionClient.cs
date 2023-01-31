// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Consumption.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Consumption
{
    /// <summary> A class to add extension methods to TenantResource. </summary>
    [CodeGenSuppress("GetBalanceAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetBalance", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetBalanceAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetBalance", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationSummariesAsync", typeof(string), typeof(ReservationSummaryDataGrain), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationSummaries", typeof(string), typeof(ReservationSummaryDataGrain), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationSummariesAsync", typeof(string), typeof(string), typeof(ReservationSummaryDataGrain), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationSummaries", typeof(string), typeof(string), typeof(ReservationSummaryDataGrain), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationDetailsAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationDetails", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationDetailsAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationDetails", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationTransactionsAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationTransactions", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationTransactionsAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetReservationTransactions", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEventsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEvents", typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEventsAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetEvents", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLotsByBillingProfileAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLotsByBillingProfile", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLotsAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLots", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLotsAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetLots", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCreditAsync", typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetCredit", typeof(string), typeof(string), typeof(CancellationToken))]
    internal partial class TenantResourceExtensionClient : ArmResource
    {
    }
}
