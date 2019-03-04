// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
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