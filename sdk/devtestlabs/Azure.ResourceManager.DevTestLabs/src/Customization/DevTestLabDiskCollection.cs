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
    /// A class representing a collection of <see cref="DevTestLabDiskResource" /> and their operations.
    /// Each <see cref="DevTestLabDiskResource" /> in the collection will belong to the same instance of <see cref="DevTestLabUserResource" />.
    /// To get a <see cref="DevTestLabDiskCollection" /> instance call the GetDevTestLabDisks method from an instance of <see cref="DevTestLabUserResource" />.
    /// </summary>
    public partial class DevTestLabDiskCollection : ArmCollection, IEnumerable<DevTestLabDiskResource>, IAsyncEnumerable<DevTestLabDiskResource>
    {
        /// <summary>
        /// List disks in a given user profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users/{userName}/disks
        /// Operation Id: Disks_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=diskType)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabDiskResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabDiskResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabDiskResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabDiskDisksClientDiagnostics.CreateScope("DevTestLabDiskCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabDiskDisksRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabDiskResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabDiskResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabDiskDisksClientDiagnostics.CreateScope("DevTestLabDiskCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabDiskDisksRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabDiskResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List disks in a given user profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users/{userName}/disks
        /// Operation Id: Disks_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=diskType)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabDiskResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabDiskResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabDiskResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabDiskDisksClientDiagnostics.CreateScope("DevTestLabDiskCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabDiskDisksRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabDiskResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabDiskResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabDiskDisksClientDiagnostics.CreateScope("DevTestLabDiskCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabDiskDisksRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabDiskResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
