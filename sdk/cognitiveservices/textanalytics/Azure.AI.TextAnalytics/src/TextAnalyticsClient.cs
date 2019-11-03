// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
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

        /// <summary>
        /// </summary>
        /// <param name="inputText"></param>
        /// <param name="countryHint"></param>
        /// <param name="showStats"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<Response<LanguageResult>> DetectLanguageAsync(string inputText, string countryHint = "en", bool showStats = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguage");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputText, countryHint, showStats);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        return await CreateLanguageResponseAsync(response, cancellationToken).ConfigureAwait(false);
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
        /// <param name="showStats"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Response<LanguageResult> DetectLanguage(string inputText, string countryHint = "en", bool showStats = false, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguage");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputText, countryHint, showStats);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return CreateLanguageResponse(response);
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
    }
}
