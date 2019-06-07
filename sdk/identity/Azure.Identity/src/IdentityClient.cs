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
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal class IdentityClient
    {
        private readonly IdentityClientOptions _options;
        private readonly HttpPipeline _pipeline;
        private readonly Uri ImdsEndptoint = new Uri("http://169.254.169.254/metadata/identity/oauth2/token");
        private readonly string MsiApiVersion = "2018-02-01";

        public IdentityClient(IdentityClientOptions options = null)
        {
            _options = options ?? new IdentityClientOptions();

            _pipeline = HttpPipeline.Build(_options,
                    _options.ResponseClassifier,
                    _options.RetryPolicy,
                    ClientRequestIdPolicy.Singleton,
                    BufferResponsePolicy.Singleton);
        }

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

            request.Method = HttpPipelineMethod.Get;

            request.Headers.SetValue("Content-Type", "application/x-www-form-urlencoded");

            request.UriBuilder.Uri = _options.AuthorityHost;

            request.UriBuilder.AppendPath(tenantId);

            request.UriBuilder.AppendPath("/oauth2/v2.0/token");

            var bodyStr = $"response_type=token&grant_type=client_credentials&client_id={Uri.EscapeDataString(clientId)}&client_secret={Uri.EscapeDataString(clientSecret)}&scope={Uri.EscapeDataString(string.Join(" ", scopes))}";

            ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(bodyStr).AsMemory();

            request.Content = HttpPipelineRequestContent.Create(content);

            return request;
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
