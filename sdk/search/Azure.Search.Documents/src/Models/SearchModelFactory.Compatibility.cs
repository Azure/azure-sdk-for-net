// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;

namespace Azure.Search.Documents.Models
{
    public static partial class SearchModelFactory
    {
        // Preserve GA signatures and defaults; expanded response factories require every argument to avoid overload ambiguity.
        /// <summary> Initializes a new instance of VectorQuery for mocking. </summary>
        /// <param name="kNearestNeighborsCount"> The number of nearest neighbors to return. </param>
        /// <param name="fieldsRaw"> The vector fields to search. </param>
        /// <param name="exhaustive"> Whether to use exhaustive nearest-neighbor search. </param>
        /// <param name="oversampling"> The oversampling factor. </param>
        /// <param name="weight"> The relative weight of the vector query. </param>
        /// <param name="kind"> The kind of vector query. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static VectorQuery VectorQuery(int? kNearestNeighborsCount = default, string fieldsRaw = default, bool? exhaustive = default, double? oversampling = default, float? weight = default, string kind = default) =>
            VectorQuery(kNearestNeighborsCount: kNearestNeighborsCount, fieldsRaw: fieldsRaw, exhaustive: exhaustive, oversampling: oversampling, weight: weight, threshold: default, filterOverride: default, perDocumentVectorLimit: default, topicGraph: default, kind: kind);

        /// <summary> Initializes a new instance of KnowledgeSource for mocking. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> The description of the knowledge source. </param>
        /// <param name="kind"> The kind of knowledge source. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> The encryption key for the knowledge source. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KnowledgeSource KnowledgeSource(string name = default, string description = default, string kind = default, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = default) =>
            KnowledgeSource(name: name, description: description, kind: kind, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey);

        /// <summary> Initializes a new instance of AzureBlobKnowledgeSource for mocking. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> The description of the knowledge source. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> The encryption key for the knowledge source. </param>
        /// <param name="azureBlobParameters"> The Azure Blob parameters. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AzureBlobKnowledgeSource AzureBlobKnowledgeSource(string name = null, string description = null, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = null, AzureBlobKnowledgeSourceParameters azureBlobParameters = null) =>
            AzureBlobKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, azureBlobParameters: azureBlobParameters);

        /// <summary> Initializes a new instance of IndexedOneLakeKnowledgeSource for mocking. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> The description of the knowledge source. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> The encryption key for the knowledge source. </param>
        /// <param name="indexedOneLakeParameters"> The OneLake parameters. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IndexedOneLakeKnowledgeSource IndexedOneLakeKnowledgeSource(string name = null, string description = null, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = null, IndexedOneLakeKnowledgeSourceParameters indexedOneLakeParameters = null) =>
            IndexedOneLakeKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, indexedOneLakeParameters: indexedOneLakeParameters);

        /// <summary> Initializes a new instance of SearchIndexKnowledgeSource for mocking. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> The description of the knowledge source. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> The encryption key for the knowledge source. </param>
        /// <param name="searchIndexParameters"> The search index parameters. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SearchIndexKnowledgeSource SearchIndexKnowledgeSource(string name = null, string description = null, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = null, SearchIndexKnowledgeSourceParameters searchIndexParameters = null) =>
            SearchIndexKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, searchIndexParameters: searchIndexParameters);

        /// <summary> Initializes a new instance of WebKnowledgeSource for mocking. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> The description of the knowledge source. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> The encryption key for the knowledge source. </param>
        /// <param name="webParameters"> The web parameters. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WebKnowledgeSource WebKnowledgeSource(string name = null, string description = null, ETag? eTag = default, SearchResourceEncryptionKey encryptionKey = null, WebKnowledgeSourceParameters webParameters = null) =>
            WebKnowledgeSource(name: name, description: description, resultsProcessing: default, eTag: eTag, encryptionKey: encryptionKey, webParameters: webParameters);

        /// <summary> Initializes a new instance of SynchronizationState for mocking. </summary>
        /// <param name="startTime"> The start time of synchronization. </param>
        /// <param name="itemsUpdatesProcessed"> The number of processed updates. </param>
        /// <param name="itemsUpdatesFailed"> The number of failed updates. </param>
        /// <param name="itemsSkipped"> The number of skipped items. </param>
        /// <param name="errors"> The synchronization errors. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SynchronizationState SynchronizationState(DateTimeOffset startTime = default, int itemsUpdatesProcessed = 0, int itemsUpdatesFailed = 0, int itemsSkipped = 0, IEnumerable<KnowledgeSourceSynchronizationError> errors = null) =>
            SynchronizationState(graphStatistics: default, startTime: startTime, itemsUpdatesProcessed: itemsUpdatesProcessed, itemsUpdatesFailed: itemsUpdatesFailed, itemsSkipped: itemsSkipped, errors: errors);

        /// <summary> Initializes a new instance of CompletedSynchronizationState for mocking. </summary>
        /// <param name="startTime"> The start time of synchronization. </param>
        /// <param name="endTime"> The end time of synchronization. </param>
        /// <param name="itemsUpdatesProcessed"> The number of processed updates. </param>
        /// <param name="itemsUpdatesFailed"> The number of failed updates. </param>
        /// <param name="itemsSkipped"> The number of skipped items. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CompletedSynchronizationState CompletedSynchronizationState(DateTimeOffset startTime = default, DateTimeOffset endTime = default, int itemsUpdatesProcessed = 0, int itemsUpdatesFailed = 0, int itemsSkipped = 0) =>
            CompletedSynchronizationState(graphStatistics: default, startTime: startTime, endTime: endTime, itemsUpdatesProcessed: itemsUpdatesProcessed, itemsUpdatesFailed: itemsUpdatesFailed, itemsSkipped: itemsSkipped);

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
        public static SearchIndex SearchIndex(string name = null, string description = null, IEnumerable<ScoringProfile> scoringProfiles = null, string defaultScoringProfile = null, CorsOptions corsOptions = null, IEnumerable<SearchSuggester> suggesters = null, IEnumerable<LexicalAnalyzer> analyzers = null, IEnumerable<LexicalTokenizer> tokenizers = null, IEnumerable<TokenFilter> tokenFilters = null, IEnumerable<CharFilter> charFilters = null, IEnumerable<LexicalNormalizer> normalizers = null, SearchResourceEncryptionKey encryptionKey = null, SimilarityAlgorithm similarity = null, SemanticSearch semanticSearch = null, VectorSearch vectorSearch = null, IEnumerable<SearchField> fields = null, string etag = null) =>
            SearchIndex(name: name, description: description, scoringProfiles: scoringProfiles, defaultScoringProfile: defaultScoringProfile, corsOptions: corsOptions, suggesters: suggesters, analyzers: analyzers, tokenizers: tokenizers, tokenFilters: tokenFilters, charFilters: charFilters, normalizers: normalizers, encryptionKey: encryptionKey, similarity: similarity, semanticSearch: semanticSearch, vectorSearch: vectorSearch, permissionFilterOption: default, sharePointConnectorAppRegistration: default, fields: fields, etag: etag);

        /// <summary> Specifies runtime parameters for a azure blob knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.AzureBlobKnowledgeSourceParams"/> instance for mocking. </returns>
        public static AzureBlobKnowledgeSourceParams AzureBlobKnowledgeSourceParams(
            string knowledgeSourceName = null,
            bool? includeReferences = default(bool?),
            bool? includeReferenceSourceData = default(bool?),
            bool? alwaysQuerySource = default(bool?),
            bool? failOnError = default(bool?),
            float? rerankerThreshold = default(float?),
            int? maxOutputDocuments = default(int?)) =>
            AzureBlobKnowledgeSourceParams(
                knowledgeSourceName: knowledgeSourceName,
                includeReferences: includeReferences,
                includeReferenceSourceData: includeReferenceSourceData,
                alwaysQuerySource: alwaysQuerySource,
                neverQuerySource: default,
                failOnError: failOnError,
                rerankerThreshold: rerankerThreshold,
                resultsProcessing: default,
                maxOutputDocuments: maxOutputDocuments,
                enableImageServing: default,
                graphParameters: default,
                topicGraph: default);

        internal static AzureBlobKnowledgeSourceParams AzureBlobKnowledgeSourceParams(
            string knowledgeSourceName,
            bool? includeReferences,
            bool? includeReferenceSourceData,
            bool? alwaysQuerySource,
            bool? neverQuerySource,
            bool? failOnError,
            float? rerankerThreshold,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            int? maxOutputDocuments,
            bool? enableImageServing,
            AgentRuntimeGraphParams graphParameters,
            VectorQueryTopicGraph topicGraph)
        {
            return new AzureBlobKnowledgeSourceParams(
                knowledgeSourceName,
                includeReferences,
                includeReferenceSourceData,
                alwaysQuerySource,
                neverQuerySource,
                failOnError,
                rerankerThreshold,
                resultsProcessing,
                maxOutputDocuments,
                KnowledgeSourceKind.AzureBlob,
                enableImageServing,
                additionalBinaryDataProperties: null,
                graphParameters,
                topicGraph);
        }

        /// <summary> Configuration for File knowledge source that supports direct file upload and indexing. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> Optional user-defined description. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your knowledge source definition when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your knowledge source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your knowledge source definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="fileParameters"> The parameters for the File knowledge source. </param>
        /// <param name="corsOptions"> Options to control Cross-Origin Resource Sharing (CORS) for the File knowledge source's file endpoints (upload, list, update, delete). </param>
        /// <returns> A new <see cref="Indexes.Models.FileKnowledgeSource"/> instance for mocking. </returns>
        public static FileKnowledgeSource FileKnowledgeSource(
            string name = null,
            string description = null,
            ETag? eTag = default(ETag?),
            SearchResourceEncryptionKey encryptionKey = null,
            FileKnowledgeSourceParameters fileParameters = null,
            CorsOptions corsOptions = null) =>
            FileKnowledgeSource(
                name: name,
                description: description,
                resultsProcessing: default,
                eTag: eTag,
                encryptionKey: encryptionKey,
                fileParameters: fileParameters,
                corsOptions: corsOptions);

        internal static FileKnowledgeSource FileKnowledgeSource(
            string name,
            string description,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            ETag? eTag,
            SearchResourceEncryptionKey encryptionKey,
            FileKnowledgeSourceParameters fileParameters,
            CorsOptions corsOptions)
        {
            return new FileKnowledgeSource(
                name,
                description,
                KnowledgeSourceKind.File,
                resultsProcessing,
                eTag,
                encryptionKey,
                additionalBinaryDataProperties: null,
                fileParameters,
                corsOptions);
        }

        /// <summary> Specifies runtime parameters for a File knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.FileKnowledgeSourceParams"/> instance for mocking. </returns>
        public static FileKnowledgeSourceParams FileKnowledgeSourceParams(
            string knowledgeSourceName = null,
            bool? includeReferences = default(bool?),
            bool? includeReferenceSourceData = default(bool?),
            bool? alwaysQuerySource = default(bool?),
            bool? failOnError = default(bool?),
            float? rerankerThreshold = default(float?),
            int? maxOutputDocuments = default(int?)) =>
            FileKnowledgeSourceParams(
                knowledgeSourceName: knowledgeSourceName,
                includeReferences: includeReferences,
                includeReferenceSourceData: includeReferenceSourceData,
                alwaysQuerySource: alwaysQuerySource,
                neverQuerySource: default,
                failOnError: failOnError,
                rerankerThreshold: rerankerThreshold,
                resultsProcessing: default,
                maxOutputDocuments: maxOutputDocuments,
                enableImageServing: default);

        internal static FileKnowledgeSourceParams FileKnowledgeSourceParams(
            string knowledgeSourceName,
            bool? includeReferences,
            bool? includeReferenceSourceData,
            bool? alwaysQuerySource,
            bool? neverQuerySource,
            bool? failOnError,
            float? rerankerThreshold,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            int? maxOutputDocuments,
            bool? enableImageServing)
        {
            return new FileKnowledgeSourceParams(
                knowledgeSourceName,
                includeReferences,
                includeReferenceSourceData,
                alwaysQuerySource,
                neverQuerySource,
                failOnError,
                rerankerThreshold,
                resultsProcessing,
                maxOutputDocuments,
                KnowledgeSourceKind.File,
                enableImageServing,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Specifies runtime parameters for a indexed OneLake knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams"/> instance for mocking. </returns>
        public static IndexedOneLakeKnowledgeSourceParams IndexedOneLakeKnowledgeSourceParams(
            string knowledgeSourceName = null,
            bool? includeReferences = default(bool?),
            bool? includeReferenceSourceData = default(bool?),
            bool? alwaysQuerySource = default(bool?),
            bool? failOnError = default(bool?),
            float? rerankerThreshold = default(float?),
            int? maxOutputDocuments = default(int?)) =>
            IndexedOneLakeKnowledgeSourceParams(
                knowledgeSourceName: knowledgeSourceName,
                includeReferences: includeReferences,
                includeReferenceSourceData: includeReferenceSourceData,
                alwaysQuerySource: alwaysQuerySource,
                neverQuerySource: default,
                failOnError: failOnError,
                rerankerThreshold: rerankerThreshold,
                resultsProcessing: default,
                maxOutputDocuments: maxOutputDocuments,
                enableImageServing: default);

        internal static IndexedOneLakeKnowledgeSourceParams IndexedOneLakeKnowledgeSourceParams(
            string knowledgeSourceName,
            bool? includeReferences,
            bool? includeReferenceSourceData,
            bool? alwaysQuerySource,
            bool? neverQuerySource,
            bool? failOnError,
            float? rerankerThreshold,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            int? maxOutputDocuments,
            bool? enableImageServing)
        {
            return new IndexedOneLakeKnowledgeSourceParams(
                knowledgeSourceName,
                includeReferences,
                includeReferenceSourceData,
                alwaysQuerySource,
                neverQuerySource,
                failOnError,
                rerankerThreshold,
                resultsProcessing,
                maxOutputDocuments,
                KnowledgeSourceKind.IndexedOneLake,
                enableImageServing,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Configuration for SharePoint knowledge source. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> Optional user-defined description. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your knowledge source definition when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your knowledge source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your knowledge source definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="indexedSharePointParameters"> The parameters for the knowledge source. </param>
        /// <returns> A new <see cref="Indexes.Models.IndexedSharePointKnowledgeSource"/> instance for mocking. </returns>
        public static IndexedSharePointKnowledgeSource IndexedSharePointKnowledgeSource(
            string name = null,
            string description = null,
            ETag? eTag = default(ETag?),
            SearchResourceEncryptionKey encryptionKey = null,
            IndexedSharePointKnowledgeSourceParameters indexedSharePointParameters = null) =>
            IndexedSharePointKnowledgeSource(
                name: name,
                description: description,
                resultsProcessing: default,
                eTag: eTag,
                encryptionKey: encryptionKey,
                indexedSharePointParameters: indexedSharePointParameters);

        internal static IndexedSharePointKnowledgeSource IndexedSharePointKnowledgeSource(
            string name,
            string description,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            ETag? eTag,
            SearchResourceEncryptionKey encryptionKey,
            IndexedSharePointKnowledgeSourceParameters indexedSharePointParameters)
        {
            return new IndexedSharePointKnowledgeSource(
                name,
                description,
                KnowledgeSourceKind.IndexedSharePoint,
                resultsProcessing,
                eTag,
                encryptionKey,
                additionalBinaryDataProperties: null,
                indexedSharePointParameters);
        }

        /// <summary> Specifies runtime parameters for a indexed SharePoint knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams"/> instance for mocking. </returns>
        public static IndexedSharePointKnowledgeSourceParams IndexedSharePointKnowledgeSourceParams(
            string knowledgeSourceName = null,
            bool? includeReferences = default(bool?),
            bool? includeReferenceSourceData = default(bool?),
            bool? alwaysQuerySource = default(bool?),
            bool? failOnError = default(bool?),
            float? rerankerThreshold = default(float?),
            int? maxOutputDocuments = default(int?)) =>
            IndexedSharePointKnowledgeSourceParams(
                knowledgeSourceName: knowledgeSourceName,
                includeReferences: includeReferences,
                includeReferenceSourceData: includeReferenceSourceData,
                alwaysQuerySource: alwaysQuerySource,
                neverQuerySource: default,
                failOnError: failOnError,
                rerankerThreshold: rerankerThreshold,
                resultsProcessing: default,
                maxOutputDocuments: maxOutputDocuments,
                enableImageServing: default);

        internal static IndexedSharePointKnowledgeSourceParams IndexedSharePointKnowledgeSourceParams(
            string knowledgeSourceName,
            bool? includeReferences,
            bool? includeReferenceSourceData,
            bool? alwaysQuerySource,
            bool? neverQuerySource,
            bool? failOnError,
            float? rerankerThreshold,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            int? maxOutputDocuments,
            bool? enableImageServing)
        {
            return new IndexedSharePointKnowledgeSourceParams(
                knowledgeSourceName,
                includeReferences,
                includeReferenceSourceData,
                alwaysQuerySource,
                neverQuerySource,
                failOnError,
                rerankerThreshold,
                resultsProcessing,
                maxOutputDocuments,
                KnowledgeSourceKind.IndexedSharePoint,
                enableImageServing,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Configuration for indexed SQL knowledge source. </summary>
        /// <param name="name"> The name of the knowledge source. </param>
        /// <param name="description"> Optional user-defined description. </param>
        /// <param name="eTag"> The ETag of the knowledge source. </param>
        /// <param name="encryptionKey"> A description of an encryption key that you create in Azure Key Vault. This key is used to provide an additional level of encryption-at-rest for your knowledge source definition when you want full assurance that no one, not even Microsoft, can decrypt them. Once you have encrypted your knowledge source definition, it will always remain encrypted. The search service will ignore attempts to set this property to null. You can change this property as needed if you want to rotate your encryption key; Your knowledge source definition will be unaffected. Encryption with customer-managed keys is not available for free search services, and is only available for paid services created on or after January 1, 2019. </param>
        /// <param name="indexedSqlParameters"> The parameters for the SQL knowledge source. </param>
        /// <returns> A new <see cref="Indexes.Models.IndexedSqlKnowledgeSource"/> instance for mocking. </returns>
        public static IndexedSqlKnowledgeSource IndexedSqlKnowledgeSource(
            string name = null,
            string description = null,
            ETag? eTag = default(ETag?),
            SearchResourceEncryptionKey encryptionKey = null,
            IndexedSqlKnowledgeSourceParameters indexedSqlParameters = null) =>
            IndexedSqlKnowledgeSource(
                name: name,
                description: description,
                resultsProcessing: default,
                eTag: eTag,
                encryptionKey: encryptionKey,
                indexedSqlParameters: indexedSqlParameters);

        internal static IndexedSqlKnowledgeSource IndexedSqlKnowledgeSource(
            string name,
            string description,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            ETag? eTag,
            SearchResourceEncryptionKey encryptionKey,
            IndexedSqlKnowledgeSourceParameters indexedSqlParameters)
        {
            return new IndexedSqlKnowledgeSource(
                name,
                description,
                KnowledgeSourceKind.IndexedSql,
                resultsProcessing,
                eTag,
                encryptionKey,
                additionalBinaryDataProperties: null,
                indexedSqlParameters);
        }

        /// <summary> Specifies runtime parameters for an indexed SQL knowledge source. </summary>
        /// <param name="knowledgeSourceName"> The name of the index the params apply to. </param>
        /// <param name="includeReferences"> Indicates whether references should be included for data retrieved from this source. </param>
        /// <param name="includeReferenceSourceData"> Indicates whether references should include the structured data obtained during retrieval in their payload. </param>
        /// <param name="alwaysQuerySource"> Indicates that this knowledge source should bypass source selection and always be queried at retrieval time. </param>
        /// <param name="failOnError"> Indicates that the entire retrieval request should fail if retrieval from this knowledge source encounters an error. Defaults to false. </param>
        /// <param name="rerankerThreshold"> The reranker threshold all retrieved documents must meet to be included in the response. </param>
        /// <param name="maxOutputDocuments"> Limits the maximum number of documents returned from this knowledge source. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.IndexedSqlKnowledgeSourceParams"/> instance for mocking. </returns>
        public static IndexedSqlKnowledgeSourceParams IndexedSqlKnowledgeSourceParams(
            string knowledgeSourceName = null,
            bool? includeReferences = default(bool?),
            bool? includeReferenceSourceData = default(bool?),
            bool? alwaysQuerySource = default(bool?),
            bool? failOnError = default(bool?),
            float? rerankerThreshold = default(float?),
            int? maxOutputDocuments = default(int?)) =>
            IndexedSqlKnowledgeSourceParams(
                knowledgeSourceName: knowledgeSourceName,
                includeReferences: includeReferences,
                includeReferenceSourceData: includeReferenceSourceData,
                alwaysQuerySource: alwaysQuerySource,
                neverQuerySource: default,
                failOnError: failOnError,
                rerankerThreshold: rerankerThreshold,
                resultsProcessing: default,
                maxOutputDocuments: maxOutputDocuments,
                enableImageServing: default);

        internal static IndexedSqlKnowledgeSourceParams IndexedSqlKnowledgeSourceParams(
            string knowledgeSourceName,
            bool? includeReferences,
            bool? includeReferenceSourceData,
            bool? alwaysQuerySource,
            bool? neverQuerySource,
            bool? failOnError,
            float? rerankerThreshold,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            int? maxOutputDocuments,
            bool? enableImageServing)
        {
            return new IndexedSqlKnowledgeSourceParams(
                knowledgeSourceName,
                includeReferences,
                includeReferenceSourceData,
                alwaysQuerySource,
                neverQuerySource,
                failOnError,
                rerankerThreshold,
                resultsProcessing,
                maxOutputDocuments,
                KnowledgeSourceKind.IndexedSql,
                enableImageServing,
                additionalBinaryDataProperties: null);
        }

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
        public static KnowledgeBase KnowledgeBase(
            string name = null,
            IEnumerable<KnowledgeSourceReference> knowledgeSources = null,
            IEnumerable<KnowledgeBaseModel> models = null,
            KnowledgeRetrievalReasoningEffort retrievalReasoningEffort = null,
            KnowledgeRetrievalOutputMode? outputMode = default(KnowledgeRetrievalOutputMode?),
            ETag? eTag = default(ETag?),
            SearchResourceEncryptionKey encryptionKey = null,
            string description = null,
            string retrievalInstructions = null,
            string answerInstructions = null,
            CorsOptions corsOptions = null) =>
            KnowledgeBase(
                name: name,
                knowledgeSources: knowledgeSources,
                tools: default,
                models: models,
                retrievalReasoningEffort: retrievalReasoningEffort,
                outputMode: outputMode,
                eTag: eTag,
                encryptionKey: encryptionKey,
                description: description,
                tags: default,
                retrievalInstructions: retrievalInstructions,
                answerInstructions: answerInstructions,
                corsOptions: corsOptions,
                retrieveDefaults: default);

        internal static KnowledgeBase KnowledgeBase(
            string name,
            IEnumerable<KnowledgeSourceReference> knowledgeSources,
            IEnumerable<KnowledgeBaseTool> tools,
            IEnumerable<KnowledgeBaseModel> models,
            KnowledgeRetrievalReasoningEffort retrievalReasoningEffort,
            KnowledgeRetrievalOutputMode? outputMode,
            ETag? eTag,
            SearchResourceEncryptionKey encryptionKey,
            string description,
            IDictionary<string, string> tags,
            string retrievalInstructions,
            string answerInstructions,
            CorsOptions corsOptions,
            KnowledgeBaseRetrieveDefaults retrieveDefaults)
        {
            knowledgeSources ??= new ChangeTrackingList<KnowledgeSourceReference>();
            tools ??= new ChangeTrackingList<KnowledgeBaseTool>();
            models ??= new ChangeTrackingList<KnowledgeBaseModel>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new KnowledgeBase(
                name,
                knowledgeSources.ToList(),
                tools.ToList(),
                models.ToList(),
                retrievalReasoningEffort,
                outputMode,
                eTag,
                encryptionKey,
                description,
                tags,
                retrievalInstructions,
                answerInstructions,
                corsOptions,
                retrieveDefaults,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Represents an agentic reasoning activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. </param>
        /// <param name="reasoningTokens"> The number of input tokens for agentic reasoning. </param>
        /// <param name="retrievalReasoningEffort"> The retrieval reasoning effort configuration. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KnowledgeBaseAgenticReasoningActivityRecord KnowledgeBaseAgenticReasoningActivityRecord(
            int id = 0,
            int? elapsedMs = default,
            KnowledgeBaseErrorDetail error = null,
            int? reasoningTokens = default,
            KnowledgeRetrievalReasoningEffort retrievalReasoningEffort = null) =>
            KnowledgeBaseAgenticReasoningActivityRecord(
                id: id,
                startedOn: default,
                completedOn: default,
                elapsedMs: elapsedMs,
                error: error,
                warning: default,
                reasoningTokens: reasoningTokens,
                retrievalReasoningEffort: retrievalReasoningEffort,
                logicalReasoningEffort: default);

        /// <summary> Represents an agentic reasoning activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="reasoningTokens"> The number of input tokens for agentic reasoning. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseAgenticReasoningActivityRecord KnowledgeBaseAgenticReasoningActivityRecord(
            int id,
            DateTimeOffset? startedOn,
            DateTimeOffset? completedOn,
            int? elapsedMs,
            KnowledgeBaseErrorDetail error,
            string warning,
            int? reasoningTokens) =>
            KnowledgeBaseAgenticReasoningActivityRecord(
                id: id,
                startedOn: startedOn,
                completedOn: completedOn,
                elapsedMs: elapsedMs,
                error: error,
                warning: warning,
                reasoningTokens: reasoningTokens,
                retrievalReasoningEffort: default,
                logicalReasoningEffort: default);

        /// <summary> Represents an agentic reasoning activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="reasoningTokens"> The number of input tokens for agentic reasoning. </param>
        /// <param name="retrievalReasoningEffort"> The retrieval reasoning effort configuration. </param>
        /// <param name="logicalReasoningEffort"> The logical reasoning effort requested by the customer. This is distinct from `retrievalReasoningEffort`, which reports the reasoning effort used for billing. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseAgenticReasoningActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseAgenticReasoningActivityRecord KnowledgeBaseAgenticReasoningActivityRecord(
            int id,
            DateTimeOffset? startedOn,
            DateTimeOffset? completedOn,
            int? elapsedMs,
            KnowledgeBaseErrorDetail error,
            string warning,
            int? reasoningTokens,
            KnowledgeRetrievalReasoningEffort retrievalReasoningEffort,
            KnowledgeRetrievalReasoningEffort logicalReasoningEffort)
        {
            return new KnowledgeBaseAgenticReasoningActivityRecord(
                id,
                KnowledgeBaseActivityRecordType.AgenticReasoning,
                startedOn,
                completedOn,
                elapsedMs,
                error,
                warning,
                additionalBinaryDataProperties: null,
                reasoningTokens,
                retrievalReasoningEffort,
                logicalReasoningEffort);
        }

        /// <summary> Represents a azure blob retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="azureBlobArguments"> The azure blob arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseAzureBlobActivityRecord KnowledgeBaseAzureBlobActivityRecord(
            int id = 0,
            DateTimeOffset? startedOn = default(DateTimeOffset?),
            DateTimeOffset? completedOn = default(DateTimeOffset?),
            int? elapsedMs = default(int?),
            KnowledgeBaseErrorDetail error = null,
            string warning = null,
            string knowledgeSourceName = null,
            DateTimeOffset? queryOn = default(DateTimeOffset?),
            int? count = default(int?),
            KnowledgeBaseAzureBlobActivityArguments azureBlobArguments = null) =>
            KnowledgeBaseAzureBlobActivityRecord(
                id: id,
                startedOn: startedOn,
                completedOn: completedOn,
                elapsedMs: elapsedMs,
                error: error,
                warning: warning,
                knowledgeSourceName: knowledgeSourceName,
                queryOn: queryOn,
                count: count,
                imageServing: default,
                azureBlobArguments: azureBlobArguments);

        /// <summary> Represents a azure blob retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="imageServing"> Statistics about image serving for this retrieval activity. </param>
        /// <param name="azureBlobArguments"> The azure blob arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseAzureBlobActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseAzureBlobActivityRecord KnowledgeBaseAzureBlobActivityRecord(
            int id,
            DateTimeOffset? startedOn,
            DateTimeOffset? completedOn,
            int? elapsedMs,
            KnowledgeBaseErrorDetail error,
            string warning,
            string knowledgeSourceName,
            DateTimeOffset? queryOn,
            int? count,
            ImageServingStatistics imageServing,
            KnowledgeBaseAzureBlobActivityArguments azureBlobArguments)
        {
            return new KnowledgeBaseAzureBlobActivityRecord(
                id,
                KnowledgeBaseActivityRecordType.AzureBlob,
                startedOn,
                completedOn,
                elapsedMs,
                error,
                warning,
                additionalBinaryDataProperties: null,
                knowledgeSourceName,
                queryOn,
                count,
                imageServing,
                azureBlobArguments);
        }

        /// <summary> Represents an Azure Blob Storage document reference. </summary>
        /// <param name="id"> The ID of the reference. </param>
        /// <param name="activitySource"> The source activity ID for the reference. </param>
        /// <param name="sourceData"> The source data for the reference. </param>
        /// <param name="rerankerScore"> The reranker score for the document reference. </param>
        /// <param name="blobUrl"> The blob URL for the reference. </param>
        /// <param name="citationUrl"> A Search-owned URL that points at the backing document for this reference, usable as a citation target. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseAzureBlobReference"/> instance for mocking. </returns>
        public static KnowledgeBaseAzureBlobReference KnowledgeBaseAzureBlobReference(
            string id = null,
            int activitySource = 0,
            IDictionary<string, BinaryData> sourceData = null,
            float? rerankerScore = default(float?),
            Uri blobUrl = null,
            Uri citationUrl = null) =>
            KnowledgeBaseAzureBlobReference(
                id: id,
                activitySource: activitySource,
                sourceData: sourceData,
                rerankerScore: rerankerScore,
                blobUrl: blobUrl,
                searchSensitivityLabelInfo: default,
                citationUrl: citationUrl);

        /// <summary> Represents an Azure Blob Storage document reference. </summary>
        /// <param name="id"> The ID of the reference. </param>
        /// <param name="activitySource"> The source activity ID for the reference. </param>
        /// <param name="sourceData"> The source data for the reference. </param>
        /// <param name="rerankerScore"> The reranker score for the document reference. </param>
        /// <param name="blobUrl"> The blob URL for the reference. </param>
        /// <param name="searchSensitivityLabelInfo"> The sensitivity label information for the reference. </param>
        /// <param name="citationUrl"> A Search-owned URL that points at the backing document for this reference, usable as a citation target. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseAzureBlobReference"/> instance for mocking. </returns>
        public static KnowledgeBaseAzureBlobReference KnowledgeBaseAzureBlobReference(
            string id,
            int activitySource,
            IDictionary<string, BinaryData> sourceData,
            float? rerankerScore,
            Uri blobUrl,
            PurviewSensitivityLabelInfo searchSensitivityLabelInfo,
            Uri citationUrl)
        {
            sourceData ??= new ChangeTrackingDictionary<string, BinaryData>();

            return new KnowledgeBaseAzureBlobReference(
                KnowledgeBaseReferenceType.AzureBlob,
                id,
                activitySource,
                sourceData,
                rerankerScore,
                additionalBinaryDataProperties: null,
                blobUrl,
                searchSensitivityLabelInfo,
                citationUrl);
        }

        /// <summary> Represents a File retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="fileArguments"> The File arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseFileActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseFileActivityRecord KnowledgeBaseFileActivityRecord(
            int id = 0,
            DateTimeOffset? startedOn = default(DateTimeOffset?),
            DateTimeOffset? completedOn = default(DateTimeOffset?),
            int? elapsedMs = default(int?),
            KnowledgeBaseErrorDetail error = null,
            string warning = null,
            string knowledgeSourceName = null,
            DateTimeOffset? queryOn = default(DateTimeOffset?),
            int? count = default(int?),
            KnowledgeBaseFileActivityArguments fileArguments = null) =>
            KnowledgeBaseFileActivityRecord(
                id: id,
                startedOn: startedOn,
                completedOn: completedOn,
                elapsedMs: elapsedMs,
                error: error,
                warning: warning,
                knowledgeSourceName: knowledgeSourceName,
                queryOn: queryOn,
                count: count,
                imageServing: default,
                fileArguments: fileArguments);

        /// <summary> Represents a File retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="imageServing"> Statistics about image serving for this retrieval activity. </param>
        /// <param name="fileArguments"> The File arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseFileActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseFileActivityRecord KnowledgeBaseFileActivityRecord(
            int id,
            DateTimeOffset? startedOn,
            DateTimeOffset? completedOn,
            int? elapsedMs,
            KnowledgeBaseErrorDetail error,
            string warning,
            string knowledgeSourceName,
            DateTimeOffset? queryOn,
            int? count,
            ImageServingStatistics imageServing,
            KnowledgeBaseFileActivityArguments fileArguments)
        {
            return new KnowledgeBaseFileActivityRecord(
                id,
                KnowledgeBaseActivityRecordType.File,
                startedOn,
                completedOn,
                elapsedMs,
                error,
                warning,
                additionalBinaryDataProperties: null,
                knowledgeSourceName,
                queryOn,
                count,
                imageServing,
                fileArguments);
        }

        /// <summary> Represents a indexed OneLake retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="indexedOneLakeArguments"> The indexed OneLake arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseIndexedOneLakeActivityRecord KnowledgeBaseIndexedOneLakeActivityRecord(
            int id = 0,
            DateTimeOffset? startedOn = default(DateTimeOffset?),
            DateTimeOffset? completedOn = default(DateTimeOffset?),
            int? elapsedMs = default(int?),
            KnowledgeBaseErrorDetail error = null,
            string warning = null,
            string knowledgeSourceName = null,
            DateTimeOffset? queryOn = default(DateTimeOffset?),
            int? count = default(int?),
            KnowledgeBaseIndexedOneLakeActivityArguments indexedOneLakeArguments = null) =>
            KnowledgeBaseIndexedOneLakeActivityRecord(
                id: id,
                startedOn: startedOn,
                completedOn: completedOn,
                elapsedMs: elapsedMs,
                error: error,
                warning: warning,
                knowledgeSourceName: knowledgeSourceName,
                queryOn: queryOn,
                count: count,
                imageServing: default,
                indexedOneLakeArguments: indexedOneLakeArguments);

        /// <summary> Represents a indexed OneLake retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="imageServing"> Statistics about image serving for this retrieval activity. </param>
        /// <param name="indexedOneLakeArguments"> The indexed OneLake arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseIndexedOneLakeActivityRecord KnowledgeBaseIndexedOneLakeActivityRecord(
            int id,
            DateTimeOffset? startedOn,
            DateTimeOffset? completedOn,
            int? elapsedMs,
            KnowledgeBaseErrorDetail error,
            string warning,
            string knowledgeSourceName,
            DateTimeOffset? queryOn,
            int? count,
            ImageServingStatistics imageServing,
            KnowledgeBaseIndexedOneLakeActivityArguments indexedOneLakeArguments)
        {
            return new KnowledgeBaseIndexedOneLakeActivityRecord(
                id,
                KnowledgeBaseActivityRecordType.IndexedOneLake,
                startedOn,
                completedOn,
                elapsedMs,
                error,
                warning,
                additionalBinaryDataProperties: null,
                knowledgeSourceName,
                queryOn,
                count,
                imageServing,
                indexedOneLakeArguments);
        }

        /// <summary> Represents an indexed OneLake document reference. </summary>
        /// <param name="id"> The ID of the reference. </param>
        /// <param name="activitySource"> The source activity ID for the reference. </param>
        /// <param name="sourceData"> The source data for the reference. </param>
        /// <param name="rerankerScore"> The reranker score for the document reference. </param>
        /// <param name="docUrl"> The document URL for the reference. </param>
        /// <param name="citationUrl"> A Search-owned URL that points at the backing document for this reference, usable as a citation target. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference"/> instance for mocking. </returns>
        public static KnowledgeBaseIndexedOneLakeReference KnowledgeBaseIndexedOneLakeReference(
            string id = null,
            int activitySource = 0,
            IDictionary<string, BinaryData> sourceData = null,
            float? rerankerScore = default(float?),
            Uri docUrl = null,
            Uri citationUrl = null) =>
            KnowledgeBaseIndexedOneLakeReference(
                id: id,
                activitySource: activitySource,
                sourceData: sourceData,
                rerankerScore: rerankerScore,
                docUrl: docUrl,
                searchSensitivityLabelInfo: default,
                citationUrl: citationUrl);

        /// <summary> Represents an indexed OneLake document reference. </summary>
        /// <param name="id"> The ID of the reference. </param>
        /// <param name="activitySource"> The source activity ID for the reference. </param>
        /// <param name="sourceData"> The source data for the reference. </param>
        /// <param name="rerankerScore"> The reranker score for the document reference. </param>
        /// <param name="docUrl"> The document URL for the reference. </param>
        /// <param name="searchSensitivityLabelInfo"> The sensitivity label information for the reference. </param>
        /// <param name="citationUrl"> A Search-owned URL that points at the backing document for this reference, usable as a citation target. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseIndexedOneLakeReference"/> instance for mocking. </returns>
        public static KnowledgeBaseIndexedOneLakeReference KnowledgeBaseIndexedOneLakeReference(
            string id,
            int activitySource,
            IDictionary<string, BinaryData> sourceData,
            float? rerankerScore,
            Uri docUrl,
            PurviewSensitivityLabelInfo searchSensitivityLabelInfo,
            Uri citationUrl)
        {
            sourceData ??= new ChangeTrackingDictionary<string, BinaryData>();

            return new KnowledgeBaseIndexedOneLakeReference(
                KnowledgeBaseReferenceType.IndexedOneLake,
                id,
                activitySource,
                sourceData,
                rerankerScore,
                additionalBinaryDataProperties: null,
                docUrl,
                searchSensitivityLabelInfo,
                citationUrl);
        }

        /// <summary> Represents a indexed SharePoint retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="indexedSharePointArguments"> The indexed SharePoint arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseIndexedSharePointActivityRecord KnowledgeBaseIndexedSharePointActivityRecord(
            int id = 0,
            DateTimeOffset? startedOn = default(DateTimeOffset?),
            DateTimeOffset? completedOn = default(DateTimeOffset?),
            int? elapsedMs = default(int?),
            KnowledgeBaseErrorDetail error = null,
            string warning = null,
            string knowledgeSourceName = null,
            DateTimeOffset? queryOn = default(DateTimeOffset?),
            int? count = default(int?),
            KnowledgeBaseIndexedSharePointActivityArguments indexedSharePointArguments = null) =>
            KnowledgeBaseIndexedSharePointActivityRecord(
                id: id,
                startedOn: startedOn,
                completedOn: completedOn,
                elapsedMs: elapsedMs,
                error: error,
                warning: warning,
                knowledgeSourceName: knowledgeSourceName,
                queryOn: queryOn,
                count: count,
                imageServing: default,
                indexedSharePointArguments: indexedSharePointArguments);

        /// <summary> Represents a indexed SharePoint retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="imageServing"> Statistics about image serving for this retrieval activity. </param>
        /// <param name="indexedSharePointArguments"> The indexed SharePoint arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseIndexedSharePointActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseIndexedSharePointActivityRecord KnowledgeBaseIndexedSharePointActivityRecord(
            int id,
            DateTimeOffset? startedOn,
            DateTimeOffset? completedOn,
            int? elapsedMs,
            KnowledgeBaseErrorDetail error,
            string warning,
            string knowledgeSourceName,
            DateTimeOffset? queryOn,
            int? count,
            ImageServingStatistics imageServing,
            KnowledgeBaseIndexedSharePointActivityArguments indexedSharePointArguments)
        {
            return new KnowledgeBaseIndexedSharePointActivityRecord(
                id,
                KnowledgeBaseActivityRecordType.IndexedSharePoint,
                startedOn,
                completedOn,
                elapsedMs,
                error,
                warning,
                additionalBinaryDataProperties: null,
                knowledgeSourceName,
                queryOn,
                count,
                imageServing,
                indexedSharePointArguments);
        }

        /// <summary> Represents an indexed SharePoint document reference. </summary>
        /// <param name="id"> The ID of the reference. </param>
        /// <param name="activitySource"> The source activity ID for the reference. </param>
        /// <param name="sourceData"> The source data for the reference. </param>
        /// <param name="rerankerScore"> The reranker score for the document reference. </param>
        /// <param name="docUrl"> The document URL for the reference. </param>
        /// <param name="citationUrl"> A Search-owned URL that points at the backing document for this reference, usable as a citation target. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference"/> instance for mocking. </returns>
        public static KnowledgeBaseIndexedSharePointReference KnowledgeBaseIndexedSharePointReference(
            string id = null,
            int activitySource = 0,
            IDictionary<string, BinaryData> sourceData = null,
            float? rerankerScore = default(float?),
            string docUrl = null,
            Uri citationUrl = null) =>
            KnowledgeBaseIndexedSharePointReference(
                id: id,
                activitySource: activitySource,
                sourceData: sourceData,
                rerankerScore: rerankerScore,
                docUrl: docUrl,
                searchSensitivityLabelInfo: default,
                citationUrl: citationUrl);

        /// <summary> Represents an indexed SharePoint document reference. </summary>
        /// <param name="id"> The ID of the reference. </param>
        /// <param name="activitySource"> The source activity ID for the reference. </param>
        /// <param name="sourceData"> The source data for the reference. </param>
        /// <param name="rerankerScore"> The reranker score for the document reference. </param>
        /// <param name="docUrl"> The document URL for the reference. </param>
        /// <param name="searchSensitivityLabelInfo"> The sensitivity label information for the reference. </param>
        /// <param name="citationUrl"> A Search-owned URL that points at the backing document for this reference, usable as a citation target. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseIndexedSharePointReference"/> instance for mocking. </returns>
        public static KnowledgeBaseIndexedSharePointReference KnowledgeBaseIndexedSharePointReference(
            string id,
            int activitySource,
            IDictionary<string, BinaryData> sourceData,
            float? rerankerScore,
            string docUrl,
            PurviewSensitivityLabelInfo searchSensitivityLabelInfo,
            Uri citationUrl)
        {
            sourceData ??= new ChangeTrackingDictionary<string, BinaryData>();

            return new KnowledgeBaseIndexedSharePointReference(
                KnowledgeBaseReferenceType.IndexedSharePoint,
                id,
                activitySource,
                sourceData,
                rerankerScore,
                additionalBinaryDataProperties: null,
                docUrl,
                searchSensitivityLabelInfo,
                citationUrl);
        }

        /// <summary> Represents an indexed SQL retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="indexedSqlArguments"> The indexed SQL arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseIndexedSqlActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseIndexedSqlActivityRecord KnowledgeBaseIndexedSqlActivityRecord(
            int id = 0,
            DateTimeOffset? startedOn = default(DateTimeOffset?),
            DateTimeOffset? completedOn = default(DateTimeOffset?),
            int? elapsedMs = default(int?),
            KnowledgeBaseErrorDetail error = null,
            string warning = null,
            string knowledgeSourceName = null,
            DateTimeOffset? queryOn = default(DateTimeOffset?),
            int? count = default(int?),
            KnowledgeBaseIndexedSqlActivityArguments indexedSqlArguments = null) =>
            KnowledgeBaseIndexedSqlActivityRecord(
                id: id,
                startedOn: startedOn,
                completedOn: completedOn,
                elapsedMs: elapsedMs,
                error: error,
                warning: warning,
                knowledgeSourceName: knowledgeSourceName,
                queryOn: queryOn,
                count: count,
                imageServing: default,
                indexedSqlArguments: indexedSqlArguments);

        /// <summary> Represents an indexed SQL retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="imageServing"> Statistics about image serving for this retrieval activity. </param>
        /// <param name="indexedSqlArguments"> The indexed SQL arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseIndexedSqlActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseIndexedSqlActivityRecord KnowledgeBaseIndexedSqlActivityRecord(
            int id,
            DateTimeOffset? startedOn,
            DateTimeOffset? completedOn,
            int? elapsedMs,
            KnowledgeBaseErrorDetail error,
            string warning,
            string knowledgeSourceName,
            DateTimeOffset? queryOn,
            int? count,
            ImageServingStatistics imageServing,
            KnowledgeBaseIndexedSqlActivityArguments indexedSqlArguments)
        {
            return new KnowledgeBaseIndexedSqlActivityRecord(
                id,
                KnowledgeBaseActivityRecordType.IndexedSql,
                startedOn,
                completedOn,
                elapsedMs,
                error,
                warning,
                additionalBinaryDataProperties: null,
                knowledgeSourceName,
                queryOn,
                count,
                imageServing,
                indexedSqlArguments);
        }

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
        public static KnowledgeBaseRetrievalRequest KnowledgeBaseRetrievalRequest(
            IEnumerable<KnowledgeBaseMessage> messages = null,
            IEnumerable<KnowledgeRetrievalIntent> intents = null,
            int? maxRuntimeInSeconds = default(int?),
            int? maxOutputDocuments = default(int?),
            int? maxOutputSizeInTokens = default(int?),
            KnowledgeRetrievalReasoningEffort retrievalReasoningEffort = null,
            bool? includeActivity = default(bool?),
            KnowledgeRetrievalOutputMode? outputMode = default(KnowledgeRetrievalOutputMode?),
            IEnumerable<KnowledgeSourceParams> knowledgeSourceParams = null) =>
            KnowledgeBaseRetrievalRequest(
                messages: messages,
                intents: intents,
                maxRuntimeInSeconds: maxRuntimeInSeconds,
                maxOutputSize: default,
                maxOutputDocuments: maxOutputDocuments,
                maxOutputSizeInTokens: maxOutputSizeInTokens,
                retrievalReasoningEffort: retrievalReasoningEffort,
                includeActivity: includeActivity,
                outputMode: outputMode,
                knowledgeSourceParams: knowledgeSourceParams,
                toolName: default);

        internal static KnowledgeBaseRetrievalRequest KnowledgeBaseRetrievalRequest(
            IEnumerable<KnowledgeBaseMessage> messages,
            IEnumerable<KnowledgeRetrievalIntent> intents,
            int? maxRuntimeInSeconds,
            int? maxOutputSize,
            int? maxOutputDocuments,
            int? maxOutputSizeInTokens,
            KnowledgeRetrievalReasoningEffort retrievalReasoningEffort,
            bool? includeActivity,
            KnowledgeRetrievalOutputMode? outputMode,
            IEnumerable<KnowledgeSourceParams> knowledgeSourceParams,
            string toolName)
        {
            messages ??= new ChangeTrackingList<KnowledgeBaseMessage>();
            intents ??= new ChangeTrackingList<KnowledgeRetrievalIntent>();
            knowledgeSourceParams ??= new ChangeTrackingList<KnowledgeSourceParams>();

            return new KnowledgeBaseRetrievalRequest(
                messages.ToList(),
                intents.ToList(),
                maxRuntimeInSeconds,
                maxOutputSize,
                maxOutputDocuments,
                maxOutputSizeInTokens,
                retrievalReasoningEffort,
                includeActivity,
                outputMode,
                knowledgeSourceParams.ToList(),
                toolName,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Represents the arguments the search index retrieval activity was run with. </summary>
        /// <param name="search"> The search string used to query the search index. </param>
        /// <param name="filter"> The filter string. </param>
        /// <param name="sourceDataFields"> What fields were selected for search. </param>
        /// <param name="searchFields"> What fields were searched against. </param>
        /// <param name="semanticConfigurationName"> What semantic configuration was used from the search index. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments"/> instance for mocking. </returns>
        public static KnowledgeBaseSearchIndexActivityArguments KnowledgeBaseSearchIndexActivityArguments(
            string search = null,
            string filter = null,
            IEnumerable<SearchIndexFieldReference> sourceDataFields = null,
            IEnumerable<SearchIndexFieldReference> searchFields = null,
            string semanticConfigurationName = null) =>
            KnowledgeBaseSearchIndexActivityArguments(
                search: search,
                filter: filter,
                sourceDataFields: sourceDataFields,
                searchFields: searchFields,
                semanticConfigurationName: semanticConfigurationName,
                queryType: default);

        /// <summary> Represents the arguments the search index retrieval activity was run with. </summary>
        /// <param name="search"> The search string used to query the search index. </param>
        /// <param name="filter"> The filter string. </param>
        /// <param name="sourceDataFields"> What fields were selected for search. </param>
        /// <param name="searchFields"> What fields were searched against. </param>
        /// <param name="semanticConfigurationName"> What semantic configuration was used from the search index. </param>
        /// <param name="queryType"> The query syntax used to execute the search. Query hints can cause semantic queries to use full query syntax. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityArguments"/> instance for mocking. </returns>
        public static KnowledgeBaseSearchIndexActivityArguments KnowledgeBaseSearchIndexActivityArguments(
            string search,
            string filter,
            IEnumerable<SearchIndexFieldReference> sourceDataFields,
            IEnumerable<SearchIndexFieldReference> searchFields,
            string semanticConfigurationName,
            SearchQueryType? queryType)
        {
            sourceDataFields ??= new ChangeTrackingList<SearchIndexFieldReference>();
            searchFields ??= new ChangeTrackingList<SearchIndexFieldReference>();

            return new KnowledgeBaseSearchIndexActivityArguments(
                search,
                filter,
                sourceDataFields.ToList(),
                searchFields.ToList(),
                semanticConfigurationName,
                queryType,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Represents a search index retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="searchIndexArguments"> The search index arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseSearchIndexActivityRecord KnowledgeBaseSearchIndexActivityRecord(
            int id = 0,
            DateTimeOffset? startedOn = default(DateTimeOffset?),
            DateTimeOffset? completedOn = default(DateTimeOffset?),
            int? elapsedMs = default(int?),
            KnowledgeBaseErrorDetail error = null,
            string warning = null,
            string knowledgeSourceName = null,
            DateTimeOffset? queryOn = default(DateTimeOffset?),
            int? count = default(int?),
            KnowledgeBaseSearchIndexActivityArguments searchIndexArguments = null) =>
            KnowledgeBaseSearchIndexActivityRecord(
                id: id,
                startedOn: startedOn,
                completedOn: completedOn,
                elapsedMs: elapsedMs,
                error: error,
                warning: warning,
                knowledgeSourceName: knowledgeSourceName,
                queryOn: queryOn,
                count: count,
                imageServing: default,
                searchIndexArguments: searchIndexArguments,
                queryHintProcessing: default);

        /// <summary> Represents a search index retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="imageServing"> Statistics about image serving for this retrieval activity. </param>
        /// <param name="searchIndexArguments"> The search index arguments for the retrieval activity. </param>
        /// <param name="queryHintProcessing"> Details about the expressions generated from query hints for this activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseSearchIndexActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseSearchIndexActivityRecord KnowledgeBaseSearchIndexActivityRecord(
            int id,
            DateTimeOffset? startedOn,
            DateTimeOffset? completedOn,
            int? elapsedMs,
            KnowledgeBaseErrorDetail error,
            string warning,
            string knowledgeSourceName,
            DateTimeOffset? queryOn,
            int? count,
            ImageServingStatistics imageServing,
            KnowledgeBaseSearchIndexActivityArguments searchIndexArguments,
            KnowledgeBaseQueryHintProcessing queryHintProcessing)
        {
            return new KnowledgeBaseSearchIndexActivityRecord(
                id,
                KnowledgeBaseActivityRecordType.SearchIndex,
                startedOn,
                completedOn,
                elapsedMs,
                error,
                warning,
                additionalBinaryDataProperties: null,
                knowledgeSourceName,
                queryOn,
                count,
                imageServing,
                searchIndexArguments,
                queryHintProcessing);
        }

        /// <summary> Represents an Azure Search document reference. </summary>
        /// <param name="id"> The ID of the reference. </param>
        /// <param name="activitySource"> The source activity ID for the reference. </param>
        /// <param name="sourceData"> The source data for the reference. </param>
        /// <param name="rerankerScore"> The reranker score for the document reference. </param>
        /// <param name="docKey"> The document key for the reference. </param>
        /// <param name="citationUrl"> A Search-owned URL that points at the backing document for this reference, usable as a citation target. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseSearchIndexReference"/> instance for mocking. </returns>
        public static KnowledgeBaseSearchIndexReference KnowledgeBaseSearchIndexReference(
            string id = null,
            int activitySource = 0,
            IDictionary<string, BinaryData> sourceData = null,
            float? rerankerScore = default(float?),
            string docKey = null,
            Uri citationUrl = null) =>
            KnowledgeBaseSearchIndexReference(
                id: id,
                activitySource: activitySource,
                sourceData: sourceData,
                rerankerScore: rerankerScore,
                docKey: docKey,
                searchSensitivityLabelInfo: default,
                citationUrl: citationUrl);

        /// <summary> Represents an Azure Search document reference. </summary>
        /// <param name="id"> The ID of the reference. </param>
        /// <param name="activitySource"> The source activity ID for the reference. </param>
        /// <param name="sourceData"> The source data for the reference. </param>
        /// <param name="rerankerScore"> The reranker score for the document reference. </param>
        /// <param name="docKey"> The document key for the reference. </param>
        /// <param name="searchSensitivityLabelInfo"> The sensitivity label information for the reference. </param>
        /// <param name="citationUrl"> A Search-owned URL that points at the backing document for this reference, usable as a citation target. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseSearchIndexReference"/> instance for mocking. </returns>
        public static KnowledgeBaseSearchIndexReference KnowledgeBaseSearchIndexReference(
            string id,
            int activitySource,
            IDictionary<string, BinaryData> sourceData,
            float? rerankerScore,
            string docKey,
            PurviewSensitivityLabelInfo searchSensitivityLabelInfo,
            Uri citationUrl)
        {
            sourceData ??= new ChangeTrackingDictionary<string, BinaryData>();

            return new KnowledgeBaseSearchIndexReference(
                KnowledgeBaseReferenceType.SearchIndex,
                id,
                activitySource,
                sourceData,
                rerankerScore,
                additionalBinaryDataProperties: null,
                docKey,
                searchSensitivityLabelInfo,
                citationUrl);
        }

        /// <summary> Represents a web retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="webArguments"> The web arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseWebActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseWebActivityRecord KnowledgeBaseWebActivityRecord(
            int id = 0,
            DateTimeOffset? startedOn = default(DateTimeOffset?),
            DateTimeOffset? completedOn = default(DateTimeOffset?),
            int? elapsedMs = default(int?),
            KnowledgeBaseErrorDetail error = null,
            string warning = null,
            string knowledgeSourceName = null,
            DateTimeOffset? queryOn = default(DateTimeOffset?),
            int? count = default(int?),
            KnowledgeBaseWebActivityArguments webArguments = null) =>
            KnowledgeBaseWebActivityRecord(
                id: id,
                startedOn: startedOn,
                completedOn: completedOn,
                elapsedMs: elapsedMs,
                error: error,
                warning: warning,
                knowledgeSourceName: knowledgeSourceName,
                queryOn: queryOn,
                count: count,
                imageServing: default,
                webArguments: webArguments);

        /// <summary> Represents a web retrieval activity record. </summary>
        /// <param name="id"> The ID of the activity record. </param>
        /// <param name="startedOn"> The time at which the activity started. </param>
        /// <param name="completedOn"> The time at which the activity completed. </param>
        /// <param name="elapsedMs"> The elapsed time in milliseconds for the retrieval activity. </param>
        /// <param name="error"> The error detail explaining why the operation failed. This property is only included when the activity does not succeed. </param>
        /// <param name="warning"> A warning message surfacing potential configuration issues observed during the activity, such as documents dropped due to score thresholding, token limit truncation, or timeout conditions. </param>
        /// <param name="knowledgeSourceName"> The knowledge source for the retrieval activity. </param>
        /// <param name="queryOn"> The query time for this retrieval activity. </param>
        /// <param name="count"> The count of documents retrieved that were sufficiently relevant to pass the reranker threshold. </param>
        /// <param name="imageServing"> Statistics about image serving for this retrieval activity. </param>
        /// <param name="webArguments"> The web arguments for the retrieval activity. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeBaseWebActivityRecord"/> instance for mocking. </returns>
        public static KnowledgeBaseWebActivityRecord KnowledgeBaseWebActivityRecord(
            int id,
            DateTimeOffset? startedOn,
            DateTimeOffset? completedOn,
            int? elapsedMs,
            KnowledgeBaseErrorDetail error,
            string warning,
            string knowledgeSourceName,
            DateTimeOffset? queryOn,
            int? count,
            ImageServingStatistics imageServing,
            KnowledgeBaseWebActivityArguments webArguments)
        {
            return new KnowledgeBaseWebActivityRecord(
                id,
                KnowledgeBaseActivityRecordType.Web,
                startedOn,
                completedOn,
                elapsedMs,
                error,
                warning,
                additionalBinaryDataProperties: null,
                knowledgeSourceName,
                queryOn,
                count,
                imageServing,
                webArguments);
        }

        /// <summary> Consolidates all general ingestion settings for knowledge sources. </summary>
        /// <param name="identity"> An explicit identity to use for this knowledge source. </param>
        /// <param name="embeddingModel"> Optional vectorizer configuration for vectorizing content. </param>
        /// <param name="chatCompletionModel"> Optional chat completion model for image verbalization or context extraction. </param>
        /// <param name="disableImageVerbalization"> Indicates whether image verbalization should be disabled. Default is false. </param>
        /// <param name="ingestionSchedule"> Optional schedule for data ingestion. </param>
        /// <param name="ingestionPermissionOptions"> Optional list of permission types to ingest together with document content. If specified, it will set the indexer permission options for the data source. </param>
        /// <param name="contentExtractionMode"> Optional content extraction mode. Default is 'minimal'. </param>
        /// <param name="aiServices"> Optional AI Services configuration for content processing. </param>
        /// <param name="networkAccessMode"> Optional network access mode for ingestion. Set to 'private' to run ingestion in a private execution environment that can reach data sources and dependencies over a private network. Default is 'public'. This is a create-time setting and cannot be changed after the knowledge source is created. </param>
        /// <returns> A new <see cref="KnowledgeBases.Models.KnowledgeSourceIngestionParameters"/> instance for mocking. </returns>
        public static KnowledgeSourceIngestionParameters KnowledgeSourceIngestionParameters(
            SearchIndexerDataIdentity identity = null,
            KnowledgeSourceVectorizer embeddingModel = null,
            KnowledgeBaseModel chatCompletionModel = null,
            bool? disableImageVerbalization = default(bool?),
            IndexingSchedule ingestionSchedule = null,
            IEnumerable<KnowledgeSourceIngestionPermissionOption> ingestionPermissionOptions = null,
            KnowledgeSourceContentExtractionMode? contentExtractionMode = default(KnowledgeSourceContentExtractionMode?),
            AIServices aiServices = null,
            KnowledgeSourceNetworkAccessMode? networkAccessMode = default(KnowledgeSourceNetworkAccessMode?)) =>
            KnowledgeSourceIngestionParameters(
                identity: identity,
                embeddingModel: embeddingModel,
                chatCompletionModel: chatCompletionModel,
                disableImageVerbalization: disableImageVerbalization,
                ingestionSchedule: ingestionSchedule,
                ingestionPermissionOptions: ingestionPermissionOptions,
                contentExtractionMode: contentExtractionMode,
                aiServices: aiServices,
                assetStore: default,
                freshnessPolicy: default,
                networkAccessMode: networkAccessMode,
                cache: default);

        internal static KnowledgeSourceIngestionParameters KnowledgeSourceIngestionParameters(
            SearchIndexerDataIdentity identity,
            KnowledgeSourceVectorizer embeddingModel,
            KnowledgeBaseModel chatCompletionModel,
            bool? disableImageVerbalization,
            IndexingSchedule ingestionSchedule,
            IEnumerable<KnowledgeSourceIngestionPermissionOption> ingestionPermissionOptions,
            KnowledgeSourceContentExtractionMode? contentExtractionMode,
            AIServices aiServices,
            AssetStore assetStore,
            FreshnessPolicy freshnessPolicy,
            KnowledgeSourceNetworkAccessMode? networkAccessMode,
            KnowledgeSourceCache cache)
        {
            ingestionPermissionOptions ??= new ChangeTrackingList<KnowledgeSourceIngestionPermissionOption>();

            return new KnowledgeSourceIngestionParameters(
                identity,
                embeddingModel,
                chatCompletionModel,
                disableImageVerbalization,
                ingestionSchedule,
                ingestionPermissionOptions.ToList(),
                contentExtractionMode,
                aiServices,
                assetStore,
                freshnessPolicy,
                networkAccessMode,
                cache,
                additionalBinaryDataProperties: null);
        }

        /// <summary>
        /// Base type for knowledge source runtime parameters.
        /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="KnowledgeBases.Models.AzureBlobKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.FabricDataAgentKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.FabricOntologyKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.FileKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.IndexedOneLakeKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.IndexedSharePointKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.IndexedSqlKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.McpServerKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.RemoteSharePointKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.SearchIndexKnowledgeSourceParams"/>, <see cref="KnowledgeBases.Models.WebKnowledgeSourceParams"/>, and <see cref="KnowledgeBases.Models.WorkIQKnowledgeSourceParams"/>.
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
        public static KnowledgeSourceParams KnowledgeSourceParams(
            string knowledgeSourceName = null,
            bool? includeReferences = default(bool?),
            bool? includeReferenceSourceData = default(bool?),
            bool? alwaysQuerySource = default(bool?),
            bool? failOnError = default(bool?),
            float? rerankerThreshold = default(float?),
            int? maxOutputDocuments = default(int?),
            string kind = null) =>
            KnowledgeSourceParams(
                knowledgeSourceName: knowledgeSourceName,
                includeReferences: includeReferences,
                includeReferenceSourceData: includeReferenceSourceData,
                alwaysQuerySource: alwaysQuerySource,
                neverQuerySource: default,
                failOnError: failOnError,
                rerankerThreshold: rerankerThreshold,
                resultsProcessing: default,
                maxOutputDocuments: maxOutputDocuments,
                kind: kind,
                enableImageServing: default);

        internal static KnowledgeSourceParams KnowledgeSourceParams(
            string knowledgeSourceName,
            bool? includeReferences,
            bool? includeReferenceSourceData,
            bool? alwaysQuerySource,
            bool? neverQuerySource,
            bool? failOnError,
            float? rerankerThreshold,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            int? maxOutputDocuments,
            string kind,
            bool? enableImageServing)
        {
            return new UnknownKnowledgeSourceParams(
                knowledgeSourceName,
                includeReferences,
                includeReferenceSourceData,
                alwaysQuerySource,
                neverQuerySource,
                failOnError,
                rerankerThreshold,
                resultsProcessing,
                maxOutputDocuments,
                new KnowledgeSourceKind(kind),
                enableImageServing,
                additionalBinaryDataProperties: null);
        }

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
        public static SearchField SearchField(
            string name = null,
            SearchFieldDataType type = default(SearchFieldDataType),
            bool? isKey = default(bool?),
            bool? isRetrievable = default(bool?),
            bool? isStored = default(bool?),
            bool? isSearchable = default(bool?),
            bool? isFilterable = default(bool?),
            bool? isSortable = default(bool?),
            bool? isFacetable = default(bool?),
            PermissionFilter? permissionFilter = default(PermissionFilter?),
            bool? organizationAccessExpiration = default(bool?),
            bool? sharepointSiteUrl = default(bool?),
            LexicalAnalyzerName? analyzerName = default(LexicalAnalyzerName?),
            LexicalAnalyzerName? searchAnalyzerName = default(LexicalAnalyzerName?),
            LexicalAnalyzerName? indexAnalyzerName = default(LexicalAnalyzerName?),
            LexicalNormalizerName? normalizerName = default(LexicalNormalizerName?),
            int? vectorSearchDimensions = default(int?),
            string vectorSearchProfileName = null,
            VectorEncodingFormat? vectorEncodingFormat = default(VectorEncodingFormat?),
            IEnumerable<string> synonymMapNames = null,
            IEnumerable<SearchField> fields = null) =>
            SearchField(
                name: name,
                @type: @type,
                isKey: isKey,
                isRetrievable: isRetrievable,
                isStored: isStored,
                isSearchable: isSearchable,
                isFilterable: isFilterable,
                isSortable: isSortable,
                isFacetable: isFacetable,
                permissionFilter: permissionFilter,
                organizationAccessExpiration: organizationAccessExpiration,
                sensitivityLabelId: default,
                sensitivityLabelName: default,
                sourceDocumentId: default,
                sharepointSiteUrl: sharepointSiteUrl,
                analyzerName: analyzerName,
                searchAnalyzerName: searchAnalyzerName,
                indexAnalyzerName: indexAnalyzerName,
                normalizerName: normalizerName,
                vectorSearchDimensions: vectorSearchDimensions,
                vectorSearchProfileName: vectorSearchProfileName,
                topicGraphProfile: default,
                vectorEncodingFormat: vectorEncodingFormat,
                synonymMapNames: synonymMapNames,
                fields: fields);

        internal static SearchField SearchField(
            string name,
            SearchFieldDataType @type,
            bool? isKey,
            bool? isRetrievable,
            bool? isStored,
            bool? isSearchable,
            bool? isFilterable,
            bool? isSortable,
            bool? isFacetable,
            PermissionFilter? permissionFilter,
            bool? organizationAccessExpiration,
            bool? sensitivityLabelId,
            bool? sensitivityLabelName,
            bool? sourceDocumentId,
            bool? sharepointSiteUrl,
            LexicalAnalyzerName? analyzerName,
            LexicalAnalyzerName? searchAnalyzerName,
            LexicalAnalyzerName? indexAnalyzerName,
            LexicalNormalizerName? normalizerName,
            int? vectorSearchDimensions,
            string vectorSearchProfileName,
            string topicGraphProfile,
            VectorEncodingFormat? vectorEncodingFormat,
            IEnumerable<string> synonymMapNames,
            IEnumerable<SearchField> fields)
        {
            synonymMapNames ??= new ChangeTrackingList<string>();
            fields ??= new ChangeTrackingList<SearchField>();

            return new SearchField(
                name,
                @type,
                isKey,
                isRetrievable,
                isStored,
                isSearchable,
                isFilterable,
                isSortable,
                isFacetable,
                permissionFilter,
                organizationAccessExpiration,
                sensitivityLabelId,
                sensitivityLabelName,
                sourceDocumentId,
                sharepointSiteUrl,
                analyzerName,
                searchAnalyzerName,
                indexAnalyzerName,
                normalizerName,
                vectorSearchDimensions,
                vectorSearchProfileName,
                topicGraphProfile,
                vectorEncodingFormat,
                synonymMapNames.ToList(),
                fields.ToList(),
                additionalBinaryDataProperties: null);
        }

        /// <summary> Represents a search index definition, which describes the fields and search behavior of an index. </summary>
        /// <param name="name"> The name of the index. </param>
        /// <param name="description"> The description of the index. </param>
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
        /// <param name="fields"> The fields of the index. </param>
        /// <param name="etag"> The ETag of the index. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndex"/> instance for mocking. </returns>
        public static SearchIndex SearchIndex(
            string name,
            string description,
            IEnumerable<ScoringProfile> scoringProfiles,
            string defaultScoringProfile,
            CorsOptions corsOptions,
            IEnumerable<SearchSuggester> suggesters,
            IEnumerable<LexicalAnalyzer> analyzers,
            IEnumerable<LexicalTokenizer> tokenizers,
            IEnumerable<TokenFilter> tokenFilters,
            IEnumerable<CharFilter> charFilters,
            IEnumerable<LexicalNormalizer> normalizers,
            SearchResourceEncryptionKey encryptionKey,
            SimilarityAlgorithm similarity,
            SemanticSearch semanticSearch,
            VectorSearch vectorSearch,
            SearchIndexPermissionFilterOption? permissionFilterOption,
            SharePointConnectorAppRegistration sharePointConnectorAppRegistration,
            IEnumerable<SearchField> fields,
            string etag) =>
            SearchIndex(
                name: name,
                description: description,
                graphProfile: default,
                scoringProfiles: scoringProfiles,
                defaultScoringProfile: defaultScoringProfile,
                corsOptions: corsOptions,
                suggesters: suggesters,
                analyzers: analyzers,
                tokenizers: tokenizers,
                tokenFilters: tokenFilters,
                charFilters: charFilters,
                normalizers: normalizers,
                encryptionKey: encryptionKey,
                similarity: similarity,
                semanticSearch: semanticSearch,
                vectorSearch: vectorSearch,
                permissionFilterOption: permissionFilterOption,
                purviewEnabled: default,
                sharePointConnectorAppRegistration: sharePointConnectorAppRegistration,
                oneLakeSecuritySource: default,
                fields: fields,
                etag: etag);

        internal static SearchIndex SearchIndex(
            string name,
            string description,
            GraphProfile graphProfile,
            IEnumerable<ScoringProfile> scoringProfiles,
            string defaultScoringProfile,
            CorsOptions corsOptions,
            IEnumerable<SearchSuggester> suggesters,
            IEnumerable<LexicalAnalyzer> analyzers,
            IEnumerable<LexicalTokenizer> tokenizers,
            IEnumerable<TokenFilter> tokenFilters,
            IEnumerable<CharFilter> charFilters,
            IEnumerable<LexicalNormalizer> normalizers,
            SearchResourceEncryptionKey encryptionKey,
            SimilarityAlgorithm similarity,
            SemanticSearch semanticSearch,
            VectorSearch vectorSearch,
            SearchIndexPermissionFilterOption? permissionFilterOption,
            bool? purviewEnabled,
            SharePointConnectorAppRegistration sharePointConnectorAppRegistration,
            OneLakeSecuritySource oneLakeSecuritySource,
            IEnumerable<SearchField> fields,
            string etag)
        {
            scoringProfiles ??= new ChangeTrackingList<ScoringProfile>();
            suggesters ??= new ChangeTrackingList<SearchSuggester>();
            analyzers ??= new ChangeTrackingList<LexicalAnalyzer>();
            tokenizers ??= new ChangeTrackingList<LexicalTokenizer>();
            tokenFilters ??= new ChangeTrackingList<TokenFilter>();
            charFilters ??= new ChangeTrackingList<CharFilter>();
            normalizers ??= new ChangeTrackingList<LexicalNormalizer>();
            fields ??= new ChangeTrackingList<SearchField>();

            return new SearchIndex(
                name,
                description,
                graphProfile,
                scoringProfiles.ToList(),
                defaultScoringProfile,
                corsOptions,
                suggesters.ToList(),
                analyzers.ToList(),
                tokenizers.ToList(),
                tokenFilters.ToList(),
                charFilters.ToList(),
                normalizers.ToList(),
                encryptionKey,
                similarity,
                semanticSearch,
                vectorSearch,
                permissionFilterOption,
                purviewEnabled,
                sharePointConnectorAppRegistration,
                oneLakeSecuritySource,
                fields.ToList(),
                etag,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Represents the current status and execution history of an indexer. </summary>
        /// <param name="name"> The name of the indexer. </param>
        /// <param name="status"> Overall indexer status. </param>
        /// <param name="runtime"> Snapshot of the indexer's cumulative runtime consumption for the service over the current UTC period. </param>
        /// <param name="lastResult"> The result of the most recent or an in-progress indexer execution. </param>
        /// <param name="executionHistory"> History of the recent indexer executions, sorted in reverse chronological order. </param>
        /// <param name="limits"> The execution limits for the indexer. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndexerStatus"/> instance for mocking. </returns>
        public static SearchIndexerStatus SearchIndexerStatus(
            string name,
            IndexerStatus status,
            IndexerRuntime runtime,
            IndexerExecutionResult lastResult,
            IEnumerable<IndexerExecutionResult> executionHistory,
            SearchIndexerLimits limits) =>
            SearchIndexerStatus(
                name: name,
                status: status,
                runtime: runtime,
                lastResult: lastResult,
                executionHistory: executionHistory,
                limits: limits,
                currentState: default);

        /// <summary> Represents the current status and execution history of an indexer. </summary>
        /// <param name="name"> The name of the indexer. </param>
        /// <param name="status"> Overall indexer status. </param>
        /// <param name="runtime"> Snapshot of the indexer's cumulative runtime consumption for the service over the current UTC period. </param>
        /// <param name="lastResult"> The result of the most recent or an in-progress indexer execution. </param>
        /// <param name="executionHistory"> History of the recent indexer executions, sorted in reverse chronological order. </param>
        /// <param name="limits"> The execution limits for the indexer. </param>
        /// <param name="currentState"> All of the state that defines and dictates the indexer's current execution. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndexerStatus"/> instance for mocking. </returns>
        public static SearchIndexerStatus SearchIndexerStatus(
            string name,
            IndexerStatus status,
            IndexerRuntime runtime,
            IndexerExecutionResult lastResult,
            IEnumerable<IndexerExecutionResult> executionHistory,
            SearchIndexerLimits limits,
            IndexerState currentState)
        {
            executionHistory ??= new ChangeTrackingList<IndexerExecutionResult>();

            return new SearchIndexerStatus(
                name,
                status,
                runtime,
                lastResult,
                executionHistory.ToList(),
                limits,
                currentState,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Parameters for search index knowledge source. </summary>
        /// <param name="searchIndexName"> The name of the Search index. </param>
        /// <param name="sourceDataFields"> Used to request additional fields for referenced source data. </param>
        /// <param name="searchFields"> Used to restrict which fields to search on the search index. </param>
        /// <param name="semanticConfigurationName"> Used to specify a different semantic configuration on the target search index other than the default one. </param>
        /// <param name="baseFilter"> A default filter condition applied to the index at retrieval time (e.g., 'State eq VA'). Can be overridden at query time via knowledge source runtime parameters. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndexKnowledgeSourceParameters"/> instance for mocking. </returns>
        public static SearchIndexKnowledgeSourceParameters SearchIndexKnowledgeSourceParameters(
            string searchIndexName = null,
            IEnumerable<SearchIndexFieldReference> sourceDataFields = null,
            IEnumerable<SearchIndexFieldReference> searchFields = null,
            string semanticConfigurationName = null,
            string baseFilter = null) =>
            SearchIndexKnowledgeSourceParameters(
                searchIndexName: searchIndexName,
                sourceDataFields: sourceDataFields,
                searchFields: searchFields,
                semanticConfigurationName: semanticConfigurationName,
                baseFilter: baseFilter,
                queryHints: default,
                topicGraph: default);

        internal static SearchIndexKnowledgeSourceParameters SearchIndexKnowledgeSourceParameters(
            string searchIndexName,
            IEnumerable<SearchIndexFieldReference> sourceDataFields,
            IEnumerable<SearchIndexFieldReference> searchFields,
            string semanticConfigurationName,
            string baseFilter,
            SearchIndexKnowledgeSourceQueryHints queryHints,
            VectorQueryTopicGraph topicGraph)
        {
            sourceDataFields ??= new ChangeTrackingList<SearchIndexFieldReference>();
            searchFields ??= new ChangeTrackingList<SearchIndexFieldReference>();

            return new SearchIndexKnowledgeSourceParameters(
                searchIndexName,
                sourceDataFields.ToList(),
                searchFields.ToList(),
                semanticConfigurationName,
                baseFilter,
                queryHints,
                topicGraph,
                additionalBinaryDataProperties: null);
        }

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
        public static SearchIndexKnowledgeSourceParams SearchIndexKnowledgeSourceParams(
            string knowledgeSourceName = null,
            bool? includeReferences = default(bool?),
            bool? includeReferenceSourceData = default(bool?),
            bool? alwaysQuerySource = default(bool?),
            bool? failOnError = default(bool?),
            float? rerankerThreshold = default(float?),
            int? maxOutputDocuments = default(int?),
            string filterAddOn = null) =>
            SearchIndexKnowledgeSourceParams(
                knowledgeSourceName: knowledgeSourceName,
                includeReferences: includeReferences,
                includeReferenceSourceData: includeReferenceSourceData,
                alwaysQuerySource: alwaysQuerySource,
                neverQuerySource: default,
                failOnError: failOnError,
                rerankerThreshold: rerankerThreshold,
                resultsProcessing: default,
                maxOutputDocuments: maxOutputDocuments,
                enableImageServing: default,
                filterAddOn: filterAddOn,
                queryHintOverrides: default,
                topicGraph: default);

        internal static SearchIndexKnowledgeSourceParams SearchIndexKnowledgeSourceParams(
            string knowledgeSourceName,
            bool? includeReferences,
            bool? includeReferenceSourceData,
            bool? alwaysQuerySource,
            bool? neverQuerySource,
            bool? failOnError,
            float? rerankerThreshold,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            int? maxOutputDocuments,
            bool? enableImageServing,
            string filterAddOn,
            SearchIndexKnowledgeSourceQueryHints queryHintOverrides,
            VectorQueryTopicGraph topicGraph)
        {
            return new SearchIndexKnowledgeSourceParams(
                knowledgeSourceName,
                includeReferences,
                includeReferenceSourceData,
                alwaysQuerySource,
                neverQuerySource,
                failOnError,
                rerankerThreshold,
                resultsProcessing,
                maxOutputDocuments,
                KnowledgeSourceKind.SearchIndex,
                enableImageServing,
                additionalBinaryDataProperties: null,
                filterAddOn,
                queryHintOverrides,
                topicGraph);
        }

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
        public static SearchIndexResponse SearchIndexResponse(
            string name = null,
            string description = null,
            IEnumerable<SearchField> fields = null,
            IEnumerable<ScoringProfile> scoringProfiles = null,
            string defaultScoringProfile = null,
            CorsOptions corsOptions = null,
            IEnumerable<SearchSuggester> suggesters = null,
            IEnumerable<LexicalAnalyzer> analyzers = null,
            IEnumerable<LexicalTokenizer> tokenizers = null,
            IEnumerable<TokenFilter> tokenFilters = null,
            IEnumerable<CharFilter> charFilters = null,
            IEnumerable<LexicalNormalizer> normalizers = null,
            SearchResourceEncryptionKey encryptionKey = null,
            SimilarityAlgorithm similarity = null,
            SemanticSearch semanticSearch = null,
            VectorSearch vectorSearch = null,
            SearchIndexPermissionFilterOption? permissionFilterOption = default(SearchIndexPermissionFilterOption?),
            SharePointConnectorAppRegistration sharePointConnectorAppRegistration = null,
            ETag? eTag = default(ETag?)) =>
            SearchIndexResponse(
                name: name,
                description: description,
                fields: fields,
                graphProfile: default,
                scoringProfiles: scoringProfiles,
                defaultScoringProfile: defaultScoringProfile,
                corsOptions: corsOptions,
                suggesters: suggesters,
                analyzers: analyzers,
                tokenizers: tokenizers,
                tokenFilters: tokenFilters,
                charFilters: charFilters,
                normalizers: normalizers,
                encryptionKey: encryptionKey,
                similarity: similarity,
                semanticSearch: semanticSearch,
                vectorSearch: vectorSearch,
                permissionFilterOption: permissionFilterOption,
                purviewEnabled: default,
                sharePointConnectorAppRegistration: sharePointConnectorAppRegistration,
                oneLakeSecuritySource: default,
                eTag: eTag);

        /// <summary> Represents a search index definition, which describes the fields and search behavior of an index. </summary>
        /// <param name="name"> The name of the index. </param>
        /// <param name="description"> The description of the index. </param>
        /// <param name="fields"> The fields of the index. </param>
        /// <param name="graphProfile"> The persisted edge-list graph mapping, when the index supports graph queries. </param>
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
        /// <param name="purviewEnabled"> A value indicating whether Purview is enabled for the index. </param>
        /// <param name="sharePointConnectorAppRegistration"> Configures a SharePoint connector app registration for the index, enabling document-level permissions from SharePoint. If provided, the applicationId and federatedCredentialId properties are required. </param>
        /// <param name="oneLakeSecuritySource"> Identifies the Microsoft Fabric OneLake lakehouse that the index's documents originate from. Required when any field uses the 'oneLakeParentFolders' or 'oneLakeLakehouseId' permission filter. </param>
        /// <param name="eTag"> The ETag of the index. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchIndexResponse"/> instance for mocking. </returns>
        public static SearchIndexResponse SearchIndexResponse(
            string name,
            string description,
            IEnumerable<SearchField> fields,
            GraphProfile graphProfile,
            IEnumerable<ScoringProfile> scoringProfiles,
            string defaultScoringProfile,
            CorsOptions corsOptions,
            IEnumerable<SearchSuggester> suggesters,
            IEnumerable<LexicalAnalyzer> analyzers,
            IEnumerable<LexicalTokenizer> tokenizers,
            IEnumerable<TokenFilter> tokenFilters,
            IEnumerable<CharFilter> charFilters,
            IEnumerable<LexicalNormalizer> normalizers,
            SearchResourceEncryptionKey encryptionKey,
            SimilarityAlgorithm similarity,
            SemanticSearch semanticSearch,
            VectorSearch vectorSearch,
            SearchIndexPermissionFilterOption? permissionFilterOption,
            bool? purviewEnabled,
            SharePointConnectorAppRegistration sharePointConnectorAppRegistration,
            OneLakeSecuritySource oneLakeSecuritySource,
            ETag? eTag)
        {
            fields ??= new ChangeTrackingList<SearchField>();
            scoringProfiles ??= new ChangeTrackingList<ScoringProfile>();
            suggesters ??= new ChangeTrackingList<SearchSuggester>();
            analyzers ??= new ChangeTrackingList<LexicalAnalyzer>();
            tokenizers ??= new ChangeTrackingList<LexicalTokenizer>();
            tokenFilters ??= new ChangeTrackingList<TokenFilter>();
            charFilters ??= new ChangeTrackingList<CharFilter>();
            normalizers ??= new ChangeTrackingList<LexicalNormalizer>();

            return new SearchIndexResponse(
                name,
                description,
                fields.ToList(),
                graphProfile,
                scoringProfiles.ToList(),
                defaultScoringProfile,
                corsOptions,
                suggesters.ToList(),
                analyzers.ToList(),
                tokenizers.ToList(),
                tokenFilters.ToList(),
                charFilters.ToList(),
                normalizers.ToList(),
                encryptionKey,
                similarity,
                semanticSearch,
                vectorSearch,
                permissionFilterOption,
                purviewEnabled,
                sharePointConnectorAppRegistration,
                oneLakeSecuritySource,
                eTag,
                additionalBinaryDataProperties: null);
        }

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
        public static SearchOptions SearchOptions(
            bool? includeTotalCount = default(bool?),
            IEnumerable<string> facets = null,
            string filter = null,
            string highlightFieldsRaw = null,
            string highlightPostTag = null,
            string highlightPreTag = null,
            double? minimumCoverage = default(double?),
            string moreLikeThis = null,
            string orderByRaw = null,
            SearchQueryType? queryType = default(SearchQueryType?),
            ScoringStatistics? scoringStatistics = default(ScoringStatistics?),
            string sessionId = null,
            IEnumerable<string> scoringParameters = null,
            string scoringProfile = null,
            QueryDebugMode? debug = default(QueryDebugMode?),
            string searchText = null,
            string searchFieldsRaw = null,
            SearchMode? searchMode = default(SearchMode?),
            string selectRaw = null,
            int? skip = default(int?),
            int? size = default(int?),
            string semanticConfigurationName = null,
            SemanticErrorMode? semanticErrorMode = default(SemanticErrorMode?),
            int? semanticMaxWaitInMilliseconds = default(int?),
            string semanticQuery = null,
            string queryAnswerRaw = null,
            string queryCaptionRaw = null,
            IEnumerable<VectorQuery> vectorQueries = null,
            VectorFilterMode? filterMode = default(VectorFilterMode?)) =>
            SearchOptions(
                includeTotalCount: includeTotalCount,
                facets: facets,
                filter: filter,
                highlightFieldsRaw: highlightFieldsRaw,
                highlightPostTag: highlightPostTag,
                highlightPreTag: highlightPreTag,
                minimumCoverage: minimumCoverage,
                moreLikeThis: moreLikeThis,
                orderByRaw: orderByRaw,
                queryType: queryType,
                agenticOptions: default,
                scoringStatistics: scoringStatistics,
                sessionId: sessionId,
                scoringParameters: scoringParameters,
                scoringProfile: scoringProfile,
                debug: debug,
                searchText: searchText,
                searchFieldsRaw: searchFieldsRaw,
                searchMode: searchMode,
                queryLanguage: default,
                querySpeller: default,
                selectRaw: selectRaw,
                skip: skip,
                size: size,
                semanticConfigurationName: semanticConfigurationName,
                semanticErrorMode: semanticErrorMode,
                semanticMaxWaitInMilliseconds: semanticMaxWaitInMilliseconds,
                semanticQuery: semanticQuery,
                queryAnswerRaw: queryAnswerRaw,
                queryCaptionRaw: queryCaptionRaw,
                queryRewritesRaw: default,
                semanticFields: default,
                vectorQueries: vectorQueries,
                filterMode: filterMode,
                hybridSearch: default);

        internal static SearchOptions SearchOptions(
            bool? includeTotalCount,
            IEnumerable<string> facets,
            string filter,
            string highlightFieldsRaw,
            string highlightPostTag,
            string highlightPreTag,
            double? minimumCoverage,
            string moreLikeThis,
            string orderByRaw,
            SearchQueryType? queryType,
            AgenticSearchOptions agenticOptions,
            ScoringStatistics? scoringStatistics,
            string sessionId,
            IEnumerable<string> scoringParameters,
            string scoringProfile,
            QueryDebugMode? debug,
            string searchText,
            string searchFieldsRaw,
            SearchMode? searchMode,
            QueryLanguage? queryLanguage,
            QuerySpellerType? querySpeller,
            string selectRaw,
            int? skip,
            int? size,
            string semanticConfigurationName,
            SemanticErrorMode? semanticErrorMode,
            int? semanticMaxWaitInMilliseconds,
            string semanticQuery,
            string queryAnswerRaw,
            string queryCaptionRaw,
            string queryRewritesRaw,
            IEnumerable<string> semanticFields,
            IEnumerable<VectorQuery> vectorQueries,
            VectorFilterMode? filterMode,
            HybridSearch hybridSearch)
        {
            facets ??= new ChangeTrackingList<string>();
            scoringParameters ??= new ChangeTrackingList<string>();
            semanticFields ??= new ChangeTrackingList<string>();
            vectorQueries ??= new ChangeTrackingList<VectorQuery>();

            return new SearchOptions(
                includeTotalCount,
                facets.ToList(),
                filter,
                highlightFieldsRaw,
                highlightPostTag,
                highlightPreTag,
                minimumCoverage,
                moreLikeThis,
                orderByRaw,
                queryType,
                agenticOptions,
                scoringStatistics,
                sessionId,
                scoringParameters.ToList(),
                scoringProfile,
                debug,
                searchText,
                searchFieldsRaw,
                searchMode,
                queryLanguage,
                querySpeller,
                selectRaw,
                skip,
                size,
                semanticConfigurationName,
                semanticErrorMode,
                semanticMaxWaitInMilliseconds,
                semanticQuery,
                queryAnswerRaw,
                queryCaptionRaw,
                queryRewritesRaw,
                semanticFields.ToList(),
                vectorQueries.ToList(),
                filterMode,
                hybridSearch,
                additionalBinaryDataProperties: null);
        }

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
        public static WebKnowledgeSourceParams WebKnowledgeSourceParams(
            string knowledgeSourceName = null,
            bool? includeReferences = default(bool?),
            bool? includeReferenceSourceData = default(bool?),
            bool? alwaysQuerySource = default(bool?),
            bool? failOnError = default(bool?),
            float? rerankerThreshold = default(float?),
            int? maxOutputDocuments = default(int?),
            string language = null,
            string market = null,
            int? count = default(int?),
            string freshness = null) =>
            WebKnowledgeSourceParams(
                knowledgeSourceName: knowledgeSourceName,
                includeReferences: includeReferences,
                includeReferenceSourceData: includeReferenceSourceData,
                alwaysQuerySource: alwaysQuerySource,
                neverQuerySource: default,
                failOnError: failOnError,
                rerankerThreshold: rerankerThreshold,
                resultsProcessing: default,
                maxOutputDocuments: maxOutputDocuments,
                enableImageServing: default,
                language: language,
                market: market,
                count: count,
                freshness: freshness);

        internal static WebKnowledgeSourceParams WebKnowledgeSourceParams(
            string knowledgeSourceName,
            bool? includeReferences,
            bool? includeReferenceSourceData,
            bool? alwaysQuerySource,
            bool? neverQuerySource,
            bool? failOnError,
            float? rerankerThreshold,
            KnowledgeSourceResultsProcessing? resultsProcessing,
            int? maxOutputDocuments,
            bool? enableImageServing,
            string language,
            string market,
            int? count,
            string freshness)
        {
            return new WebKnowledgeSourceParams(
                knowledgeSourceName,
                includeReferences,
                includeReferenceSourceData,
                alwaysQuerySource,
                neverQuerySource,
                failOnError,
                rerankerThreshold,
                resultsProcessing,
                maxOutputDocuments,
                KnowledgeSourceKind.Web,
                enableImageServing,
                additionalBinaryDataProperties: null,
                language,
                market,
                count,
                freshness);
        }

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
        public static SearchIndexer SearchIndexer(
            string name = null,
            string description = null,
            string dataSourceName = null,
            string skillsetName = null,
            string targetIndexName = null,
            IndexingSchedule schedule = null,
            IndexingParameters parameters = null,
            IEnumerable<FieldMapping> fieldMappings = null,
            IEnumerable<FieldMapping> outputFieldMappings = null,
            bool? isDisabled = default(bool?),
            ETag? eTag = default(ETag?),
            SearchResourceEncryptionKey encryptionKey = null) =>
            SearchIndexer(
                name: name,
                description: description,
                dataSourceName: dataSourceName,
                skillsetName: skillsetName,
                targetIndexName: targetIndexName,
                schedule: schedule,
                parameters: parameters,
                fieldMappings: fieldMappings,
                outputFieldMappings: outputFieldMappings,
                isDisabled: isDisabled,
                eTag: eTag,
                encryptionKey: encryptionKey,
                cache: default);

        internal static SearchIndexer SearchIndexer(
            string name,
            string description,
            string dataSourceName,
            string skillsetName,
            string targetIndexName,
            IndexingSchedule schedule,
            IndexingParameters parameters,
            IEnumerable<FieldMapping> fieldMappings,
            IEnumerable<FieldMapping> outputFieldMappings,
            bool? isDisabled,
            ETag? eTag,
            SearchResourceEncryptionKey encryptionKey,
            SearchIndexerCache cache)
        {
            fieldMappings ??= new ChangeTrackingList<FieldMapping>();
            outputFieldMappings ??= new ChangeTrackingList<FieldMapping>();

            return new SearchIndexer(
                name,
                description,
                dataSourceName,
                skillsetName,
                targetIndexName,
                schedule,
                parameters,
                fieldMappings.ToList(),
                outputFieldMappings.ToList(),
                isDisabled,
                eTag,
                encryptionKey,
                cache,
                additionalBinaryDataProperties: null);
        }

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
        public static SearchServiceCounters SearchServiceCounters(
            SearchResourceCounter aliasCounter = null,
            SearchResourceCounter documentCounter = null,
            SearchResourceCounter indexCounter = null,
            SearchResourceCounter indexerCounter = null,
            SearchResourceCounter dataSourceCounter = null,
            SearchResourceCounter storageSizeCounter = null,
            SearchResourceCounter synonymMapCounter = null,
            SearchResourceCounter skillsetCounter = null,
            SearchResourceCounter vectorIndexSizeCounter = null) =>
            SearchServiceCounters(
                aliasCounter: aliasCounter,
                documentCounter: documentCounter,
                indexCounter: indexCounter,
                indexerCounter: indexerCounter,
                dataSourceCounter: dataSourceCounter,
                storageSizeCounter: storageSizeCounter,
                synonymMapCounter: synonymMapCounter,
                skillsetCounter: skillsetCounter,
                vectorIndexSizeCounter: vectorIndexSizeCounter,
                knowledgeBaseCounter: default,
                knowledgeSourceCounter: default);

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
        /// <param name="knowledgeBaseCounter"> Total number of knowledge bases. </param>
        /// <param name="knowledgeSourceCounter"> Total number of knowledge sources. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchServiceCounters"/> instance for mocking. </returns>
        public static SearchServiceCounters SearchServiceCounters(
            SearchResourceCounter aliasCounter,
            SearchResourceCounter documentCounter,
            SearchResourceCounter indexCounter,
            SearchResourceCounter indexerCounter,
            SearchResourceCounter dataSourceCounter,
            SearchResourceCounter storageSizeCounter,
            SearchResourceCounter synonymMapCounter,
            SearchResourceCounter skillsetCounter,
            SearchResourceCounter vectorIndexSizeCounter,
            SearchResourceCounter knowledgeBaseCounter,
            SearchResourceCounter knowledgeSourceCounter)
        {
            return new SearchServiceCounters(
                aliasCounter,
                documentCounter,
                indexCounter,
                indexerCounter,
                dataSourceCounter,
                storageSizeCounter,
                synonymMapCounter,
                skillsetCounter,
                vectorIndexSizeCounter,
                knowledgeBaseCounter,
                knowledgeSourceCounter,
                additionalBinaryDataProperties: null);
        }

        /// <summary> Represents various service level limits. </summary>
        /// <param name="maxFieldsPerIndex"> The maximum allowed fields per index. </param>
        /// <param name="maxFieldNestingDepthPerIndex"> The maximum depth which you can nest sub-fields in an index, including the top-level complex field. For example, a/b/c has a nesting depth of 3. </param>
        /// <param name="maxComplexCollectionFieldsPerIndex"> The maximum number of fields of type Collection(Edm.ComplexType) allowed in an index. </param>
        /// <param name="maxComplexObjectsInCollectionsPerDocument"> The maximum number of objects in complex collections allowed per document. </param>
        /// <param name="maxStoragePerIndexInBytes"> The maximum amount of storage in bytes allowed per index. </param>
        /// <param name="maxCumulativeIndexerRuntimeSeconds"> The maximum cumulative indexer runtime in seconds allowed for the service. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchServiceLimits"/> instance for mocking. </returns>
        public static SearchServiceLimits SearchServiceLimits(
            int? maxFieldsPerIndex = default(int?),
            int? maxFieldNestingDepthPerIndex = default(int?),
            int? maxComplexCollectionFieldsPerIndex = default(int?),
            int? maxComplexObjectsInCollectionsPerDocument = default(int?),
            long? maxStoragePerIndexInBytes = default(long?),
            long? maxCumulativeIndexerRuntimeSeconds = default(long?)) =>
            SearchServiceLimits(
                maxFieldsPerIndex: maxFieldsPerIndex,
                maxFieldNestingDepthPerIndex: maxFieldNestingDepthPerIndex,
                maxComplexCollectionFieldsPerIndex: maxComplexCollectionFieldsPerIndex,
                maxComplexObjectsInCollectionsPerDocument: maxComplexObjectsInCollectionsPerDocument,
                maxStoragePerIndexInBytes: maxStoragePerIndexInBytes,
                maxCumulativeIndexerRuntimeSeconds: maxCumulativeIndexerRuntimeSeconds,
                maxVectorIndexSizePerIndexInBytes: default);

        /// <summary> Represents various service level limits. </summary>
        /// <param name="maxFieldsPerIndex"> The maximum allowed fields per index. </param>
        /// <param name="maxFieldNestingDepthPerIndex"> The maximum depth which you can nest sub-fields in an index, including the top-level complex field. For example, a/b/c has a nesting depth of 3. </param>
        /// <param name="maxComplexCollectionFieldsPerIndex"> The maximum number of fields of type Collection(Edm.ComplexType) allowed in an index. </param>
        /// <param name="maxComplexObjectsInCollectionsPerDocument"> The maximum number of objects in complex collections allowed per document. </param>
        /// <param name="maxStoragePerIndexInBytes"> The maximum amount of storage in bytes allowed per index. </param>
        /// <param name="maxCumulativeIndexerRuntimeSeconds"> The maximum cumulative indexer runtime in seconds allowed for the service. </param>
        /// <param name="maxVectorIndexSizePerIndexInBytes"> The maximum vector index size (vector memory quota) allowed per index in bytes. </param>
        /// <returns> A new <see cref="Indexes.Models.SearchServiceLimits"/> instance for mocking. </returns>
        public static SearchServiceLimits SearchServiceLimits(
            int? maxFieldsPerIndex,
            int? maxFieldNestingDepthPerIndex,
            int? maxComplexCollectionFieldsPerIndex,
            int? maxComplexObjectsInCollectionsPerDocument,
            long? maxStoragePerIndexInBytes,
            long? maxCumulativeIndexerRuntimeSeconds,
            long? maxVectorIndexSizePerIndexInBytes)
        {
            return new SearchServiceLimits(
                maxFieldsPerIndex,
                maxFieldNestingDepthPerIndex,
                maxComplexCollectionFieldsPerIndex,
                maxComplexObjectsInCollectionsPerDocument,
                maxStoragePerIndexInBytes,
                maxCumulativeIndexerRuntimeSeconds,
                maxVectorIndexSizePerIndexInBytes,
                additionalBinaryDataProperties: null);
        }
    }
}
