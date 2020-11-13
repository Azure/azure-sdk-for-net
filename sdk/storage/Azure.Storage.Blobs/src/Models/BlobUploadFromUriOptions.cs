﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs.Specialized;
using Metadata = System.Collections.Generic.IDictionary<string, string>;
using Tags = System.Collections.Generic.IDictionary<string, string>;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Optional parameters for <see cref="BlockBlobClient.SyncUploadFromUri"/>.
    /// </summary>
    public class BlobUploadFromUriOptions
    {
        /// <summary>
        /// The copy source blob properties behavior.  If true, the properties
        /// of the source blob will be copied to the new blob.  Default is true.
        /// </summary>
        public bool? CopySourceBlobProperties { get; set; }

        /// <summary>
        /// Optional standard HTTP header properties that can be set for the
        /// new append blob.
        /// </summary>
        public BlobHttpHeaders HttpHeaders { get; set; }

        // TODO service bug.  https://github.com/Azure/azure-sdk-for-net/issues/15969
        ///// <summary>
        ///// Optional custom metadata to set for this append blob.
        ///// </summary>
        //public Metadata Metadata { get; set; }

        /// <summary>
        /// Options tags to set for this block blob.
        /// </summary>
        public Tags Tags { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the copyig of data to this Block Blob.
        /// </summary>
        public BlobRequestConditions DestinationConditions { get; set; }

        /// <summary>
        /// Optional <see cref="BlobRequestConditions"/> to add
        /// conditions on the copying of data from this source blob.
        /// </summary>
        public BlobRequestConditions SourceConditions { get; set; }

        /// <summary>
        /// Optional <see cref="AccessTier"/> to set on the
        /// Block Blob.
        /// </summary>
        public AccessTier? AccessTier { get; set; }
    }
}
