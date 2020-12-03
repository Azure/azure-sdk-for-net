// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using SharedTaskExtensions = Azure.Core.Pipeline.TaskExtensions;

namespace Azure.Search.Documents.Batching
{
    /// <summary>
    /// Implement a Producer/Consumer pattern where we (potentially) have
    /// multiple document producers and a single consumer that submits those
    /// events to a service.  This class is mostly focused on synchronizing
    /// behavior between document producers and relies on abstract methods to
    /// implement service specific semantics.
    /// </summary>
    /// <typeparam name="T">The type of document being published.</typeparam>
    internal abstract partial class Publisher<T> : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// Flag indicating whether the publisher has been disposed.
        /// </summary>
        private volatile int _disposed;

        /// <summary>
        /// Channel used to communicate between the sender and publisher.
        /// </summary>
        private Channel<Message> _channel = Channel.CreateUnbounded<Message>(
            new UnboundedChannelOptions { SingleReader = true });

        /// <summary>
        /// "Blocking" semaphore used to wait for flushing to complete.
        /// </summary>
        private TaskCompletionSource<object> _flushCompletionSource =
            new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);

        /// <summary>
        /// Task that's acting as our channel's event loop to read publishing
        /// actions.
        /// </summary>
        private Task _readerLoop;

        /// <summary>
        /// A timer that we can use to automatically flush after a period of
        /// inactivity.
        /// </summary>
        private Timer _timer;

        /// <summary>
        /// Gets a value indicating whether the timer is currently paused (i.e.
        /// has an infinite dueTime).
        /// </summary>
        private bool _timerPaused;

        /// <summary>
        /// Queue of pending actions.
        /// </summary>
        private Queue<PublisherAction<T>> _pending = new Queue<PublisherAction<T>>();

        /// <summary>
        /// Queue of actions that need to be retried.
        /// </summary>
        private Queue<PublisherAction<T>> _retry = new Queue<PublisherAction<T>>();

        /// <summary>
        /// Manual retry policy to add exponential back-off after throttled
        /// requests.
        /// </summary>
        private ManualRetryDelay _manualRetries;

        /// <summary>
        /// Gets the number of indexing actions currently awaiting submission.
        /// </summary>
        public int IndexingActionsCount
        {
            get => _pending.Count + _retry.Count;
        }

        /// <summary>
        /// Gets a value indicating whether the publisher should automatically
        /// flush any indexing actions that have been added.  This will happen
        /// when the batch is full or when the <see cref="AutoFlushInterval"/>
        /// has elapsed.
        /// </summary>
        public bool AutoFlush { get; }

        /// <summary>
        /// Gets an optional amount of time to wait before automatically
        /// flushing any remaining indexing actions.
        /// </summary>
        public TimeSpan? AutoFlushInterval { get; }

        /// <summary>
        /// Gets a <see cref="CancellationToken"/> to use when publishing.
        /// </summary>
        protected CancellationToken PublisherCancellationToken { get; }

        /// <summary>
        /// Gets a value indicating the number of actions to group into a batch
        /// when tuning the behavior of the publisher.
        /// </summary>
        protected int BatchActionCount { get; }  // TODO: Not automatically tuning yet

        /// <summary>
        /// Gets a value indicating the number of bytes to use when tuning the
        /// behavior of the publisher.
        /// </summary>
        protected int BatchPayloadSize { get; }  // TODO: Not used yet

        /// <summary>
        /// Gets the number of times to retry a failed document.
        /// </summary>
        protected int MaxRetries { get; }

        /// <summary>
        /// Creates a new Publisher which immediately starts listening to
        /// process requests.
        /// </summary>
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
        public Publisher(
            bool autoFlush,
            TimeSpan? autoFlushInterval,
            int? batchActionSize,
            int? batchPayloadSize,
            int maxRetries,
            TimeSpan retryDelay,
            TimeSpan maxRetryDelay,
            CancellationToken publisherCancellationToken)
        {
            AutoFlush = autoFlush;
            AutoFlushInterval = autoFlushInterval <= TimeSpan.Zero ? null : autoFlushInterval;
            PublisherCancellationToken = publisherCancellationToken;
            BatchActionCount = batchActionSize ?? SearchIndexingBufferedSenderOptions<T>.DefaultInitialBatchActionCount;
            BatchPayloadSize = batchPayloadSize ?? SearchIndexingBufferedSenderOptions<T>.DefaultBatchPayloadSize;
            MaxRetries = maxRetries;

            // Setup manual retries
            _manualRetries = new ManualRetryDelay { Delay = retryDelay, MaxDelay = maxRetryDelay };

            // Start the message loop
            _readerLoop = Task.Run(ProcessMessagesAsync, publisherCancellationToken);
        }

        #region Message Producers - only called externally and do not touch state
        /// <summary>
        /// Add documents to be published.  This should only be called outside
        /// of the Publisher itself.
        /// </summary>
        /// <param name="documents">The documents to publish.</param>
        /// <param name="async">Whether to run sync or async.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Task for adding the documents.</returns>
        public async Task AddDocumentsAsync(IEnumerable<T> documents, bool async, CancellationToken cancellationToken = default)
        {
            EnsureNotDisposed();
            await _channel.Writer.WriteInternal(
                Message.Publish(documents),
                async,
                cancellationToken)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Flush any pending documents.  This should only be called outside of
        /// the Publisher itself.
        /// </summary>
        /// <param name="async">Whether to run sync or async.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Task for adding the documents.</returns>
        public async Task FlushAsync(bool async, CancellationToken cancellationToken = default)
        {
            EnsureNotDisposed();
            await FlushInternal(async, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Flush any pending documents.  This will not check for disposal.
        /// </summary>
        /// <param name="async">Whether to run sync or async.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Task for adding the documents.</returns>
        private async Task FlushInternal(bool async, CancellationToken cancellationToken = default)
        {
            // Get an awaitable that will let us wait until flushing has been
            // completed
            SharedTaskExtensions.WithCancellationTaskAwaitable<object> flushCompletion =
                _flushCompletionSource.Task.AwaitWithCancellation(cancellationToken);

            // Send a message to flush
            await _channel.Writer.WriteInternal(
                Message.Flush(),
                async,
                cancellationToken)
                .ConfigureAwait(false);

            // Wait for the flushing to complete
            if (async)
            {
                // AwaitWithCancellation calls ConfigureAwait(false) already
                await flushCompletion;
            }
            else
            {
                #pragma warning disable AZC0102 // Do not use GetAwaiter().GetResult().
                flushCompletion.GetAwaiter().GetResult();
                #pragma warning restore AZC0102 // Do not use GetAwaiter().GetResult().
            }
        }
        #endregion

        #region Message Consumer
        /// <summary>
        /// Listen for and process messages.
        /// </summary>
        /// <returns>
        /// A Task that will run for the lifetime of the publisher.
        /// </returns>
        private async Task ProcessMessagesAsync()
        {
            CancellationToken cancellationToken = PublisherCancellationToken;
            while (await _channel.Reader.WaitToReadAsync(cancellationToken).ConfigureAwait(false))
            {
                Message message = await _channel.Reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                switch (message.Operation)
                {
                    case MessageOperation.Publish:
                        await OnDocumentsAddedAsync(message.Documents, cancellationToken).ConfigureAwait(false);
                        break;
                    case MessageOperation.Flush:
                        await OnFlushedAsync(cancellationToken).ConfigureAwait(false);
                        break;
                    default:
                        throw new InvalidOperationException($"Unexpected value {message.Operation} of type {nameof(MessageOperation)}.");
                }
            }
            StopTimer();
        }

        /// <summary>
        /// Get a key used to identify a given document.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <returns>A key for that document.</returns>
        protected abstract string GetDocumentKey(T document);

        /// <summary>
        /// Process any documents that have been added for publishing.
        /// </summary>
        /// <param name="documents">The documents to publish.</param>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Task for processing the added documents.</returns>
        protected virtual async Task OnDocumentsAddedAsync(IEnumerable<T> documents, CancellationToken cancellationToken)
        {
            // Add all of the documents to our queue
            Debug.Assert(documents != null);
            foreach (T document in documents)
            {
                PublisherAction<T> action = new PublisherAction<T>(document, GetDocumentKey(document));
                _pending.Enqueue(action);
            }

            // Automatically trigger a submission if enabled
            if (AutoFlush)
            {
                // Determine whether or not we crossed the threshold and we need
                // to automatically submit the next batch.
                if (HasBatch())
                {
                    await PublishAsync(flush: false, cancellationToken).ConfigureAwait(false);
                }

                // Try starting a timer to flush whatever's ready when it fires
                if (IndexingActionsCount > 0)
                {
                    StartTimer();
                }
            }
        }

        /// <summary>
        /// Process any requests to flush.  After submitting, this will unblock
        /// anyone waiting behind the Flush barrier.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Task for flushing.</returns>
        protected virtual async Task OnFlushedAsync(CancellationToken cancellationToken)
        {
            await PublishAsync(flush: true, cancellationToken).ConfigureAwait(false);

            // Wake up anyone who was blocked on a flush finishing
            TaskCompletionSource<object> previous = _flushCompletionSource;
            _flushCompletionSource = new TaskCompletionSource<object>(TaskCreationOptions.RunContinuationsAsynchronously);
            previous.SetResult(null);
        }
        #endregion Message Consumer

        #region Dispose
        /// <summary>
        /// Clean up any resources.
        /// </summary>
        async ValueTask IAsyncDisposable.DisposeAsync() =>
            await DisposeAsync(async: true).ConfigureAwait(false);

        /// <summary>
        /// Clean up any resources.
        /// </summary>
        void IDisposable.Dispose() =>
            DisposeAsync(async: false).EnsureCompleted();

        /// <summary>
        /// Dispose the sender and flush any remaining indexing actions that
        /// haven't been sent yet.  This will block until everything's been
        /// sent.
        /// </summary>
        /// <param name="async">Whether to call this sync or async.</param>
        /// <returns>A Task that will wait until we're disposed.</returns>
        public async Task DisposeAsync(bool async)
        {
            if (Interlocked.CompareExchange(ref _disposed, 1, 0) == 0)
            {
                await FlushInternal(async, PublisherCancellationToken).ConfigureAwait(false);
                _timer?.Dispose();
                _channel?.Writer.TryComplete();
                if (async)
                {
                    await _readerLoop.ConfigureAwait(false);
                }
                else
                {
                    #pragma warning disable AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                    _readerLoop.EnsureCompleted();
                    #pragma warning restore AZC0104 // Use EnsureCompleted() directly on asynchronous method return value.
                }
                _flushCompletionSource.SetCanceled();
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

        #region Publishing
        /// <summary>
        /// Check if we have a full batch ready to send.
        /// </summary>
        /// <param name="flush">Whether we're flushing.</param>
        /// <returns>If we have a full batch ready to send.</returns>
        private bool HasBatch(bool flush = false) =>
            IndexingActionsCount > (flush ? 0 : BatchActionCount);

        /// <summary>
        /// Publish as many batches are ready.
        /// </summary>
        /// <param name="flush">Whether we're flushing.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>A task that represents the operation.</returns>
        private async Task PublishAsync(bool flush, CancellationToken cancellationToken)
        {
            // There's no need to let the timer keep running since we're
            // already submitting
            StopTimer();

            do
            {
                List<PublisherAction<T>> batch = new List<PublisherAction<T>>(
                    capacity: Math.Min(BatchActionCount, IndexingActionsCount));

                // Prefer pulling from the _retry queue first
                if (!FillBatchFromQueue(batch, _retry))
                {
                    FillBatchFromQueue(batch, _pending);
                }

                // Submit the batch
                await SubmitBatchAsync(
                    batch,
                    cancellationToken)
                    .ConfigureAwait(false);

            // Keep going if we have more full batches ready to submit
            } while (HasBatch(flush));

            // Fill as much of the batch as possible from the given queue.
            // Returns whether the batch is now full.
            bool FillBatchFromQueue(List<PublisherAction<T>> batch, Queue< PublisherAction<T>> queue)
            {
                // TODO: Consider tracking the keys in the batch and requiring
                // them to be unique to avoid error alignment problems

                while (queue.Count > 0)
                {
                    if (batch.Count < BatchActionCount)
                    {
                        batch.Add(queue.Dequeue());
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Send indexing actions to be processed by the service.
        /// </summary>
        /// <param name="batch">The batch of actions to submit.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>Whether the submission was throttled.</returns>
        protected async Task SubmitBatchAsync(IList<PublisherAction<T>> batch, CancellationToken cancellationToken)
        {
            // If Submit is called before our last retry delay elapsed, we'll
            // wait before sending the next request
            await _manualRetries.WaitIfNeededAsync(cancellationToken).ConfigureAwait(false);

            // Send the request
            bool throttled = await OnSubmitBatchAsync(batch, cancellationToken).ConfigureAwait(false);

            // Update whether or not the request was throttled to update our
            // retry delay
            _manualRetries.Update(throttled);
        }

        /// <summary>
        /// Send indexing actions to be processed by the service.
        /// </summary>
        /// <param name="batch">The batch of actions to submit.</param>
        /// <param name="cancellationToken">A cancellation token.</param>
        /// <returns>Whether the submission was throttled.</returns>
        protected abstract Task<bool> OnSubmitBatchAsync(IList<PublisherAction<T>> batch, CancellationToken cancellationToken);

        /// <summary>
        /// Enqueue an action to be retried.
        /// </summary>
        /// <param name="action">The action to be retried.</param>
        /// <param name="skipIncrement">
        /// Whether we should skip incrementing the retry attempts because the
        /// failure wasn't related to the action.
        /// </param>
        /// <returns>
        /// A value indicating whether the action is retriable.
        /// </returns>
        protected bool EnqueueRetry(
            PublisherAction<T> action,
            bool skipIncrement = false)
        {
            bool retriable = skipIncrement || action.RetryAttempts++ < MaxRetries;
            if (retriable)
            {
                _retry.Enqueue(action);
            }
            return retriable;
        }
        #endregion Publishing

        #region Timer
        /// <summary>
        /// Start the timer if it's not already running.
        /// </summary>
        private void StartTimer()
        {
            if (AutoFlush && AutoFlushInterval != null)
            {
                int intervalInMs = (int)AutoFlushInterval.Value.TotalMilliseconds;
                if (_timer == null)
                {
                    _timer = new Timer(
                        OnTimerElapsed,
                        state: null,
                        dueTime: intervalInMs,
                        period: Timeout.Infinite);
                    _timerPaused = false;
                }
                else if (_timerPaused)
                {
                    _timer.Change(
                        dueTime: intervalInMs,
                        period: Timeout.Infinite);
                    _timerPaused = false;
                }
            }
        }

        /// <summary>
        /// Stop the timer.
        /// </summary>
        private void StopTimer()
        {
            if (_timer != null && !_timerPaused)
            {
                _timer.Change(
                    dueTime: Timeout.Infinite,
                    period: Timeout.Infinite);
                _timerPaused = true;
            }
        }

        /// <summary>
        /// Trigger a flush when the timer elapses.
        /// </summary>
        /// <param name="timerState"></param>
        private void OnTimerElapsed(object timerState)
        {
            try
            {
                _channel.Writer.WriteInternal(
                    Message.Flush(),
                    async: false)
                    .EnsureCompleted();
            }
            catch
            {
                // We'd rather not have the timer flush than tear down the
                // process because of an unhandled exception
            }
        }
        #endregion Timer
    }
}
