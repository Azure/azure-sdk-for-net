// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Pipeline;
using NUnit.Framework;
using System.Net;

namespace Azure.Identity.Tests
{
    public class MultiTenantLiveTests : IdentityRecordedTestBase
    {
        public MultiTenantLiveTests(bool isAsync) : base(isAsync)
        { }

        private IdentityTestClient _client;

        [RecordedTest]
        public async Task CallGraphWithClientSecret()
        {
            var tenantId = TestEnvironment.MultiTenantAppTenantId;
            var clientId = TestEnvironment.MultiTenantAppClientId;
            var secret = TestEnvironment.MultiTenantAppClientSecret;

            var options = InstrumentClientOptions(new TokenCredentialOptions());
            var credential = InstrumentClient(new ClientSecretCredential(tenantId, clientId, secret, options));
            _client = InstrumentClient(new IdentityTestClient(
                credential,
                new Uri("https://graph.microsoft.com/v1.0/applications/$count"),
                options));

            var response = await _client.CallGraphAsync("https://graph.microsoft.com/.default");

            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            Assert.Greater(response.Value, 0);
        }

        [RecordedTest]
        public async Task GraphWithUsernamePassword()
        {
            var tenantId = TestEnvironment.MultiTenantAppTenantId;
            var clientId = TestEnvironment.MultiTenantAppClientId;
            var username = TestEnvironment.MultiTenantUserName;
            var password = TestEnvironment.MultiTenantPassword;

            var options = InstrumentClientOptions(new TokenCredentialOptions());
            var credential = InstrumentClient(new UsernamePasswordCredential(username, password, tenantId, clientId, options));

            _client = InstrumentClient(new IdentityTestClient(
                credential,
                new Uri("https://graph.microsoft.com/v1.0/applications/$count"),
                options));

            var response = await _client.CallGraphAsync("User.Read");

            Assert.AreEqual((int)HttpStatusCode.OK, response.GetRawResponse().Status);
            Assert.Greater(response.Value, 0);
        }

        public class IdentityTestClient
        {
            public IdentityTestClient(TokenCredential credential, Uri uri, TokenCredentialOptions options)
            {
                this.credential = credential;
                Uri = uri;
                _pipeline = HttpPipelineBuilder.Build(options);
            }

            protected IdentityTestClient() { }

            private TokenCredential credential { get; }
            private Uri Uri { get; }
            private HttpPipeline _pipeline { get; }

            [ForwardsClientCalls(true)]
            public virtual Response<int> CallGraph(string scope)
            {
                var tokenRequestContext = new TokenRequestContext(new[] { scope });
                AccessToken token = credential.GetTokenAsync(tokenRequestContext, default).GetAwaiter().GetResult();
                Request request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://graph.microsoft.com/v1.0/applications/$count"));
                request.Headers.Add("Authorization", $"Bearer {token.Token}");
                request.Headers.Add("ConsistencyLevel", "eventual");

                Response response = _pipeline.SendRequest(request, default);
                if (response.IsError)
                {
                    throw new Exception(response.ReasonPhrase);
                }
                if (int.TryParse(response.Content.ToString(), out int result))
                {
                    return Response.FromValue(result, response);
                }
                else
                {
                    throw new Exception("Could not parse response:\n" + response.Content.ToString());
                }
            }

            [ForwardsClientCalls(true)]
            public virtual async Task<Response<int>> CallGraphAsync(string scope)
            {
                var tokenRequestContext = new TokenRequestContext(new[] { scope });
                AccessToken token = await credential.GetTokenAsync(tokenRequestContext, default);
                Request request = _pipeline.CreateRequest();
                request.Method = RequestMethod.Get;
                request.Uri.Reset(new Uri("https://graph.microsoft.com/v1.0/applications/$count"));
                request.Headers.Add("Authorization", $"Bearer {token.Token}");
                request.Headers.Add("ConsistencyLevel", "eventual");

                Response response = await _pipeline.SendRequestAsync(request, default);
                if (response.IsError)
                {
                    throw new Exception(response.ReasonPhrase);
                }
                if (int.TryParse(response.Content.ToString(), out int result))
                {
                    return Response.FromValue(result, response);
                }
                else
                {
                    throw new Exception("Could not parse response:\n" + response.Content.ToString());
                }
            }
        }
    }
}
