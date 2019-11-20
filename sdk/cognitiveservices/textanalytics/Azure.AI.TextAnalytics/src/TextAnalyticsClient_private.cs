// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics
{
    public partial class TextAnalyticsClient
    {
        private const string TextAnalyticsRoute = "/text/analytics/";

        private const string LanguagesRoute = "/languages";
        private const string EntitiesRoute = "/entities/recognition/general";
        private const string PiiEntitiesRoute = "/entities/recognition/pii";
        private const string SentimentRoute = "/sentiment";
        private const string KeyPhrasesRoute = "/keyPhrases";
        private const string EntityLinkingRoute = "/entities/linking";

        private const string ShowStatistics = "showStats";
        private const string ModelVersion = "model-version";

        #region Detect Language
        private static async Task<Response<DocumentResultCollection<DetectedLanguage>>> CreateDetectLanguageResponseAsync(Response response, CancellationToken cancellation)
        {
            DocumentResultCollection<DetectedLanguage> result = await TextAnalyticsServiceSerializer.DeserializeDetectLanguageResponseAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<DocumentResultCollection<DetectedLanguage>> CreateDetectLanguageResponse(Response response) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeDetectLanguageResponse(response.ContentStream), response);

        private static async Task<Response<IEnumerable<DetectedLanguage>>> CreateDetectLanguageResponseSimpleAsync(Response response, CancellationToken cancellation)
        {
            IEnumerable<DetectedLanguage> result = await TextAnalyticsServiceSerializer.DeserializeDetectedLanguageCollectionAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<IEnumerable<DetectedLanguage>> CreateDetectLanguageResponseSimple(Response response) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeDetectedLanguageCollection(response.ContentStream), response);

        private static Response<DetectedLanguage> CreateDetectedLanguageResponseSimple(Response response, DetectedLanguage detectedLanguage) =>
            Response.FromValue(detectedLanguage, response);

        #endregion

        #region Recognize Entities
        private static async Task<Response<DocumentResultCollection<NamedEntity>>> CreateRecognizeEntitiesResponseAsync(Response response, CancellationToken cancellation)
        {
            DocumentResultCollection<NamedEntity> result = await TextAnalyticsServiceSerializer.DeserializeRecognizeEntitiesResponseAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<DocumentResultCollection<NamedEntity>> CreateRecognizeEntitiesResponse(Response response) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeRecognizeEntitiesResponse(response.ContentStream), response);

        private static async Task<Response<IEnumerable<IEnumerable<NamedEntity>>>> CreateRecognizeEntitiesResponseSimpleAsync(Response response, CancellationToken cancellation)
        {
            var result = await TextAnalyticsServiceSerializer.DeserializeEntityCollectionAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<IEnumerable<IEnumerable<NamedEntity>>> CreateRecognizeEntitiesResponseSimple(Response response) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeEntityCollection(response.ContentStream), response);

        private static Response<IEnumerable<NamedEntity>> CreateRecognizeEntitiesResponseSimple(Response response, IEnumerable<NamedEntity> entities) =>
            Response.FromValue(entities, response);

        #endregion

        #region Analyze Sentiment
        private static async Task<Response<SentimentResultCollection>> CreateAnalyzeSentimentResponseAsync(Response response, CancellationToken cancellation)
        {
            SentimentResultCollection result = await TextAnalyticsServiceSerializer.DeserializeAnalyzeSentimentResponseAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<SentimentResultCollection> CreateAnalyzeSentimentResponse(Response response) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeAnalyzeSentimentResponse(response.ContentStream), response);

        private static async Task<Response<IEnumerable<Sentiment>>> CreateAnalyzeSentimentResponseSimpleAsync(Response response, CancellationToken cancellation)
        {
            var result = await TextAnalyticsServiceSerializer.DeserializeSentimentCollectionAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<IEnumerable<Sentiment>> CreateAnalyzeSentimentResponseSimple(Response response) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeSentimentCollection(response.ContentStream), response);

        private static Response<Sentiment> CreateAnalyzeSentimentResponseSimple(Response response, Sentiment sentiment) =>
            Response.FromValue(sentiment, response);

        #endregion  Analyze Sentiment

        #region Extract KeyPhrases
        private static async Task<Response<DocumentResultCollection<string>>> CreateKeyPhraseResponseAsync(Response response, CancellationToken cancellation)
        {
            DocumentResultCollection<string> result = await TextAnalyticsServiceSerializer.DeserializeKeyPhraseResponseAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<DocumentResultCollection<string>> CreateKeyPhraseResponse(Response response) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeKeyPhraseResponse(response.ContentStream), response);

        private static async Task<Response<IEnumerable<IEnumerable<string>>>> CreateKeyPhraseResponseSimpleAsync(Response response, CancellationToken cancellation)
        {
            var result = await TextAnalyticsServiceSerializer.DeserializeKeyPhraseCollectionAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<IEnumerable<IEnumerable<string>>> CreateKeyPhraseResponseSimple(Response response) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeKeyPhraseCollection(response.ContentStream), response);

        private static Response<IEnumerable<string>> CreateKeyPhraseResponseSimple(Response response, IEnumerable<string> keyPhrases) =>
            Response.FromValue(keyPhrases, response);

        #endregion Extract KeyPhrases

        #region Entity Linking
        private static async Task<Response<DocumentResultCollection<LinkedEntity>>> CreateLinkedEntityResponseAsync(Response response, CancellationToken cancellation)
        {
            DocumentResultCollection<LinkedEntity> result = await TextAnalyticsServiceSerializer.DeserializeLinkedEntityResponseAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<DocumentResultCollection<LinkedEntity>> CreateLinkedEntityResponse(Response response) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeLinkedEntityResponse(response.ContentStream), response);

        private static async Task<Response<IEnumerable<IEnumerable<LinkedEntity>>>> CreateLinkedEntityResponseSimpleAsync(Response response, CancellationToken cancellation)
        {
            var result = await TextAnalyticsServiceSerializer.DeserializeLinkedEntityCollectionAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<IEnumerable<IEnumerable<LinkedEntity>>> CreateLinkedEntityResponseSimple(Response response) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeLinkedEntityCollection(response.ContentStream), response);

        private static Response<IEnumerable<LinkedEntity>> CreateLinkedEntityResponseSimple(Response response, IEnumerable<LinkedEntity> entities) =>
            Response.FromValue(entities, response);

        #endregion

        private void BuildUriForRoute(string route, RequestUriBuilder builder, TextAnalyticsRequestOptions options)
        {
            builder.Reset(_baseUri);
            builder.AppendPath(TextAnalyticsRoute, escape: false);
            builder.AppendPath(_apiVersion, escape: false);
            builder.AppendPath(route, escape: false);

            if (options.ShowStatistics)
            {
                builder.AppendQuery(ShowStatistics, "true");
            }

            if (!string.IsNullOrEmpty(options.ModelVersion))
            {
                builder.AppendQuery(ModelVersion, options.ModelVersion);
            }
        }

        #region nobody wants to see these
        /// <summary>
        /// Check if two ConfigurationSetting instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the ConfigurationSetting
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Creates a Key Value string in reference to the ConfigurationSetting.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
