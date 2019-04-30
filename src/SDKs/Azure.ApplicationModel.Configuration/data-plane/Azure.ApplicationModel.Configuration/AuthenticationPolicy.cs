// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.ApplicationModel.Configuration
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

        public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            string contentHash;

            using (var alg = SHA256.Create())
            {
                using (var memoryStream = new MemoryStream())
                using (var contentHashStream = new CryptoStream(memoryStream, alg, CryptoStreamMode.Write))
                {
                    if (message.Request.Content != null)
                    {
                        await message.Request.Content.WriteTo(contentHashStream, message.Cancellation);
                    }
                }

                contentHash = Convert.ToBase64String(alg.Hash);
            }

            using (var hmac = new HMACSHA256(_secret))
            {
                var uri = message.Request.UriBuilder.Uri;
                var host = uri.Host;
                var pathAndQuery = uri.PathAndQuery;

                string method = HttpPipelineMethodConverter.ToString(message.Request.Method);
                DateTimeOffset utcNow = DateTimeOffset.UtcNow;
                var utcNowString = utcNow.ToString("r");
                var stringToSign = $"{method}\n{pathAndQuery}\n{utcNowString};{host};{contentHash}";
                var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(stringToSign))); // Calculate the signature
                string signedHeaders = "date;host;x-ms-content-sha256"; // Semicolon separated header names

                // TODO (pri 3): should date header writing be moved out from here?
                message.Request.Headers.Add("Date", utcNowString);
                message.Request.Headers.Add("x-ms-content-sha256", contentHash);
                message.Request.Headers.Add("Authorization", $"HMAC-SHA256 Credential={_credential}, SignedHeaders={signedHeaders}, Signature={signature}");
            }

            await ProcessNextAsync(pipeline, message);
        }

    }
}
