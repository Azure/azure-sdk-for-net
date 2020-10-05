﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;

namespace Azure.Messaging.EventHubs.Producer
{
    /// <summary>
    ///   The set of options that can be specified to influence the way in which an event batch
    ///   behaves and is sent to the Event Hubs service.
    /// </summary>
    ///
    public class CreateBatchOptions : SendEventOptions
    {
        /// <summary>The requested maximum size to allow for the batch, in bytes.</summary>
        private long? _maximumSizeInBytes = null;

        /// <summary>
        ///   The maximum size to allow for a single batch of events, in bytes.
        /// </summary>
        ///
        /// <value>
        ///   The desired limit, in bytes, for the size of the associated event batch.  If <c>null</c>,
        ///   the maximum size allowed by the active transport will be used.
        /// </value>
        ///
        public long? MaximumSizeInBytes
        {
            get => _maximumSizeInBytes;

            set
            {
                if (value.HasValue)
                {
                    Argument.AssertAtLeast(value.Value, EventHubProducerClient.MinimumBatchSizeLimit, nameof(MaximumSizeInBytes));
                }

                _maximumSizeInBytes = value;
            }
        }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        ///
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        ///
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        ///   Returns a hash code for this instance.
        /// </summary>
        ///
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        ///   Converts the instance to string representation.
        /// </summary>
        ///
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        ///
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();

        /// <summary>
        ///   Creates a new copy of the current <see cref="CreateBatchOptions" />, cloning its attributes into a new instance.
        /// </summary>
        ///
        /// <returns>A new copy of <see cref="CreateBatchOptions" />.</returns>
        ///
        internal new CreateBatchOptions Clone() =>
            new CreateBatchOptions
            {
                PartitionId = PartitionId,
                PartitionKey = PartitionKey,
                _maximumSizeInBytes = _maximumSizeInBytes
            };
    }
}
