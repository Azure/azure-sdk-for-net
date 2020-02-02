// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Receiver
{
    /// <summary>
    ///
    /// </summary>
    public class SessionReceiverClient : ServiceBusReceiverClient
    {
        /// <summary>
        ///
        /// </summary>
        public string SessionId { get; private set; }

        /// <summary>
        /// Gets the time that the session identified by <see cref="SessionId"/> is locked until for this client.
        /// </summary>
        public DateTime LockedUntilUtc { get; }
        /// <summary>
        ///
        /// </summary>
        protected SessionReceiverClient() { }
        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="sessionId"></param>
        /// <param name="receiveMode"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        public SessionReceiverClient(string connectionString, string sessionId, ReceiveMode receiveMode)
            : base(connectionString, receiveMode, default(SessionReceiverClientOptions))
        {
            SessionId = SessionId;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the Event Hub name and the shared key properties are contained in this connection string.</param>
        /// <param name="sessionId"></param>
        /// <param name="receiveMode"></param>
        /// <param name="clientOptions">The set of options to use for this consumer.</param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hubs namespace, it will likely not contain the name of the desired Event Hub,
        ///   which is needed.  In this case, the name can be added manually by adding ";EntityPath=[[ EVENT HUB NAME ]]" to the end of the
        ///   connection string.  For example, ";EntityPath=telemetry-hub".
        ///
        ///   If you have defined a shared access policy directly on the Event Hub itself, then copying the connection string from that
        ///   Event Hub will result in a connection string that contains the name.
        /// </remarks>
        ///
        public SessionReceiverClient(string connectionString,
            string sessionId,
            ReceiveMode receiveMode,
                                      SessionReceiverClientOptions clientOptions)
            : base(connectionString, receiveMode, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Event Hubs namespace; it is expected that the shared key properties are contained in this connection string, but not the Event Hub name.</param>
        /// <param name="entityName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="sessionId"></param>
        /// <param name="receiveMode"></param>
        /// <param name="clientOptions"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Event Hub itself, it will contain the name of the desired Event Hub,
        ///   and can be used directly without passing the <paramref name="entityName" />.  The name of the Event Hub should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public SessionReceiverClient(string connectionString, string entityName,
            string sessionId,
            ReceiveMode receiveMode = ReceiveMode.PeekLock, SessionReceiverClientOptions clientOptions = default)
            : base(connectionString, entityName, receiveMode, clientOptions)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="entityName">The name of the specific Event Hub to associate the consumer with.</param>
        /// <param name="sessionId"></param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Event Hubs namespace or the requested Event Hub, depending on Azure configuration.</param>
        /// <param name="receiveMode"></param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public SessionReceiverClient(
                                      string fullyQualifiedNamespace,
                                      string entityName,
                                      string sessionId,
                                      TokenCredential credential,
                                      ReceiveMode receiveMode = ReceiveMode.PeekLock,
                                      SessionReceiverClientOptions clientOptions = default)
            : base(fullyQualifiedNamespace, entityName, credential, receiveMode)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public virtual async Task<byte[]> GetStateAsync(
            CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(new byte[4]).ConfigureAwait(false);
        }

        /// <summary>
        ///
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
        ///
        /// </summary>
        /// <returns></returns>
        public virtual async Task RenewSessionLockAsync(CancellationToken cancellationToken = default)
        {
            await Task.Delay(1).ConfigureAwait(false);
        }
    }
}
