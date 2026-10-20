// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MethodSubscriptionId;
using Azure.ResourceManager.MethodSubscriptionId.Models;
using Azure.ResourceManager.Models;
using NUnit.Framework;
using ResourceGroupResource = Azure.ResourceManager.Resources.ResourceGroupResource;
using SubscriptionResource = Azure.ResourceManager.Resources.SubscriptionResource;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.MethodSubscriptionId
{
    // Covers the twelve resource scenarios. ManagementInputLibrary intentionally omits
    // the provider-operations listing API because Azure.ResourceManager already provides it.
    public class MethodSubscriptionIdTests : SpectorTestBase
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private const string ResourceGroupName = "test-rg";

        [SpectorTest]
        public Task GetSubscriptionResource1() => Test(async host =>
        {
            SubscriptionResource1Resource resource = await GetSubscription(host)
                .GetSubscriptionResource1s().GetAsync("sub-resource-1");

            AssertSubscriptionResource1(resource.Data);
        });

        [SpectorTest]
        public Task CreateOrUpdateSubscriptionResource1() => Test(async host =>
        {
            SubscriptionResource1Data data = new()
            {
                Properties = new SubscriptionResource1Properties { Description = "Valid subscription resource 1" }
            };
            var operation = await GetSubscription(host).GetSubscriptionResource1s()
                .CreateOrUpdateAsync(WaitUntil.Completed, "sub-resource-1", data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertSubscriptionResource1(operation.Value.Data);
        });

        [SpectorTest]
        public Task DeleteSubscriptionResource1() => Test(async host =>
        {
            var resource = GetClient(host).GetSubscriptionResource1Resource(
                SubscriptionResource1Resource.CreateResourceIdentifier(SubscriptionId, "sub-resource-1"));
            var operation = await resource.DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetSubscriptionResource2() => Test(async host =>
        {
            SubscriptionResource2Resource resource = await GetSubscription(host)
                .GetSubscriptionResource2s().GetAsync("sub-resource-2");

            AssertSubscriptionResource2(resource.Data);
        });

        [SpectorTest]
        public Task CreateOrUpdateSubscriptionResource2() => Test(async host =>
        {
            SubscriptionResource2Data data = new()
            {
                Properties = new SubscriptionResource2Properties { ConfigValue = "test-config" }
            };
            var operation = await GetSubscription(host).GetSubscriptionResource2s()
                .CreateOrUpdateAsync(WaitUntil.Completed, "sub-resource-2", data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertSubscriptionResource2(operation.Value.Data);
        });

        [SpectorTest]
        public Task DeleteSubscriptionResource2() => Test(async host =>
        {
            var resource = GetClient(host).GetSubscriptionResource2Resource(
                SubscriptionResource2Resource.CreateResourceIdentifier(SubscriptionId, "sub-resource-2"));
            var operation = await resource.DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetMixedSubscriptionResource() => Test(async host =>
        {
            var resource = await GetSubscription(host).GetSubscriptionResources().GetAsync("sub-resource");

            AssertMixedSubscriptionResource(resource.Value.Data);
        });

        [SpectorTest]
        public Task CreateOrUpdateMixedSubscriptionResource() => Test(async host =>
        {
            SubscriptionResourceData data = new()
            {
                Properties = new SubscriptionResourceProperties { SubscriptionSetting = "test-sub-setting" }
            };
            var operation = await GetSubscription(host).GetSubscriptionResources()
                .CreateOrUpdateAsync(WaitUntil.Completed, "sub-resource", data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertMixedSubscriptionResource(operation.Value.Data);
        });

        [SpectorTest]
        public Task DeleteMixedSubscriptionResource() => Test(async host =>
        {
            // ArmClient's built-in GetSubscriptionResource creates a subscription scope, not this resource type.
            var resource = MethodSubscriptionIdExtensions.GetSubscriptionResource(GetClient(host),
                global::Azure.ResourceManager.MethodSubscriptionId.SubscriptionResource.CreateResourceIdentifier(SubscriptionId, "sub-resource"));
            var operation = await resource.DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task GetMixedResourceGroupResource() => Test(async host =>
        {
            var resource = await GetResourceGroup(host).GetResourceGroupResources().GetAsync("rg-resource");

            AssertMixedResourceGroupResource(resource.Value.Data);
        });

        [SpectorTest]
        public Task CreateOrUpdateMixedResourceGroupResource() => Test(async host =>
        {
            ResourceGroupResourceData data = new(AzureLocation.EastUS)
            {
                Properties = new ResourceGroupResourceProperties { ResourceGroupSetting = "test-setting" }
            };
            var operation = await GetResourceGroup(host).GetResourceGroupResources()
                .CreateOrUpdateAsync(WaitUntil.Completed, "rg-resource", data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertMixedResourceGroupResource(operation.Value.Data);
        });

        [SpectorTest]
        public Task DeleteMixedResourceGroupResource() => Test(async host =>
        {
            // Invoke the generated extension explicitly to avoid ArmClient's built-in resource-group factory.
            var resource = MethodSubscriptionIdExtensions.GetResourceGroupResource(GetClient(host),
                global::Azure.ResourceManager.MethodSubscriptionId.ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName, "rg-resource"));
            var operation = await resource.DeleteAsync(WaitUntil.Completed);

            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.GetRawResponse().Status, Is.EqualTo(204));
        });

        private static ArmClient GetClient(Uri host)
        {
            ArmClientOptions options = new()
            {
                Environment = new ArmEnvironment(new UriBuilder(host) { Scheme = Uri.UriSchemeHttps }.Uri, host.AbsoluteUri),
                Transport = new InsecureTransport()
            };
            // Resource identifiers must select the request subscription, not the ArmClient default.
            return new ArmClient(new TestCredential(), "11111111-1111-1111-1111-111111111111", options);
        }

        private static SubscriptionResource GetSubscription(Uri host)
        {
            return GetClient(host).GetSubscriptionResource(SubscriptionResource.CreateResourceIdentifier(SubscriptionId));
        }

        private static ResourceGroupResource GetResourceGroup(Uri host)
        {
            return GetClient(host).GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName));
        }

        private static void AssertSubscriptionResource1(SubscriptionResource1Data data)
        {
            AssertResource(data, "subscriptionResource1s", "sub-resource-1");
            Assert.That(data.Properties.Description, Is.EqualTo("Valid subscription resource 1"));
            Assert.That(data.Properties.ProvisioningState?.ToString(), Is.EqualTo("Succeeded"));
        }

        private static void AssertSubscriptionResource2(SubscriptionResource2Data data)
        {
            AssertResource(data, "subscriptionResource2s", "sub-resource-2");
            Assert.That(data.Properties.ConfigValue, Is.EqualTo("test-config"));
            Assert.That(data.Properties.ProvisioningState?.ToString(), Is.EqualTo("Succeeded"));
        }

        private static void AssertMixedSubscriptionResource(SubscriptionResourceData data)
        {
            AssertResource(data, "subscriptionResources", "sub-resource");
            Assert.That(data.Properties.SubscriptionSetting, Is.EqualTo("test-sub-setting"));
            Assert.That(data.Properties.ProvisioningState?.ToString(), Is.EqualTo("Succeeded"));
        }

        private static void AssertMixedResourceGroupResource(ResourceGroupResourceData data)
        {
            AssertResource(data, "resourceGroupResources", "rg-resource", $"/resourceGroups/{ResourceGroupName}");
            Assert.That(data.Location, Is.EqualTo(AzureLocation.EastUS));
            Assert.That(data.Properties.ResourceGroupSetting, Is.EqualTo("test-setting"));
            Assert.That(data.Properties.ProvisioningState?.ToString(), Is.EqualTo("Succeeded"));
        }

        private static void AssertResource(ResourceData data, string resourceType, string name, string scope = "")
        {
            Assert.That(data.Id.ToString(), Is.EqualTo($"/subscriptions/{SubscriptionId}{scope}/providers/Azure.ResourceManager.MethodSubscriptionId/{resourceType}/{name}"));
            Assert.That(data.Name, Is.EqualTo(name));
            Assert.That(data.ResourceType.ToString(), Is.EqualTo($"Azure.ResourceManager.MethodSubscriptionId/{resourceType}"));
            Assert.That(data.SystemData.CreatedBy, Is.EqualTo("AzureSDK"));
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
