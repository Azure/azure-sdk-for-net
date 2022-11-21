// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Storage
{
    /// <summary>
    /// A class representing a collection of <see cref="FileShareResource" /> and their operations.
    /// Each <see cref="FileShareResource" /> in the collection will belong to the same instance of <see cref="FileServiceResource" />.
    /// To get a <see cref="FileShareCollection" /> instance call the GetFileShares method from an instance of <see cref="FileServiceResource" />.
    /// </summary>
    public partial class FileShareCollection : ArmCollection, IEnumerable<FileShareResource>, IAsyncEnumerable<FileShareResource>
    {
        /// <summary>
        /// Lists all shares.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares
        /// Operation Id: FileShares_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of shares that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only share names starting with the filter will be listed. </param>
        /// <param name="expand"> Optional, used to expand the properties within share&apos;s properties. Valid values are: deleted, snapshots. Should be passed as a string with delimiter &apos;,&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="FileShareResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FileShareResource> GetAllAsync(string maxpagesize = null, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<FileShareResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fileShareRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, maxpagesize, filter, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FileShareResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<FileShareResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _fileShareRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, maxpagesize, filter, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new FileShareResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all shares.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Storage/storageAccounts/{accountName}/fileServices/default/shares
        /// Operation Id: FileShares_List
        /// </summary>
        /// <param name="maxpagesize"> Optional. Specified maximum number of shares that can be included in the list. </param>
        /// <param name="filter"> Optional. When specified, only share names starting with the filter will be listed. </param>
        /// <param name="expand"> Optional, used to expand the properties within share&apos;s properties. Valid values are: deleted, snapshots. Should be passed as a string with delimiter &apos;,&apos;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="FileShareResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FileShareResource> GetAll(string maxpagesize = null, string filter = null, string expand = null, CancellationToken cancellationToken = default)
        {
            Page<FileShareResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fileShareRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, maxpagesize, filter, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FileShareResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<FileShareResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _fileShareClientDiagnostics.CreateScope("FileShareCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _fileShareRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, maxpagesize, filter, expand, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new FileShareResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
