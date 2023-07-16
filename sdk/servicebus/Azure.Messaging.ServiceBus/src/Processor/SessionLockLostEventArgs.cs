// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// This type represents the event args relating to the session lock lost event. This event is raised when the session lock is lost while
    /// processing a message. The event is raised when the session lock expiration time has passed, or if an exception is thrown while
    /// renewing the session lock.
    /// </summary>
    public class SessionLockLostEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs a new <see cref="SessionLockLostEventArgs"/> instance.
        /// </summary>
        /// <param name="exception">The exception, if any, which led to the event being raised.</param>
        public SessionLockLostEventArgs(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception, if any, which led to the event being raised.
        /// </summary>
        public Exception Exception { get; }
    }
}