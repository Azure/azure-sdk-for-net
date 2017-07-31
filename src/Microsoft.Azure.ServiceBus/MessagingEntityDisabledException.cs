// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the Messaging Entity is disabled. Enable the entity again using Portal.
    /// </summary>
    public sealed class MessagingEntityDisabledException : ServiceBusException
    {
        internal MessagingEntityDisabledException(string message)
            : this(message, null)
        {
        }

        internal MessagingEntityDisabledException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}