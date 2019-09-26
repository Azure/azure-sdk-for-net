// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Either a <see cref="Prefix"/> or <see cref="Blob"/> returned from
    /// <see cref="BlobContainerClient.GetBlobsByHierarchyAsync"/>.
    /// </summary>
    public class BlobHierarchyItem
    {
        /// <summary>
        /// Gets a prefix, relative to the delimiter used to get the blobs.
        /// </summary>
        public string Prefix { get; internal set; }

        /// <summary>
        /// Gets a blob.
        /// </summary>
        public BlobItem Blob { get; internal set; }

        /// <summary>
        /// Gets a value indicating if this item represents a <see cref="Prefix"/>.
        /// </summary>
        public bool IsPrefix => Prefix != null;

        /// <summary>
        /// Gets a value indicating if this item represents a <see cref="Blob"/>.
        /// </summary>
        public bool IsBlob => Blob != null;

        /// <summary>
        /// Initialies a new instance of the BlobHierarchyItem class.
        /// </summary>
        /// <param name="prefix">
        /// A prefix, relative to the delimiter used to get the blobs.
        /// </param>
        /// <param name="blob">
        /// A blob.
        /// </param>
        internal BlobHierarchyItem(string prefix, BlobItem blob)
        {
            Prefix = prefix;
            Blob = blob;
        }
    }

    /// <summary>
    /// BlobsModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class BlobsModelFactory
    {
        /// <summary>
        /// Creates a new BlobHierarchyItem instance for mocking.
        /// </summary>
        public static BlobHierarchyItem BlobHierarchyItem(
            string prefix,
            BlobItem blob) =>
            new BlobHierarchyItem(prefix, blob);
    }
}
