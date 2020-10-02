// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class IndexingParametersConfiguration
    {
        private const string ParsingModeKey = "parsingMode";
        private const string ExcludedFileNameExtensionsKey = "excludedFileNameExtensions";
        private const string IndexedFileNameExtensionsKey = "indexedFileNameExtensions";
        private const string FailOnUnsupportedContentTypeKey = "failOnUnsupportedContentType";
        private const string FailOnUnprocessableDocumentKey = "failOnUnprocessableDocument";
        private const string IndexStorageMetadataOnlyForOversizedDocumentsKey = "indexStorageMetadataOnlyForOversizedDocuments";
        private const string DelimitedTextHeadersKey = "delimitedTextHeaders";
        private const string DelimitedTextDelimiterKey = "delimitedTextDelimiter";
        private const string FirstLineContainsHeadersKey = "firstLineContainsHeaders";
        private const string DocumentRootKey = "documentRoot";
        private const string DataToExtractKey = "dataToExtract";
        private const string ImageActionKey = "imageAction";
        private const string AllowSkillsetToReadFileDataKey = "allowSkillsetToReadFileData";
        private const string PdfTextRotationAlgorithmKey = "pdfTextRotationAlgorithm";
        private const string ExecutionEnvironmentKey = "executionEnvironment";
        private const string QueryTimeoutKey = "queryTimeout";

        private readonly IDictionary<string, object> _properties = new Dictionary<string, object>(20);
        private IDictionary<string, object> _aggregate;

        /// <summary> Represents the parsing mode for indexing from an Azure blob data source. </summary>
        public BlobIndexerParsingMode? ParsingMode
        {
            get => Get(ParsingModeKey, value => new BlobIndexerParsingMode(value));
            set => Set(ParsingModeKey, value);
        }

        /// <summary> Comma-delimited list of filename extensions to ignore when processing from Azure blob storage.  For example, you could exclude &quot;.png, .mp4&quot; to skip over those files during indexing. </summary>
        public string ExcludedFileNameExtensions
        {
            get => Get<string>(ExcludedFileNameExtensionsKey);
            set => Set(ExcludedFileNameExtensionsKey, value);
        }

        /// <summary> Comma-delimited list of filename extensions to select when processing from Azure blob storage.  For example, you could focus indexing on specific application files &quot;.docx, .pptx, .msg&quot; to specifically include those file types. </summary>
        public string IndexedFileNameExtensions
        {
            get => Get<string>(IndexedFileNameExtensionsKey);
            set => Set(IndexedFileNameExtensionsKey, value);
        }

        /// <summary> For Azure blobs, set to false if you want to continue indexing when an unsupported content type is encountered, and you don&apos;t know all the content types (file extensions) in advance. </summary>
        public bool? FailOnUnsupportedContentType
        {
            get => Get<bool?>(FailOnUnsupportedContentTypeKey);
            set => Set(FailOnUnsupportedContentTypeKey, value);
        }

        /// <summary> For Azure blobs, set to false if you want to continue indexing if a document fails indexing. </summary>
        public bool? FailOnUnprocessableDocument
        {
            get => Get<bool?>(FailOnUnprocessableDocumentKey);
            set => Set(FailOnUnprocessableDocumentKey, value);
        }

        /// <summary> For Azure blobs, set this property to true to still index storage metadata for blob content that is too large to process. Oversized blobs are treated as errors by default. For limits on blob size, see https://docs.microsoft.com/azure/search/search-limits-quotas-capacity. </summary>
        public bool? IndexStorageMetadataOnlyForOversizedDocuments
        {
            get => Get<bool?>(IndexStorageMetadataOnlyForOversizedDocumentsKey);
            set => Set(IndexStorageMetadataOnlyForOversizedDocumentsKey, value);
        }

        /// <summary> For CSV blobs, specifies a comma-delimited list of column headers, useful for mapping source fields to destination fields in an index. </summary>
        public string DelimitedTextHeaders
        {
            get => Get<string>(DelimitedTextHeadersKey);
            set => Set(DelimitedTextHeadersKey, value);
        }

        /// <summary> For CSV blobs, specifies the end-of-line single-character delimiter for CSV files where each line starts a new document (for example, &quot;|&quot;). </summary>
        public string DelimitedTextDelimiter
        {
            get => Get<string>(DelimitedTextDelimiterKey);
            set => Set(DelimitedTextDelimiterKey, value);
        }

        /// <summary> For CSV blobs, indicates that the first (non-blank) line of each blob contains headers. </summary>
        public bool? FirstLineContainsHeaders
        {
            get => Get<bool?>(FirstLineContainsHeadersKey);
            set => Set(FirstLineContainsHeadersKey, value);
        }

        /// <summary> For JSON arrays, given a structured or semi-structured document, you can specify a path to the array using this property. </summary>
        public string DocumentRoot
        {
            get => Get<string>(DocumentRootKey);
            set => Set(DocumentRootKey, value);
        }

        /// <summary> Specifies the data to extract from Azure blob storage and tells the indexer which data to extract from image content when &quot;imageAction&quot; is set to a value other than &quot;none&quot;.  This applies to embedded image content in a .PDF or other application, or image files such as .jpg and .png, in Azure blobs. </summary>
        public BlobIndexerDataToExtract? DataToExtract
        {
            get => Get(DataToExtractKey, value => new BlobIndexerDataToExtract(value));
            set => Set(DataToExtractKey, value);
        }

        /// <summary> Determines how to process embedded images and image files in Azure blob storage.  Setting the &quot;imageAction&quot; configuration to any value other than &quot;none&quot; requires that a skillset also be attached to that indexer. </summary>
        public BlobIndexerImageAction? ImageAction
        {
            get => Get(ImageActionKey, value => new BlobIndexerImageAction(value));
            set => Set(ImageActionKey, value);
        }

        /// <summary> If true, will create a path //document//file_data that is an object representing the original file data downloaded from your blob data source.  This allows you to pass the original file data to a custom skill for processing within the enrichment pipeline, or to the Document Extraction skill. </summary>
        public bool? AllowSkillsetToReadFileData
        {
            get => Get<bool?>(AllowSkillsetToReadFileDataKey);
            set => Set(AllowSkillsetToReadFileDataKey, value);
        }

        /// <summary> Determines algorithm for text extraction from PDF files in Azure blob storage. </summary>
        public BlobIndexerPdfTextRotationAlgorithm? PdfTextRotationAlgorithm
        {
            get => Get(PdfTextRotationAlgorithmKey, value => new BlobIndexerPdfTextRotationAlgorithm(value));
            set => Set(PdfTextRotationAlgorithmKey, value);
        }

        /// <summary> Specifies the environment in which the indexer should execute. </summary>
        public IndexerExecutionEnvironment? ExecutionEnvironment
        {
            get => Get(ExecutionEnvironmentKey, value => new IndexerExecutionEnvironment(value));
            set => Set(ExecutionEnvironmentKey, value);
        }

        /// <summary> Increases the timeout beyond the 5-minute default for Azure SQL database data sources, specified in the format &quot;hh:mm:ss&quot;. </summary>
        public string QueryTimeout
        {
            get => Get<string>(QueryTimeoutKey);
            set => Set(QueryTimeoutKey, value);
        }

        /// <summary>
        /// Gets a new dictionary that aggregates well-known properties and additional properties.
        /// </summary>
        /// <returns></returns>
        internal IDictionary<string, object> Aggregate() =>
            LazyInitializer.EnsureInitialized(ref _aggregate, () => new AggregateIndexingParametersConfiguration(this));

        /// <summary>
        /// Gets a value from the well-known property dictionary.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="key">The key of the property.</param>
        /// <returns>The value from the well-known property dictionary.</returns>
        private T Get<T>(string key) =>
            _properties.TryGetValue(key, out object value) ? (T)value : default;

        /// <summary>
        /// Gets a value from the well-known property dictionary.
        /// </summary>
        /// <typeparam name="T">The property type.</typeparam>
        /// <param name="key">The key of the property.</param>
        /// <param name="factory">A factory method used to create the type from a string.</param>
        /// <returns>The value from the well-known property dictionary.</returns>
        private T? Get<T>(string key, Func<string, T> factory) where T : struct
        {
            if (_properties.TryGetValue(key, out object value))
            {
                return value switch
                {
                    // Stored as T when set via IndexingParametersConfiguration or Configuration using a T:
                    T val => val,

                    // Stored as a string when set via Configuration using a string value:
                    string str => factory(str),

                    // Set in JSON as explicit null:
                    null => null,

                    // Unknown type requires further investigation rather than potential data loss:
                    object obj => throw new InvalidCastException($"Unable to cast object of type '{obj.GetType()}' to type {typeof(T)}'.")
                };
            }

            return null;
        }

        /// <summary>
        /// Sets the value of a well-known property, or remove it if <paramref name="value"/> is null.
        /// </summary>
        /// <typeparam name="T">The type of the well-known property.</typeparam>
        /// <param name="key">They key of the property.</param>
        /// <param name="value">The value of the property.</param>
        private void Set<T>(string key, T value) where T : class
        {
            if (value is null)
            {
                _properties.Remove(key);
            }
            else
            {
                _properties[key] = value;
            }
        }

        /// <summary>
        /// Sets the value of a well-known property, or remove it if <paramref name="value"/> has no value set.
        /// </summary>
        /// <typeparam name="T">The type of the well-known property.</typeparam>
        /// <param name="key">They key of the property.</param>
        /// <param name="value">The value of the property.</param>
        private void Set<T>(string key, T? value) where T : struct
        {
            if (value.HasValue)
            {
                _properties[key] = value;
            }
            else
            {
                _properties.Remove(key);
            }
        }

        /// <summary>
        /// Aggregates the well-known properties and additional properties of the parent <see cref="IndexingParametersConfiguration"/>.
        /// </summary>
        private class AggregateIndexingParametersConfiguration : AggregateDictionary<string, object>
        {
            private readonly IndexingParametersConfiguration _parent;

            /// <summary>
            /// Creates a new instance of the <see cref="AggregateIndexingParametersConfiguration"/> class.
            /// </summary>
            /// <param name="parent">The parent <see cref="IndexingParametersConfiguration"/>.</param>
            public AggregateIndexingParametersConfiguration(IndexingParametersConfiguration parent) :
                base(new[] { parent._properties, parent })
            {
                _parent = parent;
            }

            /// <inheritdoc/>
            protected override void Set(string key, object value)
            {
                Debug.Assert(key != null);

                switch (key)
                {
                    case ParsingModeKey:
                    case ExcludedFileNameExtensionsKey:
                    case IndexedFileNameExtensionsKey:
                    case FailOnUnsupportedContentTypeKey:
                    case FailOnUnprocessableDocumentKey:
                    case IndexStorageMetadataOnlyForOversizedDocumentsKey:
                    case DelimitedTextHeadersKey:
                    case DelimitedTextDelimiterKey:
                    case FirstLineContainsHeadersKey:
                    case DocumentRootKey:
                    case DataToExtractKey:
                    case ImageActionKey:
                    case AllowSkillsetToReadFileDataKey:
                    case PdfTextRotationAlgorithmKey:
                    case ExecutionEnvironmentKey:
                    case QueryTimeoutKey:
                        _parent._properties[key] = value;
                        break;

                    default:
                        _parent[key] = value;
                        break;
                }
            }
        }
    }
}
