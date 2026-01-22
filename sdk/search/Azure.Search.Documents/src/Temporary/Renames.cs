// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402 // File may only contain a single type

using Microsoft.TypeSpec.Generator.Customizations;

// =============================================================================
// CLIENT NAMESPACE RENAMES
// These customizations fix the namespace for generated clients to match
// the clientNamespace defined in client.tsp
// =============================================================================

namespace Azure.Search.Documents
{
    /// <summary> SearchClient namespace customization. </summary>
    [CodeGenType("SearchClient")]
    public partial class SearchClient
    {
    }
}

namespace Azure.Search.Documents.Indexes
{
    /// <summary> SearchIndexClient namespace customization. </summary>
    [CodeGenType("SearchIndexClient")]
    public partial class SearchIndexClient
    {
    }

    //// <summary> SearchIndexerClient namespace customization. </summary>
    //[CodeGenType("SearchIndexerClient")]
    //public partial class SearchIndexerClient
    //{
    //}
}

namespace Azure.Search.Documents.KnowledgeBases
{
    /// <summary> KnowledgeBaseRetrievalClient namespace customization. </summary>
    [CodeGenType("KnowledgeBaseRetrievalClient")]
    public partial class KnowledgeBaseRetrievalClient
    {
    }
}

namespace Azure.Search.Documents.KnowledgeBases.Models
{
    // AI Services
    /// <summary> AIServices namespace customization. </summary>
    [CodeGenType("AIServices")]
    public partial class AIServices
    {
    }

    /// <summary> SynchronizationState namespace customization. </summary>
    [CodeGenType("SynchronizationState")]
    public partial class SynchronizationState
    {
    }

    /// <summary> CompletedSynchronizationState namespace customization. </summary>
    [CodeGenType("CompletedSynchronizationState")]
    public partial class CompletedSynchronizationState
    {
    }

    // Retrieval types
    /// <summary> KnowledgeBaseRetrievalRequest namespace customization. </summary>
    [CodeGenType("KnowledgeBaseRetrievalRequest")]
    public partial class KnowledgeBaseRetrievalRequest
    {
    }

    /// <summary> KnowledgeBaseRetrievalResponse namespace customization. </summary>
    [CodeGenType("KnowledgeBaseRetrievalResponse")]
    public partial class KnowledgeBaseRetrievalResponse
    {
    }

    // Reasoning effort types
    /// <summary> KnowledgeRetrievalReasoningEffort namespace customization. </summary>
    [CodeGenType("KnowledgeRetrievalReasoningEffort")]
    public partial class KnowledgeRetrievalReasoningEffort
    {
    }

    /// <summary> KnowledgeRetrievalReasoningEffortKind namespace customization. </summary>
    [CodeGenType("KnowledgeRetrievalReasoningEffortKind")]
    public readonly partial struct KnowledgeRetrievalReasoningEffortKind
    {
    }

    /// <summary> KnowledgeRetrievalMinimalReasoningEffort namespace customization. </summary>
    [CodeGenType("KnowledgeRetrievalMinimalReasoningEffort")]
    public partial class KnowledgeRetrievalMinimalReasoningEffort
    {
    }

    /// <summary> KnowledgeRetrievalLowReasoningEffort namespace customization. </summary>
    [CodeGenType("KnowledgeRetrievalLowReasoningEffort")]
    public partial class KnowledgeRetrievalLowReasoningEffort
    {
    }

    /// <summary> KnowledgeRetrievalMediumReasoningEffort namespace customization. </summary>
    [CodeGenType("KnowledgeRetrievalMediumReasoningEffort")]
    public partial class KnowledgeRetrievalMediumReasoningEffort
    {
    }

    /// <summary> KnowledgeRetrievalOutputMode namespace customization. </summary>
    [CodeGenType("KnowledgeRetrievalOutputMode")]
    public readonly partial struct KnowledgeRetrievalOutputMode
    {
    }

    // Knowledge source params types
    /// <summary> KnowledgeSourceParams namespace customization. </summary>
    [CodeGenType("KnowledgeSourceParams")]
    public partial class KnowledgeSourceParams
    {
    }

    /// <summary> SearchIndexKnowledgeSourceParams namespace customization. </summary>
    [CodeGenType("SearchIndexKnowledgeSourceParams")]
    public partial class SearchIndexKnowledgeSourceParams
    {
    }

    /// <summary> AzureBlobKnowledgeSourceParams namespace customization. </summary>
    [CodeGenType("AzureBlobKnowledgeSourceParams")]
    public partial class AzureBlobKnowledgeSourceParams
    {
    }

    /// <summary> IndexedSharePointKnowledgeSourceParams namespace customization. </summary>
    [CodeGenType("IndexedSharePointKnowledgeSourceParams")]
    public partial class IndexedSharePointKnowledgeSourceParams
    {
    }

    /// <summary> IndexedOneLakeKnowledgeSourceParams namespace customization. </summary>
    [CodeGenType("IndexedOneLakeKnowledgeSourceParams")]
    public partial class IndexedOneLakeKnowledgeSourceParams
    {
    }

    /// <summary> WebKnowledgeSourceParams namespace customization. </summary>
    [CodeGenType("WebKnowledgeSourceParams")]
    public partial class WebKnowledgeSourceParams
    {
    }

    /// <summary> RemoteSharePointKnowledgeSourceParams namespace customization. </summary>
    [CodeGenType("RemoteSharePointKnowledgeSourceParams")]
    public partial class RemoteSharePointKnowledgeSourceParams
    {
    }

    // Vectorizer types
    /// <summary> KnowledgeSourceVectorizer namespace customization. </summary>
    [CodeGenType("KnowledgeSourceVectorizer")]
    public partial class KnowledgeSourceVectorizer
    {
    }

    /// <summary> KnowledgeSourceAzureOpenAIVectorizer namespace customization. </summary>
    [CodeGenType("KnowledgeSourceAzureOpenAIVectorizer")]
    public partial class KnowledgeSourceAzureOpenAIVectorizer
    {
    }

    /// <summary> KnowledgeSourceIngestionParameters namespace customization. </summary>
    [CodeGenType("KnowledgeSourceIngestionParameters")]
    public partial class KnowledgeSourceIngestionParameters
    {
    }

    /// <summary> KnowledgeSourceStatistics namespace customization. </summary>
    [CodeGenType("KnowledgeSourceStatistics")]
    public partial class KnowledgeSourceStatistics
    {
    }

    /// <summary> KnowledgeSourceStatus namespace customization. </summary>
    [CodeGenType("KnowledgeSourceStatus")]
    public partial class KnowledgeSourceStatus
    {
    }

    // Intent types
    /// <summary> KnowledgeRetrievalIntent namespace customization. </summary>
    [CodeGenType("KnowledgeRetrievalIntent")]
    public partial class KnowledgeRetrievalIntent
    {
    }

    /// <summary> KnowledgeRetrievalIntentType namespace customization. </summary>
    [CodeGenType("KnowledgeRetrievalIntentType")]
    public readonly partial struct KnowledgeRetrievalIntentType
    {
    }

    /// <summary> KnowledgeRetrievalSemanticIntent namespace customization. </summary>
    [CodeGenType("KnowledgeRetrievalSemanticIntent")]
    public partial class KnowledgeRetrievalSemanticIntent
    {
    }

    // Message types
    /// <summary> KnowledgeBaseMessage namespace customization. </summary>
    [CodeGenType("KnowledgeBaseMessage")]
    public partial class KnowledgeBaseMessage
    {
    }

    /// <summary> KnowledgeBaseMessageContent namespace customization. </summary>
    [CodeGenType("KnowledgeBaseMessageContent")]
    public partial class KnowledgeBaseMessageContent
    {
    }

    /// <summary> KnowledgeBaseMessageContentType namespace customization. </summary>
    [CodeGenType("KnowledgeBaseMessageContentType")]
    public readonly partial struct KnowledgeBaseMessageContentType
    {
    }

    /// <summary> KnowledgeBaseMessageTextContent namespace customization. </summary>
    [CodeGenType("KnowledgeBaseMessageTextContent")]
    public partial class KnowledgeBaseMessageTextContent
    {
    }

    /// <summary> KnowledgeBaseMessageImageContent namespace customization. </summary>
    [CodeGenType("KnowledgeBaseMessageImageContent")]
    public partial class KnowledgeBaseMessageImageContent
    {
    }

    /// <summary> KnowledgeBaseImageContent namespace customization. </summary>
    [CodeGenType("KnowledgeBaseImageContent")]
    public partial class KnowledgeBaseImageContent
    {
    }

    // Activity record types
    /// <summary> KnowledgeBaseActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseActivityRecord")]
    public partial class KnowledgeBaseActivityRecord
    {
    }

    /// <summary> KnowledgeBaseActivityRecordType namespace customization. </summary>
    [CodeGenType("KnowledgeBaseActivityRecordType")]
    public readonly partial struct KnowledgeBaseActivityRecordType
    {
    }

    /// <summary> KnowledgeBaseRetrievalActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseRetrievalActivityRecord")]
    public partial class KnowledgeBaseRetrievalActivityRecord
    {
    }

    /// <summary> KnowledgeBaseSearchIndexActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseSearchIndexActivityRecord")]
    public partial class KnowledgeBaseSearchIndexActivityRecord
    {
    }

    /// <summary> KnowledgeBaseSearchIndexActivityArguments namespace customization. </summary>
    [CodeGenType("KnowledgeBaseSearchIndexActivityArguments")]
    public partial class KnowledgeBaseSearchIndexActivityArguments
    {
    }

    /// <summary> KnowledgeBaseAzureBlobActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseAzureBlobActivityRecord")]
    public partial class KnowledgeBaseAzureBlobActivityRecord
    {
    }

    /// <summary> KnowledgeBaseAzureBlobActivityArguments namespace customization. </summary>
    [CodeGenType("KnowledgeBaseAzureBlobActivityArguments")]
    public partial class KnowledgeBaseAzureBlobActivityArguments
    {
    }

    /// <summary> KnowledgeBaseIndexedSharePointActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseIndexedSharePointActivityRecord")]
    public partial class KnowledgeBaseIndexedSharePointActivityRecord
    {
    }

    /// <summary> KnowledgeBaseIndexedSharePointActivityArguments namespace customization. </summary>
    [CodeGenType("KnowledgeBaseIndexedSharePointActivityArguments")]
    public partial class KnowledgeBaseIndexedSharePointActivityArguments
    {
    }

    /// <summary> KnowledgeBaseIndexedOneLakeActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseIndexedOneLakeActivityRecord")]
    public partial class KnowledgeBaseIndexedOneLakeActivityRecord
    {
    }

    /// <summary> KnowledgeBaseIndexedOneLakeActivityArguments namespace customization. </summary>
    [CodeGenType("KnowledgeBaseIndexedOneLakeActivityArguments")]
    public partial class KnowledgeBaseIndexedOneLakeActivityArguments
    {
    }

    /// <summary> KnowledgeBaseWebActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseWebActivityRecord")]
    public partial class KnowledgeBaseWebActivityRecord
    {
    }

    /// <summary> KnowledgeBaseWebActivityArguments namespace customization. </summary>
    [CodeGenType("KnowledgeBaseWebActivityArguments")]
    public partial class KnowledgeBaseWebActivityArguments
    {
    }

    /// <summary> KnowledgeBaseRemoteSharePointActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseRemoteSharePointActivityRecord")]
    public partial class KnowledgeBaseRemoteSharePointActivityRecord
    {
    }

    /// <summary> KnowledgeBaseRemoteSharePointActivityArguments namespace customization. </summary>
    [CodeGenType("KnowledgeBaseRemoteSharePointActivityArguments")]
    public partial class KnowledgeBaseRemoteSharePointActivityArguments
    {
    }

    /// <summary> KnowledgeBaseModelQueryPlanningActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseModelQueryPlanningActivityRecord")]
    public partial class KnowledgeBaseModelQueryPlanningActivityRecord
    {
    }

    /// <summary> KnowledgeBaseModelAnswerSynthesisActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseModelAnswerSynthesisActivityRecord")]
    public partial class KnowledgeBaseModelAnswerSynthesisActivityRecord
    {
    }

    /// <summary> KnowledgeBaseAgenticReasoningActivityRecord namespace customization. </summary>
    [CodeGenType("KnowledgeBaseAgenticReasoningActivityRecord")]
    public partial class KnowledgeBaseAgenticReasoningActivityRecord
    {
    }

    // Reference types
    /// <summary> KnowledgeBaseReference namespace customization. </summary>
    [CodeGenType("KnowledgeBaseReference")]
    public partial class KnowledgeBaseReference
    {
    }

    /// <summary> KnowledgeBaseReferenceType namespace customization. </summary>
    [CodeGenType("KnowledgeBaseReferenceType")]
    public readonly partial struct KnowledgeBaseReferenceType
    {
    }

    /// <summary> KnowledgeBaseSearchIndexReference namespace customization. </summary>
    [CodeGenType("KnowledgeBaseSearchIndexReference")]
    public partial class KnowledgeBaseSearchIndexReference
    {
    }

    /// <summary> KnowledgeBaseAzureBlobReference namespace customization. </summary>
    [CodeGenType("KnowledgeBaseAzureBlobReference")]
    public partial class KnowledgeBaseAzureBlobReference
    {
    }

    /// <summary> KnowledgeBaseIndexedSharePointReference namespace customization. </summary>
    [CodeGenType("KnowledgeBaseIndexedSharePointReference")]
    public partial class KnowledgeBaseIndexedSharePointReference
    {
    }

    /// <summary> KnowledgeBaseIndexedOneLakeReference namespace customization. </summary>
    [CodeGenType("KnowledgeBaseIndexedOneLakeReference")]
    public partial class KnowledgeBaseIndexedOneLakeReference
    {
    }

    /// <summary> KnowledgeBaseWebReference namespace customization. </summary>
    [CodeGenType("KnowledgeBaseWebReference")]
    public partial class KnowledgeBaseWebReference
    {
    }

    /// <summary> KnowledgeBaseRemoteSharePointReference namespace customization. </summary>
    [CodeGenType("KnowledgeBaseRemoteSharePointReference")]
    public partial class KnowledgeBaseRemoteSharePointReference
    {
    }

    /// <summary> SharePointSensitivityLabelInfo namespace customization. </summary>
    [CodeGenType("SharePointSensitivityLabelInfo")]
    public partial class SharePointSensitivityLabelInfo
    {
    }

    // Error types
    /// <summary> KnowledgeBaseErrorDetail namespace customization. </summary>
    [CodeGenType("KnowledgeBaseErrorDetail")]
    public partial class KnowledgeBaseErrorDetail
    {
    }

    /// <summary> KnowledgeBaseErrorAdditionalInfo namespace customization. </summary>
    [CodeGenType("KnowledgeBaseErrorAdditionalInfo")]
    public partial class KnowledgeBaseErrorAdditionalInfo
    {
    }
}

// =============================================================================
// SEARCH DOCUMENTS TYPES (Azure.Search.Documents namespace)
// Types used for search document operations
// =============================================================================

namespace Azure.Search.Documents.Models
{
    // Error types
    /// <summary> ErrorResponse namespace customization. </summary>
    [CodeGenType("ErrorResponse")]
    public partial class ErrorResponse
    {
    }

    /// <summary> ErrorDetail namespace customization. </summary>
    [CodeGenType("ErrorDetail")]
    public partial class ErrorDetail
    {
    }

    /// <summary> ErrorAdditionalInfo namespace customization. </summary>
    [CodeGenType("ErrorAdditionalInfo")]
    public partial class ErrorAdditionalInfo
    {
    }

    // Query/Search types - these are already in Azure.Search.Documents.Models which is correct
    // The client.tsp specifies Azure.Search.Documents but the SDK convention uses .Models suffix

    /// <summary> SemanticErrorMode namespace customization. </summary>
    [CodeGenType("SemanticErrorMode")]
    public readonly partial struct SemanticErrorMode
    {
    }

    /// <summary> QueryAnswerType namespace customization. </summary>
    [CodeGenType("QueryAnswerType")]
    public readonly partial struct QueryAnswerType
    {
    }

    /// <summary> QueryCaptionType namespace customization. </summary>
    [CodeGenType("QueryCaptionType")]
    public readonly partial struct QueryCaptionType
    {
    }

    /// <summary> QueryRewritesType namespace customization. </summary>
    [CodeGenType("QueryRewritesType")]
    public readonly partial struct QueryRewritesType
    {
    }

    /// <summary> QueryDebugMode namespace customization. </summary>
    [CodeGenType("QueryDebugMode")]
    public readonly partial struct QueryDebugMode
    {
    }

    /// <summary> QueryLanguage namespace customization. </summary>
    [CodeGenType("QueryLanguage")]
    public readonly partial struct QueryLanguage
    {
    }

    /// <summary> QuerySpellerType namespace customization. </summary>
    [CodeGenType("QuerySpellerType")]
    public readonly partial struct QuerySpellerType
    {
    }

    /// <summary> VectorQueryKind namespace customization. </summary>
    [CodeGenType("VectorQueryKind")]
    public readonly partial struct VectorQueryKind
    {
    }

    /// <summary> VectorThresholdKind namespace customization. </summary>
    [CodeGenType("VectorThresholdKind")]
    public readonly partial struct VectorThresholdKind
    {
    }

    /// <summary> VectorFilterMode namespace customization. </summary>
    [CodeGenType("VectorFilterMode")]
    public readonly partial struct VectorFilterMode
    {
    }

    /// <summary> HybridCountAndFacetMode namespace customization. </summary>
    [CodeGenType("HybridCountAndFacetMode")]
    public readonly partial struct HybridCountAndFacetMode
    {
    }

    /// <summary> SemanticFieldState namespace customization. </summary>
    [CodeGenType("SemanticFieldState")]
    public readonly partial struct SemanticFieldState
    {
    }

    /// <summary> SemanticErrorReason namespace customization. </summary>
    [CodeGenType("SemanticErrorReason")]
    public readonly partial struct SemanticErrorReason
    {
    }

    /// <summary> SemanticSearchResultsType namespace customization. </summary>
    [CodeGenType("SemanticSearchResultsType")]
    public readonly partial struct SemanticSearchResultsType
    {
    }

    /// <summary> SemanticQueryRewritesResultType namespace customization. </summary>
    [CodeGenType("SemanticQueryRewritesResultType")]
    public readonly partial struct SemanticQueryRewritesResultType
    {
    }

    // NOTE: QueryType is renamed to SearchQueryType in /Models/SearchQueryType.cs

    /// <summary> SearchMode namespace customization. </summary>
    [CodeGenType("SearchMode")]
    public readonly partial struct SearchMode
    {
    }

    /// <summary> ScoringStatistics namespace customization. </summary>
    [CodeGenType("ScoringStatistics")]
    public readonly partial struct ScoringStatistics
    {
    }

    /// <summary> IndexActionType namespace customization. </summary>
    [CodeGenType("IndexActionType")]
    public readonly partial struct IndexActionType
    {
    }

    /// <summary> AutocompleteMode namespace customization. </summary>
    [CodeGenType("AutocompleteMode")]
    public readonly partial struct AutocompleteMode
    {
    }

    // NOTE: The following types are customized in /Models folder:
    // - SearchDocumentsResult (internal in SearchResults.cs)
    // - SearchResult (internal in SearchResult.cs)
    // - SuggestDocumentsResult (internal in SuggestResults.cs)
    // - SuggestResult (internal in SearchSuggestion.cs)
    // - IndexAction (internal in IndexDocumentsAction.cs)
    // - IndexBatch (internal as InternalIndexBatch in IndexDocumentsBatch.cs)
    // - AutocompleteResult (renamed to AutocompleteResults in AutocompleteResults.cs)
    // - IndexingResult (property rename in IndexingResult.cs)
    // - QueryType (renamed to SearchQueryType in SearchQueryType.cs)
    // - VectorQuery, VectorizedQuery, VectorizableTextQuery (extended in /Models)
    // - FacetResult (extended with IReadOnlyDictionary in FacetResult.cs)

    /// <summary> QueryAnswerResult namespace customization. </summary>
    [CodeGenType("QueryAnswerResult")]
    public partial class QueryAnswerResult
    {
    }

    /// <summary> DebugInfo namespace customization. </summary>
    [CodeGenType("DebugInfo")]
    public partial class DebugInfo
    {
    }

    /// <summary> QueryRewritesDebugInfo namespace customization. </summary>
    [CodeGenType("QueryRewritesDebugInfo")]
    public partial class QueryRewritesDebugInfo
    {
    }

    /// <summary> QueryRewritesValuesDebugInfo namespace customization. </summary>
    [CodeGenType("QueryRewritesValuesDebugInfo")]
    public partial class QueryRewritesValuesDebugInfo
    {
    }

    // NOTE: VectorQuery is customized in /Models/VectorQuery.cs with Fields property handling

    /// <summary> VectorThreshold namespace customization. </summary>
    [CodeGenType("VectorThreshold")]
    public partial class VectorThreshold
    {
    }

    /// <summary> HybridSearch namespace customization. </summary>
    [CodeGenType("HybridSearch")]
    public partial class HybridSearch
    {
    }

    /// <summary> QueryCaptionResult namespace customization. </summary>
    [CodeGenType("QueryCaptionResult")]
    public partial class QueryCaptionResult
    {
    }

    /// <summary> DocumentDebugInfo namespace customization. </summary>
    [CodeGenType("DocumentDebugInfo")]
    public partial class DocumentDebugInfo
    {
    }

    /// <summary> SemanticDebugInfo namespace customization. </summary>
    [CodeGenType("SemanticDebugInfo")]
    public partial class SemanticDebugInfo
    {
    }

    /// <summary> QueryResultDocumentSemanticField namespace customization. </summary>
    [CodeGenType("QueryResultDocumentSemanticField")]
    public partial class QueryResultDocumentSemanticField
    {
    }

    /// <summary> QueryResultDocumentRerankerInput namespace customization. </summary>
    [CodeGenType("QueryResultDocumentRerankerInput")]
    public partial class QueryResultDocumentRerankerInput
    {
    }

    /// <summary> VectorsDebugInfo namespace customization. </summary>
    [CodeGenType("VectorsDebugInfo")]
    public partial class VectorsDebugInfo
    {
    }

    /// <summary> QueryResultDocumentSubscores namespace customization. </summary>
    [CodeGenType("QueryResultDocumentSubscores")]
    public partial class QueryResultDocumentSubscores
    {
    }

    /// <summary> TextResult namespace customization. </summary>
    [CodeGenType("TextResult")]
    public partial class TextResult
    {
    }

    /// <summary> SingleVectorFieldResult namespace customization. </summary>
    [CodeGenType("SingleVectorFieldResult")]
    public partial class SingleVectorFieldResult
    {
    }

    /// <summary> SuggestRequest namespace customization. </summary>
    [CodeGenType("SuggestRequest")]
    public partial class SuggestRequest
    {
    }

    /// <summary> LookupDocument namespace customization. </summary>
    [CodeGenType("LookupDocument")]
    public partial class LookupDocument
    {
    }

    /// <summary> IndexDocumentsResult namespace customization. </summary>
    [CodeGenType("IndexDocumentsResult")]
    public partial class IndexDocumentsResult
    {
    }

    /// <summary> AutocompleteItem namespace customization. </summary>
    [CodeGenType("AutocompleteItem")]
    public partial class AutocompleteItem
    {
    }

    /// <summary> VectorizableImageUrlQuery namespace customization. </summary>
    [CodeGenType("VectorizableImageUrlQuery")]
    public partial class VectorizableImageUrlQuery
    {
    }

    /// <summary> VectorizableImageBinaryQuery namespace customization. </summary>
    [CodeGenType("VectorizableImageBinaryQuery")]
    public partial class VectorizableImageBinaryQuery
    {
    }

    /// <summary> VectorSimilarityThreshold namespace customization. </summary>
    [CodeGenType("VectorSimilarityThreshold")]
    public partial class VectorSimilarityThreshold
    {
    }

    /// <summary> SearchScoreThreshold namespace customization. </summary>
    [CodeGenType("SearchScoreThreshold")]
    public partial class SearchScoreThreshold
    {
    }

    /// <summary> QueryResultDocumentInnerHit namespace customization. </summary>
    [CodeGenType("QueryResultDocumentInnerHit")]
    public partial class QueryResultDocumentInnerHit
    {
    }
}

// =============================================================================
// SEARCH INDEX TYPES (Azure.Search.Documents.Indexes namespace)
// Types used for index management operations
// =============================================================================

namespace Azure.Search.Documents.Indexes.Models
{
    // Indexer data source types
    /// <summary> SearchIndexerDataSourceType namespace customization. </summary>
    [CodeGenType("SearchIndexerDataSourceType")]
    public readonly partial struct SearchIndexerDataSourceType
    {
    }

    /// <summary> BlobIndexerParsingMode namespace customization. </summary>
    [CodeGenType("BlobIndexerParsingMode")]
    public readonly partial struct BlobIndexerParsingMode
    {
    }

    /// <summary> MarkdownParsingSubmode namespace customization. </summary>
    [CodeGenType("MarkdownParsingSubmode")]
    public readonly partial struct MarkdownParsingSubmode
    {
    }

    /// <summary> MarkdownHeaderDepth namespace customization. </summary>
    [CodeGenType("MarkdownHeaderDepth")]
    public readonly partial struct MarkdownHeaderDepth
    {
    }

    /// <summary> BlobIndexerDataToExtract namespace customization. </summary>
    [CodeGenType("BlobIndexerDataToExtract")]
    public readonly partial struct BlobIndexerDataToExtract
    {
    }

    /// <summary> BlobIndexerImageAction namespace customization. </summary>
    [CodeGenType("BlobIndexerImageAction")]
    public readonly partial struct BlobIndexerImageAction
    {
    }

    /// <summary> IndexerExecutionEnvironment namespace customization. </summary>
    [CodeGenType("IndexerExecutionEnvironment")]
    public readonly partial struct IndexerExecutionEnvironment
    {
    }

    /// <summary> IndexerExecutionStatusDetail namespace customization. </summary>
    [CodeGenType("IndexerExecutionStatusDetail")]
    public readonly partial struct IndexerExecutionStatusDetail
    {
    }

    /// <summary> IndexingMode namespace customization. </summary>
    [CodeGenType("IndexingMode")]
    public readonly partial struct IndexingMode
    {
    }

    /// <summary> IndexProjectionMode namespace customization. </summary>
    [CodeGenType("IndexProjectionMode")]
    public readonly partial struct IndexProjectionMode
    {
    }

    /// <summary> SearchFieldDataType namespace customization. </summary>
    [CodeGenType("SearchFieldDataType")]
    public readonly partial struct SearchFieldDataType
    {
    }

    /// <summary> VectorEncodingFormat namespace customization. </summary>
    [CodeGenType("VectorEncodingFormat")]
    public readonly partial struct VectorEncodingFormat
    {
    }

    /// <summary> VectorSearchAlgorithmKind namespace customization. </summary>
    [CodeGenType("VectorSearchAlgorithmKind")]
    public readonly partial struct VectorSearchAlgorithmKind
    {
    }

    /// <summary> VectorSearchVectorizerKind namespace customization. </summary>
    [CodeGenType("VectorSearchVectorizerKind")]
    public readonly partial struct VectorSearchVectorizerKind
    {
    }

    /// <summary> VectorSearchCompressionKind namespace customization. </summary>
    [CodeGenType("VectorSearchCompressionKind")]
    public readonly partial struct VectorSearchCompressionKind
    {
    }

    /// <summary> VectorSearchCompressionRescoreStorageMethod namespace customization. </summary>
    [CodeGenType("VectorSearchCompressionRescoreStorageMethod")]
    public readonly partial struct VectorSearchCompressionRescoreStorageMethod
    {
    }

    /// <summary> LexicalTokenizerName namespace customization. </summary>
    [CodeGenType("LexicalTokenizerName")]
    public readonly partial struct LexicalTokenizerName
    {
    }

    /// <summary> TokenFilterName namespace customization. </summary>
    [CodeGenType("TokenFilterName")]
    public readonly partial struct TokenFilterName
    {
    }

    /// <summary> CharFilterName namespace customization. </summary>
    [CodeGenType("CharFilterName")]
    public readonly partial struct CharFilterName
    {
    }

    /// <summary> VectorSearchAlgorithmMetric namespace customization. </summary>
    [CodeGenType("VectorSearchAlgorithmMetric")]
    public readonly partial struct VectorSearchAlgorithmMetric
    {
    }

    /// <summary> VectorSearchCompressionTarget namespace customization. </summary>
    [CodeGenType("VectorSearchCompressionTarget")]
    public readonly partial struct VectorSearchCompressionTarget
    {
    }

    /// <summary> AzureOpenAIModelName namespace customization. </summary>
    [CodeGenType("AzureOpenAIModelName")]
    public readonly partial struct AzureOpenAIModelName
    {
    }

    /// <summary> AIFoundryModelCatalogName namespace customization. </summary>
    [CodeGenType("AIFoundryModelCatalogName")]
    public readonly partial struct AIFoundryModelCatalogName
    {
    }

    /// <summary> KeyPhraseExtractionSkillLanguage namespace customization. </summary>
    [CodeGenType("KeyPhraseExtractionSkillLanguage")]
    public readonly partial struct KeyPhraseExtractionSkillLanguage
    {
    }

    /// <summary> OcrSkillLanguage namespace customization. </summary>
    [CodeGenType("OcrSkillLanguage")]
    public readonly partial struct OcrSkillLanguage
    {
    }

    /// <summary> OcrLineEnding namespace customization. </summary>
    [CodeGenType("OcrLineEnding")]
    public readonly partial struct OcrLineEnding
    {
    }

    /// <summary> ImageAnalysisSkillLanguage namespace customization. </summary>
    [CodeGenType("ImageAnalysisSkillLanguage")]
    public readonly partial struct ImageAnalysisSkillLanguage
    {
    }

    /// <summary> VisualFeature namespace customization. </summary>
    [CodeGenType("VisualFeature")]
    public readonly partial struct VisualFeature
    {
    }

    /// <summary> ImageDetail namespace customization. </summary>
    [CodeGenType("ImageDetail")]
    public readonly partial struct ImageDetail
    {
    }

    /// <summary> EntityCategory namespace customization. </summary>
    [CodeGenType("EntityCategory")]
    public readonly partial struct EntityCategory
    {
    }

    /// <summary> EntityRecognitionSkill namespace customization. </summary>
    [CodeGenType("EntityRecognitionSkill")]
    public partial class EntityRecognitionSkill
    {
    }

    /// <summary> EntityRecognitionSkillLanguage namespace customization. </summary>
    [CodeGenType("EntityRecognitionSkillLanguage")]
    public readonly partial struct EntityRecognitionSkillLanguage
    {
    }

    /// <summary> SentimentSkillLanguage namespace customization. </summary>
    [CodeGenType("SentimentSkillLanguage")]
    public readonly partial struct SentimentSkillLanguage
    {
    }

    /// <summary> SplitSkillLanguage namespace customization. </summary>
    [CodeGenType("SplitSkillLanguage")]
    public readonly partial struct SplitSkillLanguage
    {
    }

    /// <summary> TextSplitMode namespace customization. </summary>
    [CodeGenType("TextSplitMode")]
    public readonly partial struct TextSplitMode
    {
    }

    /// <summary> SplitSkillUnit namespace customization. </summary>
    [CodeGenType("SplitSkillUnit")]
    public readonly partial struct SplitSkillUnit
    {
    }

    /// <summary> SplitSkillEncoderModelName namespace customization. </summary>
    [CodeGenType("SplitSkillEncoderModelName")]
    public readonly partial struct SplitSkillEncoderModelName
    {
    }

    /// <summary> CustomEntityLookupSkillLanguage namespace customization. </summary>
    [CodeGenType("CustomEntityLookupSkillLanguage")]
    public readonly partial struct CustomEntityLookupSkillLanguage
    {
    }

    /// <summary> TextTranslationSkillLanguage namespace customization. </summary>
    [CodeGenType("TextTranslationSkillLanguage")]
    public readonly partial struct TextTranslationSkillLanguage
    {
    }

    /// <summary> DocumentIntelligenceLayoutSkillOutputMode namespace customization. </summary>
    [CodeGenType("DocumentIntelligenceLayoutSkillOutputMode")]
    public readonly partial struct DocumentIntelligenceLayoutSkillOutputMode
    {
    }

    /// <summary> DocumentIntelligenceLayoutSkillMarkdownHeaderDepth namespace customization. </summary>
    [CodeGenType("DocumentIntelligenceLayoutSkillMarkdownHeaderDepth")]
    public readonly partial struct DocumentIntelligenceLayoutSkillMarkdownHeaderDepth
    {
    }

    /// <summary> IndexerStatus namespace customization. </summary>
    [CodeGenType("IndexerStatus")]
    public readonly partial struct IndexerStatus
    {
    }

    /// <summary> IndexerExecutionStatus namespace customization. </summary>
    [CodeGenType("IndexerExecutionStatus")]
    public readonly partial struct IndexerExecutionStatus
    {
    }

    /// <summary> ScoringFunctionInterpolation namespace customization. </summary>
    [CodeGenType("ScoringFunctionInterpolation")]
    public readonly partial struct ScoringFunctionInterpolation
    {
    }

    /// <summary> ScoringFunctionAggregation namespace customization. </summary>
    [CodeGenType("ScoringFunctionAggregation")]
    public readonly partial struct ScoringFunctionAggregation
    {
    }

    /// <summary> TokenCharacterKind namespace customization. </summary>
    [CodeGenType("TokenCharacterKind")]
    public readonly partial struct TokenCharacterKind
    {
    }

    /// <summary> MicrosoftTokenizerLanguage namespace customization. </summary>
    [CodeGenType("MicrosoftTokenizerLanguage")]
    public readonly partial struct MicrosoftTokenizerLanguage
    {
    }

    /// <summary> MicrosoftStemmingTokenizerLanguage namespace customization. </summary>
    [CodeGenType("MicrosoftStemmingTokenizerLanguage")]
    public readonly partial struct MicrosoftStemmingTokenizerLanguage
    {
    }

    /// <summary> CjkBigramTokenFilterScripts namespace customization. </summary>
    [CodeGenType("CjkBigramTokenFilterScripts")]
    public readonly partial struct CjkBigramTokenFilterScripts
    {
    }

    /// <summary> EdgeNGramTokenFilterSide namespace customization. </summary>
    [CodeGenType("EdgeNGramTokenFilterSide")]
    public readonly partial struct EdgeNGramTokenFilterSide
    {
    }

    /// <summary> PhoneticEncoder namespace customization. </summary>
    [CodeGenType("PhoneticEncoder")]
    public readonly partial struct PhoneticEncoder
    {
    }

    /// <summary> SnowballTokenFilterLanguage namespace customization. </summary>
    [CodeGenType("SnowballTokenFilterLanguage")]
    public readonly partial struct SnowballTokenFilterLanguage
    {
    }

    /// <summary> StemmerTokenFilterLanguage namespace customization. </summary>
    [CodeGenType("StemmerTokenFilterLanguage")]
    public readonly partial struct StemmerTokenFilterLanguage
    {
    }

    /// <summary> StopwordsList namespace customization. </summary>
    [CodeGenType("StopwordsList")]
    public readonly partial struct StopwordsList
    {
    }

    // Class types for Indexes namespace
    /// <summary> SearchIndexerDataSourceConnection namespace customization. </summary>
    [CodeGenType("SearchIndexerDataSourceConnection")]
    public partial class SearchIndexerDataSourceConnection
    {
    }

    /// <summary> SearchIndexerDataContainer namespace customization. </summary>
    [CodeGenType("SearchIndexerDataContainer")]
    public partial class SearchIndexerDataContainer
    {
    }

    /// <summary> DataChangeDetectionPolicy namespace customization. </summary>
    [CodeGenType("DataChangeDetectionPolicy")]
    public partial class DataChangeDetectionPolicy
    {
    }

    /// <summary> DataDeletionDetectionPolicy namespace customization. </summary>
    [CodeGenType("DataDeletionDetectionPolicy")]
    public partial class DataDeletionDetectionPolicy
    {
    }

    /// <summary> DocumentKeysOrIds namespace customization. </summary>
    [CodeGenType("DocumentKeysOrIds")]
    public partial class DocumentKeysOrIds
    {
    }

    /// <summary> SearchIndexer namespace customization. </summary>
    [CodeGenType("SearchIndexer")]
    public partial class SearchIndexer
    {
    }

    /// <summary> IndexingSchedule namespace customization. </summary>
    [CodeGenType("IndexingSchedule")]
    public partial class IndexingSchedule
    {
    }

    /// <summary> IndexingParameters namespace customization. </summary>
    [CodeGenType("IndexingParameters")]
    public partial class IndexingParameters
    {
    }

    /// <summary> IndexingParametersConfiguration namespace customization. </summary>
    [CodeGenType("IndexingParametersConfiguration")]
    public partial class IndexingParametersConfiguration
    {
    }

    /// <summary> FieldMapping namespace customization. </summary>
    [CodeGenType("FieldMapping")]
    public partial class FieldMapping
    {
    }

    /// <summary> FieldMappingFunction namespace customization. </summary>
    [CodeGenType("FieldMappingFunction")]
    public partial class FieldMappingFunction
    {
    }

    /// <summary> SearchIndexerCache namespace customization. </summary>
    [CodeGenType("SearchIndexerCache")]
    public partial class SearchIndexerCache
    {
    }

    /// <summary> SearchIndexerStatus namespace customization. </summary>
    [CodeGenType("SearchIndexerStatus")]
    public partial class SearchIndexerStatus
    {
    }

    /// <summary> IndexerExecutionResult namespace customization. </summary>
    [CodeGenType("IndexerExecutionResult")]
    public partial class IndexerExecutionResult
    {
    }

    /// <summary> SearchIndexerError namespace customization. </summary>
    [CodeGenType("SearchIndexerError")]
    public partial class SearchIndexerError
    {
    }

    /// <summary> SearchIndexerWarning namespace customization. </summary>
    [CodeGenType("SearchIndexerWarning")]
    public partial class SearchIndexerWarning
    {
    }

    /// <summary> SearchIndexerLimits namespace customization. </summary>
    [CodeGenType("SearchIndexerLimits")]
    public partial class SearchIndexerLimits
    {
    }

    /// <summary> SearchIndexerSkillset namespace customization. </summary>
    [CodeGenType("SearchIndexerSkillset")]
    public partial class SearchIndexerSkillset
    {
    }

    /// <summary> SearchIndexerSkill namespace customization. </summary>
    [CodeGenType("SearchIndexerSkill")]
    public partial class SearchIndexerSkill
    {
    }

    /// <summary> InputFieldMappingEntry namespace customization. </summary>
    [CodeGenType("InputFieldMappingEntry")]
    public partial class InputFieldMappingEntry
    {
    }

    /// <summary> OutputFieldMappingEntry namespace customization. </summary>
    [CodeGenType("OutputFieldMappingEntry")]
    public partial class OutputFieldMappingEntry
    {
    }

    /// <summary> CognitiveServicesAccount namespace customization. </summary>
    [CodeGenType("CognitiveServicesAccount")]
    public partial class CognitiveServicesAccount
    {
    }

    /// <summary> IndexerRuntime namespace customization. </summary>
    [CodeGenType("IndexerRuntime")]
    public partial class IndexerRuntime
    {
    }

    /// <summary> SynonymMap namespace customization. </summary>
    [CodeGenType("SynonymMap")]
    public partial class SynonymMap
    {
    }

    /// <summary> ListSynonymMapsResult namespace customization. </summary>
    [CodeGenType("ListSynonymMapsResult")]
    public partial class ListSynonymMapsResult
    {
    }

    /// <summary> SearchIndex namespace customization. </summary>
    [CodeGenType("SearchIndex")]
    public partial class SearchIndex
    {
    }

    /// <summary> SearchAlias namespace customization. </summary>
    [CodeGenType("SearchAlias")]
    public partial class SearchAlias
    {
    }

    /// <summary> ListAliasesResult namespace customization. </summary>
    [CodeGenType("ListAliasesResult")]
    public partial class ListAliasesResult
    {
    }

    /// <summary> AnalyzeTextOptions namespace customization. </summary>
    [CodeGenType("AnalyzeTextOptions")]
    public partial class AnalyzeTextOptions
    {
    }

    /// <summary> AnalyzeResult namespace customization. </summary>
    [CodeGenType("AnalyzeResult")]
    public partial class AnalyzeResult
    {
    }

    /// <summary> AnalyzedTokenInfo namespace customization. </summary>
    [CodeGenType("AnalyzedTokenInfo")]
    public partial class AnalyzedTokenInfo
    {
    }

    /// <summary> SearchServiceCounters namespace customization. </summary>
    [CodeGenType("SearchServiceCounters")]
    public partial class SearchServiceCounters
    {
    }

    /// <summary> KnowledgeBase namespace customization. </summary>
    [CodeGenType("KnowledgeBase")]
    public partial class KnowledgeBase
    {
    }

    /// <summary> KnowledgeSource namespace customization. </summary>
    [CodeGenType("KnowledgeSource")]
    public partial class KnowledgeSource
    {
    }

    /// <summary> ListKnowledgeBasesResult namespace customization. </summary>
    [CodeGenType("ListKnowledgeBasesResult")]
    public partial class ListKnowledgeBasesResult
    {
    }

    /// <summary> ListKnowledgeSourcesResult namespace customization. </summary>
    [CodeGenType("ListKnowledgeSourcesResult")]
    public partial class ListKnowledgeSourcesResult
    {
    }

    // Change detection and deletion detection policies
    /// <summary> HighWaterMarkChangeDetectionPolicy namespace customization. </summary>
    [CodeGenType("HighWaterMarkChangeDetectionPolicy")]
    public partial class HighWaterMarkChangeDetectionPolicy
    {
    }

    /// <summary> SqlIntegratedChangeTrackingPolicy namespace customization. </summary>
    [CodeGenType("SqlIntegratedChangeTrackingPolicy")]
    public partial class SqlIntegratedChangeTrackingPolicy
    {
    }

    /// <summary> SoftDeleteColumnDeletionDetectionPolicy namespace customization. </summary>
    [CodeGenType("SoftDeleteColumnDeletionDetectionPolicy")]
    public partial class SoftDeleteColumnDeletionDetectionPolicy
    {
    }

    /// <summary> NativeBlobSoftDeleteDeletionDetectionPolicy namespace customization. </summary>
    [CodeGenType("NativeBlobSoftDeleteDeletionDetectionPolicy")]
    public partial class NativeBlobSoftDeleteDeletionDetectionPolicy
    {
    }

    // Scoring functions
    /// <summary> ScoringProfile namespace customization. </summary>
    [CodeGenType("ScoringProfile")]
    public partial class ScoringProfile
    {
    }

    /// <summary> TextWeights namespace customization. </summary>
    [CodeGenType("TextWeights")]
    public partial class TextWeights
    {
    }

    /// <summary> ScoringFunction namespace customization. </summary>
    [CodeGenType("ScoringFunction")]
    public partial class ScoringFunction
    {
    }

    /// <summary> DistanceScoringFunction namespace customization. </summary>
    [CodeGenType("DistanceScoringFunction")]
    public partial class DistanceScoringFunction
    {
    }

    /// <summary> DistanceScoringParameters namespace customization. </summary>
    [CodeGenType("DistanceScoringParameters")]
    public partial class DistanceScoringParameters
    {
    }

    /// <summary> FreshnessScoringFunction namespace customization. </summary>
    [CodeGenType("FreshnessScoringFunction")]
    public partial class FreshnessScoringFunction
    {
    }

    /// <summary> FreshnessScoringParameters namespace customization. </summary>
    [CodeGenType("FreshnessScoringParameters")]
    public partial class FreshnessScoringParameters
    {
    }

    /// <summary> MagnitudeScoringFunction namespace customization. </summary>
    [CodeGenType("MagnitudeScoringFunction")]
    public partial class MagnitudeScoringFunction
    {
    }

    /// <summary> MagnitudeScoringParameters namespace customization. </summary>
    [CodeGenType("MagnitudeScoringParameters")]
    public partial class MagnitudeScoringParameters
    {
    }

    /// <summary> TagScoringFunction namespace customization. </summary>
    [CodeGenType("TagScoringFunction")]
    public partial class TagScoringFunction
    {
    }

    /// <summary> TagScoringParameters namespace customization. </summary>
    [CodeGenType("TagScoringParameters")]
    public partial class TagScoringParameters
    {
    }

    // Vector search types
    /// <summary> VectorSearch namespace customization. </summary>
    [CodeGenType("VectorSearch")]
    public partial class VectorSearch
    {
    }

    /// <summary> VectorSearchProfile namespace customization. </summary>
    [CodeGenType("VectorSearchProfile")]
    public partial class VectorSearchProfile
    {
    }

    /// <summary> VectorSearchAlgorithmConfiguration namespace customization. </summary>
    [CodeGenType("VectorSearchAlgorithmConfiguration")]
    public partial class VectorSearchAlgorithmConfiguration
    {
    }

    /// <summary> VectorSearchVectorizer namespace customization. </summary>
    [CodeGenType("VectorSearchVectorizer")]
    public partial class VectorSearchVectorizer
    {
    }

    /// <summary> VectorSearchCompression namespace customization. </summary>
    [CodeGenType("VectorSearchCompression")]
    public partial class VectorSearchCompression
    {
    }

    /// <summary> RescoringOptions namespace customization. </summary>
    [CodeGenType("RescoringOptions")]
    public partial class RescoringOptions
    {
    }

    /// <summary> HnswAlgorithmConfiguration namespace customization. </summary>
    [CodeGenType("HnswAlgorithmConfiguration")]
    public partial class HnswAlgorithmConfiguration
    {
    }

    /// <summary> HnswParameters namespace customization. </summary>
    [CodeGenType("HnswParameters")]
    public partial class HnswParameters
    {
    }

    /// <summary> ExhaustiveKnnAlgorithmConfiguration namespace customization. </summary>
    [CodeGenType("ExhaustiveKnnAlgorithmConfiguration")]
    public partial class ExhaustiveKnnAlgorithmConfiguration
    {
    }

    /// <summary> ExhaustiveKnnParameters namespace customization. </summary>
    [CodeGenType("ExhaustiveKnnParameters")]
    public partial class ExhaustiveKnnParameters
    {
    }

    /// <summary> ScalarQuantizationCompression namespace customization. </summary>
    [CodeGenType("ScalarQuantizationCompression")]
    public partial class ScalarQuantizationCompression
    {
    }

    /// <summary> ScalarQuantizationParameters namespace customization. </summary>
    [CodeGenType("ScalarQuantizationParameters")]
    public partial class ScalarQuantizationParameters
    {
    }

    /// <summary> BinaryQuantizationCompression namespace customization. </summary>
    [CodeGenType("BinaryQuantizationCompression")]
    public partial class BinaryQuantizationCompression
    {
    }

    // Vectorizers
    /// <summary> AzureOpenAIVectorizer namespace customization. </summary>
    [CodeGenType("AzureOpenAIVectorizer")]
    public partial class AzureOpenAIVectorizer
    {
    }

    /// <summary> AzureOpenAIVectorizerParameters namespace customization. </summary>
    [CodeGenType("AzureOpenAIVectorizerParameters")]
    public partial class AzureOpenAIVectorizerParameters
    {
    }

    /// <summary> WebApiVectorizer namespace customization. </summary>
    [CodeGenType("WebApiVectorizer")]
    public partial class WebApiVectorizer
    {
    }

    /// <summary> WebApiVectorizerParameters namespace customization. </summary>
    [CodeGenType("WebApiVectorizerParameters")]
    public partial class WebApiVectorizerParameters
    {
    }

    /// <summary> AIServicesVisionVectorizer namespace customization. </summary>
    [CodeGenType("AIServicesVisionVectorizer")]
    public partial class AIServicesVisionVectorizer
    {
    }

    /// <summary> AIServicesVisionParameters namespace customization. </summary>
    [CodeGenType("AIServicesVisionParameters")]
    public partial class AIServicesVisionParameters
    {
    }

    /// <summary> AzureMachineLearningVectorizer namespace customization. </summary>
    [CodeGenType("AzureMachineLearningVectorizer")]
    public partial class AzureMachineLearningVectorizer
    {
    }

    /// <summary> AzureMachineLearningParameters namespace customization. </summary>
    [CodeGenType("AzureMachineLearningParameters")]
    public partial class AzureMachineLearningParameters
    {
    }

    // Identity types
    /// <summary> SearchIndexerDataIdentity namespace customization. </summary>
    [CodeGenType("SearchIndexerDataIdentity")]
    public partial class SearchIndexerDataIdentity
    {
    }

    /// <summary> SearchIndexerDataNoneIdentity namespace customization. </summary>
    [CodeGenType("SearchIndexerDataNoneIdentity")]
    public partial class SearchIndexerDataNoneIdentity
    {
    }

    /// <summary> SearchIndexerDataUserAssignedIdentity namespace customization. </summary>
    [CodeGenType("SearchIndexerDataUserAssignedIdentity")]
    public partial class SearchIndexerDataUserAssignedIdentity
    {
    }

    // Cognitive services accounts
    /// <summary> DefaultCognitiveServicesAccount namespace customization. </summary>
    [CodeGenType("DefaultCognitiveServicesAccount")]
    public partial class DefaultCognitiveServicesAccount
    {
    }

    /// <summary> CognitiveServicesAccountKey namespace customization. </summary>
    [CodeGenType("CognitiveServicesAccountKey")]
    public partial class CognitiveServicesAccountKey
    {
    }

    /// <summary> AIServicesAccountKey namespace customization. </summary>
    [CodeGenType("AIServicesAccountKey")]
    public partial class AIServicesAccountKey
    {
    }

    /// <summary> AIServicesAccountIdentity namespace customization. </summary>
    [CodeGenType("AIServicesAccountIdentity")]
    public partial class AIServicesAccountIdentity
    {
    }

    // Skills
    /// <summary> ConditionalSkill namespace customization. </summary>
    [CodeGenType("ConditionalSkill")]
    public partial class ConditionalSkill
    {
    }

    /// <summary> KeyPhraseExtractionSkill namespace customization. </summary>
    [CodeGenType("KeyPhraseExtractionSkill")]
    public partial class KeyPhraseExtractionSkill
    {
    }

    /// <summary> OcrSkill namespace customization. </summary>
    [CodeGenType("OcrSkill")]
    public partial class OcrSkill
    {
    }

    /// <summary> LanguageDetectionSkill namespace customization. </summary>
    [CodeGenType("LanguageDetectionSkill")]
    public partial class LanguageDetectionSkill
    {
    }

    /// <summary> ShaperSkill namespace customization. </summary>
    [CodeGenType("ShaperSkill")]
    public partial class ShaperSkill
    {
    }

    /// <summary> MergeSkill namespace customization. </summary>
    [CodeGenType("MergeSkill")]
    public partial class MergeSkill
    {
    }

    /// <summary> SentimentSkill namespace customization. </summary>
    [CodeGenType("SentimentSkill")]
    public partial class SentimentSkill
    {
    }

    /// <summary> EntityLinkingSkill namespace customization. </summary>
    [CodeGenType("EntityLinkingSkill")]
    public partial class EntityLinkingSkill
    {
    }

    /// <summary> SplitSkill namespace customization. </summary>
    [CodeGenType("SplitSkill")]
    public partial class SplitSkill
    {
    }

    /// <summary> CustomEntityLookupSkill namespace customization. </summary>
    [CodeGenType("CustomEntityLookupSkill")]
    public partial class CustomEntityLookupSkill
    {
    }

    /// <summary> TextTranslationSkill namespace customization. </summary>
    [CodeGenType("TextTranslationSkill")]
    public partial class TextTranslationSkill
    {
    }

    /// <summary> DocumentExtractionSkill namespace customization. </summary>
    [CodeGenType("DocumentExtractionSkill")]
    public partial class DocumentExtractionSkill
    {
    }

    /// <summary> DocumentIntelligenceLayoutSkill namespace customization. </summary>
    [CodeGenType("DocumentIntelligenceLayoutSkill")]
    public partial class DocumentIntelligenceLayoutSkill
    {
    }

    /// <summary> WebApiSkill namespace customization. </summary>
    [CodeGenType("WebApiSkill")]
    public partial class WebApiSkill
    {
    }

    /// <summary> AzureMachineLearningSkill namespace customization. </summary>
    [CodeGenType("AzureMachineLearningSkill")]
    public partial class AzureMachineLearningSkill
    {
    }

    /// <summary> AzureOpenAIEmbeddingSkill namespace customization. </summary>
    [CodeGenType("AzureOpenAIEmbeddingSkill")]
    public partial class AzureOpenAIEmbeddingSkill
    {
    }

    /// <summary> VisionVectorizeSkill namespace customization. </summary>
    [CodeGenType("VisionVectorizeSkill")]
    public partial class VisionVectorizeSkill
    {
    }

    /// <summary> ContentUnderstandingSkill namespace customization. </summary>
    [CodeGenType("ContentUnderstandingSkill")]
    public partial class ContentUnderstandingSkill
    {
    }

    /// <summary> ChatCompletionSkill namespace customization. </summary>
    [CodeGenType("ChatCompletionSkill")]
    public partial class ChatCompletionSkill
    {
    }

    /// <summary> AzureOpenAITokenizerParameters namespace customization. </summary>
    [CodeGenType("AzureOpenAITokenizerParameters")]
    public partial class AzureOpenAITokenizerParameters
    {
    }

    // Skill support types
    /// <summary> CustomEntity namespace customization. </summary>
    [CodeGenType("CustomEntity")]
    public partial class CustomEntity
    {
    }

    /// <summary> CustomEntityAlias namespace customization. </summary>
    [CodeGenType("CustomEntityAlias")]
    public partial class CustomEntityAlias
    {
    }

    /// <summary> ContentUnderstandingSkillChunkingProperties namespace customization. </summary>
    [CodeGenType("ContentUnderstandingSkillChunkingProperties")]
    public partial class ContentUnderstandingSkillChunkingProperties
    {
    }

    /// <summary> ContentUnderstandingSkillChunkingUnit namespace customization. </summary>
    [CodeGenType("ContentUnderstandingSkillChunkingUnit")]
    public readonly partial struct ContentUnderstandingSkillChunkingUnit
    {
    }

    /// <summary> ContentUnderstandingSkillExtractionOptions namespace customization. </summary>
    [CodeGenType("ContentUnderstandingSkillExtractionOptions")]
    public readonly partial struct ContentUnderstandingSkillExtractionOptions
    {
    }

    /// <summary> DocumentIntelligenceLayoutSkillChunkingProperties namespace customization. </summary>
    [CodeGenType("DocumentIntelligenceLayoutSkillChunkingProperties")]
    public partial class DocumentIntelligenceLayoutSkillChunkingProperties
    {
    }

    /// <summary> DocumentIntelligenceLayoutSkillChunkingUnit namespace customization. </summary>
    [CodeGenType("DocumentIntelligenceLayoutSkillChunkingUnit")]
    public readonly partial struct DocumentIntelligenceLayoutSkillChunkingUnit
    {
    }

    /// <summary> DocumentIntelligenceLayoutSkillExtractionOptions namespace customization. </summary>
    [CodeGenType("DocumentIntelligenceLayoutSkillExtractionOptions")]
    public readonly partial struct DocumentIntelligenceLayoutSkillExtractionOptions
    {
    }

    /// <summary> DocumentIntelligenceLayoutSkillOutputFormat namespace customization. </summary>
    [CodeGenType("DocumentIntelligenceLayoutSkillOutputFormat")]
    public readonly partial struct DocumentIntelligenceLayoutSkillOutputFormat
    {
    }

    /// <summary> WebApiHttpHeaders namespace customization. </summary>
    [CodeGenType("WebApiHttpHeaders")]
    public partial class WebApiHttpHeaders
    {
    }

    /// <summary> ChatCompletionCommonModelParameters namespace customization. </summary>
    [CodeGenType("ChatCompletionCommonModelParameters")]
    public partial class ChatCompletionCommonModelParameters
    {
    }

    /// <summary> ChatCompletionExtraParametersBehavior namespace customization. </summary>
    [CodeGenType("ChatCompletionExtraParametersBehavior")]
    public readonly partial struct ChatCompletionExtraParametersBehavior
    {
    }

    /// <summary> ChatCompletionResponseFormat namespace customization. </summary>
    [CodeGenType("ChatCompletionResponseFormat")]
    public partial class ChatCompletionResponseFormat
    {
    }

    /// <summary> ChatCompletionResponseFormatType namespace customization. </summary>
    [CodeGenType("ChatCompletionResponseFormatType")]
    public readonly partial struct ChatCompletionResponseFormatType
    {
    }

    /// <summary> ChatCompletionSchema namespace customization. </summary>
    [CodeGenType("ChatCompletionSchema")]
    public partial class ChatCompletionSchema
    {
    }

    /// <summary> ChatCompletionSchemaProperties namespace customization. </summary>
    [CodeGenType("ChatCompletionSchemaProperties")]
    public partial class ChatCompletionSchemaProperties
    {
    }

    // Analyzers
    /// <summary> LexicalAnalyzer namespace customization. </summary>
    [CodeGenType("LexicalAnalyzer")]
    public partial class LexicalAnalyzer
    {
    }

    /// <summary> CustomAnalyzer namespace customization. </summary>
    [CodeGenType("CustomAnalyzer")]
    public partial class CustomAnalyzer
    {
    }

    /// <summary> PatternAnalyzer namespace customization. </summary>
    [CodeGenType("PatternAnalyzer")]
    public partial class PatternAnalyzer
    {
    }

    /// <summary> LuceneStandardAnalyzer namespace customization. </summary>
    [CodeGenType("LuceneStandardAnalyzer")]
    public partial class LuceneStandardAnalyzer
    {
    }

    /// <summary> StopAnalyzer namespace customization. </summary>
    [CodeGenType("StopAnalyzer")]
    public partial class StopAnalyzer
    {
    }

    // Normalizers
    /// <summary> LexicalNormalizer namespace customization. </summary>
    [CodeGenType("LexicalNormalizer")]
    public partial class LexicalNormalizer
    {
    }

    /// <summary> CustomNormalizer namespace customization. </summary>
    [CodeGenType("CustomNormalizer")]
    public partial class CustomNormalizer
    {
    }

    // Tokenizers
    /// <summary> LexicalTokenizer namespace customization. </summary>
    [CodeGenType("LexicalTokenizer")]
    public partial class LexicalTokenizer
    {
    }

    /// <summary> ClassicTokenizer namespace customization. </summary>
    [CodeGenType("ClassicTokenizer")]
    public partial class ClassicTokenizer
    {
    }

    /// <summary> EdgeNGramTokenizer namespace customization. </summary>
    [CodeGenType("EdgeNGramTokenizer")]
    public partial class EdgeNGramTokenizer
    {
    }

    /// <summary> MicrosoftLanguageTokenizer namespace customization. </summary>
    [CodeGenType("MicrosoftLanguageTokenizer")]
    public partial class MicrosoftLanguageTokenizer
    {
    }

    /// <summary> MicrosoftLanguageStemmingTokenizer namespace customization. </summary>
    [CodeGenType("MicrosoftLanguageStemmingTokenizer")]
    public partial class MicrosoftLanguageStemmingTokenizer
    {
    }

    /// <summary> PatternTokenizer namespace customization. </summary>
    [CodeGenType("PatternTokenizer")]
    public partial class PatternTokenizer
    {
    }

    /// <summary> LuceneStandardTokenizer namespace customization. </summary>
    [CodeGenType("LuceneStandardTokenizer")]
    public partial class LuceneStandardTokenizer
    {
    }

    /// <summary> UaxUrlEmailTokenizer namespace customization. </summary>
    [CodeGenType("UaxUrlEmailTokenizer")]
    public partial class UaxUrlEmailTokenizer
    {
    }

    [CodeGenType("KeywordTokenizer")]
    public partial class KeywordTokenizer
    {
    }

    // Token Filters
    /// <summary> TokenFilter namespace customization. </summary>
    [CodeGenType("TokenFilter")]
    public partial class TokenFilter
    {
    }

    /// <summary> AsciiFoldingTokenFilter namespace customization. </summary>
    [CodeGenType("AsciiFoldingTokenFilter")]
    public partial class AsciiFoldingTokenFilter
    {
    }

    /// <summary> CjkBigramTokenFilter namespace customization. </summary>
    [CodeGenType("CjkBigramTokenFilter")]
    public partial class CjkBigramTokenFilter
    {
    }

    /// <summary> CommonGramTokenFilter namespace customization. </summary>
    [CodeGenType("CommonGramTokenFilter")]
    public partial class CommonGramTokenFilter
    {
    }

    /// <summary> DictionaryDecompounderTokenFilter namespace customization. </summary>
    [CodeGenType("DictionaryDecompounderTokenFilter")]
    public partial class DictionaryDecompounderTokenFilter
    {
    }

    /// <summary> EdgeNGramTokenFilter namespace customization. </summary>
    [CodeGenType("EdgeNGramTokenFilter")]
    public partial class EdgeNGramTokenFilter
    {
    }

    /// <summary> EdgeNGramTokenFilterV2 namespace customization. </summary>
    [CodeGenType("EdgeNGramTokenFilterV2")]
    public partial class EdgeNGramTokenFilterV2
    {
    }

    /// <summary> ElisionTokenFilter namespace customization. </summary>
    [CodeGenType("ElisionTokenFilter")]
    public partial class ElisionTokenFilter
    {
    }

    /// <summary> KeepTokenFilter namespace customization. </summary>
    [CodeGenType("KeepTokenFilter")]
    public partial class KeepTokenFilter
    {
    }

    /// <summary> KeywordMarkerTokenFilter namespace customization. </summary>
    [CodeGenType("KeywordMarkerTokenFilter")]
    public partial class KeywordMarkerTokenFilter
    {
    }

    /// <summary> LengthTokenFilter namespace customization. </summary>
    [CodeGenType("LengthTokenFilter")]
    public partial class LengthTokenFilter
    {
    }

    /// <summary> LimitTokenFilter namespace customization. </summary>
    [CodeGenType("LimitTokenFilter")]
    public partial class LimitTokenFilter
    {
    }

    /// <summary> NGramTokenFilter namespace customization. </summary>
    [CodeGenType("NGramTokenFilter")]
    public partial class NGramTokenFilter
    {
    }

    /// <summary> PatternCaptureTokenFilter namespace customization. </summary>
    [CodeGenType("PatternCaptureTokenFilter")]
    public partial class PatternCaptureTokenFilter
    {
    }

    /// <summary> PatternReplaceTokenFilter namespace customization. </summary>
    [CodeGenType("PatternReplaceTokenFilter")]
    public partial class PatternReplaceTokenFilter
    {
    }

    /// <summary> PhoneticTokenFilter namespace customization. </summary>
    [CodeGenType("PhoneticTokenFilter")]
    public partial class PhoneticTokenFilter
    {
    }

    /// <summary> ShingleTokenFilter namespace customization. </summary>
    [CodeGenType("ShingleTokenFilter")]
    public partial class ShingleTokenFilter
    {
    }

    /// <summary> SnowballTokenFilter namespace customization. </summary>
    [CodeGenType("SnowballTokenFilter")]
    public partial class SnowballTokenFilter
    {
    }

    /// <summary> StemmerTokenFilter namespace customization. </summary>
    [CodeGenType("StemmerTokenFilter")]
    public partial class StemmerTokenFilter
    {
    }

    /// <summary> StemmerOverrideTokenFilter namespace customization. </summary>
    [CodeGenType("StemmerOverrideTokenFilter")]
    public partial class StemmerOverrideTokenFilter
    {
    }

    /// <summary> StopwordsTokenFilter namespace customization. </summary>
    [CodeGenType("StopwordsTokenFilter")]
    public partial class StopwordsTokenFilter
    {
    }

    /// <summary> SynonymTokenFilter namespace customization. </summary>
    [CodeGenType("SynonymTokenFilter")]
    public partial class SynonymTokenFilter
    {
    }

    /// <summary> TruncateTokenFilter namespace customization. </summary>
    [CodeGenType("TruncateTokenFilter")]
    public partial class TruncateTokenFilter
    {
    }

    /// <summary> UniqueTokenFilter namespace customization. </summary>
    [CodeGenType("UniqueTokenFilter")]
    public partial class UniqueTokenFilter
    {
    }

    /// <summary> WordDelimiterTokenFilter namespace customization. </summary>
    [CodeGenType("WordDelimiterTokenFilter")]
    public partial class WordDelimiterTokenFilter
    {
    }

    // Char Filters
    /// <summary> CharFilter namespace customization. </summary>
    [CodeGenType("CharFilter")]
    public partial class CharFilter
    {
    }

    /// <summary> MappingCharFilter namespace customization. </summary>
    [CodeGenType("MappingCharFilter")]
    public partial class MappingCharFilter
    {
    }

    /// <summary> PatternReplaceCharFilter namespace customization. </summary>
    [CodeGenType("PatternReplaceCharFilter")]
    public partial class PatternReplaceCharFilter
    {
    }

    /// <summary> ClassicSimilarityAlgorithm namespace customization. </summary>
    [CodeGenType("ClassicSimilarityAlgorithm")]
    public partial class ClassicSimilarityAlgorithm
    {
    }

    /// <summary> BM25SimilarityAlgorithm namespace customization. </summary>
    [CodeGenType("BM25SimilarityAlgorithm")]
    public partial class BM25SimilarityAlgorithm
    {
    }

    // Semantic types
    /// <summary> SemanticSearch namespace customization. </summary>
    [CodeGenType("SemanticSearch")]
    public partial class SemanticSearch
    {
    }

    /// <summary> SemanticConfiguration namespace customization. </summary>
    [CodeGenType("SemanticConfiguration")]
    public partial class SemanticConfiguration
    {
    }

    /// <summary> SemanticPrioritizedFields namespace customization. </summary>
    [CodeGenType("SemanticPrioritizedFields")]
    public partial class SemanticPrioritizedFields
    {
    }

    /// <summary> SemanticField namespace customization. </summary>
    [CodeGenType("SemanticField")]
    public partial class SemanticField
    {
    }

    // Search field
    /// <summary> SearchField namespace customization. </summary>
    [CodeGenType("SearchField")]
    public partial class SearchField
    {
    }

    // CORS options
    /// <summary> CorsOptions namespace customization. </summary>
    [CodeGenType("CorsOptions")]
    public partial class CorsOptions
    {
    }

    /// <summary> IndexStatisticsSummary namespace customization. </summary>
    [CodeGenType("IndexStatisticsSummary")]
    public partial class IndexStatisticsSummary
    {
    }

    // Index projections
    /// <summary> SearchIndexerIndexProjection namespace customization. </summary>
    [CodeGenType("SearchIndexerIndexProjection")]
    public partial class SearchIndexerIndexProjection
    {
    }

    /// <summary> SearchIndexerIndexProjectionSelector namespace customization. </summary>
    [CodeGenType("SearchIndexerIndexProjectionSelector")]
    public partial class SearchIndexerIndexProjectionSelector
    {
    }

    /// <summary> SearchIndexerIndexProjectionsParameters namespace customization. </summary>
    [CodeGenType("SearchIndexerIndexProjectionsParameters")]
    public partial class SearchIndexerIndexProjectionsParameters
    {
    }

    // Indexer additional types
    /// <summary> IndexerPermissionOption namespace customization. </summary>
    [CodeGenType("IndexerPermissionOption")]
    public readonly partial struct IndexerPermissionOption
    {
    }

    /// <summary> RankingOrder namespace customization. </summary>
    [CodeGenType("RankingOrder")]
    public readonly partial struct RankingOrder
    {
    }

    /// <summary> SearchOptions namespace customization. </summary>
    [CodeGenType("SearchOptions")]
    public partial class SearchOptions
    {
    }

    /// <summary> SearchIndexPermissionFilterOption namespace customization. </summary>
    [CodeGenType("SearchIndexPermissionFilterOption")]
    public readonly partial struct SearchIndexPermissionFilterOption
    {
    }

    /// <summary> IndexerResyncBody namespace customization. </summary>
    [CodeGenType("IndexerResyncBody")]
    public partial class IndexerResyncBody
    {
    }

    /// <summary> IndexerResyncOption namespace customization. </summary>
    [CodeGenType("IndexerResyncOption")]
    public readonly partial struct IndexerResyncOption
    {
    }

    // Service indexers runtime
    /// <summary> ServiceIndexersRuntime namespace customization. </summary>
    [CodeGenType("ServiceIndexersRuntime")]
    public partial class ServiceIndexersRuntime
    {
    }

    // Created resources
    /// <summary> CreatedResources namespace customization. </summary>
    [CodeGenType("CreatedResources")]
    public partial class CreatedResources
    {
    }

    // Search index field reference
    /// <summary> SearchIndexFieldReference namespace customization. </summary>
    [CodeGenType("SearchIndexFieldReference")]
    public partial class SearchIndexFieldReference
    {
    }

    // Azure OpenAI parameters
    /// <summary> AzureOpenAiParameters namespace customization. </summary>
    [CodeGenType("AzureOpenAiParameters")]
    public partial class AzureOpenAiParameters
    {
    }

    // Knowledge base model types
    /// <summary> KnowledgeBaseModel namespace customization. </summary>
    [CodeGenType("KnowledgeBaseModel")]
    public partial class KnowledgeBaseModel
    {
    }

    /// <summary> KnowledgeBaseModelKind namespace customization. </summary>
    [CodeGenType("KnowledgeBaseModelKind")]
    public readonly partial struct KnowledgeBaseModelKind
    {
    }

    /// <summary> KnowledgeBaseAzureOpenAIModel namespace customization. </summary>
    [CodeGenType("KnowledgeBaseAzureOpenAIModel")]
    public partial class KnowledgeBaseAzureOpenAIModel
    {
    }

    // Knowledge source types
    /// <summary> KnowledgeSourceReference namespace customization. </summary>
    [CodeGenType("KnowledgeSourceReference")]
    public partial class KnowledgeSourceReference
    {
    }

    /// <summary> KnowledgeSourceKind namespace customization. </summary>
    [CodeGenType("KnowledgeSourceKind")]
    public readonly partial struct KnowledgeSourceKind
    {
    }

    /// <summary> KnowledgeSourceContentExtractionMode namespace customization. </summary>
    [CodeGenType("KnowledgeSourceContentExtractionMode")]
    public readonly partial struct KnowledgeSourceContentExtractionMode
    {
    }

    /// <summary> KnowledgeSourceIngestionPermissionOption namespace customization. </summary>
    [CodeGenType("KnowledgeSourceIngestionPermissionOption")]
    public readonly partial struct KnowledgeSourceIngestionPermissionOption
    {
    }

    /// <summary> KnowledgeSourceSynchronizationStatus namespace customization. </summary>
    [CodeGenType("KnowledgeSourceSynchronizationStatus")]
    public readonly partial struct KnowledgeSourceSynchronizationStatus
    {
    }

    // Knowledge source implementations
    /// <summary> SearchIndexKnowledgeSource namespace customization. </summary>
    [CodeGenType("SearchIndexKnowledgeSource")]
    public partial class SearchIndexKnowledgeSource
    {
    }

    /// <summary> SearchIndexKnowledgeSourceParameters namespace customization. </summary>
    [CodeGenType("SearchIndexKnowledgeSourceParameters")]
    public partial class SearchIndexKnowledgeSourceParameters
    {
    }

    /// <summary> AzureBlobKnowledgeSource namespace customization. </summary>
    [CodeGenType("AzureBlobKnowledgeSource")]
    public partial class AzureBlobKnowledgeSource
    {
    }

    /// <summary> AzureBlobKnowledgeSourceParameters namespace customization. </summary>
    [CodeGenType("AzureBlobKnowledgeSourceParameters")]
    public partial class AzureBlobKnowledgeSourceParameters
    {
    }

    /// <summary> IndexedOneLakeKnowledgeSource namespace customization. </summary>
    [CodeGenType("IndexedOneLakeKnowledgeSource")]
    public partial class IndexedOneLakeKnowledgeSource
    {
    }

    /// <summary> IndexedOneLakeKnowledgeSourceParameters namespace customization. </summary>
    [CodeGenType("IndexedOneLakeKnowledgeSourceParameters")]
    public partial class IndexedOneLakeKnowledgeSourceParameters
    {
    }

    /// <summary> IndexedSharePointContainerName namespace customization. </summary>
    [CodeGenType("IndexedSharePointContainerName")]
    public readonly partial struct IndexedSharePointContainerName
    {
    }

    /// <summary> IndexedSharePointKnowledgeSource namespace customization. </summary>
    [CodeGenType("IndexedSharePointKnowledgeSource")]
    public partial class IndexedSharePointKnowledgeSource
    {
    }

    /// <summary> IndexedSharePointKnowledgeSourceParameters namespace customization. </summary>
    [CodeGenType("IndexedSharePointKnowledgeSourceParameters")]
    public partial class IndexedSharePointKnowledgeSourceParameters
    {
    }

    /// <summary> RemoteSharePointKnowledgeSource namespace customization. </summary>
    [CodeGenType("RemoteSharePointKnowledgeSource")]
    public partial class RemoteSharePointKnowledgeSource
    {
    }

    /// <summary> RemoteSharePointKnowledgeSourceParameters namespace customization. </summary>
    [CodeGenType("RemoteSharePointKnowledgeSourceParameters")]
    public partial class RemoteSharePointKnowledgeSourceParameters
    {
    }

    /// <summary> WebKnowledgeSource namespace customization. </summary>
    [CodeGenType("WebKnowledgeSource")]
    public partial class WebKnowledgeSource
    {
    }

    /// <summary> WebKnowledgeSourceDomain namespace customization. </summary>
    [CodeGenType("WebKnowledgeSourceDomain")]
    public partial class WebKnowledgeSourceDomain
    {
    }

    /// <summary> WebKnowledgeSourceDomains namespace customization. </summary>
    [CodeGenType("WebKnowledgeSourceDomains")]
    public partial class WebKnowledgeSourceDomains
    {
    }

    /// <summary> WebKnowledgeSourceParameters namespace customization. </summary>
    [CodeGenType("WebKnowledgeSourceParameters")]
    public partial class WebKnowledgeSourceParameters
    {
    }
}
