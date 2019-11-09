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

        private Request CreateDetectLanguageRequest(string inputText, string countryHint, bool showStats)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));
            Argument.AssertNotNull(countryHint, nameof(countryHint));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDetectLanguageInput(inputText, countryHint);

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
        public virtual async Task<Response<IEnumerable<DetectedLanguage>>> DetectLanguagesAsync(IEnumerable<string> inputs, string countryHint = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageBatchRequest(inputs, countryHint);
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
        public virtual Response<IEnumerable<DetectedLanguage>> DetectLanguages(IEnumerable<string> inputs, string countryHint = "en", CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageBatchRequest(inputs, countryHint);
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

        private Request CreateDetectLanguageBatchRequest(IEnumerable<string> inputs, string countryHint)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDetectLanguageInputs(inputs, countryHint);

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
        public virtual async Task<Response<DocumentResultCollection<DetectedLanguage>>> DetectLanguagesAsync(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageBatchRequest(inputs, showStats, modelVersion);
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
        public virtual Response<DocumentResultCollection<DetectedLanguage>> DetectLanguages(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageBatchRequest(inputs, showStats, modelVersion);
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

        private Request CreateDetectLanguageBatchRequest(IEnumerable<DocumentInput> inputs, bool showStats, string modelVersion)
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

        ///// <summary>
        ///// </summary>
        ///// <param name="inputText"></param>
        ///// <param name="language"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //public virtual async Task<Response<IEnumerable<Entity>>> RecognizeEntitiesAsync(string inputText, string language = "en", CancellationToken cancellationToken = default)
        //{
        //    Argument.AssertNotNullOrEmpty(inputText, nameof(inputText));

        //    using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguage");
        //    scope.AddAttribute("inputText", inputText);
        //    scope.Start();

        //    try
        //    {
        //        using Request request = CreateDetectLanguageRequest(inputText, countryHint, showStats: false);
        //        Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

        //        switch (response.Status)
        //        {
        //            case 200:
        //                DocumentResultCollection<DetectedLanguage> result = await CreateDetectLanguageResponseAsync(response, cancellationToken).ConfigureAwait(false);
        //                if (result.Errors.Count > 0)
        //                {
        //                    // only one input, so we can ignore the id and grab the first error message.
        //                    throw await response.CreateRequestFailedExceptionAsync(result.Errors[0].Message).ConfigureAwait(false);
        //                }
        //                return CreateDetectedLanguageResponseSimple(response, result[0][0]);
        //            default:
        //                throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        scope.Failed(e);
        //        throw;
        //    }
        //}

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
                using Request request = CreateRecognizeEntitiesRequest(inputText, language, showStats: false);
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

        private Request CreateRecognizeEntitiesRequest(string inputText, string language, bool showStats)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));
            Argument.AssertNotNull(language, nameof(language));

            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInput(inputText, language);

            request.Method = RequestMethod.Post;

            BuildUriForEntitiesRoute(request.Uri, showStats, modelVersion: default);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

            if (showStats)
            {
                // TODO: do something with showStats
            }

            return request;
        }

        ///// <summary>
        ///// </summary>
        ///// <param name="inputs"></param>
        ///// <param name="language"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //public virtual async Task<Response<IEnumerable<Entity>>> RecognizeEntitiesAsync(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        //{
        //    Argument.AssertNotNull(inputs, nameof(inputs));

        //    using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
        //    scope.Start();

        //    try
        //    {
        //        using Request request = CreateDetectLanguageBatchRequest(inputs, countryHint);
        //        Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

        //        switch (response.Status)
        //        {
        //            case 200:
        //                return await CreateDetectLanguageResponseSimpleAsync(response, cancellationToken).ConfigureAwait(false);
        //            default:
        //                throw await response.CreateRequestFailedExceptionAsync();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        scope.Failed(e);
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// </summary>
        ///// <param name="inputs"></param>
        ///// <param name="language"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //public virtual Response<IEnumerable<Entity>> RecognizeEntities(IEnumerable<string> inputs, string language = "en", CancellationToken cancellationToken = default)
        //{
        //    Argument.AssertNotNull(inputs, nameof(inputs));
        //    using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
        //    scope.Start();

        //    try
        //    {
        //        using Request request = CreateDetectLanguageBatchRequest(inputs, countryHint);
        //        Response response = _pipeline.SendRequest(request, cancellationToken);

        //        return response.Status switch
        //        {
        //            // TODO: for this, we'll need to stitch back together the errors, as ids have been stripped.
        //            200 => CreateDetectLanguageResponseSimple(response),
        //            _ => throw response.CreateRequestFailedException(),
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        scope.Failed(e);
        //        throw;
        //    }
        //}

        //private Request CreateRecognizeEntitiesBatchRequest(IEnumerable<string> inputs, string countryHint)
        //{
        //    Argument.AssertNotNull(inputs, nameof(inputs));

        //    Request request = _pipeline.CreateRequest();

        //    ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDetectLanguageInputs(inputs, countryHint);

        //    request.Method = RequestMethod.Post;
        //    BuildUriForLanguagesRoute(request.Uri, showStats: default, modelVersion: default);

        //    request.Headers.Add(HttpHeader.Common.JsonContentType);
        //    request.Content = RequestContent.Create(content);

        //    request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

        //    return request;
        //}

        ///// <summary>
        ///// </summary>
        ///// <param name="inputs"></param>
        ///// <param name="showStats"></param>
        ///// <param name="modelVersion"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //public virtual async Task<Response<DocumentResultCollection<Entity>>> RecognizeEntitiesAsync(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        //{
        //    Argument.AssertNotNull(inputs, nameof(inputs));

        //    using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
        //    scope.Start();

        //    try
        //    {
        //        using Request request = CreateDetectLanguageBatchRequest(inputs, showStats, modelVersion);
        //        Response response = await _pipeline.SendRequestAsync(request, cancellationToken);

        //        return response.Status switch
        //        {
        //            200 => await CreateDetectLanguageResponseAsync(response, cancellationToken).ConfigureAwait(false),
        //            _ => throw await response.CreateRequestFailedExceptionAsync(),
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        scope.Failed(e);
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// </summary>
        ///// <param name="inputs"></param>
        ///// <param name="showStats"></param>
        ///// <param name="modelVersion"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //public virtual Response<DocumentResultCollection<Entity>> RecognizeEntities(IEnumerable<DocumentInput> inputs, bool showStats = false, string modelVersion = default, CancellationToken cancellationToken = default)
        //{
        //    Argument.AssertNotNull(inputs, nameof(inputs));

        //    using DiagnosticScope scope = _clientDiagnostics.CreateScope("Azure.AI.TextAnalytics.TextAnalyticsClient.DetectLanguages");
        //    scope.Start();

        //    try
        //    {
        //        using Request request = CreateDetectLanguageBatchRequest(inputs, showStats, modelVersion);
        //        Response response = _pipeline.SendRequest(request, cancellationToken);

        //        return response.Status switch
        //        {
        //            200 => CreateDetectLanguageResponse(response),
        //            _ => throw response.CreateRequestFailedException(),
        //        };
        //    }
        //    catch (Exception e)
        //    {
        //        scope.Failed(e);
        //        throw;
        //    }
        //}

        //private Request CreateRecognizeEntitiesBatchRequest(IEnumerable<DocumentInput> inputs, bool showStats, string modelVersion)
        //{
        //    Argument.AssertNotNull(inputs, nameof(inputs));

        //    Request request = _pipeline.CreateRequest();

        //    ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDetectLanguageInputs(inputs);

        //    request.Method = RequestMethod.Post;
        //    BuildUriForLanguagesRoute(request.Uri, showStats, modelVersion);

        //    request.Headers.Add(HttpHeader.Common.JsonContentType);
        //    request.Content = RequestContent.Create(content);

        //    request.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

        //    return request;
        //}

        #endregion
    }
}
