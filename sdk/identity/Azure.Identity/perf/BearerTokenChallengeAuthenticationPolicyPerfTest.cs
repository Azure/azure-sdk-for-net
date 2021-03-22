// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Test.Perf;

namespace Azure.Template.Perf
{
    public class BearerTokenChallengeAuthenticationPolicyPerfTest : PerfTest<CountOptions>
    {
        private HttpPipeline _pipeline;
        private HttpMessage _message;

        public BearerTokenChallengeAuthenticationPolicyPerfTest(CountOptions options) : base(options)
        {
            var _transport = new MockTransport((req) => new MockResponse(200));
            _pipeline = new HttpPipeline(_transport, new[] { new BearerTokenChallengeAuthenticationPolicy(new StaticCredential(), "scope") });
            _message = _pipeline.CreateMessage();
            _message.BufferResponse = true;
            _message.Request.Method = RequestMethod.Get;
            _message.Request.Uri.Reset(new Uri("https://example.com"));

            var cred = new ClientSecretCredential(
    "72f988bf-86f1-41af-91ab-2d7cd011db47",
    "72922900-c1f3-4e6e-b264-11461d084c0b",
    "83ea2c0d-df4f-443b-8fea-d76e97851288",
    new ClientSecretCredentialOptions()
    {
        Diagnostics = { IsLoggingEnabled = true },
        TokenCachePersistenceOptions = new TokenCachePersistenceOptions()
    });
            var options2 = new SharedTokenCacheCredentialOptions(new TokenCachePersistenceOptions()) { Diagnostics = { IsLoggingEnabled = true } };
            //options2.Username = "identitytestuser@azuresdkplayground.onmicrosoft.com";
            //options2.TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            var cred2 = new SharedTokenCacheCredential(options2);

            var token = cred.GetToken(new TokenRequestContext(new[] { "https://storage.azure.com/.default" }), default);
            var token2 = cred2.GetToken(new TokenRequestContext(new[] { "https://storage.azure.com/.default" }), default);
        }

        public override void Run(CancellationToken cancellationToken)
        {
            _pipeline.Send(_message, cancellationToken);
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await _pipeline.SendAsync(_message, cancellationToken).ConfigureAwait(false);
        }
    }
}
