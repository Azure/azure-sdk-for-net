// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// This type represents the event args relating to the session lock lost event.
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
        /// Gets the exception, if any, which led to the event being raised. If the exception is null,
        /// then the event was raised due to the session lock expiring based on the
        /// <see cref="ProcessSessionMessageEventArgs.SessionLockedUntil"/> property.
        /// </summary>
        public Exception Exception { get; }
    }
}