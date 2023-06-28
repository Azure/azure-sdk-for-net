// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    internal class CustomHMACAuthenticationWebSocket
    {
        private readonly AzureKeyCredential _keyCredential;
        private readonly Uri _acsEndpoint;

        public CustomHMACAuthenticationWebSocket(AzureKeyCredential keyCredential, Uri acsEndpoint)
        {
            _keyCredential = keyCredential;
            _acsEndpoint = acsEndpoint;
        }

        public void AddHmacHeaders(ClientWebSocket webSocket, Uri wsEndpoint, RequestMethod method, string content)
        {
            // adding x-ms-date header
            var utcNowString = DateTimeOffset.UtcNow.ToString("r", CultureInfo.InvariantCulture);
            webSocket.Options.SetRequestHeader("x-ms-date", utcNowString);

            // adding x-ms-host
            webSocket.Options.SetRequestHeader("x-ms-host", wsEndpoint.Host);

            // adding x-ms-content-sha256
            var contentHash = CalculateSHA256Base64(content);
            webSocket.Options.SetRequestHeader("x-ms-content-sha256", contentHash);

            // adding authorization
            var authorization = GetAuthorizationHeader(method, wsEndpoint, contentHash, utcNowString);
            webSocket.Options.SetRequestHeader(HttpHeader.Names.Authorization, authorization);
        }

        private string CalculateSHA256Base64(string content)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(content));
                string base64String = Convert.ToBase64String(hashBytes);
                return base64String;
            }
        }
        private string GetAuthorizationHeader(RequestMethod method, Uri uri, string contentHash, string date)
        {
            var pathAndQuery = uri.PathAndQuery;

            var stringToSign = $"{method.Method}\n{pathAndQuery}\n{date};{_acsEndpoint.Host};{contentHash}";
            var signature = ComputeHMAC(stringToSign);

            string signedHeaders = $"x-ms-date;host;x-ms-content-sha256";
            return $"HMAC-SHA256 SignedHeaders={signedHeaders}&Signature={signature}";
        }

        private string ComputeHMAC(string value)
        {
            using var hmac = new HMACSHA256(Convert.FromBase64String(_keyCredential.Key));
            var hash = hmac.ComputeHash(Encoding.ASCII.GetBytes(value));
            return Convert.ToBase64String(hash);
        }
    }
}
