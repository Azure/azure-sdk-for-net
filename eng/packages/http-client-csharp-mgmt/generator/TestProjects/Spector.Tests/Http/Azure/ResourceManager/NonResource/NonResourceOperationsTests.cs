// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.NonResource;
using Azure.ResourceManager.Resources;
using NUnit.Framework;
using NonResourceModel = Azure.ResourceManager.NonResource.Models.NonResource;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.NonResource
{
    public class NonResourceOperationsTests : SpectorTestBase
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";

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
        public Task Get() => Test(async host =>
        {
            SubscriptionResource subscription = CreateClient(host).GetSubscriptionResource(
                SubscriptionResource.CreateResourceIdentifier(SubscriptionId));

            var response = await subscription.GetAsync("eastus", "hello");

            AssertNonResource(response.Value);
        });

        [SpectorTest]
        public Task Create() => Test(async host =>
        {
            SubscriptionResource subscription = CreateClient(host).GetSubscriptionResource(
                SubscriptionResource.CreateResourceIdentifier(SubscriptionId));
            NonResourceModel body = new()
            {
                Id = "id",
                Name = "hello",
                Type = "nonResource"
            };

            var response = await subscription.CreateAsync("eastus", "hello", body);

            AssertNonResource(response.Value);
        });

        private static ArmClient CreateClient(Uri host)
        {
            ArmClientOptions options = new()
            {
                Environment = new ArmEnvironment(new UriBuilder(host) { Scheme = Uri.UriSchemeHttps }.Uri, host.AbsoluteUri),
                Transport = new InsecureTransport()
            };
            return new ArmClient(new TestCredential(), SubscriptionId, options);
        }

        private static void AssertNonResource(NonResourceModel value)
        {
            Assert.That(value.Id, Is.EqualTo("id"));
            Assert.That(value.Name, Is.EqualTo("hello"));
            Assert.That(value.Type, Is.EqualTo("nonResource"));
        }
    }
}
