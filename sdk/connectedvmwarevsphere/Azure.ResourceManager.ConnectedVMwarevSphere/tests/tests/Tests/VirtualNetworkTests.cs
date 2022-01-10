// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.ResourceManager.Resources;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ConnectedVMwarevSphere;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Models;
using Azure.ResourceManager.ConnectedVMwarevSphere.Tests.Helpers;

namespace Azure.ResourceManager.ConnectedVMwarevSphere.Tests.tests.Tests
{
    public class VirtualNetworkTests : ConnectedVMwareTestBase
    {
        private VirtualNetworkCollection _virtualNetworkCollection;
        public VirtualNetworkTests(bool isAsync) : base(isAsync)
        {
        }

        [AsyncOnly]
        [TestCase]
        [RecordedTest]
        public async Task CreateDeleteVirtualNetwork()
        {
            ResourceGroup _resourceGroup = await CreateResourceGroupAsync();
            string vnetName = Recording.GenerateAssetName("testvnet");
            _virtualNetworkCollection = _resourceGroup.GetVirtualNetworks();
            var _extendedLocation = new ExtendedLocation()
            {
                Name = CustomLocationId,
                Type = EXTENDED_LOCATION_TYPE
            };
            var vnetBody = new VirtualNetworkData(DefaultLocation);
            vnetBody.MoRefId = "network-o61";
            vnetBody.VCenterId = VcenterId;
            vnetBody.ExtendedLocation = _extendedLocation;
            //create virtual network
            VirtualNetwork vnet1 = (await _virtualNetworkCollection.CreateOrUpdateAsync(vnetName, vnetBody)).Value;
            Assert.IsNotNull(vnet1);
            Assert.AreEqual(vnet1.Id.Name, vnetName);
        }
    }
}
