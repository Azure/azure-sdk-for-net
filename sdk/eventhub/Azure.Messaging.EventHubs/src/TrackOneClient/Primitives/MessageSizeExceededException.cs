﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;

namespace TrackOne
{
    /// <summary>
    /// The exception is thrown when the message size exceeds what AMQP allows on the link.
    /// </summary>
    internal sealed class MessageSizeExceededException : EventHubsException
    {
        internal MessageSizeExceededException(string message)
            : this(message, null)
        {
        }

        internal MessageSizeExceededException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }

        internal MessageSizeExceededException(uint deliveryId, ulong size, ulong maxSize)
            : this(Resources.AmqpMessageSizeExceeded.FormatForUser(deliveryId, size, maxSize))
        {
        }
    }
}
