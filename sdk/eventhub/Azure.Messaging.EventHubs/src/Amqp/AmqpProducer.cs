// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Diagnostics;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.EventHubs.Amqp
{
    /// <summary>
    ///   A transport producer abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="EventHubProducerClient" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.EventHubs.Core.TransportProducer" />
    ///
    internal class AmqpProducer : TransportProducer
    {
        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _closed;

        /// <summary>The count of send operations performed by this instance; this is used to tag deliveries for the AMQP link.</summary>
        private int _deliveryCount;

        /// <summary>
        ///   Indicates whether or not this producer has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the producer is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public override bool IsClosed => _closed;

        /// <summary>
        ///   The name of the Event Hub to which the producer is bound.
        /// </summary>
        ///
        private string EventHubName { get; }

        /// <summary>
        ///   The identifier of the Event Hub partition that this producer is bound to, if any.  If bound, events will
        ///   be published only to this partition.
        /// </summary>
        ///
        /// <value>The partition to which the producer is bound; if unbound, <c>null</c>.</value>
        ///
        private string PartitionId { get; }

        /// <summary>
        ///   The flags specifying the set of special transport features that this producer has opted-into.
        /// </summary>
        ///
        private TransportProducerFeatures ActiveFeatures { get; }

        /// <summary>
        ///   The set of options currently active for the partition associated with this producer.
        /// </summary>
        ///
        /// <remarks>
        ///   These options are managed by the producer and will be mutated as part of state
        ///   updates.
        /// </remarks>
        ///
        private PartitionPublishingOptions ActiveOptions { get; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private EventHubsRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The converter to use for translating between AMQP messages and client library
        ///   types.
        /// </summary>
        ///
        private AmqpMessageConverter MessageConverter { get; }

        /// <summary>
        ///   The AMQP connection scope responsible for managing transport constructs for this instance.
        /// </summary>
        ///
        private AmqpConnectionScope ConnectionScope { get; }

        /// <summary>
        ///   The AMQP link intended for use with publishing operations.
        /// </summary>
        ///
        private FaultTolerantAmqpObject<SendingAmqpLink> SendLink { get; }

        /// <summary>
        ///   The maximum size of an AMQP message allowed by the associated
        ///   producer link.
        /// </summary>
        ///
        /// <value>The maximum message size, in bytes.</value>
        ///
        private long? MaximumMessageSize { get; set; }

        /// <summary>
        ///   The set of partition publishing properties active for this producer at the time it was initialized.
        /// </summary>
        ///
        /// <remarks>
        ///   It is important to note that these properties are a snapshot of the service state at the time when the
        ///   producer was initialized; they do not necessarily represent the current state of the service.
        /// </remarks>
        ///
        private PartitionPublishingProperties InitializedPartitionProperties { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpProducer"/> class.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub to which events will be published.</param>
        /// <param name="partitionId">The identifier of the Event Hub partition to which it is bound; if unbound, <c>null</c>.</param>
        /// <param name="connectionScope">The AMQP connection context for operations.</param>
        /// <param name="messageConverter">The converter to use for translating between AMQP messages and client types.</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
        /// <param name="requestedFeatures">The flags specifying the set of special transport features that should be opted-into.</param>
        /// <param name="partitionOptions">The set of options, if any, that should be considered when initializing the producer.</param>
        ///
        /// <remarks>
        ///   As an internal type, this class performs only basic sanity checks against its arguments.  It
        ///   is assumed that callers are trusted and have performed deep validation.
        ///
        ///   Any parameters passed are assumed to be owned by this instance and safe to mutate or dispose;
        ///   creation of clones or otherwise protecting the parameters is assumed to be the purview of the
        ///   caller.
        /// </remarks>
        ///
        public AmqpProducer(string eventHubName,
                            string partitionId,
                            AmqpConnectionScope connectionScope,
                            AmqpMessageConverter messageConverter,
                            EventHubsRetryPolicy retryPolicy,
                            TransportProducerFeatures requestedFeatures = TransportProducerFeatures.None,
                            PartitionPublishingOptions partitionOptions = null)
        {
            Argument.AssertNotNullOrEmpty(eventHubName, nameof(eventHubName));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(messageConverter, nameof(messageConverter));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            EventHubName = eventHubName;
            PartitionId = partitionId;
            RetryPolicy = retryPolicy;
            ConnectionScope = connectionScope;
            MessageConverter = messageConverter;
            ActiveFeatures = requestedFeatures;
            ActiveOptions = partitionOptions?.Clone() ?? new PartitionPublishingOptions();

            SendLink = new FaultTolerantAmqpObject<SendingAmqpLink>(
                timeout => CreateLinkAndEnsureProducerStateAsync(partitionId, ActiveOptions, timeout, CancellationToken.None),
                link =>
                {
                    link.Session?.SafeClose();
                    link.SafeClose();
                });
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="events">The set of event data to send.</param>
        /// <param name="sendOptions">The set of options to consider when sending this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override async Task SendAsync(IEnumerable<EventData> events,
                                             SendEventOptions sendOptions,
                                             CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(events, nameof(events));
            Argument.AssertNotClosed(_closed, nameof(AmqpProducer));

            AmqpMessage messageFactory() => MessageConverter.CreateBatchFromEvents(events, sendOptions?.PartitionKey);
            await SendAsync(messageFactory, sendOptions?.PartitionKey, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Sends a set of events to the associated Event Hub using a batched approach.
        /// </summary>
        ///
        /// <param name="eventBatch">The event batch to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <remarks>
        ///   The caller is assumed to retain ownership of the <paramref name="eventBatch" /> and
        ///   is responsible for managing its lifespan, including disposal.
        /// </remarks>
        ///
        public override async Task SendAsync(EventDataBatch eventBatch,
                                             CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(eventBatch, nameof(eventBatch));
            Argument.AssertNotClosed(_closed, nameof(AmqpProducer));

            // Make a defensive copy of the messages in the batch.

            AmqpMessage messageFactory() => MessageConverter.CreateBatchFromEvents(eventBatch.AsEnumerable<EventData>(), eventBatch.SendOptions?.PartitionKey);
            await SendAsync(messageFactory, eventBatch.SendOptions?.PartitionKey, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Creates a size-constraint batch to which <see cref="EventData" /> may be added using a try-based pattern.  If an event would
        ///   exceed the maximum allowable size of the batch, the batch will not allow adding the event and signal that scenario using its
        ///   return value.
        ///
        ///   Because events that would violate the size constraint cannot be added, publishing a batch will not trigger an exception when
        ///   attempting to send the events to the Event Hubs service.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider when creating this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="EventDataBatch" /> with the requested <paramref name="options"/>.</returns>
        ///
        public override async ValueTask<TransportEventBatch> CreateBatchAsync(CreateBatchOptions options,
                                                                              CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(options, nameof(options));
            Argument.AssertNotClosed(_closed, nameof(AmqpProducer));

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            // Ensure that maximum message size has been determined; this depends on the underlying
            // AMQP link, so if not set, requesting the link will ensure that it is populated.

            if (!MaximumMessageSize.HasValue)
            {
                var failedAttemptCount = 0;
                var tryTimeout = RetryPolicy.CalculateTryTimeout(0);

                while ((!cancellationToken.IsCancellationRequested) && (!_closed))
                {
                    try
                    {
                        await SendLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, tryTimeout)).ConfigureAwait(false);
                        break;
                    }
                    catch (Exception ex)
                    {
                        ++failedAttemptCount;

                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, bubble the exception.

                        var activeEx = ex.TranslateServiceException(EventHubName);
                        var retryDelay = RetryPolicy.CalculateRetryDelay(activeEx, failedAttemptCount);

                        if ((retryDelay.HasValue) && (!ConnectionScope.IsDisposed) && (!cancellationToken.IsCancellationRequested))
                        {
                            await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);
                            tryTimeout = RetryPolicy.CalculateTryTimeout(failedAttemptCount);
                        }
                        else if (ex is AmqpException)
                        {
                            ExceptionDispatchInfo.Capture(activeEx).Throw();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            }

            // Ensure that there was a maximum size populated; if none was provided,
            // default to the maximum size allowed by the link.

            options.MaximumSizeInBytes ??= MaximumMessageSize;
            Argument.AssertInRange(options.MaximumSizeInBytes.Value, EventHubProducerClient.MinimumBatchSizeLimit, MaximumMessageSize.Value, nameof(options.MaximumSizeInBytes));

            return new AmqpEventBatch(MessageConverter, options, ActiveFeatures);
        }

        /// <summary>
        ///   Reads the set of partition publishing properties active for this producer at the time it was initialized.
        /// </summary>
        ///
        /// <param name="cancellationToken">The cancellation token to consider when creating the link.</param>
        ///
        /// <returns>The set of <see cref="PartitionPublishingProperties" /> observed when the producer was initialized.</returns>
        ///
        /// <remarks>
        ///   It is important to note that these properties are a snapshot of the service state at the time when the
        ///   producer was initialized; they do not necessarily represent the current state of the service.
        /// </remarks>
        ///
        public override async ValueTask<PartitionPublishingProperties> ReadInitializationPublishingPropertiesAsync(CancellationToken cancellationToken)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpProducer));

            // If the properties were already initialized, use them.

            if (InitializedPartitionProperties != null)
            {
                return InitializedPartitionProperties;
            }

            // Initialize the properties by forcing the link to be opened.

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            var failedAttemptCount = 0;
            var tryTimeout = RetryPolicy.CalculateTryTimeout(0);

            while ((!cancellationToken.IsCancellationRequested) && (!_closed))
            {
                try
                {
                    await SendLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, tryTimeout)).ConfigureAwait(false);
                    break;
                }
                catch (Exception ex)
                {
                    ++failedAttemptCount;

                    // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                    // Otherwise, bubble the exception.

                    var activeEx = ex.TranslateServiceException(EventHubName);
                    var retryDelay = RetryPolicy.CalculateRetryDelay(activeEx, failedAttemptCount);

                    if ((retryDelay.HasValue) && (!ConnectionScope.IsDisposed) && (!cancellationToken.IsCancellationRequested))
                    {
                        await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);
                        tryTimeout = RetryPolicy.CalculateTryTimeout(failedAttemptCount);
                    }
                    else if (ex is AmqpException)
                    {
                        ExceptionDispatchInfo.Capture(activeEx).Throw();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            return InitializedPartitionProperties;
        }

        /// <summary>
        ///   Closes the connection to the transport producer instance.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override async Task CloseAsync(CancellationToken cancellationToken)
        {
            if (_closed)
            {
                return;
            }

            _closed = true;

            var clientId = GetHashCode().ToString(CultureInfo.InvariantCulture);
            var clientType = GetType().Name;

            try
            {
                EventHubsEventSource.Log.ClientCloseStart(clientType, EventHubName, clientId);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (SendLink?.TryGetOpenedObject(out var _) == true)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await SendLink.CloseAsync().ConfigureAwait(false);
                }

                SendLink?.Dispose();
            }
            catch (Exception ex)
            {
                _closed = false;
                EventHubsEventSource.Log.ClientCloseError(clientType, EventHubName, clientId, ex.Message);

                throw;
            }
            finally
            {
                EventHubsEventSource.Log.ClientCloseComplete(clientType, EventHubName, clientId);
            }
        }

        /// <summary>
        ///   Sends an AMQP message that contains a batch of events to the associated Event Hub. If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="messageFactory">A factory which can be used to produce an AMQP message containing the batch of events to be sent.</param>
        /// <param name="partitionKey">The hashing key to use for influencing the partition to which events should be routed.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        protected virtual async Task SendAsync(Func<AmqpMessage> messageFactory,
                                               string partitionKey,
                                               CancellationToken cancellationToken)
        {
            var failedAttemptCount = 0;
            var logPartition = PartitionId ?? partitionKey;
            var operationId = Guid.NewGuid().ToString("D", CultureInfo.InvariantCulture);
            var stopWatch = ValueStopwatch.StartNew();

            TimeSpan? retryDelay;
            SendingAmqpLink link;

            try
            {
                var tryTimeout = RetryPolicy.CalculateTryTimeout(0);

                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        using AmqpMessage batchMessage = messageFactory();

                        // Creation of the link happens without explicit knowledge of the cancellation token
                        // used for this operation; validate the token state before attempting link creation and
                        // again after the operation completes to provide best efforts in respecting it.

                        EventHubsEventSource.Log.EventPublishStart(EventHubName, logPartition, operationId);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        link = await SendLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, tryTimeout)).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        // Validate that the batch of messages is not too large to send.  This is done after the link is created to ensure
                        // that the maximum message size is known, as it is dictated by the service using the link.

                        if (batchMessage.SerializedMessageSize > MaximumMessageSize)
                        {
                            throw new EventHubsException(EventHubName, string.Format(CultureInfo.CurrentCulture, Resources.MessageSizeExceeded, operationId, batchMessage.SerializedMessageSize, MaximumMessageSize), EventHubsException.FailureReason.MessageSizeExceeded);
                        }

                        // Attempt to send the message batch.

                        var deliveryTag = new ArraySegment<byte>(BitConverter.GetBytes(Interlocked.Increment(ref _deliveryCount)));
                        var outcome = await link.SendMessageAsync(batchMessage, deliveryTag, AmqpConstants.NullBinary, tryTimeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);

                        if (outcome.DescriptorCode != Accepted.Code)
                        {
                            throw AmqpError.CreateExceptionForError((outcome as Rejected)?.Error, EventHubName);
                        }

                        // The send operation should be considered successful; return to
                        // exit the retry loop.

                        return;
                    }
                    catch (Exception ex)
                    {
                        Exception activeEx = ex.TranslateServiceException(EventHubName);

                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, bubble the exception.

                        ++failedAttemptCount;
                        retryDelay = RetryPolicy.CalculateRetryDelay(activeEx, failedAttemptCount);

                        if ((retryDelay.HasValue) && (!ConnectionScope.IsDisposed) && (!cancellationToken.IsCancellationRequested))
                        {
                            EventHubsEventSource.Log.EventPublishError(EventHubName, logPartition, operationId, activeEx.Message);
                            await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);

                            tryTimeout = RetryPolicy.CalculateTryTimeout(failedAttemptCount);
                            stopWatch = ValueStopwatch.StartNew();
                        }
                        else if (ex is AmqpException)
                        {
                            ExceptionDispatchInfo.Capture(activeEx).Throw();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                // If no value has been returned nor exception thrown by this point,
                // then cancellation has been requested.

                throw new TaskCanceledException();
            }
            catch (TaskCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                EventHubsEventSource.Log.EventPublishError(EventHubName, logPartition, operationId, ex.Message);
                throw;
            }
            finally
            {
                EventHubsEventSource.Log.EventPublishComplete(EventHubName, logPartition, operationId, failedAttemptCount);
            }
        }

        /// <summary>
        ///   Creates the AMQP link to be used for producer-related operations and ensures
        ///   that the corresponding state for the producer has been updated based on the link
        ///   configuration.
        /// </summary>
        ///
        /// <param name="partitionId">The identifier of the Event Hub partition to which it is bound; if unbound, <c>null</c>.</param>
        /// <param name="partitionOptions">The set of options, if any, that should be considered when initializing the producer.</param>
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="cancellationToken">The cancellation token to consider when creating the link.</param>
        ///
        /// <returns>The AMQP link to use for producer-related operations.</returns>
        ///
        /// <remarks>
        ///   This method will modify class-level state, setting those attributes that depend on the AMQP
        ///   link configuration.  There exists a benign race condition in doing so, as there may be multiple
        ///   concurrent callers.  In this case, the attributes may be set multiple times but the resulting
        ///   value will be the same.
        /// </remarks>
        ///
        protected virtual async Task<SendingAmqpLink> CreateLinkAndEnsureProducerStateAsync(string partitionId,
                                                                                            PartitionPublishingOptions partitionOptions,
                                                                                            TimeSpan timeout,
                                                                                            CancellationToken cancellationToken)
        {
            var link = default(SendingAmqpLink);

            try
            {
                link = await ConnectionScope.OpenProducerLinkAsync(partitionId, ActiveFeatures, partitionOptions, timeout, cancellationToken).ConfigureAwait(false);

                if (!MaximumMessageSize.HasValue)
                {
                    // This delay is necessary to prevent the link from causing issues for subsequent
                    // operations after creating a batch.  Without it, operations using the link consistently
                    // timeout.  The length of the delay does not appear significant, just the act of introducing
                    // an asynchronous delay.
                    //
                    // For consistency the value used by the legacy Event Hubs client has been brought forward and
                    // used here.

                    await Task.Delay(15, cancellationToken).ConfigureAwait(false);
                    MaximumMessageSize = (long)link.Settings.MaxMessageSize;
                }

                if (InitializedPartitionProperties == null)
                {
                    var producerGroup = link.ExtractSettingPropertyValueOrDefault(AmqpProperty.ProducerGroupId, default(long?));
                    var ownerLevel = link.ExtractSettingPropertyValueOrDefault(AmqpProperty.ProducerOwnerLevel, default(short?));
                    var sequence = link.ExtractSettingPropertyValueOrDefault(AmqpProperty.ProducerSequenceNumber, default(int?));

                    // Once the properties are initialized, clear the starting sequence number to ensure that the current
                    // sequence tracked by the service is used should the link need to be recreated; this avoids the need for
                    // the transport producer to have awareness of the sequence numbers of events being sent.

                    InitializedPartitionProperties = new PartitionPublishingProperties(false, producerGroup, ownerLevel, sequence);
                    partitionOptions.StartingSequenceNumber = null;
                }
            }
            catch (Exception ex)
            {
               ExceptionDispatchInfo.Capture(ex.TranslateConnectionCloseDuringLinkCreationException(EventHubName)).Throw();
            }

            return link;
        }

        /// <summary>
        ///   Uses the minimum value of the two specified <see cref="TimeSpan" /> instances.
        /// </summary>
        ///
        /// <param name="firstOption">The first option to consider.</param>
        /// <param name="secondOption">The second option to consider.</param>
        ///
        /// <returns>The smaller of the two specified intervals.</returns>
        ///
        private static TimeSpan UseMinimum(TimeSpan firstOption,
                                           TimeSpan secondOption) => (firstOption < secondOption) ? firstOption : secondOption;
    }
}
