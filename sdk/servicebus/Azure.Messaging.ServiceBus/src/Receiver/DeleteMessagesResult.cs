// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The result of a <see cref="ServiceBusReceiver.DeleteMessagesAsync"/> operation.
    /// </summary>
    public class DeleteMessagesResult
    {
        internal DeleteMessagesResult(int deletedCount)
        {
            DeletedCount = deletedCount;
        }

        /// <summary>
        /// Gets the number of messages that were deleted.
        /// </summary>
        public int DeletedCount { get; }
    }
}
