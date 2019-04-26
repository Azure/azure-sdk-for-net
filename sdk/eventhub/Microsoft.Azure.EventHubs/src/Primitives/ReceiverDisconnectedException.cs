// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;

    /// <summary>
    /// This exception is thrown if two or more <see cref="PartitionReceiver"/> instances connect
    /// to the same partition with different epoch values.
    /// </summary>
    public sealed class ReceiverDisconnectedException : EventHubsException
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
