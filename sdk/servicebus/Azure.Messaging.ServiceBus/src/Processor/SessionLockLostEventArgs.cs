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
        /// <param name="message">The message that was being processed when the session lock was lost.</param>
        /// <param name="sessionLockedUntil">The time that the session lock expires.</param>
        /// <param name="exception">The exception, if any, which led to the event being raised.</param>
        public SessionLockLostEventArgs(ServiceBusReceivedMessage message, DateTimeOffset sessionLockedUntil, Exception exception)
        {
            Message = message;
            SessionLockedUntil = sessionLockedUntil;
            Exception = exception;
        }

        /// <summary>
        /// The time that the session lock expires. If this time is still in the future, then the session lock was lost due to an
        /// exception being thrown which can be accessed via the <see cref="Exception"/> property.
        /// </summary>
        public DateTimeOffset SessionLockedUntil { get; }

        /// <summary>
        /// The message that was being processed when the session lock was lost.
        /// </summary>
        public ServiceBusReceivedMessage Message { get; }

        /// <summary>
        /// Gets the exception, if any, which led to the event being raised. If the exception is null,
        /// then the event was raised due to the session lock expiring based on the
        /// <see cref="ProcessSessionMessageEventArgs.SessionLockedUntil"/> property.
        /// </summary>
        public Exception Exception { get; }
    }
}