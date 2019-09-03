// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;

    /// <summary>
    /// Base Exception for various Event Hubs errors.
    /// </summary>
    public class EventHubsException : Exception
    {
        /// <summary>
        ///Enumerates the types of error sources for the messaging communication.
        /// </summary>
        public enum ErrorSourceType
        {
            /// <summary>
            /// Identifies the exception as a server error and service needs to take an action to address the failure.
            /// </summary>
            ServerError,

            /// <summary>
            /// Identifies the exception as a user error and user needs to take an action to address the failure.
            /// </summary>
            UserError,
        }

        /// <summary>
        /// Returns a new EventHubsException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        public EventHubsException(bool isTransient)
        {
            this.IsTransient = isTransient;
        }

        /// <summary>
        /// Returns a new EventHubsException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        /// <param name="message">The detailed message exception.</param>
        public EventHubsException(bool isTransient, string message)
            : base(message)
        {
            this.IsTransient = isTransient;
        }

        /// <summary>
        /// Returns a new EventHubsException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        /// <param name="innerException">The inner exception.</param>
        public EventHubsException(bool isTransient, Exception innerException)
            : base(innerException.Message, innerException)
        {
            this.IsTransient = isTransient;
        }

        /// <summary>
        /// Returns a new EventHubsException
        /// </summary>
        /// <param name="isTransient">Specifies whether or not the exception is transient.</param>
        /// <param name="message">The detailed message exception.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="errorSource">Error source of exception.</param>
        public EventHubsException(bool isTransient, string message, Exception innerException, ErrorSourceType errorSource)
            : base(message, innerException)
        {
            this.IsTransient = isTransient;
            this.ErrorSource = errorSource;
        }

        /// <summary>
        /// Gets the message as a formatted string.
        /// </summary>
        public override string Message
        {
            get
            {
                string baseMessage = base.Message;
                if (string.IsNullOrEmpty(this.EventHubsNamespace))
                {
                    return baseMessage;
                }

                return "{0}, ({1})".FormatInvariant(this.EventHubsNamespace);
            }
        }

        /// <summary>
        /// A boolean indicating if the exception is a transient error or not.
        /// </summary>
        /// <value>returns true when user can retry the operation that generated the exception without additional intervention.</value>
        public bool IsTransient { get; }

        /// <summary>
        /// Gets the Event Hubs namespace from which the exception occured, if available.
        /// </summary>
        public string EventHubsNamespace { get; internal set; }

        /// <summary>
        /// Gets the error source.
        /// </summary>
        public ErrorSourceType ErrorSource { get; private set; }
    }
}
