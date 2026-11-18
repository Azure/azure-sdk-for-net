// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MultiServiceSharedModels.Combined;
using Azure.ResourceManager.MultiServiceSharedModels.Combined.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.MultiServiceSharedModels
{
    public class MultiServiceSharedModelsResourcesTests : SpectorTestBase
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private const string ResourceGroupName = "test-rg";

        [SpectorTest]
        public Task GetVirtualMachine() => Test(async host =>
        {
            VirtualMachineResource resource = await GetResourceGroup(host)
                .GetVirtualMachines().GetAsync("vm-shared1");

            AssertVirtualMachine(resource.Data);
        });

        [SpectorTest]
        public Task CreateOrUpdateVirtualMachine() => Test(async host =>
        {
            VirtualMachineData data = new(AzureLocation.EastUS)
            {
                Properties = new VirtualMachineProperties
                {
                    Metadata = CreateMetadata("user@example.com", "environment", "production")
                }
            };

            var operation = await GetResourceGroup(host).GetVirtualMachines()
                .CreateOrUpdateAsync(WaitUntil.Completed, "vm-shared1", data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertVirtualMachine(operation.Value.Data);
        });

        [SpectorTest]
        public Task GetStorageAccount() => Test(async host =>
        {
            StorageAccountResource resource = await GetResourceGroup(host)
                .GetStorageAccounts().GetAsync("account1");

            AssertStorageAccount(resource.Data);
        });

        [SpectorTest]
        public Task CreateOrUpdateStorageAccount() => Test(async host =>
        {
            StorageAccountData data = new(AzureLocation.WestUS)
            {
                Properties = new StorageAccountProperties
                {
                    Metadata = CreateMetadata("admin@example.com", "department", "engineering")
                }
            };

            var operation = await GetResourceGroup(host).GetStorageAccounts()
                .CreateOrUpdateAsync(WaitUntil.Completed, "account1", data);

            Assert.That(operation.HasCompleted, Is.True);
            AssertStorageAccount(operation.Value.Data);
        });

        private static ResourceGroupResource GetResourceGroup(Uri host)
        {
            ArmClientOptions options = new()
            {
                Environment = new ArmEnvironment(new UriBuilder(host) { Scheme = Uri.UriSchemeHttps }.Uri, host.AbsoluteUri),
                Transport = new InsecureTransport()
            };
            ArmClient client = new(new TestCredential(), SubscriptionId, options);
            return client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName));
        }

        private static SharedMetadata CreateMetadata(string createdBy, string tagName, string tagValue)
        {
            SharedMetadata metadata = new() { CreatedBy = createdBy };
            metadata.Tags.Add(tagName, tagValue);
            return metadata;
        }

        private static void AssertVirtualMachine(VirtualMachineData data)
        {
            Assert.That(data.Id.ToString(), Is.EqualTo($"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/virtualMachinesShared/vm-shared1"));
            Assert.That(data.Name, Is.EqualTo("vm-shared1"));
            Assert.That(data.ResourceType.ToString(), Is.EqualTo("Microsoft.Compute/virtualMachinesShared"));
            Assert.That(data.Location, Is.EqualTo(AzureLocation.EastUS));
            Assert.That(data.Properties.ProvisioningState?.ToString(), Is.EqualTo("Succeeded"));
            AssertMetadata(data.Properties.Metadata, new DateTimeOffset(2025, 1, 1, 0, 0, 0, TimeSpan.Zero), "user@example.com", "environment", "production");
        }

        private static void AssertStorageAccount(StorageAccountData data)
        {
            Assert.That(data.Id.ToString(), Is.EqualTo($"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Storage/storageAccounts/account1"));
            Assert.That(data.Name, Is.EqualTo("account1"));
            Assert.That(data.ResourceType.ToString(), Is.EqualTo("Microsoft.Storage/storageAccounts"));
            Assert.That(data.Location, Is.EqualTo(AzureLocation.WestUS));
            Assert.That(data.Properties.ProvisioningState?.ToString(), Is.EqualTo("Succeeded"));
            AssertMetadata(data.Properties.Metadata, new DateTimeOffset(2025, 1, 2, 0, 0, 0, TimeSpan.Zero), "admin@example.com", "department", "engineering");
        }

        private static void AssertMetadata(SharedMetadata metadata, DateTimeOffset createdOn, string createdBy, string tagName, string tagValue)
        {
            Assert.That(metadata.CreatedOn, Is.EqualTo(createdOn));
            Assert.That(metadata.CreatedBy, Is.EqualTo(createdBy));
            Assert.That(metadata.Tags[tagName], Is.EqualTo(tagValue));
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
