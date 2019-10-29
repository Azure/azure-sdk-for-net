// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when a session cannot be locked.
    /// </summary>
    public sealed class SessionCannotBeLockedException : ServiceBusException
    {
        public SessionCannotBeLockedException(string message)
            : this(message, null)
        {
        }

        public SessionCannotBeLockedException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}