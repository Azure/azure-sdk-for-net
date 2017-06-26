// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Primitives
{
    using System;

    /// <summary>Context provided for <see cref="ExceptionReceivedEventArgs"/> exception raised by the client.</summary>
    public class ExceptionReceivedContext
    {
        /// <summary>Initializes a new instance of the <see cref="ExceptionReceivedContext" /> class.</summary>
        /// <param name="action">The action associated with the exception.</param>
        /// <param name="endpoint">The endpoint associated with the exception.</param>
        /// <param name="entityPath">The entity path associated with the exception.</param>
        public ExceptionReceivedContext(string action, string endpoint, string entityPath)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action));
            Endpoint = endpoint ?? throw new ArgumentNullException(nameof(endpoint));
            EntityPath = entityPath ?? throw new ArgumentNullException(nameof(entityPath));
        }

        /// <summary>Gets the action associated with the event.</summary>
        /// <value>The action associated with the event.</value>
        public string Action { get; private set; }

        /// <summary>The namespace name used when this exception occured.</summary>
        public string Endpoint { get; private set; }

        /// <summary>The entity path used when this exception occured.</summary>
        public string EntityPath { get; private set; }
    }
}