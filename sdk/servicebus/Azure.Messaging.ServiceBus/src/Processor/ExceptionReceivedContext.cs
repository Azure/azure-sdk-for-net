// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>Context provided for <see cref="ProcessErrorEventArgs"/> exception raised by the client.</summary>
    internal class ExceptionReceivedContext
    {
        /// <summary>Initializes a new instance of the <see cref="ExceptionReceivedContext" /> class.</summary>
        /// <param name="action">The action associated with the exception.</param>
        /// <param name="endpoint">The endpoint associated with the exception.</param>
        /// <param name="entityPath">The entity path associated with the exception.</param>
        /// <param name="clientId">The Client Id can be used to associate with thecref="QueueClient"/>,  cref="SubscriptionClient"/>,  cref="MessageSender"/> or  cref="MessageReceiver"/> that encountered the exception.</param>
        public ExceptionReceivedContext(string action, string endpoint, string entityPath, string clientId)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            EntityPath = entityPath ?? throw new ArgumentNullException(nameof(entityPath));
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
        }

        /// <summary>Gets the action associated with the event.</summary>
        /// <value>The action associated with the event.</value>
        public string Action { get; }

        /// <summary>The namespace name used when this exception occurred.</summary>
        public string Endpoint { get; }

        /// <summary>The entity path used when this exception occurred.</summary>
        public string EntityPath { get; }

        /// <summary>The Client Id associated with the sender, receiver or session when this exception occurred.</summary>
        public string ClientId { get; }
    }
}
