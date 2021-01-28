// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Communication.Pipeline
{
    internal class HMACAuthenticationPolicy : HttpPipelinePolicy
    {
        private readonly byte[] _secret;

        public HMACAuthenticationPolicy(string accessKey)
        {
            _secret = Convert.FromBase64String(accessKey);
        }

        public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            var contentHash = CreateContentHash(message);
            AddHeaders(message, contentHash);
            ProcessNext(message, pipeline);
        }

        public override async ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
        {
            var contentHash = await CreateContentHashAsync(message).ConfigureAwait(false);
            AddHeaders(message, contentHash);
            await ProcessNextAsync(message, pipeline).ConfigureAwait(false);
        }

        private static string CreateContentHash(HttpMessage message)
        {
            var alg = SHA256.Create();

            using (var memoryStream = new MemoryStream())
            using (var contentHashStream = new CryptoStream(memoryStream, alg, CryptoStreamMode.Write))
            {
                message.Request.Content?.WriteTo(contentHashStream, message.CancellationToken);
            }

            return Convert.ToBase64String(alg.Hash!);
        }

        private static async ValueTask<string> CreateContentHashAsync(HttpMessage message)
        {
            var alg = SHA256.Create();

            using (var memoryStream = new MemoryStream())
            using (var contentHashStream = new CryptoStream(memoryStream, alg, CryptoStreamMode.Write))
            {
                if (message.Request.Content != null)
                    await message.Request.Content.WriteToAsync(contentHashStream, message.CancellationToken).ConfigureAwait(false);
            }

            return Convert.ToBase64String(alg.Hash!);
        }

        private void AddHeaders(HttpMessage message, string contentHash)
        {
            var utcNowString = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture);
            var authorization = GetAuthorizationHeader(message.Request.Method, message.Request.Uri.ToUri(), contentHash, utcNowString);

            message.Request.Headers.SetValue("x-ms-content-sha256", contentHash);
            message.Request.Headers.SetValue(HttpHeader.Names.Date, utcNowString);
            message.Request.Headers.SetValue(HttpHeader.Names.Authorization, authorization);
        }

        private string GetAuthorizationHeader(RequestMethod method, Uri uri, string contentHash, string date)
        {
            const string signedHeaders = "date;host;x-ms-content-sha256";

            var host = uri.Authority;
            var pathAndQuery = uri.PathAndQuery;

            var stringToSign = $"{method.Method}\n{pathAndQuery}\n{date};{host};{contentHash}";
            var signature = ComputeHMAC(stringToSign);
            return $"HMAC-SHA256 SignedHeaders={signedHeaders}&Signature={signature}";
        }

        private string ComputeHMAC(string value)
        {
            using (var hmac = new HMACSHA256(_secret))
            {
                var hash = hmac.ComputeHash(Encoding.ASCII.GetBytes(value));
                return Convert.ToBase64String(hash);
            }
        }
    }
}