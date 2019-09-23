// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus.Management
{
    using System;

    /// <summary>
    /// The exception that is thrown when an already existing entity is being re created.
    /// </summary>
    public class MessagingEntityAlreadyExistsException : ServiceBusException
    {
        public MessagingEntityAlreadyExistsException(string message) : this(message, null)
        {
        }

        public MessagingEntityAlreadyExistsException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}