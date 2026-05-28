// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   Serves as a basis for exceptions produced within the Event Hubs
    ///   context.
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
        ///   The reason for the failure of an Event Hubs operation that resulted
        ///   in the exception.
        /// </summary>
        ///
        public FailureReason Reason { get; }

        /// <summary>
        ///   The name of the Event Hubs to which the exception is associated.
        /// </summary>
        ///
        /// <value>The name of the Event Hub, if available; otherwise, <c>null</c>.</value>
        ///
        public string EventHubName { get; }

        /// <summary>
        ///   Gets a message that describes the current exception.
        /// </summary>
        ///
        public override string Message
        {
            get
            {
                if (string.IsNullOrEmpty(EventHubName))
                {
                    return string.Format(CultureInfo.InvariantCulture, "{0}.  {1}", base.Message, Resources.TroubleshootingGuideLink);
                }

                return string.Format(CultureInfo.InvariantCulture, "{0} ({1}).  {2}", base.Message, EventHubName, Resources.TroubleshootingGuideLink);
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class.
        /// </summary>
        ///
        /// <param name="isTransient"><c>true</c> if the exception should be considered transient; otherwise, <c>false</c>.</param>
        /// <param name="eventHubName">The name of the Event Hub to which the exception is associated.</param>
        ///
        public EventHubsException(bool isTransient,
                                  string eventHubName) : this(isTransient, eventHubName, null, FailureReason.GeneralError, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class.
        /// </summary>
        ///
        /// <param name="isTransient"><c>true</c> if the exception should be considered transient; otherwise, <c>false</c>.</param>
        /// <param name="eventHubName">The name of the Event Hub to which the exception is associated.</param>
        /// <param name="reason">The reason for the failure that resulted in the exception.</param>
        ///
        public EventHubsException(bool isTransient,
                                  string eventHubName,
                                  FailureReason reason) : this(isTransient, eventHubName, null, reason, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class.
        /// </summary>
        ///
        /// <param name="isTransient"><c>true</c> if the exception should be considered transient; otherwise, <c>false</c>.</param>
        /// <param name="eventHubName">The name of the Event Hub to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        ///
        public EventHubsException(bool isTransient,
                                  string eventHubName,
                                  string message) : this(isTransient, eventHubName, message, FailureReason.GeneralError, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class.
        /// </summary>
        ///
        /// <param name="isTransient"><c>true</c> if the exception should be considered transient; otherwise, <c>false</c>.</param>
        /// <param name="eventHubName">The name of the Event Hub to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="reason">The reason for the failure that resulted in the exception.</param>
        ///
        public EventHubsException(bool isTransient,
                                  string eventHubName,
                                  string message,
                                  FailureReason reason) : this(isTransient, eventHubName, message, reason, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class.
        /// </summary>
        ///
        /// <param name="isTransient"><c>true</c> if the exception should be considered transient; otherwise, <c>false</c>.</param>
        /// <param name="eventHubName">The name of the Event Hub to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        public EventHubsException(bool isTransient,
                                  string eventHubName,
                                  string message,
                                  Exception innerException) : this(isTransient, eventHubName, message, FailureReason.GeneralError, innerException)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class.
        /// </summary>
        ///
        /// <param name="isTransient"><c>true</c> if the exception should be considered transient; otherwise, <c>false</c>.</param>
        /// <param name="eventHubName">The name of the Event Hub to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="reason">The reason for the failure that resulted in the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        public EventHubsException(bool isTransient,
                                  string eventHubName,
                                  string message,
                                  FailureReason reason,
                                  Exception innerException) : base(message, innerException)
        {
            IsTransient = isTransient;
            EventHubName = eventHubName;
            Reason = reason;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class, using the <paramref name="reason"/>
        ///   to detect whether or not it should be transient.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="reason">The reason for the failure that resulted in the exception.</param>
        ///
        public EventHubsException(string eventHubName,
                                  string message,
                                  FailureReason reason) : this(eventHubName, message, reason, null)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventHubsException"/> class, using the <paramref name="reason"/>
        ///   to detect whether or not it should be transient.
        /// </summary>
        ///
        /// <param name="eventHubName">The name of the Event Hub to which the exception is associated.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="reason">The reason for the failure that resulted in the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        internal EventHubsException(string eventHubName,
                                    string message,
                                    FailureReason reason,
                                    Exception innerException) : this(false, eventHubName, message, reason, innerException)
        {
            switch (reason)
            {
                case FailureReason.ServiceCommunicationProblem:
                case FailureReason.ServiceTimeout:
                case FailureReason.ServiceBusy:
                    IsTransient = true;
                    break;

                default:
                    IsTransient = false;
                    break;
            }
        }

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        public override string ToString() =>
            $"{ typeof(EventHubsException).FullName }({ Reason }): { Message }{ Environment.NewLine }{ StackTrace }{ FormatInnerException() }";

        /// <summary>
        ///   Formats the <see cref="Exception.InnerException"/> for inclusion in the <see cref="ToString" />
        ///   details.
        /// </summary>
        ///
        /// <returns>The text to include for the inner exception, if any.</returns>
        ///
        private string FormatInnerException() =>
            (InnerException == null) ? string.Empty : $"{ Environment.NewLine }{ InnerException }";

        /// <summary>
        ///   The set of well-known reasons for an Event Hubs operation failure that
        ///   was the cause of an exception.
        /// </summary>
        ///
        public enum FailureReason
        {
            /// <summary>The exception was the result of a general error within the client library.</summary>
            GeneralError,

            /// <summary>An operation has been attempted using an Event Hubs client instance which has already been closed.</summary>
            ClientClosed,

            /// <summary>A client was forcefully disconnected from an Event Hub instance.  This typically occurs when another consumer with higher <see cref="ReadEventOptions.OwnerLevel" /> asserts ownership over the partition and consumer group.</summary>
            ConsumerDisconnected,

            /// <summary>An Event Hubs resource, such as an Event Hub, consumer group, or partition cannot be found by the Event Hubs service.</summary>
            ResourceNotFound,

            /// <summary>A message is larger than the maximum size allowed for its transport.</summary>
            MessageSizeExceeded,

            /// <summary>The quota applied to an Event Hubs resource has been exceeded while interacting with the Azure Event Hubs service.</summary>
            QuotaExceeded,

            /// <summary>The Azure Event Hubs service reports that it is busy in response to a client request to perform an operation.</summary>
            ServiceBusy,

            /// <summary>An operation or other request timed out while interacting with the Azure Event Hubs service.</summary>
            ServiceTimeout,

            /// <summary>There was a general communications error encountered when interacting with the Azure Event Hubs service.</summary>
            ServiceCommunicationProblem,

            /// <summary>A client was forcefully disconnected from an Event Hub instance.  This typically occurs when another consumer with higher <see cref="PartitionPublishingOptions.OwnerLevel" /> asserts ownership over the partition and producer group.</summary>
            ProducerDisconnected,

            /// <summary>A client is in an invalid state from which it cannot recover.  It is recommended that the client be closed and recreated to force reinitialization of state.</summary>
            InvalidClientState
        }
    }
}
