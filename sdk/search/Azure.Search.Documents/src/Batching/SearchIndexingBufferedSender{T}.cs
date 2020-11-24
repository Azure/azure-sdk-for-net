// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Search.Documents.Batching;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Index search documents with intelligent batching, automatic flushing,
    /// and retries for failed indexing actions.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema.  Instances of this
    /// type can be retrieved as documents from the index. You can use
    /// <see cref="SearchDocument"/> for dynamic documents.
    /// </typeparam>
    public class SearchIndexingBufferedSender<T> : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Flag indicating whether the sender has been disposed.
        /// </summary>
        private volatile int _disposed;

        /// <summary>
        /// The single publisher responsible for submitting requests.
        /// </summary>
#pragma warning disable CA2213 // Member should be disposed. Disposed in DisposeAsync
        private SearchIndexingPublisher<T> _publisher;
#pragma warning restore CA2213 // Member should be disposed. Disposed in DisposeAsync

        /// <summary>
        /// Gets the <see cref="SearchClient"/> used to send requests to the
        /// service.
        /// </summary>
        internal virtual SearchClient SearchClient { get; }

        /// <summary>
        /// Gets the URI endpoint of the Search Service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        /// <remarks>
        /// This is not the URI of the Search Index.  You could construct that
        /// URI with "{Endpoint}/indexes/{IndexName}" if needed.
        /// </remarks>
        public virtual Uri Endpoint => SearchClient.Endpoint;

        /// <summary>
        /// Gets the name of the Search Service.
        /// </summary>
        public virtual string ServiceName => SearchClient.ServiceName;

        /// <summary>
        /// Gets the name of the Search Index.
        /// </summary>
        public virtual string IndexName => SearchClient.IndexName;

        /// <summary>
        /// Gets a function that can be used to access the index key value of a
        /// document.
        /// </summary>
        internal virtual Func<T, string> KeyFieldAccessor { get; private set; }

        /// <summary>
        /// Task used to minimize simultaneous requests for the key field
        /// accessor.
        /// </summary>
        private Task _getKeyFieldAccessorTask;

        /// <summary>
        /// Async event raised whenever an indexing action is added to the
        /// sender.
        /// </summary>
        public event Func<IndexDocumentsAction<T>, CancellationToken, Task> ActionAddedAsync;

        /// <summary>
        /// Async event raised whenever an indexing action is sent by the
        /// sender.
        /// </summary>
        public event Func<IndexDocumentsAction<T>, CancellationToken, Task> ActionSentAsync;

        /// <summary>
        /// Async event raised whenever an indexing action was submitted
        /// successfully.
        /// </summary>
        public event Func<IndexDocumentsAction<T>, IndexingResult, CancellationToken, Task> ActionCompletedAsync;

        /// <summary>
        /// Async event raised whenever an indexing action failed.  The
        /// <see cref="IndexingResult"/> or <see cref="Exception"/> may be null
        /// depending on the failure.
        /// </summary>
        public event Func<IndexDocumentsAction<T>, IndexingResult, Exception, CancellationToken, Task> ActionFailedAsync;

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected SearchIndexingBufferedSender() { }

        /// <summary>
        /// Creates a new instance of the SearchIndexingBufferedSender.
        /// </summary>
        /// <param name="searchClient">
        /// The SearchClient used to send requests to the service.
        /// </param>
        /// <param name="options">
        /// Provides the configuration options for the sender.
        /// </param>
        internal SearchIndexingBufferedSender(
            SearchClient searchClient,
            SearchIndexingBufferedSenderOptions<T> options = null)
        {
            Argument.AssertNotNull(searchClient, nameof(searchClient));
            SearchClient = searchClient;

            options ??= new SearchIndexingBufferedSenderOptions<T>();
            KeyFieldAccessor = options.KeyFieldAccessor;
            _publisher = new SearchIndexingPublisher<T>(
                this,
                options.AutoFlush,
                options.AutoFlushInterval,
                options.InitialBatchActionCount,
                options.BatchPayloadSize,
                options.MaxRetries,
                options.RetryDelay,
                options.MaxRetryDelay,
                options.FlushCancellationToken);
        }

        #region Dispose
        /// <summary>
        /// Flush any remaining work and clean up resources.
        /// </summary>
        #pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        void IDisposable.Dispose() =>
            DisposeAsync(async: false).EnsureCompleted();
        #pragma warning restore CA1816 // Dispose methods should call SuppressFinalize

        /// <summary>
        /// Flush any remaining work and clean up resources.
        /// </summary>
        /// <returns>
        /// A task that will complete when the object has finished disposing.
        /// </returns>
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
        async ValueTask IAsyncDisposable.DisposeAsync() =>
            await DisposeAsync(async: true).ConfigureAwait(false);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize

        /// <summary>
        /// Dispose the sender and flush any remaining indexing actions that
        /// haven't been sent yet.  This will block until everything's been
        /// sent.
        /// </summary>
        /// <param name="async">Whether to call this sync or async.</param>
        /// <returns>A Task that will wait until we're disposed.</returns>
        internal async Task DisposeAsync(bool async)
        {
            if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 0)
            {
                await _publisher.DisposeAsync(async).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Ensure the sender was properly disposed.
        /// </summary>
        ~SearchIndexingBufferedSender()
        {
            if (_publisher?.IndexingActionsCount > 0)
            {
                try
                {
                    #pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException(
                        $"{nameof(SearchIndexingBufferedSender<T>)} has {_publisher.IndexingActionsCount} unsent indexing actions.");
                    #pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                catch (InvalidOperationException)
                {
                }
            }
        }

        /// <summary>
        /// Ensure nobody's trying to use this after it's been disposed.
        /// </summary>
        private void EnsureNotDisposed()
        {
            if (_disposed > 0)
            {
                throw new ObjectDisposedException(nameof(SearchIndexingBufferedSender<T>));
            }
        }
        #endregion Dispose

        #region Get Key Field
        /// <summary>
        /// Ensure we have a valid KeyFieldAccessor (and probe the type or
        /// service to find one).
        /// </summary>
        /// <param name="async">Whether to run sync or async.</param>
        /// <param name="cancellationToken">The Cancellation token.</param>
        /// <returns>A task that will complete after we've checked.</returns>
        private async Task EnsureKeyFieldAccessorAsync(bool async, CancellationToken cancellationToken)
        {
            // Skip initialization if we already have one
            if (KeyFieldAccessor != null) { return; }

            // If we have multiple threads attempting to verify we have a key
            // field we want to minimize possible requests to the service for
            // its index.  We'll only assign the task if it's not null and
            // anyone who gets year later can wait on it with us.
            _getKeyFieldAccessorTask ??= GetKeyFieldAccessorAsync(async, cancellationToken);
            if (async)
            {
                await _getKeyFieldAccessorTask.ConfigureAwait(false);
            }
            else
            {
                #pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                // We're potentially doing sync-over-async if somebody enters
                // on an async code path first and follows up from a sync code
                // path.
                _getKeyFieldAccessorTask.GetAwaiter().GetResult();
                #pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }
        }

        /// <summary>
        /// Get a function to access the key field of a search document.
        /// </summary>
        /// <param name="async">Whether to run sync or async.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task representing the operation.</returns>
        private async Task GetKeyFieldAccessorAsync(bool async, CancellationToken cancellationToken)
        {
            // Case 1: The user provided an explicit accessor and we're done
            if (KeyFieldAccessor != null) { return; }

            // Case 2: Infer the accessor from FieldBuilder
            try
            {
                FieldBuilder builder = new FieldBuilder { Serializer = SearchClient.Serializer };
                IDictionary<string, SearchField> fields = builder.BuildMapping(typeof(T));
                KeyValuePair<string, SearchField> keyField = fields.FirstOrDefault(pair => pair.Value.IsKey == true);
                if (!keyField.Equals(default(KeyValuePair<string, SearchField>)))
                {
                    KeyFieldAccessor = CompileAccessor(keyField.Key);
                    return;
                }
            }
            catch
            {
                // Ignore any errors because this type might not have been
                // designed with FieldBuilder in mind
            }

            // Case 3: Fetch the index to find the key
            Exception failure = null;
            try
            {
                // Call the service to find the name of the key
                SearchIndexClient indexClient = SearchClient.GetSearchIndexClient();
                SearchIndex index = async ?
                    await indexClient.GetIndexAsync(IndexName, cancellationToken).ConfigureAwait(false) :
                    indexClient.GetIndex(IndexName, cancellationToken);
                SearchField keyField = index.Fields.Single(f => f.IsKey == true);
                string key = keyField.Name;

                if (typeof(T).IsAssignableFrom(typeof(SearchDocument)))
                {
                    // Case 3a: If it's a dynamic SearchDocument, lookup
                    // the name of the key in the dictionary
                    KeyFieldAccessor = (T doc) => (doc as SearchDocument)?.GetString(key);
                    return;
                }
                else
                {
                    // Case 3b: We'll see if there's a property with the
                    // same name and use that as the accessor
                    if (typeof(T).GetProperty(key) != null ||
                        typeof(T).GetField(key) != null)
                    {
                        KeyFieldAccessor = CompileAccessor(key);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                // We'll provide any exceptions as a hint because it could
                // be something like using the wrong API Key type when
                // moving from SearchClient up to SearchIndexClient that
                // potentially could be addressed if the user really wanted
                failure = ex;
            }

            // Case 4: Throw and tell the user to provide an explicit accessor.
            throw new InvalidOperationException(
                $"Failed to discover the Key field of document type {typeof(T).Name} for Azure Cognitive Search index {IndexName}.  " +
                $"Please set {typeof(SearchIndexingBufferedSenderOptions<T>).Name}.{nameof(SearchIndexingBufferedSenderOptions<T>.KeyFieldAccessor)} explicitly.",
                failure);

            // Build an accessor for a property named key on type T.  Compiling
            // is kind of heavyweight, but we'll be calling this so many times
            // it's worth it.
            static Func<T, string> CompileAccessor(string key)
            {
                ParameterExpression param = Expression.Parameter(typeof(T), "doc");
                Expression<Func<T, string>> accessor = Expression.Lambda<Func<T, string>>(
                    Expression.PropertyOrField(param, key),
                    param);
                return accessor.Compile();
            }
        }
        #endregion Get Key Field

        #region Notifications
        /// <summary>
        /// Raise the <see cref="ActionAddedAsync"/> event.
        /// </summary>
        /// <param name="action">The action being added.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task that will not complete until every handler does.
        /// </returns>
        internal async Task RaiseActionAddedAsync(
            IndexDocumentsAction<T> action,
            CancellationToken cancellationToken)
        {
            try
            {
                await ActionAddedAsync
                    .RaiseAsync(action, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch
            {
                // TODO: #16706 - Log any exceptions raised from async events
                // we can't let bubble out because they'd tear down the process
            }
        }

        /// <summary>
        /// Raise the <see cref="ActionSentAsync"/> event.
        /// </summary>
        /// <param name="action">The action being added.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task that will not complete until every handler does.
        /// </returns>
        internal async Task RaiseActionSentAsync(
            IndexDocumentsAction<T> action,
            CancellationToken cancellationToken)
        {
            try
            {
                await ActionSentAsync
                    .RaiseAsync(action, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch
            {
                // TODO: #16706 - Log any exceptions raised from async events
                // we can't let bubble out because they'd tear down the process
            }
        }

        /// <summary>
        /// Raise the <see cref="ActionCompletedAsync"/> event.
        /// </summary>
        /// <param name="action">The action being added.</param>
        /// <param name="result">The result of indexing.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task that will not complete until every handler does.
        /// </returns>
        internal async Task RaiseActionCompletedAsync(
            IndexDocumentsAction<T> action,
            IndexingResult result,
            CancellationToken cancellationToken)
        {
            try
            {
                await ActionCompletedAsync
                    .RaiseAsync(action, result, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch
            {
                // TODO: #16706 - Log any exceptions raised from async events
                // we can't let bubble out because they'd tear down the process
            }
        }

        /// <summary>
        /// Raise the <see cref="ActionFailedAsync"/> event.
        /// </summary>
        /// <param name="action">The action being added.</param>
        /// <param name="result">The result of indexing.</param>
        /// <param name="exception">An exception that was thrown.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>
        /// A task that will not complete until every handler does.
        /// </returns>
        internal async Task RaiseActionFailedAsync(
            IndexDocumentsAction<T> action,
            IndexingResult result,
            Exception exception,
            CancellationToken cancellationToken)
        {
            try
            {
                await ActionFailedAsync
                    .RaiseAsync(action, result, exception, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch
            {
                // TODO: #16706 - Log any exceptions raised from async events
                // we can't let bubble out because they'd tear down the process
            }
        }
        #endregion

        #region Index Documents
        /// <summary>
        /// Send documents to the publisher.  All the public APIs run through
        /// this method.
        /// </summary>
        /// <param name="batch">The batch to send.</param>
        /// <param name="async">Whether to run sync or async.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A Task that will complete after the batch is added.
        /// </returns>
        private async Task AddIndexingActionsInternal(
            IndexDocumentsBatch<T> batch,
            bool async,
            CancellationToken cancellationToken)
        {
            EnsureNotDisposed();
            if (batch?.Actions != null)
            {
                await EnsureKeyFieldAccessorAsync(async, cancellationToken).ConfigureAwait(false);
                await _publisher.AddDocumentsAsync(
                    batch.Actions,
                    async,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Adds a batch of upload, merge, and/or delete actions to eventually
        /// send to the search index.
        /// </summary>
        /// <param name="batch">The batch of document index actions.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        public virtual void IndexDocuments(
            IndexDocumentsBatch<T> batch,
            CancellationToken cancellationToken = default) =>
            AddIndexingActionsInternal(batch, async: false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Adds a batch of upload, merge, and/or delete actions to eventually
        /// send to the search index.
        /// </summary>
        /// <param name="batch">The batch of document index actions.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A task that completes when the indexing actions have been added but
        /// not yet sent.
        /// </returns>
        public virtual async Task IndexDocumentsAsync(
            IndexDocumentsBatch<T> batch,
            CancellationToken cancellationToken = default) =>
            await AddIndexingActionsInternal(batch, async: true, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Adds a batch of upload actions to eventually send to the search
        /// index.
        /// </summary>
        /// <param name="documents">The documents to upload.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        public virtual void UploadDocuments(
            IEnumerable<T> documents,
            CancellationToken cancellationToken = default) =>
            IndexDocuments(
                IndexDocumentsBatch.Upload<T>(documents),
                cancellationToken);

        /// <summary>
        /// Adds a batch of upload actions to eventually send to the search
        /// index.
        /// </summary>
        /// <param name="documents">The documents to upload.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A task that completes when the indexing actions have been added but
        /// not yet sent.
        /// </returns>
        public virtual async Task UploadDocumentsAsync(
            IEnumerable<T> documents,
            CancellationToken cancellationToken = default) =>
            await IndexDocumentsAsync(
                IndexDocumentsBatch.Upload<T>(documents),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Adds a batch of merge actions to eventually send to the search
        /// index.
        /// </summary>
        /// <param name="documents">The documents to merge.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        public virtual void MergeDocuments(
            IEnumerable<T> documents,
            CancellationToken cancellationToken = default) =>
            IndexDocuments(
                IndexDocumentsBatch.Merge<T>(documents),
                cancellationToken);

        /// <summary>
        /// Adds a batch of merge actions to eventually send to the search
        /// index.
        /// </summary>
        /// <param name="documents">The documents to merge.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>.
        /// <returns>
        /// A task that completes when the indexing actions have been added but
        /// not yet sent.
        /// </returns>
        public virtual async Task MergeDocumentsAsync(
            IEnumerable<T> documents,
            CancellationToken cancellationToken = default) =>
            await IndexDocumentsAsync(
                IndexDocumentsBatch.Merge<T>(documents),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Adds a batch of merge or upload actions to eventually send to the
        /// search index.
        /// </summary>
        /// <param name="documents">The documents to merge or upload.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        public virtual void MergeOrUploadDocuments(
            IEnumerable<T> documents,
            CancellationToken cancellationToken = default) =>
            IndexDocuments(
                IndexDocumentsBatch.MergeOrUpload<T>(documents),
                cancellationToken);

        /// <summary>
        /// Adds a batch of merge or upload actions to eventually send to the
        /// search index.
        /// </summary>
        /// <param name="documents">The documents to merge or upload.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A task that completes when the indexing actions have been added but
        /// not yet sent.
        /// </returns>
        public virtual async Task MergeOrUploadDocumentsAsync(
            IEnumerable<T> documents,
            CancellationToken cancellationToken = default) =>
            await IndexDocumentsAsync(
                IndexDocumentsBatch.MergeOrUpload<T>(documents),
                cancellationToken)
                .ConfigureAwait(false);

        /// <summary>
        /// Adds a batch of delete actions to eventually send to the search
        /// index.
        /// </summary>
        /// <param name="documents">The documents to delete.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        public virtual void DeleteDocuments(
            IEnumerable<T> documents,
            CancellationToken cancellationToken = default) =>
            IndexDocuments(
                IndexDocumentsBatch.Delete<T>(documents),
                cancellationToken);

        /// <summary>
        /// Adds a batch of delete actions to eventually send to the search
        /// index.
        /// </summary>
        /// <param name="documents">The documents to delete.</param>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A task that completes when the indexing actions have been added but
        /// not yet sent.
        /// </returns>
        public virtual async Task DeleteDocumentsAsync(
            IEnumerable<T> documents,
            CancellationToken cancellationToken = default) =>
            await IndexDocumentsAsync(
                IndexDocumentsBatch.Delete<T>(documents),
                cancellationToken)
                .ConfigureAwait(false);
        #endregion Index Documents

        #region Flush
        /// <summary>
        /// Flush any pending indexing actions.  This will wait until
        /// everything has been sent before returning.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        public void Flush(CancellationToken cancellationToken = default) =>
            _publisher.FlushAsync(async: false, cancellationToken).EnsureCompleted();

        /// <summary>
        /// Flush any pending indexing actions.  This will wait until
        /// everything has been sent before returning.
        /// </summary>
        /// <param name="cancellationToken">
        /// Optional <see cref="CancellationToken"/> to propagate notifications
        /// that the operation should be canceled.
        /// </param>
        /// <returns>A Task that will complete after flushing.</returns>
        public async Task FlushAsync(CancellationToken cancellationToken = default) =>
            await _publisher.FlushAsync(async: true, cancellationToken).ConfigureAwait(false);
        #endregion Flush
    }
}
