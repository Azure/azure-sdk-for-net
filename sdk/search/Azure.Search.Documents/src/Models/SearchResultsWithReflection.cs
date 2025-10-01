// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Response containing search results from an index.
    /// </summary>
    internal class SearchResultsWithReflection<T> : SearchResults<T>
    {
        /// <summary>
        /// Initializes a new instance of the SearchResultsWithReflection class.
        /// </summary>
        [RequiresUnreferencedCode(JsonSerialization.TrimWarning)]
        internal SearchResultsWithReflection() { }

        /// <summary>
        /// Get the next (server-side) page of results.
        /// </summary>
        /// <param name="async">
        /// Whether to execute synchronously or asynchronously.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>The next page of SearchResults.</returns>
        internal override async Task<SearchResults<T>> GetNextPageAsync(bool async, CancellationToken cancellationToken)
        {
            SearchResults<T> next = null;
            if (_pagingClient != null && NextOptions != null)
            {
                next = async ?
                    await _pagingClient.SearchAsync<T>(
                        NextOptions.SearchText,
                        NextOptions,
                        cancellationToken)
                        .ConfigureAwait(false) :
                    _pagingClient.Search<T>(
                        NextOptions.SearchText,
                        NextOptions,
                        cancellationToken);
            }
            return next;
        }
    }
}
