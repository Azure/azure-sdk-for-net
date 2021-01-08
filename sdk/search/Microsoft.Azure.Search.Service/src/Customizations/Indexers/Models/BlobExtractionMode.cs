// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Microsoft.Azure.Search.Common;
using Microsoft.Azure.Search.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Defines which parts of a blob will be indexed by the blob storage indexer. 
    /// <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" />
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<BlobExtractionMode>))]
    public struct BlobExtractionMode : IEquatable<BlobExtractionMode>
    {
        private readonly string _value;

        /// <summary>
        /// Specifies that only the standard blob properties and user-specified metadata will be indexed. 
        /// For more information, see <see href="https://docs.microsoft.com/azure/storage/blobs/storage-blob-container-properties-metadata">Manage container properties and metadata with .NET</see>.
        /// </summary>
        public static readonly BlobExtractionMode StorageMetadata = new BlobExtractionMode("storageMetadata");

        /// <summary>
        /// Specifies that storage metadata and the content-type specific metadata extracted from the blob content will be indexed.
        /// For more information, see <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage#content-type-specific-metadata-properties">Content type-specific metadata properties</see>.
        /// </summary>
        public static readonly BlobExtractionMode AllMetadata = new BlobExtractionMode("allMetadata");

        /// <summary>
        /// Specifies that all metadata and textual content extracted from the blob will be indexed. This is the default value.  
        /// For more information, see <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage">How to index documents in Azure Blob Storage with Azure Cognitive Search</see>.
        /// </summary>
        public static readonly BlobExtractionMode ContentAndMetadata = new BlobExtractionMode("contentAndMetadata");

        private BlobExtractionMode(string mode)
        {
            Throw.IfArgumentNull(mode, nameof(mode));
            _value = mode;
        }

        /// <summary>
        /// Defines implicit conversion from string to BlobExtractionMode.
        /// </summary>
        /// <param name="value">string to convert.</param>
        /// <returns>The string as a BlobExtractionMode.</returns>
        public static implicit operator BlobExtractionMode(string value) => new BlobExtractionMode(value);

        /// <summary>
        /// Defines explicit conversion from BlobExtractionMode to string.
        /// </summary>
        /// <param name="mode">BlobExtractionMode to convert.</param>
        /// <returns>The BlobExtractionMode as a string.</returns>
        public static explicit operator string(BlobExtractionMode mode) => mode.ToString();

        /// <summary>
        /// Compares two BlobExtractionMode values for equality.
        /// </summary>
        /// <param name="lhs">The first BlobExtractionMode to compare.</param>
        /// <param name="rhs">The second BlobExtractionMode to compare.</param>
        /// <returns>true if the BlobExtractionMode objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(BlobExtractionMode lhs, BlobExtractionMode rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two BlobExtractionMode values for inequality.
        /// </summary>
        /// <param name="lhs">The first BlobExtractionMode to compare.</param>
        /// <param name="rhs">The second BlobExtractionMode to compare.</param>
        /// <returns>true if the BlobExtractionMode objects are not equal; false otherwise.</returns>
        public static bool operator !=(BlobExtractionMode lhs, BlobExtractionMode rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the BlobExtractionMode for equality with another BlobExtractionMode.
        /// </summary>
        /// <param name="other">The BlobExtractionMode with which to compare.</param>
        /// <returns><c>true</c> if the BlobExtractionMode objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(BlobExtractionMode other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is BlobExtractionMode ? Equals((BlobExtractionMode)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the BlobExtractionMode.
        /// </summary>
        /// <returns>The BlobExtractionMode as a string.</returns>
        public override string ToString() => _value;
    }
}
