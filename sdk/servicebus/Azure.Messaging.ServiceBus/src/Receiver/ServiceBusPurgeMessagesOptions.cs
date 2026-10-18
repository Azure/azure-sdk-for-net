// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.ServiceBus
{
    /// <summary>
    /// The options used to configure a purge operation.
    /// </summary>
    public class ServiceBusPurgeMessagesOptions
    {
        private int _maxMessagesPerBatch = ServiceBusReceiver.MaxDeleteMessageCount;

        /// <summary>
        /// Gets or sets the number of messages requested in each batch-delete call.
        /// The default is 500.
        /// </summary>
        /// <remarks>
        /// The service enforces a limit of 500 for Basic and Standard and 4,000 for Premium.
        /// The batch size is captured when the purge starts and remains unchanged for that operation.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The value is less than 1.
        /// </exception>
        public int MaxMessagesPerBatch
        {
            get => _maxMessagesPerBatch;
            set
            {
                Argument.AssertAtLeast(value, 1, nameof(MaxMessagesPerBatch));
                _maxMessagesPerBatch = value;
            }
        }

        /// <summary>
        /// Determines whether the specified object is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns><c>true</c> if the specified object is equal to this instance; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts this instance to its string representation.
        /// </summary>
        /// <returns>A string representation of this instance.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
    }
}
