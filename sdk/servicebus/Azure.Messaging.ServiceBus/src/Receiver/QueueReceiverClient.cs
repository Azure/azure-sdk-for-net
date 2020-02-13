// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Messaging.ServiceBus.Core;

namespace Azure.Messaging.ServiceBus.Receiver
{
    /// <summary>
    ///
    /// </summary>
    public class QueueReceiverClient : ServiceBusReceiverClient
    {
        /// <summary>
        ///
        /// </summary>
        public string QueueName => EntityName;
        /// <summary>
        ///
        /// </summary>
        protected QueueReceiverClient(){}
        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
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
        public QueueReceiverClient(string connectionString)
            : base(connectionString, null, null, new QueueReceiverClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the Service Bus entity name and the shared key properties are contained in this connection string.</param>
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
        public QueueReceiverClient(
            string connectionString,
            QueueReceiverClientOptions clientOptions)
            : base(connectionString, null, null, clientOptions?.Clone() ?? new QueueReceiverClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="connectionString">The connection string to use for connecting to the Service Bus namespace; it is expected that the shared key properties are contained in this connection string, but not the Service Bus entity name.</param>
        /// <param name="queueName">The name of the specific Service Bus entity to associate the consumer with.</param>
        /// <param name="clientOptions"></param>
        ///
        /// <remarks>
        ///   If the connection string is copied from the Service Bus entity itself, it will contain the name of the desired Service Bus entity,
        ///   and can be used directly without passing the <paramref name="queueName" />.  The name of the Service Bus entity should be
        ///   passed only once, either as part of the connection string or separately.
        /// </remarks>
        ///
        public QueueReceiverClient(
            string connectionString,
            string queueName,
            QueueReceiverClientOptions clientOptions = default)
            : base(connectionString, queueName, null, clientOptions?.Clone() ?? new QueueReceiverClientOptions())
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusReceiverClient"/> class.
        /// </summary>
        ///
        /// <param name="fullyQualifiedNamespace">The fully qualified Service Bus namespace to connect to.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
        /// <param name="queueName">The name of the specific Service Bus entity to associate the consumer with.</param>
        /// <param name="credential">The Azure managed identity credential to use for authorization.  Access controls may be specified by the Service Bus namespace or the requested Service Bus entity, depending on Azure configuration.</param>
        /// <param name="clientOptions">A set of options to apply when configuring the consumer.</param>
        ///
        public QueueReceiverClient(
            string fullyQualifiedNamespace,
            string queueName,
            TokenCredential credential,
            QueueReceiverClientOptions clientOptions = default)
            :base(fullyQualifiedNamespace, queueName, credential, null, clientOptions?.Clone() ?? new QueueReceiverClientOptions())
        {
        }
    }
}
