// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;

    /// <summary>
    ///     The exception that is thrown when a time out is encountered.  Callers retry the operation.
    /// </summary>
    public class EventHubsTimeoutException : EventHubsException
    {
        internal EventHubsTimeoutException(string message) : this(message, null)
        {
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        internal EventHubsTimeoutException(string message, Exception innerException)
            : base(true, message, innerException)
        {
        }
    }
}
