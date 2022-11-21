// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary>
    /// A class representing a collection of <see cref="DevTestLabServiceFabricResource" /> and their operations.
    /// Each <see cref="DevTestLabServiceFabricResource" /> in the collection will belong to the same instance of <see cref="DevTestLabUserResource" />.
    /// To get a <see cref="DevTestLabServiceFabricCollection" /> instance call the GetDevTestLabServiceFabrics method from an instance of <see cref="DevTestLabUserResource" />.
    /// </summary>
    public partial class DevTestLabServiceFabricCollection : ArmCollection, IEnumerable<DevTestLabServiceFabricResource>, IAsyncEnumerable<DevTestLabServiceFabricResource>
    {
        /// <summary>
        /// List service fabrics in a given user profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users/{userName}/servicefabrics
        /// Operation Id: ServiceFabrics_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($expand=applicableSchedule)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabServiceFabricResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabServiceFabricResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabServiceFabricResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabServiceFabricServiceFabricsClientDiagnostics.CreateScope("DevTestLabServiceFabricCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabServiceFabricServiceFabricsRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabServiceFabricResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabServiceFabricResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabServiceFabricServiceFabricsClientDiagnostics.CreateScope("DevTestLabServiceFabricCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabServiceFabricServiceFabricsRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabServiceFabricResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List service fabrics in a given user profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users/{userName}/servicefabrics
        /// Operation Id: ServiceFabrics_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($expand=applicableSchedule)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabServiceFabricResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabServiceFabricResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabServiceFabricResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabServiceFabricServiceFabricsClientDiagnostics.CreateScope("DevTestLabServiceFabricCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabServiceFabricServiceFabricsRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabServiceFabricResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabServiceFabricResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabServiceFabricServiceFabricsClientDiagnostics.CreateScope("DevTestLabServiceFabricCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabServiceFabricServiceFabricsRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabServiceFabricResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
