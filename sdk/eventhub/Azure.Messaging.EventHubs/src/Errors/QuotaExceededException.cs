﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.EventHubs.Errors
{
    /// <summary>
    ///   An exception which occurs when the quota applied to an Event Hubs resource has been
    ///   exceeded while interacting with the Azure Event Hubs service.
    /// </summary>
    ///
    public sealed class QuotaExceededException : EventHubsException
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="QuotaExceededException"/> class.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        ///
        public QuotaExceededException(string resourceName,
                                      string message) : this(resourceName, message, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="QuotaExceededException"/> class.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        public QuotaExceededException(string resourceName,
                                      string message,
                                      Exception innerException) : base(false, resourceName, message, innerException)
        {
        }
    }
}
