// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// This type represents the event args relating to the message lock lost event. This event is raised when the message lock is lost while
    /// processing the message. The event is raised when the message lock expiration time has passed, or if an exception is thrown while
    /// renewing the message lock.
    /// </summary>
    public class MessageLockLostEventArgs
    {
        /// <summary>
        /// Constructs a new <see cref="MessageLockLostEventArgs"/> instance.
        /// </summary>
        /// <param name="exception">The exception, if any, which led to the event being raised.</param>
        public MessageLockLostEventArgs(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception, if any, which led to the event being raised.
        /// </summary>
        public Exception Exception { get; }
    }
}