﻿// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// 

namespace Microsoft.Azure.Batch.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Batch.Utils;
    using Rest;

    /// <summary>
    /// Shared key credentials for an Azure Batch account.
    /// </summary>
    public class BatchSharedKeyCredential : ServiceClientCredentials
    {
        private const string OCPDateHeaderString = "ocp-date";

        /// <summary>
        /// Gets the Batch account name.
        /// </summary>
        public string AccountName { get; private set; }

        /// <summary>
        /// Gets the account access key, as a Base64-encoded string.
        /// </summary>
        public string KeyValue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchSharedKeyCredential"/> class.
        /// </summary>
        /// <param name="accountName">The name of the Batch account.</param>
        /// <param name="keyValue">The access key of the Batch account, as a Base64-encoded string.</param>
        public BatchSharedKeyCredential(string accountName, string keyValue)
        {
            this.AccountName = accountName;
            this.KeyValue = keyValue;
        }

        /// <summary>
        /// Signs a HTTP request with the current credentials.
        /// </summary>
        /// <param name="httpRequest">The HTTP request</param>
        /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken"/> for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous signing operation.</returns>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage httpRequest, CancellationToken cancellationToken)
        {
            if (httpRequest == null)
            {
                return Async.CompletedTask;
            }

            //First set ocp-date always
            if (!httpRequest.Headers.Contains(OCPDateHeaderString))
            {
                httpRequest.Headers.TryAddWithoutValidation(OCPDateHeaderString, string.Format("{0:R}", DateTime.UtcNow));
            }

            // Set Headers
            var signature = new StringBuilder();
            signature.Append(httpRequest.Method).Append('\n');
            signature.Append(httpRequest.Content != null && httpRequest.Content.Headers.Contains("Content-Encoding") ? httpRequest.Content.Headers.GetValues("Content-Encoding").FirstOrDefault() : string.Empty).Append('\n');
            signature.Append(httpRequest.Content != null && httpRequest.Content.Headers.Contains("Content-Language") ? httpRequest.Content.Headers.GetValues("Content-Language").FirstOrDefault() : string.Empty).Append('\n');

            // Handle content length
            long? contentLength = httpRequest.Content?.Headers?.ContentLength;

            if (contentLength == null)
            {
                // Because C# httpRequest adds a content-length = 0 header for DELETE, PATCH, and OPTIONS even if there is no body (but only in netframework), we have to
                // sign the request knowing that there will be content-length set.
#if FullNetFx
                if (httpRequest.Method == HttpMethod.Delete || httpRequest.Method == new HttpMethod("PATCH") || httpRequest.Method == HttpMethod.Options)
                {
                    contentLength = 0;
                }
#endif

                // Because C# httpRequest adds a content-length = 0 header for POST even if there is no body, we have to
                // sign the request knowing that there will be content-length set.
                if (httpRequest.Method == HttpMethod.Post)
                {
                    contentLength = 0;
                }
            }
            signature.Append(contentLength).Append('\n');

            signature.Append(httpRequest.Content != null && httpRequest.Content.Headers.Contains("Content-MD5") ? httpRequest.Content.Headers.GetValues("Content-MD5").FirstOrDefault() : string.Empty).Append('\n');
            signature.Append(httpRequest.Content != null && httpRequest.Content.Headers.Contains("Content-Type") ? httpRequest.Content.Headers.GetValues("Content-Type").FirstOrDefault() : string.Empty).Append('\n');
            signature.Append(httpRequest.Headers.Contains("Date") ? httpRequest.Headers.GetValues("Date").FirstOrDefault() : string.Empty).Append('\n');
            signature.Append(httpRequest.Headers.Contains("If-Modified-Since") ? httpRequest.Headers.GetValues("If-Modified-Since").FirstOrDefault() : string.Empty).Append('\n');
            signature.Append(httpRequest.Headers.Contains("If-Match") ? httpRequest.Headers.GetValues("If-Match").FirstOrDefault() : string.Empty).Append('\n');
            signature.Append(httpRequest.Headers.Contains("If-None-Match") ? httpRequest.Headers.GetValues("If-None-Match").FirstOrDefault() : string.Empty).Append('\n');
            signature.Append(httpRequest.Headers.Contains("If-Unmodified-Since") ? httpRequest.Headers.GetValues("If-Unmodified-Since").FirstOrDefault() : string.Empty).Append('\n');
            signature.Append(httpRequest.Headers.Contains("Range") ? httpRequest.Headers.GetValues("Range").FirstOrDefault() : string.Empty).Append('\n');

            List<string> customHeaders = new List<string>();
            foreach (KeyValuePair<string, IEnumerable<string>> header in httpRequest.Headers)
            {
                if (header.Key.StartsWith("ocp-", StringComparison.OrdinalIgnoreCase))
                {
                    customHeaders.Add(header.Key.ToLowerInvariant());
                }
            }

            if (httpRequest.Content != null)
            {
                foreach (KeyValuePair<string, IEnumerable<string>> contentHeader in httpRequest.Content.Headers)
                {
                    if (contentHeader.Key.StartsWith("ocp-", StringComparison.OrdinalIgnoreCase))
                    {
                        customHeaders.Add(contentHeader.Key.ToLowerInvariant());
                    }
                }
            }
            customHeaders.Sort(StringComparer.Ordinal);

            foreach (string canonicalHeader in customHeaders)
            {
                string value = httpRequest.Headers.GetValues(canonicalHeader).FirstOrDefault();
                value = value.Replace('\n', ' ').Replace('\r', ' ').TrimStart();
                signature.Append(canonicalHeader).Append(':').Append(value).Append('\n');
            }

            // We temporary change client side auth code generator to bypass server bug 4092533
            signature.Append('/').Append(AccountName).Append('/').Append(httpRequest.RequestUri.AbsolutePath.TrimStart('/').Replace("%5C", "/").Replace("%2F", "/"));
            if (!string.IsNullOrEmpty(httpRequest.RequestUri.Query))
            {
#if FullNetFx
                NameValueCollection queryVariables = System.Web.HttpUtility.ParseQueryString(httpRequest.RequestUri.Query);
                List<string> queryVariableKeys = new List<string>(queryVariables.AllKeys);
#else
                Dictionary<string, Extensions.Primitives.StringValues> queryVariables = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(httpRequest.RequestUri.Query);
                List<string> queryVariableKeys = new List<string>(queryVariables.Keys);
#endif

                queryVariableKeys.Sort(StringComparer.OrdinalIgnoreCase);

                foreach (string queryKey in queryVariableKeys)
                {
                    string lowercaseQueryKey;
                    if (queryKey != null)
                    {
                        lowercaseQueryKey = queryKey.ToLowerInvariant();
                    }
                    else
                    {
                        lowercaseQueryKey = null;
                    }
                    signature.Append('\n').Append(lowercaseQueryKey).Append(':').Append(queryVariables[queryKey]);
                }
            }

            string signedSignature = null;

            using (HashAlgorithm hashAlgorithm = new HMACSHA256(Convert.FromBase64String(this.KeyValue)))
            {
                signedSignature = Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(signature.ToString())));
            }
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("SharedKey", this.AccountName + ":" + signedSignature);

            return Async.CompletedTask;
        }
    }
}
