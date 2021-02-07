// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for creating an Append Blob.
    /// </summary>
    public class AppendBlobCreateOptions
    {
        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional custom metadata to set for this append blob.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Metadata Metadata { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Options tags to set for this append blob.
        /// </summary>
#pragma warning disable CA2227 // Collection properties should be readonly
        public Tags Tags { get; set; }
#pragma warning restore CA2227 // Collection properties should be readonly

        /// <summary>
        /// Optional <see cref="AppendBlobRequestConditions"/> to add
        /// conditions on the creation of this new append blob.
        /// </summary>
        public AppendBlobRequestConditions Conditions { get; set; }
    }
}
