// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.LargeHeader;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.LargeHeader
{
    public class LargeHeadersTests : SpectorTestBase
    {
        // Keep requests HTTPS through authentication, then switch to HTTP only when sending to the local Spector server.
        private sealed class InsecureTransport : HttpPipelineTransport
        {
            private readonly HttpClientTransport _transport = new();

            public override Request CreateRequest() => _transport.CreateRequest();

            public override void Process(HttpMessage message)
            {
                message.Request.Uri.Scheme = Uri.UriSchemeHttp;
                _transport.Process(message);
            }

            public override ValueTask ProcessAsync(HttpMessage message)
            {
                message.Request.Uri.Scheme = Uri.UriSchemeHttp;
                return _transport.ProcessAsync(message);
            }
        }

        private sealed class TestCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new("token", DateTimeOffset.MaxValue);

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(GetToken(requestContext, cancellationToken));
        }

        // LRO polling URLs returned by Spector use HTTP. Normalize them before the bearer-token policy validates the scheme.
        private sealed class ForceHttpsPolicy : HttpPipelineSynchronousPolicy
        {
            public override void OnSendingRequest(HttpMessage message)
            {
                message.Request.Uri.Scheme = Uri.UriSchemeHttps;
            }
        }

        [SpectorTest]
        public Task Two6k() => Test(async host =>
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ArmClientOptions options = new()
            {
                Environment = new ArmEnvironment(new UriBuilder(host) { Scheme = Uri.UriSchemeHttps }.Uri, host.AbsoluteUri),
                Transport = new InsecureTransport()
            };
            options.AddPolicy(new ForceHttpsPolicy(), HttpPipelinePosition.PerCall);
            ArmClient client = new(new TestCredential(), subscriptionId, options);
            ResourceGroupResource resourceGroup = client.GetResourceGroupResource(
                ResourceGroupResource.CreateResourceIdentifier(subscriptionId, "test-rg"));

            var operation = await resourceGroup.Two6kAsync(WaitUntil.Completed, "header1");

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.Value.Succeeded, Is.True);
        });
    }
}
