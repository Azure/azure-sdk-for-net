// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class IndexingParametersConfiguration
    {
        private const string QueryTimeoutFormat = @"hh\:mm\:ss";

        [CodeGenMember("QueryTimeout")]
        private string _queryTimeout;

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
                { "documentRoot", (o => o.DocumentRoot, (o, v) => o.DocumentRoot = (string) v) },
                { "dataToExtract", (o => o.DataToExtract, (o, v) => o.DataToExtract = ConvertTo(v, s => new BlobIndexerDataToExtract(s))) },
                { "imageAction", (o => o.ImageAction, (o, v) => o.ImageAction = ConvertTo(v, s => new BlobIndexerImageAction(s))) },
                { "allowSkillsetToReadFileData", (o => o.AllowSkillsetToReadFileData, (o, v) => o.AllowSkillsetToReadFileData = (bool?) v) },
                { "pdfTextRotationAlgorithm", (o => o.PdfTextRotationAlgorithm, (o, v) => o.PdfTextRotationAlgorithm = ConvertTo(v, s => new BlobIndexerPdfTextRotationAlgorithm(s))) },
                { "executionEnvironment", (o => o.ExecutionEnvironment, (o, v) => o.ExecutionEnvironment = ConvertTo(v, s => new IndexerExecutionEnvironment(s))) },
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
    }
}
