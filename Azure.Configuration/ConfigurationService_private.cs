using Azure.Core;
using Azure.Core.Net;
using Azure.Core.Net.Pipeline;
using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.JsonLab;
using System.Threading;
using System.Threading.Tasks;
using static System.Buffers.Text.Encodings;

namespace Azure.Configuration
{
    public partial class ConfigurationService
    {
        #region String Table
        const string MediaTypeProblemApplication = "application/problem+json";

        const string KvRoute = "/kv/";
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

        // TODO (pri 2) : add UrlBuilder and use it.
        Url BuildUriForGetKeyValue(string key, GetKeyValueOptions options)
        {
            //key = Uri.EscapeDataString(key); TODO (pri 2): We don't need to do this now becausee Uri will do it, right?
            var requestUri = new Uri(_baseUri, KvRoute + key);
            if (options != null) {
                var queryBuild = new Dictionary<string, string>();
                if (options.Label != null) {
                    queryBuild.Add(LabelQueryFilter, options.Label);
                }
                if (options.FieldsSelector != KeyValueFields.All) {
                    queryBuild.Add(FieldsQueryFilter, (options.FieldsSelector).ToString().ToLower().Replace(" ", ""));
                }
                if (queryBuild.Count > 0) {
                    requestUri = new Uri(requestUri + ToQueryString(queryBuild), UriKind.Relative);
                }
            }
            return new Url(requestUri);
        }

        Url BuildUrlForSetKeyValue(KeyValue keyValue)
        {
            Uri requestUri = new Uri(_baseUri, KvRoute + Uri.EscapeDataString(keyValue.Key));   // TODO: Call EscapeDataString?
            if (keyValue.Label != null) {
                var queryBuild = new Dictionary<string, string> { { LabelQueryFilter, keyValue.Label } };
                requestUri = new Uri(requestUri + ToQueryString(queryBuild), UriKind.Absolute); // TODO (pri 3): this used to be relative.
            }
            return new Url(requestUri);
        }

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
