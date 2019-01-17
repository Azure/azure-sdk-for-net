// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using Azure.Core.Net;
using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Azure.ApplicationModel.Configuration
{
    public partial class ConfigurationClient
    {
        const string MediaTypeProblemApplication = "application/problem+json";
        const string AcceptDateTimeFormat = "ddd, dd MMM yyy HH:mm:ss 'GMT'";
        const string AcceptDatetimeHeader = "Accept-Datetime";
        const string KvRoute = "/kv/";
        const string LocksRoute = "/locks/";
        const string RevisionsRoute = "/revisions/";
        const string KeyQueryFilter = "key";
        const string LabelQueryFilter = "label";
        const string FieldsQueryFilter = "fields";
        const string IfMatchName = "If-Match";
        Header IfNoneMatchWildcard = new Header("If-None-Match", "*");

        static readonly Header MediaTypeKeyValueApplicationHeader = new Header(
            Header.Constants.Accept,
            Encoding.ASCII.GetBytes("application/vnd.microsoft.appconfig.kv+json")
        );

        // TODO (pri 3): do all the methods that call this accept revisions?
        static void AddFilterHeaders(SettingFilter filter, PipelineCallContext context)
        {
            if (filter == null) return;

            if (filter.ETag.IfMatch != default) {
                context.AddHeader(IfMatchName, $"\"{filter.ETag.IfMatch}\"");
            }

            if (filter.Revision.HasValue) {
                var dateTime = filter.Revision.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                context.AddHeader(AcceptDatetimeHeader, dateTime);
            }
        }

        static async Task<Response<ConfigurationSetting>> CreateResponse(PipelineCallContext context)
        {
            ServiceResponse response = context.Response;

            if (response.Status != 200) {
                return new Response<ConfigurationSetting>(response);
            }

            var result = await ConfigurationServiceSerializer.ParseSettingAsync(response.ContentStream, context.Cancellation);

            return new Response<ConfigurationSetting>(response, result);
        }

        static void ParseConnectionString(string connectionString, out Uri uri, out string credential, out byte[] secret)
        {
            uri = null;
            credential = null;
            secret = null;
            if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException(nameof(connectionString));

            // Parse connection string
            string[] args = connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (args.Length < 3)
            {
                throw new ArgumentException("invalid connection string segment count", nameof(connectionString));
            }

            const string endpointString = "Endpoint=";
            const string idString = "Id=";
            const string secretString = "Secret=";

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
                    secret = Convert.FromBase64String(secretBase64);
                }
            };
        }

        Uri BuildUrlForKvRoute(ConfigurationSetting keyValue)
            => BuildUrlForKvRoute(keyValue.Key, new SettingFilter() { Label = keyValue.Label }); // TODO (pri 2) : does this need to filter ETag?

        Uri BuildUrlForKvRoute(string key, SettingFilter filter)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path = KvRoute + key;

            if (filter != null && filter.Label != null) {
                builder.AppendQuery(LabelQueryFilter, filter.Label);                 
            }

            return builder.Uri;
        }

        Uri BuildUriForLocksRoute(string key, SettingFilter filter)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path = LocksRoute + key;

            if (filter != null && filter.Label != null) {
                builder.AppendQuery(LabelQueryFilter, filter.Label);
            }

            return builder.Uri;
        }

        Uri BuildUrlForGetBatch(SettingBatchFilter options)
        {
            var builder = new UriBuilder(_baseUri);
            builder.Path = KvRoute;

            if (options.StartIndex != 0) {
                builder.AppendQuery("after", options.StartIndex);
            }

            if (!string.IsNullOrEmpty(options.Key)) {
                builder.AppendQuery(KeyQueryFilter, options.Key);
            }

            if (options.Label != null) {
                if (options.Label == string.Empty) {
                    options.Label = "\0";
                }
                builder.AppendQuery(LabelQueryFilter, options.Label);
            }

            if (options.Fields != SettingFields.All) {
                var filter = (options.Fields).ToString().ToLower();
                builder.AppendQuery(FieldsQueryFilter, filter);
            }

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

        internal static void AddAuthenticationHeaders(PipelineCallContext context, Uri uri, ServiceMethod method, ReadOnlyMemory<byte> content, byte[] secret, string credential)
        {
            string contentHash = null;
            using (var alg = SHA256.Create())
            {
                // TODO (pri 3): ToArray should nopt be called here. Instead, TryGetArray, or PipelineContent should do hashing on the fly 
                contentHash = Convert.ToBase64String(alg.ComputeHash(content.ToArray()));
            }

            using (var hmac = new HMACSHA256(secret))
            {
                var host = uri.Host;
                var pathAndQuery = uri.PathAndQuery;

                string verb = method.ToString().ToUpper();
                DateTimeOffset utcNow = DateTimeOffset.UtcNow;
                var utcNowString = utcNow.ToString("r");
                var stringToSign = $"{verb}\n{pathAndQuery}\n{utcNowString};{host};{contentHash}";
                var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(stringToSign))); // Calculate the signature
                string signedHeaders = "date;host;x-ms-content-sha256"; // Semicolon separated header names

                context.AddHeader("Date", utcNowString);
                context.AddHeader("x-ms-content-sha256", contentHash);
                context.AddHeader("Authorization", $"HMAC-SHA256 Credential={credential}, SignedHeaders={signedHeaders}, Signature={signature}");
            }
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
