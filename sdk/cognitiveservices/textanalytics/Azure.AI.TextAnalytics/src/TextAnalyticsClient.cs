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
        }

        #region Detect Language

        // Note that this is a simple overload that takes a single input and returns a single detected language.
        // More advanced overloads are available that return the full list of detected languages.
        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="countryHint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DetectedLanguage>> DetectLanguageAsync(string inputText, string countryHint = "us", CancellationToken cancellationToken = default)
        {
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
                        DocumentResultCollection<DetectedLanguage> result = await CreateDetectLanguageResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result.Errors[0].Message).ConfigureAwait(false);
                        }
                        return CreateDetectedLanguageResponseSimple(response, result[0][0]);
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
        public virtual Response<DetectedLanguage> DetectLanguage(string inputText, string countryHint = "us", CancellationToken cancellationToken = default)
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
                        DocumentResultCollection<DetectedLanguage> result = CreateDetectLanguageResponse(response);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(result.Errors[0].Message);
                        }
                        return CreateDetectedLanguageResponseSimple(response, result[0][0]);
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
        public virtual async Task<Response<IEnumerable<DetectedLanguage>>> DetectLanguagesAsync(IEnumerable<string> inputs, string countryHint = "us", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputs, countryHint);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return await CreateDetectLanguageResponseSimpleAsync(response, cancellationToken).ConfigureAwait(false);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Note: for simple case, proposal is to take a list of strings as inputs.
        // We should provide an overload that lets you take a list of LanguageInputs, to handling country hint and id, if needed.
        // TODO: revisit whether the return type is too complex for a simple overload.  Should it be included in a kitchen sink method instead?
        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="countryHint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<IEnumerable<DetectedLanguage>> DetectLanguages(IEnumerable<string> inputs, string countryHint = "us", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputs, countryHint);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    // TODO: for this, we'll need to stitch back together the errors, as ids have been stripped.
                    200 => CreateDetectLanguageResponseSimple(response),
                    _ => throw response.CreateRequestFailedException(),
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
        public virtual async Task<Response<DocumentResultCollection<DetectedLanguage>>> DetectLanguagesAsync(IEnumerable<DetectLanguageInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
        public virtual Response<DocumentResultCollection<DetectedLanguage>> DetectLanguages(IEnumerable<DetectLanguageInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
            BuildUriForRoute(LanguagesRoute, request.Uri, new TextAnalyticsRequestOptions());

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        private Request CreateDetectLanguageRequest(IEnumerable<DetectLanguageInput> inputs, TextAnalyticsRequestOptions options)
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
        public virtual async Task<Response<IEnumerable<NamedEntity>>> RecognizeEntitiesAsync(string inputText, string language = "en", CancellationToken cancellationToken = default)
        {
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
                        DocumentResultCollection<NamedEntity> result = await CreateRecognizeEntitiesResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result.Errors[0].Message).ConfigureAwait(false);
                        }
                        return CreateRecognizeEntitiesResponseSimple(response, result[0]);
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
        public virtual Response<IEnumerable<NamedEntity>> RecognizeEntities(string inputText, string language = "en", CancellationToken cancellationToken = default)
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
                        DocumentResultCollection<NamedEntity> result = CreateRecognizeEntitiesResponse(response);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(result.Errors[0].Message);
                        }
                        return CreateRecognizeEntitiesResponseSimple(response, result[0]);
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
        public virtual async Task<Response<IEnumerable<IEnumerable<NamedEntity>>>> RecognizeEntitiesAsync(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(inputs, language, EntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return await CreateRecognizeEntitiesResponseSimpleAsync(response, cancellationToken).ConfigureAwait(false);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync();
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
        public virtual Response<IEnumerable<IEnumerable<NamedEntity>>> RecognizeEntities(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(inputs, language, EntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    // TODO: for this, we'll need to stitch back together the errors, as ids have been stripped.
                    200 => CreateRecognizeEntitiesResponseSimple(response),
                    _ => throw response.CreateRequestFailedException(),
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
        public virtual async Task<Response<DocumentResultCollection<NamedEntity>>> RecognizeEntitiesAsync(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
        public virtual Response<DocumentResultCollection<NamedEntity>> RecognizeEntities(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
        public virtual async Task<Response<Sentiment>> AnalyzeSentimentAsync(string inputText, string language = "en", CancellationToken cancellationToken = default)
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
                        SentimentResultCollection results = await CreateAnalyzeSentimentResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (results.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(results.Errors[0].Message).ConfigureAwait(false);
                        }
                        return CreateAnalyzeSentimentResponseSimple(response, (results[0] as SentimentResult).DocumentSentiment);
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
        public virtual Response<Sentiment> AnalyzeSentiment(string inputText, string language = "en", CancellationToken cancellationToken = default)
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
                        SentimentResultCollection results = CreateAnalyzeSentimentResponse(response);
                        if (results.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(results.Errors[0].Message);
                        }
                        return CreateAnalyzeSentimentResponseSimple(response, (results[0] as SentimentResult).DocumentSentiment);
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
        public virtual async Task<Response<IEnumerable<Sentiment>>> AnalyzeSentimentAsync(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.AnalyzeSentiment");
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(inputs, language, SentimentRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                return response.Status switch
                {
                    200 => await CreateAnalyzeSentimentResponseSimpleAsync(response, cancellationToken).ConfigureAwait(false),
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
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<IEnumerable<Sentiment>> AnalyzeSentiment(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.AnalyzeSentiment");
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(inputs, language, SentimentRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    // TODO: for this, we'll need to stitch back together the errors, as ids have been stripped.
                    200 => CreateAnalyzeSentimentResponseSimple(response),
                    _ => throw response.CreateRequestFailedException(),
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
        public virtual async Task<Response<SentimentResultCollection>> AnalyzeSentimentAsync(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
        public virtual Response<SentimentResultCollection> AnalyzeSentiment(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
        public virtual async Task<Response<IEnumerable<string>>> ExtractKeyPhrasesAsync(string inputText, string language = "en", CancellationToken cancellationToken = default)
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
                        DocumentResultCollection<string> result = await CreateKeyPhraseResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result.Errors[0].Message).ConfigureAwait(false);
                        }
                        return CreateKeyPhraseResponseSimple(response, result[0]);
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
        public virtual Response<IEnumerable<string>> ExtractKeyPhrases(string inputText, string language = "en", CancellationToken cancellationToken = default)
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
                        DocumentResultCollection<string> result = CreateKeyPhraseResponse(response);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(result.Errors[0].Message);
                        }
                        return CreateKeyPhraseResponseSimple(response, result[0]);
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
        public virtual async Task<Response<IEnumerable<IEnumerable<string>>>> ExtractKeyPhrasesAsync(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractKeyPhrases");
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(inputs, language, KeyPhrasesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return await CreateKeyPhraseResponseSimpleAsync(response, cancellationToken).ConfigureAwait(false);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync();
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
        public virtual Response<IEnumerable<IEnumerable<string>>> ExtractKeyPhrases(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractKeyPhrases");
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(inputs, language, KeyPhrasesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    // TODO: for this, we'll need to stitch back together the errors, as ids have been stripped.
                    200 => CreateKeyPhraseResponseSimple(response),
                    _ => throw response.CreateRequestFailedException(),
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
        public virtual async Task<Response<DocumentResultCollection<string>>> ExtractKeyPhrasesAsync(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
        public virtual Response<DocumentResultCollection<string>> ExtractKeyPhrases(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
        public virtual async Task<Response<IEnumerable<NamedEntity>>> RecognizePiiEntitiesAsync(string inputText, string language = "en", CancellationToken cancellationToken = default)
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
                        DocumentResultCollection<NamedEntity> result = await CreateRecognizeEntitiesResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result.Errors[0].Message).ConfigureAwait(false);
                        }
                        return CreateRecognizeEntitiesResponseSimple(response, result[0]);
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
        public virtual Response<IEnumerable<NamedEntity>> RecognizePiiEntities(string inputText, string language = "en", CancellationToken cancellationToken = default)
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
                        DocumentResultCollection<NamedEntity> result = CreateRecognizeEntitiesResponse(response);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(result.Errors[0].Message);
                        }
                        return CreateRecognizeEntitiesResponseSimple(response, result[0]);
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
        public virtual async Task<Response<IEnumerable<IEnumerable<NamedEntity>>>> RecognizePiiEntitiesAsync(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(inputs, language, PiiEntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return await CreateRecognizeEntitiesResponseSimpleAsync(response, cancellationToken).ConfigureAwait(false);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync();
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
        public virtual Response<IEnumerable<IEnumerable<NamedEntity>>> RecognizePiiEntities(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(inputs, language, PiiEntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    // TODO: for this, we'll need to stitch back together the errors, as ids have been stripped.
                    200 => CreateRecognizeEntitiesResponseSimple(response),
                    _ => throw response.CreateRequestFailedException(),
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
        public virtual async Task<Response<DocumentResultCollection<NamedEntity>>> RecognizePiiEntitiesAsync(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
        public virtual Response<DocumentResultCollection<NamedEntity>> RecognizePiiEntities(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
        public virtual async Task<Response<IEnumerable<LinkedEntity>>> ExtractEntityLinkingAsync(string inputText, string language = "en", CancellationToken cancellationToken = default)
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
                        DocumentResultCollection<LinkedEntity> result = await CreateLinkedEntityResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result.Errors[0].Message).ConfigureAwait(false);
                        }
                        return CreateLinkedEntityResponseSimple(response, result[0]);
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
        public virtual Response<IEnumerable<LinkedEntity>> ExtractEntityLinking(string inputText, string language = "en", CancellationToken cancellationToken = default)
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
                        DocumentResultCollection<LinkedEntity> result = CreateLinkedEntityResponse(response);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(result.Errors[0].Message);
                        }
                        return CreateLinkedEntityResponseSimple(response, result[0]);
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
        public virtual async Task<Response<IEnumerable<IEnumerable<LinkedEntity>>>> ExtractEntityLinkingAsync(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractEntityLinking");
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(inputs, language, EntityLinkingRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return await CreateLinkedEntityResponseSimpleAsync(response, cancellationToken).ConfigureAwait(false);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync();
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
        public virtual Response<IEnumerable<IEnumerable<LinkedEntity>>> ExtractEntityLinking(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractEntityLinking");
            scope.Start();

            try
            {
                using Request request = CreateStringCollectionRequest(inputs, language, EntityLinkingRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                return response.Status switch
                {
                    // TODO: for this, we'll need to stitch back together the errors, as ids have been stripped.
                    200 => CreateLinkedEntityResponseSimple(response),
                    _ => throw response.CreateRequestFailedException(),
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
        public virtual async Task<Response<DocumentResultCollection<LinkedEntity>>> ExtractEntityLinkingAsync(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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
        public virtual Response<DocumentResultCollection<LinkedEntity>> ExtractEntityLinking(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
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

        private Request CreateStringCollectionRequest(IEnumerable<string> inputs, string language, string route)
        {
            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs, language);

            request.Method = RequestMethod.Post;
            BuildUriForRoute(route, request.Uri, new TextAnalyticsRequestOptions());

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        private Request CreateDocumentInputRequest(IEnumerable<DocumentInput> inputs, TextAnalyticsRequestOptions options, string route)
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
    }
}
