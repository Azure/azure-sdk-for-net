// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core.TestFramework;
using Azure.Core;
using System.IO;
using System.Text.Json;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Tests
{
    internal class ContinuousAccessEvaluationTestsBase
    {
        protected MockResponse defaultCaeChallenge = new MockResponse(401).WithHeader("WWW-Authenticate", @"Bearer realm="""", authorization_uri=""https://login.microsoftonline.com/common/oauth2/authorize"", error=""insufficient_claims"", claims=""eyJhY2Nlc3NfdG9rZW4iOnsibmJmIjp7ImVzc2VudGlhbCI6dHJ1ZSwidmFsdWUiOiIxNzI2MDc3NTk1In0sInhtc19jYWVlcnJvciI6eyJ2YWx1ZSI6IjEwMDEyIn19fQ==""");

        protected MockResponse defaultInitialChallenge = new MockResponse(401).WithHeader("WWW-Authenticate", @"Bearer authorization=""https://login.windows.net/de763a21-49f7-4b08-a8e1-52c8fbc103b4"", resource=""https://vault.azure.net""");

        private const string VaultHost = "test.vault.azure.net";
        protected Uri VaultUri => new Uri("https://" + VaultHost);

        protected MockTransport GetMockTransportWithCaeChallenges(int numberOfCaeChallenges = 1, MockResponse final200response = null )
        {
            if (numberOfCaeChallenges < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfCaeChallenges), "Number of CAE challenges must be greater than or equal to 1.");
            }

            var responses = new List<MockResponse> { defaultInitialChallenge };
            for (int i = 0; i < numberOfCaeChallenges; i++)
            {
                responses.Add(defaultCaeChallenge);
            }
            if (final200response != null)
            {
                responses.Add(final200response);
            }
            return new MockTransport(responses.ToArray());
        }

        protected MockTransport GetMockCredentialTransport(int numberOfTokenResponses = 1)
        {
            if (numberOfTokenResponses < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfTokenResponses), "Number of token responses must be greater than or equal to 1.");
            }

            var responses = new List<MockResponse>();
            for (int i = 0; i < numberOfTokenResponses; i++)
            {
                responses.Add(new MockResponse(200)
                    .WithJson("""
                    {
                        "token_type": "Bearer",
                        "expires_in": 3599,
                        "resource": "https://vault.azure.net",
                        "access_token": "foo"
                    }
                    """));
            }
            return new MockTransport(responses.ToArray());
        }

        protected class TokenCredentialStub : TokenCredential
        {
            public TokenCredentialStub() { }

            public TokenCredentialStub(Func<TokenRequestContext, CancellationToken, AccessToken> handler, bool isAsync)
            {
                setCallBack(handler, isAsync);
            }

            private Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> _getTokenAsyncHandler;
            private Func<TokenRequestContext, CancellationToken, AccessToken> _getTokenHandler;

            public void setCallBack(Func<TokenRequestContext, CancellationToken, AccessToken> handler, bool isAsync)
            {
                if (isAsync)
                {
#pragma warning disable 1998
                    _getTokenAsyncHandler = async (r, c) => handler(r, c);
#pragma warning restore 1998
                }
                else
                {
                    _getTokenHandler = handler;
                }
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenAsyncHandler(requestContext, cancellationToken);

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => _getTokenHandler(requestContext, cancellationToken);
        }

        protected class MockCredential : TokenCredential
        {
            private readonly HttpPipeline _pipeline;
            private readonly string _tenantId;
            private readonly string _clientId;
            private readonly string _clientSecret;
            private const string TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            public MockCredential(MockTransport transport, string tenantId = TenantId, string clientId = "test_id", string clientSecret = "test_secret")
            {
                _pipeline = new HttpPipeline(transport);
                _tenantId = tenantId ?? throw new ArgumentNullException(nameof(tenantId));
                _clientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
                _clientSecret = clientSecret ?? throw new ArgumentNullException(nameof(clientSecret));
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken) => GetTokenAsync(requestContext, cancellationToken).EnsureCompleted();

            public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                Request request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Post;
                request.Headers.Add(HttpHeader.Common.FormUrlEncodedContentType);

                request.Uri.Reset(new Uri($"https://login.windows.net/{_tenantId}/oauth2/v2.0/token"));

                string body = $"response_type=token&grant_type=client_credentials&client_id={Uri.EscapeDataString(_clientId)}&client_secret={Uri.EscapeDataString(_clientSecret)}&scope={Uri.EscapeDataString(string.Join(" ", requestContext.Scopes))}";
                ReadOnlyMemory<byte> content = Encoding.UTF8.GetBytes(body).AsMemory();
                request.Content = RequestContent.Create(content);

                Response response = await _pipeline.SendRequestAsync(request, cancellationToken);
                if (response.Status == 200 || response.Status == 201)
                {
                    return await DeserializeAsync(response.ContentStream, cancellationToken);
                }

                throw new RequestFailedException(response.Status, response.ReasonPhrase);
            }

            private static async Task<AccessToken> DeserializeAsync(Stream content, CancellationToken cancellationToken)
            {
                using (JsonDocument json = await JsonDocument.ParseAsync(content, default, cancellationToken).ConfigureAwait(false))
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
}
