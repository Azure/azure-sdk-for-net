// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus.Core
{
    /// <summary>
    ///   The set of properties that comprise a connection string from the
    ///   Azure portal.
    /// </summary>
    ///
    internal struct ConnectionStringProperties
    {
        /// <summary>
        ///   The endpoint to be used for connecting to the Service Bus namespace.
        /// </summary>
        ///
        /// <value>The endpoint address, including protocol, from the connection string.</value>
        ///
        public Uri Endpoint { get; }

        /// <summary>
        ///   The name of the specific Service Bus entity instance under the associated Service Bus namespace.
        /// </summary>
        ///
        public string EntityPath { get; }

        /// <summary>
        ///   The name of the shared access key, either for the Service Bus namespace
        ///   or the Service Bus entity.
        /// </summary>
        ///
        public string SharedAccessKeyName { get; }

        /// <summary>
        ///   The value of the shared access key, either for the Service Bus namespace
        ///   or the Service Bus entity.
        /// </summary>
        ///
        public string SharedAccessKey { get; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ConnectionStringProperties"/> structure.
        /// </summary>
        ///
        /// <param name="endpoint">The endpoint of the Service Bus namespace.</param>
        /// <param name="entityName">The name of the specific Service Bus entity under the namespace.</param>
        /// <param name="sharedAccessKeyName">The name of the shared access key, to use authorization.</param>
        /// <param name="sharedAccessKey">The shared access key to use for authorization.</param>
        ///
        public ConnectionStringProperties(
            Uri endpoint,
            string entityName,
            string sharedAccessKeyName,
            string sharedAccessKey)
        {
            Endpoint = endpoint;
            EntityPath = entityName;
            SharedAccessKeyName = sharedAccessKeyName;
            SharedAccessKey = sharedAccessKey;
        }
    }
}
