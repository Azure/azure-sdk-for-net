// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Messaging.EventHubs.Core;

namespace Azure.Messaging.EventHubs
{
    /// <summary>
    ///   The set of options that can be specified when sending a set of events to configure
    ///   how the event data is packaged as a batch.
    /// </summary>
    ///
    public class EventBatchOptions
    {
        /// <summary>The maximum size to allow for the batch, in bytes.</summary>
        private int _maximumSizeInBytes = EventSender.MaximumBatchSizeLimit;

        /// <summary>
        ///   The maximum size to allow for the batch, in bytes.
        /// </summary>
        ///
        public int MaximumSizeInBytes
        {
            get => _maximumSizeInBytes;

            set
            {
                Guard.ArgumentInRange(nameof(MaximumSizeInBytes), value, EventSender.MinimumBatchSizeLimit, EventSender.MaximumBatchSizeLimit);
                _maximumSizeInBytes = value;
            }
        }

        /// <summary>
        ///   Allows a batch to be identified as part of a group, which hints to the
        ///   Event Hubs service that reasonable efforts should be made to use the same
        ///   partition for batches that belong to the same group.
        ///
        ///   This should be specified only when there is a need to try and group events by partition, but
        ///   there is flexibility in allowing them to appear in other partitions at the discretion of the service,
        ///   such as when a partition is unavailable.
        ///
        ///   If ensuring that a batch of events is sent only to a specific partition, it is recommended that the
        ///   identifier of the position be specified directly when sending the batch.
        /// </summary>
        ///
        /// <value>The name of the group to which the batch is associated; if the batch is not</value>
        ///
        public string BatchGroup { get; set; }

        /// <summary>
        ///   Determines whether the specified <see cref="System.Object" />, is equal to this instance.
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
    }
}