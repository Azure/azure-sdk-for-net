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

        #region Commented out from AppConfig

        //private static Response<ConfigurationSetting> CreateResourceModifiedResponse(Response response)
        //{
        //    return new NoBodyResponse<ConfigurationSetting>(response);
        //}

        //private void BuildUriForKvRoute(RequestUriBuilder builder, ConfigurationSetting keyValue)
        //    => BuildUriForKvRoute(builder, keyValue.Key, keyValue.Label); // TODO (pri 2) : does this need to filter ETag?

        //private void BuildUriForKvRoute(RequestUriBuilder builder, string key, string label)
        //{
        //    builder.Reset(_baseUri);
        //    builder.AppendPath(KvRoute, escape: false);
        //    builder.AppendPath(key);

        //    if (label != null)
        //    {
        //        builder.AppendQuery(LabelQueryFilter, label);
        //    }
        //}

        //private void BuildUriForLocksRoute(RequestUriBuilder builder, string key, string label)
        //{
        //    builder.Reset(_baseUri);
        //    builder.AppendPath(LocksRoute, escape: false);
        //    builder.AppendPath(key);

        //    if (label != null)
        //    {
        //        builder.AppendQuery(LabelQueryFilter, label);
        //    }
        //}

        //private static string EscapeReservedCharacters(string input)
        //{
        //    string resp = string.Empty;
        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        if (s_reservedCharacters.Contains(input[i]))
        //        {
        //            resp += $"\\{input[i]}";
        //        }
        //        else
        //        {
        //            resp += input[i];
        //        }
        //    }
        //    return resp;
        //}

        //internal static void BuildBatchQuery(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        //{
        //    if (selector.Keys.Count > 0)
        //    {
        //        var keysCopy = new List<string>();
        //        foreach (var key in selector.Keys)
        //        {
        //            if (key.IndexOfAny(s_reservedCharacters) != -1)
        //            {
        //                keysCopy.Add(EscapeReservedCharacters(key));
        //            }
        //            else
        //            {
        //                keysCopy.Add(key);
        //            }
        //        }
        //        var keys = string.Join(",", keysCopy);
        //        builder.AppendQuery(KeyQueryFilter, keys);
        //    }

        //    if (selector.Labels.Count > 0)
        //    {
        //        var labelsCopy = selector.Labels.Select(label => string.IsNullOrEmpty(label) ? "\0" : EscapeReservedCharacters(label));
        //        var labels = string.Join(",", labelsCopy);
        //        builder.AppendQuery(LabelQueryFilter, labels);
        //    }

        //    if (selector.Fields != SettingFields.All)
        //    {
        //        var filter = selector.Fields.ToString().ToLowerInvariant().Replace("isreadonly", "locked");
        //        builder.AppendQuery(FieldsQueryFilter, filter);
        //    }

        //    if (!string.IsNullOrEmpty(pageLink))
        //    {
        //        builder.AppendQuery("after", pageLink, escapeValue: false);
        //    }
        //}

        //private void BuildUriForGetBatch(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        //{
        //    builder.Reset(_baseUri);
        //    builder.AppendPath(KvRoute, escape: false);
        //    BuildBatchQuery(builder, selector, pageLink);
        //}

        //private void BuildUriForRevisions(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        //{
        //    builder.Reset(_baseUri);
        //    builder.AppendPath(RevisionsRoute, escape: false);
        //    BuildBatchQuery(builder, selector, pageLink);
        //}

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
