// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///
    /// </summary>
    public class SessionLockLostEventArgs : EventArgs
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="exception"></param>
        public SessionLockLostEventArgs(Exception exception)
        {
            Exception = exception;
        }

        /// <summary>
        ///
        /// </summary>
        public Exception Exception { get; }
    }
}