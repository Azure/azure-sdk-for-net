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
        private const string LabelQueryFilter = "label";

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

        private void BuildUriForGetBatch(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        {
            builder.Reset(_endpoint);
            builder.AppendPath(KvRoute, escape: false);
            selector.BuildBatchQuery(builder, pageLink);
        }

        private void BuildUriForRevisions(RequestUriBuilder builder, SettingSelector selector, string pageLink)
        {
            builder.Reset(_endpoint);
            builder.AppendPath(RevisionsRoute, escape: false);
            selector.BuildBatchQuery(builder, pageLink);
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
