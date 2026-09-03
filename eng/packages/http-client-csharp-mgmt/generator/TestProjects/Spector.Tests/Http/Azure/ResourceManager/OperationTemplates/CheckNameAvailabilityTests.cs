// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.OperationTemplates;
using Azure.ResourceManager.OperationTemplates.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.OperationTemplates
{
    public class CheckNameAvailabilityTests : SpectorTestBase
    {
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

        [SpectorTest]
        public Task CheckGlobal() => Test(async host =>
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000000";
            ArmClientOptions options = new()
            {
                Environment = new ArmEnvironment(new UriBuilder(host) { Scheme = Uri.UriSchemeHttps }.Uri, host.AbsoluteUri),
                Transport = new InsecureTransport()
            };
            ArmClient client = new(new TestCredential(), subscriptionId, options);
            SubscriptionResource subscription = client.GetSubscriptionResource(
                SubscriptionResource.CreateResourceIdentifier(subscriptionId));
            CheckNameAvailabilityRequest request = new()
            {
                Name = "checkName",
                Type = "Microsoft.Web/site"
            };

            var response = await subscription.CheckGlobalAsync(request);

            Assert.That(response.Value.NameAvailable, Is.False);
            Assert.That(response.Value.Message, Is.EqualTo("Hostname 'checkName' already exists. Please select a different name."));
        });
    }
}
