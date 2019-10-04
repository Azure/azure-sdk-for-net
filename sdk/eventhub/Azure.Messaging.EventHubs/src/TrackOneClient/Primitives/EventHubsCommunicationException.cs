// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace TrackOne
{
    /// <summary>
    /// Exception for signaling general communication errors related to messaging operations.
    /// </summary>
    internal class EventHubsCommunicationException : EventHubsException
    {
        /// <summary></summary>
        /// <param name="message"></param>
        protected internal EventHubsCommunicationException(string message)
            : this(message, null)
        {
        }

        /// <summary></summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected internal EventHubsCommunicationException(string message, Exception innerException)
            : base(true, message, innerException)
        {
        }
    }
}
