using Azure.Core;
using Azure.Core.Net;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.JsonLab;
using static System.Buffers.Text.Encodings;

namespace Azure.Configuration
{
    public partial class ConfigurationService
    {
        #region String Table
        const string MediaTypeProblemApplication = "application/problem+json";

        const string KvRoute = "/kv/";
        static readonly byte[] KvRouteBytes = Encoding.ASCII.GetBytes(KvRoute);

        static readonly byte[] s_after = Encoding.ASCII.GetBytes("after");
        static readonly byte[] s_keyQueryFilter = Encoding.ASCII.GetBytes(KeyQueryFilter);
        static readonly byte[] s_labelQueryFilter = Encoding.ASCII.GetBytes(LabelQueryFilter);
        static readonly byte[] s_fieldsQueryFilter = Encoding.ASCII.GetBytes(FieldsQueryFilter);

        const string RevisionsRoute = "/revisions/";
        const string LocksRoute = "/locks/";

        const string LabelQueryFilter = "label";
        const string KeyQueryFilter = "key";
        const string FieldsQueryFilter = "fields";

        const string AcceptDateTimeFormat = "ddd, dd MMM yyy HH:mm:ss 'GMT'";
        const string AcceptDatetimeHeader = "Accept-Datetime";
        #endregion

        static readonly Header MediaTypeKeyValueApplicationHeader = new Header(
            Header.Constants.Accept,
            Encoding.ASCII.GetBytes("application/vnd.microsoft.appconfig.kv+json")
        );

        void WriteJsonContent(KeyValue setting, ServiceCallContext context)
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

        Url BuildUrlForGetBatch(QueryKeyValueCollectionOptions options)
        {
            var urlBuilder = new UrlWriter(new Url(_baseUri), 100);
            urlBuilder.AppendPath(KvRouteBytes); // TODO (pri 1): it seems like this causes the path to end with /. is that ok?

            if (options.Index != 0)
            {
                urlBuilder.AppendQuery(s_after, options.Index);
            }

            if (!string.IsNullOrEmpty(options.KeyFilter))
            {
                urlBuilder.AppendQuery(s_keyQueryFilter, options.KeyFilter);
            }

            if (options.LabelFilter != null)
            {
                if (options.LabelFilter == string.Empty)
                {
                    options.LabelFilter = "\0";
                }
                urlBuilder.AppendQuery(s_labelQueryFilter, options.LabelFilter);
            }

            if (options.FieldsSelector != KeyValueFields.All)
            {
                // TODO (pri 3): this should be optimized
                var filter = (options.FieldsSelector).ToString().ToLower().Replace(" ", "");
                urlBuilder.AppendQuery(s_fieldsQueryFilter, filter);
            }

            return urlBuilder.ToUrl();
        }

        Url BuildUriForGetKeyValue(string key, GetKeyValueOptions options)
        {
            var builder = new UrlWriter(_baseUri.ToString(), 100);
            builder.AppendPath(KvRouteBytes);
            builder.AppendPath(key);

            if (options != null) {
                if (options.Label != null) {
                    builder.AppendQuery(s_labelQueryFilter, options.Label);
                }
                if (options.FieldsSelector != KeyValueFields.All)
                {
                    // TODO (pri 3): this should be optimized
                    var filter = (options.FieldsSelector).ToString().ToLower().Replace(" ", "");
                    builder.AppendQuery(s_fieldsQueryFilter, filter);
                }
            }
            return builder.ToUrl();
        }

        Url BuildUrlForSetKeyValue(KeyValue keyValue)
            => BuildUriForGetKeyValue(keyValue.Key, new GetKeyValueOptions() { Label = keyValue.Label });

        static string ToQueryString(Dictionary<string, string> parameters)
        {
            var sb = new StringBuilder("?");
            foreach (var kv in parameters) {
                if (sb.Length > 1) sb.Append('&');
                sb.Append(kv.Key).Append('=').Append(kv.Value);
            }
            return sb.ToString();
        }

        void AddAuthenticationHeader(ServiceCallContext context, ServiceMethod method, ReadOnlySequence<byte> content)
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
    }
}
