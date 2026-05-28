// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private readonly MicrosoftCognitiveLanguageServiceTextAnalysisRestClient _languageRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly Uri _baseUri;

        public override ClientDiagnostics Diagnostics => _clientDiagnostics;

        public LanguageServiceClient(Uri endpoint, TokenCredential credential, string authorizationScope, string serviceVersion, TextAnalyticsClientOptions options)
            : base(options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Argument.AssertNotNullOrEmpty(authorizationScope, nameof(authorizationScope));
            Argument.AssertNotNullOrEmpty(serviceVersion, nameof(serviceVersion));

            _baseUri = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);

            var pipeline = HttpPipelineBuilder.Build(new HttpPipelineOptions(options)
            {
                PerRetryPolicies = { new BearerTokenAuthenticationPolicy(credential, authorizationScope) },
                RequestFailedDetailsParser = new TextAnalyticsFailedDetailsParser()
            });
            _languageRestClient = new MicrosoftCognitiveLanguageServiceTextAnalysisRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri, serviceVersion);
        }

        public LanguageServiceClient(Uri endpoint, AzureKeyCredential credential, string serviceVersion, TextAnalyticsClientOptions options)
            : base(options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            Argument.AssertNotNullOrEmpty(serviceVersion, nameof(serviceVersion));

            _baseUri = endpoint;
            _clientDiagnostics = new ClientDiagnostics(options);

            var pipeline = HttpPipelineBuilder.Build(new HttpPipelineOptions(options)
            {
                PerRetryPolicies = { new AzureKeyCredentialPolicy(credential, Constants.AuthorizationHeader) },
                RequestFailedDetailsParser = new TextAnalyticsFailedDetailsParser()
            });
            _languageRestClient = new MicrosoftCognitiveLanguageServiceTextAnalysisRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri, serviceVersion);
        }

        #region Detect Language

        public override async Task<Response<DetectedLanguage>> DetectLanguageAsync(string document, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguage)}");
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
                    throw new RequestFailedException(response);
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
                    throw new RequestFailedException(response);
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
            LanguageDetectionAnalysisInput detectLanguageInputs = DocumentsToLanguageDetection(documents, countryHint);

            return await DetectLanguageBatchAsync(detectLanguageInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<DetectLanguageResultCollection> DetectLanguageBatch(IEnumerable<string> documents, string countryHint = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            LanguageDetectionAnalysisInput detectLanguageInputs = DocumentsToLanguageDetection(documents, countryHint);
            return DetectLanguageBatch(detectLanguageInputs, options, cancellationToken);
        }

        public override async Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(IEnumerable<DetectLanguageInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            LanguageDetectionAnalysisInput detectLanguageInputs = LanguageInputToLanguageDetection(documents);

            return await DetectLanguageBatchAsync(detectLanguageInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<DetectLanguageResultCollection> DetectLanguageBatch(IEnumerable<DetectLanguageInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            LanguageDetectionAnalysisInput detectLanguageInputs = LanguageInputToLanguageDetection(documents);

            return DetectLanguageBatch(detectLanguageInputs, options, cancellationToken);
        }

        private async Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(LanguageDetectionAnalysisInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            options ??= new();

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
            options ??= new();

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
            scope.Start();

            try
            {
                MultiLanguageAnalysisInput analysisInput = new();
                analysisInput.Documents.Add(ConvertToMultiLanguageInput(document, language));

                AnalyzeTextEntityRecognitionInput input = new()
                {
                    AnalysisInput = analysisInput,
                    Parameters = new EntitiesTaskParameters() { StringIndexType = Constants.DefaultStringIndexType }
                };

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(
                    input,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var entityRecognition = (EntitiesTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (entityRecognition.Results.Errors.Count > 0)
                {
                    throw new RequestFailedException(response);
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
            scope.Start();

            try
            {
                MultiLanguageAnalysisInput analysisInput = new();
                analysisInput.Documents.Add(ConvertToMultiLanguageInput(document, language));

                AnalyzeTextEntityRecognitionInput input = new()
                {
                    AnalysisInput = analysisInput,
                    Parameters = new EntitiesTaskParameters() { StringIndexType = Constants.DefaultStringIndexType }
                };

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(
                    input,
                    cancellationToken: cancellationToken);

                var entityRecognition = (EntitiesTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (entityRecognition.Results.Errors.Count > 0)
                {
                    throw new RequestFailedException(response);
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
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizeEntitiesBatchAsync(input, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return RecognizeEntitiesBatch(input, options, cancellationToken);
        }

        public override async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return await RecognizeEntitiesBatchAsync(input, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return RecognizeEntitiesBatch(input, options, cancellationToken);
        }

        private async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(MultiLanguageAnalysisInput multiLanguageInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            options ??= new();

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
            options ??= new();

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
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                var input = new MultiLanguageAnalysisInput();
                foreach (var doc in documents)
                {
                    input.Documents.Add(doc);
                }

                AnalyzeTextPiiEntitiesRecognitionInput analyzePiiEntities = new()
                {
                    AnalysisInput = input,
                    Parameters = PiiEntitiesParameters(options)
                };

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(analyzePiiEntities, cancellationToken: cancellationToken).ConfigureAwait(false);

                var piiEntities = (PiiTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (piiEntities.Results.Errors.Count > 0)
                {
                    throw new RequestFailedException(response);
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
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                var input = new MultiLanguageAnalysisInput();
                foreach (var doc in documents)
                {
                    input.Documents.Add(doc);
                }

                AnalyzeTextPiiEntitiesRecognitionInput analyzePiiEntities = new()
                {
                    AnalysisInput = input,
                    Parameters = PiiEntitiesParameters(options)
                };

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(analyzePiiEntities, cancellationToken: cancellationToken);
                var piiEntities = (PiiTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (piiEntities.Results.Errors.Count > 0)
                {
                    throw new RequestFailedException(response);
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
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizePiiEntitiesBatchAsync(input, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(IEnumerable<string> documents, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return RecognizePiiEntitiesBatch(input, options, cancellationToken);
        }

        public override async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return await RecognizePiiEntitiesBatchAsync(input, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(IEnumerable<TextDocumentInput> documents, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return RecognizePiiEntitiesBatch(input, options, cancellationToken);
        }

        private async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(MultiLanguageAnalysisInput multiLanguageInput, RecognizePiiEntitiesOptions options, CancellationToken cancellationToken)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntitiesBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextPiiEntitiesRecognitionInput input = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = PiiEntitiesParameters(options)
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
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntitiesBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextPiiEntitiesRecognitionInput input = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = PiiEntitiesParameters(options)
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

        private static PiiTaskParameters PiiEntitiesParameters(RecognizePiiEntitiesOptions options)
        {
            PiiTaskParameters parameters = new()
            {
                LoggingOptOut = options.DisableServiceLogs,
                ModelVersion = options.ModelVersion,
                Domain = options.DomainFilter.GetString() ?? (PiiDomain?)null,
                StringIndexType = Constants.DefaultStringIndexType
            };

            if (options.CategoriesFilter.Count > 0)
            {
                parameters.PiiCategories = options.CategoriesFilter;
            }
            return parameters;
        }

        #endregion

        #region Recognize Custom Entities

        public override RecognizeCustomEntitiesOperation RecognizeCustomEntities(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(RecognizeCustomEntities)}";

            return RecognizeCustomEntities(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken);
        }

        public override RecognizeCustomEntitiesOperation RecognizeCustomEntities(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(RecognizeCustomEntities)}";

            return RecognizeCustomEntities(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken);
        }

        public override async Task<RecognizeCustomEntitiesOperation> RecognizeCustomEntitiesAsync(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(RecognizeCustomEntities)}";

            return await RecognizeCustomEntitiesAsync(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<RecognizeCustomEntitiesOperation> RecognizeCustomEntitiesAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(RecognizeCustomEntities)}";

            return await RecognizeCustomEntitiesAsync(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        public override RecognizeCustomEntitiesOperation StartRecognizeCustomEntities(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartRecognizeCustomEntities)}";

            return RecognizeCustomEntities(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken);
        }

        public override RecognizeCustomEntitiesOperation StartRecognizeCustomEntities(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartRecognizeCustomEntities)}";

            return RecognizeCustomEntities(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken);
        }

        public override async Task<RecognizeCustomEntitiesOperation> StartRecognizeCustomEntitiesAsync(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartRecognizeCustomEntities)}";

            return await RecognizeCustomEntitiesAsync(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<RecognizeCustomEntitiesOperation> StartRecognizeCustomEntitiesAsync(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartRecognizeCustomEntities)}";

            return await RecognizeCustomEntitiesAsync(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        private static CustomEntitiesLROTask CreateCustomEntitiesTask(string projectName, string deploymentName, RecognizeCustomEntitiesOptions options)
        {
            return new CustomEntitiesLROTask()
            {
                Parameters = new CustomEntitiesTaskParameters(projectName, deploymentName)
                {
                    StringIndexType = Constants.DefaultStringIndexType,
                    LoggingOptOut = options.DisableServiceLogs,
                }
            };
        }

        private RecognizeCustomEntitiesOperation RecognizeCustomEntities(string scopeName, WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options, CancellationToken cancellationToken)
        {
            options ??= new RecognizeCustomEntitiesOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(scopeName);
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateCustomEntitiesTask(projectName, deploymentName, options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = _languageRestClient.AnalyzeBatchSubmitJob(input, cancellationToken);

                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new RecognizeCustomEntitiesOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<RecognizeCustomEntitiesOperation> RecognizeCustomEntitiesAsync(string scopeName, WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, string projectName, string deploymentName, RecognizeCustomEntitiesOptions options, CancellationToken cancellationToken)
        {
            options ??= new RecognizeCustomEntitiesOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(scopeName);
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateCustomEntitiesTask(projectName, deploymentName, options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = await _languageRestClient.AnalyzeBatchSubmitJobAsync(input, cancellationToken).ConfigureAwait(false);

                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new RecognizeCustomEntitiesOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
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
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.Start();

            try
            {
                MultiLanguageAnalysisInput analysisInput = new();
                analysisInput.Documents.Add(ConvertToMultiLanguageInput(document, language));

                AnalyzeTextSentimentAnalysisInput analyzePiiEntities = new()
                {
                    AnalysisInput = analysisInput,
                    Parameters = AnalyzeSentimentParameters(options)
                };

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(analyzePiiEntities, cancellationToken: cancellationToken).ConfigureAwait(false);

                var sentimentResult = (SentimentTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (sentimentResult.Results.Errors.Count > 0)
                {
                    throw new RequestFailedException(response);
                }

                return Response.FromValue(new DocumentSentiment(sentimentResult.Results.Documents[0]), response);
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
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.Start();

            try
            {
                MultiLanguageAnalysisInput analysisInput = new();
                analysisInput.Documents.Add(ConvertToMultiLanguageInput(document, language));

                AnalyzeTextSentimentAnalysisInput analyzePiiEntities = new()
                {
                    AnalysisInput = analysisInput,
                    Parameters = AnalyzeSentimentParameters(options)
                };

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(analyzePiiEntities, cancellationToken: cancellationToken);

                var sentimentResult = (SentimentTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (sentimentResult.Results.Errors.Count > 0)
                {
                    throw new RequestFailedException(response);
                }

                return Response.FromValue(new DocumentSentiment(sentimentResult.Results.Documents[0]), response);
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
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await AnalyzeSentimentBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<string> documents, string language = default, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return AnalyzeSentimentBatch(documentInputs, options, cancellationToken);
        }

        public override async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<TextDocumentInput> documents, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await AnalyzeSentimentBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<TextDocumentInput> documents, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return AnalyzeSentimentBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(MultiLanguageAnalysisInput multiLanguageInput, AnalyzeSentimentOptions options, CancellationToken cancellationToken)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentimentBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextSentimentAnalysisInput analyzeSentiment = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = AnalyzeSentimentParameters(options)
                };

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(
                    analyzeSentiment,
                    options.IncludeStatistics,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var sentimentResult = (SentimentTaskResult)result.Value;
                Response response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(multiLanguageInput.Documents);
                AnalyzeSentimentResultCollection results = Transforms.ConvertToAnalyzeSentimentResultCollection(sentimentResult.Results, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(MultiLanguageAnalysisInput multiLanguageInput, AnalyzeSentimentOptions options, CancellationToken cancellationToken)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentimentBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextSentimentAnalysisInput analyzeSentiment = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = AnalyzeSentimentParameters(options)
                };

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(
                    analyzeSentiment,
                    options.IncludeStatistics,
                    cancellationToken: cancellationToken);

                var sentimentResult = (SentimentTaskResult)result.Value;
                Response response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(multiLanguageInput.Documents);
                AnalyzeSentimentResultCollection results = Transforms.ConvertToAnalyzeSentimentResultCollection(sentimentResult.Results, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static SentimentAnalysisTaskParameters AnalyzeSentimentParameters(AnalyzeSentimentOptions options)
        {
            return new SentimentAnalysisTaskParameters()
            {
                LoggingOptOut = options.DisableServiceLogs,
                ModelVersion = options.ModelVersion,
                OpinionMining = options.IncludeOpinionMining,
                StringIndexType = Constants.DefaultStringIndexType
            };
        }

        #endregion

        #region Extract Key Phrases

        public override async Task<Response<KeyPhraseCollection>> ExtractKeyPhrasesAsync(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            scope.Start();

            try
            {
                MultiLanguageAnalysisInput analysisInput = new();
                analysisInput.Documents.Add(ConvertToMultiLanguageInput(document, language));

                var input = new AnalyzeTextKeyPhraseExtractionInput { AnalysisInput = analysisInput };

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(
                    input,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var keyPhrases = (KeyPhraseTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (keyPhrases.Results.Errors.Count > 0)
                {
                    throw new RequestFailedException(response);
                }

                return Response.FromValue(Transforms.ConvertToKeyPhraseCollection(keyPhrases.Results.Documents[0]), response);
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
            scope.Start();

            try
            {
                MultiLanguageAnalysisInput analysisInput = new();
                analysisInput.Documents.Add(ConvertToMultiLanguageInput(document, language));

                var input = new AnalyzeTextKeyPhraseExtractionInput { AnalysisInput = analysisInput };

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(
                    input,
                    cancellationToken: cancellationToken);

                var keyPhrases = (KeyPhraseTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (keyPhrases.Results.Errors.Count > 0)
                {
                    throw new RequestFailedException(response);
                }

                return Response.FromValue(Transforms.ConvertToKeyPhraseCollection(keyPhrases.Results.Documents[0]), response);
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
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await ExtractKeyPhrasesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return ExtractKeyPhrasesBatch(documentInputs, options, cancellationToken);
        }

        public override async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await ExtractKeyPhrasesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return ExtractKeyPhrasesBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(MultiLanguageAnalysisInput multiLanguageInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrasesBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextKeyPhraseExtractionInput input = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = new KeyPhraseTaskParameters(options.DisableServiceLogs, options.ModelVersion)
                };

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(
                    input,
                    options.IncludeStatistics,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var keyPhrases = (KeyPhraseTaskResult)result.Value;
                Response response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(multiLanguageInput.Documents);
                ExtractKeyPhrasesResultCollection results = Transforms.ConvertToExtractKeyPhrasesResultCollection(keyPhrases.Results, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(MultiLanguageAnalysisInput multiLanguageInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrasesBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextKeyPhraseExtractionInput input = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = new KeyPhraseTaskParameters(options.DisableServiceLogs, options.ModelVersion)
                };

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(
                    input,
                    options.IncludeStatistics,
                    cancellationToken: cancellationToken);

                var keyPhrases = (KeyPhraseTaskResult)result.Value;
                Response response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(multiLanguageInput.Documents);
                ExtractKeyPhrasesResultCollection results = Transforms.ConvertToExtractKeyPhrasesResultCollection(keyPhrases.Results, map);
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
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                var input = new MultiLanguageAnalysisInput();
                foreach (var doc in documents)
                {
                    input.Documents.Add(doc);
                }
                AnalyzeTextEntityLinkingInput analyzeRecognizeLinkedEntities = new()
                {
                    AnalysisInput = input,
                    Parameters = new EntityLinkingTaskParameters() { StringIndexType = Constants.DefaultStringIndexType }
                };
                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(
                    analyzeRecognizeLinkedEntities,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var linkedEntities = (EntityLinkingTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (linkedEntities.Results.Errors.Count > 0)
                {
                    throw new RequestFailedException(response);
                }
                return Response.FromValue(Transforms.ConvertToLinkedEntityCollection(linkedEntities.Results.Documents.FirstOrDefault()), response);
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
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                var input = new MultiLanguageAnalysisInput();
                foreach (var doc in documents)
                {
                    input.Documents.Add(doc);
                }
                AnalyzeTextEntityLinkingInput analyzeRecognizeLinkedEntities = new()
                {
                    AnalysisInput = input,
                    Parameters = new EntityLinkingTaskParameters() { StringIndexType = Constants.DefaultStringIndexType }
                };
                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(
                    analyzeRecognizeLinkedEntities,
                    cancellationToken: cancellationToken);

                var linkedEntities = (EntityLinkingTaskResult)result.Value;
                Response response = result.GetRawResponse();

                if (linkedEntities.Results.Errors.Count > 0)
                {
                    throw new RequestFailedException(response);
                }
                return Response.FromValue(Transforms.ConvertToLinkedEntityCollection(linkedEntities.Results.Documents.FirstOrDefault()), response);
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
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizeLinkedEntitiesBatchAsync(input, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return RecognizeLinkedEntitiesBatch(input, options, cancellationToken);
        }

        public override async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return await RecognizeLinkedEntitiesBatchAsync(input, options, cancellationToken).ConfigureAwait(false);
        }

        public override Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return RecognizeLinkedEntitiesBatch(input, options, cancellationToken);
        }

        private async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(MultiLanguageAnalysisInput multiLanguageInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntitiesBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextEntityLinkingInput input = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = new EntityLinkingTaskParameters(
                                        options.DisableServiceLogs,
                                        options.ModelVersion,
                                        Constants.DefaultStringIndexType)
                };

                Response<AnalyzeTextTaskResult> result = await _languageRestClient.AnalyzeAsync(
                    input,
                    options.IncludeStatistics,
                    cancellationToken: cancellationToken).ConfigureAwait(false);

                var linkedEntities = (EntityLinkingTaskResult)result.Value;
                Response response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(multiLanguageInput.Documents);
                RecognizeLinkedEntitiesResultCollection results = Transforms.ConvertToLinkedEntitiesResultCollection(linkedEntities.Results, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(MultiLanguageAnalysisInput multiLanguageInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntitiesBatch)}");
            scope.Start();

            try
            {
                AnalyzeTextEntityLinkingInput input = new()
                {
                    AnalysisInput = multiLanguageInput,
                    Parameters = new EntityLinkingTaskParameters(
                                        options.DisableServiceLogs,
                                        options.ModelVersion,
                                        Constants.DefaultStringIndexType)
                };

                Response<AnalyzeTextTaskResult> result = _languageRestClient.Analyze(
                    input,
                    options.IncludeStatistics,
                    cancellationToken: cancellationToken);

                var linkedEntities = (EntityLinkingTaskResult)result.Value;
                Response response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(multiLanguageInput.Documents);
                RecognizeLinkedEntitiesResultCollection results = Transforms.ConvertToLinkedEntitiesResultCollection(linkedEntities.Results, map);
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

        public override AnalyzeHealthcareEntitiesOperation AnalyzeHealthcareEntities(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeHealthcareEntities)}";

            return AnalyzeHealthcareEntities(scopeName, waitUntil, documentInputs, options, cancellationToken);
        }

        public override AnalyzeHealthcareEntitiesOperation AnalyzeHealthcareEntities(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeHealthcareEntities)}";

            return AnalyzeHealthcareEntities(scopeName, waitUntil, documentInputs, options, cancellationToken);
        }

        public override async Task<AnalyzeHealthcareEntitiesOperation> AnalyzeHealthcareEntitiesAsync(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeHealthcareEntities)}";

            return await AnalyzeHealthcareEntitiesAsync(scopeName, waitUntil, documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<AnalyzeHealthcareEntitiesOperation> AnalyzeHealthcareEntitiesAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeHealthcareEntities)}";

            return await AnalyzeHealthcareEntitiesAsync(scopeName, waitUntil, documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeHealthcareEntities)}";

            return await AnalyzeHealthcareEntitiesAsync(scopeName, WaitUntil.Started, documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        public override AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(IEnumerable<string> documents, string language = default, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeHealthcareEntities)}";

            return AnalyzeHealthcareEntities(scopeName, WaitUntil.Started, documentInputs, options, cancellationToken);
        }

        public override AnalyzeHealthcareEntitiesOperation StartAnalyzeHealthcareEntities(IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeHealthcareEntities)}";

            return AnalyzeHealthcareEntities(scopeName, WaitUntil.Started, documentInputs, options, cancellationToken);
        }

        public override async Task<AnalyzeHealthcareEntitiesOperation> StartAnalyzeHealthcareEntitiesAsync(IEnumerable<TextDocumentInput> documents, AnalyzeHealthcareEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(documents, nameof(documents));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeHealthcareEntities)}";

            return await AnalyzeHealthcareEntitiesAsync(scopeName, WaitUntil.Started, documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        private static HealthcareLROTask CreateHealthcareTask(AnalyzeHealthcareEntitiesOptions options)
        {
            return new HealthcareLROTask()
            {
                Parameters = new HealthcareTaskParameters()
                {
                    ModelVersion = options.ModelVersion,
                    StringIndexType = Constants.DefaultStringIndexType,
                    LoggingOptOut = options.DisableServiceLogs,
                }
            };
        }

        private AnalyzeHealthcareEntitiesOperation AnalyzeHealthcareEntities(string scopeName, WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, AnalyzeHealthcareEntitiesOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(scopeName);
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateHealthcareTask(options) } )
                {
                    DisplayName = options.DisplayName,
                };

                var response = _languageRestClient.AnalyzeBatchSubmitJob(input, cancellationToken);

                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new AnalyzeHealthcareEntitiesOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<AnalyzeHealthcareEntitiesOperation> AnalyzeHealthcareEntitiesAsync(string scopeName, WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, AnalyzeHealthcareEntitiesOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(scopeName);
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateHealthcareTask(options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = await _languageRestClient.AnalyzeBatchSubmitJobAsync(input, cancellationToken).ConfigureAwait(false);

                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new AnalyzeHealthcareEntitiesOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<HealthcareJobStatusResult>> HealthStatusAsync(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            if (!Guid.TryParse(jobId, out var id))
            {
                throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(HealthStatusAsync)}");
            scope.Start();

            try
            {
                var result = await _languageRestClient.AnalyzeBatchJobStatusAsync(id, showStats, top, skip, cancellationToken).ConfigureAwait(false);
                var status = Transforms.ConvertToHealthcareJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<HealthcareJobStatusResult> HealthStatus(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            if (!Guid.TryParse(jobId, out var id))
            {
                throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(HealthStatusAsync)}");
            scope.Start();

            try
            {
                var result = _languageRestClient.AnalyzeBatchJobStatus(id, showStats, top, skip, cancellationToken);
                var status = Transforms.ConvertToHealthcareJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<HealthcareJobStatusResult>> HealthStatusNextPageAsync(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeStatusNextPage)}");
            scope.Start();

            try
            {
                var result = await _languageRestClient.AnalyzeBatchNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                var status = Transforms.ConvertToHealthcareJobStatusResult(result.Value, idToIndexMap);

                return Response.FromValue(status, result.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<HealthcareJobStatusResult> HealthStatusNextPage(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeStatusNextPage)}");
            scope.Start();

            try
            {
                var result = _languageRestClient.AnalyzeBatchNextPage(nextLink, cancellationToken);
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

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(CancelHealthcareJobAsync)}");
            scope.Start();

            try
            {
                await _languageRestClient.AnalyzeBatchCancelJobAsync(id, cancellationToken).ConfigureAwait(false);
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
                    _languageRestClient.AnalyzeBatchCancelJob(id, cancellationToken);
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

        public override AnalyzeActionsOperation AnalyzeActions(WaitUntil waitUntil, IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeActions)}";

            return AnalyzeActions(scopeName, waitUntil, documentInputs, actions, options, cancellationToken);
        }

        public override AnalyzeActionsOperation AnalyzeActions(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeActions)}";

            return AnalyzeActions(scopeName, waitUntil, documentInputs, actions, options, cancellationToken);
        }

        public override async Task<AnalyzeActionsOperation> AnalyzeActionsAsync(WaitUntil waitUntil, IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeActions)}";

            return await AnalyzeActionsAsync(scopeName, waitUntil, documentInputs, actions, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<AnalyzeActionsOperation> AnalyzeActionsAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeActions)}";

            return await AnalyzeActionsAsync(scopeName, waitUntil, documentInputs, actions, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<AnalyzeActionsOperation> StartAnalyzeActionsAsync(IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeActions)}";

            return await AnalyzeActionsAsync(scopeName, WaitUntil.Started, documentInputs, actions, options, cancellationToken).ConfigureAwait(false);
        }

        public override AnalyzeActionsOperation StartAnalyzeActions(IEnumerable<string> documents, TextAnalyticsActions actions, string language = default, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeActions)}";

            return AnalyzeActions(scopeName, WaitUntil.Started, documentInputs, actions, options, cancellationToken);
        }

        public override AnalyzeActionsOperation StartAnalyzeActions(IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeActions)}";

            return AnalyzeActions(scopeName, WaitUntil.Started, documentInputs, actions, options, cancellationToken);
        }

        public override async Task<AnalyzeActionsOperation> StartAnalyzeActionsAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(actions, nameof(actions));
            MultiLanguageAnalysisInput documentInputs = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeActions)}";

            return await AnalyzeActionsAsync(scopeName, WaitUntil.Started, documentInputs, actions, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<Response<AnalyzeTextJobStatusResult>> AnalyzeStatusAsync(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            // Issue https://github.com/Azure/azure-sdk-for-net/issues/28355
            if (!Guid.TryParse(jobId, out var id))
            {
                throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeStatus)}");
            scope.Start();

            try
            {
                var response = await _languageRestClient.AnalyzeBatchJobStatusAsync(id, showStats, top, skip, cancellationToken).ConfigureAwait(false);
                var result = Transforms.ConvertToAnalyzeTextJobStatusResult(response.Value, idToIndexMap);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<AnalyzeTextJobStatusResult> AnalyzeStatus(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            if (!Guid.TryParse(jobId, out var id))
            {
                throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeStatus)}");
            scope.Start();

            try
            {
                var response = _languageRestClient.AnalyzeBatchJobStatus(id, showStats, top, skip, cancellationToken);
                var result = Transforms.ConvertToAnalyzeTextJobStatusResult(response.Value, idToIndexMap);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<AnalyzeTextJobStatusResult>> AnalyzeStatusNextPageAsync(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeStatusNextPage)}");
            scope.Start();

            try
            {
                var response = await _languageRestClient.AnalyzeBatchNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
                var result = Transforms.ConvertToAnalyzeTextJobStatusResult(response.Value, idToIndexMap);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<AnalyzeTextJobStatusResult> AnalyzeStatusNextPage(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeStatusNextPage)}");
            scope.Start();

            try
            {
                var response = _languageRestClient.AnalyzeBatchNextPage(nextLink, cancellationToken);
                var result = Transforms.ConvertToAnalyzeTextJobStatusResult(response.Value, idToIndexMap);

                return Response.FromValue(result, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private AnalyzeActionsOperation AnalyzeActions(string scopeName, WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(scopeName);
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, CreateTasks(actions))
                {
                    DisplayName = actions.DisplayName,
                };

                var response = _languageRestClient.AnalyzeBatchSubmitJob(input, cancellationToken);

                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new AnalyzeActionsOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<AnalyzeActionsOperation> AnalyzeActionsAsync(string scopeName, WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, TextAnalyticsActions actions, AnalyzeActionsOptions options = default, CancellationToken cancellationToken = default)
        {
            options ??= new();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(scopeName);
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, CreateTasks(actions))
                {
                    DisplayName = actions.DisplayName,
                };

                var response = await _languageRestClient.AnalyzeBatchSubmitJobAsync(input, cancellationToken).ConfigureAwait(false);

                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new AnalyzeActionsOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task CancelAnalyzeActionsJobAsync(string jobId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            if (!Guid.TryParse(jobId, out var id))
            {
                throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(CancelAnalyzeActionsJob)}");
            scope.Start();

            try
            {
                await _languageRestClient.AnalyzeBatchCancelJobAsync(id, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override void CancelAnalyzeActionsJob(string jobId, CancellationToken cancellationToken = default)
        {
            {
                Argument.AssertNotNull(jobId, nameof(jobId));

                if (!Guid.TryParse(jobId, out var id))
                {
                    throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
                }

                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(CancelAnalyzeActionsJob)}");
                scope.Start();

                try
                {
                    _languageRestClient.AnalyzeBatchCancelJob(id, cancellationToken);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
        }

        private IList<AnalyzeTextLROTask> CreateTasks(TextAnalyticsActions actions)
        {
            List<AnalyzeTextLROTask> analyzeTasks = new();

            if (actions.RecognizePiiEntitiesActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromRecognizePiiEntitiesActionsToTasks(actions.RecognizePiiEntitiesActions));
            }
            if (actions.RecognizeEntitiesActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromRecognizeEntitiesActionsToTasks(actions.RecognizeEntitiesActions));
            }
            if (actions.RecognizeCustomEntitiesActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromRecognizeCustomEntitiesActionsToTasks(actions.RecognizeCustomEntitiesActions));
            }
            if (actions.ExtractKeyPhrasesActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromExtractKeyPhrasesActionsToTasks(actions.ExtractKeyPhrasesActions));
            }
            if (actions.RecognizeLinkedEntitiesActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromRecognizeLinkedEntitiesActionsToTasks(actions.RecognizeLinkedEntitiesActions));
            }
            if (actions.AnalyzeSentimentActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromAnalyzeSentimentActionsToTasks(actions.AnalyzeSentimentActions));
            }
            if (actions.SingleLabelClassifyActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromSingleLabelClassifyActionsToTasks(actions.SingleLabelClassifyActions));
            }
            if (actions.MultiLabelClassifyActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromMultiLabelClassifyActionsToTasks(actions.MultiLabelClassifyActions));
            }
            if (actions.AnalyzeHealthcareEntitiesActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromAnalyzeHealthcareEntitiesActionsToTasks(actions.AnalyzeHealthcareEntitiesActions));
            }
            if (actions.ExtractiveSummarizeActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromExtractiveSummarizeActionsToTasks(actions.ExtractiveSummarizeActions));
            }
            if (actions.AbstractiveSummarizeActions != null)
            {
                analyzeTasks.AddRange(Transforms.ConvertFromAbstractiveSummarizeActionsToTasks(actions.AbstractiveSummarizeActions));
            }

            // Validate supported version.
            if (actions.ExtractiveSummarizeActions != null && actions.ExtractiveSummarizeActions.Count > 0)
            {
                Validation.SupportsOperation(nameof(ExtractiveSummarizeAction), TextAnalyticsClientOptions.ServiceVersion.V2023_04_01, ServiceVersion);
            }
            if (actions.AbstractiveSummarizeActions != null && actions.AbstractiveSummarizeActions.Count > 0)
            {
                Validation.SupportsOperation(nameof(AbstractiveSummarizeAction), TextAnalyticsClientOptions.ServiceVersion.V2023_04_01, ServiceVersion);
            }

            return analyzeTasks;
        }

        #endregion

        #region Single Label Classify

        public override ClassifyDocumentOperation SingleLabelClassify(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(SingleLabelClassify)}";

            return SingleLabelClassify(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken);
        }

        public override ClassifyDocumentOperation SingleLabelClassify(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(SingleLabelClassify)}";

            return SingleLabelClassify(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken);
        }

        public override async Task<ClassifyDocumentOperation> SingleLabelClassifyAsync(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(SingleLabelClassify)}";

            return await SingleLabelClassifyAsync(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<ClassifyDocumentOperation> SingleLabelClassifyAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(SingleLabelClassify)}";

            return await SingleLabelClassifyAsync(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        public override ClassifyDocumentOperation StartSingleLabelClassify(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartSingleLabelClassify)}";

            return SingleLabelClassify(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken);
        }

        public override ClassifyDocumentOperation StartSingleLabelClassify(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartSingleLabelClassify)}";

            return SingleLabelClassify(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken);
        }

        public override async Task<ClassifyDocumentOperation> StartSingleLabelClassifyAsync(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartSingleLabelClassify)}";

            return await SingleLabelClassifyAsync(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<ClassifyDocumentOperation> StartSingleLabelClassifyAsync(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, SingleLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartSingleLabelClassify)}";

            return await SingleLabelClassifyAsync(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        private static CustomSingleLabelClassificationLROTask CreateCustomSingleLabelClassificationTask(string projectName, string deploymentName, SingleLabelClassifyOptions options)
        {
            return new CustomSingleLabelClassificationLROTask()
            {
                Parameters = new CustomSingleLabelClassificationTaskParameters(projectName, deploymentName)
                {
                    LoggingOptOut = options.DisableServiceLogs,
                }
            };
        }

        private ClassifyDocumentOperation SingleLabelClassify(string scopeName, WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, string projectName, string deploymentName, SingleLabelClassifyOptions options, CancellationToken cancellationToken)
        {
            options ??= new SingleLabelClassifyOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(scopeName);
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateCustomSingleLabelClassificationTask(projectName, deploymentName, options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = _languageRestClient.AnalyzeBatchSubmitJob(input, cancellationToken);

                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new ClassifyDocumentOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<ClassifyDocumentOperation> SingleLabelClassifyAsync(string scopeName, WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, string projectName, string deploymentName, SingleLabelClassifyOptions options, CancellationToken cancellationToken)
        {
            options ??= new SingleLabelClassifyOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(scopeName);
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateCustomSingleLabelClassificationTask(projectName, deploymentName, options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = await _languageRestClient.AnalyzeBatchSubmitJobAsync(input, cancellationToken).ConfigureAwait(false);

                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new ClassifyDocumentOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Multi Label Classify

        public override ClassifyDocumentOperation MultiLabelClassify(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(MultiLabelClassify)}";

            return MultiLabelClassify(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken);
        }

        public override ClassifyDocumentOperation MultiLabelClassify(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(MultiLabelClassify)}";

            return MultiLabelClassify(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken);
        }

        public override async Task<ClassifyDocumentOperation> MultiLabelClassifyAsync(WaitUntil waitUntil, IEnumerable<string> documents, string projectName, string deploymentName, string language = default, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(MultiLabelClassify)}";

            return await MultiLabelClassifyAsync(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<ClassifyDocumentOperation> MultiLabelClassifyAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(MultiLabelClassify)}";

            return await MultiLabelClassifyAsync(scopeName, waitUntil, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        public override ClassifyDocumentOperation StartMultiLabelClassify(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartMultiLabelClassify)}";

            return MultiLabelClassify(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken);
        }

        public override ClassifyDocumentOperation StartMultiLabelClassify(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartMultiLabelClassify)}";

            return MultiLabelClassify(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken);
        }

        public override async Task<ClassifyDocumentOperation> StartMultiLabelClassifyAsync(IEnumerable<string> documents, string projectName, string deploymentName, string language = default, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartMultiLabelClassify)}";

            return await MultiLabelClassifyAsync(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<ClassifyDocumentOperation> StartMultiLabelClassifyAsync(IEnumerable<TextDocumentInput> documents, string projectName, string deploymentName, MultiLabelClassifyOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);
            string scopeName = $"{nameof(TextAnalyticsClient)}.{nameof(StartMultiLabelClassify)}";

            return await MultiLabelClassifyAsync(scopeName, WaitUntil.Started, input, projectName, deploymentName, options, cancellationToken).ConfigureAwait(false);
        }

        private static CustomMultiLabelClassificationLROTask CreateCustomMultiLabelClassificationTask(string projectName, string deploymentName, MultiLabelClassifyOptions options)
        {
            return new CustomMultiLabelClassificationLROTask()
            {
                Parameters = new CustomMultiLabelClassificationTaskParameters(projectName, deploymentName)
                {
                    LoggingOptOut = options.DisableServiceLogs,
                }
            };
        }

        private ClassifyDocumentOperation MultiLabelClassify(string scopeName, WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, string projectName, string deploymentName, MultiLabelClassifyOptions options, CancellationToken cancellationToken)
        {
            options ??= new MultiLabelClassifyOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(scopeName);
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateCustomMultiLabelClassificationTask(projectName, deploymentName, options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = _languageRestClient.AnalyzeBatchSubmitJob(input, cancellationToken);

                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new ClassifyDocumentOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<ClassifyDocumentOperation> MultiLabelClassifyAsync(string scopeName, WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, string projectName, string deploymentName, MultiLabelClassifyOptions options, CancellationToken cancellationToken)
        {
            options ??= new MultiLabelClassifyOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope(scopeName);
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateCustomMultiLabelClassificationTask(projectName, deploymentName, options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = await _languageRestClient.AnalyzeBatchSubmitJobAsync(input, cancellationToken).ConfigureAwait(false);

                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new ClassifyDocumentOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Extractive Summarize

        public override ExtractiveSummarizeOperation ExtractiveSummarize(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, ExtractiveSummarizeOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return ExtractiveSummarize(waitUntil, input, options, cancellationToken);
        }

        public override ExtractiveSummarizeOperation ExtractiveSummarize(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, ExtractiveSummarizeOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return ExtractiveSummarize(waitUntil, input, options, cancellationToken);
        }

        public override async Task<ExtractiveSummarizeOperation> ExtractiveSummarizeAsync(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, ExtractiveSummarizeOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return await ExtractiveSummarizeAsync(waitUntil, input, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<ExtractiveSummarizeOperation> ExtractiveSummarizeAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, ExtractiveSummarizeOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return await ExtractiveSummarizeAsync(waitUntil, input, options, cancellationToken).ConfigureAwait(false);
        }

        private static ExtractiveSummarizationLROTask CreateExtractiveSummarizationTask(ExtractiveSummarizeOptions options)
        {
            return new ExtractiveSummarizationLROTask()
            {
                Parameters = new ExtractiveSummarizationTaskParameters()
                {
                    ModelVersion = options.ModelVersion,
                    StringIndexType = Constants.DefaultStringIndexType,
                    LoggingOptOut = options.DisableServiceLogs,
                    SentenceCount = options.MaxSentenceCount,
                    SortBy = options.OrderBy,
                }
            };
        }

        private ExtractiveSummarizeOperation ExtractiveSummarize(WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, ExtractiveSummarizeOptions options, CancellationToken cancellationToken)
        {
            options ??= new ExtractiveSummarizeOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractiveSummarize)}");
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateExtractiveSummarizationTask(options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = _languageRestClient.AnalyzeBatchSubmitJob(input, cancellationToken);
                string location = response.Headers.OperationLocation;
                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new ExtractiveSummarizeOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<ExtractiveSummarizeOperation> ExtractiveSummarizeAsync(WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, ExtractiveSummarizeOptions options, CancellationToken cancellationToken)
        {
            options ??= new ExtractiveSummarizeOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractiveSummarize)}");
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateExtractiveSummarizationTask(options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = await _languageRestClient.AnalyzeBatchSubmitJobAsync(input, cancellationToken).ConfigureAwait(false);
                string location = response.Headers.OperationLocation;
                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new ExtractiveSummarizeOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Abstractive Summarize

        public override AbstractiveSummarizeOperation AbstractiveSummarize(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, AbstractiveSummarizeOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return AbstractiveSummarize(waitUntil, input, options, cancellationToken);
        }

        public override AbstractiveSummarizeOperation AbstractiveSummarize(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, AbstractiveSummarizeOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return AbstractiveSummarize(waitUntil, input, options, cancellationToken);
        }

        public override async Task<AbstractiveSummarizeOperation> AbstractiveSummarizeAsync(WaitUntil waitUntil, IEnumerable<string> documents, string language = default, AbstractiveSummarizeOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents, language);

            return await AbstractiveSummarizeAsync(waitUntil, input, options, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<AbstractiveSummarizeOperation> AbstractiveSummarizeAsync(WaitUntil waitUntil, IEnumerable<TextDocumentInput> documents, AbstractiveSummarizeOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            MultiLanguageAnalysisInput input = ConvertToMultiLanguageInputs(documents);

            return await AbstractiveSummarizeAsync(waitUntil, input, options, cancellationToken).ConfigureAwait(false);
        }

        private static AbstractiveSummarizationLROTask CreateAbstractiveSummarizationTask(AbstractiveSummarizeOptions options)
        {
            AbstractiveSummarizationTaskParameters parameters = new()
            {
                ModelVersion = options.ModelVersion,
                StringIndexType = Constants.DefaultStringIndexType,
                LoggingOptOut = options.DisableServiceLogs,
                SentenceCount = options.SentenceCount,
            };

            return new AbstractiveSummarizationLROTask(parameters);
        }

        private AbstractiveSummarizeOperation AbstractiveSummarize(WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, AbstractiveSummarizeOptions options, CancellationToken cancellationToken)
        {
            options ??= new AbstractiveSummarizeOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AbstractiveSummarize)}");
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateAbstractiveSummarizationTask(options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = _languageRestClient.AnalyzeBatchSubmitJob(input, cancellationToken);
                string location = response.Headers.OperationLocation;
                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new AbstractiveSummarizeOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<AbstractiveSummarizeOperation> AbstractiveSummarizeAsync(WaitUntil waitUntil, MultiLanguageAnalysisInput multiLanguageInput, AbstractiveSummarizeOptions options, CancellationToken cancellationToken)
        {
            options ??= new AbstractiveSummarizeOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AbstractiveSummarize)}");
            scope.Start();

            try
            {
                AnalyzeTextJobsInput input = new(multiLanguageInput, new List<AnalyzeTextLROTask>() { CreateAbstractiveSummarizationTask(options) })
                {
                    DisplayName = options.DisplayName,
                };

                var response = await _languageRestClient.AnalyzeBatchSubmitJobAsync(input, cancellationToken).ConfigureAwait(false);
                string location = response.Headers.OperationLocation;
                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(multiLanguageInput.Documents);

                var operation = new AbstractiveSummarizeOperation(this, _clientDiagnostics, location, idToIndexMap, options.IncludeStatistics);

                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }

                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Long Running Operations

        public override async Task<Response<AnalyzeTextJobState>> AnalyzeTextJobStatusAsync(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            // Issue https://github.com/Azure/azure-sdk-for-net/issues/28355
            if (!Guid.TryParse(jobId, out var id))
            {
                throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeTextJobStatus)}");
            scope.Start();

            try
            {
                return await _languageRestClient.AnalyzeBatchJobStatusAsync(id, showStats, top, skip, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<AnalyzeTextJobState> AnalyzeTextJobStatus(string jobId, bool? showStats, int? top, int? skip, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(jobId, nameof(jobId));

            if (!Guid.TryParse(jobId, out var id))
            {
                throw new FormatException($"{nameof(jobId)} is not a valid GUID.");
            }

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeTextJobStatus)}");
            scope.Start();

            try
            {
                return _languageRestClient.AnalyzeBatchJobStatus(id, showStats, top, skip, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override async Task<Response<AnalyzeTextJobState>> AnalyzeTextJobStatusNextPageAsync(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeTextJobStatusNextPage)}");
            scope.Start();

            try
            {
                return await _languageRestClient.AnalyzeBatchNextPageAsync(nextLink, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public override Response<AnalyzeTextJobState> AnalyzeTextJobStatusNextPage(string nextLink, int? pageSizeHint, IDictionary<string, int> idToIndexMap, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(nextLink, nameof(nextLink));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeTextJobStatusNextPage)}");
            scope.Start();

            try
            {
                return _languageRestClient.AnalyzeBatchNextPage(nextLink, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
            => new MultiLanguageInput(id.ToString(CultureInfo.InvariantCulture), document) { Language = language ?? Options.DefaultLanguage };

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
                input.Documents.Add(new MultiLanguageInput(document.Id, document.Text) { Language = document.Language ?? Options.DefaultLanguage });
            }
            return input;
        }

        private LanguageInput ConvertToLanguageInput(string document, string countryHint, int id = 0)
            => new LanguageInput($"{id}", document) { CountryHint = countryHint ?? Options.DefaultCountryHint };

        #endregion
    }
}
