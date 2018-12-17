using Azure.Core;
using Azure.Core.Net;
using System;
using System.Buffers;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using System.Text.JsonLab;
using System.Threading.Tasks;
using static System.Buffers.Text.Encodings;

namespace Azure.Configuration
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

        static readonly Func<ServiceResponse, ConfigurationSetting> s_parser = (rsp) => {
            if (ConfigurationServiceParser.TryParse(rsp.Content.Bytes, out ConfigurationSetting result, out _)) return result;
            throw new Exception("invalid response content");
        };

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

        static async Task<Response<ConfigurationSetting>> CreateKeyValueResponse(PipelineCallContext context)
        {
            ServiceResponse response = context.Response;

            if (response.Status != 200) {
                return new Response<ConfigurationSetting>(response);
            }

            if (!response.TryGetHeader(Header.Constants.ContentLength, out long contentLength)) {
                throw new Exception("bad response: no content length header");
            }
            await response.Content.ReadAsync(contentLength).ConfigureAwait(false);

            return new Response<ConfigurationSetting>(response, s_parser);
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

        Uri BuildUrlForGetBatch(BatchFilter options)
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

        // TODO (pri 1): serialize the Tags field
        void WriteJsonContent(ConfigurationSetting setting, PipelineCallContext context)
        {
            var writer = Utf8JsonWriter.Create(context.ContentWriter);
            writer.WriteObjectStart();
            writer.WriteAttribute("key", setting.Value);
            writer.WriteAttribute("content_type", setting.ContentType);
            writer.WriteObjectEnd();
            writer.Flush();
            var written = context.ContentWriter.Written;
            context.AddHeader(Header.Common.CreateContentLength(written.Length));
            AddAuthenticationHeader(context, ServiceMethod.Put, written);
        }

        void AddAuthenticationHeader(PipelineCallContext context, ServiceMethod method, ReadOnlySequence<byte> content)
        {
            string contentHash = null;
            using (var alg = SHA256.Create())
            {
                contentHash = Convert.ToBase64String(alg.ComputeHash(content.ToArray()));
            }

            using (var hmac = new HMACSHA256(_secret))
            { 
                var (_, host, pathAndQuery) = context.Url;
                string hostString = Utf8.ToString(host);
                string pathAndQueryString = Utf8.ToString(pathAndQuery); 
                string verb = method.ToString().ToUpper();
                DateTimeOffset utcNow = DateTimeOffset.UtcNow;
                var utcNowString = utcNow.ToString("r");
                var stringToSign = $"{verb}\n{pathAndQueryString}\n{utcNowString};{hostString};{contentHash}";
                var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(stringToSign))); // Calculate the signature
                context.AddHeader("Date", utcNowString);
                context.AddHeader("x-ms-content-sha256", contentHash);
                string signedHeaders = "date;host;x-ms-content-sha256"; // Semicolon separated header names
                context.AddHeader("Authentication", $"HMAC-SHA256 Credential={_credential}, SignedHeaders={signedHeaders}, Signature={signature}");
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
