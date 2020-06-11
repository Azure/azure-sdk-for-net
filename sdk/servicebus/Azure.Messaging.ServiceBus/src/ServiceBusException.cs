// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    ///   Serves as a basis for exceptions produced within the Service Bus
    ///   context.
    /// </summary>
    ///
    /// <seealso cref="System.Exception" />
    ///
    public class ServiceBusException : Exception
    {
        /// <summary>
        ///   Indicates whether an exception should be considered transient or final.
        /// </summary>
        ///
        /// <value><c>true</c> if the exception is likely transient; otherwise, <c>false</c>.</value>
        ///
        public bool IsTransient { get; }

        /// <summary>
        ///   The reason for the failure of an Service Bus operation that resulted
        ///   in the exception.
        /// </summary>
        ///
        public FailureReason Reason { get; }

        /// <summary>
        ///   The name of the Service Bus to which the exception is associated.
        /// </summary>
        ///
        /// <value>The name of the Service Bus entity, if available; otherwise, <c>null</c>.</value>
        ///
        public string EntityPath { get; }

        /// <summary>
        /// Can be used to hold the processor error source when we rethrow exceptions.
        /// </summary>
        internal ServiceBusErrorSource? ProcessorErrorSource { get; set; }

        /// <summary>
        ///   Gets a message that describes the current exception.
        /// </summary>
        ///
        public override string Message
        {
            get
            {
                if (string.IsNullOrEmpty(EntityPath))
                {
                    return string.Format(
                        CultureInfo.InvariantCulture,
                        "{0} ({1})",
                        base.Message,
                        Reason);
                }
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "{0} ({1} - {2})",
                    base.Message,
                    EntityPath,
                    Reason);
            }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ServiceBusException"/> class, using the <paramref name="reason"/>
        ///   to detect whether or not it should be transient.
        /// </summary>
        ///
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="reason">The reason for the failure that resulted in the exception.</param>
        /// <param name="entityPath">The name of the Service Bus entity to which the exception is associated.</param>
        /// <param name="innerException"></param>
        ///
        public ServiceBusException(
            string message,
            FailureReason reason,
            string entityPath = default,
            Exception innerException = default) :
            this(default, message, entityPath, reason, innerException)
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
        ///   Initializes a new instance of the <see cref="ServiceBusException"/> class.
        /// </summary>
        ///
        /// <param name="isTransient"><c>true</c> if the exception should be considered transient; otherwise, <c>false</c>.</param>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="entityName">The name of the Service Bus entity to which the exception is associated.</param>
        /// <param name="reason">The reason for the failure that resulted in the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        ///
        public ServiceBusException(bool isTransient,
                                  string message,
                                  string entityName = default,
                                  FailureReason reason = FailureReason.GeneralError,
                                  Exception innerException = default) : base(message, innerException)
        {
            IsTransient = isTransient;
            EntityPath = entityName;
            Reason = reason;
        }

        /// <summary>
        ///
        /// </summary>
        public ServiceBusException() { }

        /// <summary>
        ///   The set of well-known reasons for an Service Bus operation failure that
        ///   was the cause of an exception.
        /// </summary>
        ///
        public enum FailureReason
        {
            /// <summary>The exception was the result of a general error within the client library.</summary>
            GeneralError,

            /// <summary>An operation has been attempted using an Service Bus client instance
            /// which has already been closed.
            /// </summary>
            ClientClosed,

            /// <summary>A Service Bus resource cannot be found by the Service Bus service.</summary>
            MessagingEntityNotFound,

            /// <summary>
            /// The lock on the message is lost. Callers should call attempt to
            /// receive and process the message again.
            /// </summary>
            MessageLockLost,

            /// <summary>
            /// The requested message was not found.
            /// </summary>
            MessageNotFound,

            /// <summary>A message is larger than the maximum size allowed for its transport.</summary>
            MessageSizeExceeded,

            /// <summary>
            /// The Messaging Entity is disabled. Enable the entity again using Portal.
            /// </summary>
            MessagingEntityDisabled,

            /// <summary>The quota applied to an Service Bus resource has been exceeded while interacting with the Azure Service Bus service.</summary>
            QuotaExceeded,

            /// <summary>The Azure Service Bus service reports that it is busy in response to a client request to perform an operation.</summary>
            ServiceBusy,

            /// <summary>An operation or other request timed out while interacting with the Azure Service Bus service.</summary>
            ServiceTimeout,

            /// <summary>There was a general communications error encountered when interacting with the Azure Service Bus service.</summary>
            ServiceCommunicationProblem,

            /// <summary>
            /// The requested session cannot be locked.
            /// </summary>
            SessionCannotBeLocked,

            /// <summary>
            /// The lock on the session has expired.  Callers should request the session again.
            /// </summary>
            SessionLockLost,

            /// <summary>
            /// The user doesn't have access to the entity.
            /// </summary>
            Unauthorized,

            /// <summary>
            /// An entity with the same name exists under the same namespace.
            /// </summary>
            MessagingEntityAlreadyExists
        }
    }
}
