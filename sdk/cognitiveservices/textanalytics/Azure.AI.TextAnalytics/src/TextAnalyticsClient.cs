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
            Argument.AssertNotNull(options, nameof(options));

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
                using Request request = CreateDetectLanguageRequest(new List<string> { inputText }, countryHint);
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
                using Request request = CreateDetectLanguageRequest(new List<string> { inputText }, countryHint);
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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DocumentResultCollection<DetectedLanguage>>> DetectLanguagesAsync(IEnumerable<DetectLanguageInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputs, showStats, modelVersion);
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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DocumentResultCollection<DetectedLanguage>> DetectLanguages(IEnumerable<DetectLanguageInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputs, showStats, modelVersion);
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
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(countryHint, nameof(countryHint));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDetectLanguageInputs(inputs, countryHint);

            request.Method = RequestMethod.Post;
            BuildUriForLanguagesRoute(request.Uri, showStats: default, modelVersion: default);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        private Request CreateDetectLanguageRequest(IEnumerable<DetectLanguageInput> inputs, bool showStats, string modelVersion)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDetectLanguageInputs(inputs);

            request.Method = RequestMethod.Post;
            BuildUriForLanguagesRoute(request.Uri, showStats, modelVersion);

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
        public virtual async Task<Response<IEnumerable<Entity>>> RecognizeEntitiesAsync(string inputText, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateRecognizeEntitiesRequest(new List<string> { inputText }, language);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        DocumentResultCollection<Entity> result = await CreateRecognizeEntitiesResponseAsync(response, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<IEnumerable<Entity>> RecognizeEntities(string inputText, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateRecognizeEntitiesRequest(new List<string> { inputText }, language);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        DocumentResultCollection<Entity> result = CreateRecognizeEntitiesResponse(response);
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
        public virtual async Task<Response<IEnumerable<IEnumerable<Entity>>>> RecognizeEntitiesAsync(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.Start();

            try
            {
                using Request request = CreateRecognizeEntitiesRequest(inputs, language);
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
        public virtual Response<IEnumerable<IEnumerable<Entity>>> RecognizeEntities(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.Start();

            try
            {
                using Request request = CreateRecognizeEntitiesRequest(inputs, language);
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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DocumentResultCollection<Entity>>> RecognizeEntitiesAsync(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.Start();

            try
            {
                using Request request = CreateRecognizeEntitiesRequest(inputs, showStats, modelVersion);
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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DocumentResultCollection<Entity>> RecognizeEntities(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizeEntities");
            scope.Start();

            try
            {
                using Request request = CreateRecognizeEntitiesRequest(inputs, showStats, modelVersion);
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

        private Request CreateRecognizeEntitiesRequest(IEnumerable<string> inputs, string language)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(language, nameof(language));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs, language);

            request.Method = RequestMethod.Post;
            BuildUriForEntitiesRoute(request.Uri, showStats: default, modelVersion: default);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        private Request CreateRecognizeEntitiesRequest(IEnumerable<DocumentInput> inputs, bool showStats, string modelVersion)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs);

            request.Method = RequestMethod.Post;
            BuildUriForEntitiesRoute(request.Uri, showStats, modelVersion);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
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
                using Request request = CreateAnalyzeSentimentRequest(new List<string> { inputText }, language);
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
                using Request request = CreateAnalyzeSentimentRequest(new List<string> { inputText }, language);
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
                using Request request = CreateAnalyzeSentimentRequest(inputs, language);
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
                using Request request = CreateAnalyzeSentimentRequest(inputs, language);
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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<SentimentResultCollection>> AnalyzeSentimentAsync(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.AnalyzeSentiment");
            scope.Start();

            try
            {
                using Request request = CreateAnalyzeSentimentRequest(inputs, showStats, modelVersion);
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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<SentimentResultCollection> AnalyzeSentiment(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.AnalyzeSentiment");
            scope.Start();

            try
            {
                using Request request = CreateAnalyzeSentimentRequest(inputs, showStats, modelVersion);
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

        private Request CreateAnalyzeSentimentRequest(IEnumerable<string> inputs, string language)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs, language);

            request.Method = RequestMethod.Post;
            BuildUriForSentimentRoute(request.Uri, showStats: default, modelVersion: default);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        private Request CreateAnalyzeSentimentRequest(IEnumerable<DocumentInput> inputs, bool showStats, string modelVersion)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs);

            request.Method = RequestMethod.Post;
            BuildUriForSentimentRoute(request.Uri, showStats, modelVersion);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
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
                using Request request = CreateExtractKeyPhrasesRequest(new List<string> { inputText }, language);
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
                using Request request = CreateExtractKeyPhrasesRequest(new List<string> { inputText }, language);
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
                using Request request = CreateExtractKeyPhrasesRequest(inputs, language);
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
                using Request request = CreateExtractKeyPhrasesRequest(inputs, language);
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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DocumentResultCollection<string>>> ExtractKeyPhrasesAsync(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractKeyPhrases");
            scope.Start();

            try
            {
                using Request request = CreateExtractKeyPhrasesRequest(inputs, showStats, modelVersion);
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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DocumentResultCollection<string>> ExtractKeyPhrases(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.ExtractKeyPhrases");
            scope.Start();

            try
            {
                using Request request = CreateExtractKeyPhrasesRequest(inputs, showStats, modelVersion);
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

        private Request CreateExtractKeyPhrasesRequest(IEnumerable<string> inputs, string language)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(language, nameof(language));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs, language);

            request.Method = RequestMethod.Post;
            BuildUriForKeyPhrasesRoute(request.Uri, showStats: default, modelVersion: default);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        private Request CreateExtractKeyPhrasesRequest(IEnumerable<DocumentInput> inputs, bool showStats, string modelVersion)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs);

            request.Method = RequestMethod.Post;
            BuildUriForKeyPhrasesRoute(request.Uri, showStats, modelVersion);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        #endregion

        #region Recognize PII Entities

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="language"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<IEnumerable<Entity>>> RecognizePiiEntitiesAsync(string inputText, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateRecognizePiiEntitiesRequest(new List<string> { inputText }, language);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        DocumentResultCollection<Entity> result = await CreateRecognizeEntitiesResponseAsync(response, cancellationToken).ConfigureAwait(false);
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
        public virtual Response<IEnumerable<Entity>> RecognizePiiEntities(string inputText, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateRecognizePiiEntitiesRequest(new List<string> { inputText }, language);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        DocumentResultCollection<Entity> result = CreateRecognizeEntitiesResponse(response);
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
        public virtual async Task<Response<IEnumerable<IEnumerable<Entity>>>> RecognizePiiEntitiesAsync(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.Start();

            try
            {
                using Request request = CreateRecognizePiiEntitiesRequest(inputs, language);
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
        public virtual Response<IEnumerable<IEnumerable<Entity>>> RecognizePiiEntities(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.Start();

            try
            {
                using Request request = CreateRecognizePiiEntitiesRequest(inputs, language);
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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<DocumentResultCollection<Entity>>> RecognizePiiEntitiesAsync(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.Start();

            try
            {
                using Request request = CreateRecognizePiiEntitiesRequest(inputs, showStats, modelVersion);
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
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<DocumentResultCollection<Entity>> RecognizePiiEntities(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.RecognizePiiEntities");
            scope.Start();

            try
            {
                using Request request = CreateRecognizePiiEntitiesRequest(inputs, showStats, modelVersion);
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

        private Request CreateRecognizePiiEntitiesRequest(IEnumerable<string> inputs, string language)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(language, nameof(language));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs, language);

            request.Method = RequestMethod.Post;
            BuildUriForPiiEntitiesRoute(request.Uri, showStats: default, modelVersion: default);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        private Request CreateRecognizePiiEntitiesRequest(IEnumerable<DocumentInput> inputs, bool showStats, string modelVersion)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs);

            request.Method = RequestMethod.Post;
            BuildUriForPiiEntitiesRoute(request.Uri, showStats, modelVersion);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        #endregion

    }
}
