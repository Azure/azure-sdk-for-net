// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Http;

namespace Azure.ApplicationModel.Configuration
{
    public partial class ConfigurationClient
    {
        const string MediaTypeProblemApplication = "application/problem+json";
        const string AcceptDateTimeFormat = "ddd, dd MMM yyy HH:mm:ss 'GMT'";
        const string AcceptDatetimeHeader = "Accept-Datetime";
        const string KvRoute = "/kv/";
        const string RevisionsRoute = "/revisions/";
        const string KeyQueryFilter = "key";
        const string LabelQueryFilter = "label";
        const string FieldsQueryFilter = "$select";
        const string IfMatchName = "If-Match";
        const string IfNoneMatch = "If-None-Match";

        static readonly char[] ReservedCharacters = new char[] { ',', '\\' };

        static readonly HttpHeader MediaTypeKeyValueApplicationHeader = new HttpHeader(
            HttpHeader.Names.Accept,
            "application/vnd.microsoft.appconfig.kv+json"
        );

        static async Task<Response<ConfigurationSetting>> CreateResponseAsync(Response response, CancellationToken cancellation)
        {
            ConfigurationSetting result = await ConfigurationServiceSerializer.DeserializeSettingAsync(response.ContentStream, cancellation);
            return new Response<ConfigurationSetting>(response, result);
        }

        static Response<ConfigurationSetting> CreateResponse(Response response, CancellationToken cancellation)
        {
            return new Response<ConfigurationSetting>(response, ConfigurationServiceSerializer.DeserializeSetting(response.ContentStream, cancellation));
        }

        static void ParseConnectionString(string connectionString, out Uri uri, out string credential, out byte[] secret)
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

        Uri BuildUriForKvRoute(ConfigurationSetting keyValue)
            => BuildUriForKvRoute(keyValue.Key, keyValue.Label); // TODO (pri 2) : does this need to filter ETag?

        Uri BuildUriForKvRoute(string key, string label)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path = KvRoute + key;

            if (label != null)
            {
                builder.AppendQuery(LabelQueryFilter, label);
            }

            return builder.Uri;
        }

        private string EscapeReservedCharacters(string input)
        {
            string resp = string.Empty;
            for (int i=0; i<input.Length; i++)
            {
                if (ReservedCharacters.Contains(input[i]))
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

        internal void BuildBatchQuery(UriBuilder builder, SettingSelector selector)
        {
            if (selector.Keys.Count > 0)
            {
                var keysCopy = new List<string>();
                foreach (var key in selector.Keys)
                {
                    if (key.IndexOfAny(ReservedCharacters) != -1)
                    {
                        keysCopy.Add(EscapeReservedCharacters(key));
                    }
                    else
                    {
                        keysCopy.Add(key);
                    }
                }
                var keys = string.Join(",", keysCopy).ToLower();
                builder.AppendQuery(KeyQueryFilter, keys);
            }

            if (selector.Labels.Count > 0)
            {
                var labelsCopy = new List<string>();
                foreach (var label in selector.Labels)
                {
                    if (label == string.Empty)
                    {
                        labelsCopy.Add("\0");
                    }
                    else
                    {
                        labelsCopy.Add(EscapeReservedCharacters(label));
                    }
                }
                var labels = string.Join(",", labelsCopy).ToLower();
                builder.AppendQuery(LabelQueryFilter, labels);
            }

            if (selector.Fields != SettingFields.All)
            {
                var filter = (selector.Fields).ToString().ToLower();
                builder.AppendQuery(FieldsQueryFilter, filter);
            }

            if (!string.IsNullOrEmpty(selector.BatchLink))
            {
                builder.AppendQuery("after", selector.BatchLink);
            }
        }

        Uri BuildUriForGetBatch(SettingSelector selector)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path = KvRoute;
            BuildBatchQuery(builder, selector);

            return builder.Uri;
        }

        Uri BuildUriForRevisions(SettingSelector selector)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path = RevisionsRoute;
            BuildBatchQuery(builder, selector);

            return builder.Uri;
        }

        static ReadOnlyMemory<byte> Serialize(ConfigurationSetting setting)
        {
            ReadOnlyMemory<byte> content = default;
            int size = 256;
            while (true)
            {
                byte[] buffer = new byte[size];
                if (ConfigurationServiceSerializer.TrySerialize(setting, buffer, out int written))
                {
                    content = buffer.AsMemory(0, written);
                    break;
                }
                size *= 2;
            }

            return content;
        }
        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
