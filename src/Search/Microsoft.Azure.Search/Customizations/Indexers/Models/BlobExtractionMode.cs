// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Search.Serialization;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Defines which parts of a blob will be indexed by the blob storage indexer. 
    /// <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" />
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<BlobExtractionMode>))]
    public sealed class BlobExtractionMode : ExtensibleEnum<BlobExtractionMode>
    {
        /// <summary>
        /// Specifies that only the standard blob properties and user-specified metadata will be indexed. 
        /// <see href="https://docs.microsoft.com/azure/storage/storage-properties-metadata" />
        /// </summary>
        public static readonly BlobExtractionMode StorageMetadata = new BlobExtractionMode("storageMetadata");

        /// <summary>
        /// Specifies that storage metadata and the content-type specific metadata extracted from the blob content will be indexed.
        /// <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage#content-type-specific-metadata-properties" /> 
        /// </summary>
        public static readonly BlobExtractionMode AllMetadata = new BlobExtractionMode("allMetadata");

        /// <summary>
        /// Specifies that all metadata and textual content extracted from the blob will be indexed. This is the default value.  
        /// <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage#document-extraction-process"/>
        /// </summary>
        public static readonly BlobExtractionMode ContentAndMetadata = new BlobExtractionMode("contentAndMetadata");

        private BlobExtractionMode(string mode) : base(mode)
        {
            // Base class does all initialization.
        }

        /// <summary>
        /// Creates a new BlobExtractionMode instance, or returns an existing instance if the given name matches that of a
        /// known blob extraction mode.
        /// </summary>
        /// <param name="name">Name of the blob extraction mode.</param>
        /// <returns>A BlobExtractionMode instance with the given name.</returns>
        public static BlobExtractionMode Create(string name)
        {
            // Data source type names are purposefully open-ended. If we get one we don't recognize, just create a new object.
            return Lookup(name) ?? new BlobExtractionMode(name);
        }
    }
}
