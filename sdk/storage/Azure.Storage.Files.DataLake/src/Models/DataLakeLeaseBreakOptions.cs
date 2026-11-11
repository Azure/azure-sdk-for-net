// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for DataLakeLeaseClient.Break.
    /// </summary>
    public class DataLakeLeaseBreakOptions
    {
        /// <summary>
        /// Specifies the proposed duration the lease should continue before
        /// it is broken, in seconds, between 0 and 60.  This break period is
        /// only used if it is shorter than the time remaining on the lease.
        /// If longer, the time remaining on the lease is used.  A new lease
        /// will not be available before the break period has expired, but the
        /// lease may be held for longer than the break period.  If this value
        /// is not provided, a fixed-duration lease breaks after the remaining
        /// lease period elapses, and an infinite lease breaks immediately.
        /// </summary>
        public TimeSpan? BreakPeriod { get; set; }

        /// <summary>
        /// Optional <see cref="RequestConditions"/> to add
        /// conditions on breaking a lease.
        /// </summary>
        public RequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
