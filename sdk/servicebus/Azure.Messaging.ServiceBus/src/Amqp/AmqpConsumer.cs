// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Receiver;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    ///   A transport client abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="ServiceBusReceiverClient" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.ServiceBus.Core.TransportConsumer" />
    ///
    internal class AmqpConsumer : TransportConsumer
    {
        /// <summary>The default prefetch count to use for the consumer.</summary>
        private const uint DefaultPrefetchCount = 0;

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private bool _closed = false;

        /// <summary>
        ///   Indicates whether or not this consumer has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the consumer is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public override bool IsClosed => _closed;

        /// <summary>
        ///   The name of the Service Bus entity to which the client is bound.
        /// </summary>
        ///
        private string EntityName { get; }

        /// <summary>
        ///   The identifier of the Service Bus entity partition that this consumer is associated with.  Events will be read
        ///   only from this partition.
        /// </summary>
        ///
        private string PartitionId { get; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private ServiceBusRetryPolicy RetryPolicy { get; }

        ///// <summary>
        /////   The converter to use for translating between AMQP messages and client library
        /////   types.
        ///// </summary>
        //private AmqpMessageConverter MessageConverter { get; }

        ///// <summary>
        /////   The AMQP connection scope responsible for managing transport constructs for this instance.
        ///// </summary>
        /////
        //internal AmqpConnectionScope ConnectionScope { get; }

        ///// <summary>
        /////   The AMQP link intended for use with receiving operations.
        ///// </summary>
        /////
        //internal FaultTolerantAmqpObject<ReceivingAmqpLink> ReceiveLink { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpConsumer"/> class.
        /// </summary>
        ///
        /// <param name="entityName">The name of the Service Bus entity from which events will be consumed.</param>
        /// <param name="prefetchCount">Controls the number of events received and queued locally without regard to whether an operation was requested.  If <c>null</c> a default will be used.</param>
        /// <param name="ownerLevel">The relative priority to associate with the link; for a non-exclusive link, this value should be <c>null</c>.</param>
        /// <param name="connectionScope">The AMQP connection context for operations .</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
        /// <param name="sessionId"></param>
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
        public AmqpConsumer(
            string entityName,
            long? ownerLevel,
            uint? prefetchCount,
            AmqpConnectionScope connectionScope,
            ServiceBusRetryPolicy retryPolicy,
            string sessionId)
        {
            Argument.AssertNotNullOrEmpty(entityName, nameof(entityName));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));
            EntityName = entityName;
            ConnectionScope = connectionScope;
            RetryPolicy = retryPolicy;

            ReceiveLink = new FaultTolerantAmqpObject<ReceivingAmqpLink>(
                timeout =>
                    ConnectionScope.OpenConsumerLinkAsync(
                        //consumerGroup,
                        //partitionId,
                        timeout,
                        prefetchCount ?? DefaultPrefetchCount,
                        ownerLevel,
                        sessionId,
                        CancellationToken.None),
                link =>
                {
                    CloseLink(link);
                });
        }

        private void CloseLink(ReceivingAmqpLink link)
        {
            link.Session?.SafeClose();
            link.SafeClose();
        }

        /// <summary>
        ///   Receives a batch of <see cref="ServiceBusMessage" /> from the Service Bus entity partition.
        /// </summary>
        ///
        /// <param name="maximumMessageCount">The maximum number of messages to receive in this batch.</param>
        /// <param name="maximumWaitTime">The maximum amount of time to wait to build up the requested message count for the batch; if not specified, the per-try timeout specified by the retry policy will be used.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>The batch of <see cref="ServiceBusMessage" /> from the Service Bus entity partition this consumer is associated with.  If no events are present, an empty enumerable is returned.</returns>
        ///
        public override async Task<IEnumerable<ServiceBusMessage>> ReceiveAsync(
            int maximumMessageCount,
            TimeSpan? maximumWaitTime,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotClosed(_closed, nameof(AmqpConsumer));
            Argument.AssertAtLeast(maximumMessageCount, 1, nameof(maximumMessageCount));

            var receivedMessageCount = 0;
            var failedAttemptCount = 0;
            var tryTimeout = RetryPolicy.CalculateTryTimeout(0);
            var waitTime = (maximumWaitTime ?? tryTimeout);
            var link = default(ReceivingAmqpLink);
            var retryDelay = default(TimeSpan?);
            var amqpMessages = default(IEnumerable<AmqpMessage>);
            var receivedMessages = default(List<ServiceBusMessage>);

            var stopWatch = Stopwatch.StartNew();

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        ServiceBusEventSource.Log.MessageReceiveStart(EntityName);

                        link = await ReceiveLink.GetOrCreateAsync(UseMinimum(ConnectionScope.SessionTimeout, tryTimeout)).ConfigureAwait(false);
                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        var messagesReceived = await Task.Factory.FromAsync
                        (
                            (callback, state) => link.BeginReceiveRemoteMessages(maximumMessageCount, TimeSpan.FromMilliseconds(20),  waitTime, callback, state),
                            (asyncResult) => link.EndReceiveMessages(asyncResult, out amqpMessages),
                            TaskCreationOptions.RunContinuationsAsynchronously
                        ).ConfigureAwait(false);

                        cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                        // If event messages were received, then package them for consumption and
                        // return them.

                        if ((messagesReceived) && (amqpMessages != null))
                        {
                            receivedMessages ??= new List<ServiceBusMessage>();

                            foreach (AmqpMessage message in amqpMessages)
                            {
                                //link.DisposeDelivery(message, true, AmqpConstants.AcceptedOutcome);
                                receivedMessages.Add(AmqpMessageConverter.AmqpMessageToSBMessage(message));
                                message.Dispose();
                            }

                            receivedMessageCount = receivedMessages.Count;
                            return receivedMessages;
                        }

                        // No events were available.

                        return Enumerable.Empty<ServiceBusMessage>();
                    }
                    catch (ServiceBusException ex) when (ex.Reason == ServiceBusException.FailureReason.ServiceTimeout)
                    {
                        // Because the timeout specified with the request is intended to be the maximum
                        // amount of time to wait for events, a timeout isn't considered an error condition,
                        // rather a sign that no events were available in the requested period.

                        return Enumerable.Empty<ServiceBusMessage>();
                    }
                    catch (Exception ex)
                    {
                        Exception activeEx = ex.TranslateServiceException(EntityName);

                        // Determine if there should be a retry for the next attempt; if so enforce the delay but do not quit the loop.
                        // Otherwise, bubble the exception.

                        ++failedAttemptCount;
                        retryDelay = RetryPolicy.CalculateRetryDelay(activeEx, failedAttemptCount);

                        if ((retryDelay.HasValue) && (!ConnectionScope.IsDisposed) && (!cancellationToken.IsCancellationRequested))
                        {
                            ServiceBusEventSource.Log.MessageReceiveError(EntityName, activeEx.Message);
                            await Task.Delay(UseMinimum(retryDelay.Value, waitTime.CalculateRemaining(stopWatch.Elapsed)), cancellationToken).ConfigureAwait(false);

                            tryTimeout = RetryPolicy.CalculateTryTimeout(failedAttemptCount);
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
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.MessageReceiveError(EntityName, ex.Message);
                throw;
            }
            finally
            {
                stopWatch.Stop();
                ServiceBusEventSource.Log.MessageReceiveComplete(EntityName, receivedMessageCount);
            }
        }

        /// <summary>
        ///   Closes the connection to the transport consumer instance.
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

                if (ReceiveLink?.TryGetOpenedObject(out var _) == true)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await ReceiveLink.CloseAsync().ConfigureAwait(false);
                }

                ReceiveLink?.Dispose();
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
        ///   Uses the minimum value of the two specified <see cref="TimeSpan" /> instances.
        /// </summary>
        ///
        /// <param name="firstOption">The first option to consider.</param>
        /// <param name="secondOption">The second option to consider.</param>
        ///
        /// <returns>The smaller of the two specified intervals.</returns>
        ///
        private static TimeSpan UseMinimum(
            TimeSpan firstOption,
            TimeSpan secondOption) =>
            (firstOption < secondOption) ? firstOption : secondOption;
    }
}
