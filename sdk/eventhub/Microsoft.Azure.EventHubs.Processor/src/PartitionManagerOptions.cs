// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Processor
{
    using System;

    /// <summary>
    /// Options to control various aspects of partition distribution happening within <see cref="EventProcessorHost"/> instance.
    /// </summary> 
    public class PartitionManagerOptions
    {
        const int MinLeaseDurationInSeconds = 15;
        const int MaxLeaseDurationInSeconds = 1500;

        TimeSpan renewInterval = TimeSpan.FromSeconds(10);
        TimeSpan leaseDuration = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Renew interval for all leases for partitions currently held by <see cref="EventProcessorHost"/> instance.
        /// </summary>
        public TimeSpan RenewInterval
        {
            get
            {
                return this.renewInterval;
            }

            set
            {
                if (value >= this.leaseDuration)
                {
                    throw new ArgumentException("Renew interval needs to be smaller than the lease duration.");
                }

                this.renewInterval = value;
            }
        }

        /// <summary>
        /// Interval for which the lease is taken on Azure Blob representing an EventHub partition.  If the lease is not renewed within this 
        /// interval, it will cause it to expire and ownership of the partition will move to another <see cref="EventProcessorHost"/> instance.
        /// </summary>
        public TimeSpan LeaseDuration
        {
            get
            {
                return this.leaseDuration;
            }

            set
            {
                if (value <= this.renewInterval)
                {
                    throw new ArgumentException("Lease duration needs to be greater than the renew interval.");
                }

                if (value.TotalSeconds < MinLeaseDurationInSeconds || value.TotalSeconds > MaxLeaseDurationInSeconds)
                {
                    throw new ArgumentException($"Lease duration needs to be between {MinLeaseDurationInSeconds} seconds and {MaxLeaseDurationInSeconds} seconds.");
                }

                this.leaseDuration = value;
            }
        }
    }
}
