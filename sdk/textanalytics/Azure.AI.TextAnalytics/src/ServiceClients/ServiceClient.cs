// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using Azure.Core.Pipeline;
using static Azure.AI.TextAnalytics.TextAnalyticsClientOptions;

namespace Azure.AI.TextAnalytics.ServiceClients
{
    /// <summary>
    ///   Defines the contract to be implemented by clients to a specific
    ///   REST API service implementation for Text Analytics.  This abstraction
    ///   allows for the <see cref="TextAnalyticsClient" /> to work with both
    ///   the legacy Text Analytics REST API and the Language REST API.
    /// </summary>
    ///
    internal abstract class ServiceClient
    {
        public ServiceClient(TextAnalyticsClientOptions options)
        {
            Options = options;
        }

        public abstract ClientDiagnostics Diagnostics { get; }

        protected TextAnalyticsClientOptions Options { get; }

        protected ServiceVersion ServiceVersion => Options.Version;

        #region Detect Language

        public abstract Task<Response<DetectedLanguage>> DetectLanguageAsync(string document, string countryHint = default, CancellationToken cancellationToken = default);
        public abstract Response<DetectedLanguage> DetectLanguage(string document, string countryHint = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(IEnumerable<string> documents, string countryHint = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<DetectLanguageResultCollection> DetectLanguageBatch(IEnumerable<string> documents, string countryHint = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(IEnumerable<DetectLanguageInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<DetectLanguageResultCollection> DetectLanguageBatch(IEnumerable<DetectLanguageInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);

        #endregion

        #region Recognize Entities

        public abstract Task<Response<CategorizedEntityCollection>> RecognizeEntitiesAsync(string document, string language = default, CancellationToken cancellationToken = default);
        public abstract Response<CategorizedEntityCollection> RecognizeEntities(string document, string language = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);

        #endregion

        #region Recognize PII Entities

        public abstract Task<Response<PiiEntityCollection>> RecognizePiiEntitiesAsync(string document, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<PiiEntityCollection> RecognizePiiEntities(string document, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(IEnumerable<string> documents, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(IEnumerable<string> documents, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(IEnumerable<TextDocumentInput> documents, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default);

        #endregion

        #region Recognize Custom Entities

        public virtual RecognizeCustomEntitiesOperation RecognizeCustomEntities(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.RecognizeCustomEntities)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual RecognizeCustomEntitiesOperation RecognizeCustomEntities(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.RecognizeCustomEntities)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<RecognizeCustomEntitiesOperation> RecognizeCustomEntitiesAsync(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.RecognizeCustomEntitiesAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<RecognizeCustomEntitiesOperation> RecognizeCustomEntitiesAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.RecognizeCustomEntitiesAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual RecognizeCustomEntitiesOperation StartRecognizeCustomEntities(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartRecognizeCustomEntities)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual RecognizeCustomEntitiesOperation StartRecognizeCustomEntities(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartRecognizeCustomEntities)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<RecognizeCustomEntitiesOperation> StartRecognizeCustomEntitiesAsync(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartRecognizeCustomEntitiesAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<RecognizeCustomEntitiesOperation> StartRecognizeCustomEntitiesAsync(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartRecognizeCustomEntitiesAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        #endregion

        #region Analyze Sentiment

        public abstract Task<Response<DocumentSentiment>> AnalyzeSentimentAsync(string document, string language = default, AnalyzeSentimentOptions options = null, CancellationToken cancellationToken = default);
        public abstract Response<DocumentSentiment> AnalyzeSentiment(string document, string language = default, AnalyzeSentimentOptions options = null, CancellationToken cancellationToken = default);
        public abstract Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<string> documents, string language = default, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<string> documents, string language = default, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<TextDocumentInput> documents, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<TextDocumentInput> documents, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default);

        #endregion

        #region Extract Key Phrases

        public abstract Task<Response<KeyPhraseCollection>> ExtractKeyPhrasesAsync(string document, string language = default, CancellationToken cancellationToken = default);
        public abstract Response<KeyPhraseCollection> ExtractKeyPhrases(string document, string language = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);

        #endregion

        #region Linked Entities

        public abstract Task<Response<LinkedEntityCollection>> RecognizeLinkedEntitiesAsync(string document, string language = default, CancellationToken cancellationToken = default);
        public abstract Response<LinkedEntityCollection> RecognizeLinkedEntities(string document, string language = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);
        public abstract Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default);

        #endregion

        #region Healthcare

        public abstract AnalyzeHealthcareEntitiesOperation AnalyzeHealthcareEntities(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract AnalyzeHealthcareEntitiesOperation AnalyzeHealthcareEntities(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options, CancellationToken cancellationToken = default);
        public abstract Task<AnalyzeHealthcareEntitiesOperation> AnalyzeHealthcareEntitiesAsync(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<AnalyzeHealthcareEntitiesOperation> AnalyzeHealthcareEntitiesAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options, CancellationToken cancellationToken = default);
        public abstract Task<AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task CancelHealthcareJobAsync(string jobId, CancellationToken cancellationToken = default);
        public abstract void CancelHealthcareJob(string jobId, CancellationToken cancellationToken = default);
        public abstract Task<Response<HealthcareJobStatusResult>> HealthStatusAsync(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);
        public abstract Response<HealthcareJobStatusResult> HealthStatus(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);
        public abstract Task<Response<HealthcareJobStatusResult>> HealthStatusNextPageAsync(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);
        public abstract Response<HealthcareJobStatusResult> HealthStatusNextPage(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);

        #endregion

        #region Analyze Operation
        public abstract AnalyzeActionsOperation AnalyzeActions(WaitUntil waitUntil, IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default);
        public abstract AnalyzeActionsOperation AnalyzeActions(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<AnalyzeActionsOperation> AnalyzeActionsAsync(WaitUntil waitUntil, IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<AnalyzeActionsOperation> AnalyzeActionsAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<AnalyzeActionsOperation> StartAnalyzeActionsAsync(IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default);
        public abstract AnalyzeActionsOperation StartAnalyzeActions(IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default);
        public abstract AnalyzeActionsOperation StartAnalyzeActions(IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<AnalyzeActionsOperation> StartAnalyzeActionsAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default);
        public abstract Task<Response<AnalyzeTextJobStatusResult>> AnalyzeStatusAsync(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);
        public abstract Response<AnalyzeTextJobStatusResult> AnalyzeStatus(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);
        public abstract Task<Response<AnalyzeTextJobStatusResult>> AnalyzeStatusNextPageAsync(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);
        public abstract Response<AnalyzeTextJobStatusResult> AnalyzeStatusNextPage(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);
        public abstract Task CancelAnalyzeActionsJobAsync(string jobId, CancellationToken cancellationToken = default);
        public abstract void CancelAnalyzeActionsJob(string jobId, CancellationToken cancellationToken = default);

        #endregion

        #region Single Label Classify

        public virtual ClassifyDocumentOperation SingleLabelClassify(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.SingleLabelClassify)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual ClassifyDocumentOperation SingleLabelClassify(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.SingleLabelClassify)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<ClassifyDocumentOperation> SingleLabelClassifyAsync(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.SingleLabelClassifyAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<ClassifyDocumentOperation> SingleLabelClassifyAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.SingleLabelClassifyAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual ClassifyDocumentOperation StartSingleLabelClassify(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartSingleLabelClassify)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual ClassifyDocumentOperation StartSingleLabelClassify(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartSingleLabelClassify)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<ClassifyDocumentOperation> StartSingleLabelClassifyAsync(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartSingleLabelClassifyAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<ClassifyDocumentOperation> StartSingleLabelClassifyAsync(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartSingleLabelClassifyAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        #endregion

        #region Multi Label Classify

        public virtual ClassifyDocumentOperation MultiLabelClassify(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.MultiLabelClassify)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual ClassifyDocumentOperation MultiLabelClassify(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.MultiLabelClassify)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<ClassifyDocumentOperation> MultiLabelClassifyAsync(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.MultiLabelClassifyAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<ClassifyDocumentOperation> MultiLabelClassifyAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.MultiLabelClassifyAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual ClassifyDocumentOperation StartMultiLabelClassify(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartMultiLabelClassify)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual ClassifyDocumentOperation StartMultiLabelClassify(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartMultiLabelClassify)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<ClassifyDocumentOperation> StartMultiLabelClassifyAsync(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartMultiLabelClassifyAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        public virtual Task<ClassifyDocumentOperation> StartMultiLabelClassifyAsync(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartMultiLabelClassifyAsync)}", ServiceVersion.V2022_05_01, ServiceVersion);

        #endregion

        #region Extractive Summarize

        public virtual ExtractiveSummarizeOperation ExtractiveSummarize(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, ExtractiveSummarizeOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.ExtractiveSummarize)}", ServiceVersion.V2023_04_01, ServiceVersion);

        public virtual ExtractiveSummarizeOperation ExtractiveSummarize(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, ExtractiveSummarizeOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.ExtractiveSummarize)}", ServiceVersion.V2023_04_01, ServiceVersion);

        public virtual Task<ExtractiveSummarizeOperation> ExtractiveSummarizeAsync(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, ExtractiveSummarizeOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.ExtractiveSummarizeAsync)}", ServiceVersion.V2023_04_01, ServiceVersion);

        public virtual Task<ExtractiveSummarizeOperation> ExtractiveSummarizeAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, ExtractiveSummarizeOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.ExtractiveSummarizeAsync)}", ServiceVersion.V2023_04_01, ServiceVersion);

        #endregion

        #region Abstractive Summarize

        public virtual AbstractiveSummarizeOperation AbstractiveSummarize(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, AbstractiveSummarizeOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.AbstractiveSummarize)}", ServiceVersion.V2023_04_01, ServiceVersion);

        public virtual AbstractiveSummarizeOperation AbstractiveSummarize(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, AbstractiveSummarizeOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.AbstractiveSummarize)}", ServiceVersion.V2023_04_01, ServiceVersion);

        public virtual Task<AbstractiveSummarizeOperation> AbstractiveSummarizeAsync(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, AbstractiveSummarizeOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.AbstractiveSummarizeAsync)}", ServiceVersion.V2023_04_01, ServiceVersion);

        public virtual Task<AbstractiveSummarizeOperation> AbstractiveSummarizeAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, AbstractiveSummarizeOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.AbstractiveSummarizeAsync)}", ServiceVersion.V2023_04_01, ServiceVersion);

        #endregion

        #region Long Running Operations

        public abstract Task<Response<AnalyzeTextJobState>> AnalyzeTextJobStatusAsync(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);
        public abstract Response<AnalyzeTextJobState> AnalyzeTextJobStatus(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);
        public abstract Task<Response<AnalyzeTextJobState>> AnalyzeTextJobStatusNextPageAsync(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);
        public abstract Response<AnalyzeTextJobState> AnalyzeTextJobStatusNextPage(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default);

        #endregion
    }
}
