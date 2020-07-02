// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Search.Documents.Samples
{
    /// <summary>
    /// Defines which parts of a blob will be indexed by the blob storage indexer.
    /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" /> for details.
    /// </summary>
    public readonly partial struct BlobExtractionMode : IEquatable<BlobExtractionMode>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="BlobExtractionMode"/> values are the same. </summary>
        public BlobExtractionMode(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string StorageMetadataValue = "storageMetadata";
        private const string AllMetadataValue = "allMetadata";
        private const string ContentAndMetadataValue = "contentAndMetadata";

        /// <summary>
        /// Specifies that only the standard blob properties and user-specified metadata will be indexed.
        /// See <see href="https://docs.microsoft.com/azure/storage/blobs/storage-blob-container-properties-metadata">Manage container properties and metadata with .NET</see> for details.
        /// </summary>
        public static BlobExtractionMode StorageMetadata { get; } = new BlobExtractionMode(StorageMetadataValue);

        /// <summary>
        /// Specifies that storage metadata and the content-type specific metadata extracted from the blob content will be indexed.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage#content-type-specific-metadata-properties">Content type-specific metadata properties</see> for details.
        /// </summary>
        public static BlobExtractionMode AllMetadata { get; } = new BlobExtractionMode(AllMetadataValue);

        /// <summary>
        /// Specifies that all metadata and textual content extracted from the blob will be indexed. This is the default value.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage">How to index documents in Azure Blob Storage with Azure Cognitive Search</see> for details.
        /// </summary>
        public static BlobExtractionMode ContentAndMetadata { get; } = new BlobExtractionMode(ContentAndMetadataValue);

        /// <summary> Determines if two <see cref="BlobExtractionMode"/> values are the same. </summary>
        public static bool operator ==(BlobExtractionMode left, BlobExtractionMode right) => left.Equals(right);

        /// <summary> Determines if two <see cref="BlobExtractionMode"/> values are not the same. </summary>
        public static bool operator !=(BlobExtractionMode left, BlobExtractionMode right) => !left.Equals(right);

        /// <summary> Converts a string to a <see cref="BlobExtractionMode"/>. </summary>
        public static implicit operator BlobExtractionMode(string value) => new BlobExtractionMode(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is BlobExtractionMode other && Equals(other);

        /// <inheritdoc />
        public bool Equals(BlobExtractionMode other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;

        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
