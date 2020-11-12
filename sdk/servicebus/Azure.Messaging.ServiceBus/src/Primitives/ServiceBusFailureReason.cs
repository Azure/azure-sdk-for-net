// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The set of well-known reasons for an Service Bus operation failure that was the cause of an exception.
    /// </summary>
    public enum ServiceBusFailureReason
    {
        /// <summary>
        /// The exception was the result of a general error within the client library.
        /// </summary>
        GeneralError,

        /// <summary>
        /// A Service Bus resource cannot be found by the Service Bus service.
        /// </summary>
        MessagingEntityNotFound,

        /// <summary>
        /// The lock on the message is lost. Callers should call attempt to receive and process the message again.
        /// </summary>
        MessageLockLost,

        /// <summary>
        /// The requested message was not found.
        /// </summary>
        MessageNotFound,

        /// <summary>
        /// A message is larger than the maximum size allowed for its transport.
        /// </summary>
        MessageSizeExceeded,

        /// <summary>
        /// The Messaging Entity is disabled. Enable the entity again using Portal.
        /// </summary>
        MessagingEntityDisabled,

        /// <summary>
        /// The quota applied to an Service Bus resource has been exceeded while interacting with the Azure Service Bus service.
        /// </summary>
        QuotaExceeded,

        /// <summary>
        /// The Azure Service Bus service reports that it is busy in response to a client request to perform an operation.
        /// </summary>
        ServiceBusy,

        /// <summary>
        /// An operation or other request timed out while interacting with the Azure Service Bus service.
        /// </summary>
        ServiceTimeout,

        /// <summary>
        /// There was a general communications error encountered when interacting with the Azure Service Bus service.
        /// </summary>
        ServiceCommunicationProblem,

        /// <summary>
        /// The requested session cannot be locked.
        /// </summary>
        SessionCannotBeLocked,

        /// <summary>
        /// The lock on the session has expired. Callers should request the session again.
        /// </summary>
        SessionLockLost,

        /// <summary>
        /// An entity with the same name exists under the same namespace.
        /// </summary>
        MessagingEntityAlreadyExists
    }
}
