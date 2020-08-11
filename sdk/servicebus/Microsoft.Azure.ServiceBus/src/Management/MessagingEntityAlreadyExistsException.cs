// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus.Management
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