﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    // TODO: This has been translated from the policy inside SharedKeyCredentials
    // and still has some dependencies to remove

    /// <summary>
    /// HttpPipelinePolicy to sign requests using an Azure Storage shared key.
    /// </summary>
    public sealed class SharedKeyPipelinePolicy : HttpPipelinePolicy
    {
        /// <summary>
        /// Shared key credentials used to sign requests
        /// </summary>
        private readonly SharedKeyCredentials _credentials;

        /// <summary>
        /// Create a new SharedKeyPipelinePolicy
        /// </summary>
        /// <param name="credentials">SharedKeyCredentials to authenticate requests.</param>
        public SharedKeyPipelinePolicy(SharedKeyCredentials credentials)
            => this._credentials = credentials;

        /// <summary>
        /// Sign the request using the shared key credentials.
        /// </summary>
        /// <param name="message">The message with the request to sign.</param>
        /// <param name="pipeline">The next step in the pipeline.</param>
        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            this.AddAuthorizationHeader(message);
            await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
        }

        /// <summary>
        /// Sign the request using the shared key credentials.
        /// </summary>
        /// <param name="message">The message with the request to sign.</param>
        /// <param name="pipeline">The next step in the pipeline.</param>
        public override void Process(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            this.AddAuthorizationHeader(message);
            ProcessNext(pipeline, message);
        }

        private void AddAuthorizationHeader(HttpPipelineMessage message, bool includeXmsDate = true)
        {
            // Add a x-ms-date header if it doesn't already exist
            if (includeXmsDate && !message.Request.Headers.Contains("x-ms-date"))
            {
                var date = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture);
                message.Request.Headers.Add("x-ms-date", date);
            }

            var stringToSign = this.BuildStringToSign(message);
            var signature = this._credentials.ComputeHMACSHA256(stringToSign);

            var key = new AuthenticationHeaderValue("SharedKey", this._credentials.AccountName + ":" + signature).ToString();
            message.Request.Headers.SetValue("Authorization", key);
        }

        private string BuildStringToSign(HttpPipelineMessage message)
        {
            // https://docs.microsoft.com/en-us/rest/api/storageservices/authorize-with-shared-key

            message.Request.Headers.TryGetValue("Content-Encoding", out var contentEncoding);
            message.Request.Headers.TryGetValue("Content-Language", out var contentLanguage);
            message.Request.Headers.TryGetValue("Content-Length", out var contentLength);
            message.Request.Headers.TryGetValue("Content-MD5", out var contentMD5);
            message.Request.Headers.TryGetValue("Content-Type", out var contentType);
            message.Request.Headers.TryGetValue("If-Modified-Since", out var ifModifiedSince);
            message.Request.Headers.TryGetValue("If-Match", out var ifMatch);
            message.Request.Headers.TryGetValue("If-None-Match", out var ifNoneMatch);
            message.Request.Headers.TryGetValue("If-Unmodified-Since", out var ifUnmodifiedSince);
            message.Request.Headers.TryGetValue("Range", out var range);

            var stringToSign = String.Join("\n",
                message.Request.Method.ToString().ToUpperInvariant(),
                contentEncoding ?? "",
                contentLanguage ?? "",
                contentLength == "0" ? "" : contentLength ?? "",
                contentMD5 ?? "", // todo: fix base 64 VALUE
                contentType ?? "",
                "", // Empty date because x-ms-date is expected (as per web page above)
                ifModifiedSince ?? "",
                ifMatch ?? "",
                ifNoneMatch ?? "",
                ifUnmodifiedSince ?? "",
                range ?? "",
                BuildCanonicalizedHeaders(message),
                this.BuildCanonicalizedResource(message.Request.UriBuilder.Uri));
            return stringToSign;
        }

        private static string BuildCanonicalizedHeaders(HttpPipelineMessage message)
        {
            // Grab all the "x-ms-*" headers, trim whitespace, lowercase, sort,
            // and combine them with their values (separated by a colon).
            var sb = new StringBuilder();
            foreach (var headerName in
                message.Request.Headers
                .Select(h => h.Name)
                .Where(name => name.StartsWith("x-ms-", StringComparison.OrdinalIgnoreCase))
#pragma warning disable CA1308 // Normalize strings to uppercase
                .OrderBy(name => name.Trim().ToLowerInvariant()))
#pragma warning restore CA1308 // Normalize strings to uppercase
            {
                if (sb.Length > 0)
                {
                    sb.Append('\n');
                }
                message.Request.Headers.TryGetValue(headerName, out var value);
                sb.Append(headerName).Append(':').Append(value);
            }
            return sb.ToString();
        }

        private string BuildCanonicalizedResource(Uri resource)
        {
            // https://docs.microsoft.com/en-us/rest/api/storageservices/authentication-for-the-azure-storage-services
            var cr = new StringBuilder("/").Append(this._credentials.AccountName);
            if (resource.AbsolutePath.Length > 0)
            {
                // Any portion of the CanonicalizedResource string that is derived from
                // the resource's URI should be encoded exactly as it is in the URI.
                // -- https://msdn.microsoft.com/en-gb/library/azure/dd179428.aspx
                cr.Append(resource.AbsolutePath);//EscapedPath()
            }
            else
            {
                // a slash is required to indicate the root path
                cr.Append('/');
            }

            var parameters = resource.GetQueryParameters(); // Returns URL decoded values
            if (parameters.Count > 0)
            {
                foreach (var name in parameters.Keys.OrderBy(key => key, StringComparer.Ordinal))
                {
#pragma warning disable CA1308 // Normalize strings to uppercase
                    cr.Append('\n').Append(name.ToLowerInvariant()).Append(':').Append(parameters[name]);
#pragma warning restore CA1308 // Normalize strings to uppercase
                }
            }
            return cr.ToString();
        }
    }
}
