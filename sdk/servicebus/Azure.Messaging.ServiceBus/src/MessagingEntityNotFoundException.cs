// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the Messaging Entity is not found.  Verify Entity Exists.
    /// </summary>
    public sealed class MessagingEntityNotFoundException : ServiceBusException
    {
        public MessagingEntityNotFoundException(string message)
            : this(message, null)
        {
        }

        public MessagingEntityNotFoundException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}