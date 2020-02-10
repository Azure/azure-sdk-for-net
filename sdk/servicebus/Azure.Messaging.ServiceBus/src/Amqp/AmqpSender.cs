// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Sender;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    ///   A transport producer abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="ServiceBusSenderClient" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.ServiceBus.Core.TransportSender" />
    ///
    internal class AmqpSender : TransportSender
    {
        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private bool _closed = false;

        /// <summary>The count of send operations performed by this instance; this is used to tag deliveries for the AMQP link.</summary>
        private int _deliveryCount = 0;

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
        ///   The name of the Service Bus entity to which the producer is bound.
        /// </summary>
        ///
        private string EntityName { get; }


        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private ServiceBusRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The AMQP connection scope responsible for managing transport constructs for this instance.
        /// </summary>
        ///
        private AmqpConnectionScope ConnectionScope { get; }

        /// <summary>
        ///   The maximum size of an AMQP message allowed by the associated
        ///   producer link.
        /// </summary>
        ///
        /// <value>The maximum message size, in bytes.</value>
        ///
        private long? MaximumMessageSize { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpSender"/> class.
        /// </summary>
        ///
        /// <param name="entityName">The name of the entity to which messages will be sent.</param>
        /// <param name="connectionScope">The AMQP connection context for operations.</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
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
        public AmqpSender(
            string entityName,
            AmqpConnectionScope connectionScope,
            ServiceBusRetryPolicy retryPolicy)
        {
            Argument.AssertNotNullOrEmpty(entityName, nameof(entityName));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            EntityName = entityName;
            RetryPolicy = retryPolicy;
            ConnectionScope = connectionScope;

            SendLink = new FaultTolerantAmqpObject<SendingAmqpLink>(
                timeout => CreateLinkAndEnsureProducerStateAsync(timeout, CancellationToken.None),
                link =>
                {
                    link.Session?.SafeClose();
                    link.SafeClose();
                });
        }

        /// <summary>
        ///   Sends a set of events to the associated Service Bus entity using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="messages">The set of event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override async Task SendAsync(IEnumerable<ServiceBusMessage> messages,
                                             CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(messages, nameof(messages));
            Argument.AssertNotClosed(_closed, nameof(AmqpSender));

            AmqpMessage messageFactory() => AmqpMessageConverter.BatchSBMessagesAsAmqpMessage(messages);
            await SendAsync(messageFactory, cancellationToken).ConfigureAwait(false);
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

            var clientId = GetHashCode().ToString();
            var clientType = GetType();

            try
            {
                ServiceBusEventSource.Log.ClientCloseStart(clientType, EntityName, clientId);
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
                ServiceBusEventSource.Log.ClientCloseError(clientType, EntityName, clientId, ex.Message);

                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientCloseComplete(clientType, EntityName, clientId);
            }
        }

        /// <summary>
        ///   Sends an AMQP message that contains a batch of events to the associated Service Bus entity. If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="messageFactory">A factory which can be used to produce an AMQP message containing the batch of events to be sent.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        protected virtual async Task SendAsync(Func<AmqpMessage> messageFactory,
                                               CancellationToken cancellationToken)
        {
            var failedAttemptCount = 0;
            var stopWatch = Stopwatch.StartNew();

            SendingAmqpLink link;

            try
            {
                var tryTimeout = RetryPolicy.CalculateTryTimeout(0);
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        using AmqpMessage batchMessage = messageFactory();
                        string messageHash = batchMessage.GetHashCode().ToString();

                        //ServiceBusEventSource.Log.EventPublishStart(EventHubName, logPartition, messageHash);

                        link = await SendLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, tryTimeout)).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        // Validate that the batch of messages is not too large to send.  This is done after the link is created to ensure
                        // that the maximum message size is known, as it is dictated by the service using the link.

                        if (batchMessage.SerializedMessageSize > MaximumMessageSize)
                        {
                            throw new ServiceBusException(EntityName, string.Format(Resources1.MessageSizeExceeded, messageHash, batchMessage.SerializedMessageSize, MaximumMessageSize), ServiceBusException.FailureReason.MessageSizeExceeded);
                        }

                        // Attempt to send the message batch.

                        var deliveryTag = new ArraySegment<byte>(BitConverter.GetBytes(Interlocked.Increment(ref _deliveryCount)));
                        var outcome = await link.SendMessageAsync(batchMessage, deliveryTag, AmqpConstants.NullBinary, tryTimeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        if (outcome.DescriptorCode != Accepted.Code)
                        {
                            throw AmqpError.CreateExceptionForError((outcome as Rejected)?.Error, EntityName);
                        }

                        // The send operation should be considered successful; return to
                        // exit the retry loop.

                        return;
                    }
                    catch (Exception ex)
                    {
                        Exception activeEx = ex.TranslateServiceException(EntityName);

                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, bubble the exception.

                        ++failedAttemptCount;
                        TimeSpan? retryDelay = RetryPolicy.CalculateRetryDelay(activeEx, failedAttemptCount);

                        if (retryDelay.HasValue && !ConnectionScope.IsDisposed && !cancellationToken.IsCancellationRequested)
                        {
                            //ServiceBusEventSource.Log.EventPublishError(EventHubName, messageHash, activeEx.Message);
                            await Task.Delay(retryDelay.Value, cancellationToken).ConfigureAwait(false);

                            tryTimeout = RetryPolicy.CalculateTryTimeout(failedAttemptCount);
                            stopWatch.Reset();
                        }
                        else if (ex is AmqpException)
                        {
                            throw activeEx;
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
            catch (Exception)
            {
                //ServiceBusEventSource.Log.EventPublishError(EventHubName, logPartition, messageHash, ex.Message);
                throw;
            }
            finally
            {
                stopWatch.Stop();
                //ServiceBusEventSource.Log.EventPublishComplete(EventHubName, logPartition, messageHash);
            }
        }

        /// <summary>
        ///   Creates the AMQP link to be used for producer-related operations and ensures
        ///   that the corresponding state for the producer has been updated based on the link
        ///   configuration.
        /// </summary>
        ///
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
        protected virtual async Task<SendingAmqpLink> CreateLinkAndEnsureProducerStateAsync(
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            SendingAmqpLink link = await ConnectionScope.OpenProducerLinkAsync(timeout, cancellationToken).ConfigureAwait(false);

            if (!MaximumMessageSize.HasValue)
            {
                // This delay is necessary to prevent the link from causing issues for subsequent
                // operations after creating a batch.  Without it, operations using the link consistently
                // timeout.  The length of the delay does not appear significant, just the act of introducing
                // an asynchronous delay.
                //
                // For consistency the value used by the legacy Service Bus client has been brought forward and
                // used here.

                await Task.Delay(15, cancellationToken).ConfigureAwait(false);
                MaximumMessageSize = (long)link.Settings.MaxMessageSize;
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
