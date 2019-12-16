// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    public partial class ConfigurationClient
    {
        private const string AcceptDateTimeFormat = "R";
        private const string AcceptDatetimeHeader = "Accept-Datetime";
        private const string KvRoute = "/kv/";
        private const string RevisionsRoute = "/revisions/";
        private const string LocksRoute = "/locks/";
        private const string KeyQueryFilter = "key";
        private const string LabelQueryFilter = "label";
        private const string FieldsQueryFilter = "$select";

        private static readonly char[] s_reservedCharacters = new char[] { ',', '\\' };

        private static readonly HttpHeader s_mediaTypeKeyValueApplicationHeader = new HttpHeader(
            HttpHeader.Names.Accept,
            "application/vnd.microsoft.appconfig.kv+json"
        );

        private static async Task<Response<ConfigurationSetting>> CreateResponseAsync(Response response, CancellationToken cancellation)
        {
            ConfigurationSetting result = await ConfigurationServiceSerializer.DeserializeSettingAsync(response.ContentStream, cancellation).ConfigureAwait(false);
            return Response.FromValue(result, response);
        }

        private static Response<ConfigurationSetting> CreateResponse(Response response)
        {
            return Response.FromValue(ConfigurationServiceSerializer.DeserializeSetting(response.ContentStream), response);
        }

        private static Response<ConfigurationSetting> CreateResourceModifiedResponse(Response response)
        {
            return new NoBodyResponse<ConfigurationSetting>(response);
        }

        private static void ParseConnectionString(string connectionString, out Uri uri, out string credential, out byte[] secret)
        {
            Debug.Assert(connectionString != null); // callers check this

            var parsed = ConnectionString.Parse(connectionString);

            uri = new Uri(parsed.GetRequired("Endpoint"));
            credential = parsed.GetRequired("Id");
            try
            {
                secret = Convert.FromBase64String(parsed.GetRequired("Secret"));
            }
            catch (FormatException)
            {
                throw new InvalidOperationException("Specified Secret value isn't a valid base64 string");
            }
        }

        private void BuildUriForKvRoute(RequestUriBuilder builder, ConfigurationSetting keyValue)
            => BuildUriForKvRoute(builder, keyValue.Key, keyValue.Label); // TODO (pri 2) : does this need to filter ETag?

        private void BuildUriForKvRoute(RequestUriBuilder builder, string key, string label)
        {
            builder.Reset(_endpoint);
            builder.AppendPath(KvRoute, escape: false);
            builder.AppendPath(key);

            if (label != null)
            {
                builder.AppendQuery(LabelQueryFilter, label);
            }
        }

        private void BuildUriForLocksRoute(RequestUriBuilder builder, string key, string label)
        {
            builder.Reset(_endpoint);
            builder.AppendPath(LocksRoute, escape: false);
            builder.AppendPath(key);

            if (label != null)
            {
                builder.AppendQuery(LabelQueryFilter, label);
            }
        }

        private static string EscapeReservedCharacters(string input)
        {
            string resp = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                if (s_reservedCharacters.Contains(input[i]))
                {
                    resp += $"\\{input[i]}";
                }
                else
                {
                    resp += input[i];
                }
            }
            return resp;
        }

        internal static void BuildBatchQuery(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        {
            if (!string.IsNullOrEmpty(selector.KeyFilter))
            {
                builder.AppendQuery(KeyQueryFilter, selector.KeyFilter);
            }

            if (!string.IsNullOrEmpty(selector.LabelFilter))
            {
                builder.AppendQuery(LabelQueryFilter, selector.LabelFilter);
            }

            if (selector.Fields != SettingFields.All)
            {
                var filter = selector.Fields.ToString().ToLowerInvariant().Replace("isreadonly", "locked");
                builder.AppendQuery(FieldsQueryFilter, filter);
            }

            if (!string.IsNullOrEmpty(pageLink))
            {
                builder.AppendQuery("after", pageLink, escapeValue: false);
            }
        }

        private void BuildUriForGetBatch(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        {
            builder.Reset(_endpoint);
            builder.AppendPath(KvRoute, escape: false);
            BuildBatchQuery(builder, selector, pageLink);
        }

        private void BuildUriForRevisions(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        {
            builder.Reset(_endpoint);
            builder.AppendPath(RevisionsRoute, escape: false);
            BuildBatchQuery(builder, selector, pageLink);
        }

        #region nobody wants to see these
        /// <summary>
        /// Check if two ConfigurationSetting instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the ConfigurationSetting.
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
