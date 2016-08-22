// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines extension methods for the IndexingParameters class.
    /// </summary>
    public static class IndexingParametersExtensions
    {
        private const string ParsingModeKey = "parsingMode";

        /// <summary>
        /// Specifies that the indexer will index only the storage metadata and completely skip the document extraction process. This is useful when
        /// you don't need the document content, nor do you need any of the content type-specific metadata properties.
        /// See <see href="https://azure.microsoft.com/en-us/documentation/articles/search-howto-indexing-azure-blob-storage/" /> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters IndexStorageMetadataOnly(this IndexingParameters parameters)
        {
            return Configure(parameters, "indexStorageMetadataOnly", true);
        }

        /// <summary>
        /// Specifies that the indexer will index only the blobs with the file name extensions you specify. Each string is a file extensions with a
        /// leading dot. For example, ".pdf", ".docx", etc. If you pass the same file extension to this method and ExcludeFileNameExtensions, blobs
        /// with that extension will be excluded from indexing (that is, ExcludeFileNameExtensions takes precedence).
        /// See <see href="https://azure.microsoft.com/en-us/documentation/articles/search-howto-indexing-azure-blob-storage/" /> for details.
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
                Configure(parameters, "indexedFileNameExtensions", extensions.ToCommaSeparatedString());
            }

            return parameters;
        }

        /// <summary>
        /// Specifies that the indexer will not index blobs with the file name extensions you specify. Each string is a file extensions with a
        /// leading dot. For example, ".pdf", ".docx", etc. If you pass the same file extension to this method and IndexFileNameExtensions, blobs
        /// with that extension will be excluded from indexing (that is, this method takes precedence).
        /// See <see href="https://azure.microsoft.com/en-us/documentation/articles/search-howto-indexing-azure-blob-storage/" /> for details.
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
                Configure(parameters, "excludedFileNameExtensions", extensions.ToCommaSeparatedString());
            }

            return parameters;
        }

        /// <summary>
        /// Specifies that the indexer will extract metadata, but skip content extraction for all blobs. If you want to skip content extraction for
        /// only some blobs, add AzureSearch_SkipContent metadata to those blobs individually instead of using this option.
        /// See <see href="https://azure.microsoft.com/en-us/documentation/articles/search-howto-indexing-azure-blob-storage/" /> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters SkipContent(this IndexingParameters parameters)
        {
            return Configure(parameters, "skipContent", true);
        }

        /// <summary>
        /// Tells the indexer to assume that all blobs contain JSON, which it will then parse such that each blob's JSON will map to a single
        /// document in the Azure Search index.
        /// See <see href="https://azure.microsoft.com/en-us/documentation/articles/search-howto-index-json-blobs/" /> for details.
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
        /// Tells the indexer to assume that all blobs contain JSON arrays, which it will then parse such that each JSON object in each array will
        /// map to a single document in the Azure Search index.
        /// See <see href="https://azure.microsoft.com/en-us/documentation/articles/search-howto-index-json-blobs/" /> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <param name="documentRoot">
        /// An optional JSON Pointer that tells the indexer how to find the JSON array if it's not the top-level JSON property of each blob. If this
        /// parameter is null or empty, the indexer will assume that the JSON array can be found in the top-level JSON property of each blob.
        /// Default is null.
        /// </param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters ParseJsonArrays(this IndexingParameters parameters, string documentRoot = null)
        {
            Configure(parameters, ParsingModeKey, "jsonArray");

            if (!string.IsNullOrEmpty(documentRoot))
            {
                Configure(parameters, "documentRoot", documentRoot);
            }

            return parameters;
        }

        /// <summary>
        /// Tells the indexer to assume that all blobs are delimited text files. Currently only comma-separated value (CSV) text files are supported.
        /// See <see href="https://azure.microsoft.com/en-us/documentation/articles/search-howto-index-csv-blobs/" /> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <param name="headers">
        /// Specifies column headers that the indexer will use to map values to specific fields in the Azure Search index. If you don't specify any
        /// headers, the indexer assumes that the first non-blank line of each blob contains comma-separated headers.
        /// </param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters ParseDelimitedTextFiles(this IndexingParameters parameters, params string[] headers)
        {
            Configure(parameters, ParsingModeKey, "delimitedText");

            if (headers?.Length > 0)
            {
                Configure(parameters, "delimitedTextHeaders", headers.ToCommaSeparatedString());
            }
            else
            {
                Configure(parameters, "firstLineContainsHeaders", true);
            }

            return parameters;
        }

        private static IndexingParameters Configure(IndexingParameters parameters, string key, object value)
        {
            Throw.IfArgumentNull(parameters, nameof(parameters));

            if (parameters.Configuration == null)
            {
                parameters.Configuration = new Dictionary<string, object>();
            }

            parameters.Configuration.Add(key, value);
            return parameters;
        }
    }
}
