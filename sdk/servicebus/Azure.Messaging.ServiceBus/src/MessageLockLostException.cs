// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the lock on the message is lost.  Callers should call Receive and process the message again.
    /// </summary>
    public sealed class MessageLockLostException : ServiceBusException
    {
        public MessageLockLostException(string message)
            : this(message, null)
        {
        }

        public MessageLockLostException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}