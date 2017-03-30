// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Defines extension methods for the IndexingParameters class.
    /// </summary>
    public static class IndexingParametersExtensions
    {
        private const string ParsingModeKey = "parsingMode";

        /// <summary> 
        /// Specifies that the indexer will index only the storage metadata and completely skip the document extraction process. This is useful when 
        /// you don't need the document content, nor do you need any of the content type-specific metadata properties. 
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" /> for details. 
        /// </summary> 
        /// <param name="parameters">IndexingParameters to configure.</param> 
        /// <remarks> 
        /// This option only applies to indexers that index Azure Blob Storage. 
        /// </remarks> 
        /// <returns>The IndexingParameters instance.</returns> 
        [Obsolete("This method is obsolete. Please use SetBlobExtractionMode(BlobExtractionMode.StorageMetadata).")]
        public static IndexingParameters IndexStorageMetadataOnly(this IndexingParameters parameters)
        { 
            return parameters.SetBlobExtractionMode(BlobExtractionMode.StorageMetadata); 
        } 
 
        /// <summary>
        /// Specifies that the indexer will index only the blobs with the file name extensions you specify. Each string is a file extensions with a
        /// leading dot. For example, ".pdf", ".docx", etc. If you pass the same file extension to this method and ExcludeFileNameExtensions, blobs
        /// with that extension will be excluded from indexing (that is, ExcludeFileNameExtensions takes precedence).
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" /> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <param name="extensions">File extensions to include in indexing.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters IndexFileNameExtensions(this IndexingParameters parameters, params string[] extensions)
        {
            if (extensions?.Length > 0)
            {
                Configure(
                    parameters, 
                    "indexedFileNameExtensions",
                    extensions.Select(ValidateExtension).Select(FixUpExtension).ToCommaSeparatedString());
            }

            return parameters;
        }

        /// <summary>
        /// Specifies that the indexer will not index blobs with the file name extensions you specify. Each string is a file extensions with a
        /// leading dot. For example, ".pdf", ".docx", etc. If you pass the same file extension to this method and IndexFileNameExtensions, blobs
        /// with that extension will be excluded from indexing (that is, this method takes precedence).
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" /> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <param name="extensions">File extensions to exclude from indexing.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters ExcludeFileNameExtensions(this IndexingParameters parameters, params string[] extensions)
        {
            if (extensions?.Length > 0)
            {
                Configure(
                    parameters, 
                    "excludedFileNameExtensions", 
                    extensions.Select(ValidateExtension).Select(FixUpExtension).ToCommaSeparatedString());
            }

            return parameters;
        }

        /// <summary>
        /// Specifies that the indexer will extract metadata, but skip content extraction for all blobs. If you want to skip content extraction for 
        /// only some blobs, add AzureSearch_SkipContent metadata to those blobs individually instead of using this option. 
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" /> for details. 
        /// </summary> 
        /// <param name="parameters">IndexingParameters to configure.</param> 
        /// <remarks> 
        /// This option only applies to indexers that index Azure Blob Storage. 
        /// </remarks> 
        /// <returns>The IndexingParameters instance.</returns> 
        [Obsolete("This method is obsolete. Please use SetBlobExtractionMode(BlobExtractionMode.AllMetadata).")]
        public static IndexingParameters SkipContent(this IndexingParameters parameters)
        { 
            return parameters.SetBlobExtractionMode(BlobExtractionMode.AllMetadata); 
        }

        /// <summary>
        /// Specifies which parts of a blob will be indexed by the blob storage indexer. 
        /// </summary>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" />
        /// </remarks>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <param name="extractionMode">A <c cref="BlobExtractionMode">BlobExtractionMode</c> value specifying what to index.</param>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters SetBlobExtractionMode(this IndexingParameters parameters, BlobExtractionMode extractionMode)
        {
            return Configure(parameters, "dataToExtract", (string)extractionMode);
        }

        /// <summary>
        /// Tells the indexer to assume that all blobs contain JSON, which it will then parse such that each blob's JSON will map to a single
        /// document in the Azure Search index.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-index-json-blobs/" /> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters ParseJson(this IndexingParameters parameters)
        {
            return Configure(parameters, ParsingModeKey, "json");
        }

        /// <summary>
        /// Specifies that <c cref="BlobExtractionMode.StorageMetadata">BlobExtractionMode.StorageMetadata</c> blob extraction mode will be
        /// automatically used for blobs of unsupported content types. The default is false.
        /// </summary>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <returns></returns>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters DoNotFailOnUnsupportedContentType(this IndexingParameters parameters)
        {
            return Configure(parameters, "failOnUnsupportedContentType", false);
        }

        private static IndexingParameters Configure(IndexingParameters parameters, string key, object value)
        {
            Throw.IfArgumentNull(parameters, nameof(parameters));

            if (parameters.Configuration == null)
            {
                parameters.Configuration = new Dictionary<string, object>();
            }

            parameters.Configuration[key] = value;
            return parameters;
        }

        private static string ValidateExtension(string extension)
        {
            if (string.IsNullOrEmpty(extension))
            {
                throw new ArgumentException("Extension cannot be null or empty string.");
            }

            if (extension.Contains("*"))
            {
                throw new ArgumentException("Extension cannot contain the wildcard character '*'.");
            }

            return extension;
        }

        private static string FixUpExtension(string extension)
        {
            if (!extension.StartsWith(".", StringComparison.Ordinal))
            {
                return "." + extension;
            }

            return extension;
        }
    }
}
