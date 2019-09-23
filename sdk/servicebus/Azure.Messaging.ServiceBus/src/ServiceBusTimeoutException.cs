// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when a time out is encountered.  Callers retry the operation.
    /// </summary>
    public class ServiceBusTimeoutException : ServiceBusException
    {
        public ServiceBusTimeoutException(string message) : this(message, null)
        {
        }

        public ServiceBusTimeoutException(string message, Exception innerException) : base(true, message, innerException)
        {
        }
    }
}