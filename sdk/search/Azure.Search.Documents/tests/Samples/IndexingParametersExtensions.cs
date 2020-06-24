// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Tests.Samples
{
    /// <summary>
    /// Defines extension methods for the <see cref="IndexingParameters"/> class.
    /// </summary>
    public static class IndexingParametersExtensions
    {
        private const string ParsingModeKey = "parsingMode";

        /// <summary>
        /// Specifies that the indexer will index only the blobs with the file name extensions you specify. Each string is a file extensions with a
        /// leading dot, for example, ".pdf", ".docx", etc. If you pass the same file extension to this method and
        /// <see cref="SetExcludeFileNameExtensions(IndexingParameters, string[])"/>, blobs with that extension will be excluded from indexing
        /// (that is, <see cref="SetExcludeFileNameExtensions(IndexingParameters, string[])"/> takes precedence).
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" /> for details.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <param name="extensions">File extensions to include in indexing.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        public static IndexingParameters SetIndexedFileNameExtensions(this IndexingParameters parameters, params string[] extensions) =>
            ConfigureFileNameExtensions(parameters, "indexedFileNameExtensions", extensions);

        /// <summary>
        /// Specifies that the indexer will not index blobs with the file name extensions you specify. Each string is a file extensions with a
        /// leading dot, for example, ".pdf", ".docx", etc. If you pass the same file extension to this method and <see cref="SetIndexedFileNameExtensions(IndexingParameters, string[])"/>, blobs
        /// with that extension will be excluded from indexing (that is, this method takes precedence).
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" /> for details.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <param name="extensions">File extensions to include in indexing.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        public static IndexingParameters SetExcludeFileNameExtensions(this IndexingParameters parameters, params string[] extensions) =>
            ConfigureFileNameExtensions(parameters, "excludedFileNameExtensions", extensions);

        /// <summary>
        /// Specifies which parts of a blob will be indexed by the blob storage indexer.
        /// </summary>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage" /> for details.
        /// </remarks>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <param name="extractionMode">A <see cref="BlobExtractionMode"/> value specifying what to index.</param>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        public static IndexingParameters SetBlobExtractionMode(this IndexingParameters parameters, BlobExtractionMode extractionMode) =>
            Configure(parameters, "dataToExtract", extractionMode.ToString());

        /// <summary>
        /// Tells the indexer to assume that all blobs contain JSON, which it will then parse such that each blob's JSON will map to a single
        /// document in the search index.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-index-json-blobs/" /> for details.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        public static IndexingParameters SetParseJson(this IndexingParameters parameters) =>
            Configure(parameters, ParsingModeKey, "json");

        /// <summary>
        /// Tells the indexer to assume that all blobs contain new-line separated JSON, which it will then parse such that individual JSON entities in each blob
        /// will map to a single document in the search index.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-index-json-blobs/" /> for details.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        public static IndexingParameters SetParseJsonLines(this IndexingParameters parameters) =>
            Configure(parameters, ParsingModeKey, "jsonLines");

        /// <summary>
        /// Tells the indexer to assume that all blobs contain JSON arrays, which it will then parse such that each JSON object in each array will
        /// map to a single document in the search index.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-index-json-blobs" /> for details.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <param name="documentRoot">
        /// An optional <see href="https://tools.ietf.org/html/rfc6901">JSON Pointer</see> that tells the indexer how to find the JSON array if it's not the top-level JSON property of each blob.
        /// If this parameter is null or empty, the indexer will assume that the JSON array can be found in the top-level JSON property of each blob.
        /// Default is null.
        /// </param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        public static IndexingParameters SetParseJsonArrays(this IndexingParameters parameters, string documentRoot = null)
        {
            Configure(parameters, ParsingModeKey, "jsonArray");

            if (!string.IsNullOrEmpty(documentRoot))
            {
                Configure(parameters, "documentRoot", documentRoot);
            }

            return parameters;
        }

        /// <summary>
        /// Tells the indexer to assume that all blobs are text files containing comma-separated values (CSV).
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-index-csv-blobs" /> for details.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <param name="headers">
        /// Specifies column headers that the indexer will use to map values to specific fields in the search index. If you don't specify any
        /// headers, the indexer assumes that the first non-blank line of each blob contains comma-separated headers.
        /// </param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        public static IndexingParameters SetParseDelimitedTextFiles(this IndexingParameters parameters, params string[] headers) =>
            SetParseDelimitedTextFiles(parameters, ',', headers);

        /// <summary>
        /// Tells the indexer to assume that all blobs are delimited text files.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-index-csv-blobs" /> for details.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <param name="delimiter">
        /// Specifies the end-of-line or field delimiter.
        /// </param>
        /// <param name="headers">
        /// Specifies column headers that the indexer will use to map values to specific fields in the search index. If you don't specify any
        /// headers, the indexer assumes that the first non-blank line of each blob contains comma-separated headers.
        /// </param>
        /// <remarks>
        /// This option only applies to indexers that index Azure Blob Storage.
        /// </remarks>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parameters"/> is null.</exception>
        public static IndexingParameters SetParseDelimitedTextFiles(this IndexingParameters parameters, char delimiter, string[] headers)
        {
            Configure(parameters, ParsingModeKey, "delimitedText");
            Configure(parameters, "delimitedTextDelimiter", delimiter.ToString());

            if (headers != null && headers.Length > 0)
            {
                Configure(parameters, "delimitedTextHeaders", headers.CommaJoin());
            }
            else
            {
                Configure(parameters, "firstLineContainsHeaders", true);
            }

            return parameters;
        }

        /// <summary>
        /// Tells the indexer to assume that blobs should be parsed as text files in UTF-8 encoding.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage#indexing-plain-text"/> for details.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        public static IndexingParameters SetParseText(this IndexingParameters parameters) =>
            SetParseText(parameters, Encoding.UTF8);

        /// <summary>
        /// Tells the indexer to assume that blobs should be parsed as text files in the desired encoding.
        /// See <see href="https://docs.microsoft.com/azure/search/search-howto-indexing-azure-blob-storage#indexing-plain-text"/> for details.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <param name="encoding">Encoding used to read the text stored in blobs.</param>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        public static IndexingParameters SetParseText(this IndexingParameters parameters, Encoding encoding)
        {
            Argument.AssertNotNull(encoding, nameof(encoding));

            Configure(parameters, ParsingModeKey, "text");
            Configure(parameters, "encoding", encoding.WebName);
            return parameters;
        }

        /// <summary>
        /// Tells the indexer to stop processing documents when an unsupported content type is encountered.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        public static IndexingParameters SetFailOnUnsupportedContentType(this IndexingParameters parameters) =>
            Configure(parameters, "failOnUnsupportedContentType", true);

        /// <summary>
        /// Tells the indexer to stop processing documents if a document fails indexing.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        public static IndexingParameters SetFailOnUnprocessableDocument(this IndexingParameters parameters) =>
            Configure(parameters, "failOnUnprocessableDocument", true);

        /// <summary>
        /// Tells the indexer to create a path <c>/document/file_data</c> that is an object representing
        /// the original file data downloaded from your blob data source.
        /// This allows you to pass the original file data to a
        /// <see href="https://docs.microsoft.com/azure/search/cognitive-search-custom-skill-web-api">custom skill</see> for processing within the enrichment pipeline, or the
        /// <see href="https://docs.microsoft.com/azure/search/cognitive-search-skill-document-extraction">Document Extraction skill</see>.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        public static IndexingParameters SetAllowSkillsetToReadFileData(this IndexingParameters parameters) =>
            Configure(parameters, "allowSkillsetToReadFileData", true);

        /// <summary>
        /// Tells the indexer to still index storage metadata for blob content that is too large to process.
        /// Oversized blobs are treated as errors by default.
        /// For limits on blob size, see <see href="https://docs.microsoft.com/azure/search/search-limits-quotas-capacity">Service Limits</see>.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        public static IndexingParameters SetIndexStorageMetadataOnlyForOversizedDocuments(this IndexingParameters parameters) =>
            Configure(parameters, "indexStorageMetadataOnlyForOversizedDocuments", true);

        /// <summary>
        /// Tells the indexer how to process embedded images or image files.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <param name="imageAction">The <see cref="ImageAction"/> to set.</param>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        public static IndexingParameters SetImageAction(this IndexingParameters parameters, ImageAction imageAction) =>
            Configure(parameters, "imageAction", imageAction.ToString());

        /// <summary>
        /// Tells the indexer whether it should attempt to detect and rotate PDFs.
        /// The parsing mode must not be set to use this parameter.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <param name="pdfTextRotationAlgorithm">The <see cref="ImageAction"/> to set.</param>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        public static IndexingParameters SetPdfTextRotationAlgorithm(this IndexingParameters parameters, PdfTextRotationAlgorithm pdfTextRotationAlgorithm) =>
            Configure(parameters, "pdfTextRotationAlgorithm", pdfTextRotationAlgorithm.ToString());

        /// <summary>
        /// Only when indexing a <see cref="SearchIndexerDataSourceType.AzureSql"/> data source connection,
        /// set this parameter to increase the timeout beyond the 5-minute default.
        /// </summary>
        /// <param name="parameters">The <see cref="IndexingParameters"/> to configure.</param>
        /// <param name="queryTimeout">The <see cref="TimeSpan"/> when the query should be terminated.</param>
        /// <returns>The <see cref="IndexingParameters"/> instance.</returns>
        public static IndexingParameters SetQueryTimeout(this IndexingParameters parameters, TimeSpan queryTimeout) =>
            Configure(parameters, "queryTimeout", queryTimeout.ToString("hh\\:mm\\:ss", CultureInfo.InvariantCulture));

        private static IndexingParameters Configure(IndexingParameters parameters, string key, object value)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            parameters.Configuration[key] = value;
            return parameters;
        }

        private static IndexingParameters ConfigureFileNameExtensions(this IndexingParameters parameters, string key, string[] extensions)
        {
            if (extensions != null && extensions.Length > 0)
            {
                string delimitedExtensions = ProcessFileNameExtensions(extensions).CommaJoin();
                Configure(parameters, key, delimitedExtensions);
            }

            return parameters;
        }

        private static IEnumerable<string> ProcessFileNameExtensions(string[] extensions)
        {
            foreach (string extension in extensions)
            {
                if (string.IsNullOrEmpty(extension))
                {
                    throw new ArgumentException($"{nameof(extensions)} cannot be null or empty.", nameof(extensions));
                }

                if (extension.Contains("*"))
                {
                    throw new ArgumentException($"{nameof(extensions)} cannot contain the wildcard character '*'.");
                }

                if (!extension.StartsWith(".", StringComparison.Ordinal))
                {
                    yield return "." + extension;
                }
                else
                {
                    yield return extension;
                }
            }
        }
    }
}
