// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    /// <summary>
    /// The context object used to preserve state in the stream.
    /// </summary>
    public class Checkpoint
    {       
        /// <summary>
        /// Creates a new Checkpoint for a particular partition ID.
        /// </summary>
        /// <param name="partitionId">The partition ID for the checkpoint</param>
        public Checkpoint(string partitionId)
            : this(partitionId, EventPosition.FromStart().Offset, 0)
        {
        }

        /// <summary>
        /// Creates a new Checkpoint for a particular partition ID, with the offset and sequence number.
        /// </summary>
        /// <param name="partitionId">The partition ID for the checkpoint</param>
        /// <param name="offset">The offset for the last processed <see cref="EventData"/></param>
        /// <param name="sequenceNumber">The sequence number of the last processed <see cref="EventData"/></param>
        public Checkpoint(string partitionId, string offset, long sequenceNumber)
        {
            this.PartitionId = partitionId;
            this.Offset = offset;
            this.SequenceNumber = sequenceNumber;
        }

        /// <summary>
        /// Creates a new Checkpoint from an existing checkpoint.
        /// </summary>
        /// <param name="source">The existing checkpoint to copy</param>
        public Checkpoint(Checkpoint source)
        {
            this.PartitionId = source.PartitionId;
            this.Offset = source.Offset;
            this.SequenceNumber = source.SequenceNumber;
        }

        /// <summary>
        /// Gets or sets the offset of the last processed <see cref="EventData"/>.
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// Gets or sets the sequence number of the last processed <see cref="EventData"/>.
        /// </summary>
        public long SequenceNumber { get; set; }

        /// <summary>
        /// Gets the partition ID for the corresponding checkpoint.
        /// </summary>
        public string PartitionId { get; }
    }
}