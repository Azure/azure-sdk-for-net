// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace TrackOne
{
    /// <summary>
    ///     The exception that is thrown when a time out is encountered.  Callers retry the operation.
    /// </summary>
    internal class EventHubsTimeoutException : EventHubsException
    {
        internal EventHubsTimeoutException(string message) : this(message, null)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        internal EventHubsTimeoutException(string message, Exception innerException)
            : base(true, message, innerException)
        {
        }
    }
}
