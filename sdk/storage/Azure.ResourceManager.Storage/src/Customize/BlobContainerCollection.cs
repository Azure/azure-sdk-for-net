// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing a collection of <see cref="BlobContainerResource" /> and their operations.
    /// Each <see cref="BlobContainerResource" /> in the collection will belong to the same instance of <see cref="BlobServiceResource" />.
    /// To get a <see cref="BlobContainerCollection" /> instance call the GetBlobContainers method from an instance of <see cref="BlobServiceResource" />.
    /// </summary>
    public partial class BlobContainerCollection : ArmCollection, IEnumerable<BlobContainerResource>, IAsyncEnumerable<BlobContainerResource>
    {
        /// <summary>
        /// Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers
        /// Operation Id: BlobContainers_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only container names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, used to include the properties for soft deleted blob containers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BlobContainerResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BlobContainerResource> GetAllAsync(string maxpagesize = null, string filter = null, BlobContainerState? include = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<BlobContainerResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _blobContainerRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, maxpagesize, filter, include, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BlobContainerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<BlobContainerResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _blobContainerRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, maxpagesize, filter, include, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BlobContainerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all containers and does not support a prefix like data plane. Also SRP today does not return continuation token.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/blobServices/default/containers
        /// Operation Id: BlobContainers_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of containers that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only container names starting with the filter will be listed. </param>
        /// <param name="include"> Optional, used to include the properties for soft deleted blob containers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BlobContainerResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BlobContainerResource> GetAll(string maxpagesize = null, string filter = null, BlobContainerState? include = null, CancellationToken cancellationToken = default)
        {
            Page<BlobContainerResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _blobContainerRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, maxpagesize, filter, include, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BlobContainerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<BlobContainerResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _blobContainerClientDiagnostics.CreateScope("BlobContainerCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _blobContainerRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, maxpagesize, filter, include, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BlobContainerResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
