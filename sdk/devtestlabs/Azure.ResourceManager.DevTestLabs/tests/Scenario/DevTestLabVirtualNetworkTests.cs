// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DevTestLabs.Tests
{
    internal class DevTestLabVirtualNetworkTests : DevTestLabsManagementTestBase
    {
        private DevTestLabVirtualNetworkCollection _dtlVnetCollection;
        private const string _dtlVnetPrefixName = "dtlVnet";

        public DevTestLabVirtualNetworkTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            TestResourceGroup = await CreateResourceGroup();
            var lab = await CreateDevTestLab(TestResourceGroup, Recording.GenerateAssetName("lab"));
            _dtlVnetCollection = lab.GetDevTestLabVirtualNetworks();
        }

        private async Task<DevTestLabVirtualNetworkResource> CreateDevTestLabVnet(string vnetName)
        {
            var data = new DevTestLabVirtualNetworkData(DefaultLocation);
            var dtlVnet = await _dtlVnetCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, data);
            return dtlVnet.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdateExistGetGetAllDelete()
        {
            // CreateOrUpdate
            string dtlVnetName = Recording.GenerateAssetName(_dtlVnetPrefixName);
            var dtlVnet = await CreateDevTestLabVnet(dtlVnetName);
            ValidateDevTestLabVirtualNetwork(dtlVnet.Data, dtlVnetName);

            // Exist
            var flag = await _dtlVnetCollection.ExistsAsync(dtlVnetName);
            Assert.IsTrue(flag);

            // Get
            var getdtlVnet = await _dtlVnetCollection.GetAsync(dtlVnetName);
            ValidateDevTestLabVirtualNetwork(getdtlVnet.Value.Data, dtlVnetName);

            // GetAll
            var list = await _dtlVnetCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateDevTestLabVirtualNetwork(list.FirstOrDefault().Data, dtlVnetName);

            // Delete
            await dtlVnet.DeleteAsync(WaitUntil.Completed);
            flag = await _dtlVnetCollection.ExistsAsync(dtlVnetName);
            Assert.IsFalse(flag);
        }

        private void ValidateDevTestLabVirtualNetwork(DevTestLabVirtualNetworkData dtlVnetData, string dtlVnetName)
        {
            Assert.IsNotNull(dtlVnetData);
            Assert.IsNotEmpty(dtlVnetData.Id);
            Assert.AreEqual(dtlVnetName, dtlVnetData.Name);
            Assert.AreEqual("Succeeded", dtlVnetData.ProvisioningState);
        }
    }
}
