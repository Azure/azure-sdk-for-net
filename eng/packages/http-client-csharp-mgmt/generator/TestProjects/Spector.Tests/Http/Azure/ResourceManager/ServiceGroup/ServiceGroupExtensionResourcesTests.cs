// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ServiceGroupExtension;
using Azure.ResourceManager.ServiceGroupExtension.Models;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.ServiceGroup
{
    public class ServiceGroupExtensionResourcesTests : SpectorTestBase
    {
        private const string ServiceGroupId = "test-sg";
        private const string ResourceName = "resource";
        private static readonly ResourceIdentifier ServiceGroupResourceId = new($"/providers/Microsoft.Management/serviceGroups/{ServiceGroupId}");

        [SpectorTest]
        public Task Get() => Test(async host =>
        {
            ServiceGroupExtensionResource resource = await GetClient(host)
                .GetServiceGroupExtensionResourceAsync(ServiceGroupResourceId, ResourceName);

            AssertResource(resource.Data, "valid");
        });

        [SpectorTest]
        public Task CreateOrUpdate() => Test(async host =>
        {
            var operation = await GetClient(host).GetServiceGroupExtensionResources(ServiceGroupResourceId)
                .CreateOrUpdateAsync(WaitUntil.Completed, ResourceName, CreateData("valid"));

            Assert.That(operation.HasCompleted, Is.True);
            AssertResource(operation.Value.Data, "valid");
        });

        [SpectorTest]
        public Task Update() => Test(async host =>
        {
            ServiceGroupExtensionResource resource = GetClient(host).GetServiceGroupExtensionResource(
                ServiceGroupExtensionResource.CreateResourceIdentifier(ServiceGroupId, ResourceName));

            Response<ServiceGroupExtensionResource> response = await resource.UpdateAsync(CreateData("valid2"));
            AssertResource(response.Value.Data, "valid2");
        });

        [SpectorTest]
        public Task Delete() => Test(async host =>
        {
            ServiceGroupExtensionResource resource = GetClient(host).GetServiceGroupExtensionResource(
                ServiceGroupExtensionResource.CreateResourceIdentifier(ServiceGroupId, ResourceName));

            var operation = await resource.DeleteAsync(WaitUntil.Completed);
            Assert.That(operation.HasCompleted, Is.True);
        });

        [SpectorTest]
        public Task ListByServiceGroup() => Test(async host =>
        {
            int count = 0;
            await foreach (ServiceGroupExtensionResource resource in GetClient(host)
                .GetServiceGroupExtensionResources(ServiceGroupResourceId).GetAllAsync())
            {
                AssertResource(resource.Data, "valid");
                count++;
            }

            Assert.That(count, Is.EqualTo(1));
        });

        private static ArmClient GetClient(Uri host)
        {
            ArmClientOptions options = new()
            {
                Environment = new ArmEnvironment(new UriBuilder(host) { Scheme = Uri.UriSchemeHttps }.Uri, host.AbsoluteUri),
                Transport = new InsecureTransport()
            };
            return new ArmClient(new TestCredential(), default(string), options);
        }

        private static ServiceGroupExtensionResourceData CreateData(string description) => new()
        {
            Properties = new ServiceGroupExtensionResourceProperties { Description = description }
        };

        private static void AssertResource(ServiceGroupExtensionResourceData data, string description)
        {
            Assert.That(data.Name, Is.EqualTo(ResourceName));
            Assert.That(data.Properties.Description, Is.EqualTo(description));
            Assert.That(data.Properties.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
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
