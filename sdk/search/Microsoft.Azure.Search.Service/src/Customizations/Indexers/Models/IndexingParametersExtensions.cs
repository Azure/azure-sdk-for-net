// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Common;

    /// <summary>
    /// Defines extension methods for the IndexingParameters class.
    /// </summary>
    public static class IndexingParametersExtensions
    {
        private const string ParsingModeKey = "parsingMode";
 
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
        /// Specifies which parts of a blob will be indexed by the blob storage indexer. 
        /// </summary>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" />
        /// </remarks>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <param name="extractionMode">A <c cref="BlobExtractionMode">BlobExtractionMode</c> value specifying what to index.</param>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters SetBlobExtractionMode(this IndexingParameters parameters, BlobExtractionMode extractionMode) =>
            Configure(parameters, "dataToExtract", (string)extractionMode);

        /// <summary>
        /// Tells the indexer to assume that all blobs contain JSON, which it will then parse such that each blob's JSON will map to a single
        /// document in the search index.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-index-json-blobs/" /> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters ParseJson(this IndexingParameters parameters) =>
            Configure(parameters, ParsingModeKey, "json");

        /// <summary>
        /// Tells the indexer to assume that all blobs contain new-line separated JSON, which it will then parse such that individual JSON entities in each blob
        /// will map to a single document in the search index.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-index-json-blobs/" /> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters ParseJsonLines(this IndexingParameters parameters) =>
            Configure(parameters, ParsingModeKey, "jsonLines");

        /// <summary>
        /// Tells the indexer to assume that all blobs contain JSON arrays, which it will then parse such that each JSON object in each array will
        /// map to a single document in the search index.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-index-json-blobs" /> for details.
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
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-index-csv-blobs" /> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <param name="headers">
        /// Specifies column headers that the indexer will use to map values to specific fields in the search index. If you don't specify any
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

        /// <summary>
        /// Tells the indexer to assume that blobs should be parsed as text files in UTF-8 encoding.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage#indexing-plain-text">Indexing plain text</see> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters ParseText(this IndexingParameters parameters) => 
            ParseText(parameters, Encoding.UTF8);

        /// <summary>
        /// Tells the indexer to assume that blobs should be parsed as text files in the desired encoding.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage#indexing-plain-text">Indexing plain text</see> for details.
        /// </summary>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <param name="encoding">Encoding used to read the text stored in blobs.</param>
        /// <returns>The IndexingParameters instance.</returns>
        public static IndexingParameters ParseText(this IndexingParameters parameters, Encoding encoding)
        {
            Throw.IfArgumentNull(encoding, nameof(encoding));

            Configure(parameters, ParsingModeKey, "text");
            Configure(parameters, "encoding", encoding.WebName);
            return parameters;
        }

        /// <summary>
        /// Specifies that <c cref="BlobExtractionMode.StorageMetadata">BlobExtractionMode.StorageMetadata</c> blob extraction mode will be
        /// automatically used for blobs of unsupported content types. This behavior is enabled by default.
        /// </summary>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <param name="parameters">IndexingParameters to configure.</param>
        /// <returns></returns>
        /// <returns>The IndexingParameters instance.</returns>
        [Obsolete("This behavior is now enabled by default, so calling this method is no longer necessary.")]
        public static IndexingParameters DoNotFailOnUnsupportedContentType(this IndexingParameters parameters) =>
            Configure(parameters, "failOnUnsupportedContentType", false);

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
