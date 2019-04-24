// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System.Threading.Tasks;

    /// <summary>
    /// Contains partition ownership information.
    /// </summary>
    public class Lease
    {
        /// <summary></summary>
        protected Lease()
        {
        }

        /// <summary></summary>
        /// <param name="partitionId"></param>
        protected Lease(string partitionId)
        {
            this.PartitionId = partitionId;
            this.Owner = string.Empty;
            this.Token = string.Empty;
        }

        /// <summary></summary>
        /// <param name="source"></param>
        protected Lease(Lease source)
        {
            this.PartitionId = source.PartitionId;
            this.Epoch = source.Epoch;
            this.Owner = source.Owner;
            this.Token = source.Token;
        }

        /// <summary>
        /// Gets or sets the current value for the offset in the stream.
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// Gets or sets the last checkpointed sequence number in the stream.
        /// </summary>
        public long SequenceNumber { get; set; }

        /// <summary>
        /// Gets the ID of the partition to which this lease belongs.
        /// </summary>
        public string PartitionId { get; set; }

        /// <summary>
        /// Gets or sets the host owner for the partition.
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Gets or sets the lease token that manages concurrency between hosts. You can use this token to guarantee single access to any resource needed by the <see cref="IEventProcessor"/> object.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the epoch year of the lease, which is a value you can use to determine the most recent owner of a partition between competing nodes.
        /// </summary>
        public long Epoch { get; set; }

        /// <summary>
        /// Determines whether the lease is expired.
        /// </summary>
        /// <returns></returns>
        public virtual Task<bool> IsExpired() 
        {
            // By default lease never expires.
            // Deriving class will implement the lease expiry logic.
            return Task.FromResult(false);
        }

        internal long IncrementEpoch()
        {
            this.Epoch++;
            return this.Epoch;
        }
    }
}