// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
using Azure.Search.Documents.Utilities;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Models
{
    /// <summary>
    /// Helper class that acts as a factory for read-only models, to mock the types in <c>Azure.Search.Documents.Models</c>.
    /// Renames generated SearchDocumentsModelFactory to SearchModelFactory.
    /// </summary>
    [CodeGenType("DocumentsModelFactory")]
    [CodeGenSuppress("IndexDocumentsResult", typeof(IReadOnlyList<IndexingResult>))]
    [CodeGenSuppress(nameof(ScoringFunction), typeof(ScoringFunctionInterpolation?), typeof(string))]
    public static partial class SearchModelFactory
    {
        /// <summary> Initializes a new instance of ScoringFunction. </summary>
        /// <param name="fieldName"> The name of the field used as input to the scoring function. </param>
        /// <param name="boost"> The multiplier for the raw score. </param>
        /// <param name="interpolation"> The interpolation to apply to document scores. </param>
        /// <param name="type"> The scoring function type. </param>
        public static ScoringFunction ScoringFunction(
            string fieldName = null,
            double boost = 0,
            ScoringFunctionInterpolation? interpolation = default,
            string type = null) =>
            new ScoringFunction(fieldName, boost, interpolation, type, additionalBinaryDataProperties: null);

        /// <summary> Represents an agentic reasoning activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. </param>
        /// <param name="reasoningTokens"> The number of input tokens for agentic reasoning. </param>
        /// <param name="retrievalReasoningEffort"> The retrieval reasoning effort configuration. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KnowledgeBaseAgenticReasoningActivityRecord KnowledgeBaseAgenticReasoningActivityRecord(int id = default, int? elapsedMs = default, KnowledgeBaseErrorDetail error = default, int? reasoningTokens = default, KnowledgeRetrievalReasoningEffort retrievalReasoningEffort = default)
        {
            return KnowledgeBaseAgenticReasoningActivityRecord(id, startedOn: null, completedOn: null, elapsedMs, error, warning: null, reasoningTokens, retrievalReasoningEffort, logicalReasoningEffort: null);
        }

        /// <summary> Represents an agentic reasoning activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="reasoningTokens"> The number of input tokens for agentic reasoning. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord"/> instance for mocking. </returns>
        /// <remarks> All arguments are required to keep calls that omit arguments unambiguous with the 12.0.0 overload. </remarks>
        public static KnowledgeBaseAgenticReasoningActivityRecord KnowledgeBaseAgenticReasoningActivityRecord(int id, DateTimeOffset? startedOn, DateTimeOffset? completedOn, int? elapsedMs, KnowledgeBaseErrorDetail error, string warning, int? reasoningTokens)
        {
            return KnowledgeBaseAgenticReasoningActivityRecord(id, startedOn, completedOn, elapsedMs, error, warning, reasoningTokens, retrievalReasoningEffort: null, logicalReasoningEffort: null);
        }

        /// <summary> Specifies an Azure Machine Learning endpoint deployed via the Azure AI Foundry Model Catalog for generating the vector embedding of a query string. </summary>
        /// <param name="vectorizerName"> The name to associate with this particular vectorization method. </param>
        /// <param name="amlParameters"> Specifies the properties of the AML vectorizer. </param>
        /// <returns> A new <see cref="Indexes.Models.AzureMachineLearningVectorizer"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AzureMachineLearningVectorizer AzureMachineLearningVectorizer(string vectorizerName = default, AzureMachineLearningParameters amlParameters = default) =>
            new AzureMachineLearningVectorizer(vectorizerName, VectorSearchVectorizerKind.AML, additionalBinaryDataProperties: null, amlParameters);

        /// <summary> Specifies the properties for connecting to an AML vectorizer. </summary>
        /// <param name="scoringUri"> The scoring URI of the AML service. </param>
        /// <param name="authenticationKey"> The key for the AML service. </param>
        /// <param name="resourceId"> The Azure Resource Manager resource ID of the AML service. </param>
        /// <param name="timeout"> The timeout for the HTTP client making the API call. </param>
        /// <param name="region"> The region the AML service is deployed in. </param>
        /// <param name="modelName"> The name of the embedding model from the Azure AI Foundry Catalog. </param>
        /// <returns> A new <see cref="Indexes.Models.AzureMachineLearningParameters"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AzureMachineLearningParameters AzureMachineLearningParameters(Uri scoringUri = default, string authenticationKey = default, string resourceId = default, TimeSpan? timeout = default, string region = default, AIFoundryModelCatalogName? modelName = default) =>
            new AzureMachineLearningParameters(scoringUri, authenticationKey, resourceId, timeout, region, modelName, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of <see cref="Models.VectorizableImageBinaryQuery"/> for mocking. </summary>
        /// <param name="kNearestNeighborsCount"> Number of nearest neighbors to return as top hits. </param>
        /// <param name="fieldsRaw"> Comma-separated vector fields to search. </param>
        /// <param name="exhaustive"> Whether to use exhaustive nearest neighbor search. </param>
        /// <param name="oversampling"> The oversampling factor. </param>
        /// <param name="weight"> The relative weight of the vector query. </param>
        /// <param name="base64Image"> The base64-encoded image to vectorize. </param>
        /// <returns> A new <see cref="Models.VectorizableImageBinaryQuery"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VectorizableImageBinaryQuery VectorizableImageBinaryQuery(int? kNearestNeighborsCount = default, string fieldsRaw = default, bool? exhaustive = default, double? oversampling = default, float? weight = default, string base64Image = default) =>
            VectorizableImageBinaryQuery(kNearestNeighborsCount, fieldsRaw, exhaustive, oversampling, weight, threshold: null, filterOverride: null, base64Image: base64Image);

        /// <summary> Initializes a new instance of <see cref="Models.VectorizableImageUrlQuery"/> for mocking. </summary>
        /// <param name="kNearestNeighborsCount"> Number of nearest neighbors to return as top hits. </param>
        /// <param name="fieldsRaw"> Comma-separated vector fields to search. </param>
        /// <param name="exhaustive"> Whether to use exhaustive nearest neighbor search. </param>
        /// <param name="oversampling"> The oversampling factor. </param>
        /// <param name="weight"> The relative weight of the vector query. </param>
        /// <param name="url"> The URL of the image to vectorize. </param>
        /// <returns> A new <see cref="Models.VectorizableImageUrlQuery"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VectorizableImageUrlQuery VectorizableImageUrlQuery(int? kNearestNeighborsCount = default, string fieldsRaw = default, bool? exhaustive = default, double? oversampling = default, float? weight = default, Uri url = default) =>
            VectorizableImageUrlQuery(kNearestNeighborsCount, fieldsRaw, exhaustive, oversampling, weight, threshold: null, filterOverride: null, url: url);

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
            new AnalyzedTokenInfo(token, startOffset, endOffset, position, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of CharFilter. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the char filter. </param>
        /// <param name="name"> The name of the char filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public static CharFilter CharFilter(
            string oDataType,
            string name) =>
            new CharFilter(oDataType, name, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of CognitiveServicesAccount. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the cognitive service resource attached to a skillset. </param>
        /// <param name="description"> Description of the cognitive service resource attached to a skillset. </param>
        public static CognitiveServicesAccount CognitiveServicesAccount(
            string oDataType,
            string description) =>
            new CognitiveServicesAccount(oDataType, description, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of DataChangeDetectionPolicy. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the data change detection policy. </param>
        public static DataChangeDetectionPolicy DataChangeDetectionPolicy(
            string oDataType) =>
            new DataChangeDetectionPolicy(oDataType, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of DataDeletionDetectionPolicy. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the data deletion detection policy. </param>
        public static DataDeletionDetectionPolicy DataDeletionDetectionPolicy(
            string oDataType) =>
            new DataDeletionDetectionPolicy(oDataType, additionalBinaryDataProperties: null);

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
            IndexerExecutionResult(status, statusDetail: null, mode: null, errorMessage, startTime, endTime, errors, warnings, itemCount, failedItemCount, initialTrackingState, finalTrackingState);

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
            return IndexerExecutionResult(status, statusDetail: null, mode: null, errorMessage, startTime, endTime, errors, warnings, itemCount, failedItemCount, initialTrackingState, finalTrackingState);
        }

        /// <summary> Initializes a new instance of LexicalAnalyzer. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the analyzer. </param>
        /// <param name="name"> The name of the analyzer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public static LexicalAnalyzer LexicalAnalyzer(
            string oDataType,
            string name) =>
            new LexicalAnalyzer(oDataType, name, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of LexicalTokenizer. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the tokenizer. </param>
        /// <param name="name"> The name of the tokenizer. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public static LexicalTokenizer LexicalTokenizer(
            string oDataType,
            string name) =>
            new LexicalTokenizer(oDataType, name, additionalBinaryDataProperties: null);

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
            new ScoringFunction(fieldName, boost, interpolation, type, additionalBinaryDataProperties: null);

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
            new SearchIndexerError(key, errorMessage, statusCode, name, details, documentationLink, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of SearchIndexerLimits. </summary>
        /// <param name="maxRunTime"> The maximum duration that the indexer is permitted to run for one execution. </param>
        /// <param name="maxDocumentExtractionSize"> The maximum size of a document, in bytes, which will be considered valid for indexing. </param>
        /// <param name="maxDocumentContentCharactersToExtract"> The maximum number of characters that will be extracted from a document picked up for indexing. </param>
        /// <returns> A new SearchIndexerLimits instance for mocking. </returns>
        public static SearchIndexerLimits SearchIndexerLimits(
            TimeSpan? maxRunTime,
            long? maxDocumentExtractionSize,
            long? maxDocumentContentCharactersToExtract) =>
            new SearchIndexerLimits(maxRunTime, maxDocumentExtractionSize, maxDocumentContentCharactersToExtract, additionalBinaryDataProperties: null);

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
            new SearchIndexerSkill(oDataType, name, description, context, inputs, outputs, additionalBinaryDataProperties: null);

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
            SearchIndexerStatus(name: null, status, runtime: null, lastResult, executionHistory, limits, currentState: null);

        /// <summary> Initializes a new instance of <see cref="Indexes.Models.SearchIndexerStatus"/>. </summary>
        /// <param name="status"> Overall indexer status. </param>
        /// <param name="lastResult"> The result of the most recent or an in-progress indexer execution. </param>
        /// <param name="executionHistory"> History of the recent indexer executions, sorted in reverse chronological order. </param>
        /// <param name="limits"> The execution limits for the indexer. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndexerStatus"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndexerStatus SearchIndexerStatus(IndexerStatus status = default, IndexerExecutionResult lastResult = null, IEnumerable<IndexerExecutionResult> executionHistory = null, SearchIndexerLimits limits = null)
        {
            return SearchIndexerStatus(name: null, status, runtime: null, lastResult, executionHistory, limits, currentState: null);
        }

        /// <summary> Initializes a new instance of <see cref="Indexes.Models.SearchIndexerStatus"/>. </summary>
        /// <param name="name"> The name of the indexer. </param>
        /// <param name="status"> Overall indexer status. </param>
        /// <param name="lastResult"> The result of the most recent or an in-progress indexer execution. </param>
        /// <param name="executionHistory"> History of the recent indexer executions, sorted in reverse chronological order. </param>
        /// <param name="limits"> The execution limits for the indexer. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndexerStatus"/> instance for mocking. </returns>
        public static SearchIndexerStatus SearchIndexerStatus(string name = null, IndexerStatus status = default, IndexerExecutionResult lastResult = null, IEnumerable<IndexerExecutionResult> executionHistory = null, SearchIndexerLimits limits = null)
        {
            return SearchIndexerStatus(name, status, runtime: null, lastResult, executionHistory, limits, currentState: null);
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
            new SearchIndexerWarning(key, message, name, details, documentationLink, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of SearchIndexStatistics. </summary>
        /// <param name="documentCount"> The number of documents in the index. </param>
        /// <param name="storageSize"> The amount of storage in bytes consumed by the index. </param>
        /// <returns> A new SearchIndexStatistics instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndexStatistics SearchIndexStatistics(
            long documentCount,
            long storageSize) =>
            new SearchIndexStatistics(documentCount, storageSize, vectorIndexSize: default, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of SearchResourceCounter. </summary>
        /// <param name="usage"> The resource usage amount. </param>
        /// <param name="quota"> The resource amount quota. </param>
        /// <returns> A new SearchResourceCounter instance for mocking. </returns>
        public static SearchResourceCounter SearchResourceCounter(
            long usage,
            long? quota) =>
            new SearchResourceCounter(usage, quota, additionalBinaryDataProperties: null);

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
            SearchServiceCounters(aliasCounter: null, documentCounter, indexCounter, indexerCounter, dataSourceCounter, storageSizeCounter, synonymMapCounter, skillsetCounter: null, vectorIndexSizeCounter: null, knowledgeBaseCounter: null, knowledgeSourceCounter: null);

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
            SearchServiceCounters(aliasCounter: null, documentCounter, indexCounter, indexerCounter, dataSourceCounter, storageSizeCounter, synonymMapCounter, skillsetCounter, vectorIndexSizeCounter: null, knowledgeBaseCounter: null, knowledgeSourceCounter: null);

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
            SearchResourceCounter documentCounter,
            SearchResourceCounter indexCounter,
            SearchResourceCounter indexerCounter,
            SearchResourceCounter dataSourceCounter,
            SearchResourceCounter storageSizeCounter,
            SearchResourceCounter synonymMapCounter,
            SearchResourceCounter skillsetCounter,
            SearchResourceCounter vectorIndexSizeCounter) =>
            SearchServiceCounters(aliasCounter: null, documentCounter, indexCounter, indexerCounter, dataSourceCounter, storageSizeCounter, synonymMapCounter, skillsetCounter, vectorIndexSizeCounter, knowledgeBaseCounter: null, knowledgeSourceCounter: null);

        /// <summary> Initializes a new instance of SearchServiceLimits. </summary>
        /// <param name="maxFieldsPerIndex"> The maximum allowed fields per index. </param>
        /// <param name="maxFieldNestingDepthPerIndex"> The maximum depth which you can nest sub-fields in an index, including the top-level complex field. For example, a/b/c has a nesting depth of 3. </param>
        /// <param name="maxComplexCollectionFieldsPerIndex"> The maximum number of fields of type Collection(Edm.ComplexType) allowed in an index. </param>
        /// <param name="maxComplexObjectsInCollectionsPerDocument"> The maximum number of objects in complex collections allowed per document. </param>
        /// <param name="maxStoragePerIndexInBytes"> The maximum storage per index in bytes. </param>
        /// <returns> A new SearchServiceLimits instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceLimits SearchServiceLimits(
        int? maxFieldsPerIndex,
        int? maxFieldNestingDepthPerIndex,
        int? maxComplexCollectionFieldsPerIndex,
        int? maxComplexObjectsInCollectionsPerDocument,
        long? maxStoragePerIndexInBytes) =>
        SearchServiceLimits(maxFieldsPerIndex, maxFieldNestingDepthPerIndex, maxComplexCollectionFieldsPerIndex, maxComplexObjectsInCollectionsPerDocument, maxStoragePerIndexInBytes, maxCumulativeIndexerRuntimeSeconds: null, maxVectorIndexSizePerIndexInBytes: null);

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
        SearchServiceLimits(maxFieldsPerIndex, maxFieldNestingDepthPerIndex, maxComplexCollectionFieldsPerIndex, maxComplexObjectsInCollectionsPerDocument, maxStoragePerIndexInBytes: null, maxCumulativeIndexerRuntimeSeconds: null, maxVectorIndexSizePerIndexInBytes: null);

        /// <summary> Initializes a new instance of SearchServiceStatistics. </summary>
        /// <param name="counters"> Service level resource counters. </param>
        /// <param name="limits"> Service level general limits. </param>
        /// <returns> A new SearchServiceStatistics instance for mocking. </returns>
        public static SearchServiceStatistics SearchServiceStatistics(
            SearchServiceCounters counters,
            SearchServiceLimits limits) =>
            new SearchServiceStatistics(counters, limits, indexersRuntime: null, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of SimilarityAlgorithm. </summary>
        /// <param name="oDataType"> . </param>
        public static SimilarityAlgorithm SimilarityAlgorithm(
            string oDataType) =>
            new SimilarityAlgorithm(oDataType, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of TokenFilter. </summary>
        /// <param name="oDataType"> Identifies the concrete type of the token filter. </param>
        /// <param name="name"> The name of the token filter. It must only contain letters, digits, spaces, dashes or underscores, can only start and end with alphanumeric characters, and is limited to 128 characters. </param>
        public static TokenFilter TokenFilter(
            string oDataType,
            string name) =>
            new TokenFilter(oDataType, name, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of AutocompleteResults. </summary>
        /// <param name="coverage"> A value indicating the percentage of the index that was considered by the autocomplete request, or null if minimumCoverage was not specified in the request. </param>
        /// <param name="results"> The list of returned Autocompleted items. </param>
        /// <returns> A new AutocompleteResults instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AutocompleteResults AutocompleteResults(
            double? coverage,
            IReadOnlyList<AutocompleteItem> results) =>
            new AutocompleteResults(coverage, results, additionalBinaryDataProperties: null);

        /// <summary> Initializes a new instance of AutocompleteItem. </summary>
        /// <param name="text"> The completed term. </param>
        /// <param name="queryPlusText"> The query along with the completed term. </param>
        /// <returns> A new AutocompleteItem instance for mocking. </returns>
        public static AutocompleteItem AutocompleteItem(
            string text,
            string queryPlusText) =>
            new AutocompleteItem(text, queryPlusText, additionalBinaryDataProperties: null);

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
        public static FacetResult FacetResult(long? count, IReadOnlyDictionary<string, object> additionalProperties)
        {
            additionalProperties ??= new Dictionary<string, object>();

            return FacetResult(count, avg: null, min: null, additionalProperties: additionalProperties.ToBinaryDataDictionary());
        }

        /// <summary> Initializes a new instance of IndexDocumentsResult. </summary>
        /// <param name="results"> The list of status information for each document in the indexing request. </param>
        /// <returns> A new IndexDocumentsResult instance for mocking. </returns>
        public static IndexDocumentsResult IndexDocumentsResult(
            IEnumerable<IndexingResult> results) =>
            new IndexDocumentsResult([.. results], additionalBinaryDataProperties: null);

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
            new IndexingResult(key, errorMessage, succeeded, status, additionalBinaryDataProperties: null);

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexerChangeTrackingState"/> class.
        /// </summary>
        /// <param name="allDocumentsInitialState">Change tracking state used when indexing starts on all documents in the datasource.</param>
        /// <param name="allDocumentsFinalState">Change tracking state value when indexing finishes on all documents in the datasource.</param>
        /// <param name="resetDocumentsInitialState">Change tracking state used when indexing starts on select, reset documents in the datasource.</param>
        /// <param name="resetDocumentsFinalState">Change tracking state value when indexing finishes on select, reset documents in the datasource.</param>
        public static IndexerChangeTrackingState IndexerChangeTrackingState(
            string allDocumentsInitialState,
            string allDocumentsFinalState,
            string resetDocumentsInitialState,
            string resetDocumentsFinalState) =>
                new IndexerChangeTrackingState(
                    allDocumentsInitialState,
                    allDocumentsFinalState,
                    resetDocumentsInitialState,
                    resetDocumentsFinalState);

        /// <summary> Initializes a new instance of SearchIndex for mocking. </summary>
        /// <param name="name"> The name of the index. </param>
        /// <param name="description"> The description of the index. </param>
        /// <param name="scoringProfiles"> The scoring profiles for the index. </param>
        /// <param name="defaultScoringProfile"> The default scoring profile. </param>
        /// <param name="corsOptions"> The cross-origin resource sharing options. </param>
        /// <param name="suggesters"> The suggesters for the index. </param>
        /// <param name="analyzers"> The analyzers for the index. </param>
        /// <param name="tokenizers"> The tokenizers for the index. </param>
        /// <param name="tokenFilters"> The token filters for the index. </param>
        /// <param name="charFilters"> The character filters for the index. </param>
        /// <param name="normalizers"> The normalizers for the index. </param>
        /// <param name="encryptionKey"> The encryption key for the index. </param>
        /// <param name="similarity"> The similarity algorithm. </param>
        /// <param name="semanticSearch"> The semantic search configuration. </param>
        /// <param name="vectorSearch"> The vector search configuration. </param>
        /// <param name="fields"> The fields of the index. </param>
        /// <param name="etag"> The ETag of the index. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndex SearchIndex(string name = null, string description = null, IEnumerable<ScoringProfile> scoringProfiles = null, string defaultScoringProfile = null, CorsOptions corsOptions = null, IEnumerable<SearchSuggester> suggesters = null, IEnumerable<LexicalAnalyzer> analyzers = null, IEnumerable<LexicalTokenizer> tokenizers = null, IEnumerable<TokenFilter> tokenFilters = null, IEnumerable<CharFilter> charFilters = null, IEnumerable<LexicalNormalizer> normalizers = null, SearchResourceEncryptionKey encryptionKey = null, SimilarityAlgorithm similarity = null, SemanticSearch semanticSearch = null, VectorSearch vectorSearch = null, IEnumerable<SearchField> fields = null, string etag = null)
        {
            return SearchIndex(name: name, description: description, scoringProfiles: scoringProfiles, defaultScoringProfile: defaultScoringProfile, corsOptions: corsOptions, suggesters: suggesters, analyzers: analyzers, tokenizers: tokenizers, tokenFilters: tokenFilters, charFilters: charFilters, normalizers: normalizers, encryptionKey: encryptionKey, similarity: similarity, semanticSearch: semanticSearch, vectorSearch: vectorSearch, permissionFilterOption: default, sharePointConnectorAppRegistration: default, fields: fields, etag: etag);
        }

        /// <summary> Initializes a new instance of SearchIndex. </summary>
        /// <param name="name"> The name of the index. </param>
        /// <param name="description"> The description of the index. </param>
        /// <param name="fields"> The fields of the index. </param>
        /// <param name="scoringProfiles"> The scoring profiles for the index. </param>
        /// <param name="defaultScoringProfile"> The name of the scoring profile to use if none is specified in the query. If this property is not set and no scoring profile is specified in the query, then default scoring (tf-idf) will be used. </param>
        /// <param name="corsOptions"> Options to control Cross-Origin Resource Sharing (CORS) for the index. </param>
        /// <param name="suggesters"> The suggesters for the index. </param>
        /// <param name="analyzers">
        /// The analyzers for the index.
        /// Please note <see cref="LexicalAnalyzer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="CustomAnalyzer"/>, <see cref="PatternAnalyzer"/>, <see cref="LuceneStandardAnalyzer"/> and <see cref="StopAnalyzer"/>.
        /// </param>
        /// <param name="tokenizers">
        /// The tokenizers for the index.
        /// Please note <see cref="LexicalTokenizer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="ClassicTokenizer"/>, <see cref="EdgeNGramTokenizer"/>, <see cref="KeywordTokenizer"/>, <see cref="MicrosoftLanguageStemmingTokenizer"/>, <see cref="MicrosoftLanguageTokenizer"/>, <see cref="NGramTokenizer"/>, <see cref="PathHierarchyTokenizer"/>, <see cref="PatternTokenizer"/>, <see cref="LuceneStandardTokenizer"/> and <see cref="UaxUrlEmailTokenizer"/>.
        /// </param>
        /// <param name="tokenFilters">
        /// The token filters for the index.
        /// Please note <see cref="TokenFilter"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AsciiFoldingTokenFilter"/>, <see cref="CjkBigramTokenFilter"/>, <see cref="CommonGramTokenFilter"/>, <see cref="DictionaryDecompounderTokenFilter"/>, <see cref="EdgeNGramTokenFilter"/>, <see cref="ElisionTokenFilter"/>, <see cref="KeepTokenFilter"/>, <see cref="KeywordMarkerTokenFilter"/>, <see cref="LengthTokenFilter"/>, <see cref="LimitTokenFilter"/>, <see cref="NGramTokenFilter"/>, <see cref="PatternCaptureTokenFilter"/>, <see cref="PatternReplaceTokenFilter"/>, <see cref="PhoneticTokenFilter"/>, <see cref="ShingleTokenFilter"/>, <see cref="SnowballTokenFilter"/>, <see cref="StemmerOverrideTokenFilter"/>, <see cref="StemmerTokenFilter"/>, <see cref="StopwordsTokenFilter"/>, <see cref="SynonymTokenFilter"/>, <see cref="TruncateTokenFilter"/>, <see cref="UniqueTokenFilter"/> and <see cref="WordDelimiterTokenFilter"/>.
        /// </param>
        /// <param name="charFilters">
        /// The character filters for the index.
        /// Please note <see cref="CharFilter"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="MappingCharFilter"/> and <see cref="PatternReplaceCharFilter"/>.
        /// </param>
        /// <param name="normalizers">
        /// The normalizers for the index.
        /// Please note <see cref="LexicalNormalizer"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="CustomNormalizer"/>.
        /// </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your data when you want full assurance that no one, not even Microsoft, can decrypt your data. Once you have encrypted your data, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your data will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="similarity">
        /// The type of similarity algorithm to be used when scoring and ranking the documents matching a search query. The similarity algorithm can only be defined at index creation time and cannot be modified on existing indexes. If null, the ClassicSimilarity algorithm is used.
        /// Please note <see cref="SimilarityAlgorithm"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="BM25Similarity"/> and <see cref="ClassicSimilarity"/>.
        /// </param>
        /// <param name="semanticSearch"> Defines parameters for a search index that influence semantic capabilities. </param>
        /// <param name="vectorSearch"> Contains configuration options related to vector search. </param>
        /// <param name="etag"> The ETag of the index. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        public static SearchIndex SearchIndex(string name = null, string description = null, IList<SearchField> fields = null, IList<ScoringProfile> scoringProfiles = null, string defaultScoringProfile = null, CorsOptions corsOptions = null, IList<SearchSuggester> suggesters = null, IList<LexicalAnalyzer> analyzers = null, IList<LexicalTokenizer> tokenizers = null, IList<TokenFilter> tokenFilters = null, IList<CharFilter> charFilters = null, IList<LexicalNormalizer> normalizers = null, SearchResourceEncryptionKey encryptionKey = null, SimilarityAlgorithm similarity = null, SemanticSearch semanticSearch = null, VectorSearch vectorSearch = null, string etag = null, IDictionary<string, BinaryData> additionalBinaryDataProperties = null)
        {
            fields ??= new List<SearchField>();
            scoringProfiles ??= new List<ScoringProfile>();
            suggesters ??= new List<SearchSuggester>();
            analyzers ??= new List<LexicalAnalyzer>();
            tokenizers ??= new List<LexicalTokenizer>();
            tokenFilters ??= new List<TokenFilter>();
            charFilters ??= new List<CharFilter>();
            normalizers ??= new List<LexicalNormalizer>();
            additionalBinaryDataProperties ??= new Dictionary<string, BinaryData>();

            return new SearchIndex(name, description, graphProfile: null, scoringProfiles, defaultScoringProfile, corsOptions, suggesters, analyzers, tokenizers, tokenFilters, charFilters, normalizers, encryptionKey, similarity, semanticSearch, vectorSearch, permissionFilterOption: null, purviewEnabled: null, sharePointConnectorAppRegistration: null, oneLakeSecuritySource: null, fields, etag, additionalBinaryDataProperties);
        }

        /// <summary> Initializes a new instance of <see cref="SearchIndexerDataSourceConnection"/>. </summary>
        /// <param name="name"> The name of the datasource. </param>
        /// <param name="description"> The description of the datasource. </param>
        /// <param name="type"> The type of the datasource. </param>
        /// <param name="connectionString"> Credentials for the datasource. </param>
        /// <param name="container"> The data container for the datasource. </param>
        /// <param name="dataChangeDetectionPolicy">
        /// The data change detection policy for the datasource.
        /// The available derived classes include <see cref="HighWaterMarkChangeDetectionPolicy"/> and <see cref="SqlIntegratedChangeTrackingPolicy"/>.
        /// </param>
        /// <param name="dataDeletionDetectionPolicy">
        /// The data deletion detection policy for the datasource.
        /// The available derived classes include <see cref="SoftDeleteColumnDeletionDetectionPolicy"/>.
        /// </param>
        /// <param name="etag"> The ETag of the data source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your datasource definition when you want full assurance that no one, not even Microsoft, can decrypt your data source definition. Once you have encrypted your data source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your datasource definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        public static SearchIndexerDataSourceConnection SearchIndexerDataSourceConnection(string name = null, string description = null, SearchIndexerDataSourceType type = default, string connectionString = null, SearchIndexerDataContainer container = null, DataChangeDetectionPolicy dataChangeDetectionPolicy = null, DataDeletionDetectionPolicy dataDeletionDetectionPolicy = null, string etag = null, SearchResourceEncryptionKey encryptionKey = null, IDictionary<string, BinaryData> additionalBinaryDataProperties = null)
        {
            additionalBinaryDataProperties ??= new Dictionary<string, BinaryData>();

            return new SearchIndexerDataSourceConnection(name, description, type, connectionString, container, dataChangeDetectionPolicy, dataDeletionDetectionPolicy, etag, encryptionKey, additionalBinaryDataProperties);
        }

        /// <summary> Initializes a new instance of SearchIndexer. </summary>
        /// <param name="name"> The name of the indexer. </param>
        /// <param name="description"> The description of the indexer. </param>
        /// <param name="dataSourceName"> The name of the datasource from which this indexer reads data. </param>
        /// <param name="skillsetName"> The name of the skillset executing with this indexer. </param>
        /// <param name="targetIndexName"> The name of the index to which this indexer writes data. </param>
        /// <param name="schedule"> The schedule for this indexer. </param>
        /// <param name="parameters"> Parameters for indexer execution. </param>
        /// <param name="fieldMappings"> Defines mappings between fields in the data source and corresponding target fields in the index. </param>
        /// <param name="outputFieldMappings"> Output field mappings are applied after enrichment and immediately before indexing. </param>
        /// <param name="isDisabled"> A value indicating whether the indexer is disabled. Default is false. </param>
        /// <param name="etag"> The ETag of the indexer. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your indexer definition (as well as indexer execution status) when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your indexer definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your indexer definition (and indexer execution status) will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        public static SearchIndexer SearchIndexer(string name = null, string description = null, string dataSourceName = null, string skillsetName = null, string targetIndexName = null, IndexingSchedule schedule = null, IndexingParameters parameters = null, IList<FieldMapping> fieldMappings = null, IList<FieldMapping> outputFieldMappings = null, bool? isDisabled = null, ETag? etag = null, SearchResourceEncryptionKey encryptionKey = null, IDictionary<string, BinaryData> additionalBinaryDataProperties = null)
        {
            fieldMappings ??= new List<FieldMapping>();
            outputFieldMappings ??= new List<FieldMapping>();
            additionalBinaryDataProperties ??= new Dictionary<string, BinaryData>();

            return new SearchIndexer(name, description, dataSourceName, skillsetName, targetIndexName, schedule, parameters, fieldMappings, outputFieldMappings, isDisabled, etag, encryptionKey, cache: null, additionalBinaryDataProperties);
        }

        /// <summary> Initializes a new instance of SynonymMap. </summary>
        /// <param name="name"> The name of the synonym map. </param>
        /// <param name="format"> The format of the synonym map. Only the 'solr' format is currently supported. </param>
        /// <param name="synonyms"> A series of synonym rules in the specified synonym map format. The rules must be separated by newlines. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your data when you want full assurance that no one, not even Microsoft, can decrypt your data. Once you have encrypted your data, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your data will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="etag"> The ETag of the synonym map. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        public static SynonymMap SynonymMap(string name = null, string format = null, string synonyms = null, SearchResourceEncryptionKey encryptionKey = null, string etag = null, IDictionary<string, BinaryData> additionalBinaryDataProperties = null)
        {
            additionalBinaryDataProperties ??= new Dictionary<string, BinaryData>();

            return new SynonymMap(name, format, synonyms?.Split('\n'), encryptionKey, etag, additionalBinaryDataProperties);
        }

        /// <summary> Initializes a new instance of DocumentDebugInfo. </summary>
        /// <param name="vectors"> Contains debugging information specific to vector and hybrid search. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DocumentDebugInfo DocumentDebugInfo(VectorsDebugInfo vectors = null)
        {
            return DocumentDebugInfo(semantic: null, vectors, innerHits: null);
        }

        /// <summary> Initializes a new instance of QueryAnswerResult. </summary>
        /// <param name="score"> The score value represents how relevant the answer is to the query relative to other answers returned for the query. </param>
        /// <param name="key"> The key of the document the answer was extracted from. </param>
        /// <param name="text"> The text passage extracted from the document contents as the answer. </param>
        /// <param name="highlights"> Same text passage as in the Text property with highlighted text phrases most relevant to the query. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        public static QueryAnswerResult QueryAnswerResult(double? score = null, string key = null, string text = null, string highlights = null, IReadOnlyDictionary<string, object> additionalProperties = null)
        {
            return new QueryAnswerResult(score, key, text, highlights, additionalProperties?.ToDictionary(property => property.Key, property => property.Value));
        }

        /// <summary> Initializes a new instance of FacetResult. </summary>
        /// <param name="count"> The approximate count of documents falling within the bucket described by this facet. </param>
        /// <param name="additionalProperties"> Additional Properties. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FacetResult FacetResult(long? count, IDictionary<string, BinaryData> additionalProperties)
        {
            additionalProperties ??= new Dictionary<string, BinaryData>();

            return FacetResult(count, avg: null, min: null, additionalProperties: additionalProperties);
        }

        /// <summary> Initializes a new instance of FacetResult for mocking. </summary>
        /// <param name="additionalProperties"> Additional properties of the facet. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FacetResult FacetResult(IReadOnlyDictionary<string, object> additionalProperties) =>
            FacetResult(count: null, additionalProperties);

        // A single optional overload avoids ambiguity between the GA dictionary overloads and statistical facets.
        /// <summary> Initializes a new instance of FacetResult for mocking. </summary>
        /// <param name="count"> The approximate count of documents in the bucket. </param>
        /// <param name="avg"> The average value. </param>
        /// <param name="min"> The minimum value. </param>
        /// <param name="max"> The maximum value. </param>
        /// <param name="sum"> The sum of values. </param>
        /// <param name="cardinality"> The number of distinct values. </param>
        /// <param name="facets"> Nested facet results. </param>
        /// <param name="additionalProperties"> Additional properties of the facet. </param>
        public static FacetResult FacetResult(long? count = default, double? avg = default, double? min = default, double? max = default, double? sum = default, long? cardinality = default, IReadOnlyDictionary<string, IList<FacetResult>> facets = default, IDictionary<string, BinaryData> additionalProperties = default) =>
            new FacetResult(count, avg, min, max, sum, cardinality, facets, additionalProperties ?? new Dictionary<string, BinaryData>());

        /// <summary> Initializes a new instance of VectorQuery. </summary>
        /// <param name="kNearestNeighborsCount"> Number of nearest neighbors to return as top hits. </param>
        /// <param name="fieldsRaw"> Vector Fields of type Collection(Edm.Single) to be included in the vector searched. </param>
        /// <param name="exhaustive"> When true, triggers an exhaustive k-nearest neighbor search across all vectors within the vector index. </param>
        /// <param name="oversampling"> Oversampling factor. </param>
        /// <param name="weight"> Relative weight of the vector query when compared to other vector query and/or the text query within the same search request. </param>
        /// <param name="kind"> The kind of vector query being performed. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VectorQuery VectorQuery(int? kNearestNeighborsCount = default, string fieldsRaw = default, bool? exhaustive = default, double? oversampling = default, float? weight = default, string kind = default)
        {
            return VectorQuery(kNearestNeighborsCount, fieldsRaw, exhaustive, oversampling, weight, threshold: null, filterOverride: null, kind: kind);
        }

        /// <summary> Initializes a new instance of KnowledgeSource. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> The description of the knowledge source. </param>
        /// <param name="kind"> The type of the knowledge source. </param>
        /// <param name="eTag"> A string representing an ETag that can be used to perform optimistic concurrency control. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KnowledgeSource KnowledgeSource(string name = default, string description = default, string kind = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default)
        {
            return KnowledgeSource(name, description, kind, resultsProcessing: null, eTag, encryptionKey);
        }

        /// <summary> Initializes a new instance of KnowledgeBaseActivityRecord. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="type"> The type of the activity record. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KnowledgeBaseActivityRecord KnowledgeBaseActivityRecord(int id, string @type, int? elapsedMs, KnowledgeBaseErrorDetail error)
        {
            return KnowledgeBaseActivityRecord(id: id, @type: @type, elapsedMs: elapsedMs, error: error, warning: default);
        }

        /// <summary> Initializes a new instance of KnowledgeSourceParams. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data. </param>
        /// <param name="rerankerThreshold"> The reranker threshold. </param>
        /// <param name="kind"> The type of the knowledge source. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KnowledgeSourceParams KnowledgeSourceParams(string knowledgeSourceName, bool? includeReferences, bool? includeReferenceSourceData, float? rerankerThreshold, string kind)
        {
            return KnowledgeSourceParams(knowledgeSourceName: knowledgeSourceName, includeReferences: includeReferences, includeReferenceSourceData: includeReferenceSourceData, alwaysQuerySource: default, failOnError: default, rerankerThreshold: rerankerThreshold, maxOutputDocuments: default, kind: kind);
        }

        // Preserve GA positional calls; model construction stays in the generated factories.
        /// <summary> Parameters for filtering, sorting, faceting, paging, and other search query behaviors. </summary>
        /// <param name="includeTotalCount"> A value that specifies whether to fetch the total count of results. Default is false. Setting this value to true may have a performance impact. Note that the count returned is an approximation. </param>
        /// <param name="facets"> The list of facet expressions to apply to the search query. Each facet expression contains a field name, optionally followed by a comma-separated list of name:value pairs. </param>
        /// <param name="filter"> The OData $filter expression to apply to the search query. </param>
        /// <param name="highlightFieldsRaw"> The comma-separated list of field names to use for hit highlights. Only searchable fields can be used for hit highlighting. </param>
        /// <param name="highlightPostTag"> A string tag that is appended to hit highlights. Must be set with highlightPreTag. Default is &lt;/em&gt;. </param>
        /// <param name="highlightPreTag"> A string tag that is prepended to hit highlights. Must be set with highlightPostTag. Default is &lt;em&gt;. </param>
        /// <param name="minimumCoverage"> A number between 0 and 100 indicating the percentage of the index that must be covered by a search query in order for the query to be reported as a success. This parameter can be useful for ensuring search availability even for services with only one replica. The default is 100. </param>
        /// <param name="moreLikeThis"> The key of the document to use as the basis for finding similar documents. This parameter cannot be used together with search text. </param>
        /// <param name="orderByRaw"> The comma-separated list of OData $orderby expressions by which to sort the results. Each expression can be either a field name or a call to either the geo.distance() or the search.score() functions. Each expression can be followed by asc to indicate ascending, or desc to indicate descending. The default is ascending order. Ties will be broken by the match scores of documents. If no $orderby is specified, the default sort order is descending by document match score. There can be at most 32 $orderby clauses. </param>
        /// <param name="queryType"> A value that specifies the syntax of the search query. The default is 'simple'. Use 'full' if your query uses the Lucene query syntax. </param>
        /// <param name="scoringStatistics"> A value that specifies whether we want to calculate scoring statistics (such as document frequency) globally for more consistent scoring, or locally, for lower latency. The default is 'local'. Use 'global' to aggregate scoring statistics globally before scoring. Using global scoring statistics can increase latency of search queries. </param>
        /// <param name="sessionId"> A value to be used to create a sticky session, which can help getting more consistent results. As long as the same sessionId is used, a best-effort attempt will be made to target the same replica set. Be wary that reusing the same sessionID values repeatedly can interfere with the load balancing of the requests across replicas and adversely affect the performance of the search service. The value used as sessionId cannot start with a '_' character. </param>
        /// <param name="scoringParameters"> The list of parameter values to be used in scoring functions (for example, referencePointParameter) using the format name-values. For example, if the scoring profile defines a function with a parameter called 'mylocation' the parameter string would be "mylocation--122.2,44.8" (without the quotes). </param>
        /// <param name="scoringProfile"> The name of a scoring profile to evaluate match scores for matching documents in order to sort the results. </param>
        /// <param name="debug"> Enables a debugging tool that can be used to further explore your reranked results. </param>
        /// <param name="searchText"> A full-text search query expression; Use "*" or omit this parameter to match all documents. </param>
        /// <param name="searchFieldsRaw"> The comma-separated list of field names to which to scope the full-text search. When using fielded search (fieldName:searchExpression) in a full Lucene query, the field names of each fielded search expression take precedence over any field names listed in this parameter. </param>
        /// <param name="searchMode"> A value that specifies whether any or all of the search terms must be matched in order to count the document as a match. </param>
        /// <param name="selectRaw"> The comma-separated list of fields to retrieve. If unspecified, all fields marked as retrievable in the schema are included. </param>
        /// <param name="skip"> The number of search results to skip. This value cannot be greater than 100,000. If you need to scan documents in sequence, but cannot use skip due to this limitation, consider using orderby on a totally-ordered key and filter with a range query instead. </param>
        /// <param name="size"> The number of search results to retrieve. This can be used in conjunction with $skip to implement client-side paging of search results. If results are truncated due to server-side paging, the response will include a continuation token that can be used to issue another Search request for the next page of results. </param>
        /// <param name="semanticConfigurationName"> The name of a semantic configuration that will be used when processing documents for queries of type semantic. </param>
        /// <param name="semanticErrorMode"> Allows the user to choose whether a semantic call should fail completely (default / current behavior), or to return partial results. </param>
        /// <param name="semanticMaxWaitInMilliseconds"> Allows the user to set an upper bound on the amount of time it takes for semantic enrichment to finish processing before the request fails. </param>
        /// <param name="semanticQuery"> Allows setting a separate search query that will be solely used for semantic reranking, semantic captions and semantic answers. Is useful for scenarios where there is a need to use different queries between the base retrieval and ranking phase, and the L2 semantic phase. </param>
        /// <param name="queryAnswerRaw"> A value that specifies whether answers should be returned as part of the search response. </param>
        /// <param name="queryCaptionRaw"> A value that specifies whether captions should be returned as part of the search response. </param>
        /// <param name="vectorQueries"> The query parameters for vector and hybrid search queries. </param>
        /// <param name="filterMode"> Determines whether or not filters are applied before or after the vector search is performed. Default is 'preFilter' for new indexes. </param>
        /// <returns> A new <see cref="Documents.SearchOptions"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchOptions SearchOptions(bool? includeTotalCount = default, IEnumerable<string> facets = default, string filter = default, string highlightFieldsRaw = default, string highlightPostTag = default, string highlightPreTag = default, double? minimumCoverage = default, string moreLikeThis = default, string orderByRaw = default, SearchQueryType? queryType = default, ScoringStatistics? scoringStatistics = default, string sessionId = default, IEnumerable<string> scoringParameters = default, string scoringProfile = default, QueryDebugMode? debug = default, string searchText = default, string searchFieldsRaw = default, SearchMode? searchMode = default, string selectRaw = default, int? skip = default, int? size = default, string semanticConfigurationName = default, SemanticErrorMode? semanticErrorMode = default, int? semanticMaxWaitInMilliseconds = default, string semanticQuery = default, string queryAnswerRaw = default, string queryCaptionRaw = default, IEnumerable<VectorQuery> vectorQueries = default, VectorFilterMode? filterMode = default) =>
            SearchOptions(includeTotalCount: includeTotalCount, facets: facets, filter: filter, highlightFieldsRaw: highlightFieldsRaw, highlightPostTag: highlightPostTag, highlightPreTag: highlightPreTag, minimumCoverage: minimumCoverage, moreLikeThis: moreLikeThis, orderByRaw: orderByRaw, queryType: queryType, agenticOptions: default, scoringStatistics: scoringStatistics, sessionId: sessionId, scoringParameters: scoringParameters, scoringProfile: scoringProfile, debug: debug, searchText: searchText, searchFieldsRaw: searchFieldsRaw, searchMode: searchMode, queryLanguage: default, querySpeller: default, selectRaw: selectRaw, skip: skip, size: size, semanticConfigurationName: semanticConfigurationName, semanticErrorMode: semanticErrorMode, semanticMaxWaitInMilliseconds: semanticMaxWaitInMilliseconds, semanticQuery: semanticQuery, queryAnswerRaw: queryAnswerRaw, queryCaptionRaw: queryCaptionRaw, queryRewritesRaw: default, semanticFields: default, vectorQueries: vectorQueries, filterMode: filterMode, hybridSearch: default);

        /// <summary> Represents a field in an index definition, which describes the name, data type, and search behavior of a field. </summary>
        /// <param name="name"> The name of the field, which must be unique within the fields collection of the index or parent field. </param>
        /// <param name="type"> The data type of the field. </param>
        /// <param name="isKey"> A value indicating whether the field uniquely identifies documents in the index. Exactly one top-level field in each index must be chosen as the key field and it must be of type Edm.String. Key fields can be used to look up documents directly and update or delete specific documents. Default is false for simple fields and null for complex fields. </param>
        /// <param name="isRetrievable"> A value indicating whether the field can be returned in a search result. You can disable this option if you want to use a field (for example, margin) as a filter, sorting, or scoring mechanism but do not want the field to be visible to the end user. This property must be true for key fields, and it must be null for complex fields. This property can be changed on existing fields. Enabling this property does not cause any increase in index storage requirements. Default is true for simple fields, false for vector fields, and null for complex fields. </param>
        /// <param name="isStored"> An immutable value indicating whether the field will be persisted separately on disk to be returned in a search result. You can disable this option if you don't plan to return the field contents in a search response to save on storage overhead. This can only be set during index creation and only for vector fields. This property cannot be changed for existing fields or set as false for new fields. If this property is set as false, the property 'retrievable' must also be set to false. This property must be true or unset for key fields, for new fields, and for non-vector fields, and it must be null for complex fields. Disabling this property will reduce index storage requirements. The default is true for vector fields. </param>
        /// <param name="isSearchable"> A value indicating whether the field is full-text searchable. This means it will undergo analysis such as word-breaking during indexing. If you set a searchable field to a value like "sunny day", internally it will be split into the individual tokens "sunny" and "day". This enables full-text searches for these terms. Fields of type Edm.String or Collection(Edm.String) are searchable by default. This property must be false for simple fields of other non-string data types, and it must be null for complex fields. Note: searchable fields consume extra space in your index to accommodate additional tokenized versions of the field value for full-text searches. If you want to save space in your index and you don't need a field to be included in searches, set searchable to false. </param>
        /// <param name="isFilterable"> A value indicating whether to enable the field to be referenced in $filter queries. filterable differs from searchable in how strings are handled. Fields of type Edm.String or Collection(Edm.String) that are filterable do not undergo word-breaking, so comparisons are for exact matches only. For example, if you set such a field f to "sunny day", $filter=f eq 'sunny' will find no matches, but $filter=f eq 'sunny day' will. This property must be null for complex fields. Default is true for simple fields and null for complex fields. </param>
        /// <param name="isSortable"> A value indicating whether to enable the field to be referenced in $orderby expressions. By default, the search engine sorts results by score, but in many experiences users will want to sort by fields in the documents. A simple field can be sortable only if it is single-valued (it has a single value in the scope of the parent document). Simple collection fields cannot be sortable, since they are multi-valued. Simple sub-fields of complex collections are also multi-valued, and therefore cannot be sortable. This is true whether it's an immediate parent field, or an ancestor field, that's the complex collection. Complex fields cannot be sortable and the sortable property must be null for such fields. The default for sortable is true for single-valued simple fields, false for multi-valued simple fields, and null for complex fields. </param>
        /// <param name="isFacetable"> A value indicating whether to enable the field to be referenced in facet queries. Typically used in a presentation of search results that includes hit count by category (for example, search for digital cameras and see hits by brand, by megapixels, by price, and so on). This property must be null for complex fields. Fields of type Edm.GeographyPoint or Collection(Edm.GeographyPoint) cannot be facetable. Default is true for all other simple fields. </param>
        /// <param name="permissionFilter"> A value indicating whether the field should be used as a permission filter. </param>
        /// <param name="organizationAccessExpiration"> A value indicating whether the field contains the expiration timestamp for organization-scoped SharePoint sharing links. At most one top-level field of type Edm.DateTimeOffset can have this property set to true. On permission-filtered queries, expiration applies only to orgLink:&lt;tenantId&gt; values in a userIds permission-filter field whose tenant ID matches the validated user's tenant ID. The grant is valid only before the timestamp; an absent expiration field or a null timestamp means no time limit. Expiration does not affect orgGroup:&lt;tenantId&gt; values in groupIds permission-filter fields or ordinary user and group grants. If omitted or false, this field is not used for organization-link expiration. </param>
        /// <param name="sharepointSiteUrl"> A value indicating whether the field contains a SharePoint site URL used for SharePoint group-based filtering. </param>
        /// <param name="analyzerName"> The name of the analyzer to use for the field. This option can be used only with searchable fields and it can't be set together with either searchAnalyzer or indexAnalyzer. Once the analyzer is chosen, it cannot be changed for the field. Must be null for complex fields. </param>
        /// <param name="searchAnalyzerName"> The name of the analyzer used at search time for the field. This option can be used only with searchable fields. It must be set together with indexAnalyzer and it cannot be set together with the analyzer option. This property cannot be set to the name of a language analyzer; use the analyzer property instead if you need a language analyzer. This analyzer can be updated on an existing field. Must be null for complex fields. </param>
        /// <param name="indexAnalyzerName"> The name of the analyzer used at indexing time for the field. This option can be used only with searchable fields. It must be set together with searchAnalyzer and it cannot be set together with the analyzer option.  This property cannot be set to the name of a language analyzer; use the analyzer property instead if you need a language analyzer. Once the analyzer is chosen, it cannot be changed for the field. Must be null for complex fields. </param>
        /// <param name="normalizerName"> The name of the normalizer to use for the field. This option can be used only with fields with filterable, sortable, or facetable enabled. Once the normalizer is chosen, it cannot be changed for the field. Must be null for complex fields. </param>
        /// <param name="vectorSearchDimensions"> The dimensionality of the vector field. </param>
        /// <param name="vectorSearchProfileName"> The name of the vector search profile that specifies the algorithm and vectorizer to use when searching the vector field. </param>
        /// <param name="vectorEncodingFormat"> The encoding format to interpret the field contents. </param>
        /// <param name="synonymMapNames"> A list of the names of synonym maps to associate with this field. This option can be used only with searchable fields. Currently only one synonym map per field is supported. Assigning a synonym map to a field ensures that query terms targeting that field are expanded at query-time using the rules in the synonym map. This attribute can be changed on existing fields. Must be null or an empty collection for complex fields. </param>
        /// <param name="fields"> A list of sub-fields if this is a field of type Edm.ComplexType or Collection(Edm.ComplexType). Must be null or empty for simple fields. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchField"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchField SearchField(string name = default, SearchFieldDataType @type = default, bool? isKey = default, bool? isRetrievable = default, bool? isStored = default, bool? isSearchable = default, bool? isFilterable = default, bool? isSortable = default, bool? isFacetable = default, PermissionFilter? permissionFilter = default, bool? organizationAccessExpiration = default, bool? sharepointSiteUrl = default, LexicalAnalyzerName? analyzerName = default, LexicalAnalyzerName? searchAnalyzerName = default, LexicalAnalyzerName? indexAnalyzerName = default, LexicalNormalizerName? normalizerName = default, int? vectorSearchDimensions = default, string vectorSearchProfileName = default, VectorEncodingFormat? vectorEncodingFormat = default, IEnumerable<string> synonymMapNames = default, IEnumerable<SearchField> fields = default) =>
            SearchField(name: name, @type: @type, isKey: isKey, isRetrievable: isRetrievable, isStored: isStored, isSearchable: isSearchable, isFilterable: isFilterable, isSortable: isSortable, isFacetable: isFacetable, permissionFilter: permissionFilter, organizationAccessExpiration: organizationAccessExpiration, isSensitivityLabelId: default, isSensitivityLabelName: default, isSourceDocumentId: default, sharepointSiteUrl: sharepointSiteUrl, analyzerName: analyzerName, searchAnalyzerName: searchAnalyzerName, indexAnalyzerName: indexAnalyzerName, normalizerName: normalizerName, vectorSearchDimensions: vectorSearchDimensions, vectorSearchProfileName: vectorSearchProfileName, topicGraphProfile: default, vectorEncodingFormat: vectorEncodingFormat, synonymMapNames: synonymMapNames, fields: fields);

        /// <summary> Represents a search index definition, which describes the fields and search behavior of an index. </summary>
        /// <param name="name"> The name of the index. </param>
        /// <param name="description"> The description of the index. </param>
        /// <param name="fields"> The fields of the index. </param>
        /// <param name="scoringProfiles"> The scoring profiles for the index. </param>
        /// <param name="defaultScoringProfile"> The name of the scoring profile to use if none is specified in the query. If this property is not set and no scoring profile is specified in the query, then default scoring (tf-idf) will be used. </param>
        /// <param name="corsOptions"> Options to control Cross-Origin Resource Sharing (CORS) for the index. </param>
        /// <param name="suggesters"> The suggesters for the index. </param>
        /// <param name="analyzers"> The analyzers for the index. </param>
        /// <param name="tokenizers"> The tokenizers for the index. </param>
        /// <param name="tokenFilters"> The token filters for the index. </param>
        /// <param name="charFilters"> The character filters for the index. </param>
        /// <param name="normalizers"> The normalizers for the index. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your data when you want full assurance that no one, not even Microsoft, can decrypt your data. Once you have encrypted your data, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your data will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="similarity"> The type of similarity algorithm to be used when scoring and ranking the documents matching a search query. The similarity algorithm can only be defined at index creation time and cannot be modified on existing indexes. If null, the ClassicSimilarity algorithm is used. </param>
        /// <param name="semanticSearch"> Defines parameters for a search index that influence semantic capabilities. </param>
        /// <param name="vectorSearch"> Contains configuration options related to vector search. </param>
        /// <param name="permissionFilterOption"> A value indicating whether permission filtering is enabled for the index. </param>
        /// <param name="sharePointConnectorAppRegistration"> Configures a SharePoint connector app registration for the index, enabling document-level permissions from SharePoint. If provided, the applicationId and federatedCredentialId properties are required. </param>
        /// <param name="eTag"> The ETag of the index. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndexResponse"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndexResponse SearchIndexResponse(string name = default, string description = default, IEnumerable<SearchField> fields = default, IEnumerable<ScoringProfile> scoringProfiles = default, string defaultScoringProfile = default, CorsOptions corsOptions = default, IEnumerable<SearchSuggester> suggesters = default, IEnumerable<LexicalAnalyzer> analyzers = default, IEnumerable<LexicalTokenizer> tokenizers = default, IEnumerable<TokenFilter> tokenFilters = default, IEnumerable<CharFilter> charFilters = default, IEnumerable<LexicalNormalizer> normalizers = default, SearchResourceEncryptionKey encryptionKey = default, SimilarityAlgorithm similarity = default, SemanticSearch semanticSearch = default, VectorSearch vectorSearch = default, SearchIndexPermissionFilterOption? permissionFilterOption = default, SharePointConnectorAppRegistration sharePointConnectorAppRegistration = default, ETag? eTag = default) =>
            SearchIndexResponse(name: name, description: description, fields: fields, graphProfile: default, scoringProfiles: scoringProfiles, defaultScoringProfile: defaultScoringProfile, corsOptions: corsOptions, suggesters: suggesters, analyzers: analyzers, tokenizers: tokenizers, tokenFilters: tokenFilters, charFilters: charFilters, normalizers: normalizers, encryptionKey: encryptionKey, similarity: similarity, semanticSearch: semanticSearch, vectorSearch: vectorSearch, permissionFilterOption: permissionFilterOption, purviewEnabled: default, sharePointConnectorAppRegistration: sharePointConnectorAppRegistration, oneLakeSecuritySource: default, eTag: eTag);

        /// <summary> Represents a knowledge base definition. </summary>
        /// <param name="name"> The name of the knowledge base. </param>
        /// <param name="knowledgeSources"> Knowledge sources referenced by this knowledge base. </param>
        /// <param name="models"> Contains configuration options on how to connect to AI models. </param>
        /// <param name="retrievalReasoningEffort"> The retrieval reasoning effort configuration. </param>
        /// <param name="outputMode"> The output mode for the knowledge base. </param>
        /// <param name="eTag"> The ETag of the knowledge base. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. </param>
        /// <param name="description"> The description of the knowledge base. </param>
        /// <param name="retrievalInstructions"> Instructions considered by the knowledge base when developing query plan. </param>
        /// <param name="answerInstructions"> Instructions considered by the knowledge base when generating answers. </param>
        /// <param name="corsOptions"> Options to control Cross-Origin Resource Sharing (CORS) for the knowledge base. </param>
        /// <returns> A new <see cref="Indexes.Models.KnowledgeBase"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KnowledgeBase KnowledgeBase(string name = default, IEnumerable<KnowledgeSourceReference> knowledgeSources = default, IEnumerable<KnowledgeBaseModel> models = default, KnowledgeRetrievalReasoningEffort retrievalReasoningEffort = default, KnowledgeRetrievalOutputMode? outputMode = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default, string description = default, string retrievalInstructions = default, string answerInstructions = default, CorsOptions corsOptions = default) =>
            KnowledgeBase(name: name, knowledgeSources: knowledgeSources, tools: default, models: models, retrievalReasoningEffort: retrievalReasoningEffort, outputMode: outputMode, eTag: eTag, encryptionKey: encryptionKey, description: description, tags: default, retrievalInstructions: retrievalInstructions, answerInstructions: answerInstructions, corsOptions: corsOptions, retrieveDefaults: default);

        /// <summary> Knowledge Source targeting a search index. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> Optional user-defined description. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your knowledge source definition when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your knowledge source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your knowledge source definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="searchIndexParameters"> The parameters for the knowledge source. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndexKnowledgeSource"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndexKnowledgeSource SearchIndexKnowledgeSource(string name = default, string description = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default, SearchIndexKnowledgeSourceParameters searchIndexParameters = default) =>
            SearchIndexKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, searchIndexParameters: searchIndexParameters);

        /// <summary> Configuration for Azure Blob Storage knowledge source. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> Optional user-defined description. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your knowledge source definition when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your knowledge source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your knowledge source definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="azureBlobParameters"> The type of the knowledge source. </param>
        /// <returns> A new <see cref="Indexes.Models.AzureBlobKnowledgeSource"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AzureBlobKnowledgeSource AzureBlobKnowledgeSource(string name = default, string description = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default, AzureBlobKnowledgeSourceParameters azureBlobParameters = default) =>
            AzureBlobKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, azureBlobParameters: azureBlobParameters);

        /// <summary> Configuration for SharePoint knowledge source. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> Optional user-defined description. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your knowledge source definition when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your knowledge source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your knowledge source definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="indexedSharePointParameters"> The parameters for the knowledge source. </param>
        /// <returns> A new <see cref="Indexes.Models.IndexedSharePointKnowledgeSource"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IndexedSharePointKnowledgeSource IndexedSharePointKnowledgeSource(string name = default, string description = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default, IndexedSharePointKnowledgeSourceParameters indexedSharePointParameters = default) =>
            IndexedSharePointKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, indexedSharePointParameters: indexedSharePointParameters);

        /// <summary> Configuration for OneLake knowledge source. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> Optional user-defined description. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your knowledge source definition when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your knowledge source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your knowledge source definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="indexedOneLakeParameters"> The parameters for the knowledge source. </param>
        /// <returns> A new <see cref="Indexes.Models.IndexedOneLakeKnowledgeSource"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IndexedOneLakeKnowledgeSource IndexedOneLakeKnowledgeSource(string name = default, string description = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default, IndexedOneLakeKnowledgeSourceParameters indexedOneLakeParameters = default) =>
            IndexedOneLakeKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, indexedOneLakeParameters: indexedOneLakeParameters);

        /// <summary> Configuration for indexed SQL knowledge source. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> Optional user-defined description. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your knowledge source definition when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your knowledge source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your knowledge source definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="indexedSqlParameters"> The parameters for the SQL knowledge source. </param>
        /// <returns> A new <see cref="Indexes.Models.IndexedSqlKnowledgeSource"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IndexedSqlKnowledgeSource IndexedSqlKnowledgeSource(string name = default, string description = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default, IndexedSqlKnowledgeSourceParameters indexedSqlParameters = default) =>
            IndexedSqlKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, indexedSqlParameters: indexedSqlParameters);

        /// <summary> Configuration for File knowledge source that supports direct file upload and indexing. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> Optional user-defined description. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your knowledge source definition when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your knowledge source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your knowledge source definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="fileParameters"> The parameters for the File knowledge source. </param>
        /// <param name="corsOptions"> Options to control Cross-Origin Resource Sharing (CORS) for the File knowledge source's file endpoints (upload, list, update, delete). </param>
        /// <returns> A new <see cref="Indexes.Models.FileKnowledgeSource"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileKnowledgeSource FileKnowledgeSource(string name = default, string description = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default, FileKnowledgeSourceParameters fileParameters = default, CorsOptions corsOptions = default) =>
            FileKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, fileParameters: fileParameters, corsOptions: corsOptions);

        /// <summary> Knowledge Source targeting web results. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> Optional user-defined description. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your knowledge source definition when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your knowledge source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your knowledge source definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="webParameters"> The parameters for the web knowledge source. </param>
        /// <returns> A new <see cref="Indexes.Models.WebKnowledgeSource"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WebKnowledgeSource WebKnowledgeSource(string name = default, string description = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default, WebKnowledgeSourceParameters webParameters = default) =>
            WebKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, webParameters: webParameters);

        /// <summary> Represents the current state of an ongoing synchronization that spans multiple indexer runs. </summary>
        /// <param name="startTime"> The start time of the current synchronization. </param>
        /// <param name="itemsUpdatesProcessed"> The number of item updates successfully processed in the current synchronization. </param>
        /// <param name="itemsUpdatesFailed"> The number of item updates that failed in the current synchronization. </param>
        /// <param name="itemsSkipped"> The number of items skipped in the current synchronization. </param>
        /// <param name="errors"> Collection of document-level indexing errors encountered during the current synchronization run. Returned only when errors are present. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.SynchronizationState"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SynchronizationState SynchronizationState(DateTimeOffset startTime = default, int itemsUpdatesProcessed = default, int itemsUpdatesFailed = default, int itemsSkipped = default, IEnumerable<KnowledgeSourceSynchronizationError> errors = default) =>
            SynchronizationState(graphStatistics: default, startTime: startTime, itemsUpdatesProcessed: itemsUpdatesProcessed, itemsUpdatesFailed: itemsUpdatesFailed, itemsSkipped: itemsSkipped, errors: errors);

        /// <summary> Represents the completed state of the last synchronization. </summary>
        /// <param name="startTime"> The start time of the last completed synchronization. </param>
        /// <param name="endTime"> The end time of the last completed synchronization. </param>
        /// <param name="itemsUpdatesProcessed"> The number of item updates successfully processed in the last synchronization. </param>
        /// <param name="itemsUpdatesFailed"> The number of item updates that failed in the last synchronization. </param>
        /// <param name="itemsSkipped"> The number of items skipped in the last synchronization. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.CompletedSynchronizationState"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CompletedSynchronizationState CompletedSynchronizationState(DateTimeOffset startTime = default, DateTimeOffset endTime = default, int itemsUpdatesProcessed = default, int itemsUpdatesFailed = default, int itemsSkipped = default) =>
            CompletedSynchronizationState(graphStatistics: default, startTime: startTime, endTime: endTime, itemsUpdatesProcessed: itemsUpdatesProcessed, itemsUpdatesFailed: itemsUpdatesFailed, itemsSkipped: itemsSkipped);

        /// <summary> Represents service-level resource counters and quotas. </summary>
        /// <param name="aliasCounter"> Total number of aliases. </param>
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
        public static SearchServiceCounters SearchServiceCounters(SearchResourceCounter aliasCounter = default, SearchResourceCounter documentCounter = default, SearchResourceCounter indexCounter = default, SearchResourceCounter indexerCounter = default, SearchResourceCounter dataSourceCounter = default, SearchResourceCounter storageSizeCounter = default, SearchResourceCounter synonymMapCounter = default, SearchResourceCounter skillsetCounter = default, SearchResourceCounter vectorIndexSizeCounter = default) =>
            SearchServiceCounters(aliasCounter: aliasCounter, documentCounter: documentCounter, indexCounter: indexCounter, indexerCounter: indexerCounter, dataSourceCounter: dataSourceCounter, storageSizeCounter: storageSizeCounter, synonymMapCounter: synonymMapCounter, skillsetCounter: skillsetCounter, vectorIndexSizeCounter: vectorIndexSizeCounter, knowledgeBaseCounter: default, knowledgeSourceCounter: default);

        /// <summary> Represents various service level limits. </summary>
        /// <param name="maxFieldsPerIndex"> The maximum allowed fields per index. </param>
        /// <param name="maxFieldNestingDepthPerIndex"> The maximum depth which you can nest sub-fields in an index, including the top-level complex field. For example, a/b/c has a nesting depth of 3. </param>
        /// <param name="maxComplexCollectionFieldsPerIndex"> The maximum number of fields of type Collection(Edm.ComplexType) allowed in an index. </param>
        /// <param name="maxComplexObjectsInCollectionsPerDocument"> The maximum number of objects in complex collections allowed per document. </param>
        /// <param name="maxStoragePerIndexInBytes"> The maximum amount of storage in bytes allowed per index. </param>
        /// <param name="maxCumulativeIndexerRuntimeSeconds"> The maximum cumulative indexer runtime in seconds allowed for the service. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchServiceLimits"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchServiceLimits SearchServiceLimits(int? maxFieldsPerIndex = default, int? maxFieldNestingDepthPerIndex = default, int? maxComplexCollectionFieldsPerIndex = default, int? maxComplexObjectsInCollectionsPerDocument = default, long? maxStoragePerIndexInBytes = default, long? maxCumulativeIndexerRuntimeSeconds = default) =>
            SearchServiceLimits(maxFieldsPerIndex: maxFieldsPerIndex, maxFieldNestingDepthPerIndex: maxFieldNestingDepthPerIndex, maxComplexCollectionFieldsPerIndex: maxComplexCollectionFieldsPerIndex, maxComplexObjectsInCollectionsPerDocument: maxComplexObjectsInCollectionsPerDocument, maxStoragePerIndexInBytes: maxStoragePerIndexInBytes, maxCumulativeIndexerRuntimeSeconds: maxCumulativeIndexerRuntimeSeconds, maxVectorIndexSizePerIndexInBytes: default);

        /// <summary> Represents an indexer. </summary>
        /// <param name="name"> The name of the indexer. </param>
        /// <param name="description"> The description of the indexer. </param>
        /// <param name="dataSourceName"> The name of the datasource from which this indexer reads data. </param>
        /// <param name="skillsetName"> The name of the skillset executing with this indexer. </param>
        /// <param name="targetIndexName"> The name of the index to which this indexer writes data. </param>
        /// <param name="schedule"> The schedule for this indexer. </param>
        /// <param name="parameters"> Parameters for indexer execution. </param>
        /// <param name="fieldMappings"> Defines mappings between fields in the data source and corresponding target fields in the index. </param>
        /// <param name="outputFieldMappings"> Output field mappings are applied after enrichment and immediately before indexing. </param>
        /// <param name="isDisabled"> A value indicating whether the indexer is disabled. Default is false. </param>
        /// <param name="eTag"> The ETag of the indexer. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your indexer definition (as well as indexer execution status) when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your indexer definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your indexer definition (and indexer execution status) will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndexer"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndexer SearchIndexer(string name = default, string description = default, string dataSourceName = default, string skillsetName = default, string targetIndexName = default, IndexingSchedule schedule = default, IndexingParameters parameters = default, IEnumerable<FieldMapping> fieldMappings = default, IEnumerable<FieldMapping> outputFieldMappings = default, bool? isDisabled = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default) =>
            SearchIndexer(name: name, description: description, dataSourceName: dataSourceName, skillsetName: skillsetName, targetIndexName: targetIndexName, schedule: schedule, parameters: parameters, fieldMappings: fieldMappings, outputFieldMappings: outputFieldMappings, isDisabled: isDisabled, eTag: eTag, encryptionKey: encryptionKey, cache: default);

        /// <summary> The input contract for the retrieval request. </summary>
        /// <param name="messages"> A list of chat message style input. </param>
        /// <param name="intents"> A list of intended queries to execute without model query planning. </param>
        /// <param name="maxRuntimeInSeconds"> The maximum runtime in seconds. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents in the output. </param>
        /// <param name="maxOutputSizeInTokens"> Limits the maximum size of the content in the output. </param>
        /// <param name="retrievalReasoningEffort"> The retrieval reasoning effort configuration. </param>
        /// <param name="includeActivity"> Indicates retrieval results should include activity information. </param>
        /// <param name="outputMode"> The output configuration for this retrieval. </param>
        /// <param name="knowledgeSourceParams"> A list of runtime parameters for the knowledge sources. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseRetrievalRequest"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KnowledgeBaseRetrievalRequest KnowledgeBaseRetrievalRequest(IEnumerable<KnowledgeBaseMessage> messages = default, IEnumerable<KnowledgeRetrievalIntent> intents = default, int? maxRuntimeInSeconds = default, int? maxOutputDocuments = default, int? maxOutputSizeInTokens = default, KnowledgeRetrievalReasoningEffort retrievalReasoningEffort = default, bool? includeActivity = default, KnowledgeRetrievalOutputMode? outputMode = default, IEnumerable<KnowledgeSourceParams> knowledgeSourceParams = default) =>
            KnowledgeBaseRetrievalRequest(messages: messages, intents: intents, maxRuntimeInSeconds: maxRuntimeInSeconds, maxOutputSize: default, maxOutputDocuments: maxOutputDocuments, maxOutputSizeInTokens: maxOutputSizeInTokens, retrievalReasoningEffort: retrievalReasoningEffort, includeActivity: includeActivity, outputMode: outputMode, knowledgeSourceParams: knowledgeSourceParams, toolName: default);

        /// <summary>
        /// Base type for knowledge source runtime parameters.
        ///             Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="KnowledgeBases.Models.AzureBlobKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.FileKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.IndexedSqlKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.SearchIndexKnowledgeSourceParams"/>, and <see cref="KnowledgeBases.Models.WebKnowledgeSourceParams"/>.
        /// </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <param name="kind"> The type of the knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeSourceParams"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KnowledgeSourceParams KnowledgeSourceParams(string knowledgeSourceName = default, bool? includeReferences = default, bool? includeReferenceSourceData = default, bool? alwaysQuerySource = default, bool? failOnError = default, float? rerankerThreshold = default, int? maxOutputDocuments = default, string kind = default) =>
            KnowledgeSourceParams(knowledgeSourceName: knowledgeSourceName, includeReferences: includeReferences, includeReferenceSourceData: includeReferenceSourceData, alwaysQuerySource: alwaysQuerySource, neverQuerySource: default, failOnError: failOnError, rerankerThreshold: rerankerThreshold, resultsProcessing: default, maxOutputDocuments: maxOutputDocuments, kind: kind, enableImageServing: default);

        /// <summary> Specifies runtime parameters for a search index knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <param name="filterAddOn"> A filter condition applied to the index (e.g., 'State eq VA'). </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.SearchIndexKnowledgeSourceParams"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndexKnowledgeSourceParams SearchIndexKnowledgeSourceParams(string knowledgeSourceName = default, bool? includeReferences = default, bool? includeReferenceSourceData = default, bool? alwaysQuerySource = default, bool? failOnError = default, float? rerankerThreshold = default, int? maxOutputDocuments = default, string filterAddOn = default) =>
            SearchIndexKnowledgeSourceParams(knowledgeSourceName: knowledgeSourceName, includeReferences: includeReferences, includeReferenceSourceData: includeReferenceSourceData, alwaysQuerySource: alwaysQuerySource, neverQuerySource: default, failOnError: failOnError, rerankerThreshold: rerankerThreshold, resultsProcessing: default, maxOutputDocuments: maxOutputDocuments, enableImageServing: default, filterAddOn: filterAddOn, queryHintOverrides: default, topicGraph: default);

        /// <summary> Specifies runtime parameters for a azure blob knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.AzureBlobKnowledgeSourceParams"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AzureBlobKnowledgeSourceParams AzureBlobKnowledgeSourceParams(string knowledgeSourceName = default, bool? includeReferences = default, bool? includeReferenceSourceData = default, bool? alwaysQuerySource = default, bool? failOnError = default, float? rerankerThreshold = default, int? maxOutputDocuments = default) =>
            AzureBlobKnowledgeSourceParams(knowledgeSourceName: knowledgeSourceName, includeReferences: includeReferences, includeReferenceSourceData: includeReferenceSourceData, alwaysQuerySource: alwaysQuerySource, neverQuerySource: default, failOnError: failOnError, rerankerThreshold: rerankerThreshold, resultsProcessing: default, maxOutputDocuments: maxOutputDocuments, enableImageServing: default, graphParameters: default, topicGraph: default);

        /// <summary> Specifies runtime parameters for a indexed SharePoint knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IndexedSharePointKnowledgeSourceParams IndexedSharePointKnowledgeSourceParams(string knowledgeSourceName = default, bool? includeReferences = default, bool? includeReferenceSourceData = default, bool? alwaysQuerySource = default, bool? failOnError = default, float? rerankerThreshold = default, int? maxOutputDocuments = default) =>
            IndexedSharePointKnowledgeSourceParams(knowledgeSourceName: knowledgeSourceName, includeReferences: includeReferences, includeReferenceSourceData: includeReferenceSourceData, alwaysQuerySource: alwaysQuerySource, neverQuerySource: default, failOnError: failOnError, rerankerThreshold: rerankerThreshold, resultsProcessing: default, maxOutputDocuments: maxOutputDocuments, enableImageServing: default);

        /// <summary> Specifies runtime parameters for a indexed OneLake knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IndexedOneLakeKnowledgeSourceParams IndexedOneLakeKnowledgeSourceParams(string knowledgeSourceName = default, bool? includeReferences = default, bool? includeReferenceSourceData = default, bool? alwaysQuerySource = default, bool? failOnError = default, float? rerankerThreshold = default, int? maxOutputDocuments = default) =>
            IndexedOneLakeKnowledgeSourceParams(knowledgeSourceName: knowledgeSourceName, includeReferences: includeReferences, includeReferenceSourceData: includeReferenceSourceData, alwaysQuerySource: alwaysQuerySource, neverQuerySource: default, failOnError: failOnError, rerankerThreshold: rerankerThreshold, resultsProcessing: default, maxOutputDocuments: maxOutputDocuments, enableImageServing: default);

        /// <summary> Specifies runtime parameters for a web knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <param name="language"> The language of the web results. </param>
        /// <param name="market"> The market of the web results. </param>
        /// <param name="count"> The number of web results to return. </param>
        /// <param name="freshness"> The freshness of web results. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.WebKnowledgeSourceParams"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WebKnowledgeSourceParams WebKnowledgeSourceParams(string knowledgeSourceName = default, bool? includeReferences = default, bool? includeReferenceSourceData = default, bool? alwaysQuerySource = default, bool? failOnError = default, float? rerankerThreshold = default, int? maxOutputDocuments = default, string language = default, string market = default, int? count = default, string freshness = default) =>
            WebKnowledgeSourceParams(knowledgeSourceName: knowledgeSourceName, includeReferences: includeReferences, includeReferenceSourceData: includeReferenceSourceData, alwaysQuerySource: alwaysQuerySource, neverQuerySource: default, failOnError: failOnError, rerankerThreshold: rerankerThreshold, resultsProcessing: default, maxOutputDocuments: maxOutputDocuments, enableImageServing: default, language: language, market: market, count: count, freshness: freshness);

        /// <summary> Specifies runtime parameters for a File knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.FileKnowledgeSourceParams"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static FileKnowledgeSourceParams FileKnowledgeSourceParams(string knowledgeSourceName = default, bool? includeReferences = default, bool? includeReferenceSourceData = default, bool? alwaysQuerySource = default, bool? failOnError = default, float? rerankerThreshold = default, int? maxOutputDocuments = default) =>
            FileKnowledgeSourceParams(knowledgeSourceName: knowledgeSourceName, includeReferences: includeReferences, includeReferenceSourceData: includeReferenceSourceData, alwaysQuerySource: alwaysQuerySource, neverQuerySource: default, failOnError: failOnError, rerankerThreshold: rerankerThreshold, resultsProcessing: default, maxOutputDocuments: maxOutputDocuments, enableImageServing: default);

        /// <summary> Specifies runtime parameters for an indexed SQL knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.IndexedSqlKnowledgeSourceParams"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IndexedSqlKnowledgeSourceParams IndexedSqlKnowledgeSourceParams(string knowledgeSourceName = default, bool? includeReferences = default, bool? includeReferenceSourceData = default, bool? alwaysQuerySource = default, bool? failOnError = default, float? rerankerThreshold = default, int? maxOutputDocuments = default) =>
            IndexedSqlKnowledgeSourceParams(knowledgeSourceName: knowledgeSourceName, includeReferences: includeReferences, includeReferenceSourceData: includeReferenceSourceData, alwaysQuerySource: alwaysQuerySource, neverQuerySource: default, failOnError: failOnError, rerankerThreshold: rerankerThreshold, resultsProcessing: default, maxOutputDocuments: maxOutputDocuments, enableImageServing: default);
    }
}
