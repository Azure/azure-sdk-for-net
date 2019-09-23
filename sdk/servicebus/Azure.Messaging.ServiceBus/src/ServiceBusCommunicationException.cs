// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;

    /// <summary>
    /// Exception for signaling general communication errors related to messaging operations.
    /// </summary>
    public class ServiceBusCommunicationException : ServiceBusException
    {
        public ServiceBusCommunicationException(string message)
            : this(message, null)
        {
        }

        public ServiceBusCommunicationException(string message, Exception innerException)
            : base(true, message, innerException)
        {
        }
    }
}