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
    [NonParallelizable]
    internal class DevTestLabVirtualNetworkTests : DevTestLabsManagementTestBase
    {
        private DevTestLabVirtualNetworkCollection _dtlVnetCollection => TestDevTestLab.GetDevTestLabVirtualNetworks();
        private DevTestLabVirtualNetworkResource _dtlVnet;
        private const string _dtlVnetPrefixName = "dtlVnet";
        private string _dtlVnetName;

        public DevTestLabVirtualNetworkTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        private async Task<DevTestLabVirtualNetworkResource> CreateDevTestLabVnet(string vnetName)
        {
            var data = new DevTestLabVirtualNetworkData(DefaultLocation);
            var dtlVnet = await _dtlVnetCollection.CreateOrUpdateAsync(WaitUntil.Completed, vnetName, data);
            return dtlVnet.Value;
        }

        [SetUp]
        public async Task SetUp()
        {
            _dtlVnetName = Recording.GenerateAssetName(_dtlVnetPrefixName);
            _dtlVnet = await CreateDevTestLabVnet(_dtlVnetName);
        }

        [RecordedTest]
        public void CreateOrUpdate()
        {
            ValidateDevTestLabVirtualNetwork(_dtlVnet.Data, _dtlVnetName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            var flag = await _dtlVnetCollection.ExistsAsync(_dtlVnetName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            var getdtlVnet = await _dtlVnetCollection.GetAsync(_dtlVnetName);
            ValidateDevTestLabVirtualNetwork(getdtlVnet.Value.Data, _dtlVnetName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            var first = (await _dtlVnetCollection.GetAllAsync().ToEnumerableAsync()).FirstOrDefault();
            ValidateDevTestLabVirtualNetwork(first.Data, _dtlVnetName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            await _dtlVnet.DeleteAsync(WaitUntil.Completed);
            bool flag = await _dtlVnetCollection.ExistsAsync(_dtlVnetName);
            Assert.IsFalse(flag);
        }

        private void ValidateDevTestLabVirtualNetwork(DevTestLabVirtualNetworkData dtlVnetData, string _dtlVnetName)
        {
            Assert.IsNotNull(dtlVnetData);
            Assert.IsNotEmpty(dtlVnetData.Id);
            Assert.AreEqual(_dtlVnetName, dtlVnetData.Name);
            Assert.AreEqual("Succeeded", dtlVnetData.ProvisioningState);
        }
    }
}
