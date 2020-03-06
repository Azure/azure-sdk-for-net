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
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    ///   A transport producer abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="ServiceBusSender" /> make use of an instance
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
        private readonly string _entityName;

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private readonly ServiceBusRetryPolicy _retryPolicy;

        /// <summary>
        ///   The AMQP connection scope responsible for managing transport constructs for this instance.
        /// </summary>
        ///
        private readonly AmqpConnectionScope _connectionScope;

        private readonly FaultTolerantAmqpObject<SendingAmqpLink> _sendLink;

        private readonly FaultTolerantAmqpObject<RequestResponseAmqpLink> _managementLink;

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

            _entityName = entityName;
            _retryPolicy = retryPolicy;
            _connectionScope = connectionScope;

            _sendLink = new FaultTolerantAmqpObject<SendingAmqpLink>(
                timeout => CreateLinkAndEnsureSenderStateAsync(timeout, CancellationToken.None),
                link =>
                {
                    link.Session?.SafeClose();
                    link.SafeClose();
                });

            _managementLink = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(
                timeout => _connectionScope.OpenManagementLinkAsync(
                    _entityName,
                    timeout,
                    CancellationToken.None),
                link =>
                {
                    link.Session?.SafeClose();
                    link.SafeClose();
                });
        }

        /// <summary>
        ///   Creates a size-constraint batch to which <see cref="ServiceBusMessage" /> may be added using a try-based pattern.  If a message would
        ///   exceed the maximum allowable size of the batch, the batch will not allow adding the message and signal that scenario using its
        ///   return value.
        ///
        ///   Because messages that would violate the size constraint cannot be added, publishing a batch will not trigger an exception when
        ///   attempting to send the message to the Queue/Topic.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider when creating this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="ServiceBusMessageBatch" /> with the requested <paramref name="options"/>.</returns>
        ///
        public override async ValueTask<TransportMessageBatch> CreateBatchAsync(
            CreateBatchOptions options,
            CancellationToken cancellationToken)
        {
            TransportMessageBatch messageBatch = null;
            Task createBatchTask = _retryPolicy.RunOperation(async (timeout) =>
            {
                messageBatch = await CreateBatchInternalAsync(
                    options,
                    timeout).ConfigureAwait(false);
            },
            _entityName,
            _connectionScope,
            cancellationToken);
            await createBatchTask.ConfigureAwait(false);
            return messageBatch;
        }

        internal async ValueTask<TransportMessageBatch> CreateBatchInternalAsync(
            CreateBatchOptions options,
            TimeSpan timeout)
        {
            Argument.AssertNotNull(options, nameof(options));

            // Ensure that maximum message size has been determined; this depends on the underlying
            // AMQP link, so if not set, requesting the link will ensure that it is populated.

            if (!MaximumMessageSize.HasValue)
            {
                await _sendLink.GetOrCreateAsync(timeout).ConfigureAwait(false);
            }

            // Ensure that there was a maximum size populated; if none was provided,
            // default to the maximum size allowed by the link.

            options.MaximumSizeInBytes ??= MaximumMessageSize;

            Argument.AssertInRange(options.MaximumSizeInBytes.Value, ServiceBusSender.MinimumBatchSizeLimit, MaximumMessageSize.Value, nameof(options.MaximumSizeInBytes));
            return new AmqpMessageBatch(options);
        }

        /// <summary>
        ///   Sends a set of messages to the associated Queue/Topic using a batched approach.
        /// </summary>
        ///
        /// <param name="messageBatch">The set of messages to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public override async Task SendBatchAsync(
            ServiceBusMessageBatch messageBatch,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(messageBatch, nameof(messageBatch));
            Argument.AssertNotClosed(_closed, nameof(AmqpSender));

            await _retryPolicy.RunOperation(async (timeout) =>
             await SendBatchInternalAsync(
                    messageBatch,
                    timeout,
                    cancellationToken).ConfigureAwait(false),
            _entityName,
            _connectionScope,
            cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///    Sends a set of messages to the associated Queue/Topic using a batched approach.
        /// </summary>
        ///
        /// <param name="messageBatch"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        internal virtual async Task SendBatchInternalAsync(
            ServiceBusMessageBatch messageBatch,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            var stopWatch = Stopwatch.StartNew();

            AmqpMessage messageFactory() => AmqpMessageConverter.BatchSBMessagesAsAmqpMessage(messageBatch.AsEnumerable<ServiceBusMessage>());

            using (AmqpMessage batchMessage = messageFactory())
            {
                //ServiceBusEventSource.Log.SendStart(Entityname, messageHash);

                string messageHash = batchMessage.GetHashCode().ToString();

                SendingAmqpLink link = await _sendLink.GetOrCreateAsync(UseMinimum(_connectionScope.SessionTimeout, timeout)).ConfigureAwait(false);

                // Validate that the message is not too large to send.  This is done after the link is created to ensure
                // that the maximum message size is known, as it is dictated by the service using the link.

                if (batchMessage.SerializedMessageSize > MaximumMessageSize)
                {
                    throw new ServiceBusException(string.Format(Resources1.MessageSizeExceeded, messageHash, batchMessage.SerializedMessageSize, MaximumMessageSize, _entityName), ServiceBusException.FailureReason.MessageSizeExceeded);
                }

                // Attempt to send the message batch.

                var deliveryTag = new ArraySegment<byte>(BitConverter.GetBytes(Interlocked.Increment(ref _deliveryCount)));
                var outcome = await link.SendMessageAsync(batchMessage, deliveryTag, AmqpConstants.NullBinary, timeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (outcome.DescriptorCode != Accepted.Code)
                {
                    throw AmqpError.CreateExceptionForError((outcome as Rejected)?.Error, _entityName);
                }

                //ServiceBusEventSource.Log.SendStop(Entityname, messageHash);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                stopWatch.Stop();
            }
        }

        /// <summary>
        ///   Sends a message to the associated Service Bus entity.
        /// </summary>
        ///
        /// <param name="message">A message to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        public override async Task SendAsync(
            ServiceBusMessage message,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(message, nameof(message));
            Argument.AssertNotClosed(_closed, nameof(AmqpSender));

            await _retryPolicy.RunOperation(async (timeout) =>
             await SendInternalAsync(
                    message,
                    timeout,
                    cancellationToken).ConfigureAwait(false),
            _entityName,
            _connectionScope,
            cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Sends a message to the associated Service Bus entity.
        /// </summary>
        ///
        /// <param name="message"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        internal virtual async Task SendInternalAsync(
            ServiceBusMessage message,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            var stopWatch = Stopwatch.StartNew();
            using (AmqpMessage amqpMessage = AmqpMessageConverter.SBMessageToAmqpMessage(message))
            {
                //ServiceBusEventSource.Log.SendStart(Entityname, messageHash);

                string messageHash = amqpMessage.GetHashCode().ToString();

                SendingAmqpLink link = await _sendLink.GetOrCreateAsync(UseMinimum(_connectionScope.SessionTimeout, timeout)).ConfigureAwait(false);

                // Validate that the message is not too large to send.  This is done after the link is created to ensure
                // that the maximum message size is known, as it is dictated by the service using the link.

                if (amqpMessage.SerializedMessageSize > MaximumMessageSize)
                {
                    throw new ServiceBusException(string.Format(Resources1.MessageSizeExceeded, messageHash, amqpMessage.SerializedMessageSize, MaximumMessageSize), ServiceBusException.FailureReason.MessageSizeExceeded, _entityName);
                }

                // Attempt to send the message batch.

                var deliveryTag = new ArraySegment<byte>(BitConverter.GetBytes(Interlocked.Increment(ref _deliveryCount)));
                var outcome = await link.SendMessageAsync(amqpMessage, deliveryTag, AmqpConstants.NullBinary, timeout.CalculateRemaining(stopWatch.Elapsed)).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (outcome.DescriptorCode != Accepted.Code)
                {
                    throw AmqpError.CreateExceptionForError((outcome as Rejected)?.Error, _entityName);
                }

                //ServiceBusEventSource.Log.SendStop(Entityname, messageHash);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                stopWatch.Stop();
            }
        }

        /// <summary>
        ///   Closes the connection to the transport sender instance.
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
                ServiceBusEventSource.Log.ClientCloseStart(clientType, _entityName, clientId);
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (_sendLink?.TryGetOpenedObject(out var _) == true)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await _sendLink.CloseAsync().ConfigureAwait(false);
                }

                _sendLink?.Dispose();
            }
            catch (Exception ex)
            {
                _closed = false;
                ServiceBusEventSource.Log.ClientCloseError(clientType, _entityName, clientId, ex.Message);

                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientCloseComplete(clientType, _entityName, clientId);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<long> ScheduleMessageAsync(
            ServiceBusMessage message,
            CancellationToken cancellationToken = default)
        {
            long sequenceNumber = 0;
            Task scheduleTask = _retryPolicy.RunOperation(async (timeout) =>
            {
                sequenceNumber = await ScheduleMessageInternalAsync(
                    message,
                    timeout,
                    cancellationToken).ConfigureAwait(false);
            },
            _entityName,
            _connectionScope,
            cancellationToken);
            await scheduleTask.ConfigureAwait(false);
            return sequenceNumber;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task<long> ScheduleMessageInternalAsync(
            ServiceBusMessage message,
            TimeSpan timeout,
            CancellationToken cancellationToken = default)
        {
            var stopWatch = Stopwatch.StartNew();

            using (AmqpMessage amqpMessage = AmqpMessageConverter.SBMessageToAmqpMessage(message))
            {

                var request = AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.ScheduleMessageOperation,
                        timeout,
                        null);

                if (_sendLink.TryGetOpenedObject(out SendingAmqpLink sendLink))
                {
                    request.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = sendLink.Name;
                }

                ArraySegment<byte>[] payload = amqpMessage.GetPayload();
                var buffer = new BufferListStream(payload);
                ArraySegment<byte> value = buffer.ReadBytes((int)buffer.Length);

                var entry = new AmqpMap();
                {
                    entry[ManagementConstants.Properties.Message] = value;
                    entry[ManagementConstants.Properties.MessageId] = message.MessageId;

                    if (!string.IsNullOrWhiteSpace(message.SessionId))
                    {
                        entry[ManagementConstants.Properties.SessionId] = message.SessionId;
                    }

                    if (!string.IsNullOrWhiteSpace(message.PartitionKey))
                    {
                        entry[ManagementConstants.Properties.PartitionKey] = message.PartitionKey;
                    }

                    if (!string.IsNullOrWhiteSpace(message.ViaPartitionKey))
                    {
                        entry[ManagementConstants.Properties.ViaPartitionKey] = message.ViaPartitionKey;
                    }
                }

                request.Map[ManagementConstants.Properties.Messages] = new List<AmqpMap> { entry };

                RequestResponseAmqpLink mgmtLink = await _managementLink.GetOrCreateAsync(
                    UseMinimum(_connectionScope.SessionTimeout,
                    timeout.CalculateRemaining(stopWatch.Elapsed)))
                    .ConfigureAwait(false);

                using AmqpMessage response = await mgmtLink.RequestAsync(
                    request.AmqpMessage,
                    timeout.CalculateRemaining(stopWatch.Elapsed))
                    .ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                stopWatch.Stop();

                AmqpResponseMessage amqpResponseMessage = AmqpResponseMessage.CreateResponse(response);

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    var sequenceNumbers = amqpResponseMessage.GetValue<long[]>(ManagementConstants.Properties.SequenceNumbers);
                    if (sequenceNumbers == null || sequenceNumbers.Length < 1)
                    {
                        throw new ServiceBusException(true, "Could not schedule message successfully.");
                    }

                    return sequenceNumbers[0];

                }
                else
                {
                    throw new Exception();
                    //throw response.ToMessagingContractException();
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sequenceNumber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task CancelScheduledMessageAsync(
            long sequenceNumber,
            CancellationToken cancellationToken = default)
        {
            Task cancelMessageTask = _retryPolicy.RunOperation(async (timeout) =>
            {
                await CancelScheduledMessageInternalAsync(
                    sequenceNumber,
                    timeout,
                    cancellationToken).ConfigureAwait(false);
            },
            _entityName,
            _connectionScope,
            cancellationToken);
            await cancelMessageTask.ConfigureAwait(false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sequenceNumber"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task CancelScheduledMessageInternalAsync(
            long sequenceNumber,
            TimeSpan timeout,
            CancellationToken cancellationToken = default)
        {
            var stopWatch = Stopwatch.StartNew();

            var request = AmqpRequestMessage.CreateRequest(
                ManagementConstants.Operations.CancelScheduledMessageOperation,
                timeout,
                null);

            if (_sendLink.TryGetOpenedObject(out SendingAmqpLink sendLink))
            {
                request.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = sendLink.Name;
            }

            request.Map[ManagementConstants.Properties.SequenceNumbers] = new[] { sequenceNumber };

            RequestResponseAmqpLink mgmtLink = await _managementLink.GetOrCreateAsync(
                    UseMinimum(_connectionScope.SessionTimeout,
                    timeout.CalculateRemaining(stopWatch.Elapsed)))
                    .ConfigureAwait(false);

            using AmqpMessage response = await mgmtLink.RequestAsync(
                request.AmqpMessage,
                timeout.CalculateRemaining(stopWatch.Elapsed))
                .ConfigureAwait(false);

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            stopWatch.Stop();
            AmqpResponseMessage amqpResponseMessage = AmqpResponseMessage.CreateResponse(response);


            if (amqpResponseMessage.StatusCode != AmqpResponseStatusCode.OK)
            {
                throw new Exception();
                //throw response.ToMessagingContractException();
            }
            return;
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
        protected virtual async Task<SendingAmqpLink> CreateLinkAndEnsureSenderStateAsync(
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            SendingAmqpLink link = await _connectionScope.OpenSenderLinkAsync(
                _entityName,
                timeout,
                cancellationToken).ConfigureAwait(false);

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
