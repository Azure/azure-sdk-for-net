// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the requested message is not found.
    /// </summary>
    public sealed class MessageNotFoundException : ServiceBusException
    {
        public MessageNotFoundException(string message)
            : this(message, null)
        {
        }

        public MessageNotFoundException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}