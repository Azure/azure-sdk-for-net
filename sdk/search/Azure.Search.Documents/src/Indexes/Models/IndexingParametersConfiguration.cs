// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class IndexingParametersConfiguration : IDictionary<string, object>
    {
        private const string QueryTimeoutFormat = @"hh\:mm\:ss";
        private IDictionary<string, object> _additionalProperties;

        [CodeGenMember("QueryTimeout")]
        private string _queryTimeout;

        internal IndexingParametersConfiguration(
            BlobIndexerParsingMode? parsingMode,
            string excludedFileNameExtensions,
            string indexedFileNameExtensions,
            bool? failOnUnsupportedContentType,
            bool? failOnUnprocessableDocument,
            bool? indexStorageMetadataOnlyForOversizedDocuments,
            string delimitedTextHeaders,
            string delimitedTextDelimiter,
            bool? firstLineContainsHeaders,
            MarkdownParsingSubmode? markdownParsingSubmode,
            MarkdownHeaderDepth? markdownHeaderDepth,
            string documentRoot,
            BlobIndexerDataToExtract? dataToExtract,
            BlobIndexerImageAction? imageAction,
            bool? allowSkillsetToReadFileData,
            BlobIndexerPdfTextRotationAlgorithm? pdfTextRotationAlgorithm,
            IndexerExecutionEnvironment? executionEnvironment,
            bool? refreshAllAcls,
            string queryTimeout,
            IDictionary<string, object> additionalProperties)
        {
            ParsingMode = parsingMode;
            ExcludedFileNameExtensions = excludedFileNameExtensions;
            IndexedFileNameExtensions = indexedFileNameExtensions;
            FailOnUnsupportedContentType = failOnUnsupportedContentType;
            FailOnUnprocessableDocument = failOnUnprocessableDocument;
            IndexStorageMetadataOnlyForOversizedDocuments = indexStorageMetadataOnlyForOversizedDocuments;
            DelimitedTextHeaders = delimitedTextHeaders;
            DelimitedTextDelimiter = delimitedTextDelimiter;
            FirstLineContainsHeaders = firstLineContainsHeaders;
            MarkdownParsingSubmode = markdownParsingSubmode;
            MarkdownHeaderDepth = markdownHeaderDepth;
            DocumentRoot = documentRoot;
            DataToExtract = dataToExtract;
            ImageAction = imageAction;
            AllowSkillsetToReadFileData = allowSkillsetToReadFileData;
            PdfTextRotationAlgorithm = pdfTextRotationAlgorithm;
            ExecutionEnvironment = executionEnvironment;
            RefreshAllAcls = refreshAllAcls;
            _queryTimeout = queryTimeout;
            _additionalProperties = additionalProperties;
        }

        internal IDictionary<string, object> AdditionalProperties
        {
            get
            {
                if (_additionalProperties == null)
                {
                    IDictionary<string, object> additionalProperties = new ChangeTrackingDictionary<string, object>();
                    if (_additionalBinaryDataProperties != null)
                    {
                        foreach (KeyValuePair<string, BinaryData> property in _additionalBinaryDataProperties)
                        {
                            if (property.Value == null)
                            {
                                additionalProperties.Add(property.Key, null);
                            }
                            else
                            {
                                using JsonDocument document = JsonDocument.Parse(property.Value);
                                additionalProperties.Add(property.Key, document.RootElement.GetObject());
                            }
                        }
                    }
                    _additionalProperties = additionalProperties;
                }
                return _additionalProperties;
            }
        }

        /// <summary>
        /// Increases the timeout beyond the 5-minute default for Azure SQL database data sources.
        /// </summary>
        public TimeSpan? QueryTimeout
        {
            get => _queryTimeout != null ? TimeSpan.ParseExact(_queryTimeout, QueryTimeoutFormat, CultureInfo.InvariantCulture) : (TimeSpan?)null;
            set => _queryTimeout = value?.ToString(QueryTimeoutFormat, CultureInfo.InvariantCulture) ?? null;
        }

        /// <summary>
        /// Sets all well-known properties to null and clears <see cref="AdditionalProperties"/>.
        /// </summary>
        internal void Reset()
        {
            foreach ((Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set) in WellKnownProperties.Values)
            {
                Set(this, null);
            }

            AdditionalProperties.Clear();
        }

        /// <summary>
        /// Gets a collection of properties declared by the model, along with getters and setters.
        /// </summary>
        internal static IDictionary<string, (Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set)> WellKnownProperties { get; } =
            new Dictionary<string, (Func<IndexingParametersConfiguration, object> Get, Action<IndexingParametersConfiguration, object> Set)>
            {
                { "parsingMode", (o => o.ParsingMode, (o, v) => o.ParsingMode = ConvertTo(v, s => new BlobIndexerParsingMode(s))) },
                { "excludedFileNameExtensions", (o => o.ExcludedFileNameExtensions, (o, v) => o.ExcludedFileNameExtensions = (string) v) },
                { "indexedFileNameExtensions", (o => o.IndexedFileNameExtensions, (o, v) => o.IndexedFileNameExtensions = (string) v) },
                { "failOnUnsupportedContentType", (o => o.FailOnUnsupportedContentType, (o, v) => o.FailOnUnsupportedContentType = (bool?) v) },
                { "failOnUnprocessableDocument", (o => o.FailOnUnprocessableDocument, (o, v) => o.FailOnUnprocessableDocument = (bool?) v) },
                { "indexStorageMetadataOnlyForOversizedDocuments", (o => o.IndexStorageMetadataOnlyForOversizedDocuments, (o, v) => o.IndexStorageMetadataOnlyForOversizedDocuments = (bool?) v) },
                { "delimitedTextHeaders", (o => o.DelimitedTextHeaders, (o, v) => o.DelimitedTextHeaders = (string) v) },
                { "delimitedTextDelimiter", (o => o.DelimitedTextDelimiter, (o, v) => o.DelimitedTextDelimiter = (string) v) },
                { "firstLineContainsHeaders", (o => o.FirstLineContainsHeaders, (o, v) => o.FirstLineContainsHeaders = (bool?) v) },
                { "markdownParsingSubmode", (o => o.MarkdownParsingSubmode, (o, v) => o.MarkdownParsingSubmode = ConvertTo(v, s => new MarkdownParsingSubmode(s))) },
                { "markdownHeaderDepth", (o => o.MarkdownHeaderDepth, (o, v) => o.MarkdownHeaderDepth = ConvertTo(v, s => new MarkdownHeaderDepth(s))) },
                { "documentRoot", (o => o.DocumentRoot, (o, v) => o.DocumentRoot = (string) v) },
                { "dataToExtract", (o => o.DataToExtract, (o, v) => o.DataToExtract = ConvertTo(v, s => new BlobIndexerDataToExtract(s))) },
                { "imageAction", (o => o.ImageAction, (o, v) => o.ImageAction = ConvertTo(v, s => new BlobIndexerImageAction(s))) },
                { "allowSkillsetToReadFileData", (o => o.AllowSkillsetToReadFileData, (o, v) => o.AllowSkillsetToReadFileData = (bool?) v) },
                { "pdfTextRotationAlgorithm", (o => o.PdfTextRotationAlgorithm, (o, v) => o.PdfTextRotationAlgorithm = ConvertTo(v, s => new BlobIndexerPdfTextRotationAlgorithm(s))) },
                { "executionEnvironment", (o => o.ExecutionEnvironment, (o, v) => o.ExecutionEnvironment = ConvertTo(v, s => new IndexerExecutionEnvironment(s))) },
                { "refreshAllAcls", (o => o.RefreshAllAcls, (o, v) => o.RefreshAllAcls = (bool?) v) },
                { "queryTimeout", (o => o.QueryTimeout, (o, v) => o.QueryTimeout = ConvertTo(v, s => TimeSpan.ParseExact(s, QueryTimeoutFormat, CultureInfo.InvariantCulture))) },
            };

        /// <summary>
        /// Converts different possible value types to a value type of <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The value type to convert to.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="factory">A factory method to convert a string to a value type of <typeparamref name="T"/>.</param>
        /// <returns>A nullable value of type <typeparamref name="T"/>.</returns>
        /// <exception cref="InvalidCastException">The <paramref name="value"/> could not be converted to a value of type <typeparamref name="T"/>.</exception>
        private static T? ConvertTo<T>(object value, Func<string, T> factory) where T : struct => value switch
        {
            // Stored as T when set via IndexingParametersConfiguration or Configuration using a T:
            T v => v,

            // Stored as a string when set via Configuration using a string value:
            string s => factory(s),

            // Set in JSON as explicit null:
            null => null,

            // Unknown type requires further investigation rather than potential data loss:
            object obj => throw new InvalidCastException($"Unable to cast object of type '{obj.GetType()}' to type {typeof(T)}'.")
        };

        /// <inheritdoc />
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => AdditionalProperties.GetEnumerator();
        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => AdditionalProperties.GetEnumerator();
        /// <inheritdoc />
        public bool TryGetValue(string key, out object value) => AdditionalProperties.TryGetValue(key, out value);
        /// <inheritdoc />
        public bool ContainsKey(string key) => AdditionalProperties.ContainsKey(key);
        /// <inheritdoc />
        public ICollection<string> Keys => AdditionalProperties.Keys;
        /// <inheritdoc />
        public ICollection<object> Values => AdditionalProperties.Values;
        /// <inheritdoc cref="ICollection{T}.Count"/>
        int ICollection<KeyValuePair<string, object>>.Count => AdditionalProperties.Count;
        /// <inheritdoc />
        public void Add(string key, object value) => AdditionalProperties.Add(key, value);
        /// <inheritdoc />
        public bool Remove(string key) => AdditionalProperties.Remove(key);
        /// <inheritdoc cref="ICollection{T}.IsReadOnly"/>
        bool ICollection<KeyValuePair<string, object>>.IsReadOnly => AdditionalProperties.IsReadOnly;
        /// <inheritdoc cref="ICollection{T}.Add"/>
        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> value) => AdditionalProperties.Add(value);
        /// <inheritdoc cref="ICollection{T}.Remove"/>
        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> value) => AdditionalProperties.Remove(value);
        /// <inheritdoc cref="ICollection{T}.Contains"/>
        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> value) => AdditionalProperties.Contains(value);
        /// <inheritdoc cref="ICollection{T}.CopyTo"/>
        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] destination, int offset) => AdditionalProperties.CopyTo(destination, offset);
        /// <inheritdoc cref="ICollection{T}.Clear"/>
        void ICollection<KeyValuePair<string, object>>.Clear() => AdditionalProperties.Clear();
        /// <inheritdoc />
        public object this[string key]
        {
            get => AdditionalProperties[key];
            set => AdditionalProperties[key] = value;
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<IndexingParametersConfiguration>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(IndexingParametersConfiguration)} does not support writing '{format}' format.");
            }
            if (Optional.IsDefined(ParsingMode))
            {
                writer.WritePropertyName("parsingMode"u8);
                writer.WriteStringValue(ParsingMode.Value.ToString());
            }
            if (Optional.IsDefined(ExcludedFileNameExtensions))
            {
                writer.WritePropertyName("excludedFileNameExtensions"u8);
                writer.WriteStringValue(ExcludedFileNameExtensions);
            }
            if (Optional.IsDefined(IndexedFileNameExtensions))
            {
                writer.WritePropertyName("indexedFileNameExtensions"u8);
                writer.WriteStringValue(IndexedFileNameExtensions);
            }
            if (Optional.IsDefined(FailOnUnsupportedContentType))
            {
                writer.WritePropertyName("failOnUnsupportedContentType"u8);
                writer.WriteBooleanValue(FailOnUnsupportedContentType.Value);
            }
            if (Optional.IsDefined(FailOnUnprocessableDocument))
            {
                writer.WritePropertyName("failOnUnprocessableDocument"u8);
                writer.WriteBooleanValue(FailOnUnprocessableDocument.Value);
            }
            if (Optional.IsDefined(IndexStorageMetadataOnlyForOversizedDocuments))
            {
                writer.WritePropertyName("indexStorageMetadataOnlyForOversizedDocuments"u8);
                writer.WriteBooleanValue(IndexStorageMetadataOnlyForOversizedDocuments.Value);
            }
            if (Optional.IsDefined(DelimitedTextHeaders))
            {
                writer.WritePropertyName("delimitedTextHeaders"u8);
                writer.WriteStringValue(DelimitedTextHeaders);
            }
            if (Optional.IsDefined(DelimitedTextDelimiter))
            {
                writer.WritePropertyName("delimitedTextDelimiter"u8);
                writer.WriteStringValue(DelimitedTextDelimiter);
            }
            if (Optional.IsDefined(FirstLineContainsHeaders))
            {
                writer.WritePropertyName("firstLineContainsHeaders"u8);
                writer.WriteBooleanValue(FirstLineContainsHeaders.Value);
            }
            if (Optional.IsDefined(MarkdownParsingSubmode, _markdownParsingSubmodeIsDefined))
            {
                if (MarkdownParsingSubmode != null)
                {
                    writer.WritePropertyName("markdownParsingSubmode"u8);
                    writer.WriteStringValue(MarkdownParsingSubmode.Value.ToString());
                }
                else
                {
                    writer.WriteNull("markdownParsingSubmode"u8);
                }
            }
            if (Optional.IsDefined(MarkdownHeaderDepth, _markdownHeaderDepthIsDefined))
            {
                if (MarkdownHeaderDepth != null)
                {
                    writer.WritePropertyName("markdownHeaderDepth"u8);
                    writer.WriteStringValue(MarkdownHeaderDepth.Value.ToString());
                }
                else
                {
                    writer.WriteNull("markdownHeaderDepth"u8);
                }
            }
            if (Optional.IsDefined(DocumentRoot))
            {
                writer.WritePropertyName("documentRoot"u8);
                writer.WriteStringValue(DocumentRoot);
            }
            if (Optional.IsDefined(DataToExtract))
            {
                writer.WritePropertyName("dataToExtract"u8);
                writer.WriteStringValue(DataToExtract.Value.ToString());
            }
            if (Optional.IsDefined(ImageAction))
            {
                writer.WritePropertyName("imageAction"u8);
                writer.WriteStringValue(ImageAction.Value.ToString());
            }
            if (Optional.IsDefined(AllowSkillsetToReadFileData))
            {
                writer.WritePropertyName("allowSkillsetToReadFileData"u8);
                writer.WriteBooleanValue(AllowSkillsetToReadFileData.Value);
            }
            if (Optional.IsDefined(PdfTextRotationAlgorithm))
            {
                writer.WritePropertyName("pdfTextRotationAlgorithm"u8);
                writer.WriteStringValue(PdfTextRotationAlgorithm.Value.ToString());
            }
            if (Optional.IsDefined(ExecutionEnvironment))
            {
                writer.WritePropertyName("executionEnvironment"u8);
                writer.WriteStringValue(ExecutionEnvironment.Value.ToString());
            }
            if (Optional.IsDefined(RefreshAllAcls))
            {
                writer.WritePropertyName("refreshAllAcls"u8);
                writer.WriteBooleanValue(RefreshAllAcls.Value);
            }
            if (Optional.IsDefined(_queryTimeout))
            {
                writer.WritePropertyName("queryTimeout"u8);
                writer.WriteStringValue(_queryTimeout);
            }
            // Configuration entries are service inputs even when their keys are not modeled by the SDK.
            foreach (KeyValuePair<string, object> property in AdditionalProperties)
            {
                writer.WritePropertyName(property.Key);
                writer.WriteObjectValue(property.Value, options);
            }
        }

        /// <param name="element"> The JSON element to deserialize. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        internal static IndexingParametersConfiguration DeserializeIndexingParametersConfiguration(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            BlobIndexerParsingMode? parsingMode = default;
            string excludedFileNameExtensions = default;
            string indexedFileNameExtensions = default;
            bool? failOnUnsupportedContentType = default;
            bool? failOnUnprocessableDocument = default;
            bool? indexStorageMetadataOnlyForOversizedDocuments = default;
            string delimitedTextHeaders = default;
            string delimitedTextDelimiter = default;
            bool? firstLineContainsHeaders = default;
            MarkdownParsingSubmode? markdownParsingSubmode = default;
            MarkdownHeaderDepth? markdownHeaderDepth = default;
            string documentRoot = default;
            BlobIndexerDataToExtract? dataToExtract = default;
            BlobIndexerImageAction? imageAction = default;
            bool? allowSkillsetToReadFileData = default;
            BlobIndexerPdfTextRotationAlgorithm? pdfTextRotationAlgorithm = default;
            IndexerExecutionEnvironment? executionEnvironment = default;
            bool? refreshAllAcls = default;
            string queryTimeout = default;
            IDictionary<string, object> additionalProperties = new ChangeTrackingDictionary<string, object>();
            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("parsingMode"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    parsingMode = new BlobIndexerParsingMode(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("excludedFileNameExtensions"u8))
                {
                    excludedFileNameExtensions = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("indexedFileNameExtensions"u8))
                {
                    indexedFileNameExtensions = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("failOnUnsupportedContentType"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failOnUnsupportedContentType = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("failOnUnprocessableDocument"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    failOnUnprocessableDocument = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("indexStorageMetadataOnlyForOversizedDocuments"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    indexStorageMetadataOnlyForOversizedDocuments = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("delimitedTextHeaders"u8))
                {
                    delimitedTextHeaders = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("delimitedTextDelimiter"u8))
                {
                    delimitedTextDelimiter = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("firstLineContainsHeaders"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    firstLineContainsHeaders = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("markdownParsingSubmode"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        markdownParsingSubmode = null;
                        continue;
                    }
                    markdownParsingSubmode = new MarkdownParsingSubmode(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("markdownHeaderDepth"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        markdownHeaderDepth = null;
                        continue;
                    }
                    markdownHeaderDepth = new MarkdownHeaderDepth(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("documentRoot"u8))
                {
                    documentRoot = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("dataToExtract"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    dataToExtract = new BlobIndexerDataToExtract(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("imageAction"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    imageAction = new BlobIndexerImageAction(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("allowSkillsetToReadFileData"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    allowSkillsetToReadFileData = prop.Value.GetBoolean();
                    continue;
                }
                if (prop.NameEquals("pdfTextRotationAlgorithm"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    pdfTextRotationAlgorithm = new BlobIndexerPdfTextRotationAlgorithm(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("executionEnvironment"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    executionEnvironment = new IndexerExecutionEnvironment(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("queryTimeout"u8))
                {
                    queryTimeout = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("refreshAllAcls"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    refreshAllAcls = prop.Value.GetBoolean();
                    continue;
                }
                additionalProperties.Add(prop.Name, prop.Value.GetObject());
            }
            return new IndexingParametersConfiguration(
                parsingMode,
                excludedFileNameExtensions,
                indexedFileNameExtensions,
                failOnUnsupportedContentType,
                failOnUnprocessableDocument,
                indexStorageMetadataOnlyForOversizedDocuments,
                delimitedTextHeaders,
                delimitedTextDelimiter,
                firstLineContainsHeaders,
                markdownParsingSubmode,
                markdownHeaderDepth,
                documentRoot,
                dataToExtract,
                imageAction,
                allowSkillsetToReadFileData,
                pdfTextRotationAlgorithm,
                executionEnvironment,
                refreshAllAcls,
                queryTimeout,
                additionalProperties);
        }
    }
}
