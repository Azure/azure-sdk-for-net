// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class VmssPublicIPAddressApiVersionTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000000";
        private static readonly ResourceType s_resourceType = new("Microsoft.Compute/virtualMachineScaleSets/publicIPAddresses");

        [TestCase(null, "2018-10-01")]
        [TestCase("2024-07-01", "2024-07-01")]
        public void GetVirtualMachineScaleSetPublicIPAddressesUsesExpectedApiVersion(string configuredVersion, string expectedVersion)
        {
            MockTransport transport = CreateTransport(configuredVersion, out ResourceGroupResource resourceGroup);

            _ = resourceGroup.GetVirtualMachineScaleSetPublicIPAddresses("vmss").ToList();

            Assert.That(transport.Requests.Single().Uri.Query, Does.Contain($"api-version={expectedVersion}"));
        }

        [TestCase(null, "2018-10-01")]
        [TestCase("2024-07-01", "2024-07-01")]
        public async Task GetVirtualMachineScaleSetPublicIPAddressesAsyncUsesExpectedApiVersion(string configuredVersion, string expectedVersion)
        {
            MockTransport transport = CreateTransport(configuredVersion, out ResourceGroupResource resourceGroup);

            await foreach (PublicIPAddressData _ in resourceGroup.GetVirtualMachineScaleSetPublicIPAddressesAsync("vmss"))
            {
            }

            Assert.That(transport.Requests.Single().Uri.Query, Does.Contain($"api-version={expectedVersion}"));
        }

        private static MockTransport CreateTransport(string configuredVersion, out ResourceGroupResource resourceGroup)
        {
            var transport = new MockTransport(new MockResponse(200).WithContent("{\"value\":[]}"));
            var options = new ArmClientOptions { Transport = transport };
            if (configuredVersion != null)
            {
                options.SetApiVersion(s_resourceType, configuredVersion);
            }

            var client = new ArmClient(new MockCredential(), SubscriptionId, options);
            resourceGroup = client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, "rg"));
            return transport;
        }
    }
}
