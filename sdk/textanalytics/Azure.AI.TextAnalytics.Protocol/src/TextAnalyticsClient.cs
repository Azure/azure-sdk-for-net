// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Protocol
{
    /// <summary>
    /// The Text Analytics API is a suite of text analytics web services built with best-in-class Microsoft machine learning algorithms.
    /// The API can be used to analyze unstructured text for tasks such as sentiment analysis, key phrase extraction and language detection.
    /// No training data is needed to use this API; just bring your text data. This API uses advanced natural language processing techniques
    /// to deliver best in class predictions. Further documentation can be found in
    /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/overview.
    /// </summary>
    public class TextAnalyticsClient
    {
        public virtual Uri Endpoint { get; }
        protected  HttpPipeline Pipeline { get; }
        private const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        protected TextAnalyticsClient()
        {
        }

        /// <summary>
        /// Constructs a new instance of a TextAnalyticsClient using the given endpoint and credentials.
        /// </summary>
        /// <param name="endpoint">The endpoint to use.</param>
        /// <param name="credential">The credentials to use.</param>
        public TextAnalyticsClient(Uri endpoint, AzureKeyCredential credential) : this(endpoint, credential, new ProtocolClientOptions())
        {
        }

        /// <summary>
        /// Constructs a new instance of a TextAnalyticsClient using the given endpoint, credentials and options.
        /// </summary>
        /// <param name="endpoint">The endpoint to use.</param>
        /// <param name="credential">The credentials to use.</param>
        /// <param name="options">Options to control the underlying operations.</param>
        public TextAnalyticsClient(Uri endpoint, AzureKeyCredential credential, ProtocolClientOptions options)
        {
            if (endpoint == null)
            {
                throw new ArgumentNullException(nameof(endpoint));
            }

            if (credential == null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            Endpoint = endpoint;
            Pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, AuthorizationHeader));
        }

        /// <summary>
        /// The API returns a list of general named entities in a given document. For the list of supported entity types,
        /// check <see href="https://aka.ms/taner">Supported Entity Types in Text Analytics API</see>. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/EntitiesRecognitionGeneral">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<Response> GetEntitiesAsync(RequestContent body, string modelVersion = null, bool? showStats = null, string stringIndexType = null, CancellationToken cancellationToken = default)
        {
            Request req = GetEntitiesRequest(body, modelVersion, showStats, stringIndexType);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The API returns a list of general named entities in a given document. For the list of supported entity types,
        /// check <see href="https://aka.ms/taner">Supported Entity Types in Text Analytics API</see>. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/EntitiesRecognitionGeneral">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual Response GetEntities(RequestContent body, string modelVersion = null, bool? showStats = null, string stringIndexType = null, CancellationToken cancellationToken = default)
        {
            Request req = GetEntitiesRequest(body, modelVersion, showStats, stringIndexType);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary>
        /// The API returns a list of general named entities in a given document. For the list of supported entity types,
        /// check <see href="https://aka.ms/taner">Supported Entity Types in Text Analytics API</see>. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/EntitiesRecognitionGeneral">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        protected virtual Request GetEntitiesRequest(RequestContent body, string modelVersion = null, bool? showStats = null, string stringIndexType = null)
        {
            Request req = Pipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.1-preview.1/entities/recognition/general", false);

            req.Content = body;

            if (modelVersion != null)
            {
                uriBuilder.AppendQuery("model-version", modelVersion);
            }

            if (showStats.HasValue)
            {
                uriBuilder.AppendQuery("showStats", showStats.Value ? "true" : "false");
            }

            if (stringIndexType != null)
            {
                uriBuilder.AppendQuery("stringIndexType", stringIndexType);
            }

            req.Uri = uriBuilder;
            req.Headers.SetValue("Content-Type", "application/json");
            req.Headers.SetValue("Accept", "application/json");

            return req;
        }

        /// <summary>
        /// The API returns a list of recognized entities with links to a well-known knowledge base. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/EntitiesLinking">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<Response> GetLinkedEntitiesAsync(RequestContent body, string modelVersion = null, bool? showStats = null, string stringIndexType = null, CancellationToken cancellationToken = default)
        {
            Request req = GetLinkedEntitiesRequest(body, modelVersion, showStats, stringIndexType);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The API returns a list of recognized entities with links to a well-known knowledge base. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/EntitiesLinking">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual Response GetLinkedEntities(RequestContent body, string modelVersion = null, bool? showStats = null, string stringIndexType = null, CancellationToken cancellationToken = default)
        {
            Request req = GetLinkedEntitiesRequest(body, modelVersion, showStats, stringIndexType);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary>
        /// The API returns a list of recognized entities with links to a well-known knowledge base. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/EntitiesLinking">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        protected virtual Request GetLinkedEntitiesRequest(RequestContent body, string modelVersion = null, bool? showStats = null, string stringIndexType = null)
        {
            Request req = Pipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.1-preview.1/entities/linking", false);

            req.Content = body;

            if (modelVersion != null)
            {
                uriBuilder.AppendQuery("model-version", modelVersion);
            }

            if (showStats.HasValue)
            {
                uriBuilder.AppendQuery("showStats", showStats.Value ? "true" : "false");
            }

            if (stringIndexType != null)
            {
                uriBuilder.AppendQuery("stringIndexType", stringIndexType);
            }

            req.Uri = uriBuilder;
            req.Headers.SetValue("Content-Type", "application/json");
            req.Headers.SetValue("Accept", "application/json");

            return req;
        }

        /// <summary>
        /// The API returns a list of strings denoting the key phrases in the input text. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/KeyPhrases">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<Response> GetKeyPhrasesAsync(RequestContent body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            Request req = GetKeyPhrasesRequest(body, modelVersion, showStats);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The API returns a list of strings denoting the key phrases in the input text. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/KeyPhrases">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual Response GetKeyPhrases(RequestContent body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            Request req = GetKeyPhrasesRequest(body, modelVersion, showStats);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary>
        /// The API returns a list of strings denoting the key phrases in the input text. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/KeyPhrases">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        protected virtual Request GetKeyPhrasesRequest(RequestContent body, string modelVersion = null, bool? showStats = null)
        {
            Request req = Pipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.1-preview.1/keyPhrases", false);

            req.Content = body;

            if (modelVersion != null)
            {
                uriBuilder.AppendQuery("model-version", modelVersion);
            }

            if (showStats.HasValue)
            {
                uriBuilder.AppendQuery("showStats", showStats.Value ? "true" : "false");
            }

            req.Uri = uriBuilder;
            req.Headers.SetValue("Content-Type", "application/json");
            req.Headers.SetValue("Accept", "application/json");

            return req;
        }

        /// <summary>
        /// The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty
        /// that the identified language is true. See the<see href="https://aka.ms/talangs">Supported languages in Text
        /// Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/Languages">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<Response> GetLanguagesAsync(RequestContent body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            Request req = GetLanguagesRequest(body, modelVersion, showStats);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty
        /// that the identified language is true. See the<see href="https://aka.ms/talangs">Supported languages in Text
        /// Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/Languages">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual Response GetLanguages(RequestContent body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            Request req = GetLanguagesRequest(body, modelVersion, showStats);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary>
        /// The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty
        /// that the identified language is true. See the<see href="https://aka.ms/talangs">Supported languages in Text
        /// Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/Languages">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        protected virtual Request GetLanguagesRequest(RequestContent body, string modelVersion = null, bool? showStats = null)
        {
            Request req = Pipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.1-preview.1/languages", false);

            req.Content = body;

            if (modelVersion != null)
            {
                uriBuilder.AppendQuery("model-version", modelVersion);
            }

            if (showStats.HasValue)
            {
                uriBuilder.AppendQuery("showStats", showStats.Value ? "true" : "false");
            }

            req.Uri = uriBuilder;
            req.Headers.SetValue("Content-Type", "application/json");
            req.Headers.SetValue("Accept", "application/json");

            return req;
        }

        /// <summary>
        /// The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral
        /// for the document and each sentence within it. See the <see href="https://aka.ms/talangs">Supported languages in Text
        /// Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="opinionMining">if set to true, response will contain input and document level statistics including aspect-based sentiment analysis results.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/Sentiment">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<Response> GetSentimentAsync(RequestContent body, string modelVersion = null, bool? showStats = null, bool? opinionMining = null, string stringIndexType = null, CancellationToken cancellationToken = default)
        {
            Request req = GetSentimentRequest(body, modelVersion, showStats, opinionMining, stringIndexType);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral
        /// for the document and each sentence within it. See the <see href="https://aka.ms/talangs">Supported languages in Text
        /// Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="opinionMining">if set to true, response will contain input and document level statistics including aspect-based sentiment analysis results.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/Sentiment">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual Response GetSentiment(RequestContent body, string modelVersion = null, bool? showStats = null, bool? opinionMining = false, string stringIndexType = null, CancellationToken cancellationToken = default)
        {
            Request req = GetSentimentRequest(body, modelVersion, showStats, opinionMining, stringIndexType);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary>
        /// The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral
        /// for the document and each sentence within it. See the <see href="https://aka.ms/talangs">Supported languages in Text
        /// Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="opinionMining">if set to true, response will contain input and document level statistics including aspect-based sentiment analysis results.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview.1/operations/Sentiment">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        protected virtual Request GetSentimentRequest(RequestContent body, string modelVersion = null, bool? showStats = null, bool? opinionMining = false, string stringIndexType = null)
        {
            Request req = Pipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.1-preview.1/sentiment", false);

            req.Content = body;

            if (modelVersion != null)
            {
                uriBuilder.AppendQuery("model-version", modelVersion);
            }

            if (showStats.HasValue)
            {
                uriBuilder.AppendQuery("showStats", showStats.Value ? "true" : "false");
            }

            if (opinionMining.HasValue)
            {
                uriBuilder.AppendQuery("opinionMining", opinionMining.Value ? "true" : "false");
            }

            if (stringIndexType != null)
            {
                uriBuilder.AppendQuery("stringIndexType", stringIndexType);
            }

            req.Uri = uriBuilder;
            req.Headers.SetValue("Content-Type", "application/json");
            req.Headers.SetValue("Accept", "application/json");

            return req;
        }

        /// <summary>
        /// The API returns a list of entities with personal information ("SSN", "Bank Account" etc) in the document. For the list
        /// of supported entity types, check <see href="https://aka.ms/tanerpii">Supported Entity Types in Text Analytics API</see>.
        /// See the <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled
        /// languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="domain">if set to 'PHI', response will contain only PHI entities.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview-1/operations/EntitiesRecognitionPii">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<Response> GetEntitiesPiiAsync(RequestContent body, string modelVersion = null, bool? showStats = null, string domain = null, string stringIndexType = null, CancellationToken cancellationToken = default)
        {
            Request req = GetEntitiesPiiRequest(body, modelVersion, showStats, domain, stringIndexType);
            return await Pipeline.SendRequestAsync(req, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// The API returns a list of entities with personal information ("SSN", "Bank Account" etc) in the document. For the list
        /// of supported entity types, check <see href="https://aka.ms/tanerpii">Supported Entity Types in Text Analytics API</see>.
        /// See the <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled
        /// languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="domain">if set to 'PHI', response will contain only PHI entities.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview-1/operations/EntitiesRecognitionPii">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual Response GetEntitiesPii(RequestContent body, string modelVersion = null, bool? showStats = null, string domain = null, string stringIndexType = null, CancellationToken cancellationToken = default)
        {
            Request req = GetEntitiesPiiRequest(body, modelVersion, showStats, domain, stringIndexType);
            return Pipeline.SendRequest(req, cancellationToken);
        }

        /// <summary>
        /// The API returns a list of entities with personal information ("SSN", "Bank Account" etc) in the document. For the list
        /// of supported entity types, check <see href="https://aka.ms/tanerpii">Supported Entity Types in Text Analytics API</see>.
        /// See the <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled
        /// languages.
        /// </summary>
        /// <param name="body">The request body</param>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <param name="domain">if set to 'PHI', response will contain only PHI entities.</param>
        /// <param name="stringIndexType">Specifies the method used to interpret string offsets. Defaults to Text Elements (Graphemes)
        /// according to Unicode v8.0.0. For additional information see <see href="https://aka.ms/text-analytics-offsets"/>.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-1-preview-1/operations/EntitiesRecognitionPii">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        protected virtual Request GetEntitiesPiiRequest(RequestContent body, string modelVersion = null, bool? showStats = null, string domain = null, string stringIndexType = null)
        {
            Request req = Pipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.1-preview.1/entities/recognition/pii", false);

            req.Content = body;

            if (modelVersion != null)
            {
                uriBuilder.AppendQuery("model-version", modelVersion);
            }

            if (showStats.HasValue)
            {
                uriBuilder.AppendQuery("showStats", showStats.Value ? "true" : "false");
            }

            if (domain != null)
            {
                uriBuilder.AppendQuery("domain", domain);
            }

            if (stringIndexType != null)
            {
                uriBuilder.AppendQuery("stringIndexType", stringIndexType);
            }

            req.Uri = uriBuilder;
            req.Headers.SetValue("Content-Type", "application/json");
            req.Headers.SetValue("Accept", "application/json");

            return req;
        }
    }
}
