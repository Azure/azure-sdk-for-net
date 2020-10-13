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

        private const string EntitiesRoute = "/entities/recognition/general";
        private const string SentimentRoute = "/sentiment";
        private const string KeyPhrasesRoute = "/keyPhrases";
        private const string EntityLinkingRoute = "/entities/linking";

        private const string ShowStatistics = "showStats";
        private const string ModelVersion = "model-version";

        private const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        #region Recognize Entities
        private static async Task<Response<RecognizeEntitiesResultCollection>> CreateRecognizeEntitiesResponseAsync(Response response, IDictionary<string, int> idToIndexMap, CancellationToken cancellation)
        {
            RecognizeEntitiesResultCollection result = await TextAnalyticsServiceSerializer.DeserializeRecognizeEntitiesResponseAsync(response.ContentStream, idToIndexMap, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<RecognizeEntitiesResultCollection> CreateRecognizeEntitiesResponse(Response response, IDictionary<string, int> idToIndexMap) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeRecognizeEntitiesResponse(response.ContentStream, idToIndexMap), response);

        #endregion

        #region Analyze Sentiment
        private static async Task<Response<AnalyzeSentimentResultCollection>> CreateAnalyzeSentimentResponseAsync(Response response, IDictionary<string, int> idToIndexMap, CancellationToken cancellation)
        {
            AnalyzeSentimentResultCollection result = await TextAnalyticsServiceSerializer.DeserializeAnalyzeSentimentResponseAsync(response.ContentStream, idToIndexMap, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<AnalyzeSentimentResultCollection> CreateAnalyzeSentimentResponse(Response response, IDictionary<string, int> idToIndexMap) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeAnalyzeSentimentResponse(response.ContentStream, idToIndexMap), response);

        #endregion  Analyze Sentiment

        #region Extract KeyPhrases
        private static async Task<Response<ExtractKeyPhrasesResultCollection>> CreateKeyPhraseResponseAsync(Response response, IDictionary<string, int> idToIndexMap, CancellationToken cancellation)
        {
            ExtractKeyPhrasesResultCollection result = await TextAnalyticsServiceSerializer.DeserializeKeyPhraseResponseAsync(response.ContentStream, idToIndexMap, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<ExtractKeyPhrasesResultCollection> CreateKeyPhraseResponse(Response response, IDictionary<string, int> idToIndexMap) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeKeyPhraseResponse(response.ContentStream, idToIndexMap), response);

        #endregion Extract KeyPhrases

        #region Linked Entities
        private static async Task<Response<RecognizeLinkedEntitiesResultCollection>> CreateLinkedEntityResponseAsync(Response response, IDictionary<string, int> idToIndexMap, CancellationToken cancellation)
        {
            RecognizeLinkedEntitiesResultCollection result = await TextAnalyticsServiceSerializer.DeserializeLinkedEntityResponseAsync(response.ContentStream, idToIndexMap, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<RecognizeLinkedEntitiesResultCollection> CreateLinkedEntityResponse(Response response, IDictionary<string, int> idToIndexMap) =>
            Response.FromValue(TextAnalyticsServiceSerializer.DeserializeLinkedEntityResponse(response.ContentStream, idToIndexMap), response);

        #endregion

        private void BuildUriForRoute(string route, RequestUriBuilder builder, TextAnalyticsRequestOptions options)
        {
            builder.Reset(_baseUri);
            builder.AppendPath(TextAnalyticsRoute, escape: false);
            builder.AppendPath(_apiVersion, escape: false);
            builder.AppendPath(route, escape: false);

            if (options.IncludeStatistics)
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
        /// Check if two TextAnalyticsClient instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the TextAnalyticsClient.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// TextAnalyticsClient ToString.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
