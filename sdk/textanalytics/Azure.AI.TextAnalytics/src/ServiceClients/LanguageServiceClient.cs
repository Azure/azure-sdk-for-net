﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.TextAnalytics.ServiceClients
{
    /// <summary>
    ///   Allows the <see cref="TextAnalyticsClient" /> to operate against the
    ///   Cognitive Language REST API service using an abstraction common among the
    ///   different services.
    /// </summary>
    ///
    internal class LanguageServiceClient : ServiceClient
    {
        private static readonly TextAnalyticsRequestOptions s_defaultRequestOptions = new TextAnalyticsRequestOptions();
        private static readonly RecognizePiiEntitiesOptions s_piiEntitiesOptions = new RecognizePiiEntitiesOptions();

        private readonly MicrosoftCognitiveLanguageServiceRestClient _languageRestClient;
        private readonly TextAnalyticsClientOptions _options;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _baseUri;

        public override ClientDiagnostics Diagnostics => _clientDiagnostics;

        public LanguageServiceClient(Uri endpoint, TokenCredential credential, string authorizationScope, string serviceVersion, TextAnalyticsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Argument.AssertNotNullOrEmpty(authorizationScope, nameof(authorizationScope));
            Argument.AssertNotNullOrEmpty(serviceVersion, nameof(serviceVersion));

            _baseUri = endpoint;
            _clientDiagnostics = new TextAnalyticsClientDiagnostics(options);
            _options = options;

            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, authorizationScope));
            _languageRestClient = new MicrosoftCognitiveLanguageServiceRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri, serviceVersion);
        }

        public LanguageServiceClient(Uri endpoint, AzureKeyCredential credential, string serviceVersion, TextAnalyticsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Argument.AssertNotNullOrEmpty(serviceVersion, nameof(serviceVersion));

            _baseUri = endpoint;
            _clientDiagnostics = new TextAnalyticsClientDiagnostics(options);
            _options = options;

            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            _languageRestClient = new MicrosoftCognitiveLanguageServiceRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri, serviceVersion);
        }

        #region Detect Language

        public override async Task<Response<DetectedLanguage>> DetectLanguageAsync(string document, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguage)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<LanguageInput>() { ConvertToLanguageInput(document, countryHint) };
                var input = new LanguageDetectionAnalysisInput();
                foreach (var doc in documents)
                {
                    input.Documents.Add(doc);
                }
                var analyzeLanguageDetection = new AnalyzeTextLanguageDetectionInput { AnalysisInput = input };
                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(analyzeLanguageDetection, cancellationToken: cancellationToken).ConfigureAwait(false);

                var languageDetection = (LanguageDetectionTaskResult)result.Value;
                Response response = result.GetRawResponse();
                if (languageDetection.Results.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(languageDetection.Results.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToDetectedLanguage(languageDetection.Results.Documents.FirstOrDefault()), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<DetectedLanguage> DetectLanguage(string document, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguage)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<LanguageInput>() { ConvertToLanguageInput(document, countryHint) };
                var input = new LanguageDetectionAnalysisInput();
                foreach (var doc in documents)
                {
                    input.Documents.Add(doc);
                }
                var analyzeLanguageDetection = new AnalyzeTextLanguageDetectionInput { AnalysisInput = input };
                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(analyzeLanguageDetection, cancellationToken: cancellationToken);

                var languageDetection = (LanguageDetectionTaskResult)result.Value;
                Response response = result.GetRawResponse();
                if (languageDetection.Results.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.

                    var error = Transforms.ConvertToError(languageDetection.Results.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToDetectedLanguage(languageDetection.Results.Documents.FirstOrDefault()), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(IEnumerable<string> documents, string countryHint = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_defaultRequestOptions;
            LanguageDetectionAnalysisInput detectLanguageInputs = DocumentsToLanguageDetection(documents, countryHint);

            return await DetectLanguageBatchAsync(detectLanguageInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<DetectLanguageResultCollection> DetectLanguageBatch(IEnumerable<string> documents, string countryHint = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_defaultRequestOptions;
            LanguageDetectionAnalysisInput detectLanguageInputs = DocumentsToLanguageDetection(documents, countryHint);
            return DetectLanguageBatch(detectLanguageInputs, options, cancellationToken);
        }

        public override async Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(IEnumerable<DetectLanguageInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_defaultRequestOptions;
            LanguageDetectionAnalysisInput detectLanguageInputs = LanguageInputToLanguageDetection(documents);

            return await DetectLanguageBatchAsync(detectLanguageInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<DetectLanguageResultCollection> DetectLanguageBatch(IEnumerable<DetectLanguageInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_defaultRequestOptions;
            LanguageDetectionAnalysisInput detectLanguageInputs = LanguageInputToLanguageDetection(documents);

            return DetectLanguageBatch(detectLanguageInputs, options, cancellationToken);
        }

        private async Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(LanguageDetectionAnalysisInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguageBatch)}");
            scope.Start();

            try
            {
                var analyzeLanguageDetection = new AnalyzeTextLanguageDetectionInput
                {
                    AnalysisInput = batchInput,
                    Parameters = new LanguageDetectionTaskParameters(options.DisableServiceLogs, options.ModelVersion)
                };

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(analyzeLanguageDetection, options.IncludeStatistics, cancellationToken: cancellationToken).ConfigureAwait(false);
                var languageDetection = result.Value as LanguageDetectionTaskResult;
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                DetectLanguageResultCollection results = Transforms.ConvertToDetectLanguageResultCollection(languageDetection.Results, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<DetectLanguageResultCollection> DetectLanguageBatch(LanguageDetectionAnalysisInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguageBatch)}");
            scope.Start();

            try
            {
                var analyzeLanguageDetection = new AnalyzeTextLanguageDetectionInput
                {
                    AnalysisInput = batchInput,
                    Parameters = new LanguageDetectionTaskParameters(options.DisableServiceLogs, options.ModelVersion)
                };

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(analyzeLanguageDetection, options.IncludeStatistics, cancellationToken: cancellationToken);
                var languageDetection = result.Value as LanguageDetectionTaskResult;
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                DetectLanguageResultCollection results = Transforms.ConvertToDetectLanguageResultCollection(languageDetection.Results, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private LanguageDetectionAnalysisInput DocumentsToLanguageDetection(IEnumerable<string> documents, string countryHint = default)
        {
            LanguageDetectionAnalysisInput detectLanguageInputs = new LanguageDetectionAnalysisInput();
            int id = 0;
            foreach (var document in documents)
            {
                LanguageInput languageInput = ConvertToLanguageInput(document, countryHint, id);
                id++;
                detectLanguageInputs.Documents.Add(languageInput);
            }
            return detectLanguageInputs;
        }

        private static LanguageDetectionAnalysisInput LanguageInputToLanguageDetection(IEnumerable<DetectLanguageInput> documents)
        {
            LanguageDetectionAnalysisInput detectLanguageInputs = new LanguageDetectionAnalysisInput();
            foreach (var document in documents)
            {
                LanguageInput languageInput = new LanguageInput(document.Id, document.Text);
                languageInput.CountryHint = document.CountryHint;
                detectLanguageInputs.Documents.Add(languageInput);
            }
            return detectLanguageInputs;
        }

        #endregion

        #region Recognize Entities

        public override async Task<Response<CategorizedEntityCollection>> RecognizeEntitiesAsync(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                var input = new MultiLanguageAnalysisInput();
                foreach (var doc in documents)
                {
                    input.Documents.Add(doc);
                }
                var analyzeRecognizeEntities = new AnalyzeTextEntityRecognitionInput { AnalysisInput = input };
                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(
                    analyzeRecognizeEntities,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var entityRecognition = (EntitiesTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (entityRecognition.Results.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(entityRecognition.Results.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }
                return Response.FromValue(Transforms.ConvertToCategorizedEntityCollection(entityRecognition.Results.Documents.FirstOrDefault()), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<CategorizedEntityCollection> RecognizeEntities(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                var input = new MultiLanguageAnalysisInput();
                foreach (var doc in documents)
                {
                    input.Documents.Add(doc);
                }
                var analyzeRecognizeEntities = new AnalyzeTextEntityRecognitionInput { AnalysisInput = input };
                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(
                    analyzeRecognizeEntities,
                    cancellationToken: cancellationToken);

                var entityRecognition = (EntitiesTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (entityRecognition.Results.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(entityRecognition.Results.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
                }
                return Response.FromValue(Transforms.ConvertToCategorizedEntityCollection(entityRecognition.Results.Documents.FirstOrDefault()), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_defaultRequestOptions;
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizeEntitiesBatchAsync(input, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_defaultRequestOptions;
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return RecognizeEntitiesBatch(input, options, cancellationToken);
        }

        public override async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_defaultRequestOptions;
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return await RecognizeEntitiesBatchAsync(input, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_defaultRequestOptions;
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return RecognizeEntitiesBatch(input, options, cancellationToken);
        }

        private async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(MultiLanguageAnalysisInput multiLanguageInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntitiesBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextEntityRecognitionInput input = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = new EntitiesTaskParameters(
                                        options.DisableServiceLogs,
                                        options.ModelVersion,
                                        Constants.DefaultStringIndexType)
                };

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(
                    input,
                    options.IncludeStatistics,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var entityRecognition = (EntitiesTaskResult)result.Value;
                Response response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(multiLanguageInput.Documents);
                RecognizeEntitiesResultCollection results = Transforms.ConvertToRecognizeEntitiesResultCollection(entityRecognition.Results, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(MultiLanguageAnalysisInput multiLanguageInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntitiesBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextEntityRecognitionInput input = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = new EntitiesTaskParameters(
                                        options.DisableServiceLogs,
                                        options.ModelVersion,
                                        Constants.DefaultStringIndexType)
                };

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(
                    input,
                    options.IncludeStatistics,
                    cancellationToken: cancellationToken);

                var entityRecognition = (EntitiesTaskResult)result.Value;
                Response response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(multiLanguageInput.Documents);
                RecognizeEntitiesResultCollection results = Transforms.ConvertToRecognizeEntitiesResultCollection(entityRecognition.Results, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Recognize PII Entities

        public override async Task<Response<PiiEntityCollection>> RecognizePiiEntitiesAsync(string document, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= s_piiEntitiesOptions;

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                var input = new MultiLanguageAnalysisInput();
                foreach (var doc in documents)
                {
                    input.Documents.Add(doc);
                }
                var analyzePiiEntities = new AnalyzeTextPiiEntitiesRecognitionInput { AnalysisInput = input };
                analyzePiiEntities.Parameters = new PiiTaskParameters(
                    options.DisableServiceLogs,
                    options.ModelVersion,
                    new PiiDomain(options.DomainFilter.GetString()),
                    options.CategoriesFilter,
                    Constants.DefaultStringIndexType);

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(analyzePiiEntities, cancellationToken: cancellationToken).ConfigureAwait(false);

                var piiEntities = (PiiTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (piiEntities.Results.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.

                    var error = Transforms.ConvertToError(piiEntities.Results.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToPiiEntityCollection(piiEntities.Results.Documents.FirstOrDefault()), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<PiiEntityCollection> RecognizePiiEntities(string document, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= s_piiEntitiesOptions;

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                var input = new MultiLanguageAnalysisInput();
                foreach (var doc in documents)
                {
                    input.Documents.Add(doc);
                }
                var analyzePiiEntities = new AnalyzeTextPiiEntitiesRecognitionInput { AnalysisInput = input };
                analyzePiiEntities.Parameters = new PiiTaskParameters(
                    options.DisableServiceLogs,
                    options.ModelVersion,
                    new PiiDomain(options.DomainFilter.GetString()),
                    options.CategoriesFilter,
                    Constants.DefaultStringIndexType);

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(analyzePiiEntities, cancellationToken: cancellationToken);
                var piiEntities = (PiiTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (piiEntities.Results.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.

                    var error = Transforms.ConvertToError(piiEntities.Results.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToPiiEntityCollection(piiEntities.Results.Documents.FirstOrDefault()), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(IEnumerable<string> documents, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_piiEntitiesOptions;
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizePiiEntitiesBatchAsync(input, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(IEnumerable<string> documents, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_piiEntitiesOptions;
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return RecognizePiiEntitiesBatch(input, options, cancellationToken);
        }

        public override async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_piiEntitiesOptions;
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return await RecognizePiiEntitiesBatchAsync(input, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(IEnumerable<TextDocumentInput> documents, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= s_piiEntitiesOptions;
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return RecognizePiiEntitiesBatch(input, options, cancellationToken);
        }

        private async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(MultiLanguageAnalysisInput multiLanguageInput, RecognizePiiEntitiesOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntitiesBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextPiiEntitiesRecognitionInput input = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = new PiiTaskParameters(
                                        options.DisableServiceLogs,
                                        options.ModelVersion,
                                        new PiiDomain(options.DomainFilter.GetString()),
                                        options.CategoriesFilter,
                                        Constants.DefaultStringIndexType)
                };

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(
                    input,
                    options.IncludeStatistics,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var entityRecognition = (PiiTaskResult)result.Value;
                Response response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(multiLanguageInput.Documents);
                RecognizePiiEntitiesResultCollection results = Transforms.ConvertToRecognizePiiEntitiesResultCollection(entityRecognition.Results, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(MultiLanguageAnalysisInput multiLanguageInput, RecognizePiiEntitiesOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntitiesBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextPiiEntitiesRecognitionInput input = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = new PiiTaskParameters(
                                        options.DisableServiceLogs,
                                        options.ModelVersion,
                                        new PiiDomain(options.DomainFilter.GetString()),
                                        options.CategoriesFilter,
                                        Constants.DefaultStringIndexType)
                };

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(
                    input,
                    options.IncludeStatistics,
                    cancellationToken: cancellationToken);

                var entityRecognition = (PiiTaskResult)result.Value;
                Response response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(multiLanguageInput.Documents);
                RecognizePiiEntitiesResultCollection results = Transforms.ConvertToRecognizePiiEntitiesResultCollection(entityRecognition.Results, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Analyze Sentiment

        public override async Task<Response<DocumentSentiment>> AnalyzeSentimentAsync(string document, string language = default, AnalyzeSentimentOptions options = null, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(document, nameof(document));
            //options ??= new AnalyzeSentimentOptions();

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            //scope.AddAttribute("document", document);
            //scope.Start();

            //try
            //{
            //    var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
            //    Response<SentimentResponse> result = await _serviceRestClient.SentimentAsync(
            //        new MultiLanguageBatchInput(documents),
            //        options.ModelVersion,
            //        options.IncludeStatistics,
            //        options.DisableServiceLogs,
            //        options.IncludeOpinionMining,
            //        Constants.DefaultStringIndexType,
            //        cancellationToken).ConfigureAwait(false);
            //    Response response = result.GetRawResponse();

            //    if (result.Value.Errors.Count > 0)
            //    {
            //        // only one document, so we can ignore the id and grab the first error message.
            //        var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
            //        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
            //    }

            //    return Response.FromValue(new DocumentSentiment(result.Value.Documents[0]), response);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override Response<DocumentSentiment> AnalyzeSentiment(string document, string language = default, AnalyzeSentimentOptions options = null, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(document, nameof(document));
            //options ??= new AnalyzeSentimentOptions();

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            //scope.AddAttribute("document", document);
            //scope.Start();

            //try
            //{
            //    var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
            //    Response<SentimentResponse> result = _serviceRestClient.Sentiment(
            //        new MultiLanguageBatchInput(documents),
            //        options.ModelVersion,
            //        options.IncludeStatistics,
            //        options.DisableServiceLogs,
            //        options.IncludeOpinionMining,
            //        Constants.DefaultStringIndexType,
            //        cancellationToken);
            //    Response response = result.GetRawResponse();

            //    if (result.Value.Errors.Count > 0)
            //    {
            //        // only one document, so we can ignore the id and grab the first error message.
            //        var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
            //        throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
            //    }

            //    return Response.FromValue(new DocumentSentiment(result.Value.Documents[0]), response);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
            throw new NotImplementedException();
        }

        public override async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<string> documents, string language = default, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new AnalyzeSentimentOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            //return await AnalyzeSentimentBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<string> documents, string language = default, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new AnalyzeSentimentOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            //return AnalyzeSentimentBatch(documentInputs, options, cancellationToken);
            throw new NotImplementedException();
        }

        public override async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<TextDocumentInput> documents, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new AnalyzeSentimentOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            //return await AnalyzeSentimentBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<TextDocumentInput> documents, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new AnalyzeSentimentOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            //return AnalyzeSentimentBatch(documentInputs, options, cancellationToken);
            throw new NotImplementedException();
        }

        #endregion

        #region Extract Key Phrases

        public override async Task<Response<KeyPhraseCollection>> ExtractKeyPhrasesAsync(string document, string language = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(document, nameof(document));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            //scope.AddAttribute("document", document);
            //scope.Start();

            //try
            //{
            //    var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
            //    Response<KeyPhraseResult> result = await _serviceRestClient.KeyPhrasesAsync(new MultiLanguageBatchInput(documents), cancellationToken: cancellationToken).ConfigureAwait(false);
            //    Response response = result.GetRawResponse();

            //    if (result.Value.Errors.Count > 0)
            //    {
            //        // only one document, so we can ignore the id and grab the first error message.
            //        var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
            //        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
            //    }

            //    return Response.FromValue(Transforms.ConvertToKeyPhraseCollection(result.Value.Documents[0]), response);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override Response<KeyPhraseCollection> ExtractKeyPhrases(string document, string language = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(document, nameof(document));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            //scope.AddAttribute("document", document);
            //scope.Start();

            //try
            //{
            //    var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
            //    Response<KeyPhraseResult> result = _serviceRestClient.KeyPhrases(new MultiLanguageBatchInput(documents), cancellationToken: cancellationToken);
            //    Response response = result.GetRawResponse();

            //    if (result.Value.Errors.Count > 0)
            //    {
            //        // only one document, so we can ignore the id and grab the first error message.
            //        var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
            //        throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
            //    }

            //    return Response.FromValue(Transforms.ConvertToKeyPhraseCollection(result.Value.Documents[0]), response);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
            throw new NotImplementedException();
        }

        public override async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new TextAnalyticsRequestOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            //return await ExtractKeyPhrasesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new TextAnalyticsRequestOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            //return ExtractKeyPhrasesBatch(documentInputs, options, cancellationToken);
            throw new NotImplementedException();
        }

        public override async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new TextAnalyticsRequestOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            //return await ExtractKeyPhrasesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new TextAnalyticsRequestOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            //return ExtractKeyPhrasesBatch(documentInputs, options, cancellationToken);
            throw new NotImplementedException();
        }

        #endregion

        #region Linked Entities

        public override async Task<Response<LinkedEntityCollection>> RecognizeLinkedEntitiesAsync(string document, string language = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(document, nameof(document));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntities)}");
            //scope.AddAttribute("document", document);
            //scope.Start();

            //try
            //{
            //    var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };

            //    Response<EntityLinkingResult> result = await _serviceRestClient.EntitiesLinkingAsync(
            //        new MultiLanguageBatchInput(documents),
            //        stringIndexType: Constants.DefaultStringIndexType,
            //        cancellationToken: cancellationToken).ConfigureAwait(false);
            //    Response response = result.GetRawResponse();

            //    if (result.Value.Errors.Count > 0)
            //    {
            //        // only one document, so we can ignore the id and grab the first error message.
            //        var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
            //        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
            //    }

            //    return Response.FromValue(Transforms.ConvertToLinkedEntityCollection(result.Value.Documents[0]), response);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override Response<LinkedEntityCollection> RecognizeLinkedEntities(string document, string language = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(document, nameof(document));

            //using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntities)}");
            //scope.AddAttribute("document", document);
            //scope.Start();

            //try
            //{
            //    var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };

            //    Response<EntityLinkingResult> result = _serviceRestClient.EntitiesLinking(
            //        new MultiLanguageBatchInput(documents),
            //        stringIndexType: Constants.DefaultStringIndexType,
            //        cancellationToken: cancellationToken);
            //    Response response = result.GetRawResponse();

            //    if (result.Value.Errors.Count > 0)
            //    {
            //        // only one document, so we can ignore the id and grab the first error message.
            //        var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
            //        throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
            //    }

            //    return Response.FromValue(Transforms.ConvertToLinkedEntityCollection(result.Value.Documents[0]), response);
            //}
            //catch (Exception e)
            //{
            //    scope.Failed(e);
            //    throw;
            //}
            throw new NotImplementedException();
        }

        public override async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new TextAnalyticsRequestOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            //return await RecognizeLinkedEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new TextAnalyticsRequestOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            //return RecognizeLinkedEntitiesBatch(documentInputs, options, cancellationToken);
            throw new NotImplementedException();
        }

        public override async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new TextAnalyticsRequestOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            //return await RecognizeLinkedEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new TextAnalyticsRequestOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            //return RecognizeLinkedEntitiesBatch(documentInputs, options, cancellationToken);
            throw new NotImplementedException();
        }

        #endregion

        #region Healthcare

        public override async Task<AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new AnalyzeHealthcareEntitiesOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            //return await StartAnalyzeHealthcareEntitiesAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //options ??= new AnalyzeHealthcareEntitiesOptions();
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            //return StartAnalyzeHealthcareEntities(documentInputs, options, cancellationToken);
            throw new NotImplementedException();
        }

        public override AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNull(documents, nameof(documents));

            //options ??= new AnalyzeHealthcareEntitiesOptions();

            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            //return StartAnalyzeHealthcareEntities(documentInputs, options, cancellationToken);
            throw new NotImplementedException();
        }

        public override async Task<AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNull(documents, nameof(documents));

            //options ??= new AnalyzeHealthcareEntitiesOptions();

            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            //return await StartAnalyzeHealthcareEntitiesAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
            await Task.Yield();
            throw new NotImplementedException();
        }

        #endregion

        #region Analyze Operation

        public override async Task<AnalyzeActionsOperation> StartAnalyzeActionsAsync(IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //Argument.AssertNotNull(actions, nameof(actions));
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            //return await StartAnalyzeActionsAsync(documentInputs, actions, options, cancellationToken).ConfigureAwait(false);
            await Task.Yield();
            throw new NotImplementedException();
        }

        public override AnalyzeActionsOperation StartAnalyzeActions(IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //Argument.AssertNotNull(actions, nameof(actions));
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            //return StartAnalyzeActions(documentInputs, actions, options, cancellationToken);
            throw new NotImplementedException();
        }

        public override AnalyzeActionsOperation StartAnalyzeActions(IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //Argument.AssertNotNull(actions, nameof(actions));
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            //return StartAnalyzeActions(documentInputs, actions, options, cancellationToken);
            throw new NotImplementedException();
        }

        public override async Task<AnalyzeActionsOperation> StartAnalyzeActionsAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            //Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            //Argument.AssertNotNull(actions, nameof(actions));
            //MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            //return await StartAnalyzeActionsAsync(documentInputs, actions, options, cancellationToken).ConfigureAwait(false);
            await Task.Yield();
            throw new NotImplementedException();
        }

        private static JobManifestTasks CreateTasks(TextAnalyticsActions actions)
        {
            //JobManifestTasks tasks = new();

            //if (actions.RecognizePiiEntitiesActions != null)
            //{
            //    tasks.EntityRecognitionPiiTasks = Transforms.ConvertFromRecognizePiiEntitiesActionsToTasks(actions.RecognizePiiEntitiesActions);
            //}
            //if (actions.RecognizeEntitiesActions != null)
            //{
            //    tasks.EntityRecognitionTasks = Transforms.ConvertFromRecognizeEntitiesActionsToTasks(actions.RecognizeEntitiesActions);
            //}
            //if (actions.RecognizeCustomEntitiesActions != null)
            //{
            //    tasks.CustomEntityRecognitionTasks = Transforms.ConvertFromRecognizeCustomEntitiesActionsToTasks(actions.RecognizeCustomEntitiesActions);
            //}
            //if (actions.ExtractKeyPhrasesActions != null)
            //{
            //    tasks.KeyPhraseExtractionTasks = Transforms.ConvertFromExtractKeyPhrasesActionsToTasks(actions.ExtractKeyPhrasesActions);
            //}
            //if (actions.RecognizeLinkedEntitiesActions != null)
            //{
            //    tasks.EntityLinkingTasks = Transforms.ConvertFromRecognizeLinkedEntitiesActionsToTasks(actions.RecognizeLinkedEntitiesActions);
            //}
            //if (actions.AnalyzeSentimentActions != null)
            //{
            //    tasks.SentimentAnalysisTasks = Transforms.ConvertFromAnalyzeSentimentActionsToTasks(actions.AnalyzeSentimentActions);
            //}
            //if (actions.ExtractSummaryActions != null)
            //{
            //    tasks.ExtractiveSummarizationTasks = Transforms.ConvertFromExtractSummaryActionsToTasks(actions.ExtractSummaryActions);
            //}
            //if (actions.SingleCategoryClassifyActions != null)
            //{
            //    tasks.CustomSingleClassificationTasks = Transforms.ConvertFromSingleCategoryClassifyActionsToTasks(actions.SingleCategoryClassifyActions);
            //}
            //if (actions.MultiCategoryClassifyActions != null)
            //{
            //    tasks.CustomMultiClassificationTasks = Transforms.ConvertFromMultiCategoryClassifyActionsToTasks(actions.MultiCategoryClassifyActions);
            //}
            //return tasks;

            throw new NotImplementedException();
        }

        #endregion

        #region Common

        private static IDictionary<string, int> CreateIdToIndexMap<T>(IEnumerable<T> documents)
        {
            var map = new Dictionary<string, int>(documents.Count());

            int i = 0;
            foreach (T item in documents)
            {
                string id = item switch
                {
                    LanguageInput li => li.Id,
                    MultiLanguageInput mli => mli.Id,
                    _ => throw new NotSupportedException(),
                };

                map[id] = i++;
            }

            return map;
        }

        private MultiLanguageInput ConvertToMultiLanguageInput(string document, string language, int id = 0)
            => new MultiLanguageInput(id.ToString(CultureInfo.InvariantCulture), document) { Language = language ?? _options.DefaultLanguage };

        private MultiLanguageAnalysisInput ConvertToMultiLanguageInputs(IEnumerable<string> documents, string language)
        {
            MultiLanguageAnalysisInput input = new MultiLanguageAnalysisInput();
            int i = 0;
            foreach (var document in documents)
            {
                input.Documents.Add(ConvertToMultiLanguageInput(document, language, i++));
            }
            return input;
        }

        private MultiLanguageAnalysisInput ConvertToMultiLanguageInputs(IEnumerable<TextDocumentInput> documents)
        {
            MultiLanguageAnalysisInput input = new MultiLanguageAnalysisInput();
            foreach (var document in documents)
            {
                input.Documents.Add(new MultiLanguageInput(document.Id, document.Text) { Language = document.Language ?? _options.DefaultLanguage });
            }
            return input;
        }

        private LanguageInput ConvertToLanguageInput(string document, string countryHint, int id = 0)
            => new LanguageInput($"{id}", document) { CountryHint = countryHint ?? _options.DefaultCountryHint };

        private static IDictionary<string, string> CreateAdditionalInformation(TextAnalyticsError error) =>
            (string.IsNullOrEmpty(error.Target))
                ? null
                : new Dictionary<string, string> { { "Target", error.Target } };

        #endregion
    }
}
