// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics
{
    public partial class TextAnalyticsClient
    {
        private const string TextAnalyticsRoute = "/text/analytics/";
        private const string LanguagesRoute = "/languages";

        //private const string AcceptDateTimeFormat = "R";
        //private const string AcceptDatetimeHeader = "Accept-Datetime";
        //private const string RevisionsRoute = "/revisions/";
        //private const string LocksRoute = "/locks/";
        //private const string KeyQueryFilter = "key";
        //private const string LabelQueryFilter = "label";
        //private const string FieldsQueryFilter = "$select";

        private static async Task<Response<LanguageResult>> CreateLanguageResponseAsync(Response response, CancellationToken cancellation)
        {
            LanguageResult result = await TextAnalyticsServiceSerializer.DeserializeLanguageResponseAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<LanguageResult> CreateLanguageResponse(Response response)
        {
            return Response.FromValue(TextAnalyticsServiceSerializer.DeserializeLanguageResponse(response.ContentStream), response);
        }

        private void BuildUriForLanguagesRoute(RequestUriBuilder builder)
        {
            builder.Reset(_baseUri);
            builder.AppendPath(TextAnalyticsRoute, escape: false);
            builder.AppendPath(_apiVersion, escape:false);
            builder.AppendPath(LanguagesRoute, escape: false);

            // TODO: handle stats and model-version
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
