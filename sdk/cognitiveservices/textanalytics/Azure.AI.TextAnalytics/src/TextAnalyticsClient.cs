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
        public TextAnalyticsClient(string endpoint, string subscriptionKey)
            : this(endpoint, subscriptionKey, new TextAnalyticsClientOptions())
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="subscriptionKey"></param>
        /// <param name="options"></param>
        public TextAnalyticsClient(string endpoint, string subscriptionKey, TextAnalyticsClientOptions options)
        {
            Argument.AssertNotNullOrEmpty(endpoint, nameof(endpoint));
            Argument.AssertNotNullOrEmpty(subscriptionKey, nameof(endpoint));

            _baseUri = new Uri(endpoint);
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
        public virtual async Task<DetectedLanguage> DetectLanguageAsync(string inputText, string countryHint = "en", CancellationToken cancellationToken = default)
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
                        LanguageResult result = await CreateLanguageResponseAsync(response, cancellationToken).ConfigureAwait(false);
                        if (result.ErrorMessage != null)
                        {
                            throw response.CreateRequestFailedException(result.ErrorMessage);
                        }
                        return CreateDetectedLanguageResponseSimple(response, result.DetectedLanguages[0]);
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
                        LanguageResult result = CreateLanguageResponse(response);
                        if (result.ErrorMessage != null)
                        {
                            throw response.CreateRequestFailedException(result.ErrorMessage);
                        }
                        return CreateDetectedLanguageResponseSimple(response, result.DetectedLanguages[0]);
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

            BuildUriForLanguagesRoute(request.Uri);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            if (showStats)
            {
                // TODO: do something with showStats
            }

            return request;
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
        public virtual Pageable<List<DetectedLanguage>> DetectLanguages(List<string> inputs, string countryHint = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            return PageResponseEnumerator.CreateEnumerable(nextLink => GetDetectedLanguagesPage(inputs, countryHint, cancellationToken));
        }

        private Page<List<DetectedLanguage>> GetDetectedLanguagesPage(List<string> inputs, string countryHint, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.GetDetectedLanguagesPage");
            scope.Start();

            try
            {
                using Request request = CreateDetectedLanguageBatchRequest(inputs, countryHint);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        ResultBatch<List<DetectedLanguage>> resultBatch = TextAnalyticsServiceSerializer.ParseDetectedLanguageBatch(response);
                        return Page<List<DetectedLanguage>>.FromValues(resultBatch.Values, resultBatch.NextBatchLink, response);
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

        private Request CreateDetectedLanguageBatchRequest(List<string> inputs, string countryHint)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeLanguageInputs(inputs, countryHint);

            request.Method = RequestMethod.Post;
            BuildUriForLanguagesRoute(request.Uri);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            return request;
        }

        #endregion
    }
}
