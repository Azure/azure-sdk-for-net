// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.

// 

namespace Microsoft.Azure.Batch.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.Azure.Batch.Utils;

    /// <summary>
    /// Shared key credentials for an Azure Batch account.
    /// </summary>
    public class BatchSharedKeyCredential : BatchCredentials
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
        /// Signs a HTTP request with the current <see cref="BatchCredentials"/>.
        /// </summary>
        /// <param name="httpRequest">The HTTP request to be signed.</param>
        /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken"/> for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous signing operation.</returns>
        public override Task SignRequestAsync(HttpRequestMessage httpRequest, System.Threading.CancellationToken cancellationToken)
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
            if (httpRequest.Content != null)
            {
                signature.Append(httpRequest.Content.Headers.ContentLength.HasValue ? httpRequest.Content.Headers.ContentLength.ToString() : string.Empty).Append('\n');
            }
            else
            {
                // Because C# httpRequest adds a content-length = 0 header for POST and DELETE even if there is no body, we have to
                // sign the request knowing that there will be content-length set.  For all other methods that have no body, there will be
                // no content length set and thus we append \n with no 0.
                if ((httpRequest.Method == HttpMethod.Delete) || (httpRequest.Method == HttpMethod.Post))
                {
                    signature.Append("0\n");
                }
                else
                {
                    signature.Append('\n');
                }
            }

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
                NameValueCollection queryVariables = HttpUtility.ParseQueryString(httpRequest.RequestUri.Query);
                List<string> queryVariableKeys = new List<string>(queryVariables.AllKeys);
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

        /// <summary>
        /// Signs a HTTP request with the current <see cref="BatchCredentials"/>.
        /// </summary>
        /// <param name="request">The HTTP request</param>
        /// <param name="cancellationToken">A <see cref="System.Threading.CancellationToken"/> for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous signing operation.</returns>
        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return this.SignRequestAsync(request, cancellationToken);
        }
    }
}
