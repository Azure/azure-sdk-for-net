// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Extension methods for <see cref="SearchIndexingBufferedSender{T}"/>.
    /// </summary>
    public static class SearchIndexingBufferedSenderExtensions
    {
        /// <summary>
        /// Adds a batch of delete actions to eventually send to the search
        /// index.
        /// </summary>
        /// <param name="indexer">The sender.</param>
        /// <param name="keyFieldName">The name of the key field.</param>
        /// <param name="documentKeys">
        /// The keys of the documents to delete.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        public static void DeleteDocuments(
            this SearchIndexingBufferedSender<SearchDocument> indexer,
            string keyFieldName,
            IEnumerable<string> documentKeys,
            CancellationToken cancellationToken = default) =>
            DeleteDocumentsInternal(
                indexer,
                keyFieldName,
                documentKeys,
                async: false,
                cancellationToken)
                .EnsureCompleted();

        /// <summary>
        /// Adds a batch of delete actions to eventually send to the search
        /// index.
        /// </summary>
        /// <param name="indexer">The sender.</param>
        /// <param name="keyFieldName">The name of the key field.</param>
        /// <param name="documentKeys">
        /// The keys of the documents to delete.
        /// </param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A task that completes when the indexing actions have been added but
        /// not yet sent.
        /// </returns>
        public static async Task DeleteDocumentsAsync(
            this SearchIndexingBufferedSender<SearchDocument> indexer,
            string keyFieldName,
            IEnumerable<string> documentKeys,
            CancellationToken cancellationToken = default) =>
            await DeleteDocumentsInternal(
                indexer,
                keyFieldName,
                documentKeys,
                async: true,
                cancellationToken)
                .ConfigureAwait(false);

        private static async Task DeleteDocumentsInternal(
            SearchIndexingBufferedSender<SearchDocument> indexer,
            string keyFieldName,
            IEnumerable<string> documentKeys,
            bool async,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(indexer, nameof(indexer));
            Argument.AssertNotNull(keyFieldName, nameof(keyFieldName));
            Argument.AssertNotNull(documentKeys, nameof(documentKeys));

            var batch = IndexDocumentsBatch.Delete<SearchDocument>(
                documentKeys.Select(k => new SearchDocument { [keyFieldName] = k }));
            if (async)
            {
                await indexer.IndexDocumentsAsync(batch, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                indexer.IndexDocuments(batch, cancellationToken);
            }
        }
    }
}
