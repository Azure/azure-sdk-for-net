// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the requested message is not found.
    /// </summary>
    public sealed class MessageNotFoundException : ServiceBusException
    {
        public MessageNotFoundException(string message)
            : this(message, null)
        {
        }

        public MessageNotFoundException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}