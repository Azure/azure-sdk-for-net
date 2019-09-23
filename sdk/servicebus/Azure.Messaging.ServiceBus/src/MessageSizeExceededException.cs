// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    using System;

    /// <summary>
    /// The exception that is thrown when the message size exceeds the limit.
    /// </summary>
    public sealed class MessageSizeExceededException : ServiceBusException
    {
        public MessageSizeExceededException(string message)
            : this(message, null)
        {
        }

        public MessageSizeExceededException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}