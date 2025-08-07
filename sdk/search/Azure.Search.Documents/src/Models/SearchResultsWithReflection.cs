// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;

#pragma warning disable SA1402 // File may only contain a single type

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
