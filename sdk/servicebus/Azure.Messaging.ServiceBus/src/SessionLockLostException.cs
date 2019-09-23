// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the lock on the Session has expired.  Callers should receive the Session again.
    /// </summary>
    public sealed class SessionLockLostException : ServiceBusException
    {
        public SessionLockLostException(string message)
            : this(message, null)
        {
        }

        public SessionLockLostException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}