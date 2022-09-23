﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Legacy;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.TextAnalytics.ServiceClients
{
    /// <summary>
    ///   Allows the <see cref="TextAnalyticsClient" /> to operate against the
    ///   legacy Text Analytics REST API service using an abstraction common among
    ///   the different service.
    /// </summary>
    ///
    internal class LegacyServiceClient : ServiceClient
    {
        private static readonly TextAnalyticsRequestOptions DefaultRequestOptions = new();
        private static readonly RecognizePiiEntitiesOptions DefaultPiiEntitiesOptions = new();
        private static readonly AnalyzeHealthcareEntitiesOptions DefaultHeathcareEntitiesOptions = new();
        private static readonly AnalyzeSentimentOptions DefaultAnalyzeSentimentOptions = new();

        private readonly TextAnalyticsRestClient _serviceRestClient;
        private readonly TextAnalyticsClientOptions _options;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _baseUri;

        public override ClientDiagnostics Diagnostics => _clientDiagnostics;

        public LegacyServiceClient(Uri endpoint, TokenCredential credential, string authorizationScope, string serviceVersion, TextAnalyticsClientOptions options)
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
            _serviceRestClient = new TextAnalyticsRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri, serviceVersion);
        }

        public LegacyServiceClient(Uri endpoint, AzureKeyCredential credential, string serviceVersion, TextAnalyticsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Argument.AssertNotNullOrEmpty(serviceVersion, nameof(serviceVersion));

            _baseUri = endpoint;
            _clientDiagnostics = new TextAnalyticsClientDiagnostics(options);
            _options = options;

            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader));
            _serviceRestClient = new TextAnalyticsRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri, serviceVersion);
        }

        internal TextAnalyticsClientOptions.ServiceVersion ServiceVersion => _options.Version;

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

                Response<LanguageResult> result = await _serviceRestClient.LanguagesAsync(new LanguageBatchInput(documents), cancellationToken: cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToDetectedLanguage(result.Value.Documents[0]), response);
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
                Response<LanguageResult> result = _serviceRestClient.Languages(new LanguageBatchInput(documents), cancellationToken: cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToDetectedLanguage(result.Value.Documents[0]), response);
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
            options ??= DefaultRequestOptions;
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents, countryHint);

            return await DetectLanguageBatchAsync(detectLanguageInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<DetectLanguageResultCollection> DetectLanguageBatch(IEnumerable<string> documents, string countryHint = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents, countryHint);

            return DetectLanguageBatch(detectLanguageInputs, options, cancellationToken);
        }

        public override async Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(IEnumerable<DetectLanguageInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents);

            return await DetectLanguageBatchAsync(detectLanguageInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<DetectLanguageResultCollection> DetectLanguageBatch(IEnumerable<DetectLanguageInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents);

            return DetectLanguageBatch(detectLanguageInputs, options, cancellationToken);
        }

        private async Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(LanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguageBatch)}");
            scope.Start();

            try
            {
                Response<LanguageResult> result = await _serviceRestClient.LanguagesAsync(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                DetectLanguageResultCollection results = Transforms.ConvertToDetectLanguageResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<DetectLanguageResultCollection> DetectLanguageBatch(LanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguageBatch)}");
            scope.Start();

            try
            {
                Response<LanguageResult> result = _serviceRestClient.Languages(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                DetectLanguageResultCollection results = Transforms.ConvertToDetectLanguageResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

                Response<EntitiesResult> result = await _serviceRestClient.EntitiesRecognitionGeneralAsync(
                    new MultiLanguageBatchInput(documents),
                    stringIndexType: Constants.DefaultLegacyStringIndexType,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToCategorizedEntityCollection(result.Value.Documents[0]), response);
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

                Response<EntitiesResult> result = _serviceRestClient.EntitiesRecognitionGeneral(
                    new MultiLanguageBatchInput(documents),
                    stringIndexType: Constants.DefaultLegacyStringIndexType,
                    cancellationToken: cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToCategorizedEntityCollection(result.Value.Documents[0]), response);
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
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizeEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return RecognizeEntitiesBatch(documentInputs, options, cancellationToken);
        }

        public override async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await RecognizeEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return RecognizeEntitiesBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntitiesBatch)}");
            scope.Start();

            try
            {
                Response<EntitiesResult> result = await _serviceRestClient.EntitiesRecognitionGeneralAsync(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    Constants.DefaultLegacyStringIndexType,
                    cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizeEntitiesResultCollection results = Transforms.ConvertToRecognizeEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntitiesBatch)}");
            scope.Start();

            try
            {
                Response<EntitiesResult> result = _serviceRestClient.EntitiesRecognitionGeneral(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    Constants.DefaultLegacyStringIndexType,
                    cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizeEntitiesResultCollection results = Transforms.ConvertToRecognizeEntitiesResultCollection(result.Value, map);
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
            Validation.SupportsOperation($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.RecognizePiiEntitiesAsync)}", TextAnalyticsClientOptions.ServiceVersion.V3_1, ServiceVersion);

            options ??= DefaultPiiEntitiesOptions;

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                var filters = options.CategoriesFilter.Count > 0 ? new List<Legacy.Models.PiiEntityLegacyCategory>(options.CategoriesFilter.Count) : null;

                foreach (var filter in options.CategoriesFilter)
                {
                    filters.Add(new Legacy.Models.PiiEntityLegacyCategory(filter.ToString()));
                }

                var result = await _serviceRestClient.EntitiesRecognitionPiiAsync(
                    new MultiLanguageBatchInput(documents),
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    options.DomainFilter.GetString(),
                    Constants.DefaultLegacyStringIndexType,
                    filters,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToPiiEntityCollection(result.Value.Documents[0]), response);
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
            Validation.SupportsOperation($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.RecognizePiiEntities)}", TextAnalyticsClientOptions.ServiceVersion.V3_1, ServiceVersion);

            options ??= DefaultPiiEntitiesOptions;

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                var filters = options.CategoriesFilter.Count > 0 ? new List<Legacy.Models.PiiEntityLegacyCategory>(options.CategoriesFilter.Count) : null;

                foreach (var filter in options.CategoriesFilter)
                {
                    filters.Add(new Legacy.Models.PiiEntityLegacyCategory(filter.ToString()));
                }

                var result = _serviceRestClient.EntitiesRecognitionPii(
                    new MultiLanguageBatchInput(documents),
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    options.DomainFilter.GetString(),
                    Constants.DefaultLegacyStringIndexType,
                    filters,
                    cancellationToken: cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToPiiEntityCollection(result.Value.Documents[0]), response);
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
            options ??= DefaultPiiEntitiesOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizePiiEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(IEnumerable<string> documents, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultPiiEntitiesOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return RecognizePiiEntitiesBatch(documentInputs, options, cancellationToken);
        }

        public override async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultPiiEntitiesOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await RecognizePiiEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(IEnumerable<TextDocumentInput> documents, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultPiiEntitiesOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return RecognizePiiEntitiesBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(MultiLanguageBatchInput batchInput, RecognizePiiEntitiesOptions options, CancellationToken cancellationToken)
        {
            Validation.SupportsOperation($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.RecognizePiiEntitiesBatchAsync)}", TextAnalyticsClientOptions.ServiceVersion.V3_1, ServiceVersion);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntitiesBatch)}");
            scope.Start();

            try
            {
                var filters = options.CategoriesFilter.Count > 0 ? new List<Legacy.Models.PiiEntityLegacyCategory>(options.CategoriesFilter.Count) : null;

                foreach (var filter in options.CategoriesFilter)
                {
                    filters.Add(new Legacy.Models.PiiEntityLegacyCategory(filter.ToString()));
                }

                var result = await _serviceRestClient.EntitiesRecognitionPiiAsync(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    options.DomainFilter.GetString(),
                    Constants.DefaultLegacyStringIndexType,
                    filters,
                    cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizePiiEntitiesResultCollection results = Transforms.ConvertToRecognizePiiEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(MultiLanguageBatchInput batchInput, RecognizePiiEntitiesOptions options, CancellationToken cancellationToken)
        {
            Validation.SupportsOperation($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.RecognizePiiEntitiesBatch)}", TextAnalyticsClientOptions.ServiceVersion.V3_1, ServiceVersion);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntitiesBatch)}");
            scope.Start();

            try
            {
                var filters = options.CategoriesFilter.Count > 0 ? new List<Legacy.Models.PiiEntityLegacyCategory>(options.CategoriesFilter.Count) : null;

                foreach (var filter in options.CategoriesFilter)
                {
                    filters.Add(new Legacy.Models.PiiEntityLegacyCategory(filter.ToString()));
                }

               var result = _serviceRestClient.EntitiesRecognitionPii(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    options.DomainFilter.GetString(),
                    Constants.DefaultLegacyStringIndexType,
                    filters,
                    cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizePiiEntitiesResultCollection results = Transforms.ConvertToRecognizePiiEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Recognize Custom Entities

        public override RecognizeCustomEntitiesOperation StartRecognizeCustomEntities(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartRecognizeCustomEntities)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);

        public override RecognizeCustomEntitiesOperation StartRecognizeCustomEntities(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartRecognizeCustomEntities)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);

        public override Task<RecognizeCustomEntitiesOperation> StartRecognizeCustomEntitiesAsync(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartRecognizeCustomEntitiesAsync)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);

        public override Task<RecognizeCustomEntitiesOperation> StartRecognizeCustomEntitiesAsync(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartRecognizeCustomEntitiesAsync)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);

        #endregion

        #region Analyze Sentiment

        public override async Task<Response<DocumentSentiment>> AnalyzeSentimentAsync(string document, string language = default, AnalyzeSentimentOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= DefaultAnalyzeSentimentOptions;

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                Response<SentimentResponse> result = await _serviceRestClient.SentimentAsync(
                    new MultiLanguageBatchInput(documents),
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    options.IncludeOpinionMining,
                    Constants.DefaultLegacyStringIndexType,
                    cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToDocumentSentiment(result.Value.Documents[0]), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<DocumentSentiment> AnalyzeSentiment(string document, string language = default, AnalyzeSentimentOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= DefaultAnalyzeSentimentOptions;

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                Response<SentimentResponse> result = _serviceRestClient.Sentiment(
                    new MultiLanguageBatchInput(documents),
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    options.IncludeOpinionMining,
                    Constants.DefaultLegacyStringIndexType,
                    cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToDocumentSentiment(result.Value.Documents[0]), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<string> documents, string language = default, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultAnalyzeSentimentOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await AnalyzeSentimentBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<string> documents, string language = default, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultAnalyzeSentimentOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return AnalyzeSentimentBatch(documentInputs, options, cancellationToken);
        }

        public override async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<TextDocumentInput> documents, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultAnalyzeSentimentOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await AnalyzeSentimentBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<TextDocumentInput> documents, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultAnalyzeSentimentOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return AnalyzeSentimentBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(MultiLanguageBatchInput batchInput, AnalyzeSentimentOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentimentBatch)}");
            scope.Start();

            try
            {
                Response<SentimentResponse> result = await _serviceRestClient.SentimentAsync(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    options.IncludeOpinionMining,
                    Constants.DefaultLegacyStringIndexType,
                    cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                AnalyzeSentimentResultCollection results = Transforms.ConvertToAnalyzeSentimentResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(MultiLanguageBatchInput batchInput, AnalyzeSentimentOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentimentBatch)}");
            scope.Start();

            try
            {
                Response<SentimentResponse> result = _serviceRestClient.Sentiment(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    options.IncludeOpinionMining,
                    Constants.DefaultLegacyStringIndexType,
                    cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                AnalyzeSentimentResultCollection results = Transforms.ConvertToAnalyzeSentimentResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Extract Key Phrases

        public override async Task<Response<KeyPhraseCollection>> ExtractKeyPhrasesAsync(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                Response<KeyPhraseResult> result = await _serviceRestClient.KeyPhrasesAsync(new MultiLanguageBatchInput(documents), cancellationToken: cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToKeyPhraseCollection(result.Value.Documents[0]), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<KeyPhraseCollection> ExtractKeyPhrases(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                Response<KeyPhraseResult> result = _serviceRestClient.KeyPhrases(new MultiLanguageBatchInput(documents), cancellationToken: cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToKeyPhraseCollection(result.Value.Documents[0]), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await ExtractKeyPhrasesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return ExtractKeyPhrasesBatch(documentInputs, options, cancellationToken);
        }

        public override async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await ExtractKeyPhrasesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return ExtractKeyPhrasesBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrasesBatch)}");
            scope.Start();

            try
            {
                Response<KeyPhraseResult> result = await _serviceRestClient.KeyPhrasesAsync(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                ExtractKeyPhrasesResultCollection results = Transforms.ConvertToExtractKeyPhrasesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrasesBatch)}");
            scope.Start();

            try
            {
                Response<KeyPhraseResult> result = _serviceRestClient.KeyPhrases(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                ExtractKeyPhrasesResultCollection results = Transforms.ConvertToExtractKeyPhrasesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Linked Entities

        public override async Task<Response<LinkedEntityCollection>> RecognizeLinkedEntitiesAsync(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };

                Response<EntityLinkingResult> result = await _serviceRestClient.EntitiesLinkingAsync(
                    new MultiLanguageBatchInput(documents),
                    stringIndexType: Constants.DefaultLegacyStringIndexType,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToLinkedEntityCollection(result.Value.Documents[0]), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<LinkedEntityCollection> RecognizeLinkedEntities(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };

                Response<EntityLinkingResult> result = _serviceRestClient.EntitiesLinking(
                    new MultiLanguageBatchInput(documents),
                    stringIndexType: Constants.DefaultLegacyStringIndexType,
                    cancellationToken: cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, new ResponseError(error.ErrorCode.ToString(), error.Message), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToLinkedEntityCollection(result.Value.Documents[0]), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizeLinkedEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return RecognizeLinkedEntitiesBatch(documentInputs, options, cancellationToken);
        }

        public override async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await RecognizeLinkedEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultRequestOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return RecognizeLinkedEntitiesBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntitiesBatch)}");
            scope.Start();

            try
            {
                Response<EntityLinkingResult> result = await _serviceRestClient.EntitiesLinkingAsync(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    Constants.DefaultLegacyStringIndexType,
                    cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizeLinkedEntitiesResultCollection results = Transforms.ConvertToRecognizeLinkedEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntitiesBatch)}");
            scope.Start();

            try
            {
                Response<EntityLinkingResult> result = _serviceRestClient.EntitiesLinking(batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DisableServiceLogs,
                    Constants.DefaultLegacyStringIndexType,
                    cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizeLinkedEntitiesResultCollection results = Transforms.ConvertToRecognizeLinkedEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Healthcare

        public override async Task<AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultHeathcareEntitiesOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await StartAnalyzeHealthcareEntitiesAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= DefaultHeathcareEntitiesOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return StartAnalyzeHealthcareEntities(documentInputs, options, cancellationToken);
        }

        public override AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(documents, nameof(documents));
            options ??= DefaultHeathcareEntitiesOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return StartAnalyzeHealthcareEntities(documentInputs, options, cancellationToken);
        }

        public override async Task<AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(documents, nameof(documents));
            options ??= DefaultHeathcareEntitiesOptions;
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await StartAnalyzeHealthcareEntitiesAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        private AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(MultiLanguageBatchInput batchInput, AnalyzeHealthcareEntitiesOptions options, CancellationToken cancellationToken = default)
        {
            Validation.SupportsOperation($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartAnalyzeHealthcareEntities)}", TextAnalyticsClientOptions.ServiceVersion.V3_1, ServiceVersion);

            options ??= DefaultHeathcareEntitiesOptions;

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeHealthcareEntities)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<TextAnalyticsHealthHeaders> response = _serviceRestClient.Health(
                    batchInput,
                    options.ModelVersion,
                    Constants.DefaultLegacyStringIndexType,
                    options.DisableServiceLogs,
                    cancellationToken);
                string location = response.Headers.OperationLocation;

                var _idToIndexMap = CreateIdToIndexMap(batchInput.Documents);

                return new AnalyzeHealthcareEntitiesOperation(this, _clientDiagnostics, location, _idToIndexMap, options.IncludeStatistics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(MultiLanguageBatchInput batchInput, AnalyzeHealthcareEntitiesOptions options, CancellationToken cancellationToken = default)
        {
            Validation.SupportsOperation($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartAnalyzeHealthcareEntitiesAsync)}", TextAnalyticsClientOptions.ServiceVersion.V3_1, ServiceVersion);

            options ??= DefaultHeathcareEntitiesOptions;

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeHealthcareEntities)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<TextAnalyticsHealthHeaders> response = await _serviceRestClient.HealthAsync(
                    batchInput,
                    options.ModelVersion,
                    Constants.DefaultLegacyStringIndexType,
                    options.DisableServiceLogs,
                    cancellationToken).ConfigureAwait(false);
                string location = response.Headers.OperationLocation;

                var _idToIndexMap = CreateIdToIndexMap(batchInput.Documents);

                return new AnalyzeHealthcareEntitiesOperation(this, _clientDiagnostics, location, _idToIndexMap, options.IncludeStatistics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<Models.HealthcareJobStatusResult>> HealthStatusAsync(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            if (!Guid.TryParse(jobId, out var id))
            {
                throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(HealthStatus)}");
            scope.Start();

            try
            {
                var result = await _serviceRestClient.HealthStatusAsync(id, top, skip, showStats, cancellationToken).ConfigureAwait(false);
                var status = Transforms.ConvertToHealthcareJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<Models.HealthcareJobStatusResult> HealthStatus(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            if (!Guid.TryParse(jobId, out var id))
            {
                throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(HealthStatus)}");
            scope.Start();

            try
            {
                var result = _serviceRestClient.HealthStatus(id, top, skip, showStats, cancellationToken);
                var status = Transforms.ConvertToHealthcareJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<Models.HealthcareJobStatusResult>> HealthStatusNextPageAsync(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(HealthStatusNextPage)}");
            scope.Start();

            try
            {
                var result = await _serviceRestClient.HealthStatusNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                var status = Transforms.ConvertToHealthcareJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<Models.HealthcareJobStatusResult> HealthStatusNextPage(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(HealthStatusNextPage)}");
            scope.Start();

            try
            {
                var result = _serviceRestClient.HealthStatusNextPage(nextLink, cancellationToken);
                var status = Transforms.ConvertToHealthcareJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task CancelHealthcareJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            if (!Guid.TryParse(jobId, out var id))
            {
                throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(CancelHealthcareJob)}");
            scope.Start();

            try
            {
                await _serviceRestClient.CancelHealthJobAsync(id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override void CancelHealthcareJob(string jobId, CancellationToken cancellationToken = default)
        {
            {
                Argument.AssertNotNull(jobId, nameof(jobId));

                if (!Guid.TryParse(jobId, out var id))
                {
                    throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
                }

                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(CancelHealthcareJob)}");
                scope.Start();

                try
                {
                    _serviceRestClient.CancelHealthJob(id, cancellationToken);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
        }

        #endregion

        #region Analyze Operation

        public override async Task<AnalyzeActionsOperation> StartAnalyzeActionsAsync(IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await StartAnalyzeActionsAsync(documentInputs, actions, options, cancellationToken).ConfigureAwait(false);
        }

        public override AnalyzeActionsOperation StartAnalyzeActions(IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return StartAnalyzeActions(documentInputs, actions, options, cancellationToken);
        }

        public override AnalyzeActionsOperation StartAnalyzeActions(IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return StartAnalyzeActions(documentInputs, actions, options, cancellationToken);
        }

        public override async Task<AnalyzeActionsOperation> StartAnalyzeActionsAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await StartAnalyzeActionsAsync(documentInputs, actions, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<Response<Models.AnalyzeTextJobStatusResult>> AnalyzeStatusAsync(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeStatus)}");
            scope.Start();

            try
            {
                var result = await _serviceRestClient.AnalyzeStatusAsync(jobId, showStats, top, skip, cancellationToken).ConfigureAwait(false);
                var status = Transforms.ConvertToAnalyzeTextJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<Models.AnalyzeTextJobStatusResult> AnalyzeStatus(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeStatus)}");
            scope.Start();

            try
            {
                var result = _serviceRestClient.AnalyzeStatus(jobId, showStats, top, skip, cancellationToken);
                var status = Transforms.ConvertToAnalyzeTextJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<Models.AnalyzeTextJobStatusResult>> AnalyzeStatusNextPageAsync(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeStatusNextPage)}");
            scope.Start();

            try
            {
                var result = await _serviceRestClient.AnalyzeStatusNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                var status = Transforms.ConvertToAnalyzeTextJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<Models.AnalyzeTextJobStatusResult> AnalyzeStatusNextPage(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeStatusNextPage)}");
            scope.Start();

            try
            {
                var result = _serviceRestClient.AnalyzeStatusNextPage(nextLink, cancellationToken);
                var status = Transforms.ConvertToAnalyzeTextJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Task CancelAnalyzeActionsJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            throw Validation.NotSupported("Cancellation", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        }

        public override void CancelAnalyzeActionsJob(string jobId, CancellationToken cancellationToken = default)
        {
            throw Validation.NotSupported("Cancellation", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        }

        private AnalyzeActionsOperation StartAnalyzeActions(MultiLanguageBatchInput batchInput, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Validation.SupportsOperation($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartAnalyzeActions)}", TextAnalyticsClientOptions.ServiceVersion.V3_1, ServiceVersion);

            options ??= new AnalyzeActionsOptions();
            AnalyzeBatchInput analyzeDocumentInputs = new AnalyzeBatchInput(batchInput, CreateTasks(actions)) { DisplayName = actions.DisplayName };
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeActions)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<TextAnalyticsAnalyzeHeaders> response = _serviceRestClient.Analyze(analyzeDocumentInputs, cancellationToken);
                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(batchInput.Documents);

                return new AnalyzeActionsOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<AnalyzeActionsOperation> StartAnalyzeActionsAsync(MultiLanguageBatchInput batchInput, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Validation.SupportsOperation($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartAnalyzeActionsAsync)}", TextAnalyticsClientOptions.ServiceVersion.V3_1, ServiceVersion);

            options ??= new AnalyzeActionsOptions();

            AnalyzeBatchInput analyzeDocumentInputs = new AnalyzeBatchInput(batchInput, CreateTasks(actions)) { DisplayName = actions.DisplayName };

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeActions)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<TextAnalyticsAnalyzeHeaders> response = await _serviceRestClient.AnalyzeAsync(analyzeDocumentInputs, cancellationToken).ConfigureAwait(false);
                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(batchInput.Documents);

                return new AnalyzeActionsOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Legacy.JobManifestTasks CreateTasks(TextAnalyticsActions actions)
        {
            Legacy.JobManifestTasks tasks = new();

            if (actions.RecognizePiiEntitiesActions != null)
            {
                tasks.EntityRecognitionPiiTasks = Transforms.ConvertFromRecognizePiiEntitiesActionsToLegacyTasks(actions.RecognizePiiEntitiesActions);
            }
            if (actions.RecognizeEntitiesActions != null)
            {
                tasks.EntityRecognitionTasks = Transforms.ConvertFromRecognizeEntitiesActionsToLegacyTasks(actions.RecognizeEntitiesActions);
            }
            if (actions.ExtractKeyPhrasesActions != null)
            {
                tasks.KeyPhraseExtractionTasks = Transforms.ConvertFromExtractKeyPhrasesActionsToLegacyTasks(actions.ExtractKeyPhrasesActions);
            }
            if (actions.RecognizeLinkedEntitiesActions != null)
            {
                tasks.EntityLinkingTasks = Transforms.ConvertFromRecognizeLinkedEntitiesActionsToLegacyTasks(actions.RecognizeLinkedEntitiesActions);
            }
            if (actions.AnalyzeSentimentActions != null)
            {
                tasks.SentimentAnalysisTasks = Transforms.ConvertFromAnalyzeSentimentActionsToLegacyTasks(actions.AnalyzeSentimentActions);
            }

            // Not supported in legacy service.
            if (actions.AnalyzeHealthcareEntitiesActions != null && actions.AnalyzeHealthcareEntitiesActions.Count > 0)
            {
                throw Validation.NotSupported(nameof(AnalyzeHealthcareEntitiesAction), TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
            }
            if (actions.MultiLabelClassifyActions != null && actions.MultiLabelClassifyActions.Count > 0)
            {
                throw Validation.NotSupported(nameof(MultiLabelClassifyAction), TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
            }
            if (actions.RecognizeCustomEntitiesActions != null && actions.RecognizeCustomEntitiesActions.Count > 0)
            {
                throw Validation.NotSupported(nameof(RecognizeCustomEntitiesAction), TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
            }
            if (actions.SingleLabelClassifyActions != null && actions.SingleLabelClassifyActions.Count > 0)
            {
                throw Validation.NotSupported(nameof(SingleLabelClassifyAction), TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
            }
            return tasks;
        }

        #endregion

        #region Single Label Classify

        public override ClassifyDocumentOperation StartSingleLabelClassify(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartSingleLabelClassify)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        public override ClassifyDocumentOperation StartSingleLabelClassify(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartSingleLabelClassify)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        public override Task<ClassifyDocumentOperation> StartSingleLabelClassifyAsync(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartSingleLabelClassifyAsync)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        public override Task<ClassifyDocumentOperation> StartSingleLabelClassifyAsync(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartSingleLabelClassifyAsync)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);

        #endregion

        #region Multi Label Classify

        public override ClassifyDocumentOperation StartMultiLabelClassify(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartMultiLabelClassify)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        public override ClassifyDocumentOperation StartMultiLabelClassify(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartMultiLabelClassify)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        public override Task<ClassifyDocumentOperation> StartMultiLabelClassifyAsync(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartMultiLabelClassifyAsync)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        public override Task<ClassifyDocumentOperation> StartMultiLabelClassifyAsync(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported($"{nameof(TextAnalyticsClient)}.{nameof(TextAnalyticsClient.StartMultiLabelClassifyAsync)}", TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);

        #endregion

        #region Long Running Operations

        public override Task<Response<Models.AnalyzeTextJobState>> AnalyzeTextJobStatusAsync(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported(nameof(AnalyzeTextJobStatusAsync), TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        public override Response<Models.AnalyzeTextJobState> AnalyzeTextJobStatus(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported(nameof(AnalyzeTextJobStatus), TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        public override Task<Response<Models.AnalyzeTextJobState>> AnalyzeTextJobStatusNextPageAsync(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported(nameof(AnalyzeTextJobStatusNextPageAsync), TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);
        public override Response<Models.AnalyzeTextJobState> AnalyzeTextJobStatusNextPage(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default) =>
            throw Validation.NotSupported(nameof(AnalyzeTextJobStatusNextPage), TextAnalyticsClientOptions.ServiceVersion.V2022_05_01, ServiceVersion);

        #endregion

        #region Common

        private MultiLanguageInput ConvertToMultiLanguageInput(string document, string language, int id = 0)
            => new MultiLanguageInput($"{id}", document) { Language = language ?? _options.DefaultLanguage };

        private MultiLanguageBatchInput ConvertToMultiLanguageInputs(IEnumerable<string> documents, string language)
        {
            var batchInput = new MultiLanguageBatchInput(Array.Empty<MultiLanguageInput>());
            var i = 0;

            foreach (var document in documents)
            {
                batchInput.Documents.Add(ConvertToMultiLanguageInput(document, language, i));
                ++i;
            }

            return batchInput;
        }

        private MultiLanguageBatchInput ConvertToMultiLanguageInputs(IEnumerable<TextDocumentInput> documents)
        {
            var batchInput = new MultiLanguageBatchInput(Array.Empty<MultiLanguageInput>());;

            foreach (var document in documents)
            {
                batchInput.Documents.Add(new MultiLanguageInput(document.Id, document.Text) { Language = document.Language ?? _options.DefaultLanguage });;
            }

            return batchInput;
        }

        private LanguageInput ConvertToLanguageInput(string document, string countryHint, int id = 0)
            => new LanguageInput($"{id}", document) { CountryHint = countryHint ?? _options.DefaultCountryHint };

        private LanguageBatchInput ConvertToLanguageInputs(IEnumerable<string> documents, string countryHint)
        {
            var batchInput = new LanguageBatchInput(Array.Empty<LanguageInput>());
            var i = 0;

            foreach (var document in documents)
            {
                batchInput.Documents.Add(ConvertToLanguageInput(document, countryHint, i));
                ++i;
            }

            return batchInput;
        }

        private LanguageBatchInput ConvertToLanguageInputs(IEnumerable<DetectLanguageInput> documents)
        {
            var batchInput = new LanguageBatchInput(Array.Empty<LanguageInput>());

            foreach (var document in documents)
            {
                batchInput.Documents.Add(new LanguageInput(document.Id, document.Text) { CountryHint = document.CountryHint ?? _options.DefaultCountryHint });
            }

            return batchInput;
        }

        private static IDictionary<string, int> CreateIdToIndexMap<T>(IEnumerable<T> documents)
        {
            var map = documents switch
            {
                IList<T> list => new Dictionary<string, int>(list.Count),
                _ => new Dictionary<string, int>()
            };

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

        private static IDictionary<string, string> CreateAdditionalInformation(TextAnalyticsError error) =>
            error.Target switch
            {
                { Length: > 0 } => new Dictionary<string, string> { { "Target", error.Target } },
                _ => null
            };

        #endregion
    }
}
