// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroup;
using Azure.ResourceManager.ManagementGroup.Models;
using Azure.ResourceManager.ManagementGroups;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.ManagementGroup
{
    public class ManagementGroupChildResourcesTests : SpectorTestBase
    {
        private const string ManagementGroupId = "test-mg";
        private const string ResourceName = "resource";

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
            ManagementGroupChildResource resource = await GetManagementGroup(host)
                .GetManagementGroupChildResourceAsync(ResourceName);

            AssertResource(resource.Data, "valid");
        });

        [SpectorTest]
        public Task CreateOrUpdate() => Test(async host =>
        {
            ManagementGroupChildResourceData data = CreateData("valid");

            var operation = await GetManagementGroup(host).GetManagementGroupChildResources()
                .CreateOrUpdateAsync(WaitUntil.Completed, ResourceName, data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertResource(operation.Value.Data, "valid");
        });

        [SpectorTest]
        public Task Update() => Test(async host =>
        {
            ManagementGroupChildResource resource = GetClient(host).GetManagementGroupChildResource(
                ManagementGroupChildResource.CreateResourceIdentifier(ManagementGroupId, ResourceName));

            Response<ManagementGroupChildResource> response = await resource.UpdateAsync(CreateData("valid2"));

            AssertResource(response.Value.Data, "valid2");
        });

        [SpectorTest]
        public Task Delete() => Test(async host =>
        {
            ManagementGroupChildResource resource = GetClient(host).GetManagementGroupChildResource(
                ManagementGroupChildResource.CreateResourceIdentifier(ManagementGroupId, ResourceName));

            var operation = await resource.DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
        });

        [SpectorTest]
        public Task ListByManagementGroup() => Test(async host =>
        {
            int count = 0;
            await foreach (ManagementGroupChildResource resource in GetManagementGroup(host).GetManagementGroupChildResources().GetAllAsync())
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

        private static ManagementGroupResource GetManagementGroup(Uri host) => GetClient(host).GetManagementGroupResource(
            ManagementGroupResource.CreateResourceIdentifier(ManagementGroupId));

        private static ManagementGroupChildResourceData CreateData(string description) => new()
        {
            Properties = new ManagementGroupChildResourceProperties { Description = description }
        };

        private static void AssertResource(ManagementGroupChildResourceData data, string expectedDescription)
        {
            Assert.That(data.Name, Is.EqualTo(ResourceName));
            Assert.That(data.Properties.Description, Is.EqualTo(expectedDescription));
            Assert.That(data.Properties.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
        }
    }
}
