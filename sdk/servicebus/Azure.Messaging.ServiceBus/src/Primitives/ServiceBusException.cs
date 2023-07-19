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
    public class ServiceBusException : Exception
    {
        /// <summary>
        ///   Indicates whether an exception should be considered transient or final.
        /// </summary>
        ///
        /// <value><c>true</c> if the exception is likely transient; otherwise, <c>false</c>.</value>
        public bool IsTransient { get; }

        /// <summary>
        ///   The reason for the failure of an Service Bus operation that resulted
        ///   in the exception.
        /// </summary>
        public ServiceBusFailureReason Reason { get; }

        /// <summary>
        ///   The name of the Service Bus to which the exception is associated.
        /// </summary>
        ///
        /// <value>The name of the Service Bus entity, if available; otherwise, <c>null</c>.</value>
        public string EntityPath { get; }

        /// <summary>
        /// Can be used to hold the processor error source when we rethrow exceptions.
        /// </summary>
        internal ServiceBusErrorSource? ProcessorErrorSource { get; set; }

        /// <summary>
        ///   Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                if (string.IsNullOrEmpty(EntityPath))
                {
                    return string.Format(
                        CultureInfo.InvariantCulture,
                        "{0} ({1}). {2}",
                        base.Message,
                        Reason,
                        Constants.TroubleshootingMessage);
                }
                return string.Format(
                    CultureInfo.InvariantCulture,
                    "{0} ({1} - {2}). {3}",
                    base.Message,
                    EntityPath,
                    Reason,
                    Constants.TroubleshootingMessage);
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
        public ServiceBusException(
            string message,
            ServiceBusFailureReason reason,
            string entityPath = default,
            Exception innerException = default) :
            this(default, message, entityPath, reason, innerException)
        {
            switch (reason)
            {
                case ServiceBusFailureReason.ServiceCommunicationProblem:
                case ServiceBusFailureReason.ServiceTimeout:
                case ServiceBusFailureReason.ServiceBusy:
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
        public ServiceBusException(bool isTransient,
                                  string message,
                                  string entityName = default,
                                  ServiceBusFailureReason reason = ServiceBusFailureReason.GeneralError,
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
    }
}
