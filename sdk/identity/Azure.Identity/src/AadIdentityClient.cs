// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Http;

namespace Azure.Identity
{
    internal class AadIdentityClient
    {
        private static Lazy<AadIdentityClient> s_sharedClient = new Lazy<AadIdentityClient>(() => new AadIdentityClient(null));

        private readonly IdentityClientOptions _options;
        private readonly HttpPipeline _pipeline;

        private const string ClientAssertionType = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer";

        private const string AuthenticationRequestFailedError = "The request to the identity service failed.  See inner exception for details.";

        protected AadIdentityClient()
        {
        }

        public AadIdentityClient(IdentityClientOptions options = null)
        {
            _options = options ?? new IdentityClientOptions();

            _pipeline = HttpPipelineBuilder.Build(_options, bufferResponse: true);
        }

        public static AadIdentityClient SharedClient { get { return s_sharedClient.Value; } }


        public virtual async Task<AccessToken> AuthenticateAsync(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Identity.AadIdentityClient.Authenticate");
            scope.Start();

            try
            {
                using Request request = CreateClientSecretAuthRequest(tenantId, clientId, clientSecret, scopes);
                try
                {
                    return await SendAuthRequestAsync(request, cancellationToken).ConfigureAwait(false);
                }
                catch (RequestFailedException ex)
                {
                    throw new AuthenticationFailedException(AuthenticationRequestFailedError, ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual AccessToken Authenticate(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Identity.AadIdentityClient.Authenticate");
            scope.Start();

            try
            {
                using Request request = CreateClientSecretAuthRequest(tenantId, clientId, clientSecret, scopes);
                try
                {
                    return SendAuthRequest(request, cancellationToken);
                }
                catch (RequestFailedException ex)
                {
                    throw new AuthenticationFailedException(AuthenticationRequestFailedError, ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<AccessToken> AuthenticateAsync(string tenantId, string clientId, X509Certificate2 clientCertificate, string[] scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Identity.AadIdentityClient.Authenticate");
            scope.Start();

            try
            {
                using Request request = CreateClientCertificateAuthRequest(tenantId, clientId, clientCertificate, scopes);
                try
                {
                    return await SendAuthRequestAsync(request, cancellationToken).ConfigureAwait(false);
                }
                catch (RequestFailedException ex)
                {
                    throw new AuthenticationFailedException(AuthenticationRequestFailedError, ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual AccessToken Authenticate(string tenantId, string clientId, X509Certificate2 clientCertificate, string[] scopes, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.Diagnostics.CreateScope("Azure.Identity.AadIdentityClient.Authenticate");
            scope.Start();

            try
            {
                using Request request = CreateClientCertificateAuthRequest(tenantId, clientId, clientCertificate, scopes);
                try
                {
                    return SendAuthRequest(request, cancellationToken);
                }
                catch (RequestFailedException ex)
                {
                    throw new AuthenticationFailedException(AuthenticationRequestFailedError, ex);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<AccessToken> SendAuthRequestAsync(Request request, CancellationToken cancellationToken)
        {
            var response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

            if (response.Status == 200 || response.Status == 201)
            {
                var result = await DeserializeAsync(response.ContentStream, cancellationToken).ConfigureAwait(false);

                return new Response<AccessToken>(response, result);
            }

            throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
        }

        private AccessToken SendAuthRequest(Request request, CancellationToken cancellationToken)
        {
            var response = _pipeline.SendRequest(request, cancellationToken);

            if (response.Status == 200 || response.Status == 201)
            {
                var result = Deserialize(response.ContentStream);

                return new Response<AccessToken>(response, result);
            }

            throw response.CreateRequestFailedException();
        }

        private Request CreateClientSecretAuthRequest(string tenantId, string clientId, string clientSecret, string[] scopes)
        {
            Request request = _pipeline.CreateRequest();

            request.Method = RequestMethod.Post;

            request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

            request.UriBuilder.Uri = _options.AuthorityHost;

            request.UriBuilder.AppendPath(tenantId);

            request.UriBuilder.AppendPath("/oauth2/v2.0/token");

            var bodyStr = $"response_type=token&grant_type=client_credentials&client_id={Uri.EscapeDataString(clientId)}&client_secret={Uri.EscapeDataString(clientSecret)}&scope={Uri.EscapeDataString(string.Join(" ", scopes))}";

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();

            request.Content = HttpPipelineRequestContent.Create(content);

            return request;
        }

        private Request CreateClientCertificateAuthRequest(string tenantId, string clientId, X509Certificate2 clientCertficate, string[] scopes)
        {
            Request request = _pipeline.CreateRequest();

            request.Method = RequestMethod.Post;

            request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

            request.UriBuilder.Uri = _options.AuthorityHost;

            request.UriBuilder.AppendPath(tenantId);

            request.UriBuilder.AppendPath("/oauth2/v2.0/token");

            string clientAssertion = CreateClientAssertionJWT(clientId, request.UriBuilder.ToString(), clientCertficate);

            var bodyStr = $"response_type=token&grant_type=client_credentials&client_id={Uri.EscapeDataString(clientId)}&client_assertion_type={Uri.EscapeDataString(ClientAssertionType)}&client_assertion={Uri.EscapeDataString(clientAssertion)}&scope={Uri.EscapeDataString(string.Join(" ", scopes))}";

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();

            request.Content = HttpPipelineRequestContent.Create(content);

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

            if (json.TryGetProperty("access_token", out JsonElement accessTokenProp))
            {
                accessToken = accessTokenProp.GetString();
            }

            if (json.TryGetProperty("expires_in", out JsonElement expiresInProp))
            {
                expiresOn = DateTime.UtcNow + TimeSpan.FromSeconds(expiresInProp.GetInt64());
            }

            return new AccessToken(accessToken, expiresOn);
        }
    }
}
