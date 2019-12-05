// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The client to use for interacting with the Azure Configuration Store.
    /// </summary>
    public partial class TextAnalyticsClient
    {
        private readonly Uri _baseUri;
        private readonly HttpPipeline _pipeline;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly string _subscriptionKey;
        private readonly string _apiVersion;
        private readonly TextAnalyticsClientOptions _options;

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected TextAnalyticsClient()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"></param>
        public TextAnalyticsClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new TextAnalyticsClientOptions())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="credential"></param>
        /// <param name="options"></param>
        public TextAnalyticsClient(Uri endpoint, TokenCredential credential, TextAnalyticsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new TextAnalyticsClientOptions();

            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="subscriptionKey"></param>
        public TextAnalyticsClient(Uri endpoint, string subscriptionKey)
            : this(endpoint, subscriptionKey, new TextAnalyticsClientOptions())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="subscriptionKey"></param>
        /// <param name="options"></param>
        public TextAnalyticsClient(Uri endpoint, string subscriptionKey, TextAnalyticsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(subscriptionKey, nameof(subscriptionKey));
            Argument.AssertNotNull(options, nameof(options));

            _baseUri = endpoint;
            _subscriptionKey = subscriptionKey;
            _apiVersion = options.GetVersionString();
            _pipeline = HttpPipelineBuilder.Build(options);
            _clientDiagnostics = new ClientDiagnostics(options);
            _options = options;
        }

        #region Detect Language

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="countryHint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DetectLanguageResult>> DetectLanguageAsync(string inputText, string countryHint = default, CancellationToken cancellationToken = default)
        {
            // TODO: set countryHint from options.

            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguage");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(new string[] { inputText }, countryHint);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        DetectLanguageResultCollection result = await CreateDetectLanguageResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (result[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(result[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="countryHint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DetectLanguageResult> DetectLanguage(string inputText, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguage");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(new string[] { inputText }, countryHint);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        DetectLanguageResultCollection result = CreateDetectLanguageResponse(response);
                        if (result[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(result[0].ErrorMessage);
                        }
                        return Response.FromValue(result[0], response);
                    default:
                        throw response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="countryHint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DetectLanguageResultCollection>> DetectLanguagesAsync(IEnumerable<string> inputs, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<DetectLanguageInput> detectLanguageInputs = ConvertToDetectLanguageInputs(inputs, countryHint);
            return await DetectLanguagesAsync(detectLanguageInputs, new TextAnalysisOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="countryHint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DetectLanguageResultCollection> DetectLanguages(IEnumerable<string> inputs, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<DetectLanguageInput> detectLanguageInputs = ConvertToDetectLanguageInputs(inputs, countryHint);
            return DetectLanguages(detectLanguageInputs, new TextAnalysisOptions(), cancellationToken);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DetectLanguageResultCollection>> DetectLanguagesAsync(IEnumerable<DetectLanguageInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputs, options);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                return response.Status switch
                {
                    200 => await CreateDetectLanguageResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    _ => throw await response.CreateRequestFailedExceptionAsync(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DetectLanguageResultCollection> DetectLanguages(IEnumerable<DetectLanguageInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputs, options);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    200 => CreateDetectLanguageResponse(response),
                    _ => throw response.CreateRequestFailedException(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Request CreateDetectLanguageRequest(IEnumerable<string> inputs, string countryHint)
        {
            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDetectLanguageInputs(inputs, countryHint);

            request.Method = RequestMethod.Post;
            BuildUriForRoute(LanguagesRoute, request.Uri, new TextAnalysisOptions());

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        private Request CreateDetectLanguageRequest(IEnumerable<DetectLanguageInput> inputs, TextAnalysisOptions options)
        {
            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDetectLanguageInputs(inputs);

            request.Method = RequestMethod.Post;
            BuildUriForRoute(LanguagesRoute, request.Uri, options);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        #endregion

        #region Recognize Entities

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<RecognizeEntitiesResult>> RecognizeEntitiesAsync(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            // TODO: set language from options

            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(new string[] { inputText }, language, EntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        RecognizeEntitiesResultCollection results = await CreateRecognizeEntitiesResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(results[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<RecognizeEntitiesResult> RecognizeEntities(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(new string[] { inputText }, language, EntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        RecognizeEntitiesResultCollection results = CreateRecognizeEntitiesResponse(response);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(results[0].ErrorMessage);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesAsync(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return await RecognizeEntitiesAsync(documentInputs, new TextAnalysisOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<RecognizeEntitiesResultCollection> RecognizeEntities(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return RecognizeEntities(documentInputs, new TextAnalysisOptions(), cancellationToken);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesAsync(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, EntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                return response.Status switch
                {
                    200 => await CreateRecognizeEntitiesResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    _ => throw await response.CreateRequestFailedExceptionAsync(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<RecognizeEntitiesResultCollection> RecognizeEntities(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, EntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    200 => CreateRecognizeEntitiesResponse(response),
                    _ => throw response.CreateRequestFailedException(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Analyze Sentiment

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<AnalyzeSentimentResult>> AnalyzeSentimentAsync(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.AnalyzeSentiment");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(new string[] { inputText }, language, SentimentRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        AnalyzeSentimentResultCollection results = await CreateAnalyzeSentimentResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(results[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<AnalyzeSentimentResult> AnalyzeSentiment(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.AnalyzeSentiment");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(new string[] { inputText }, language, SentimentRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        AnalyzeSentimentResultCollection results = CreateAnalyzeSentimentResponse(response);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(results[0].ErrorMessage);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentAsync(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return await AnalyzeSentimentAsync(documentInputs, new TextAnalysisOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<AnalyzeSentimentResultCollection> AnalyzeSentiment(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return AnalyzeSentiment(documentInputs, new TextAnalysisOptions(), cancellationToken);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentAsync(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.AnalyzeSentiment");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, SentimentRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                return response.Status switch
                {
                    200 => await CreateAnalyzeSentimentResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    _ => throw await response.CreateRequestFailedExceptionAsync(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<AnalyzeSentimentResultCollection> AnalyzeSentiment(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.AnalyzeSentiment");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, SentimentRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    200 => CreateAnalyzeSentimentResponse(response),
                    _ => throw response.CreateRequestFailedException(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Extract Key Phrases

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<ExtractKeyPhrasesResult>> ExtractKeyPhrasesAsync(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractKeyPhrases");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(new string[] { inputText }, language, KeyPhrasesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        ExtractKeyPhrasesResultCollection result = await CreateKeyPhraseResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (result[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(result[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<ExtractKeyPhrasesResult> ExtractKeyPhrases(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractKeyPhrases");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(new string[] { inputText }, language, KeyPhrasesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        ExtractKeyPhrasesResultCollection result = CreateKeyPhraseResponse(response);
                        if (result[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(result[0].ErrorMessage);
                        }
                        return Response.FromValue(result[0], response);
                    default:
                        throw response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesAsync(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return await ExtractKeyPhrasesAsync(documentInputs, new TextAnalysisOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrases(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return ExtractKeyPhrases(documentInputs, new TextAnalysisOptions(), cancellationToken);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesAsync(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractKeyPhrases");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, KeyPhrasesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                return response.Status switch
                {
                    200 => await CreateKeyPhraseResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    _ => throw await response.CreateRequestFailedExceptionAsync(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrases(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractKeyPhrases");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, KeyPhrasesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    200 => CreateKeyPhraseResponse(response),
                    _ => throw response.CreateRequestFailedException(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Recognize PII Entities

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<RecognizeEntitiesResult>> RecognizePiiEntitiesAsync(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(new string[] { inputText }, language, PiiEntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        RecognizeEntitiesResultCollection results = await CreateRecognizeEntitiesResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(results[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<RecognizeEntitiesResult> RecognizePiiEntities(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(new string[] { inputText }, language, PiiEntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        RecognizeEntitiesResultCollection results = CreateRecognizeEntitiesResponse(response);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(results[0].ErrorMessage);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<RecognizeEntitiesResultCollection>> RecognizePiiEntitiesAsync(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return await RecognizeEntitiesAsync(documentInputs, new TextAnalysisOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<RecognizeEntitiesResultCollection> RecognizePiiEntities(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return RecognizeEntities(documentInputs, new TextAnalysisOptions(), cancellationToken);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<RecognizeEntitiesResultCollection>> RecognizePiiEntitiesAsync(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, PiiEntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                return response.Status switch
                {
                    200 => await CreateRecognizeEntitiesResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    _ => throw await response.CreateRequestFailedExceptionAsync(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<RecognizeEntitiesResultCollection> RecognizePiiEntities(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, PiiEntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    200 => CreateRecognizeEntitiesResponse(response),
                    _ => throw response.CreateRequestFailedException(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Entity Linking

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<ExtractLinkedEntitiesResult>> ExtractEntityLinkingAsync(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractEntityLinking");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(new string[] { inputText }, language, EntityLinkingRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        ExtractLinkedEntitiesResultCollection result = await CreateLinkedEntityResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (result[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(result[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<ExtractLinkedEntitiesResult> ExtractEntityLinking(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractEntityLinking");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(new string[] { inputText }, language, EntityLinkingRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        ExtractLinkedEntitiesResultCollection results = CreateLinkedEntityResponse(response);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(results[0].ErrorMessage);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<ExtractLinkedEntitiesResultCollection>> ExtractEntityLinkingAsync(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return await ExtractEntityLinkingAsync(documentInputs, new TextAnalysisOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<ExtractLinkedEntitiesResultCollection> ExtractEntityLinking(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return ExtractEntityLinking(documentInputs, new TextAnalysisOptions(), cancellationToken);
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<ExtractLinkedEntitiesResultCollection>> ExtractEntityLinkingAsync(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractEntityLinking");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, EntityLinkingRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                return response.Status switch
                {
                    200 => await CreateLinkedEntityResponseAsync(response, cancellationToken).ConfigureAwait(false),
                    _ => throw await response.CreateRequestFailedExceptionAsync(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="options"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<ExtractLinkedEntitiesResultCollection> ExtractEntityLinking(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractEntityLinking");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, EntityLinkingRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    200 => CreateLinkedEntityResponse(response),
                    _ => throw response.CreateRequestFailedException(),
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Common
        private List<TextDocumentInput> ConvertToDocumentInputs(IEnumerable<string> inputs, string language)
        {
            language ??= _options.DefaultLanguage;

            int id = 0;
            List<TextDocumentInput> documentInputs = new List<TextDocumentInput>();
            foreach (string input in inputs)
            {
                documentInputs.Add(new TextDocumentInput($"{id++}", input)
                {
                    Language = language,
                });
            }

            return documentInputs;
        }

        private List<DetectLanguageInput> ConvertToDetectLanguageInputs(IEnumerable<string> inputs, string countryHint)
        {
            countryHint ??= _options.DefaultCountryHint;

            int id = 0;
            List<DetectLanguageInput> detectLanguageInputs = new List<DetectLanguageInput>();
            foreach (string input in inputs)
            {
                detectLanguageInputs.Add(new DetectLanguageInput($"{id++}")
                {
                    Text = input,
                    CountryHint = countryHint,
                });
            }

            return detectLanguageInputs;
        }

        private Request CreateStringCollectionRequest(IEnumerable<string> inputs, string language, string route)
        {
            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs, language);

            request.Method = RequestMethod.Post;
            BuildUriForRoute(route, request.Uri, new TextAnalysisOptions());

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        private Request CreateDocumentInputRequest(IEnumerable<TextDocumentInput> inputs, TextAnalysisOptions options, string route)
        {
            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs);

            request.Method = RequestMethod.Post;
            BuildUriForRoute(route, request.Uri, options);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }
        #endregion
    }
}
