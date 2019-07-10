// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Errors
{
    /// <summary>
    ///   An exception which occurs when an Event Hubs resource, such as an Event Hub, consumer group, or
    ///   partition cannot be found.
    /// </summary>
    ///
    public sealed class EventHubsResourceNotFoundException : EventHubsException
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsResourceNotFoundException"/> class.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource that could not be found.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        ///
        internal EventHubsResourceNotFoundException(string resourceName,
                                                    string message) : this(resourceName, message, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsResourceNotFoundException"/> class.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource that could not be found.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        internal EventHubsResourceNotFoundException(string resourceName,
                                                    string message,
                                                    Exception innerException) : base(false, resourceName, message, innerException)
        {
        }
    }
}
