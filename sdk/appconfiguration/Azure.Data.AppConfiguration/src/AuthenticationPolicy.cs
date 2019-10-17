// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.AppConfiguration
{
    internal class AuthenticationPolicy : HttpPipelinePolicy
    {
        private readonly string _credential;
        private readonly byte[] _secret;

        public AuthenticationPolicy(string credential, byte[] secret)
        {
            _credential = credential;
            _secret = secret;
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            await ProcessAsync(message, async: true).ConfigureAwait(false);

            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }

        private async ValueTask ProcessAsync(HttpMessage message, bool async)
        {
            string contentHash;

            using (var alg = SHA256.Create())
            {
                using (var memoryStream = new MemoryStream())
                using (var contentHashStream = new CryptoStream(memoryStream, alg, CryptoStreamMode.Write))
                {
                    if (message.Request.Content != null)
                    {
                        if (async)
                        {
                            await message.Request.Content.WriteToAsync(contentHashStream, message.CancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            message.Request.Content.WriteTo(contentHashStream, message.CancellationToken);
                        }
                    }
                }

                contentHash = Convert.ToBase64String(alg.Hash);
            }

            using (var hmac = new HMACSHA256(_secret))
            {
                Uri uri = message.Request.Uri.ToUri();
                var host = uri.Host;
                var pathAndQuery = uri.PathAndQuery;

                string method = message.Request.Method.Method;
                DateTimeOffset utcNow = DateTimeOffset.UtcNow;
                var utcNowString = utcNow.ToString("r", CultureInfo.InvariantCulture);
                var stringToSign = $"{method}\n{pathAndQuery}\n{utcNowString};{host};{contentHash}";
                var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(stringToSign))); // Calculate the signature
                string signedHeaders = "date;host;x-ms-content-sha256"; // Semicolon separated header names

                message.Request.Headers.SetValue("Date", utcNowString);
                message.Request.Headers.SetValue("x-ms-content-sha256", contentHash);
                message.Request.Headers.SetValue("Authorization", $"HMAC-SHA256 Credential={_credential}&SignedHeaders={signedHeaders}&Signature={signature}");
            }
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            ProcessAsync(message, async: false).GetAwaiter().GetResult();

            ProcessNext(message, pipeline);
        }
    }
}
