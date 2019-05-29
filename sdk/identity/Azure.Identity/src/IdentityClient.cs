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
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    internal class IdentityClient
    {
        private readonly IdentityClientOptions _options;
        private readonly HttpPipeline _pipeline;

        public IdentityClient(IdentityClientOptions options = null)
        {
            _options = options ?? new IdentityClientOptions();

            _pipeline = HttpPipeline.Build(_options,
                    _options.ResponseClassifier,
                    _options.RetryPolicy,
                    ClientRequestIdPolicy.Singleton,
                    BufferResponsePolicy.Singleton);
        }

        public async Task<AccessToken> AuthenticateAsync(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
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

        public AccessToken Authenticate(string tenantId, string clientId, string clientSecret, string[] scopes, CancellationToken cancellationToken = default)
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

        private Request CreateClientSecretAuthRequest(string tenantId, string clientId, string clientSecret, string[] scopes)
        {
            Request request = _pipeline.CreateRequest();

            request.Method = HttpPipelineMethod.Post;

            request.Headers.SetValue("Content-Type", "application/x-www-form-urlencoded");

            request.UriBuilder.Uri = _options.AuthorityHost;

            request.UriBuilder.AppendPath(tenantId);

            request.UriBuilder.AppendPath("/oauth2/v2.0/token");

            ReadOnlyMemory<byte> content = Serialize(
                ("response_type", "token"),
                ("grant_type", "client_credentials"),
                ("client_id", clientId),
                ("client_secret", clientSecret),
                ("scope", string.Join(" ", scopes)));

            request.Content = HttpPipelineRequestContent.Create(content);

            return request;
        }

        private ReadOnlyMemory<byte> Serialize(params (string, string)[] bodyArgs)
        {
            var buff = new byte[1024];

            var writer = new FixedSizedBufferWriter(buff);

            var json = new Utf8JsonWriter(writer);

            json.WriteStartObject();

            foreach (var prop in bodyArgs)
            {
                json.WriteString(prop.Item1, prop.Item2);
            }

            json.WriteEndObject();

            return buff.AsMemory(0, (int)json.BytesWritten);
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

        // TODO (pri 3): CoreFx will soon have a type like this. We should remove this one then.
        internal class FixedSizedBufferWriter : IBufferWriter<byte>
        {
            private readonly byte[] _buffer;
            private int _count;

            public FixedSizedBufferWriter(byte[] buffer)
            {
                _buffer = buffer;
            }

            public Memory<byte> GetMemory(int minimumLength = 0) => _buffer.AsMemory(_count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Span<byte> GetSpan(int minimumLength = 0) => _buffer.AsSpan(_count);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Advance(int bytes)
            {
                _count += bytes;
                if (_count > _buffer.Length)
                {
                    throw new InvalidOperationException("Cannot advance past the end of the buffer.");
                }
            }
        }
    }
}
