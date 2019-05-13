// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    public class CredentialOptions : HttpClientOptions
    {
        private const string DefaultAuthorityHost = "https://login.microsoftonline.com/";
        private readonly static TimeSpan DefaultRefreshBuffer = TimeSpan.FromMinutes(2);

        public RetryPolicy RetryPolicy { get; set; }

        public HttpPipelinePolicy LoggingPolicy { get; set; }

        public string AuthorityHost { get; set; }

        public TimeSpan RefreshBuffer { get; set; }

        public CredentialOptions()
        {
            AuthorityHost = DefaultAuthorityHost;
            LoggingPolicy = Core.Pipeline.Policies.LoggingPolicy.Shared;
            RefreshBuffer = DefaultRefreshBuffer;
            RetryPolicy = new ExponentialRetryPolicy()
            {
                Delay = TimeSpan.FromMilliseconds(800),
                MaxRetries = 3
            };
        }
    }

    internal class IdentityClient
    {
        private readonly CredentialOptions _options;
        private readonly HttpPipeline _pipeline;
        

        public IdentityClient(CredentialOptions options = null)
        {
            _options = options ?? new CredentialOptions();

            _pipeline = HttpPipeline.Build(_options,
                    _options.ResponseClassifier,
                    _options.RetryPolicy,
                    ClientRequestIdPolicy.Singleton,
                    _options.LoggingPolicy,
                    BufferResponsePolicy.Singleton);
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(string tenantId, string clientId, string clientSecret, IEnumerable<string> scopes, CancellationToken cancellationToken = default)
        {
            Uri authUri = new Uri(_options.AuthorityHost + tenantId + "/oauth2/token");

            using (var request = _pipeline.CreateRequest())
            {
                var body = new Dictionary<string, string>() {
                    { "response_type", "token" },
                    { "grant_type", "client_credentials" },
                    { "client_id", clientId },
                    { "client_secret", clientSecret },
                    { "scopes", string.Join(" ", scopes) }
                };

                request.SetRequestLine(HttpPipelineMethod.Put, authUri);

                ReadOnlyMemory<byte> content = Serialize(body);

                request.Content = HttpPipelineRequestContent.Create(content);

                var response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 201)
                {
                    var result = await DeserializeAsync(response.ContentStream, cancellationToken).ConfigureAwait(false);

                    return new Response<AuthenticationResponse>(response, result);
                }

                throw await response.CreateRequestFailedExceptionAsync();
            }
        }

        private ReadOnlyMemory<byte> Serialize(Dictionary<string,string> dict)
        {
            var buff = new byte[1024];

            var writer = new FixedSizedBufferWriter(buff);

            var json = new Utf8JsonWriter(writer);

            json.WriteStartObject();

            foreach(var prop in dict)
            {
                json.WriteString(prop.Key, prop.Value);
            }

            json.WriteEndObject();

            return buff.AsMemory(0, (int)json.BytesWritten);
        }

        private async Task<AuthenticationResponse> DeserializeAsync(Stream content, CancellationToken cancellationToken)
        {
            using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false))
            {
                var response = new Dictionary<string, string>();

                foreach(var property in json.RootElement.EnumerateObject())
                {
                    response.Add(property.Name, property.Value.GetString());
                }

                return new AuthenticationResponse(response);
            }
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
