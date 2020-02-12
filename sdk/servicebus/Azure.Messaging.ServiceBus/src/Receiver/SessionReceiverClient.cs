// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Core;
using Microsoft.Azure.Amqp;
using Microsoft.Azure.Amqp.Framing;

namespace Azure.Messaging.ServiceBus.Receiver
{
    /// <summary>
    ///
    /// </summary>
    public class SessionReceiverClient : ServiceBusReceiverClient
    {
        /// <summary>
        /// Gets the time that the session identified by see cref="SessionId"/> is locked until for this client.
        /// </summary>
        public virtual DateTime LockedUntilUtc { get; }

        /// <summary>
        /// The session Id for the session that the receiver is scoped to.
        /// </summary>
        public virtual string SessionId { get; set; }

        /// <summary>
        /// Constructor for mocking.
        /// </summary>
        protected SessionReceiverClient() { }

        /// <summary>
        ///
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="sessionId"></param>
        /// <param name="clientOptions"></param>
        internal SessionReceiverClient(
            ServiceBusConnection connection,
            string sessionId = null,
            SessionReceiverClientOptions clientOptions = default)
            : base(connection, sessionId, clientOptions?.Clone() ?? new SessionReceiverClientOptions())
        {
            SessionId = sessionId;
        }
        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
        /// <param name="entityName"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired Service Bus entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ Service Bus entity NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Service Bus itself, then copying the connection string from that
        ///   Service Bus entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public SessionReceiverClient(
            string connectionString,
            string entityName)
            : base(connectionString, entityName, null, new SessionReceiverClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the entity name and the shared key properties are contained in this connection string.</param>
        /// <param name="entityName"></param>
        /// <param name="clientOptions"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired Service Bus entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ ENTITY NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Service Bus entity itself, then copying the connection string from that
        ///   Service Bus entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public SessionReceiverClient(
            string connectionString,
            string entityName,
            SessionReceiverClientOptions clientOptions)
            : base(connectionString, entityName, null, clientOptions?.Clone() ?? new SessionReceiverClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="sessionId"></param>
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
        /// <param name="entityName"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ entity name ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=orders-queue".
        ///
        ///   If you have defined a shared access policy directly on the entity itself, then copying the connection string from that
        ///   entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public SessionReceiverClient(
            string sessionId,
            string connectionString,
            string entityName)
            : base(connectionString, entityName, sessionId, new SessionReceiverClientOptions())
        {
            SessionId = sessionId;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="sessionId"></param>
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
        /// <param name="entityName"></param>
        /// <param name="clientOptions">The set of options to use for this consumer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus namespace, it will likely not contain the name of the desired Service Bus entity,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ Service Bus entity NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Service Bus entity itself, then copying the connection string from that
        ///   Service Bus entity will result in a connection string that contains the name.
        /// </remarks>
        ///
        public SessionReceiverClient(
            string sessionId,
            string connectionString,
            string entityName,
            SessionReceiverClientOptions clientOptions)
            : base(connectionString, entityName, sessionId, clientOptions?.Clone() ?? new SessionReceiverClientOptions())
        {
            SessionId = sessionId;
        }


        /// <summary>
        ///   Initializes a new instance of the <see cref="SessionReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="sessionId"></param>
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of the specific entity to associate the receiver with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public SessionReceiverClient(
            string sessionId,
            string fullyQualifiedNamespace,
            string entityName,
            TokenCredential credential,
            SessionReceiverClientOptions clientOptions = default)
            : base(fullyQualifiedNamespace, entityName, credential, sessionId, clientOptions?.Clone() ?? new SessionReceiverClientOptions())
        {
            SessionId = sessionId;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="SessionReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of the specific entity to associate the receiver with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public SessionReceiverClient(
            string fullyQualifiedNamespace,
            string entityName,
            TokenCredential credential,
            SessionReceiverClientOptions clientOptions = default)
            : base(fullyQualifiedNamespace, entityName, credential, null, clientOptions?.Clone() ?? new SessionReceiverClientOptions())
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<ServiceBusMessage> PeekAsync(CancellationToken cancellationToken = default)
        {
            IAsyncEnumerator<ServiceBusMessage> result = PeekRangeBySequenceInternal(fromSequenceNumber: null).GetAsyncEnumerator();
            await result.MoveNextAsync().ConfigureAwait(false);
            return result.Current;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<ServiceBusMessage> PeekBySequenceAsync(
            long fromSequenceNumber,
            CancellationToken cancellationToken = default)
        {
            IAsyncEnumerator<ServiceBusMessage> result = PeekRangeBySequenceAsync(fromSequenceNumber: fromSequenceNumber).GetAsyncEnumerator();
            await result.MoveNextAsync().ConfigureAwait(false);
            return result.Current;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async IAsyncEnumerable<ServiceBusMessage> PeekRangeAsync(
            int maxMessages,
            [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
        {
            IAsyncEnumerable<ServiceBusMessage> ret = PeekRangeBySequenceInternal(fromSequenceNumber: null, maxMessages);
            await foreach (ServiceBusMessage msg in ret.ConfigureAwait(false))
            {
                yield return msg;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async IAsyncEnumerable<ServiceBusMessage> PeekRangeBySequenceAsync(
            long fromSequenceNumber,
            int maxMessages = 1,
            [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
        {

            IAsyncEnumerable<ServiceBusMessage> ret = PeekRangeBySequenceInternal(
                fromSequenceNumber: fromSequenceNumber,
                maxMessages: maxMessages,
                cancellationToken: cancellationToken);
            await foreach (ServiceBusMessage msg in ret.ConfigureAwait(false))
            {
                yield return msg;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fromSequenceNumber"></param>
        /// <param name="maxMessages"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal async IAsyncEnumerable<ServiceBusMessage> PeekRangeBySequenceInternal(
            long? fromSequenceNumber,
            int maxMessages = 1,
            [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
        {

            RetriableContext context = CreateRetriableContext(cancellationToken);
            ReceivingAmqpLink openedLink =
                await context.RunOperation(
                    async () => await Consumer.ReceiveLink.GetOrCreateAsync(context.TimeSpan)
                    .ConfigureAwait(false))
                .ConfigureAwait(false);

            var source = (Source)openedLink.Settings.Source;
            if (source.FilterSet.TryGetValue<string>(AmqpClientConstants.SessionFilterName, out var tempSessionId))
            {
                // If one of the constructors not accepting a SessionId was used, the broker will determine which session to send messages from.
                SessionId = tempSessionId;
            }
            IAsyncEnumerable<ServiceBusMessage> ret = PeekRangeBySequenceInternal(
                fromSequenceNumber: fromSequenceNumber,
                maxMessages: maxMessages,
                sessionId: SessionId,
                cancellationToken: cancellationToken);
            await foreach (ServiceBusMessage msg in ret.ConfigureAwait(false))
            {
                yield return msg;
            }
        }

        /// <summary>
        /// TODO implement
        /// </summary>
        /// <returns></returns>
        public virtual async Task<byte[]> GetStateAsync(
            CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new byte[4]).ConfigureAwait(false);
        }

        /// <summary>
        /// TODO implement
        /// </summary>
        /// <param name="sessionState"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task SetStateAsync(byte[] sessionState,
            CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);
        }

        /// <summary>
        /// TODO implement
        /// </summary>
        /// <returns></returns>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);
        }
    }
}
