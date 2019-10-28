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

            uri = default;
            credential = default;
            secret = default;

            // Parse connection string
            string[] args = connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (args.Length < 3)
            {
                throw new ArgumentException("invalid connection string segment count", nameof(connectionString));
            }

            const string endpointString = "Endpoint=";
            const string idString = "Id=";
            const string secretString = "Secret=";

            // TODO (pri 2): this allows elements in the connection string to be in varied order. Should we disallow it?
            // TODO (pri 2): this parser will succeed even if one of the elements is missing (e.g. if cs == "a;b;c". We should fix that.
            foreach (var arg in args)
            {
                var segment = arg.Trim();
                if (segment.StartsWith(endpointString, StringComparison.OrdinalIgnoreCase))
                {
                    uri = new Uri(segment.Substring(segment.IndexOf('=') + 1));
                }
                else if (segment.StartsWith(idString, StringComparison.OrdinalIgnoreCase))
                {
                    credential = segment.Substring(segment.IndexOf('=') + 1);
                }
                else if (segment.StartsWith(secretString, StringComparison.OrdinalIgnoreCase))
                {
                    var secretBase64 = segment.Substring(segment.IndexOf('=') + 1);
                    // TODO (pri 2): this might throw an obscure exception. Should we throw a consisten exception when the parser fails?
                    secret = Convert.FromBase64String(secretBase64);
                }
            };
        }

        private void BuildUriForKvRoute(RequestUriBuilder builder, ConfigurationSetting keyValue)
            => BuildUriForKvRoute(builder, keyValue.Key, keyValue.Label); // TODO (pri 2) : does this need to filter ETag?

        private void BuildUriForKvRoute(RequestUriBuilder builder, string key, string label)
        {
            builder.Reset(_baseUri);
            builder.AppendPath(KvRoute, escape: false);
            builder.AppendPath(key);

            if (label != null)
            {
                builder.AppendQuery(LabelQueryFilter, label);
            }
        }

        private void BuildUriForLocksRoute(RequestUriBuilder builder, string key, string label)
        {
            builder.Reset(_baseUri);
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
            if (selector.Keys.Count > 0)
            {
                var keysCopy = new List<string>();
                foreach (var key in selector.Keys)
                {
                    if (key.IndexOfAny(s_reservedCharacters) != -1)
                    {
                        keysCopy.Add(EscapeReservedCharacters(key));
                    }
                    else
                    {
                        keysCopy.Add(key);
                    }
                }
                var keys = string.Join(",", keysCopy);
                builder.AppendQuery(KeyQueryFilter, keys);
            }

            if (selector.Labels.Count > 0)
            {
                var labelsCopy = selector.Labels.Select(label => string.IsNullOrEmpty(label) ? "\0" : EscapeReservedCharacters(label));
                var labels = string.Join(",", labelsCopy);
                builder.AppendQuery(LabelQueryFilter, labels);
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
            builder.Reset(_baseUri);
            builder.AppendPath(KvRoute, escape: false);
            BuildBatchQuery(builder, selector, pageLink);
        }

        private void BuildUriForRevisions(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        {
            builder.Reset(_baseUri);
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
