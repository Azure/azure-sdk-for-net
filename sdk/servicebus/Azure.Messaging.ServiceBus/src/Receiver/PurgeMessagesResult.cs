// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The result of a <see cref="ServiceBusReceiver.PurgeMessagesAsync(System.DateTimeOffset?, System.Threading.CancellationToken)"/> operation.
    /// </summary>
    public class PurgeMessagesResult
    {
        internal PurgeMessagesResult(long deletedCount)
        {
            DeletedCount = deletedCount;
        }

        /// <summary>
        /// Gets the total number of messages that were deleted.
        /// </summary>
        public long DeletedCount { get; }
    }
}
