// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace TrackOne
{
    /// <summary>
    /// This exception is thrown if two or more <see cref="PartitionReceiver"/> instances connect
    /// to the same partition with different epoch values.
    /// </summary>
    internal sealed class ReceiverDisconnectedException : EventHubsException
    {
        internal ReceiverDisconnectedException(string message)
            : this(message, null)
        {
        }

        internal ReceiverDisconnectedException(string message, Exception innerException)
            : base(false, message, innerException)
        {
        }
    }
}
