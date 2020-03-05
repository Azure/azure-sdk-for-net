// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Messaging.ServiceBus.Core;
using Azure.Messaging.ServiceBus.Diagnostics;
using Microsoft.Azure.Amqp;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   A client responsible for sending <see cref="ServiceBusMessage" /> to a specific Service Bus entity (queue or topic).
    /// </summary>
    ///
    public class ServiceBusSender : IAsyncDisposable
    {
        /// <summary>
        ///   The fully qualified Service Bus namespace that the producer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => _connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the entity that the producer is connected to, specific to the
        ///   Service Bus namespace that contains it.
        /// </summary>
        ///
        public string EntityName { get; }

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusSender"/> has been closed.
        /// </summary>
        ///
        /// <value>
        ///   <c>true</c> if the client is closed; otherwise, <c>false</c>.
        /// </value>
        ///
        public bool IsClosed { get; protected set; } = false;

        /// <summary>
        ///   Indicates whether the client has ownership of the associated <see cref="ServiceBusConnection" />
        ///   and should take responsibility for managing its lifespan.
        /// </summary>
        ///
        private bool OwnsConnection { get; } = false;

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
        ///
        /// </summary>
        private ClientDiagnostics ClientDiagnostics { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSender"/> class.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="options">A set of options to apply when configuring the producer.</param>
        /// <param name="entityName"></param>
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the  name="entityName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        internal ServiceBusSender(
            ServiceBusConnection connection,
            ServiceBusSenderOptions options,
            string entityName)
        {
            if (entityName == null)
            {
                throw new ArgumentException();
            }

            options = options?.Clone() ?? new ServiceBusSenderOptions();
            ClientDiagnostics = new ClientDiagnostics(options);
            OwnsConnection = false;
            EntityName = entityName;
            _connection = connection;
            _retryPolicy = options.RetryOptions.ToRetryPolicy();
            _innerSender = _connection.CreateTransportSender(
                entityName,
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
        ///   Sends a set of events to the associated Service Bus entity using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="message">The set of event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendRangeInternal(IEnumerable{ServiceBusMessage}, CancellationToken)"/>
        ///
        public virtual async Task SendAsync(
            ServiceBusMessage message,
            CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(message, nameof(message));
            await SendBatchAsync(new ServiceBusMessage[]{message}, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Sends a set of events to the associated Service Bus entity using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="messages">The set of event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        /// <seealso cref="SendRangeInternal(IEnumerable{ServiceBusMessage}, CancellationToken)"/>
        ///
        public virtual async Task SendBatchAsync(IEnumerable<ServiceBusMessage> messages, CancellationToken cancellationToken = default) =>
            await SendRangeInternal(messages, cancellationToken).ConfigureAwait(false);

        ///// <summary>
        /////   Sends a set of events to the associated Service Bus entity using a batched approach.  If the size of events exceed the
        /////   maximum size of a single batch, an exception will be triggered and the send will fail.
        ///// </summary>
        /////
        ///// <param name="messages">The set of event data to send.</param>
        ///// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        /////
        ///// <returns>A task to be resolved on when the operation has completed.</returns>
        /////
        ///// <seealso cref="SendRangeInternal(IEnumerable{ServiceBusMessage}, CancellationToken)"/>
        /////
        //public virtual async Task SendBatchAsync(ServiceBusMessageBatch messages, CancellationToken cancellationToken = default) =>
        //    await SendRangeInternal(new ServiceBusMessage[] { }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Schedules a message to appear on Service Bus at a later time.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="scheduleEnqueueTimeUtc">The UTC time at which the message should be available for processing</param>
        /// <param name="cancellationToken"></param>
        /// <returns>The sequence number of the message that was scheduled.</returns>
        public virtual async Task<long> ScheduleMessageAsync(
            ServiceBusMessage message,
            DateTimeOffset scheduleEnqueueTimeUtc,
            CancellationToken cancellationToken = default)
        {
            //this.ThrowIfClosed();
            Argument.AssertNotNull(message, nameof(message));
            message.ScheduledEnqueueTimeUtc = scheduleEnqueueTimeUtc.UtcDateTime;
            return await _innerSender.ScheduleMessageAsync(message, _retryPolicy, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="ServiceBusReceivedMessage.SequenceNumber"/> of the message to be cancelled.</param>
        /// <param name="cancellationToken"></param>
        public virtual async Task CancelScheduledMessageAsync(long sequenceNumber, CancellationToken cancellationToken = default)
        {
            //this.ThrowIfClosed();
            await _innerSender.CancelScheduledMessageAsync(sequenceNumber, _retryPolicy, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///   Sends a set of events to the associated Service Bus entity using a batched approach.  If the size of events exceed the
        ///   maximum size of a single batch, an exception will be triggered and the send will fail.
        /// </summary>
        ///
        /// <param name="messages">The set of event data to send.</param>
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///

        ///
        internal async Task SendRangeInternal(
            IEnumerable<ServiceBusMessage> messages,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(messages, nameof(messages));

            using DiagnosticScope scope = CreateDiagnosticScope();
            messages = messages.ToList();
            InstrumentMessages(messages);

            try
            {
                await _innerSender.SendAsync(messages, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        ///   Closes the producer.
        /// </summary>
        ///
        /// <param name="cancellationToken">An optional <see cref="CancellationToken"/> instance to signal the request to cancel the operation.</param>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        public virtual async Task CloseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested<TaskCanceledException>();
            IsClosed = true;

            var identifier = GetHashCode().ToString();
            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusSender), EntityName, identifier);

            // Attempt to close the active transport producers.  In the event that an exception is encountered,
            // it should not impact the attempt to close the connection, assuming ownership.

            var transportProducerException = default(Exception);

            try
            {
                await _innerSender.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseError(typeof(ServiceBusSender), EntityName, identifier, ex.Message);
                transportProducerException = ex;
            }

            // An exception when closing the connection supersedes one observed when closing the
            // individual transport clients.

            try
            {
                if (OwnsConnection)
                {
                    await _connection.CloseAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseError(typeof(ServiceBusSender), EntityName, identifier, ex.Message);
                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientCloseComplete(typeof(ServiceBusSender), EntityName, identifier);
            }

            // If there was an active exception pending from closing the individual
            // transport producers, surface it now.

            if (transportProducerException != default)
            {
                throw transportProducerException;
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusSender" />,
        ///   including ensuring that the client itself has been closed.
        /// </summary>
        ///
        /// <returns>A task to be resolved on when the operation has completed.</returns>
        ///
        [SuppressMessage("Usage", "AZC0002:Ensure all service methods take an optional CancellationToken parameter.", Justification = "This signature must match the IAsyncDisposable interface.")]
        public virtual async ValueTask DisposeAsync() => await CloseAsync().ConfigureAwait(false);

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
        ///   Creates and configures a diagnostics scope to be used for instrumenting
        ///   events.
        /// </summary>
        ///
        /// <returns>The requested <see cref="DiagnosticScope" />.</returns>
        ///
        internal virtual DiagnosticScope CreateDiagnosticScope()
        {
            DiagnosticScope scope = ClientDiagnostics.CreateScope(DiagnosticProperty.SenderActivityName);
            scope.AddAttribute(DiagnosticProperty.TypeAttribute, DiagnosticProperty.ServiceBusSenderType);
            scope.AddAttribute(DiagnosticProperty.ServiceContextAttribute, DiagnosticProperty.ServiceBusServiceContext);
            scope.AddAttribute(DiagnosticProperty.ServiceBusAttribute, EntityName);
            scope.AddAttribute(DiagnosticProperty.EndpointAttribute, _connection.ServiceEndpoint);
            scope.Start();

            return scope;
        }

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
