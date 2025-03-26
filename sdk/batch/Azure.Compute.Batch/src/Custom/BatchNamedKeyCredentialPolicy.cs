// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Azure.Core.Pipeline;
using Azure.Core;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace Azure.Compute.Batch.Custom
{
    /// <summary>
    /// BatchNamedKeyCredential Policy
    /// </summary>
    internal class BatchNamedKeyCredentialPolicy : HttpPipelineSynchronousPolicy
    {
        /// <summary>
        /// Batch Account name
        /// </summary>
        private string AccountName;

        /// <summary>
        /// Batch Shared Key
        /// </summary>
        private byte[] AccountKey;

        /// <summary>
        /// Create a new BatchNamedKeyCredentialPolicy
        /// </summary>
        /// <param name="credentials">BatchNamedKeyCredentialPolicy to authenticate requests.</param>
        public BatchNamedKeyCredentialPolicy(AzureNamedKeyCredential credentials)
        {
            var (name, key) = credentials;
            AccountName = name; ;
            SetAccountKey(key);
        }

        /// <summary>
        /// Update the Batch Account's access key.  This intended to be used
        /// when you've regenerated your Batch Account's access keys and want
        /// to update long lived clients.
        /// </summary>
        /// <param name="accountKey">A Batch Account access key.</param>
        public void SetAccountKey(string accountKey) =>
            AccountKey = Convert.FromBase64String(accountKey);

        /// <summary>
        /// Sign the request using the shared key credentials.
        /// </summary>
        /// <param name="message">The message with the request to sign.</param>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);

            var date = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture);
            message.Request.Headers.SetValue(Constants.HeaderNames.OCPDate, date);

            var stringToSign = BuildStringToSign(message);
            var signature = ComputeSasSignature(stringToSign);

            var key = new AuthenticationHeaderValue(Constants.HeaderNames.SharedKey, AccountName + ":" + signature).ToString();
            message.Request.Headers.SetValue(Constants.HeaderNames.Authorization, key);
        }

        // If you change this method, make sure live tests are passing before merging PR.
        private string BuildStringToSign(HttpMessage message)
        {
            // https://docs.microsoft.com/en-us/rest/api/Batchservices/authorize-with-shared-key

            message.Request.Headers.TryGetValue(Constants.HeaderNames.ContentEncoding, out var contentEncoding);
            message.Request.Headers.TryGetValue(Constants.HeaderNames.ContentLanguage, out var contentLanguage);
            message.Request.Headers.TryGetValue(Constants.HeaderNames.ContentMD5, out var contentMD5);
            message.Request.Headers.TryGetValue(Constants.HeaderNames.ContentType, out var contentType);
            message.Request.Headers.TryGetValue(Constants.HeaderNames.IfModifiedSince, out var ifModifiedSince);
            message.Request.Headers.TryGetValue(Constants.HeaderNames.IfMatch, out var ifMatch);
            message.Request.Headers.TryGetValue(Constants.HeaderNames.IfNoneMatch, out var ifNoneMatch);
            message.Request.Headers.TryGetValue(Constants.HeaderNames.IfUnmodifiedSince, out var ifUnmodifiedSince);
            message.Request.Headers.TryGetValue(Constants.HeaderNames.Range, out var range);

            string contentLengthString = string.Empty;

            if (message.Request.Content != null && message.Request.Content.TryComputeLength(out long contentLength))
            {
                contentLengthString = contentLength.ToString(CultureInfo.InvariantCulture);
            }
            var uri = message.Request.Uri.ToUri();

            var stringBuilder = new StringBuilder(uri.AbsolutePath.Length + 64);
            stringBuilder.Append(message.Request.Method.ToString().ToUpperInvariant()).Append('\n');
            stringBuilder.Append(contentEncoding ?? "").Append('\n');
            stringBuilder.Append(contentLanguage ?? "").Append('\n');
            stringBuilder.Append(contentLengthString == "0" ? "" : contentLengthString ?? "").Append('\n');
            stringBuilder.Append(contentMD5 ?? "");// todo: fix base 64 VALUE
            stringBuilder.Append('\n');
            stringBuilder.Append(contentType ?? "").Append('\n');
            stringBuilder.Append('\n');
            stringBuilder.Append(ifModifiedSince ?? "").Append('\n');
            stringBuilder.Append(ifMatch ?? "").Append('\n');
            stringBuilder.Append(ifNoneMatch ?? "").Append('\n');
            stringBuilder.Append(ifUnmodifiedSince ?? "").Append('\n');
            stringBuilder.Append(range ?? "").Append('\n');
            BuildCanonicalizedHeaders(stringBuilder, message);
            BuildCanonicalizedResource(stringBuilder, uri);
            return stringBuilder.ToString();
        }

        // If you change this method, make sure live tests are passing before merging PR.
        private void BuildCanonicalizedHeaders(StringBuilder stringBuilder, HttpMessage message)
        {
            // Grab all the "ocp-*" headers, trim whitespace, lowercase, sort,
            // and combine them with their values (separated by a colon).
            var headers = new List<HttpHeader>();
            foreach (var header in message.Request.Headers)
            {
                if (header.Name.StartsWith(Constants.HeaderNames.OCPPrefix, StringComparison.OrdinalIgnoreCase))
                {
                    headers.Add(new HttpHeader(header.Name.ToLowerInvariant(), header.Value));
                }
            }

            headers.Sort(static (x, y) => string.CompareOrdinal(x.Name, y.Name));

            foreach (var header in headers)
            {
                stringBuilder
                    .Append(header.Name)
                    .Append(':')
                    .Append(header.Value)
                    .Append('\n');
            }
        }

        // If you change this method, make sure live tests are passing before merging PR.
        private void BuildCanonicalizedResource(StringBuilder stringBuilder, Uri resource)
        {
            // https://learn.microsoft.com/rest/api/batchservice/authenticate-requests-to-the-azure-batch-service
            stringBuilder.Append('/');
            stringBuilder.Append(AccountName);
            if (resource.AbsolutePath.Length > 0)
            {
                // Any portion of the CanonicalizedResource string that is derived from
                // the resource's URI should be encoded exactly as it is in the URI.
                // -- https://msdn.microsoft.com/library/azure/dd179428.aspx
                stringBuilder.Append(resource.AbsolutePath);//EscapedPath()
            }
            else
            {
                // a slash is required to indicate the root path
                stringBuilder.Append('/');
            }
            string queryString = resource.Query;
            var namedValueCollection = System.Web.HttpUtility.ParseQueryString(queryString);
            IDictionary<string, string> parameters = ToDictionary(namedValueCollection);
            //System.Collections.Generic.IDictionary<string, string> parameters = resource.Query.ToDictionary(; // Returns URL decoded values
            if (parameters.Count > 0)
            {
                foreach (var name in parameters.Keys.OrderBy(key => key, StringComparer.Ordinal))
                {
#pragma warning disable CA1308 // Normalize strings to uppercase
                    stringBuilder.Append('\n').Append(name.ToLowerInvariant()).Append(':').Append(parameters[name]);
#pragma warning restore CA1308 // Normalize strings to uppercase
                }
            }
        }

        /// <summary>
        /// Generates a base-64 hash signature string for an HTTP request or
        /// for a SAS.
        /// </summary>
        /// <param name="message">The message to sign.</param>
        /// <returns>The signed message.</returns>
        private string ComputeSasSignature(string message)
        {
#if NET6_0_OR_GREATER
            return Convert.ToBase64String(HMACSHA256.HashData(AccountKey, Encoding.UTF8.GetBytes(message)));
#else
            return Convert.ToBase64String(new HMACSHA256(AccountKey).ComputeHash(Encoding.UTF8.GetBytes(message)));
#endif
        }

        /// <summary>
        ///     A NameValueCollection extension method that converts to a dictionary.
        /// </summary>
        /// <param name="collection">The collection to act on.</param>
        /// <returns>@this as an IDictionary&lt;string,object&gt;</returns>
        private IDictionary<string, string> ToDictionary(NameValueCollection collection)
        {
            var dict = new Dictionary<string, string>();

            if (collection != null)
            {
                foreach (string key in collection.AllKeys)
                {
                    dict.Add(key, collection[key]);
                }
            }

            return dict;
        }
    }
}
