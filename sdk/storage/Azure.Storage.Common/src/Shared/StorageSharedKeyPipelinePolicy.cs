// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage
{
    /// <summary>
    /// HttpPipelinePolicy to sign requests using an Azure Storage shared key.
    /// </summary>
    internal sealed class StorageSharedKeyPipelinePolicy : HttpPipelineSynchronousPolicy
    {
        /// <summary>
        /// Whether to always add the x-ms-date header.
        /// </summary>
        private const bool IncludeXMsDate = true;

        /// <summary>
        /// Shared key credentials used to sign requests
        /// </summary>
        private readonly StorageSharedKeyCredential _credentials;

        /// <summary>
        /// Create a new SharedKeyPipelinePolicy
        /// </summary>
        /// <param name="credentials">SharedKeyCredentials to authenticate requests.</param>
        public StorageSharedKeyPipelinePolicy(StorageSharedKeyCredential credentials)
            => _credentials = credentials;

        /// <summary>
        /// Sign the request using the shared key credentials.
        /// </summary>
        /// <param name="message">The message with the request to sign.</param>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);

            // Add a x-ms-date header
            if (IncludeXMsDate)
            {
                var date = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture);
                message.Request.Headers.SetValue(Constants.HeaderNames.Date, date);
            }

            var stringToSign = BuildStringToSign(message);
            var signature = StorageSharedKeyCredentialInternals.ComputeSasSignature(_credentials, stringToSign);

            var key = new AuthenticationHeaderValue(Constants.HeaderNames.SharedKey, _credentials.AccountName + ":" + signature).ToString();
            message.Request.Headers.SetValue(Constants.HeaderNames.Authorization, key);
        }

        // If you change this method, make sure live tests are passing before merging PR.
        private string BuildStringToSign(HttpMessage message)
        {
            // https://docs.microsoft.com/en-us/rest/api/storageservices/authorize-with-shared-key

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
            stringBuilder.Append(contentType ?? "").Append('\n'); // Empty date because x-ms-date is expected (as per web page above))
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
        private static void BuildCanonicalizedHeaders(StringBuilder stringBuilder, HttpMessage message)
        {
            // Grab all the "x-ms-*" headers, trim whitespace, lowercase, sort,
            // and combine them with their values (separated by a colon).
            foreach (var header in
                message.Request.Headers
                .Where(static h => h.Name.StartsWith(Constants.HeaderNames.XMsPrefix, StringComparison.OrdinalIgnoreCase))
#pragma warning disable CA1308 // Normalize strings to uppercase
                .Select(static h => (h.Name.ToLowerInvariant(), h.Value))
#pragma warning restore CA1308 // Normalize strings to uppercase
                .OrderBy(static h => h.Item1.Trim()))
            {
                stringBuilder.Append(header.Item1);
                stringBuilder.Append(':');
                stringBuilder.Append(header.Value);
                stringBuilder.Append('\n');
            }
        }

        // If you change this method, make sure live tests are passing before merging PR.
        private void BuildCanonicalizedResource(StringBuilder stringBuilder, Uri resource)
        {
            // https://docs.microsoft.com/en-us/rest/api/storageservices/authentication-for-the-azure-storage-services
            stringBuilder.Append('/');
            stringBuilder.Append(_credentials.AccountName);
            if (resource.AbsolutePath.Length > 0)
            {
                // Any portion of the CanonicalizedResource string that is derived from
                // the resource's URI should be encoded exactly as it is in the URI.
                // -- https://msdn.microsoft.com/en-gb/library/azure/dd179428.aspx
                stringBuilder.Append(resource.AbsolutePath);//EscapedPath()
            }
            else
            {
                // a slash is required to indicate the root path
                stringBuilder.Append('/');
            }

            System.Collections.Generic.IDictionary<string, string> parameters = resource.GetQueryParameters(); // Returns URL decoded values
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
    }
}
