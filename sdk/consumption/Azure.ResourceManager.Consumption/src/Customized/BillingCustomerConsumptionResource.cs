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
    /// A class extending from the BillingCustomerResource in Azure.ResourceManager.Consumption along with the instance operations that can be performed on it.
    /// You can only construct a <see cref="BillingCustomerConsumptionResource" /> from a <see cref="ResourceIdentifier" /> with a resource type of Microsoft.Billing/billingAccounts/customers.
    /// </summary>
    public partial class BillingCustomerConsumptionResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="BillingCustomerConsumptionResource"/> instance. </summary>
        internal static ResourceIdentifier CreateResourceIdentifier(string billingAccountId, string customerId)
        {
            var resourceId = $"/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _lotsClientDiagnostics;
        private readonly LotsRestOperations _lotsRestClient;

        /// <summary> Initializes a new instance of the <see cref="BillingCustomerConsumptionResource"/> class for mocking. </summary>
        protected BillingCustomerConsumptionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BillingCustomerConsumptionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal BillingCustomerConsumptionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _lotsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Consumption", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _lotsRestClient = new LotsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Billing/billingAccounts/customers";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Lists all Azure credits for a customer. The API is only supported for Microsoft Partner  Agreements (MPA) billing accounts.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}/providers/Microsoft.Consumption/lots</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Lots_ListByCustomer</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> May be used to filter the lots by Status, Source etc. The filter supports &apos;eq&apos;, &apos;lt&apos;, &apos;gt&apos;, &apos;le&apos;, &apos;ge&apos;, and &apos;and&apos;. Tag filter is a key value pair string where key and value is separated by a colon (:). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ConsumptionLotSummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ConsumptionLotSummary> GetLotsAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ConsumptionLotSummary>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _lotsClientDiagnostics.CreateScope("BillingCustomerConsumptionResource.GetLots");
                scope.Start();
                try
                {
                    var response = await _lotsRestClient.ListByCustomerAsync(Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _lotsClientDiagnostics.CreateScope("BillingCustomerConsumptionResource.GetLots");
                scope.Start();
                try
                {
                    var response = await _lotsRestClient.ListByCustomerNextPageAsync(nextLink, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Lists all Azure credits for a customer. The API is only supported for Microsoft Partner  Agreements (MPA) billing accounts.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.Billing/billingAccounts/{billingAccountId}/customers/{customerId}/providers/Microsoft.Consumption/lots</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Lots_ListByCustomer</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filter"> May be used to filter the lots by Status, Source etc. The filter supports &apos;eq&apos;, &apos;lt&apos;, &apos;gt&apos;, &apos;le&apos;, &apos;ge&apos;, and &apos;and&apos;. Tag filter is a key value pair string where key and value is separated by a colon (:). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ConsumptionLotSummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ConsumptionLotSummary> GetLots(string filter = null, CancellationToken cancellationToken = default)
        {
            Page<ConsumptionLotSummary> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _lotsClientDiagnostics.CreateScope("BillingCustomerConsumptionResource.GetLots");
                scope.Start();
                try
                {
                    var response = _lotsRestClient.ListByCustomer(Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken);
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
                using var scope = _lotsClientDiagnostics.CreateScope("BillingCustomerConsumptionResource.GetLots");
                scope.Start();
                try
                {
                    var response = _lotsRestClient.ListByCustomerNextPage(nextLink, Id.Parent.Name, Id.Name, filter, cancellationToken: cancellationToken);
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
    }
}
