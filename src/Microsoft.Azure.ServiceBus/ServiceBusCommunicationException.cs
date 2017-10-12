// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    /// <summary>
    /// Exception for signaling general communication errors related to messaging operations.
    /// </summary>
    public class ServiceBusCommunicationException : ServiceBusException
    {
        /// <summary></summary>
        /// <param name="message"></param>
        protected internal ServiceBusCommunicationException(string message)
            : this(message, null)
        {
        }

        /// <summary></summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        protected internal ServiceBusCommunicationException(string message, Exception innerException)
            : base(true, message, innerException)
        {
        }
    }
}