// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   A client responsible for sending <see cref="ServiceBusMessage" /> to a specific Service Bus entity (queue or topic).
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
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed { get; private set; } = false;

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

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSender"/> class.
        /// </summary>
        /// <param name="entityPath"></param>
        /// <param name="connection"></param>
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the  name="entityName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        internal ServiceBusSender(
            string entityPath,
            ServiceBusConnection connection)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(connection.RetryOptions, nameof(connection.RetryOptions));
            Argument.AssertNotNullOrWhiteSpace(entityPath, nameof(entityPath));
            connection.ThrowIfClosed();

            EntityPath = entityPath;
            Identifier = DiagnosticUtilities.GenerateIdentifier(EntityPath);
            _connection = connection;
            _retryPolicy = _connection.RetryOptions.ToRetryPolicy();
            _innerSender = _connection.CreateTransportSender(
                entityPath,
                _retryPolicy);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSender"/> class.
        /// </summary>
        ///
        protected ServiceBusSender()
        {
        }

        /// <summary>
        ///   Sends a message to the associated entity of Service Bus.
        /// </summary>
        ///
        /// <param name="message">A messsage to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task SendAsync(
            ServiceBusMessage message,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusSender));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.SendMessageStart(Identifier, messageCount: 1);
            try
            {
                await _innerSender.SendAsync(message, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.SendMessageException(Identifier, ex);
                throw;
            }
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.SendMessageComplete(Identifier);
        }
        /// <summary>
        ///   Creates a size-constraint batch to which <see cref="ServiceBusMessage" /> may be added using a try-based pattern.  If a message would
        ///   exceed the maximum allowable size of the batch, the batch will not allow adding the message and signal that scenario using its
        ///   return value.
        ///
        ///   Because messages that would violate the size constraint cannot be added, publishing a batch will not trigger an exception when
        ///   attempting to send the messages to the Queue/Topic.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>An <see cref="ServiceBusMessageBatch" /> with the default batch options.</returns>
        ///
        /// <seealso cref="CreateBatchAsync(CreateBatchOptions, CancellationToken)" />
        ///
        public virtual ValueTask<ServiceBusMessageBatch> CreateBatchAsync(CancellationToken cancellationToken = default) => CreateBatchAsync(null, cancellationToken);

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
        /// <seealso cref="CreateBatchAsync(CreateBatchOptions, CancellationToken)" />
        ///
        public virtual async ValueTask<ServiceBusMessageBatch> CreateBatchAsync(
            CreateBatchOptions options,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusSender));
            options = options?.Clone() ?? new CreateBatchOptions();
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.CreateMessageBatchStart(Identifier);
            ServiceBusMessageBatch batch;
            try
            {
                TransportMessageBatch transportBatch = await _innerSender.CreateBatchAsync(options, cancellationToken).ConfigureAwait(false);
                batch = new ServiceBusMessageBatch(transportBatch);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.CreateMessageBatchException(Identifier, ex);
                throw;
            }
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.CreateMessageBatchComplete(Identifier);
            return batch;
        }

        /// <summary>
        ///   Sends a set of messages to the associated Service Bus entity using a batched approach.  If the size of messages exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="messageBatch">The set of messages to send. A batch may be created using <see cref="CreateBatchAsync(CancellationToken)" />.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /// Make sure we have plenty of tests to cover all the corner cases for batch size.
        /// TODO - add safeguards to prevent any access to batch while it is being sent. We should dispose
        /// the batch once the send batch operation is completed? Or at least flag it as not allowing
        /// additional operations.
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task SendBatchAsync(
            ServiceBusMessageBatch messageBatch,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(messageBatch, nameof(messageBatch));
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusSender));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.SendMessageStart(Identifier, messageBatch.Count);
            try
            {
                await _innerSender.SendBatchAsync(messageBatch, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.SendMessageException(Identifier, ex);
                throw;
            }
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.SendMessageComplete(Identifier);
        }

        /// <summary>
        /// Schedules a message to appear on Service Bus at a later time.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="scheduledEnqueueTime">The UTC time at which the message should be available for processing</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The sequence number of the message that was scheduled.</returns>
        public virtual async Task<long> ScheduleMessageAsync(
            ServiceBusMessage message,
            DateTimeOffset scheduledEnqueueTime,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusSender));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.ScheduleMessageStart(Identifier, scheduledEnqueueTime);

            long sequenceNumber;
            try
            {
                message.ScheduledEnqueueTime = scheduledEnqueueTime.UtcDateTime;
                sequenceNumber = await _innerSender.ScheduleMessageAsync(message, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ScheduleMessageException(Identifier, ex);
                throw;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.ScheduleMessageComplete(Identifier);
            return sequenceNumber;
        }

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="ServiceBusReceivedMessage.SequenceNumber"/> of the message to be cancelled.</param>
        /// <param name="cancellationToken"></param>
        public virtual async Task CancelScheduledMessageAsync(
            long sequenceNumber,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotClosed(IsClosed, nameof(ServiceBusSender));
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.CancelScheduledMessageStart(Identifier, sequenceNumber);

            try
            {
                await _innerSender.CancelScheduledMessageAsync(sequenceNumber, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.CancelScheduledMessageException(Identifier, ex);
                throw;
            }

            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            ServiceBusEventSource.Log.CancelScheduledMessageComplete(Identifier);
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusSender" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync()
        {
            IsClosed = true;

            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusSender), Identifier);

            try
            {
                await _innerSender.CloseAsync(CancellationToken.None).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseException(typeof(ServiceBusSender), Identifier, ex);
                throw;
            }

            ServiceBusEventSource.Log.ClientCloseComplete(typeof(ServiceBusSender), Identifier);
        }

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

        /// <summary>
        ///   Performs the actions needed to instrument a set of events.
        /// </summary>
        ///
        /// <param name="messages">The events to instrument.</param>
        ///
        private void InstrumentMessages(IEnumerable<ServiceBusMessage> messages)
        {
            foreach (ServiceBusMessage message in messages)
            {
                //EventDataInstrumentation.InstrumentEvent(message);
            }
        }
    }
}
