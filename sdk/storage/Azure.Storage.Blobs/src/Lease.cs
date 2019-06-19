// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure;
using Azure.Storage.Blobs.Models;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Lease
    /// </summary>
    public partial class Lease
    {
        /// <summary>
        /// Gets the approximate time remaining in the lease period, in
        /// seconds.  This is only provided when breaking a lease.
        /// </summary>
        public int? LeaseTime { get; internal set; }
    }
}

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// BlobRestClient response extensions
    /// </summary>
    public static partial class BlobExtensions
    {
        /// <summary>
        /// Convert the internal BrokenLease response into a Lease.  The
        /// LeaseId will be empty.
        /// </summary>
        /// <param name="response">The original response.</param>
        /// <returns>The Lease response.</returns>
        internal static Response<Lease> ToLease(this Response<BrokenLease> response)
            => new Response<Lease>(
                response.Raw,
                new Lease
                {
                    ETag = response.Value.ETag,
                    LastModified = response.Value.LastModified,
                    LeaseTime = response.Value.LeaseTime
                });
    }
}
