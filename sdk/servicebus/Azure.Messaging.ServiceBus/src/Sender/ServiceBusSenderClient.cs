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

namespace Azure.Messaging.ServiceBus.Sender
{
    /// <summary>
    ///   A client responsible for sending <see cref="ServiceBusMessage" /> to a specific Service Bus entity (queue or topic).
    /// </summary>
    ///
    public class ServiceBusSenderClient : IAsyncDisposable
    {
        /// <summary>
        ///   The fully qualified Service Bus namespace that the producer is associated with.  This is likely
        ///   to be similar to <c>{yournamespace}.servicebus.windows.net</c>.
        /// </summary>
        ///
        public string FullyQualifiedNamespace => Connection.FullyQualifiedNamespace;

        /// <summary>
        ///   The name of the entity that the producer is connected to, specific to the
        ///   Service Bus namespace that contains it.
        /// </summary>
        ///
        public string EntityName => Connection.EntityName;

        /// <summary>
        ///   Indicates whether or not this <see cref="ServiceBusSenderClient"/> has been closed.
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
        private bool OwnsConnection { get; } = true;

        /// <summary>
        ///   The policy to use for determining retry behavior for when an operation fails.
        /// </summary>
        ///
        private ServiceBusRetryPolicy RetryPolicy { get; }

        /// <summary>
        ///   The active connection to the Azure Service Bus service, enabling client communications for metadata
        ///   about the associated Service Bus entity and access to a transport-aware sender.
        /// </summary>
        ///
        private ServiceBusConnection Connection { get; }

        /// <summary>
        ///   An abstracted Service Bus entity transport-specific sender that is associated with the
        ///   Service Bus entity gateway rather than a specific partition; intended to perform delegated operations.
        /// </summary>
        ///
        internal virtual TransportSender InnerSender { get; }

        /// <summary>
        ///
        /// </summary>
        private ClientDiagnostics ClientDiagnostics { get; set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired Service Bus entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ Service Bus entity NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=orders-queue".
        ///
        ///   If you have defined a shared access policy directly on the Service Bus entity itself, then copying the connection string from that
        ///   Service Bus entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public ServiceBusSenderClient(string connectionString) : this(connectionString, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
        /// <param name="clientOptions">The set of options to use for this consumer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired Service Bus entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ Service Bus entity NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=orders-queue".
        ///
        ///   If you have defined a shared access policy directly on the Service Bus entity itself, then copying the connection string from that
        ///   Service Bus entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public ServiceBusSenderClient(string connectionString, ServiceBusSenderClientOptions clientOptions)
            : this(connectionString, null, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the shared key properties are contained in this connection string, but not the Service Bus entity name.</param>
        /// <param name="entityName">The name of the specific Service Bus entity to associate the producer with.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the <paramref name="entityName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public ServiceBusSenderClient(string connectionString, string entityName)
            : this(connectionString, entityName, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the shared key properties are contained in this connection string, but not the Service Bus entity name.</param>
        /// <param name="entityName">The name of the specific Service Bus entity to associate the producer with.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the <paramref name="entityName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public ServiceBusSenderClient(
            string connectionString,
            string entityName,
            ServiceBusSenderClientOptions clientOptions)
        {
            Argument.AssertNotNullOrEmpty(connectionString, nameof(connectionString));
            clientOptions = clientOptions?.Clone() ?? new ServiceBusSenderClientOptions();
            ClientDiagnostics = new ClientDiagnostics(clientOptions);
            OwnsConnection = true;
            Connection = new ServiceBusConnection(connectionString, entityName, clientOptions.ConnectionOptions);
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            InnerSender = Connection.CreateTransportProducer(RetryPolicy);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of the specific Service Bus entity to associated the producer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        public ServiceBusSenderClient(
            string fullyQualifiedNamespace,
            string entityName,
            TokenCredential credential,
            ServiceBusSenderClientOptions clientOptions = default)
        {
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(fullyQualifiedNamespace, nameof(fullyQualifiedNamespace));
            Argument.AssertNotNullOrEmpty(entityName, nameof(entityName));
            Argument.AssertNotNull(credential, nameof(credential));

            clientOptions = clientOptions?.Clone() ?? new ServiceBusSenderClientOptions();
            ClientDiagnostics = new ClientDiagnostics(clientOptions);

            OwnsConnection = true;
            Connection = new ServiceBusConnection(fullyQualifiedNamespace, entityName, credential, clientOptions.ConnectionOptions);
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            InnerSender = Connection.CreateTransportProducer(RetryPolicy);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="connection">The <see cref="ServiceBusConnection" /> connection to use for communication with the Service Bus service.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the producer.</param>
        ///
        internal ServiceBusSenderClient(
            ServiceBusConnection connection,
            ServiceBusSenderClientOptions clientOptions = default)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            clientOptions = clientOptions?.Clone() ?? new ServiceBusSenderClientOptions();
            ClientDiagnostics = new ClientDiagnostics(clientOptions);

            OwnsConnection = false;
            Connection = connection;
            RetryPolicy = clientOptions.RetryOptions.ToRetryPolicy();
            InnerSender = Connection.CreateTransportProducer(RetryPolicy);
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        /// <param name="connection">The connection to use as the basis for delegation of client-type operations.</param>
        /// <param name="transportProducer">The transport producer instance to use as the basis for service communication.</param>
        ///
        /// <remarks>
        ///   This constructor is intended to be used internally for functional
        ///   testing only.
        /// </remarks>
        ///
        internal ServiceBusSenderClient(
            ServiceBusConnection connection,
            TransportSender transportProducer)
        {
            Argument.AssertNotNull(connection, nameof(connection));
            Argument.AssertNotNull(transportProducer, nameof(transportProducer));

            OwnsConnection = false;
            Connection = connection;
            InnerSender = transportProducer;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusSenderClient"/> class.
        /// </summary>
        ///
        protected ServiceBusSenderClient()
        {
            OwnsConnection = false;
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
            await SendRangeAsync(new ServiceBusMessage[] { message }, cancellationToken).ConfigureAwait(false);
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
        public virtual async Task SendRangeAsync(IEnumerable<ServiceBusMessage> messages, CancellationToken cancellationToken = default) =>
            await SendRangeInternal(messages, cancellationToken).ConfigureAwait(false);

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
            return await Connection.ScheduleMessageAsync(message, RetryPolicy, GetSendLinkName(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancels a message that was scheduled.
        /// </summary>
        /// <param name="sequenceNumber">The <see cref="ServiceBusMessage.SystemPropertiesCollection.SequenceNumber"/> of the message to be cancelled.</param>
        /// <param name="cancellationToken"></param>
        public virtual async Task CancelScheduledMessageAsync(long sequenceNumber, CancellationToken cancellationToken = default)
        {
            //this.ThrowIfClosed();
            await Connection.CancelScheduledMessageAsync(sequenceNumber, RetryPolicy, GetSendLinkName(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the send link name if the send link is already open.
        /// </summary>
        /// <returns></returns>
        private string GetSendLinkName()
        {
            string sendLinkName = null;
            if (InnerSender.SendLink.TryGetOpenedObject(out SendingAmqpLink openedLink))
            {
                if (openedLink != null)
                {
                    sendLinkName = openedLink.Name;
                }
            }
            return sendLinkName;
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

        /// <seealso cref="SendRangeAsync(IEnumerable{ServiceBusMessage}, CancellationToken)" />
        ///
        internal virtual async Task SendRangeInternal(
            IEnumerable<ServiceBusMessage> messages,
            CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(messages, nameof(messages));

            using DiagnosticScope scope = CreateDiagnosticScope();
            messages = messages.ToList();
            InstrumentMessages(messages);

            try
            {
                await InnerSender.SendAsync(messages, cancellationToken).ConfigureAwait(false);
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
            ServiceBusEventSource.Log.ClientCloseStart(typeof(ServiceBusSenderClient), EntityName, identifier);

            // Attempt to close the active transport producers.  In the event that an exception is encountered,
            // it should not impact the attempt to close the connection, assuming ownership.

            var transportProducerException = default(Exception);

            try
            {
                await InnerSender.CloseAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseError(typeof(ServiceBusSenderClient), EntityName, identifier, ex.Message);
                transportProducerException = ex;
            }

            // An exception when closing the connection supersedes one observed when closing the
            // individual transport clients.

            try
            {
                if (OwnsConnection)
                {
                    await Connection.CloseAsync().ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                ServiceBusEventSource.Log.ClientCloseError(typeof(ServiceBusSenderClient), EntityName, identifier, ex.Message);
                throw;
            }
            finally
            {
                ServiceBusEventSource.Log.ClientCloseComplete(typeof(ServiceBusSenderClient), EntityName, identifier);
            }

            // If there was an active exception pending from closing the individual
            // transport producers, surface it now.

            if (transportProducerException != default)
            {
                throw transportProducerException;
            }
        }

        /// <summary>
        ///   Performs the task needed to clean up resources used by the <see cref="ServiceBusSenderClient" />,
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
            scope.AddAttribute(DiagnosticProperty.EndpointAttribute, Connection.ServiceEndpoint);
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
