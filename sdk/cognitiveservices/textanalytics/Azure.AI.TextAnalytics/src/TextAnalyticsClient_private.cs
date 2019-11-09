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

        private const string ShowStats = "showStats";
        private const string ModelVersion = "model-version";

        private const string LanguagesRoute = "/languages";
        private const string EntitiesRoute = "/entities/recognition/general";

        #region Detect Language
        private static async Task<Response<DocumentResultCollection<DetectedLanguage>>> CreateDetectLanguageResponseAsync(Response response, CancellationToken cancellation)
        {
            DocumentResultCollection<DetectedLanguage> result = await TextAnalyticsServiceSerializer.DeserializeDetectLanguageResponseAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<DocumentResultCollection<DetectedLanguage>> CreateDetectLanguageResponse(Response response)
        {
            return Response.FromValue(TextAnalyticsServiceSerializer.DeserializeDetectLanguageResponse(response.ContentStream), response);
        }

        private static async Task<Response<IEnumerable<DetectedLanguage>>> CreateDetectLanguageResponseSimpleAsync(Response response, CancellationToken cancellation)
        {
            IEnumerable<DetectedLanguage> result = await TextAnalyticsServiceSerializer.DeserializeDetectedLanguageBatchSimpleAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<IEnumerable<DetectedLanguage>> CreateDetectLanguageResponseSimple(Response response)
        {
            return Response.FromValue(TextAnalyticsServiceSerializer.DeserializeDetectedLanguageBatchSimple(response.ContentStream), response);
        }

        // TODO: Add Async Variant of this
        private static Response<DetectedLanguage> CreateDetectedLanguageResponseSimple(Response response, DetectedLanguage detectedLanguage)
        {
            return Response.FromValue(detectedLanguage, response);
        }

        private void BuildUriForLanguagesRoute(RequestUriBuilder builder, bool showStats, string modelVersion)
        {
            builder.Reset(_baseUri);
            builder.AppendPath(TextAnalyticsRoute, escape: false);
            builder.AppendPath(_apiVersion, escape: false);
            builder.AppendPath(LanguagesRoute, escape: false);

            if (showStats)
            {
                builder.AppendQuery(ShowStats, "true");
            }

            if (!string.IsNullOrEmpty(modelVersion))
            {
                builder.AppendQuery(ModelVersion, modelVersion);
            }
        }
        #endregion

        #region Recognize Entities
        private static async Task<Response<DocumentResultCollection<Entity>>> CreateRecognizeEntitiesResponseAsync(Response response, CancellationToken cancellation)
        {
            DocumentResultCollection<Entity> result = await TextAnalyticsServiceSerializer.DeserializeRecognizeEntitiesResponseAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<DocumentResultCollection<Entity>> CreateRecognizeEntitiesResponse(Response response)
        {
            return Response.FromValue(TextAnalyticsServiceSerializer.DeserializeRecognizeEntitiesResponse(response.ContentStream), response);
        }

        private static Response<IEnumerable<Entity>> CreateRecognizeEntitiesResponseSimple(Response response, IEnumerable<Entity> entities)
        {
            return Response.FromValue(entities, response);
        }

        private void BuildUriForEntitiesRoute(RequestUriBuilder builder, bool showStats, string modelVersion)
        {
            builder.Reset(_baseUri);
            builder.AppendPath(TextAnalyticsRoute, escape: false);
            builder.AppendPath(_apiVersion, escape: false);
            builder.AppendPath(EntitiesRoute, escape: false);

            if (showStats)
            {
                builder.AppendQuery(ShowStats, "true");
            }

            if (!string.IsNullOrEmpty(modelVersion))
            {
                builder.AppendQuery(ModelVersion, modelVersion);
            }
        }
        #endregion


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
