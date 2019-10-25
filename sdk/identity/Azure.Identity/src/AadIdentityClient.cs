// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Identity
{
    internal class AadIdentityClient
    {
        private const string ClientAssertionType = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer";

        private readonly CredentialPipeline _pipeline;

        protected AadIdentityClient()
        {
        }

        public AadIdentityClient(CredentialPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        public virtual async Task<AccessToken> AuthenticateAsync(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
        {
            using Request request = CreateClientSecretAuthRequest(tenantId, clientId, clientSecret, scopes);

            return await SendAuthRequestAsync(request, cancellationToken).ConfigureAwait(false);
        }

        public virtual AccessToken Authenticate(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
        {
            using Request request = CreateClientSecretAuthRequest(tenantId, clientId, clientSecret, scopes);

            return SendAuthRequest(request, cancellationToken);
        }

        public virtual async Task<AccessToken> AuthenticateAsync(string tenantId, string clientId, X509Certificate2 clientCertificate, string[] scopes, CancellationToken cancellationToken = default)
        {
            using Request request = CreateClientCertificateAuthRequest(tenantId, clientId, clientCertificate, scopes);

            return await SendAuthRequestAsync(request, cancellationToken).ConfigureAwait(false);
        }

        public virtual AccessToken Authenticate(string tenantId, string clientId, X509Certificate2 clientCertificate, string[] scopes, CancellationToken cancellationToken = default)
        {
            using Request request = CreateClientCertificateAuthRequest(tenantId, clientId, clientCertificate, scopes);

            return SendAuthRequest(request, cancellationToken);
        }

        private async Task<AccessToken> SendAuthRequestAsync(Request request, CancellationToken cancellationToken)
        {
            Response response = await _pipeline.HttpPipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.Status == 200 || response.Status == 201)
            {
                AccessToken result = await DeserializeAsync(response.ContentStream, cancellationToken).ConfigureAwait(false);

                return Response.FromValue(result, response);
            }

            throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
        }

        private AccessToken SendAuthRequest(Request request, CancellationToken cancellationToken)
        {
            Response response = _pipeline.HttpPipeline.SendRequest(request, cancellationToken);

            if (response.Status == 200 || response.Status == 201)
            {
                AccessToken result = Deserialize(response.ContentStream);

                return Response.FromValue(result, response);
            }

            throw response.CreateRequestFailedException();
        }

        private Request CreateClientSecretAuthRequest(string tenantId, string clientId, string clientSecret, string[] scopes)
        {
            Request request = _pipeline.HttpPipeline.CreateRequest();

            request.Method = RequestMethod.Post;

            request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

            request.Uri.Reset(_pipeline.AuthorityHost);

            request.Uri.AppendPath(tenantId);

            request.Uri.AppendPath("/oauth2/v2.0/token", escape: false);

            var bodyStr = $"response_type=token&grant_type=client_credentials&client_id={Uri.EscapeDataString(clientId)}&client_secret={Uri.EscapeDataString(clientSecret)}&scope={Uri.EscapeDataString(string.Join(" ", scopes))}";

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();

            request.Content = RequestContent.Create(content);

            return request;
        }

        private Request CreateClientCertificateAuthRequest(string tenantId, string clientId, X509Certificate2 clientCertficate, string[] scopes)
        {
            Request request = _pipeline.HttpPipeline.CreateRequest();

            request.Method = RequestMethod.Post;

            request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

            request.Uri.Reset(_pipeline.AuthorityHost);

            request.Uri.AppendPath(tenantId);

            request.Uri.AppendPath("/oauth2/v2.0/token", escape: false);

            string clientAssertion = CreateClientAssertionJWT(clientId, request.Uri.ToString(), clientCertficate);

            var bodyStr = $"response_type=token&grant_type=client_credentials&client_id={Uri.EscapeDataString(clientId)}&client_assertion_type={Uri.EscapeDataString(ClientAssertionType)}&client_assertion={Uri.EscapeDataString(clientAssertion)}&scope={Uri.EscapeDataString(string.Join(" ", scopes))}";

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();

            request.Content = RequestContent.Create(content);

            return request;
        }

        private static string CreateClientAssertionJWT(string clientId, string audience, X509Certificate2 clientCertificate)
        {
            var headerBuff = new ArrayBufferWriter<byte>();

            using (var headerJson = new Utf8JsonWriter(headerBuff))
            {
                headerJson.WriteStartObject();

                headerJson.WriteString("typ", "JWT");
                headerJson.WriteString("alg", "RS256");
                headerJson.WriteString("x5t", Base64Url.HexToBase64Url(clientCertificate.Thumbprint));

                headerJson.WriteEndObject();

                headerJson.Flush();
            }

            var payloadBuff = new ArrayBufferWriter<byte>();

            using (var payloadJson = new Utf8JsonWriter(payloadBuff))
            {
                payloadJson.WriteStartObject();

                payloadJson.WriteString("jti", Guid.NewGuid());
                payloadJson.WriteString("aud", audience);
                payloadJson.WriteString("iss", clientId);
                payloadJson.WriteString("sub", clientId);
                payloadJson.WriteNumber("nbf", DateTimeOffset.UtcNow.ToUnixTimeSeconds());
                payloadJson.WriteNumber("exp", (DateTimeOffset.UtcNow + TimeSpan.FromMinutes(30)).ToUnixTimeSeconds());

                payloadJson.WriteEndObject();

                payloadJson.Flush();
            }

            string header = Base64Url.Encode(headerBuff.WrittenMemory.ToArray());

            string payload = Base64Url.Encode(payloadBuff.WrittenMemory.ToArray());

            string flattenedJws = header + "." + payload;

            byte[] signature = clientCertificate.GetRSAPrivateKey().SignData(Encoding.ASCII.GetBytes(flattenedJws), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            return flattenedJws + "." + Base64Url.Encode(signature);
        }

        private static async Task<AccessToken> DeserializeAsync(Stream content, CancellationToken cancellationToken)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false))
            {
                return Deserialize(json.RootElement);
            }
        }

        private static AccessToken Deserialize(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                return Deserialize(json.RootElement);
            }
        }

        private static AccessToken Deserialize(JsonElement json)
        {
            string accessToken = null;

            DateTimeOffset expiresOn = DateTimeOffset.MaxValue;

            foreach (JsonProperty prop in json.EnumerateObject())
            {
                switch (prop.Name)
                {
                    case "access_token":
                        accessToken = prop.Value.GetString();
                        break;

                    case "expires_in":
                        expiresOn = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(prop.Value.GetInt64());
                        break;
                }
            }

            return new AccessToken(accessToken, expiresOn);
        }
    }
}
