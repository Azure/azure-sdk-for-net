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
        public bool IsClosed => _closed;

        /// <summary>
        /// The identifier of the sender.
        /// </summary>
        public string Identifier { get; }

        /// <summary>
        ///   The name of the Service Bus entity to which the sender is bound.
        /// </summary>
        ///
        private readonly string _entityPath;

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private readonly ServiceBusRetryPolicy _retryPolicy;

        /// <summary>
        ///    The converter to use for translating <see cref="ServiceBusMessage" /> into an AMQP-specific message.
        /// </summary>
        private readonly AmqpMessageConverter _messageConverter;

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
        ///   The maximum size of an AMQP message batch allowed by the associated
        ///   sender link.
        /// </summary>
        ///
        /// <value>The maximum message batch size, in bytes.</value>
        ///
        private long? MaxBatchSize { get; set; }

        /// <summary>
        ///   The maximum number of messages to allow in a single batch.
        /// </summary>
        ///
        private int MaxMessageCount { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AmqpSender"/> class.
        /// </summary>
        ///
        /// <param name="entityPath">The name of the entity to which messages will be sent.</param>
        /// <param name="connectionScope">The AMQP connection context for operations.</param>
        /// <param name="retryPolicy">The retry policy to consider when an operation fails.</param>
        /// <param name="identifier">The identifier for the sender.</param>
        /// <param name="messageConverter">The converter to use for translating <see cref="ServiceBusMessage" /> into an AMQP-specific message.</param>
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
            string identifier,
            AmqpMessageConverter messageConverter)
        {
            Argument.AssertNotNullOrEmpty(entityPath, nameof(entityPath));
            Argument.AssertNotNull(connectionScope, nameof(connectionScope));
            Argument.AssertNotNull(retryPolicy, nameof(retryPolicy));

            // NOTE:
            //   This is a temporary work-around until Service Bus exposes a link property for
            //   the maximum batch size.  The limit for batches differs from the limit for individual
            //   messages.  Tracked by: https://github.com/Azure/azure-sdk-for-net/issues/44914
            MaxBatchSize = 1048576;

            // NOTE:
            //   This is a temporary work-around until Service Bus exposes a link property for
            //   the maximum batch size.  The limit for batches differs from the limit for individual
            //   messages.  Tracked by: https://github.com/Azure/azure-sdk-for-net/issues/44916
            MaxMessageCount = 4500;

            _entityPath = entityPath;
            Identifier = identifier;
            _retryPolicy = retryPolicy;
            _connectionScope = connectionScope;

            _sendLink = new FaultTolerantAmqpObject<SendingAmqpLink>(
                timeout => CreateLinkAndEnsureSenderStateAsync(timeout, CancellationToken.None),
                link => _connectionScope.CloseLink(link, Identifier));

            _managementLink = new FaultTolerantAmqpObject<RequestResponseAmqpLink>(
                timeout => OpenManagementLinkAsync(timeout),
                link => _connectionScope.CloseLink(link, Identifier));
            _messageConverter = messageConverter;
        }

        private async Task<RequestResponseAmqpLink> OpenManagementLinkAsync(
            TimeSpan timeout)
        {
            RequestResponseAmqpLink link = await _connectionScope.OpenManagementLinkAsync(
                _entityPath,
                Identifier,
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
            return await _retryPolicy.RunOperation(static async (value, timeout, _) =>
                {
                    var (sender, options) = value;
                    return await sender.CreateMessageBatchInternalAsync(
                        options,
                        timeout).ConfigureAwait(false);
                },
                (this, options),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
        }

        internal async ValueTask<TransportMessageBatch> CreateMessageBatchInternalAsync(
            CreateMessageBatchOptions options,
            TimeSpan timeout)
        {
            Argument.AssertNotNull(options, nameof(options));

            // Ensure that maximum message size has been determined; this depends on the underlying
            // AMQP link, so if not set, requesting the link will ensure that it is populated.

            if ((!MaxMessageSize.HasValue) || (!MaxBatchSize.HasValue))
            {
                await _sendLink.GetOrCreateAsync(timeout).ConfigureAwait(false);
            }

            // Ensure that there was a maximum size populated; if none was provided,
            // default to the maximum size allowed by the link.

            options.MaxSizeInBytes ??= MaxBatchSize;
            options.MaxMessageCount ??= MaxMessageCount;

            Argument.AssertInRange(options.MaxSizeInBytes.Value, ServiceBusSender.MinimumBatchSizeLimit, MaxBatchSize.Value, nameof(options.MaxSizeInBytes));
            return new AmqpMessageBatch(_messageConverter, options);
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
            await _retryPolicy.RunOperation(static async (value, timeout, token) =>
                {
                    var (sender, messageBatch) = value;
                    await sender.SendBatchInternalAsync(
                        messageBatch.AsReadOnly<AmqpMessage>(),
                        timeout,
                        token).ConfigureAwait(false);
                },
                (this, messageBatch),
            _connectionScope,
            cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///    Sends a set of messages to the associated Queue/Topic using a batched approach.
        /// </summary>
        ///
        /// <param name="messages"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        internal virtual async Task SendBatchInternalAsync(
            IReadOnlyCollection<AmqpMessage> messages,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            using (AmqpMessage batchMessage = _messageConverter.BuildAmqpBatchFromMessages(messages, false))
            {
                await SendBatchInternalAsync(batchMessage, timeout, cancellationToken).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///    Sends a set of messages to the associated Queue/Topic using a batched approach.
        /// </summary>
        ///
        /// <param name="batchMessage">A batch of messages to send represented as a <see cref="AmqpMessage"/>.</param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        internal virtual async Task SendBatchInternalAsync(
            AmqpMessage batchMessage,
            TimeSpan timeout,
            CancellationToken cancellationToken)
        {
            var link = default(SendingAmqpLink);

            try
            {
                ArraySegment<byte> transactionId = AmqpConstants.NullBinary;
                Transaction ambientTransaction = Transaction.Current;
                if (ambientTransaction != null)
                {
                    transactionId = await AmqpTransactionManager.Instance.EnlistAsync(
                        ambientTransaction,
                        _connectionScope,
                        timeout).ConfigureAwait(false);
                }

                link = await _sendLink.GetOrCreateAsync(timeout, cancellationToken).ConfigureAwait(false);

                // Validate that the message is not too large to send.  This is done after the link is created to ensure
                // that the maximum message size is known, as it is dictated by the service using the link.

                if (batchMessage.SerializedMessageSize > MaxMessageSize)
                {
                    string messageHash = batchMessage.GetHashCode().ToString(CultureInfo.InvariantCulture);
                    throw new ServiceBusException(string.Format(CultureInfo.InvariantCulture, Resources.MessageSizeExceeded, messageHash, batchMessage.SerializedMessageSize, MaxMessageSize, _entityPath), ServiceBusFailureReason.MessageSizeExceeded);
                }

                // Attempt to send the message batch.

                var deliveryTag = new ArraySegment<byte>(BitConverter.GetBytes(Interlocked.Increment(ref _deliveryCount)));
                Outcome outcome = await link.SendMessageAsync(
                    batchMessage,
                    deliveryTag,
                    transactionId,
                    cancellationToken).ConfigureAwait(false);

                if (outcome.DescriptorCode != Accepted.Code)
                {
                    throw (outcome as Rejected)?.Error.ToMessagingContractException();
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
            IReadOnlyCollection<ServiceBusMessage> messages,
            CancellationToken cancellationToken)
        {
            await _retryPolicy.RunOperation(static async (value, timeout, token) =>
                {
                    var (sender, messages) = value;
                    await sender.SendBatchInternalAsync(
                        sender._messageConverter.BatchSBMessagesAsAmqpMessage(messages, false),
                        timeout,
                        token).ConfigureAwait(false);
                },
                (this, messages),
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
                    await _sendLink.CloseAsync(CancellationToken.None).ConfigureAwait(false);
                }

                if (_managementLink?.TryGetOpenedObject(out var _) == true)
                {
                    cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                    await _managementLink.CloseAsync(CancellationToken.None).ConfigureAwait(false);
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
                Identifier,
                sender);

        private void OnManagementLinkClosed(object managementLink, EventArgs e) =>
            ServiceBusEventSource.Log.ManagementLinkClosed(
                Identifier,
                managementLink);

        /// <summary>
        ///
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<IReadOnlyList<long>> ScheduleMessagesAsync(
            IReadOnlyCollection<ServiceBusMessage> messages,
            CancellationToken cancellationToken = default)
        {
            return await _retryPolicy.RunOperation(static async (value, timeout, token) =>
                {
                    var (sender, messages) = value;
                    return await sender
                        .ScheduleMessageInternalAsync(
                            messages,
                            timeout,
                            token).ConfigureAwait(false);
                },
                (this, messages),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="timeout"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async Task<IReadOnlyList<long>> ScheduleMessageInternalAsync(
            IReadOnlyCollection<ServiceBusMessage> messages,
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

                List<AmqpMap> entries = new List<AmqpMap>(messages.Count);
                foreach (ServiceBusMessage message in messages)
                {
                    using AmqpMessage amqpMessage = _messageConverter.SBMessageToAmqpMessage(message);
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

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                AmqpResponseMessage amqpResponseMessage = await ManagementUtilities.ExecuteRequestResponseAsync(
                    _connectionScope,
                    _managementLink,
                    request,
                    timeout).ConfigureAwait(false);

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
            await _retryPolicy.RunOperation(static async (value, timeout, token) =>
                {
                    var (sender, sequenceNumbers) = value;
                    await sender.CancelScheduledMessageInternalAsync(
                        sequenceNumbers,
                        timeout,
                        token).ConfigureAwait(false);
                },
                (this, sequenceNumbers),
                _connectionScope,
                cancellationToken).ConfigureAwait(false);
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

                cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
                AmqpResponseMessage amqpResponseMessage = await ManagementUtilities.ExecuteRequestResponseAsync(
                        _connectionScope,
                        _managementLink,
                        request,
                        timeout).ConfigureAwait(false);

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
            ServiceBusEventSource.Log.CreateSendLinkStart(Identifier);
            try
            {
                SendingAmqpLink link = await _connectionScope.OpenSenderLinkAsync(
                    entityPath: _entityPath,
                    identifier: Identifier,
                    timeout: timeout,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                // Update the known maximum message size each time a link is opened, as the
                // configuration can be changed on-the-fly and may not match the previously cached value.
                //
                // This delay is necessary to prevent the link from causing issues for subsequent
                // operations after creating a batch.  Without it, operations using the link consistently
                // timeout.  The length of the delay does not appear significant, just the act of introducing
                // an asynchronous delay.
                //
                // For consistency the value used by the legacy Service Bus client has been brought forward and
                // used here.

                await Task.Delay(15, cancellationToken).ConfigureAwait(false);
                MaxMessageSize = (long)link.Settings.MaxMessageSize;

                // Update with service metadata when available:
                //  https://github.com/Azure/azure-sdk-for-net/issues/44914
                //  https://github.com/Azure/azure-sdk-for-net/issues/44916

                MaxBatchSize = Math.Min(MaxMessageSize.Value, MaxBatchSize.Value);
                MaxMessageSize = MaxMessageSize;

                ServiceBusEventSource.Log.CreateSendLinkComplete(Identifier);
                link.Closed += OnSenderLinkClosed;
                return link;
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.CreateSendLinkException(Identifier, ex.ToString());
                throw;
            }
        }

        private bool HasLinkCommunicationError(SendingAmqpLink link) =>
            !_closed && (link?.IsClosing() ?? false);
    }
}
