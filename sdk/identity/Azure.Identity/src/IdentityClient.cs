// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal class IdentityClient
    {
        private static Lazy<IdentityClient> s_sharedClient = new Lazy<IdentityClient>(() => new IdentityClient());

        private readonly IdentityClientOptions _options;
        private readonly HttpPipeline _pipeline;
        private readonly Uri ImdsEndptoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        private const string MsiApiVersion = "2018-02-01";
        private const string ClientAssertionType = "urn:ietf:params:oauth:client-assertion-type:jwt-bearer";

        public IdentityClient(IdentityClientOptions options = null)
        {
            _options = options ?? new IdentityClientOptions();

            _pipeline = HttpPipelineBuilder.Build(_options, bufferResponse: true);
        }

        public static IdentityClient SharedClient { get { return s_sharedClient.Value; } }


        public virtual async Task<AccessToken> AuthenticateAsync(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateClientSecretAuthRequest(tenantId, clientId, clientSecret, scopes))
            {
                var response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 201)
                {
                    var result = await DeserializeAsync(response.ContentStream, cancellationToken).ConfigureAwait(false);

                    return new Response<AccessToken>(response, result);
                }

                throw await response.CreateRequestFailedExceptionAsync();
            }
        }

        public virtual AccessToken Authenticate(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateClientSecretAuthRequest(tenantId, clientId, clientSecret, scopes))
            {
                var response = _pipeline.SendRequest(request, cancellationToken);

                if (response.Status == 200 || response.Status == 201)
                {
                    var result = Deserialize(response.ContentStream);

                    return new Response<AccessToken>(response, result);
                }

                throw response.CreateRequestFailedException();
            }
        }

        public virtual async Task<AccessToken> AuthenticateAsync(string tenantId, string clientId, X509Certificate2 clientCertificate, string[] scopes, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateClientCertificateAuthRequest(tenantId, clientId, clientCertificate, scopes))
            {
                var response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 201)
                {
                    var result = await DeserializeAsync(response.ContentStream, cancellationToken).ConfigureAwait(false);

                    return new Response<AccessToken>(response, result);
                }

                throw await response.CreateRequestFailedExceptionAsync();
            }
        }

        public virtual AccessToken Authenticate(string tenantId, string clientId, X509Certificate2 clientCertificate, string[] scopes, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateClientCertificateAuthRequest(tenantId, clientId, clientCertificate, scopes))
            {
                var response = _pipeline.SendRequest(request, cancellationToken);

                if (response.Status == 200 || response.Status == 201)
                {
                    var result = Deserialize(response.ContentStream);

                    return new Response<AccessToken>(response, result);
                }

                throw response.CreateRequestFailedException();
            }
        }
        public virtual async Task<AccessToken> AuthenticateManagedIdentityAsync(string[] scopes, string clientId = null, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateManagedIdentityAuthRequest(scopes, clientId))
            {
                var response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 201)
                {
                    var result = await DeserializeAsync(response.ContentStream, cancellationToken).ConfigureAwait(false);

                    return new Response<AccessToken>(response, result);
                }

                throw response.CreateRequestFailedException();
            }
        }

        public virtual AccessToken AuthenticateManagedIdentity(string[] scopes, string clientId = null, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateManagedIdentityAuthRequest(scopes, clientId))
            {
                var response = _pipeline.SendRequest(request, cancellationToken);

                if (response.Status == 200 || response.Status == 201)
                {
                    var result = Deserialize(response.ContentStream);

                    return new Response<AccessToken>(response, result);
                }

                throw response.CreateRequestFailedException();
            }
        }

        private Request CreateManagedIdentityAuthRequest(string[] scopes, string clientId = null)
        {
            // covert the scopes to a resource string
            string resource = ScopeUtilities.ScopesToResource(scopes);

            Request request = _pipeline.CreateRequest();

            request.Method = HttpPipelineMethod.Get;

            request.Headers.Add("Metadata", "true");

            // TODO: support MSI for hosted services
            request.UriBuilder.Uri = ImdsEndptoint;

            request.UriBuilder.AppendQuery("api-version", MsiApiVersion);

            request.UriBuilder.AppendQuery("resource", Uri.EscapeDataString(resource));

            if (!string.IsNullOrEmpty(clientId))
            {
                request.UriBuilder.AppendQuery("client_id", Uri.EscapeDataString(clientId));
            }

            return request;
        }

        private Request CreateClientSecretAuthRequest(string tenantId, string clientId, string clientSecret, string[] scopes)
        {
            Request request = _pipeline.CreateRequest();

            request.Method = HttpPipelineMethod.Post;

            request.Headers.SetValue("Content-Type", "application/x-www-form-urlencoded");

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

            request.Method = HttpPipelineMethod.Post;

            request.Headers.SetValue("Content-Type", "application/x-www-form-urlencoded");

            request.UriBuilder.Uri = _options.AuthorityHost;

            request.UriBuilder.AppendPath(tenantId);

            request.UriBuilder.AppendPath("/oauth2/v2.0/token");

            string clientAssertion = CreateClientAssertionJWT(clientId, request.UriBuilder.ToString(), clientCertficate);

            var bodyStr = $"response_type=token&grant_type=client_credentials&client_id={Uri.EscapeDataString(clientId)}&client_assertion_type={Uri.EscapeDataString(ClientAssertionType)}&client_assertion={Uri.EscapeDataString(clientAssertion)}&scope={Uri.EscapeDataString(string.Join(" ", scopes))}";

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();

            request.Content = HttpPipelineRequestContent.Create(content);

            return request;
        }

        private string CreateClientAssertionJWT(string clientId, string audience, X509Certificate2 clientCertificate)
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

        private async Task<AccessToken> DeserializeAsync(Stream content, CancellationToken cancellationToken)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false))
            {
                return Deserialize(json.RootElement);
            }
        }

        private AccessToken Deserialize(Stream content)
        {
            using (JsonDocument json = JsonDocument.Parse(content))
            {
                return Deserialize(json.RootElement);
            }
        }

        private AccessToken Deserialize(JsonElement json)
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
