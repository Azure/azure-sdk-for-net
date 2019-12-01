﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Errors
{
    /// <summary>
    ///   An exception which occurs when there is a general communications error encountered
    ///   when interacting with the Azure Event Hubs service.
    /// </summary>
    ///
    public sealed class EventHubsCommunicationException : EventHubsException
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsCommunicationException"/> class.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        ///
        public EventHubsCommunicationException(string resourceName,
                                               string message) : this(resourceName, message, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsCommunicationException"/> class.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        public EventHubsCommunicationException(string resourceName,
                                               string message,
                                               Exception innerException) : base(true, resourceName, message, innerException)
        {
        }
    }
}
