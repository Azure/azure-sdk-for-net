// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure;
using Azure.Storage.Blobs.Models;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Lease
    /// </summary>
    public partial class BlobLease
    {
        /// <summary>
        /// Gets the approximate time remaining in the lease period, in
        /// seconds.  This is only provided when breaking a lease.
        /// </summary>
        public int? LeaseTime { get; internal set; }
    }
}
