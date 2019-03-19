// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Azure.ServiceBus.Core;

namespace Microsoft.Azure.ServiceBus
{
    using System;

    /// <summary>Context provided for <see cref="ExceptionReceivedEventArgs"/> exception raised by the client.</summary>
    public class ExceptionReceivedContext
    {
        /// <summary>Initializes a new instance of the <see cref="ExceptionReceivedContext" /> class.</summary>
        /// <param name="action">The action associated with the exception.</param>
        /// <param name="endpoint">The endpoint associated with the exception.</param>
        /// <param name="entityPath">The entity path associated with the exception.</param>
        /// <param name="clientId">The Client Id can be used to associate with the <see cref="QueueClient"/>, <see cref="SubscriptionClient"/>, <see cref="MessageSender"/> or <see cref="MessageReceiver"/> that encountered the exception.</param>
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