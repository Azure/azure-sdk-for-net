// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents.Batching
{
    /// <summary>
    /// The SearchIndexingPublisher is responsible for submitting documents to
    /// the service for indexing.
    /// </summary>
    /// <typeparam name="T">
    /// The .NET type that maps to the index schema.  Instances of this
    /// type can be retrieved as documents from the index. You can use
    /// <see cref="SearchDocument"/> for dynamic documents.
    /// </typeparam>
    internal class SearchIndexingPublisher<T> : Publisher<IndexDocumentsAction<T>>
    {
        /// <summary>
        /// The sender, which we mostly use for raising events.
        /// </summary>
        private SearchIndexingBufferedSender<T> _sender;

        /// <summary>
        /// Creates a new SearchIndexingPublisher which immediately starts
        /// listening to process requests.
        /// </summary>
        /// <param name="sender">The sender that produces actions.</param>
        /// <param name="autoFlush">
        /// A value indicating whether the publisher should automatically flush.
        /// </param>
        /// <param name="autoFlushInterval">
        /// An optional amount of time to wait before automatically flushing.
        /// </param>
        /// <param name="batchActionSize">
        /// The number of actions to group into a batch.
        /// </param>
        /// <param name="batchPayloadSize">
        /// The number of bytes to use when tuning the behavior of the
        /// publisher.
        /// </param>
        /// <param name="maxRetries">
        /// The number of times to retry a failed document.
        /// </param>
        /// <param name="retryDelay">
        /// The initial retry delay on which to base calculations for a
        /// backoff-based approach.
        /// </param>
        /// <param name="maxRetryDelay">
        /// The maximum permissible delay between retry attempts.
        /// </param>
        /// <param name="publisherCancellationToken">
        /// A <see cref="CancellationToken"/> to use when publishing.
        /// </param>
        public SearchIndexingPublisher(
            SearchIndexingBufferedSender<T> sender,
            bool autoFlush,
            TimeSpan? autoFlushInterval,
            int? batchActionSize,
            int? batchPayloadSize,
            int maxRetries,
            TimeSpan retryDelay,
            TimeSpan maxRetryDelay,
            CancellationToken publisherCancellationToken)
            : base(
                autoFlush,
                autoFlushInterval,
                batchActionSize,
                batchPayloadSize,
                maxRetries,
                retryDelay,
                maxRetryDelay,
                publisherCancellationToken)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get a key used to identify a given document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>A key for that document.</returns>
        protected override string GetDocumentKey(IndexDocumentsAction<T> document) =>
            _sender.KeyFieldAccessor(document.Document);

        /// <summary>
        /// Process any documents that have been added for publishing.
        /// </summary>
        /// <param name="documents">The documents to publish.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Task for processing the added documents.</returns>
        protected override async Task OnDocumentsAddedAsync(IEnumerable<IndexDocumentsAction<T>> documents, CancellationToken cancellationToken)
        {
            // Raise notifications
            foreach (IndexDocumentsAction<T> document in documents)
            {
                await _sender.RaiseActionAddedAsync(document, cancellationToken).ConfigureAwait(false);
            }

            // Add all of the documents and possibly auto flush
            await base.OnDocumentsAddedAsync(documents, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Send indexing actions to be processed by the service.
        /// </summary>
        /// <param name="batch">The batch of actions to submit.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>Whether the submission was throttled.</returns>
        protected override async Task<bool> OnSubmitBatchAsync(IList<PublisherAction<IndexDocumentsAction<T>>> batch, CancellationToken cancellationToken)
        {
            // Bail early if someone sent an empty batch
            if (batch.Count == 0) { return false; }

            // Notify the action is being sent
            foreach (PublisherAction<IndexDocumentsAction<T>> action in batch)
            {
                await _sender.RaiseActionSentAsync(action.Document, cancellationToken).ConfigureAwait(false);
            }

            // Send the request to the service
            Response<IndexDocumentsResult> response = null;
            try
            {
                response = await _sender.SearchClient.IndexDocumentsAsync(
                    IndexDocumentsBatch.Create(batch.Select(a => a.Document).ToArray()),
                    cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
            }
            // Handle batch level failures
            catch (RequestFailedException ex) when (ex.Status == 413) // Payload Too Large
            {
                // Split the batch and try with smaller payloads
                int half = (int)Math.Floor((double)batch.Count / 2.0);
                var smaller = new List<PublisherAction<IndexDocumentsAction<T>>>(batch.Take(half));
                foreach (PublisherAction<IndexDocumentsAction<T>> action in batch.Skip(half))
                {
                    // Add the second half to the retry queue without
                    // counting this as a retry attempt
                    _ = EnqueueRetry(action, skipIncrement: true);
                }

                // Try resubmitting with just the smaller half
                await SubmitBatchAsync(smaller, cancellationToken).ConfigureAwait(false);
                return false;
            }
            catch (Exception ex)
            {
                // Retry the whole batch using the same exception for everything
                foreach (PublisherAction<IndexDocumentsAction<T>> action in batch)
                {
                    await EnqueueOrFailRetryAsync(action, null, ex, cancellationToken).ConfigureAwait(false);
                }

                // Search currently uses 503s for throttling
                return (ex is RequestFailedException failure && failure.Status ==  503);
            }

            // Handle individual responses which might be success or failure
            bool throttled = false;
            foreach ((PublisherAction<IndexDocumentsAction<T>> action, IndexingResult result) in
                AssociateResults(batch, response.Value.Results))
            {
                // Search currently uses 503s for throttling
                throttled |= (result.Status == 503);

                Debug.Assert(action.Key == result.Key);
                if (result.Succeeded)
                {
                    await _sender.RaiseActionCompletedAsync(
                        action.Document,
                        result,
                        cancellationToken)
                        .ConfigureAwait(false);
                }
                else if (IsRetriable(result.Status))
                {
                    await EnqueueOrFailRetryAsync(
                        action,
                        result,
                        exception: null,
                        cancellationToken)
                        .ConfigureAwait(false);
                }
                else
                {
                    await _sender.RaiseActionFailedAsync(
                        action.Document,
                        result,
                        exception: null,
                        cancellationToken)
                        .ConfigureAwait(false);
                }
            }
            return throttled;
        }

        /// <summary>
        /// Attempt to add an item to the retry queue or raise a failure
        /// notification if it's been retried too many times.
        /// </summary>
        /// <param name="action">The action to retry.</param>
        /// <param name="result">Result of executing the action.</param>
        /// <param name="exception">An exception raised by the action.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>Task.</returns>
        private async Task EnqueueOrFailRetryAsync(
            PublisherAction<IndexDocumentsAction<T>> action,
            IndexingResult result,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (!EnqueueRetry(action))
            {
                await _sender.RaiseActionFailedAsync(
                    action.Document,
                    result,
                    exception,
                    cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Associate the results of a submission with the pending actions.
        /// </summary>
        /// <param name="actions">The batch of actions.</param>
        /// <param name="results">The results.</param>
        /// <returns>Actions paired with their result.</returns>
        private static IEnumerable<(PublisherAction<IndexDocumentsAction<T>>, IndexingResult)> AssociateResults(
            IList<PublisherAction<IndexDocumentsAction<T>>> actions,
            IReadOnlyList<IndexingResult> results)
        {
            // In the worst case scenario with multiple actions on the
            // same key, we'll treat the results as ordered.  We'll do a stable
            // sort on both collections and then pair them up.
            return actions.OrderBy(a => a.Key)
                .Zip(results.OrderBy(r => r.Key), (a, r) => (a, r));
        }

        /// <summary>
        /// Check if a status code for an individual failure is retriable.
        /// </summary>
        /// <param name="status">The status code.</param>
        /// <returns>Whether we should retry.</returns>
        private static bool IsRetriable(int status) =>
            status == 422 ||
            status == 409 ||
            status == 503;
    }
}
