// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Helper class that acts as a factory for read-only models, to mock the types in <c>Azure.Search.Documents.Models</c>.
    /// </summary>
    [CodeGenModel("SearchDocumentsModelFactory")]
    [CodeGenSuppress("IndexDocumentsResult", typeof(IReadOnlyList<IndexingResult>))]
    public static partial class SearchModelFactory
    {
        /// <summary> Initializes a new instance of AnalyzedTokenInfo. </summary>
        /// <param name="token"> The token returned by the analyzer. </param>
        /// <param name="startOffset"> The index of the first character of the token in the input text. </param>
        /// <param name="endOffset"> The index of the last character of the token in the input text. </param>
        /// <param name="position"> The position of the token in the input text relative to other tokens. The first token in the input text has position 0, the next has position 1, and so on. Depending on the analyzer used, some tokens might have the same position, for example if they are synonyms of each other. </param>
        /// <returns> A new AnalyzedTokenInfo instance for mocking. </returns>
        public static AnalyzedTokenInfo AnalyzedTokenInfo(
            string token,
            int startOffset,
            int endOffset,
            int position) =>
            new AnalyzedTokenInfo(token, startOffset, endOffset, position);

        /// <summary> Initializes a new instance of CharFilter. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the char filter. </param>
        /// <param name="name"> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public static CharFilter CharFilter(
            string oDataType,
            string name) =>
            new CharFilter(oDataType, name, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of CognitiveServicesAccount. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the cognitive service resource attached to a skillset. </param>
        /// <param name="description"> Description of the cognitive service resource attached to a skillset. </param>
        public static CognitiveServicesAccount CognitiveServicesAccount(
            string oDataType,
            string description) =>
            new CognitiveServicesAccount(oDataType, description, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of DataChangeDetectionPolicy. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the data change detection policy. </param>
        public static DataChangeDetectionPolicy DataChangeDetectionPolicy(
            string oDataType) =>
            new DataChangeDetectionPolicy(oDataType, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of DataDeletionDetectionPolicy. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the data deletion detection policy. </param>
        public static DataDeletionDetectionPolicy DataDeletionDetectionPolicy(
            string oDataType) =>
            new DataDeletionDetectionPolicy(oDataType, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of IndexerExecutionResult. </summary>
        /// <param name="status"> The outcome of this indexer execution. </param>
        /// <param name="errorMessage"> The error message indicating the top-level error, if any. </param>
        /// <param name="startTime"> The start time of this indexer execution. </param>
        /// <param name="endTime"> The end time of this indexer execution, if the execution has already completed. </param>
        /// <param name="errors"> The item-level indexing errors. </param>
        /// <param name="warnings"> The item-level indexing warnings. </param>
        /// <param name="itemCount"> The number of items that were processed during this indexer execution. This includes both successfully processed items and items where indexing was attempted but failed. </param>
        /// <param name="failedItemCount"> The number of items that failed to be indexed during this indexer execution. </param>
        /// <param name="initialTrackingState"> Change tracking state with which an indexer execution started. </param>
        /// <param name="finalTrackingState"> Change tracking state with which an indexer execution finished. </param>
        /// <returns> A new IndexerExecutionResult instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IndexerExecutionResult IndexerExecutionResult(
            IndexerExecutionStatus status,
            string errorMessage,
            DateTimeOffset? startTime,
            DateTimeOffset? endTime,
            IReadOnlyList<SearchIndexerError> errors,
            IReadOnlyList<SearchIndexerWarning> warnings,
            int itemCount,
            int failedItemCount,
            string initialTrackingState,
            string finalTrackingState) =>
            new IndexerExecutionResult(status, errorMessage, startTime, endTime, errors, warnings, itemCount, failedItemCount, initialTrackingState, finalTrackingState, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of IndexerExecutionResult. </summary>
        /// <param name="status"> The outcome of this indexer execution. </param>
        /// <param name="errorMessage"> The error message indicating the top-level error, if any. </param>
        /// <param name="startTime"> The start time of this indexer execution. </param>
        /// <param name="endTime"> The end time of this indexer execution, if the execution has already completed. </param>
        /// <param name="errors"> The item-level indexing errors. </param>
        /// <param name="warnings"> The item-level indexing warnings. </param>
        /// <param name="itemCount"> The number of items that were processed during this indexer execution. This includes both successfully processed items and items where indexing was attempted but failed. </param>
        /// <param name="failedItemCount"> The number of items that failed to be indexed during this indexer execution. </param>
        /// <param name="initialTrackingState"> Change tracking state with which an indexer execution started. </param>
        /// <param name="finalTrackingState"> Change tracking state with which an indexer execution finished. </param>
        /// <returns> A new <see cref="Indexes.Models.IndexerExecutionResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IndexerExecutionResult IndexerExecutionResult(
            IndexerExecutionStatus status = default,
            string errorMessage = null,
            DateTimeOffset? startTime = null,
            DateTimeOffset? endTime = null,
            IEnumerable<SearchIndexerError> errors = null,
            IEnumerable<SearchIndexerWarning> warnings = null,
            int itemCount = default,
            int failedItemCount = default,
            string initialTrackingState = null,
            string finalTrackingState = null)
        {
            errors ??= new List<SearchIndexerError>();
            warnings ??= new List<SearchIndexerWarning>();

            return new IndexerExecutionResult(status, errorMessage, startTime, endTime, errors?.ToList(), warnings?.ToList(), itemCount, failedItemCount, initialTrackingState, finalTrackingState, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of LexicalAnalyzer. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the analyzer. </param>
        /// <param name="name"> The name of the analyzer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public static LexicalAnalyzer LexicalAnalyzer(
            string oDataType,
            string name) =>
            new LexicalAnalyzer(oDataType, name, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of LexicalTokenizer. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public static LexicalTokenizer LexicalTokenizer(
            string oDataType,
            string name) =>
            new LexicalTokenizer(oDataType, name, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of ScoringFunction. </summary>
        /// <param name="type"> Indicates the type of function to use. Valid values include magnitude, freshness, distance, and tag. The function type must be lower case. </param>
        /// <param name="fieldName"> The name of the field used as input to the scoring function. </param>
        /// <param name="boost"> A multiplier for the raw score. Must be a positive number not equal to 1.0. </param>
        /// <param name="interpolation"> A value indicating how boosting will be interpolated across document scores; defaults to &quot;Linear&quot;. </param>
        public static ScoringFunction ScoringFunction(
            string type,
            string fieldName,
            double boost,
            ScoringFunctionInterpolation? interpolation) =>
            new ScoringFunction(type, fieldName, boost, interpolation, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of SearchIndexerError. </summary>
        /// <param name="key"> The key of the item for which indexing failed. </param>
        /// <param name="errorMessage"> The message describing the error that occurred while processing the item. </param>
        /// <param name="statusCode"> The status code indicating why the indexing operation failed. Possible values include: 400 for a malformed input document, 404 for document not found, 409 for a version conflict, 422 when the index is temporarily unavailable, or 503 for when the service is too busy. </param>
        /// <param name="name"> The name of the source at which the error originated. For example, this could refer to a particular skill in the attached skillset. This may not be always available. </param>
        /// <param name="details"> Additional, verbose details about the error to assist in debugging the indexer. This may not be always available. </param>
        /// <param name="documentationLink"> A link to a troubleshooting guide for these classes of errors. This may not be always available. </param>
        /// <returns> A new SearchIndexerError instance for mocking. </returns>
        public static SearchIndexerError SearchIndexerError(
            string key,
            string errorMessage,
            int statusCode,
            string name,
            string details,
            string documentationLink) =>
            new SearchIndexerError(key, errorMessage, statusCode, name, details, documentationLink, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of SearchIndexerLimits. </summary>
        /// <param name="maxRunTime"> The maximum duration that the indexer is permitted to run for one execution. </param>
        /// <param name="maxDocumentExtractionSize"> The maximum size of a document, in bytes, which will be considered valid for indexing. </param>
        /// <param name="maxDocumentContentCharactersToExtract"> The maximum number of characters that will be extracted from a document picked up for indexing. </param>
        /// <returns> A new SearchIndexerLimits instance for mocking. </returns>
        public static SearchIndexerLimits SearchIndexerLimits(
            TimeSpan? maxRunTime,
            long? maxDocumentExtractionSize,
            long? maxDocumentContentCharactersToExtract) =>
            new SearchIndexerLimits(maxRunTime, maxDocumentExtractionSize, maxDocumentContentCharactersToExtract, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of SearchIndexerSkill. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the skill. </param>
        /// <param name="name"> The name of the skill which uniquely identifies it within the skillset. A skill with no name defined will be given a default name of its 1-based index in the skills array, prefixed with the character &apos;#&apos;. </param>
        /// <param name="description"> The description of the skill which describes the inputs, outputs, and usage of the skill. </param>
        /// <param name="context"> Represents the level at which operations take place, such as the document root or document content (for example, /document or /document/content). The default is /document. </param>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        public static SearchIndexerSkill SearchIndexerSkill(
            string oDataType,
            string name,
            string description,
            string context,
            IList<InputFieldMappingEntry> inputs,
            IList<OutputFieldMappingEntry> outputs) =>
            new SearchIndexerSkill(oDataType, name, description, context, inputs, outputs, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of SearchIndexerStatus. </summary>
        /// <param name="status"> Overall indexer status. </param>
        /// <param name="lastResult"> The result of the most recent or an in-progress indexer execution. </param>
        /// <param name="executionHistory"> History of the recent indexer executions, sorted in reverse chronological order. </param>
        /// <param name="limits"> The execution limits for the indexer. </param>
        /// <returns> A new SearchIndexerStatus instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndexerStatus SearchIndexerStatus(
            IndexerStatus status,
            IndexerExecutionResult lastResult,
            IReadOnlyList<IndexerExecutionResult> executionHistory,
            SearchIndexerLimits limits) =>
            new SearchIndexerStatus(default, status, lastResult, executionHistory, limits, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of <see cref="Indexes.Models.SearchIndexerStatus"/>. </summary>
        /// <param name="status"> Overall indexer status. </param>
        /// <param name="lastResult"> The result of the most recent or an in-progress indexer execution. </param>
        /// <param name="executionHistory"> History of the recent indexer executions, sorted in reverse chronological order. </param>
        /// <param name="limits"> The execution limits for the indexer. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndexerStatus"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndexerStatus SearchIndexerStatus(IndexerStatus status = default, IndexerExecutionResult lastResult = null, IEnumerable<IndexerExecutionResult> executionHistory = null, SearchIndexerLimits limits = null)
        {
            executionHistory ??= new List<IndexerExecutionResult>();

            return new SearchIndexerStatus(default, status, lastResult, executionHistory?.ToList(), limits, serializedAdditionalRawData: null);
        }

        /// <summary> Initializes a new instance of SearchIndexerWarning. </summary>
        /// <param name="key"> The key of the item which generated a warning. </param>
        /// <param name="message"> The message describing the warning that occurred while processing the item. </param>
        /// <param name="name"> The name of the source at which the warning originated. For example, this could refer to a particular skill in the attached skillset. This may not be always available. </param>
        /// <param name="details"> Additional, verbose details about the warning to assist in debugging the indexer. This may not be always available. </param>
        /// <param name="documentationLink"> A link to a troubleshooting guide for these classes of warnings. This may not be always available. </param>
        /// <returns> A new SearchIndexerWarning instance for mocking. </returns>
        public static SearchIndexerWarning SearchIndexerWarning(
            string key,
            string message,
            string name,
            string details,
            string documentationLink) =>
            new SearchIndexerWarning(key, message, name, details, documentationLink, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of SearchIndexStatistics. </summary>
        /// <param name="documentCount"> The number of documents in the index. </param>
        /// <param name="storageSize"> The amount of storage in bytes consumed by the index. </param>
        /// <returns> A new SearchIndexStatistics instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndexStatistics SearchIndexStatistics(
            long documentCount,
            long storageSize) =>
            new SearchIndexStatistics(documentCount, storageSize, vectorIndexSize: default);

        /// <summary> Initializes a new instance of SearchResourceCounter. </summary>
        /// <param name="usage"> The resource usage amount. </param>
        /// <param name="quota"> The resource amount quota. </param>
        /// <returns> A new SearchResourceCounter instance for mocking. </returns>
        public static SearchResourceCounter SearchResourceCounter(
            long usage,
            long? quota) =>
            new SearchResourceCounter(usage, quota, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of SearchServiceCounters. </summary>
        /// <param name="documentCounter"> Total number of documents across all indexes in the service. </param>
        /// <param name="indexCounter"> Total number of indexes. </param>
        /// <param name="indexerCounter"> Total number of indexers. </param>
        /// <param name="dataSourceCounter"> Total number of data sources. </param>
        /// <param name="storageSizeCounter"> Total size of used storage in bytes. </param>
        /// <param name="synonymMapCounter"> Total number of synonym maps. </param>
        /// <returns> A new SearchServiceCounters instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceCounters SearchServiceCounters(
            SearchResourceCounter documentCounter,
            SearchResourceCounter indexCounter,
            SearchResourceCounter indexerCounter,
            SearchResourceCounter dataSourceCounter,
            SearchResourceCounter storageSizeCounter,
            SearchResourceCounter synonymMapCounter) =>
            new SearchServiceCounters(documentCounter, indexCounter, indexerCounter, dataSourceCounter, storageSizeCounter, synonymMapCounter, skillsetCounter: null, null);

        /// <summary> Initializes a new instance of SearchServiceCounters. </summary>
        /// <param name="documentCounter"> Total number of documents across all indexes in the service. </param>
        /// <param name="indexCounter"> Total number of indexes. </param>
        /// <param name="indexerCounter"> Total number of indexers. </param>
        /// <param name="dataSourceCounter"> Total number of data sources. </param>
        /// <param name="storageSizeCounter"> Total size of used storage in bytes. </param>
        /// <param name="synonymMapCounter"> Total number of synonym maps. </param>
        /// <param name="skillsetCounter"> Total number of skillsets. </param>
        /// <returns> A new SearchServiceCounters instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceCounters SearchServiceCounters(
            SearchResourceCounter documentCounter,
            SearchResourceCounter indexCounter,
            SearchResourceCounter indexerCounter,
            SearchResourceCounter dataSourceCounter,
            SearchResourceCounter storageSizeCounter,
            SearchResourceCounter synonymMapCounter,
            SearchResourceCounter skillsetCounter) =>
            new SearchServiceCounters(documentCounter, indexCounter, indexerCounter, dataSourceCounter, storageSizeCounter, synonymMapCounter, skillsetCounter, null);

        // <summary> Initializes a new instance of SearchServiceCounters. </summary>
        /// <param name="documentCounter"> Total number of documents across all indexes in the service. </param>
        /// <param name="indexCounter"> Total number of indexes. </param>
        /// <param name="indexerCounter"> Total number of indexers. </param>
        /// <param name="dataSourceCounter"> Total number of data sources. </param>
        /// <param name="storageSizeCounter"> Total size of used storage in bytes. </param>
        /// <param name="synonymMapCounter"> Total number of synonym maps. </param>
        /// <param name="skillsetCounter"> Total number of skillsets. </param>
        /// <param name="vectorIndexSizeCounter"> Total memory consumption of all vector indexes within the service, in bytes. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchServiceCounters"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceCounters SearchServiceCounters(
            SearchResourceCounter documentCounter = null,
            SearchResourceCounter indexCounter = null,
            SearchResourceCounter indexerCounter = null,
            SearchResourceCounter dataSourceCounter = null,
            SearchResourceCounter storageSizeCounter = null,
            SearchResourceCounter synonymMapCounter = null,
            SearchResourceCounter skillsetCounter = null,
            SearchResourceCounter vectorIndexSizeCounter = null) =>
            new SearchServiceCounters(documentCounter, indexCounter, indexerCounter, dataSourceCounter, storageSizeCounter, synonymMapCounter, skillsetCounter, vectorIndexSizeCounter);

        /// <summary> Initializes a new instance of SearchServiceLimits. </summary>
        /// <param name="maxFieldsPerIndex"> The maximum allowed fields per index. </param>
        /// <param name="maxFieldNestingDepthPerIndex"> The maximum depth which you can nest sub-fields in an index, including the top-level complex field. For example, a/b/c has a nesting depth of 3. </param>
        /// <param name="maxComplexCollectionFieldsPerIndex"> The maximum number of fields of type Collection(Edm.ComplexType) allowed in an index. </param>
        /// <param name="maxComplexObjectsInCollectionsPerDocument"> The maximum number of objects in complex collections allowed per document. </param>
        /// <returns> A new SearchServiceLimits instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceLimits SearchServiceLimits(
        int? maxFieldsPerIndex,
        int? maxFieldNestingDepthPerIndex,
        int? maxComplexCollectionFieldsPerIndex,
        int? maxComplexObjectsInCollectionsPerDocument) =>
        new SearchServiceLimits(maxFieldsPerIndex, maxFieldNestingDepthPerIndex, maxComplexCollectionFieldsPerIndex, maxComplexObjectsInCollectionsPerDocument, null, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of SearchServiceStatistics. </summary>
        /// <param name="counters"> Service level resource counters. </param>
        /// <param name="limits"> Service level general limits. </param>
        /// <returns> A new SearchServiceStatistics instance for mocking. </returns>
        public static SearchServiceStatistics SearchServiceStatistics(
            SearchServiceCounters counters,
            SearchServiceLimits limits) =>
            new SearchServiceStatistics(counters, limits);

        /// <summary> Initializes a new instance of SimilarityAlgorithm. </summary>
        /// <param name="oDataType"> . </param>
        public static SimilarityAlgorithm SimilarityAlgorithm(
            string oDataType) =>
            new SimilarityAlgorithm(oDataType, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of TokenFilter. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public static TokenFilter TokenFilter(
            string oDataType,
            string name) =>
            new TokenFilter(oDataType, name, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of AutocompleteResults. </summary>
        /// <param name="coverage"> A value indicating the percentage of the index that was considered by the autocomplete request, or null if minimumCoverage was not specified in the request. </param>
        /// <param name="results"> The list of returned Autocompleted items. </param>
        /// <returns> A new AutocompleteResults instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AutocompleteResults AutocompleteResults(
            double? coverage,
            IReadOnlyList<AutocompleteItem> results) =>
            new AutocompleteResults(coverage, results, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of AutocompleteItem. </summary>
        /// <param name="text"> The completed term. </param>
        /// <param name="queryPlusText"> The query along with the completed term. </param>
        /// <returns> A new AutocompleteItem instance for mocking. </returns>
        public static AutocompleteItem AutocompleteItem(
            string text,
            string queryPlusText) =>
            new AutocompleteItem(text, queryPlusText);

        /// <summary> Initializes a new instance of FacetResult. </summary>
        /// <param name="count"> The approximate count of documents falling within the bucket described by this facet. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        /// <returns> A new <see cref="Models.FacetResult"/> instance for mocking. </returns>
        /// <example>
        /// This sample shows how to mock <see cref="Models.FacetResult"/> type.
        /// <code><![CDATA[
        /// var count = 2;
        /// var additionalProperties = new Dictionary<string, object>()
        /// {
        ///      ["value"] = "Luxury"
        /// }
        /// var facetResult = SearchModelFactory.FacetResult(count, additionalProperties);
        /// Assert.AreEqual(count, facetResult.Count);
        ///
        /// var additionalProperty = additionalProperties.First();
        /// Assert.AreEqual(additionalProperty.Value, facetResult.TryGetValue(additionalProperty.Key, out object value) ? value : null);
        /// ]]></code>
        /// </example>
        /// <remarks> For more details please refer <see href="https://docs.microsoft.com/en-us/rest/api/searchservice/search-documents#query-parameters"/></remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FacetResult FacetResult(long? count = null, IReadOnlyDictionary<string, object> additionalProperties = null)
        {
            additionalProperties ??= new Dictionary<string, object>();

            return new FacetResult(count, additionalProperties);
        }

        /// <summary> Initializes a new instance of IndexDocumentsResult. </summary>
        /// <param name="results"> The list of status information for each document in the indexing request. </param>
        /// <returns> A new IndexDocumentsResult instance for mocking. </returns>
        public static IndexDocumentsResult IndexDocumentsResult(
            IEnumerable<IndexingResult> results) =>
            new IndexDocumentsResult(results);

        /// <summary> Initializes a new instance of IndexingResult. </summary>
        /// <param name="key"> The key of a document that was in the indexing request. </param>
        /// <param name="errorMessage"> The error message explaining why the indexing operation failed for the document identified by the key; null if indexing succeeded. </param>
        /// <param name="succeeded"> A value indicating whether the indexing operation succeeded for the document identified by the key. </param>
        /// <param name="status"> The status code of the indexing operation. Possible values include: 200 for a successful update or delete, 201 for successful document creation, 400 for a malformed input document, 404 for document not found, 409 for a version conflict, 422 when the index is temporarily unavailable, or 503 for when the service is too busy. </param>
        /// <returns> A new IndexingResult instance for mocking. </returns>
        public static IndexingResult IndexingResult(
            string key,
            string errorMessage,
            bool succeeded,
            int status) =>
            new IndexingResult(key, errorMessage, succeeded, status, serializedAdditionalRawData: null);
    }
}
