// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the lock on the message is lost.  Callers should call Receive and process the message again.
    /// </summary>
    public sealed class MessageLockLostException : ServiceBusException
    {
        internal MessageLockLostException(string message)
            : this(message, null)
        {
        }

        internal MessageLockLostException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}