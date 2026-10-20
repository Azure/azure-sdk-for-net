// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    public class CollectionResultPagingTests
    {
        [TestCase(false)]
        [TestCase(true)]
        public async Task VmssPublicIPAddressCompatibilityPaging(bool async)
        {
            const string subscriptionId = "00000000-0000-0000-0000-000000000001";
            string path = $"/subscriptions/{subscriptionId}/resourceGroups/rg/providers/Microsoft.Compute/virtualMachineScaleSets/vmss/virtualMachines/0/networkInterfaces/nic1/ipconfigurations/ip1/publicipaddresses";
            string nextLink = $"https://management.azure.com{path}?api-version=2018-10-01&$skiptoken=next";
            var transport = new MockTransport(
                new MockResponse(200).SetContent($"{{\"value\":[{{\"id\":\"{path}/first\",\"name\":\"first\"}}],\"nextLink\":\"{nextLink}\"}}"),
                new MockResponse(200).SetContent($"{{\"value\":[{{\"id\":\"{path}/second\",\"name\":\"second\"}}]}}"));
            var client = new ArmClient(new MockCredential(), subscriptionId, new ArmClientOptions { Transport = transport });
            var resource = client.GetVirtualMachineScaleSetVmNetworkResource(
                VirtualMachineScaleSetVmNetworkResource.CreateResourceIdentifier(subscriptionId, "rg", "vmss", "0"));
            var ids = new List<string>();

            if (async)
            {
                await foreach (var item in resource.GetAllPublicIPAddressDataAsync("vmss", "0", CancellationToken.None))
                {
                    ids.Add(item.Id.ToString());
                }
            }
            else
            {
                foreach (var item in resource.GetAllPublicIPAddressData("vmss", "0", CancellationToken.None))
                {
                    ids.Add(item.Id.ToString());
                }
            }

            Assert.That(ids, Is.EqualTo(new[] { path + "/first", path + "/second" }));
            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            Assert.That(transport.Requests[0].Uri.ToUri().AbsolutePath, Is.EqualTo(path));
            Assert.That(transport.Requests[1].Uri.ToUri().AbsoluteUri, Is.EqualTo(nextLink));
        }
    }
}
