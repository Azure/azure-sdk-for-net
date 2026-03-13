// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Search.Models;

namespace Azure.ResourceManager.Search
{
    public partial class SearchServiceResource
    {
        // Convenience overloads without SearchManagementRequestOptions.
        // The generated tag helper methods call Get/Update without the @params
        // parameter. These overloads delegate to the full signatures with null.

        /// <summary> Gets the search service with the given name in the given resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SearchServiceResource>> GetAsync(CancellationToken cancellationToken)
            => await GetAsync(new SearchManagementRequestOptions(), cancellationToken).ConfigureAwait(false);

        /// <summary> Gets the search service with the given name in the given resource group. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SearchServiceResource> Get(CancellationToken cancellationToken)
            => Get(new SearchManagementRequestOptions(), cancellationToken);

        /// <summary> Updates an existing search service in the given resource group. </summary>
        /// <param name="patch"> The definition of the search service to update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<SearchServiceResource>> UpdateAsync(SearchServicePatch patch, CancellationToken cancellationToken)
            => await UpdateAsync(patch, new SearchManagementRequestOptions(), cancellationToken).ConfigureAwait(false);

        /// <summary> Updates an existing search service in the given resource group. </summary>
        /// <param name="patch"> The definition of the search service to update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<SearchServiceResource> Update(SearchServicePatch patch, CancellationToken cancellationToken)
            => Update(patch, new SearchManagementRequestOptions(), cancellationToken);
    }
}
