// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Messaging.EventHubs.Errors
{
    /// <summary>
    ///     Serves as a basis for exceptions produced within the Event Hubs
    ///     context.
    /// </summary>
    ///
    /// <seealso cref="System.Exception" />
    ///
    public class EventHubsException : Exception
    {
        /// <summary>
        ///   Indicates whether an exception should be considered transient or final.
        /// </summary>
        ///
        /// <value><c>true</c> if the exception is likely transient; otherwise, <c>false</c>.</value>
        ///
        public bool IsTransient { get; }

        /// <summary>
        ///   The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition,
        ///   to which the exception is associated.
        /// </summary>
        ///
        /// <value>The name of the resource, if available; otherwise, <c>null</c>.</value>
        ///
        public string ResourceName { get; }

        /// <summary>
        ///   Gets a message that describes the current exception.
        /// </summary>
        ///
        public override string Message
        {
            get
            {
                if (string.IsNullOrEmpty(ResourceName))
                {
                    return base.Message;
                }

                return string.Format(CultureInfo.InvariantCulture, "{0} ({1})", base.Message, ResourceName);
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class.
        /// </summary>
        ///
        /// <param name="isTransient"><c>true</c> if the exception should be considered transient; otherwise, <c>false</c>.</param>
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        ///
        internal EventHubsException(bool isTransient,
                                    string resourceName) : this(isTransient, resourceName, null, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class.
        /// </summary>
        ///
        /// <param name="isTransient"><c>true</c> if the exception should be considered transient; otherwise, <c>false</c>.</param>
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        ///
        internal EventHubsException(bool isTransient,
                                    string resourceName,
                                    string message) : this(isTransient, resourceName, message, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class.
        /// </summary>
        ///
        /// <param name="isTransient"><c>true</c> if the exception should be considered transient; otherwise, <c>false</c>.</param>
        /// <param name="resourceName">The name of the Event Hubs resource, such as an Event Hub, consumer group, or partition, to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        internal EventHubsException(bool isTransient,
                                    string resourceName,
                                    string message,
                                    Exception innerException) : base(message, innerException)
        {
            IsTransient = isTransient;
            ResourceName = resourceName;
        }
    }
}
