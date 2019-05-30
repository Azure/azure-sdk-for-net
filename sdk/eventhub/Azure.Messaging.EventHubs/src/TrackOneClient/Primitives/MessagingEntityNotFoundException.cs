// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace TrackOne
{
    /// <summary>
    /// The exception that is thrown when the Event Hub is not found on the namespace.
    /// </summary>
    internal sealed class MessagingEntityNotFoundException : EventHubsException
    {
        internal MessagingEntityNotFoundException(string message)
            : base(false, message, null)
        {
        }
    }
}
