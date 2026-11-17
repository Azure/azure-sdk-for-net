// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.Resources
{
    public abstract class ResourcesTestBase : SpectorTestBase
    {
        protected const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        protected const string ResourceGroupName = "test-rg";
        protected const string TopLevelResourceName = "top";
        protected static readonly AzureLocation Location = AzureLocation.EastUS;

        protected static ResourceIdentifier ResourceGroupId => new($"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}");

        protected static ResourceIdentifier TopLevelResourceId => TopLevelTrackedResource.CreateResourceIdentifier(
            SubscriptionId, ResourceGroupName, TopLevelResourceName);

        protected static ArmClient GetClient(Uri host)
        {
            ArmClientOptions options = new()
            {
                Environment = new ArmEnvironment(new UriBuilder(host) { Scheme = Uri.UriSchemeHttps }.Uri, host.AbsoluteUri),
                Transport = new InsecureTransport()
            };
            return new ArmClient(new TestCredential(), default(string), options);
        }

        protected static void AssertResource(ResourceData data, ResourceIdentifier expectedId, string expectedName, string expectedType)
        {
            Assert.Multiple(() =>
            {
                Assert.That(data.Id, Is.EqualTo(expectedId));
                Assert.That(data.Name, Is.EqualTo(expectedName));
                Assert.That(data.ResourceType.ToString(), Is.EqualTo(expectedType));
                Assert.That(data.SystemData.CreatedBy, Is.EqualTo("AzureSDK"));
                Assert.That(data.SystemData.CreatedByType, Is.EqualTo(CreatedByType.User));
                Assert.That(data.SystemData.CreatedOn, Is.EqualTo(DateTimeOffset.Parse("2024-10-04T00:56:07.442Z")));
                Assert.That(data.SystemData.LastModifiedBy, Is.EqualTo("AzureSDK"));
                Assert.That(data.SystemData.LastModifiedByType, Is.EqualTo(CreatedByType.User));
                Assert.That(data.SystemData.LastModifiedOn, Is.EqualTo(data.SystemData.CreatedOn));
            });
        }

        protected static async Task AssertList<T>(AsyncPageable<T> resources, Action<T> assertResource) where T : notnull
        {
            int count = 0;
            await foreach (T resource in resources)
            {
                assertResource(resource);
                count++;
            }
            Assert.That(count, Is.EqualTo(1));
        }

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
    }
}
