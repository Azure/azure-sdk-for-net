// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MultiService.Combined;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.MultiService
{
    public class MultiServiceResourcesTests : SpectorTestBase
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private const string ResourceGroupName = "test-rg";

        [SpectorTest]
        public Task GetVirtualMachine() => Test(async host =>
        {
            VirtualMachineResource resource = await GetResourceGroup(host)
                .GetVirtualMachines().GetAsync("vm1");

            AssertVirtualMachine(resource.Data);
        });

        [SpectorTest]
        public Task CreateOrUpdateVirtualMachine() => Test(async host =>
        {
            var operation = await GetResourceGroup(host).GetVirtualMachines()
                .CreateOrUpdateAsync(WaitUntil.Completed, "vm1", new VirtualMachineData(AzureLocation.EastUS));

            Assert.That(operation.HasCompleted, Is.True);
            AssertVirtualMachine(operation.Value.Data);
        });

        [SpectorTest]
        public Task GetDisk() => Test(async host =>
        {
            DiskResource resource = await GetResourceGroup(host)
                .GetDisks().GetAsync("disk1");

            AssertDisk(resource.Data);
        });

        [SpectorTest]
        public Task CreateOrUpdateDisk() => Test(async host =>
        {
            var operation = await GetResourceGroup(host).GetDisks()
                .CreateOrUpdateAsync(WaitUntil.Completed, "disk1", new DiskData(AzureLocation.EastUS));

            Assert.That(operation.HasCompleted, Is.True);
            AssertDisk(operation.Value.Data);
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

        private static void AssertVirtualMachine(VirtualMachineData data)
        {
            Assert.That(data.Id.ToString(), Is.EqualTo($"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/virtualMachines/vm1"));
            Assert.That(data.Name, Is.EqualTo("vm1"));
            Assert.That(data.ResourceType.ToString(), Is.EqualTo("Microsoft.Compute/virtualMachines"));
            Assert.That(data.Location, Is.EqualTo(AzureLocation.EastUS));
            Assert.That(data.VirtualMachineProvisioningState?.ToString(), Is.EqualTo("Succeeded"));
        }

        private static void AssertDisk(DiskData data)
        {
            Assert.That(data.Id.ToString(), Is.EqualTo($"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/disks/disk1"));
            Assert.That(data.Name, Is.EqualTo("disk1"));
            Assert.That(data.ResourceType.ToString(), Is.EqualTo("Microsoft.Compute/disks"));
            Assert.That(data.Location, Is.EqualTo(AzureLocation.EastUS));
            Assert.That(data.DiskProvisioningState?.ToString(), Is.EqualTo("Succeeded"));
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
