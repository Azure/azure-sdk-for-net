// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Keys.Tests
{
    public class AttestationClient
    {
        private const string TokenPath = "/generate-test-token";

        private readonly Uri _endpoint;
        private readonly ClientDiagnostics _diagnostics;
        private readonly HttpPipeline _pipeline;

        public AttestationClient(Uri endpoint, KeyClientOptions options)
        {
            _endpoint = endpoint;
            _diagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options);
        }

        protected AttestationClient()
        {
        }

        public virtual Response<string> GetToken(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(GetToken)}");
            scope.Start();

            try
            {
                Request request = CreateTokenRequest();
                Response response = _pipeline.SendRequest(request, cancellationToken);

                TokenResult result = response.Content.ToObjectFromJson<TokenResult>();
                return Response.FromValue(result.Token, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<string>> GetTokenAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(AttestationClient)}.{nameof(GetToken)}");
            scope.Start();

            try
            {
                Request request = CreateTokenRequest();
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                TokenResult result = response.Content.ToObjectFromJson<TokenResult>();
                return Response.FromValue(result.Token, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Request CreateTokenRequest()
        {
            Request request = _pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri.Reset(_endpoint);
            request.Uri.AppendPath(TokenPath);

            return request;
        }

        private class TokenResult
        {
            [JsonPropertyName("token")]
            public string Token { get; set; }
        }
    }
}
