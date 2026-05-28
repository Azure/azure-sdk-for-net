// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// This type represents the event args relating to the message lock lost event.
    /// </summary>
    public class MessageLockLostEventArgs
    {
        /// <summary>
        /// Constructs a new <see cref="MessageLockLostEventArgs"/> instance.
        /// </summary>
        /// <param name="message">The message that the lock was lost for.</param>
        /// <param name="exception">The exception, if any, which led to the event being raised.</param>
        public MessageLockLostEventArgs(ServiceBusReceivedMessage message, Exception exception)
        {
            Message = message;
            Exception = exception;
        }

        /// <summary>
        /// The message that the lock was lost for.
        /// </summary>
        public ServiceBusReceivedMessage Message { get; }

        /// <summary>
        /// Gets the exception, if any, which led to the event being raised. If the exception is null,
        /// then the event was raised due to the message lock expiring based on the
        /// <see cref="ServiceBusReceivedMessage.LockedUntil"/> property.
        /// </summary>
        public Exception Exception { get; }
    }
}