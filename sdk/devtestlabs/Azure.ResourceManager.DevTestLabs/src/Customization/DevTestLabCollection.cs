// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.DevTestLabs
{
    /// <summary>
    /// A class representing a collection of <see cref="DevTestLabResource" /> and their operations.
    /// Each <see cref="DevTestLabResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="DevTestLabCollection" /> instance call the GetDevTestLabs method from an instance of <see cref="ResourceGroupResource" />.
    /// </summary>
    public partial class DevTestLabCollection : ArmCollection, IEnumerable<DevTestLabResource>, IAsyncEnumerable<DevTestLabResource>
    {
        /// <summary>
        /// List labs in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs
        /// Operation Id: Labs_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=defaultStorageAccount)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabLabsClientDiagnostics.CreateScope("DevTestLabCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabLabsRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabLabsClientDiagnostics.CreateScope("DevTestLabCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabLabsRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List labs in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs
        /// Operation Id: Labs_ListByResourceGroup
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=defaultStorageAccount)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabLabsClientDiagnostics.CreateScope("DevTestLabCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabLabsRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabLabsClientDiagnostics.CreateScope("DevTestLabCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabLabsRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
