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

        // TODO: How are we doing AAD auth?

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
        public virtual async Task<Response<DetectedLanguage>> DetectLanguageAsync(string inputText, string countryHint = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguage");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputText, countryHint, showStats: false);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        TextAnalyticsResultPage<DetectedLanguage> result = await CreateLanguageResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result.Errors[0].Message).ConfigureAwait(false);
                        }
                        return CreateDetectedLanguageResponseSimple(response, result.DocumentResults[0].Predictions[0]);
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
        public virtual Response<DetectedLanguage> DetectLanguage(string inputText, string countryHint = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguage");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputText, countryHint, showStats: false);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        TextAnalyticsResultPage<DetectedLanguage> result = CreateDetectLanguageResponse(response);
                        if (result.Errors.Count > 0)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(result.Errors[0].Message);
                        }
                        return CreateDetectedLanguageResponseSimple(response, result.DocumentResults[0].Predictions[0]);
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

        private Request CreateDetectLanguageRequest(string inputText, string countryHint, bool showStats)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));
            Argument.AssertNotNull(countryHint, nameof(countryHint));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeLanguageInput(inputText, countryHint);

            request.Method = RequestMethod.Post;

            BuildUriForLanguagesRoute(request.Uri, showStats, modelVersion: default);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            if (showStats)
            {
                // TODO: do something with showStats
            }

            return request;
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="countryHint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual AsyncPageable<DetectedLanguage> DetectLanguagesAsync(List<string> inputs, string countryHint = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetDetectedLanguagesPageAsync(inputs, countryHint, cancellationToken));
        }

        // Note: for simple case, we can take a list of strings as inputs.
        // We should provide an overload that lets you take a list of LanguageInputs, to handling country hint and id, if needed.
        // TODO: revisit whether the return type is too complex for a simple overload.  Should it be included in a kitchen sink method instead?
        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="countryHint"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Pageable<DetectedLanguage> DetectLanguages(List<string> inputs, string countryHint = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            return PageResponseEnumerator.CreateEnumerable(nextLink => GetDetectedLanguagesPage(inputs, countryHint, cancellationToken));
        }

        private async Task<Page<DetectedLanguage>> GetDetectedLanguagesPageAsync(List<string> inputs, string countryHint, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.GetDetectedLanguagesPage");
            scope.Start();

            try
            {
                using Request request = CreateDetectedLanguageBatchRequestSimple(inputs, countryHint);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        // TODO: we should probably rip out the simple stuff now.  Look into that.
                        ResultBatch<DetectedLanguage> resultBatch = await TextAnalyticsServiceSerializer.ParseDetectedLanguageBatchSimpleAsync(response, cancellationToken).ConfigureAwait(false);
                        return Page<DetectedLanguage>.FromValues(resultBatch.Values, resultBatch.NextBatchLink, response);

                    // TODO: what is exception handling story for case where some values come back with an error and some don't?
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

        private Page<DetectedLanguage> GetDetectedLanguagesPage(List<string> inputs, string countryHint, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.GetDetectedLanguagesPage");
            scope.Start();

            try
            {
                using Request request = CreateDetectedLanguageBatchRequestSimple(inputs, countryHint);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        ResultBatch<DetectedLanguage> resultBatch = TextAnalyticsServiceSerializer.ParseDetectedLanguageBatchSimple(response);
                        return Page<DetectedLanguage>.FromValues(resultBatch.Values, resultBatch.NextBatchLink, response);

                    // TODO: what is exception handling story for case where some values come back with an error and some don't?
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

        // TODO: can we fold this into advanced version?
        private Request CreateDetectedLanguageBatchRequestSimple(List<string> inputs, string countryHint)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeLanguageInputs(inputs, countryHint);

            request.Method = RequestMethod.Post;
            BuildUriForLanguagesRoute(request.Uri, showStats: default, modelVersion: default);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual AsyncPageable<DocumentResult<DetectedLanguage>> DetectLanguagesAsync(List<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => GetDetectedLanguagesPageAsync(inputs, showStats, modelVersion, cancellationToken));
        }

        /// <summary>
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="showStats"></param>
        /// <param name="modelVersion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Pageable<DocumentResult<DetectedLanguage>> DetectLanguages(List<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            return PageResponseEnumerator.CreateEnumerable(nextLink => GetDetectedLanguagesPage(inputs, showStats, modelVersion, cancellationToken));
        }

        private async Task<Page<DocumentResult<DetectedLanguage>>> GetDetectedLanguagesPageAsync(List<DocumentInput> inputs, bool showStats, string modelVersion, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.GetDetectedLanguagesPage");
            scope.Start();

            try
            {
                using Request request = CreateDetectedLanguageBatchRequest(inputs, showStats, modelVersion);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return await TextAnalyticsServiceSerializer.DeserializeDetectLanguageResponseAsync(response, cancellationToken).ConfigureAwait(false);
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

        private TextAnalyticsResultPage<DetectedLanguage> GetDetectedLanguagesPage(List<DocumentInput> inputs, bool showStats, string modelVersion, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.GetDetectedLanguagesPage");
            scope.Start();

            try
            {
                using Request request = CreateDetectedLanguageBatchRequest(inputs, showStats, modelVersion);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return TextAnalyticsServiceSerializer.DeserializeDetectLanguageResponse(response);
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

        private Request CreateDetectedLanguageBatchRequest(List<DocumentInput> inputs, bool showStats, string modelVersion)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeLanguageInputs(inputs);

            request.Method = RequestMethod.Post;
            BuildUriForLanguagesRoute(request.Uri, showStats, modelVersion);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        #endregion
    }
}
