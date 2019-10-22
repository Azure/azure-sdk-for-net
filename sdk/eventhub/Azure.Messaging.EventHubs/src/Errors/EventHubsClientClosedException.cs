// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Errors
{
    /// <summary>
    ///   An exception which occurs when an operation has been attempted using an Event Hubs
    ///   client instance which has already been closed.
    /// </summary>
    ///
    public sealed class EventHubsClientClosedException : EventHubsException
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsClientClosedException"/> class.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        ///
        internal EventHubsClientClosedException(string resourceName,
                                                string message) : this(resourceName, message, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsClientClosedException"/> class.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        internal EventHubsClientClosedException(string resourceName,
                                                string message,
                                                Exception innerException) : base(false, resourceName, message, innerException)
        {
        }
    }
}
