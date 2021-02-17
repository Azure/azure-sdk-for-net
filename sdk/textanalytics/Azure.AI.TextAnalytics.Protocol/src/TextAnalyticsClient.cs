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
        private HttpPipeline HttpPipeline { get; }
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
            HttpPipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, AuthorizationHeader));
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/EntitiesRecognitionGeneral">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<DynamicResponse> GetEntitiesAsync(JsonData body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetEntitiesRequest();

            req.Content = DynamicContent.Create(body);
            return await req.SendAsync(cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/EntitiesRecognitionGeneral">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<DynamicResponse> GetEntitiesAsync(dynamic body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetEntitiesRequest();

            req.Content = DynamicContent.Create(ToJsonData(body));
            return await req.SendAsync(cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/EntitiesRecognitionGeneral">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicResponse GetEntities(JsonData body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetEntitiesRequest(modelVersion, showStats);
            req.Content = DynamicContent.Create(body);

            return req.Send(cancellationToken);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/EntitiesRecognitionGeneral">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicResponse GetEntities(dynamic body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetEntitiesRequest(modelVersion, showStats);
            req.Content = DynamicContent.Create(ToJsonData(body));

            return req.Send(cancellationToken);
        }

        /// <summary>
        /// The API returns a list of general named entities in a given document. For the list of supported entity types,
        /// check <see href="https://aka.ms/taner">Supported Entity Types in Text Analytics API</see>. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/EntitiesRecognitionGeneral">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicRequest GetEntitiesRequest(string modelVersion = null, bool? showStats = null)
        {
            Request req = HttpPipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.0/entities/recognition/general", false);

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

            return new DynamicRequest(req, HttpPipeline);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/EntitiesLinking">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<DynamicResponse> GetLinkedEntitiesAsync(JsonData body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetLinkedEntitiesRequest();
            req.Content = DynamicContent.Create(body);

            return await req.SendAsync(cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/EntitiesLinking">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<DynamicResponse> GetLinkedEntitiesAsync(dynamic body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetLinkedEntitiesRequest();
            req.Content = DynamicContent.Create(ToJsonData(body));

            return await req.SendAsync(cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/EntitiesLinking">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicResponse GetLinkedEntities(JsonData body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetLinkedEntitiesRequest(modelVersion, showStats);
            req.Content = DynamicContent.Create(body);

            return req.Send(cancellationToken);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/EntitiesLinking">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicResponse GetLinkedEntities(dynamic body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetLinkedEntitiesRequest(modelVersion, showStats);
            req.Content = DynamicContent.Create(ToJsonData(body));

            return req.Send(cancellationToken);
        }

        /// <summary>
        /// The API returns a list of recognized entities with links to a well-known knowledge base. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/EntitiesLinking">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicRequest GetLinkedEntitiesRequest(string modelVersion = null, bool? showStats = null)
        {
            Request req = HttpPipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.0/entities/linking", false);

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

            return new DynamicRequest(req, HttpPipeline);
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
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/KeyPhrases">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<DynamicResponse> GetKeyPhrasesAsync(JsonData body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetKeyPhrasesRequest();
            req.Content = DynamicContent.Create(body);

            return await req.SendAsync(cancellationToken).ConfigureAwait(false);
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
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/KeyPhrases">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<DynamicResponse> GetKeyPhrasesAsync(dynamic body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetKeyPhrasesRequest();
            req.Content = DynamicContent.Create(ToJsonData(body));

            return await req.SendAsync(cancellationToken).ConfigureAwait(false);
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
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/KeyPhrases">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicResponse GetKeyPhrases(JsonData body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetKeyPhrasesRequest(modelVersion, showStats);
            req.Content = DynamicContent.Create(body);

            return req.Send(cancellationToken);
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
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/KeyPhrases">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicResponse GetKeyPhrases(dynamic body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetKeyPhrasesRequest(modelVersion, showStats);
            req.Content = DynamicContent.Create(ToJsonData(body));

            return req.Send(cancellationToken);
        }

        /// <summary>
        /// The API returns a list of strings denoting the key phrases in the input text. See the
        /// <see href="https://aka.ms/talangs">Supported languages in Text Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/KeyPhrases">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicRequest GetKeyPhrasesRequest(string modelVersion = null, bool? showStats = null)
        {
            Request req = HttpPipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.0/keyPhrases", false);

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

            return new DynamicRequest(req, HttpPipeline);
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
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Languages">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<DynamicResponse> GetLanguagesAsync(JsonData body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetLanguagesRequest();
            req.Content = DynamicContent.Create(body);

            return await req.SendAsync(cancellationToken).ConfigureAwait(false);
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
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Languages">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<DynamicResponse> GetLanguagesAsync(dynamic body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetLanguagesRequest();
            req.Content = DynamicContent.Create(ToJsonData(body));

            return await req.SendAsync(cancellationToken).ConfigureAwait(false);
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
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Languages">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicResponse GetLanguages(JsonData body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetLanguagesRequest(modelVersion, showStats);
            req.Content = DynamicContent.Create(body);

            return req.Send(cancellationToken);
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
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Languages">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicResponse GetLanguages(dynamic body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetLanguagesRequest(modelVersion, showStats);
            req.Content = DynamicContent.Create(ToJsonData(body));

            return req.Send(cancellationToken);
        }

        /// <summary>
        /// The API returns the detected language and a numeric score between 0 and 1. Scores close to 1 indicate 100% certainty
        /// that the identified language is true. See the<see href="https://aka.ms/talangs">Supported languages in Text
        /// Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Languages">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicRequest GetLanguagesRequest(string modelVersion = null, bool? showStats = null)
        {
            Request req = HttpPipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.0/languages", false);

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

            return new DynamicRequest(req, HttpPipeline);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Sentiment">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<DynamicResponse> GetSentimentAsync(JsonData body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetSentimentRequest();
            req.Content = DynamicContent.Create(body);

            return await req.SendAsync(cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// A task which represents the response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Sentiment">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual async Task<DynamicResponse> GetSentimentAsync(dynamic body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetSentimentRequest();
            req.Content = DynamicContent.Create(ToJsonData(body));

            return await req.SendAsync(cancellationToken).ConfigureAwait(false);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Sentiment">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicResponse GetSentiment(JsonData body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetSentimentRequest(modelVersion, showStats);
            req.Content = DynamicContent.Create(body);

            return req.Send(cancellationToken);
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
        /// <param name="cancellationToken">A token to check for cancellation.</param>
        /// <returns>
        /// The response of the operation.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Sentiment">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicResponse GetSentiment(dynamic body, string modelVersion = null, bool? showStats = null, CancellationToken cancellationToken = default)
        {
            DynamicRequest req = GetSentimentRequest(modelVersion, showStats);
            req.Content = DynamicContent.Create(ToJsonData(body));

            return req.Send(cancellationToken);
        }

        /// <summary>
        /// The API returns a sentiment prediction, as well as sentiment scores for each sentiment class (Positive, Negative, and Neutral
        /// for the document and each sentence within it. See the <see href="https://aka.ms/talangs">Supported languages in Text
        /// Analytics API</see> for the list of enabled languages.
        /// </summary>
        /// <param name="modelVersion">
        /// This value indicates which model will be used for scoring. If a modelVersion is not specified,
        /// the API should default to the latest, non-preview version.
        /// </param>
        /// <param name="showStats">if set to true, response will contain input and document level statistics.</param>
        /// <returns>
        /// A prepared request, without a body, which may be modified before sending.
        /// </returns>
        /// <remarks>
        /// The <see href="https://westus2.dev.cognitive.microsoft.com/docs/services/TextAnalytics-v3-0/operations/Sentiment">
        /// REST API Documentation</see> has more information on the body of the request and the response.
        /// </remarks>
        public virtual DynamicRequest GetSentimentRequest(string modelVersion = null, bool? showStats = null)
        {
            Request req = HttpPipeline.CreateRequest();
            req.Method = RequestMethod.Post;

            RequestUriBuilder uriBuilder = new RequestUriBuilder();
            uriBuilder.Reset(Endpoint);
            uriBuilder.AppendPath("text/analytics/v3.0/sentiment", false);

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

            return new DynamicRequest(req, HttpPipeline);
        }

        private static JsonData ToJsonData(object value)
        {
            if (value is JsonData) {
                return (JsonData)value;
            }

            return new JsonData(value);
        }
    }
}
