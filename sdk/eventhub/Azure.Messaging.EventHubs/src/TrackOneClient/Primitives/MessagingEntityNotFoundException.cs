// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
