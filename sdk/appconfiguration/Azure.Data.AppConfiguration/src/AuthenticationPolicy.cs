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

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            string contentHash = CreateContentHash(message);
            AddHeaders(message, contentHash);
            ProcessNext(message, pipeline);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            string contentHash = await CreateContentHashAsync(message).ConfigureAwait(false);
            AddHeaders(message, contentHash);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }

        private static string CreateContentHash(HttpMessage message)
        {
            using var alg = SHA256.Create();

            using (var memoryStream = new MemoryStream())
            using (var contentHashStream = new CryptoStream(memoryStream, alg, CryptoStreamMode.Write))
            {
                message.Request.Content?.WriteTo(contentHashStream, message.CancellationToken);
            }

            return Convert.ToBase64String(alg.Hash);
        }

        private static async ValueTask<string> CreateContentHashAsync(HttpMessage message)
        {
            using var alg = SHA256.Create();

            using (var memoryStream = new MemoryStream())
            using (var contentHashStream = new CryptoStream(memoryStream, alg, CryptoStreamMode.Write))
            {
                if (message.Request.Content != null)
                {
                    await message.Request.Content.WriteToAsync(contentHashStream, message.CancellationToken).ConfigureAwait(false);
                }
            }

            return Convert.ToBase64String(alg.Hash);
        }

        private void AddHeaders(HttpMessage message, string contentHash)
        {
            var utcNowString = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture);
            var authorization = GetAuthorizationHeader(message.Request, contentHash, utcNowString);

            message.Request.Headers.SetValue("x-ms-content-sha256", contentHash);
            message.Request.Headers.SetValue(HttpHeader.Names.Date, utcNowString);
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, authorization);
        }

        private string GetAuthorizationHeader(Request request, string contentHash, string date) {
            const string signedHeaders = "date;host;x-ms-content-sha256"; // Semicolon separated header names

            var uri = request.Uri.ToUri();
            var host = uri.Authority;
            var pathAndQuery = uri.PathAndQuery;
            var method = request.Method.Method;

            var stringToSign = $"{method}\n{pathAndQuery}\n{date};{host};{contentHash}";
            var signature = ComputeHash(stringToSign); // Calculate the signature
            return $"HMAC-SHA256 Credential={_credential}&SignedHeaders={signedHeaders}&Signature={signature}";
        }

        private string ComputeHash(string value)
        {
            using var hmac = new HMACSHA256(_secret);
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(value)));
        }
    }
}
