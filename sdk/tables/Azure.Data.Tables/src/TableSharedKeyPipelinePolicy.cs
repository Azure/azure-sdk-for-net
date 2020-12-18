// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.Tables
{
    /// <summary>
    /// HttpPipelinePolicy to sign requests using an Azure Storage shared key.
    /// </summary>
    internal sealed class TableSharedKeyPipelinePolicy : HttpPipelineSynchronousPolicy
    {
        private class InternalStorageCredential : TableSharedKeyCredential
        {
            public static InternalStorageCredential Instance = new InternalStorageCredential();
            public InternalStorageCredential() : base(string.Empty, string.Empty)
            {
            }

            public static string GetSas(TableSharedKeyCredential credential, string message)
            {
                return ComputeSasSignature(credential, message);
            }
        }
        /// <summary>
        /// Shared key credentials used to sign requests
        /// </summary>
        private readonly TableSharedKeyCredential _credentials;

        /// <summary>
        /// Create a new SharedKeyPipelinePolicy
        /// </summary>
        /// <param name="credentials">SharedKeyCredentials to authenticate requests.</param>
        public TableSharedKeyPipelinePolicy(TableSharedKeyCredential credentials)
            => _credentials = credentials;

        /// <summary>
        /// Sign the request using the shared key credentials.
        /// </summary>
        /// <param name="message">The message with the request to sign.</param>
        public override void OnSendingRequest(HttpMessage message)
        {
            base.OnSendingRequest(message);

            var date = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture);
            message.Request.Headers.SetValue(TableConstants.HeaderNames.Date, date);

            var stringToSign = BuildStringToSign(message);
            var signature = InternalStorageCredential.GetSas(_credentials, stringToSign);

            var key = new AuthenticationHeaderValue(TableConstants.HeaderNames.SharedKey, _credentials.AccountName + ":" + signature).ToString();
            message.Request.Headers.SetValue(TableConstants.HeaderNames.Authorization, key);
        }

        private string BuildStringToSign(HttpMessage message)
        {
            // https://docs.microsoft.com/en-us/rest/api/storageservices/authorize-with-shared-key

            message.Request.Headers.TryGetValue(TableConstants.HeaderNames.Date, out var date);

            var stringToSign = string.Join("\n",
                date,
                BuildCanonicalizedResource(message.Request.Uri.ToUri()));
            return stringToSign;
        }

        private string BuildCanonicalizedResource(Uri resource)
        {
            // https://docs.microsoft.com/en-us/rest/api/storageservices/authentication-for-the-azure-storage-services
            StringBuilder cr = new StringBuilder("/").Append(_credentials.AccountName);
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

            System.Collections.Generic.IDictionary<string, string> parameters = GetQueryParameters(resource); // Returns URL decoded values
            if (parameters.Count > 0)
            {
                foreach (var name in parameters.Keys.OrderBy(key => key, StringComparer.Ordinal))
                {
                    // If the request URI addresses a component of the resource, append the appropriate query string.
                    // The query string should include the question mark and the comp parameter (for example, ?comp=metadata).
                    // No other parameters should be included on the query string.
                    // https://docs.microsoft.com/en-us/rest/api/storageservices/authorize-with-shared-key#shared-key-lite-and-table-service-format-for-2009-09-19-and-later
                    if (name == "comp")
                    {
#pragma warning disable CA1308 // Normalize strings to uppercase
                        cr.Append('?').Append(name.ToLowerInvariant()).Append('=').Append(parameters[name]);
#pragma warning restore CA1308 // Normalize strings to uppercase
                    }
                }
            }
            return cr.ToString();
        }
        public static IDictionary<string, string> GetQueryParameters(Uri uri)
        {
            var parameters = new Dictionary<string, string>();
            var query = uri.Query ?? "";
            if (!string.IsNullOrEmpty(query))
            {
                if (query.StartsWith("?", true, CultureInfo.InvariantCulture))
                {
                    query = query.Substring(1);
                }
                foreach (var param in query.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var parts = param.Split(new[] { '=' }, 2);
                    var name = WebUtility.UrlDecode(parts[0]);
                    if (parts.Length == 1)
                    {
                        parameters.Add(name, default);
                    }
                    else
                    {
                        parameters.Add(name, WebUtility.UrlDecode(parts[1]));
                    }
                }
            }
            return parameters;
        }
    }
}
