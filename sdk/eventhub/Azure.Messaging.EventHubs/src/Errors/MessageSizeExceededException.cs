// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Messaging.EventHubs.Errors
{
    /// <summary>
    ///   An exception which occurs when a message is larger than the maximum size allowed
    ///   for its transport.
    /// </summary>
    ///
    public sealed class MessageSizeExceededException : EventHubsException
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="MessageSizeExceededException"/> class.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        ///
        internal MessageSizeExceededException(string resourceName,
                                              string message) : this(resourceName, message, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="MessageSizeExceededException"/> class.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        internal MessageSizeExceededException(string resourceName,
                                              string message,
                                              Exception innerException) : base(false, resourceName, message, innerException)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="MessageSizeExceededException"/> class using
        ///   the default messaging.
        /// </summary>
        ///
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="messageId">The identifier of the message that triggered the exception.</param>
        /// <param name="sizeInBytes">The size, in bytes, of the message.</param>
        /// <param name="maximumSizeInBytes">The maximum allowed size of messages, in bytes, allowed by the transport.</param>
        ///
        internal MessageSizeExceededException(string resourceName,
                                              uint messageId,
                                              ulong sizeInBytes,
                                              ulong maximumSizeInBytes) : this(resourceName, FormatDefaultMessage(messageId, sizeInBytes, maximumSizeInBytes))
        {
        }

        /// <summary>
        ///   Formats the default exception message.
        /// </summary>
        ///
        /// <param name="messageId">The identifier of the message that triggered the exception.</param>
        /// <param name="sizeInBytes">The size, in bytes, of the message.</param>
        /// <param name="maximumSizeInBytes">The maximum allowed size of messages, in bytes, allowed by the transport.</param>
        ///
        /// <returns>The formatted message with details for the requested message attributes.</returns>
        ///
        private static string FormatDefaultMessage(uint messageId,
                                                   ulong sizeInBytes,
                                                   ulong maximumSizeInBytes) =>
            string.Format(CultureInfo.CurrentCulture, Resources.MessageSizeExceeded, messageId, sizeInBytes, maximumSizeInBytes);
    }
}
