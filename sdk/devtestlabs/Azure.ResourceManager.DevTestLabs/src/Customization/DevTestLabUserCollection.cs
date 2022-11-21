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
    /// A class representing a collection of <see cref="DevTestLabUserResource" /> and their operations.
    /// Each <see cref="DevTestLabUserResource" /> in the collection will belong to the same instance of <see cref="DevTestLabResource" />.
    /// To get a <see cref="DevTestLabUserCollection" /> instance call the GetDevTestLabUsers method from an instance of <see cref="DevTestLabResource" />.
    /// </summary>
    public partial class DevTestLabUserCollection : ArmCollection, IEnumerable<DevTestLabUserResource>, IAsyncEnumerable<DevTestLabUserResource>
    {
        /// <summary>
        /// List user profiles in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users
        /// Operation Id: Users_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=identity)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DevTestLabUserResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DevTestLabUserResource> GetAllAsync(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DevTestLabUserResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabUserUsersClientDiagnostics.CreateScope("DevTestLabUserCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabUserUsersRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabUserResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DevTestLabUserResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabUserUsersClientDiagnostics.CreateScope("DevTestLabUserCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _devTestLabUserUsersRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabUserResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// List user profiles in a given lab.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DevTestLab/labs/{labName}/users
        /// Operation Id: Users_List
        /// </summary>
        /// <param name="expand"> Specify the $expand query. Example: &apos;properties($select=identity)&apos;. </param>
        /// <param name="filter"> The filter to apply to the operation. Example: &apos;$filter=contains(name,&apos;myName&apos;). </param>
        /// <param name="top"> The maximum number of resources to return from the operation. Example: &apos;$top=10&apos;. </param>
        /// <param name="orderby"> The ordering expression for the results, using OData notation. Example: &apos;$orderby=name desc&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DevTestLabUserResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DevTestLabUserResource> GetAll(string expand = null, string filter = null, int? top = null, string orderby = null, CancellationToken cancellationToken = default)
        {
            Page<DevTestLabUserResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _devTestLabUserUsersClientDiagnostics.CreateScope("DevTestLabUserCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabUserUsersRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabUserResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DevTestLabUserResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _devTestLabUserUsersClientDiagnostics.CreateScope("DevTestLabUserCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _devTestLabUserUsersRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand, filter, top, orderby, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DevTestLabUserResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
