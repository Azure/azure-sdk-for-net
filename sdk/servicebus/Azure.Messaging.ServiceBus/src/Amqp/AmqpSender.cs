// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Encoding;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Amqp
{
    /// <summary>
    ///   A transport sender abstraction responsible for brokering operations for AMQP-based connections.
    ///   It is intended that the public <see cref="ServiceBusSender" /> make use of an instance
    ///   via containment and delegate operations to it.
    /// </summary>
    ///
    /// <seealso cref="Azure.Messaging.ServiceBus.Core.TransportSender" />
    ///
#pragma warning disable CA1001 // Types that own disposable fields should be disposable. The AmqpSender doesn't own the connection scope.
    internal class AmqpSender : TransportSender
#pragma warning restore CA1001 // Types that own disposable fields should be disposable
    {
        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private bool _closed;

        /// <summary>The count of send operations performed by this instance; this is used to tag deliveries for the AMQP link.</summary>
        private int _deliveryCount;

        /// <summary>
        ///   Indicates whether or not this sender has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the sender is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public override bool IsClosed => _closed;

        /// <summary>
        ///   The name of the Service Bus entity to which the sender is bound.
        /// </summary>
        ///
        private readonly string _entityPath;

        /// <summary>
        /// The identifier for the sender.
        /// </summary>
        private readonly string _identifier;

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
        ///   sender link.
        /// </summary>
        ///
        /// <value>The maximum message size, in bytes.</value>
        ///
        private long? MaxMessageSize { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpSender"/> class.
        /// </summary>
        ///
        /// <param name="entityPath">The name of the entity to which messages will be sent.</param>
        /// <param name="connectionScope">The AMQP connection context for operations.</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
        /// <param name="identifier">The identifier for the sender.</param>
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
            string entityPath,
            AmqpConnectionScope connectionScope,
            ServiceBusRetryPolicy retryPolicy,
            string identifier)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            _entityPath = entityPath;
            _identifier = identifier;
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
                timeout => OpenManagementLinkAsync(timeout),
                link =>
                {
                    link.Session?.SafeClose();
                    link.SafeClose();
                });
        }

        private async Task<RequestResponseAmqpLink> OpenManagementLinkAsync(
            TimeSpan timeout)
        {
            RequestResponseAmqpLink link = await _connectionScope.OpenManagementLinkAsync(
                _entityPath,
                _identifier,
                timeout,
                CancellationToken.None).ConfigureAwait(false);
            link.Closed += OnManagementLinkClosed;
            return link;
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
        public override async ValueTask<TransportMessageBatch> CreateMessageBatchAsync(
            CreateMessageBatchOptions options,
            CancellationToken cancellationToken)
        {
            TransportMessageBatch messageBatch = null;
            Task createBatchTask = _retryPolicy.RunOperation(async (timeout) =>
            {
                messageBatch = await CreateMessageBatchInternalAsync(
                    options,
                    timeout).ConfigureAwait(false);
            },
            _connectionScope,
            cancellationToken);
            await createBatchTask.ConfigureAwait(false);
            return messageBatch;
        }

        internal async ValueTask<TransportMessageBatch> CreateMessageBatchInternalAsync(
            CreateMessageBatchOptions options,
            TimeSpan timeout)
        {
            Argument.AssertNotNull(options, nameof(options));

            // Ensure that maximum message size has been determined; this depends on the underlying
            // AMQP link, so if not set, requesting the link will ensure that it is populated.

            if (!MaxMessageSize.HasValue)
            {
                await _sendLink.GetOrCreateAsync(timeout).ConfigureAwait(false);
            }

            // Ensure that there was a maximum size populated; if none was provided,
            // default to the maximum size allowed by the link.

            options.MaxSizeInBytes ??= MaxMessageSize;

            Argument.AssertInRange(options.MaxSizeInBytes.Value, ServiceBusSender.MinimumBatchSizeLimit, MaxMessageSize.Value, nameof(options.MaxSizeInBytes));
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
            AmqpMessage messageFactory() => AmqpMessageConverter.BatchSBMessagesAsAmqpMessage(messageBatch.AsEnumerable<ServiceBusMessage>());
            await _retryPolicy.RunOperation(async (timeout) =>
                await SendBatchInternalAsync(
                    messageFactory,
                    timeout,
                    cancellationToken).ConfigureAwait(false),
            _connectionScope,
            cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///    Sends a set of messages to the associated Queue/Topic using a batched approach.
        /// </summary>
        ///
        /// <param name="messageFactory"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        internal virtual async Task SendBatchInternalAsync(
            Func<AmqpMessage> messageFactory,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            var stopWatch = ValueStopwatch.StartNew();
            var link = default(SendingAmqpLink);

            try
            {
                using (AmqpMessage batchMessage = messageFactory())
                {
                    string messageHash = batchMessage.GetHashCode().ToString(CultureInfo.InvariantCulture);

                    ArraySegment<byte> transactionId = AmqpConstants.NullBinary;
                    Transaction ambientTransaction = Transaction.Current;
                    if (ambientTransaction != null)
                    {
                        transactionId = await AmqpTransactionManager.Instance.EnlistAsync(
                            ambientTransaction,
                            _connectionScope,
                            timeout).ConfigureAwait(false);
                    }

                    link = await _sendLink.GetOrCreateAsync(UseMinimum(_connectionScope.SessionTimeout, timeout)).ConfigureAwait(false);

                    // Validate that the message is not too large to send.  This is done after the link is created to ensure
                    // that the maximum message size is known, as it is dictated by the service using the link.

                    if (batchMessage.SerializedMessageSize > MaxMessageSize)
                    {
                        throw new ServiceBusException(string.Format(CultureInfo.InvariantCulture, Resources.MessageSizeExceeded, messageHash, batchMessage.SerializedMessageSize, MaxMessageSize, _entityPath), ServiceBusFailureReason.MessageSizeExceeded);
                    }

                    // Attempt to send the message batch.

                    var deliveryTag = new ArraySegment<byte>(BitConverter.GetBytes(Interlocked.Increment(ref _deliveryCount)));
                    Outcome outcome = await link.SendMessageAsync(
                        batchMessage,
                        deliveryTag,
                    transactionId, timeout.CalculateRemaining(stopWatch.GetElapsedTime())).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                    if (outcome.DescriptorCode != Accepted.Code)
                    {
                        throw (outcome as Rejected)?.Error.ToMessagingContractException();
                    }

                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                }
            }
            catch (Exception exception)
            {
                ExceptionDispatchInfo.Capture(AmqpExceptionHelper.TranslateException(
                    exception,
                    link?.GetTrackingId(),
                    null,
                    HasLinkCommunicationError(link)))
                .Throw();

                throw; // will never be reached
            }
        }

        /// <summary>
        ///   Sends a list of messages to the associated Service Bus entity using a batched approach.
        ///   If the size of the messages exceed the maximum size of a single batch,
        ///   an exception will be triggered and the send will fail. In order to ensure that the messages
        ///   being sent will fit in a batch, use <see cref="SendBatchAsync"/> instead.
        /// </summary>
        ///
        /// <param name="messages">The list of messages to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public override async Task SendAsync(
            IReadOnlyList<ServiceBusMessage> messages,
            CancellationToken cancellationToken)
        {
            AmqpMessage messageFactory() => AmqpMessageConverter.BatchSBMessagesAsAmqpMessage(messages);
            await _retryPolicy.RunOperation(async (timeout) =>
             await SendBatchInternalAsync(
                    messageFactory,
                    timeout,
                    cancellationToken).ConfigureAwait(false),
            _connectionScope,
            cancellationToken).ConfigureAwait(false);
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

            try
            {
                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (_sendLink?.TryGetOpenedObject(out var _) == true)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await _sendLink.CloseAsync().ConfigureAwait(false);
                }

                if (_managementLink?.TryGetOpenedObject(out var _) == true)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await _managementLink.CloseAsync().ConfigureAwait(false);
                }

                _sendLink?.Dispose();
                _managementLink?.Dispose();
            }
            catch (Exception)
            {
                _closed = false;
                throw;
            }
        }

        private void OnSenderLinkClosed(object sender, EventArgs e) =>
            ServiceBusEventSource.Log.SendLinkClosed(
                _identifier,
                sender);

        private void OnManagementLinkClosed(object managementLink, EventArgs e) =>
            ServiceBusEventSource.Log.ManagementLinkClosed(
                _identifier,
                managementLink);

        /// <summary>
        ///
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<IReadOnlyList<long>> ScheduleMessagesAsync(
            IReadOnlyList<ServiceBusMessage> messages,
            CancellationToken cancellationToken = default)
        {
            long[] seqNumbers = null;
            await _retryPolicy.RunOperation(async (timeout) =>
            {
                seqNumbers = await ScheduleMessageInternalAsync(
                    messages,
                    timeout,
                    cancellationToken).ConfigureAwait(false);
            },
            _connectionScope,
            cancellationToken).ConfigureAwait(false);
            return seqNumbers ?? Array.Empty<long>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task<long[]> ScheduleMessageInternalAsync(
            IReadOnlyList<ServiceBusMessage> messages,
            TimeSpan timeout,
            CancellationToken cancellationToken = default)
        {
            var sendLink = default(SendingAmqpLink);
            try
            {
                var request = AmqpRequestMessage.CreateRequest(
                        ManagementConstants.Operations.ScheduleMessageOperation,
                        timeout,
                        null);

                if (_sendLink.TryGetOpenedObject(out sendLink))
                {
                    request.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = sendLink.Name;
                }

                List<AmqpMap> entries = new List<AmqpMap>();
                foreach (ServiceBusMessage message in messages)
                {
                    using AmqpMessage amqpMessage = AmqpMessageConverter.SBMessageToAmqpMessage(message);
                    var entry = new AmqpMap();
                    ArraySegment<byte>[] payload = amqpMessage.GetPayload();
                    var buffer = new BufferListStream(payload);
                    ArraySegment<byte> value = buffer.ReadBytes((int)buffer.Length);
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

                    if (!string.IsNullOrWhiteSpace(message.TransactionPartitionKey))
                    {
                        entry[ManagementConstants.Properties.ViaPartitionKey] = message.TransactionPartitionKey;
                    }

                    entries.Add(entry);
                }

                request.Map[ManagementConstants.Properties.Messages] = entries;

                AmqpResponseMessage amqpResponseMessage = await ManagementUtilities.ExecuteRequestResponseAsync(
                    _connectionScope,
                    _managementLink,
                    request,
                    timeout).ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (amqpResponseMessage.StatusCode == AmqpResponseStatusCode.OK)
                {
                    var sequenceNumbers = amqpResponseMessage.GetValue<long[]>(ManagementConstants.Properties.SequenceNumbers);
                    if (sequenceNumbers == null || sequenceNumbers.Length < 1)
                    {
                        throw new ServiceBusException(true, "Could not schedule message successfully.");
                    }

                    return sequenceNumbers;
                }
                else
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                ExceptionDispatchInfo.Capture(AmqpExceptionHelper.TranslateException(
                    exception,
                    sendLink?.GetTrackingId(),
                    null,
                    HasLinkCommunicationError(sendLink)))
                .Throw();

                throw; // will never be reached
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sequenceNumbers"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task CancelScheduledMessagesAsync(
            long[] sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            Task cancelMessageTask = _retryPolicy.RunOperation(async (timeout) =>
            {
                await CancelScheduledMessageInternalAsync(
                    sequenceNumbers,
                    timeout,
                    cancellationToken).ConfigureAwait(false);
            },
            _connectionScope,
            cancellationToken);
            await cancelMessageTask.ConfigureAwait(false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sequenceNumbers"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task CancelScheduledMessageInternalAsync(
            long[] sequenceNumbers,
            TimeSpan timeout,
            CancellationToken cancellationToken = default)
        {
            var sendLink = default(SendingAmqpLink);
            try
            {
                var request = AmqpRequestMessage.CreateRequest(
                    ManagementConstants.Operations.CancelScheduledMessageOperation,
                    timeout,
                    null);

                if (_sendLink.TryGetOpenedObject(out sendLink))
                {
                    request.AmqpMessage.ApplicationProperties.Map[ManagementConstants.Request.AssociatedLinkName] = sendLink.Name;
                }

                request.Map[ManagementConstants.Properties.SequenceNumbers] = sequenceNumbers;

                AmqpResponseMessage amqpResponseMessage = await ManagementUtilities.ExecuteRequestResponseAsync(
                        _connectionScope,
                        _managementLink,
                        request,
                        timeout).ConfigureAwait(false);

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

                if (amqpResponseMessage.StatusCode != AmqpResponseStatusCode.OK)
                {
                    throw amqpResponseMessage.ToMessagingContractException();
                }
            }
            catch (Exception exception)
            {
                ExceptionDispatchInfo.Capture(AmqpExceptionHelper.TranslateException(
                    exception,
                    sendLink?.GetTrackingId(),
                    null,
                    HasLinkCommunicationError(sendLink)))
                .Throw();

                throw; // will never be reached
            }
        }

        /// <summary>
        ///   Creates the AMQP link to be used for sender-related operations and ensures
        ///   that the corresponding state for the sender has been updated based on the link
        ///   configuration.
        /// </summary>
        ///
        /// <param name="timeout">The timeout to apply when creating the link.</param>
        /// <param name="cancellationToken">The cancellation token to consider when creating the link.</param>
        ///
        /// <returns>The AMQP link to use for sender-related operations.</returns>
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
            ServiceBusEventSource.Log.CreateSendLinkStart(_identifier);
            try
            {
                SendingAmqpLink link = await _connectionScope.OpenSenderLinkAsync(
                    entityPath: _entityPath,
                    identifier: _identifier,
                    timeout: timeout,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                if (!MaxMessageSize.HasValue)
                {
                    // This delay is necessary to prevent the link from causing issues for subsequent
                    // operations after creating a batch.  Without it, operations using the link consistently
                    // timeout.  The length of the delay does not appear significant, just the act of introducing
                    // an asynchronous delay.
                    //
                    // For consistency the value used by the legacy Service Bus client has been brought forward and
                    // used here.

                    await Task.Delay(15, cancellationToken).ConfigureAwait(false);
                    MaxMessageSize = (long)link.Settings.MaxMessageSize;
                }
                ServiceBusEventSource.Log.CreateSendLinkComplete(_identifier);
                link.Closed += OnSenderLinkClosed;
                return link;
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.CreateSendLinkException(_identifier, ex.ToString());
                throw;
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
        private static TimeSpan UseMinimum(TimeSpan firstOption,
                                           TimeSpan secondOption) => (firstOption < secondOption) ? firstOption : secondOption;

        private bool HasLinkCommunicationError(SendingAmqpLink link) =>
            !_closed && (link?.IsClosing() ?? false);
    }
}
