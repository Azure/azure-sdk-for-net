// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the lock on the Session has expired.  Callers should receive the Session again.
    /// </summary>
    public sealed class SessionLockLostException : ServiceBusException
    {
        internal SessionLockLostException(string message)
            : this(message, null)
        {
        }

        internal SessionLockLostException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}