// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics
{
    public partial class TextAnalyticsClient
    {
        private const string TextAnalyticsRoute = "/text/analytics/";
        private const string LanguagesRoute = "/languages";
        private const string ShowStats = "showStats";
        private const string ModelVersion = "model-version";

        private static async Task<TextAnalyticsResultPage<DetectedLanguage>> CreateLanguageResponseAsync(Response response, CancellationToken cancellation)
        {
            TextAnalyticsResultPage<DetectedLanguage> result = await TextAnalyticsServiceSerializer.DeserializeDetectLanguageResponseAsync(response, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<TextAnalyticsResultPage<DetectedLanguage>> CreateDetectLanguageResponse(Response response)
        {
            return Response.FromValue(TextAnalyticsServiceSerializer.DeserializeDetectLanguageResponse(response), response);
        }

        private static Response<DetectedLanguage> CreateDetectedLanguageResponseSimple(Response response, DetectedLanguage detectedLanguage)
        {
            return Response.FromValue(detectedLanguage, response);
        }

        private void BuildUriForLanguagesRoute(RequestUriBuilder builder, bool showStats, string modelVersion)
        {
            builder.Reset(_baseUri);
            builder.AppendPath(TextAnalyticsRoute, escape: false);
            builder.AppendPath(_apiVersion, escape:false);
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
