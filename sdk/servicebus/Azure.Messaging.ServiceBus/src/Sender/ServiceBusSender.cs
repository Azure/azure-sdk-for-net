// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Azure.Messaging.ServiceBus.Plugins;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   A client responsible for sending <see cref="ServiceBusMessage" /> to a specific Service Bus entity
    ///   (Queue or Topic). It can be used for both session and non-session entities. It is constructed by calling <see cref="ServiceBusClient.CreateSender(string)"/>.
    /// </summary>
    ///
    public class ServiceBusSender : IAsyncDisposable
    {
        /// <summary>The minimum allowable size, in bytes, for a batch to be sent.</summary>
        internal const int MinimumBatchSizeLimit = 24;

        /// <summary>
        ///   The fully qualified Service Bus namespace that the producer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => _connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The path of the entity that the sender is connected to, specific to the
        ///   Service Bus namespace that contains it.
        /// </summary>
        ///
        public string EntityPath { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusSender"/> has been closed.
        /// </summary>
        ///
        /// <value>
        /// <c>true</c> if the sender is closed; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosed
        {
            get => _closed;
            private set => _closed = value;
        }

        /// <summary>Indicates whether or not this instance has been closed.</summary>
        private volatile bool _closed;

        /// <summary>
        ///   The instance of <see cref="ServiceBusEventSource" /> which can be mocked for testing.
        /// </summary>
        ///
        internal ServiceBusEventSource Logger { get; set; } = ServiceBusEventSource.Log;

        /// <summary>
        /// Gets the ID to identify this client. This can be used to correlate logs and exceptions.
        /// </summary>
        /// <remarks>Every new client has a unique ID.</remarks>
        internal string Identifier { get; private set; }

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private readonly ServiceBusRetryPolicy _retryPolicy;

        /// <summary>
        ///   The active connection to the Azure Service Bus service, enabling client communications for metadata
        ///   about the associated Service Bus entity and access to transport-aware consumers.
        /// </summary>
        ///
        private readonly ServiceBusConnection _connection;

        /// <summary>
        ///   An abstracted Service Bus entity transport-specific sender that is associated with the
        ///   Service Bus entity gateway rather than a specific partition; intended to perform delegated operations.
        /// </summary>
        ///
        private readonly TransportSender _innerSender;
        private readonly EntityScopeFactory _scopeFactory;
        internal readonly IList<ServiceBusPlugin> _plugins;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSender"/> class.
        /// </summary>
        /// <param name="entityPath">The entity path to send the message to.</param>
        /// <param name="options">The set of <see cref="ServiceBusSenderOptions"/> to use for configuring
        /// this <see cref="ServiceBusSender"/>.</param>
        /// <param name="connection">The connection for the sender.</param>
        /// <param name="plugins">Plugins to apply to outgoing messages.</param>
        ///
        internal ServiceBusSender(
            string entityPath,
            ServiceBusSenderOptions options,
            ServiceBusConnection connection,
            IList<ServiceBusPlugin> plugins)
        {
            Logger.ClientCreateStart(typeof(ServiceBusSender), connection?.FullyQualifiedNamespace, entityPath);
            try
            {
                Argument.AssertNotNull(connection, nameof(connection));
                Argument.AssertNotNull(connection.RetryOptions, nameof(connection.RetryOptions));
                Argument.AssertNotNullOrWhiteSpace(entityPath, nameof(entityPath));
                connection.ThrowIfClosed();

                options = options?.Clone() ?? new ServiceBusSenderOptions();
                EntityPath = entityPath;
                Identifier = DiagnosticUtilities.GenerateIdentifier(EntityPath);
                _connection = connection;
                _retryPolicy = _connection.RetryOptions.ToRetryPolicy();
                _innerSender = _connection.CreateTransportSender(
                    entityPath,
                    _retryPolicy,
                    Identifier);
                _scopeFactory = new EntityScopeFactory(EntityPath, FullyQualifiedNamespace);
                _plugins = plugins;
            }
            catch (Exception ex)
            {
                Logger.ClientCreateException(typeof(ServiceBusSender), connection?.FullyQualifiedNamespace, entityPath, ex);
                throw;
            }
            Logger.ClientCreateComplete(typeof(ServiceBusSender), Identifier);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSender"/> class for mocking.
        /// </summary>
        ///
        protected ServiceBusSender()
        {
        }

        /// <summary>
        ///   Sends a message to the associated entity of Service Bus.
        /// </summary>
        /// <param name="message"></param>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task SendMessageAsync(
            ServiceBusMessage message,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            await SendMessagesAsync(
                new ServiceBusMessage[] { message },
                cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Sends a set of messages to the associated Service Bus entity using a batched approach.
        ///   If the size of the messages exceed the maximum size of a single batch,
        ///   an exception will be triggered and the send will fail. In order to ensure that the messages
        ///   being sent will fit in a batch, use <see cref="SendMessagesAsync(ServiceBusMessageBatch, CancellationToken)"/> instead.
        /// </summary>
        ///
        /// <param name="messages">The set of messages to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task SendMessagesAsync(
            IEnumerable<ServiceBusMessage> messages,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(messages, nameof(messages));
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusSender));
            IReadOnlyList<ServiceBusMessage> messageList = messages switch
            {
                IReadOnlyList<ServiceBusMessage> alreadyList => alreadyList,
                _ => messages.ToList()
            };

            if (messageList.Count == 0)
            {
                return;
            }
            await ApplyPlugins(messageList).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.SendMessageStart(Identifier, messageCount: messageList.Count);
            using DiagnosticScope scope = CreateDiagnosticScope(messages, DiagnosticProperty.SendActivityName);
            scope.Start();

            try
            {
                await _innerSender.SendAsync(
                    messageList,
                    cancellationToken).ConfigureAwait(false);
            }

            catch (Exception exception)
            {
                Logger.SendMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.SendMessageComplete(Identifier);
        }

        private async Task ApplyPlugins(IReadOnlyList<ServiceBusMessage> messages)
        {
            foreach (ServiceBusPlugin plugin in _plugins)
            {
                string pluginType = plugin.GetType().Name;
                foreach (ServiceBusMessage message in messages)
                {
                    try
                    {
                        Logger.PluginCallStarted(pluginType, message.MessageId);
                        await plugin.BeforeMessageSendAsync(message).ConfigureAwait(false);
                        Logger.PluginCallCompleted(pluginType, message.MessageId);
                    }
                    catch (Exception ex)
                    {
                        Logger.PluginCallException(pluginType, message.MessageId, ex.ToString());
                        throw;
                    }
                }
            }
        }

        private DiagnosticScope CreateDiagnosticScope(IEnumerable<ServiceBusMessage> messages, string activityName)
        {
            InstrumentMessages(messages);

            // create a new scope for the specified operation
            DiagnosticScope scope = _scopeFactory.CreateScope(
                activityName,
                DiagnosticProperty.ClientKind);

            scope.SetMessageData(messages);
            return scope;
        }

        /// <summary>
        ///   Performs the actions needed to instrument a set of messages.
        /// </summary>
        ///
        /// <param name="messages">The messages to instrument.</param>
        ///
        private void InstrumentMessages(IEnumerable<ServiceBusMessage> messages)
        {
            foreach (ServiceBusMessage message in messages)
            {
                if (!message.ApplicationProperties.ContainsKey(DiagnosticProperty.DiagnosticIdAttribute))
                {
                    using DiagnosticScope messageScope = _scopeFactory.CreateScope(
                        DiagnosticProperty.MessageActivityName,
                        DiagnosticProperty.ProducerKind);
                    messageScope.Start();

                    Activity activity = Activity.Current;
                    if (activity != null)
                    {
                        message.ApplicationProperties[DiagnosticProperty.DiagnosticIdAttribute] = activity.Id;
                    }
                }
            }
        }

        /// <summary>
        ///   Creates a size-constraint batch to which <see cref="ServiceBusMessage" /> may be added using
        ///   a <see cref="ServiceBusMessageBatch.TryAddMessage"/>. If a message would exceed the maximum
        ///   allowable size of the batch, the batch will not allow adding the message and signal that
        ///   scenario using it return value.
        ///
        ///   Because messages that would violate the size constraint cannot be added, publishing a batch
        ///   will not trigger an exception when attempting to send the messages to the Queue/Topic.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="ServiceBusMessageBatch" /> with the default batch options.</returns>
        ///
        /// <seealso cref="CreateMessageBatchAsync(CreateMessageBatchOptions, CancellationToken)" />
        ///
        public virtual ValueTask<ServiceBusMessageBatch> CreateMessageBatchAsync(CancellationToken cancellationToken = default) => CreateMessageBatchAsync(null, cancellationToken);

        /// <summary>
        ///   Creates a size-constraint batch to which <see cref="ServiceBusMessage" /> may be added using a try-based pattern.  If a message would
        ///   exceed the maximum allowable size of the batch, the batch will not allow adding the message and signal that scenario using its
        ///   return value.
        ///
        ///   Because messages that would violate the size constraint cannot be added, publishing a batch will not trigger an exception when
        ///   attempting to send the messages to the Queue/Topic.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider when creating this batch.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="ServiceBusMessageBatch" /> with the requested <paramref name="options"/>.</returns>
        ///
        /// <seealso cref="CreateMessageBatchAsync(CreateMessageBatchOptions, CancellationToken)" />
        ///
        public virtual async ValueTask<ServiceBusMessageBatch> CreateMessageBatchAsync(
            CreateMessageBatchOptions options,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusSender));
            options = options?.Clone() ?? new CreateMessageBatchOptions();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.CreateMessageBatchStart(Identifier);
            ServiceBusMessageBatch batch;
            try
            {
                TransportMessageBatch transportBatch = await _innerSender.CreateMessageBatchAsync(options, cancellationToken).ConfigureAwait(false);
                batch = new ServiceBusMessageBatch(transportBatch);
            }
            catch (Exception ex)
            {
                Logger.CreateMessageBatchException(Identifier, ex.ToString());
                throw;
            }
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.CreateMessageBatchComplete(Identifier);
            return batch;
        }

        /// <summary>
        ///   Sends a <see cref="ServiceBusMessageBatch"/>
        ///   containing a set of <see cref="ServiceBusMessage"/> to
        ///   the associated Service Bus entity.
        /// </summary>
        ///
        /// <param name="messageBatch">The batch of messages to send. A batch may be created using <see cref="CreateMessageBatchAsync(CancellationToken)" />.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task SendMessagesAsync(
            ServiceBusMessageBatch messageBatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(messageBatch, nameof(messageBatch));
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusSender));
            if (messageBatch.Count == 0)
            {
                return;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.SendMessageStart(Identifier, messageBatch.Count);
            using DiagnosticScope scope = CreateDiagnosticScope(
                messageBatch.AsEnumerable<ServiceBusMessage>(),
                DiagnosticProperty.SendActivityName);
            scope.Start();

            try
            {
                messageBatch.Lock();
                await _innerSender.SendBatchAsync(messageBatch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.SendMessageException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }
            finally
            {
                messageBatch.Unlock();
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.SendMessageComplete(Identifier);
        }

        /// <summary>
        /// Schedules a message to appear on Service Bus at a later time.
        /// </summary>
        ///
        /// <param name="message">The <see cref="ServiceBusMessage"/> to schedule.</param>
        /// <param name="scheduledEnqueueTime">The UTC time at which the message should be available for processing</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Although the message will not be available to be received until the scheduledEnqueueTime, it can still be peeked before that time.
        /// Messages can also be scheduled by setting <see cref="ServiceBusMessage.ScheduledEnqueueTime"/> and
        /// using <see cref="SendMessageAsync(ServiceBusMessage, CancellationToken)"/>,
        /// <see cref="SendMessagesAsync(IEnumerable{ServiceBusMessage}, CancellationToken)"/>, or
        /// <see cref="SendMessagesAsync(ServiceBusMessageBatch, CancellationToken)"/>.</remarks>
        ///
        /// <returns>The sequence number of the message that was scheduled.</returns>
        public virtual async Task<long> ScheduleMessageAsync(
            ServiceBusMessage message,
            DateTimeOffset scheduledEnqueueTime,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            IReadOnlyList<long> sequenceNumbers = await ScheduleMessagesAsync(
                new ServiceBusMessage[] { message },
                scheduledEnqueueTime,
                cancellationToken)
            .ConfigureAwait(false);
            // if there isn't one sequence number in the list, an
            // exception should have been thrown by this point.
            return sequenceNumbers[0];
        }

        /// <summary>
        /// Schedules a set of messages to appear on Service Bus at a later time.
        /// </summary>
        ///
        /// <param name="messages">The set of messages to schedule.</param>
        /// <param name="scheduledEnqueueTime">The UTC time at which the message should be available for processing</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <remarks>Although the message will not be available to be received until the scheduledEnqueueTime, it can still be peeked before that time.
        /// Messages can also be scheduled by setting <see cref="ServiceBusMessage.ScheduledEnqueueTime"/> and
        /// using <see cref="SendMessageAsync(ServiceBusMessage, CancellationToken)"/>,
        /// <see cref="SendMessagesAsync(IEnumerable{ServiceBusMessage}, CancellationToken)"/>, or
        /// <see cref="SendMessagesAsync(ServiceBusMessageBatch, CancellationToken)"/>.</remarks>
        ///
        /// <returns>The sequence number of the message that was scheduled.</returns>
        public virtual async Task<IReadOnlyList<long>> ScheduleMessagesAsync(
            IEnumerable<ServiceBusMessage> messages,
            DateTimeOffset scheduledEnqueueTime,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(messages, nameof(messages));
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusSender));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            IReadOnlyList<ServiceBusMessage> messageList = messages switch
            {
                IReadOnlyList<ServiceBusMessage> alreadyList => alreadyList,
                _ => messages.ToList()
            };

            if (messageList.Count == 0)
            {
                return Array.Empty<long>();
            }

            await ApplyPlugins(messageList).ConfigureAwait(false);
            Logger.ScheduleMessagesStart(
                Identifier,
                messageList.Count,
                scheduledEnqueueTime.ToString(CultureInfo.InvariantCulture));

            using DiagnosticScope scope = CreateDiagnosticScope(
                messages,
                DiagnosticProperty.ScheduleActivityName);
            scope.Start();

            IReadOnlyList<long> sequenceNumbers = null;
            try
            {
                foreach (ServiceBusMessage message in messageList)
                {
                    message.ScheduledEnqueueTime = scheduledEnqueueTime.UtcDateTime;
                }
                sequenceNumbers = await _innerSender.ScheduleMessagesAsync(messageList, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                Logger.ScheduleMessagesException(Identifier, exception.ToString());
                scope.Failed(exception);
                throw;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.ScheduleMessagesComplete(Identifier);
            return sequenceNumbers;
        }

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="ServiceBusReceivedMessage.SequenceNumber"/> of the message to be cancelled.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public virtual async Task CancelScheduledMessageAsync(
            long sequenceNumber,
            CancellationToken cancellationToken = default) =>
            await CancelScheduledMessagesAsync(
                new long[] { sequenceNumber },
                cancellationToken)
            .ConfigureAwait(false);

        /// <summary>
        /// Cancels a set of messages that were scheduled.
        /// </summary>
        /// <param name="sequenceNumbers">The set of <see cref="ServiceBusReceivedMessage.SequenceNumber"/> of the messages to be cancelled.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        public virtual async Task CancelScheduledMessagesAsync(
            IEnumerable<long> sequenceNumbers,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotDisposed(IsClosed, nameof(ServiceBusSender));
            Argument.AssertNotNull(sequenceNumbers, nameof(sequenceNumbers));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();

            // the sequence numbers MUST be in array form for them to be encoded correctly
            long[] sequenceArray = sequenceNumbers switch
            {
                long[] alreadyArray => alreadyArray,
                _ => sequenceNumbers.ToArray()
            };

            if (sequenceArray.Length == 0)
            {
                return;
            }

            Logger.CancelScheduledMessagesStart(Identifier, sequenceArray);

            using DiagnosticScope scope = _scopeFactory.CreateScope(
                DiagnosticProperty.CancelActivityName,
                DiagnosticProperty.ClientKind);
            scope.Start();

            try
            {
                await _innerSender.CancelScheduledMessagesAsync(sequenceArray, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.CancelScheduledMessagesException(Identifier, ex.ToString());
                throw;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            Logger.CancelScheduledMessagesComplete(Identifier);
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusSender" />.
        /// </summary>
        /// <param name="cancellationToken"> An optional<see cref="CancellationToken"/> instance to signal the
        /// request to cancel the operation.</param>
        public virtual async Task CloseAsync(
            CancellationToken cancellationToken = default)
        {
            IsClosed = true;

            Logger.ClientCloseStart(typeof(ServiceBusSender), Identifier);

            try
            {
                await _innerSender.CloseAsync(CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Logger.ClientCloseException(typeof(ServiceBusSender), Identifier, ex);
                throw;
            }

            Logger.ClientCloseComplete(typeof(ServiceBusSender), Identifier);
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusSender" />.
        ///   This is equivalent to calling <see cref="CloseAsync"/> with the default <see cref="LinkCloseMode"/>.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync() =>
            await CloseAsync().ConfigureAwait(false);

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
