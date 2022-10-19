// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Consumption.Models;

namespace Azure.ResourceManager.Consumption
{
    /// <summary>
    /// A class extending from the BillingProfileResource in Azure.ResourceManager.Consumption along with the instance operations that can be performed on it.
    /// You can only construct a <see cref="BillingProfileConsumptionResource" /> from a <see cref="ResourceIdentifier" /> with a resource type of Microsoft.Billing/billingAccounts/billingProfiles.
    /// </summary>
    public partial class BillingProfileConsumptionResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="BillingProfileConsumptionResource"/> instance. </summary>
        internal static ResourceIdentifier CreateResourceIdentifier(string billingAccountId, string billingProfileId)
        {
            var resourceId = $"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _reservationTransactionsClientDiagnostics;
        private readonly ReservationTransactionsRestOperations _reservationTransactionsRestClient;
        private readonly ClientDiagnostics _eventsClientDiagnostics;
        private readonly EventsRestOperations _eventsRestClient;
        private readonly ClientDiagnostics _lotsClientDiagnostics;
        private readonly LotsRestOperations _lotsRestClient;
        private readonly ClientDiagnostics _creditsClientDiagnostics;
        private readonly CreditsRestOperations _creditsRestClient;

        /// <summary> Initializes a new instance of the <see cref="BillingProfileConsumptionResource"/> class for mocking. </summary>
        protected BillingProfileConsumptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BillingProfileConsumptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BillingProfileConsumptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _reservationTransactionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Consumption", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _reservationTransactionsRestClient = new ReservationTransactionsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _eventsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Consumption", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _eventsRestClient = new EventsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _lotsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Consumption", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _lotsRestClient = new LotsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _creditsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Consumption", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _creditsRestClient = new CreditsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Billing/billingAccounts/billingProfiles";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// List of transactions for reserved instances on billing profile scope. The refund transactions are posted along with its purchase transaction (i.e. in the purchase billing month). For example, The refund is requested in May 2021. This refund transaction will have event date as May 2021 but the billing month as April 2020 when the reservation purchase was made.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/providers/Microsoft.Consumption/reservationTransactions
        /// Operation Id: ReservationTransactions_ListByBillingProfile
        /// </summary>
        /// <param name="filter"> Filter reservation transactions by date range. The properties/EventDate for start date and end date. The filter supports &apos;le&apos; and  &apos;ge&apos;. Note: API returns data for the entire start date&apos;s and end date&apos;s billing month. For example, filter properties/eventDate+ge+2020-01-01+AND+properties/eventDate+le+2020-12-29 will include data for entire December 2020 month (i.e. will contain records for dates December 30 and 31). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ConsumptionModernReservationTransaction" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ConsumptionModernReservationTransaction> GetReservationTransactionsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ConsumptionModernReservationTransaction>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _reservationTransactionsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetReservationTransactions");
                scope.Start();
                try
                {
                    var response = await _reservationTransactionsRestClient.ListByBillingProfileAsync(Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ConsumptionModernReservationTransaction>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _reservationTransactionsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetReservationTransactions");
                scope.Start();
                try
                {
                    var response = await _reservationTransactionsRestClient.ListByBillingProfileNextPageAsync(nextLink, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// List of transactions for reserved instances on billing profile scope. The refund transactions are posted along with its purchase transaction (i.e. in the purchase billing month). For example, The refund is requested in May 2021. This refund transaction will have event date as May 2021 but the billing month as April 2020 when the reservation purchase was made.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/providers/Microsoft.Consumption/reservationTransactions
        /// Operation Id: ReservationTransactions_ListByBillingProfile
        /// </summary>
        /// <param name="filter"> Filter reservation transactions by date range. The properties/EventDate for start date and end date. The filter supports &apos;le&apos; and  &apos;ge&apos;. Note: API returns data for the entire start date&apos;s and end date&apos;s billing month. For example, filter properties/eventDate+ge+2020-01-01+AND+properties/eventDate+le+2020-12-29 will include data for entire December 2020 month (i.e. will contain records for dates December 30 and 31). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ConsumptionModernReservationTransaction" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ConsumptionModernReservationTransaction> GetReservationTransactions(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ConsumptionModernReservationTransaction> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _reservationTransactionsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetReservationTransactions");
                scope.Start();
                try
                {
                    var response = _reservationTransactionsRestClient.ListByBillingProfile(Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ConsumptionModernReservationTransaction> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _reservationTransactionsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetReservationTransactions");
                scope.Start();
                try
                {
                    var response = _reservationTransactionsRestClient.ListByBillingProfileNextPage(nextLink, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the events that decrements Azure credits or Microsoft Azure consumption commitment for a billing account or a billing profile for a given start and end date.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/providers/Microsoft.Consumption/events
        /// Operation Id: Events_ListByBillingProfile
        /// </summary>
        /// <param name="startDate"> Start date. </param>
        /// <param name="endDate"> End date. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="startDate"/> or <paramref name="endDate"/> is null. </exception>
        /// <returns> An async collection of <see cref="ConsumptionEventSummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ConsumptionEventSummary> GetEventsAsync(string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(startDate, nameof(startDate));
            Argument.AssertNotNull(endDate, nameof(endDate));

            async Task<Page<ConsumptionEventSummary>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _eventsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetEvents");
                scope.Start();
                try
                {
                    var response = await _eventsRestClient.ListByBillingProfileAsync(Id.Parent.Name, Id.Name, startDate, endDate, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ConsumptionEventSummary>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _eventsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetEvents");
                scope.Start();
                try
                {
                    var response = await _eventsRestClient.ListByBillingProfileNextPageAsync(nextLink, Id.Parent.Name, Id.Name, startDate, endDate, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the events that decrements Azure credits or Microsoft Azure consumption commitment for a billing account or a billing profile for a given start and end date.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/providers/Microsoft.Consumption/events
        /// Operation Id: Events_ListByBillingProfile
        /// </summary>
        /// <param name="startDate"> Start date. </param>
        /// <param name="endDate"> End date. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="startDate"/> or <paramref name="endDate"/> is null. </exception>
        /// <returns> A collection of <see cref="ConsumptionEventSummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ConsumptionEventSummary> GetEvents(string startDate, string endDate, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(startDate, nameof(startDate));
            Argument.AssertNotNull(endDate, nameof(endDate));

            Page<ConsumptionEventSummary> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _eventsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetEvents");
                scope.Start();
                try
                {
                    var response = _eventsRestClient.ListByBillingProfile(Id.Parent.Name, Id.Name, startDate, endDate, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ConsumptionEventSummary> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _eventsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetEvents");
                scope.Start();
                try
                {
                    var response = _eventsRestClient.ListByBillingProfileNextPage(nextLink, Id.Parent.Name, Id.Name, startDate, endDate, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists all Azure credits for a billing account or a billing profile. The API is only supported for Microsoft Customer Agreements (MCA) billing accounts.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/providers/Microsoft.Consumption/lots
        /// Operation Id: Lots_ListByBillingProfile
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ConsumptionLotSummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ConsumptionLotSummary> GetLotsAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ConsumptionLotSummary>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _lotsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetLots");
                scope.Start();
                try
                {
                    var response = await _lotsRestClient.ListByBillingProfileAsync(Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ConsumptionLotSummary>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _lotsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetLots");
                scope.Start();
                try
                {
                    var response = await _lotsRestClient.ListByBillingProfileNextPageAsync(nextLink, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists all Azure credits for a billing account or a billing profile. The API is only supported for Microsoft Customer Agreements (MCA) billing accounts.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/providers/Microsoft.Consumption/lots
        /// Operation Id: Lots_ListByBillingProfile
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ConsumptionLotSummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ConsumptionLotSummary> GetLots(CancellationToken cancellationToken = default)
        {
            Page<ConsumptionLotSummary> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _lotsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetLots");
                scope.Start();
                try
                {
                    var response = _lotsRestClient.ListByBillingProfile(Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ConsumptionLotSummary> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _lotsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetLots");
                scope.Start();
                try
                {
                    var response = _lotsRestClient.ListByBillingProfileNextPage(nextLink, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// The credit summary by billingAccountId and billingProfileId.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/providers/Microsoft.Consumption/credits/balanceSummary
        /// Operation Id: Credits_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ConsumptionCreditSummary>> GetCreditAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _creditsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetCredit");
            scope.Start();
            try
            {
                var response = await _creditsRestClient.GetAsync(Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// The credit summary by billingAccountId and billingProfileId.
        /// Request Path: /providers/Microsoft.Billing/billingAccounts/{billingAccountId}/billingProfiles/{billingProfileId}/providers/Microsoft.Consumption/credits/balanceSummary
        /// Operation Id: Credits_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ConsumptionCreditSummary> GetCredit(CancellationToken cancellationToken = default)
        {
            using var scope = _creditsClientDiagnostics.CreateScope("BillingProfileConsumptionResource.GetCredit");
            scope.Start();
            try
            {
                var response = _creditsRestClient.Get(Id.Parent.Name, Id.Name, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
