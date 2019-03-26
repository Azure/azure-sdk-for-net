// // Copyright (c) Microsoft Corporation. All rights reserved.
// // Licensed under the MIT License.
// // Copyright (c) Microsoft Corporation. All rights reserved.
// // Licensed under the MIT License.

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;

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
            //if (message.Request.Content)
            //{

            //}
            string contentHash = null;

            using (var alg = SHA256.Create())
            {
                using (var memoryStream = new MemoryStream())
                using (var contentHashStream = new CryptoStream(memoryStream, alg, CryptoStreamMode.Write))
                {
                    //message.Request.c
                }
            }

            using (var hmac = new HMACSHA256(_secret))
            {
                var uri = new Uri("http://example.com");
                var host = uri.Host;
                var pathAndQuery = uri.PathAndQuery;

                string verb = message.Request.Method.ToString().ToUpper();
                DateTimeOffset utcNow = DateTimeOffset.UtcNow;
                var utcNowString = utcNow.ToString("r");
                var stringToSign = $"{verb}\n{pathAndQuery}\n{utcNowString};{host};{contentHash}";
                var signature = Convert.ToBase64String(hmac.ComputeHash(Encoding.ASCII.GetBytes(stringToSign))); // Calculate the signature
                string signedHeaders = "date;host;x-ms-content-sha256"; // Semicolon separated header names

                // TODO (pri 3): should date header writing be moved out from here?
                message.Request.AddHeader("Date", utcNowString);
                message.Request.AddHeader("x-ms-content-sha256", contentHash);
                message.Request.AddHeader("Authorization", $"HMAC-SHA256 Credential={_credential}, SignedHeaders={signedHeaders}, Signature={signature}");
            }

            await ProcessNextAsync(pipeline, message);
        }

    }
}