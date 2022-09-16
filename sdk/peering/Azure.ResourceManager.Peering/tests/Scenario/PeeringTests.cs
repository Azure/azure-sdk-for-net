// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Peering.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Peering.Tests
{
    internal class PeeringTests : PeeringManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private PeeringServiceCollection _peeringServiceCollection => _resourceGroup.GetPeeringServices();

        public PeeringTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
        }

        private async Task<PeeringServiceResource> CreateAtmanPeeringService(string peeringServiceName)
        {
            PeeringServiceData data = new PeeringServiceData(_resourceGroup.Data.Location)
            {
                Location = _resourceGroup.Data.Location,
                PeeringServiceLocation = "South Australia",
                PeeringServiceProvider = "Atman",
                ProviderPrimaryPeeringLocation = "Warsaw",
            };
            var peeringservice = await _peeringServiceCollection.CreateOrUpdateAsync(WaitUntil.Completed, peeringServiceName, data);
            return peeringservice.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            var peeringService = await CreateAtmanPeeringService(peeringServiceName);
            ValidatePeeringService(peeringService);
            Assert.AreEqual(peeringServiceName, peeringService.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            await CreateAtmanPeeringService(peeringServiceName);
            bool flag = await _peeringServiceCollection.ExistsAsync(peeringServiceName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            await CreateAtmanPeeringService(peeringServiceName);
            var peeringService = await _peeringServiceCollection.GetAsync(peeringServiceName);
            ValidatePeeringService(peeringService);
            Assert.AreEqual(peeringServiceName, peeringService.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            await CreateAtmanPeeringService(peeringServiceName);
            var list = await _peeringServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePeeringService(list.First(item => item.Data.Name == peeringServiceName));
        }

        [RecordedTest]
        public async Task Delete()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            var peeringService = await CreateAtmanPeeringService(peeringServiceName);
            bool flag = await _peeringServiceCollection.ExistsAsync(peeringServiceName);
            Assert.IsTrue(flag);

            await peeringService.DeleteAsync(WaitUntil.Completed);
            flag = await _peeringServiceCollection.ExistsAsync(peeringServiceName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task AddTag()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            var peeringService = await CreateAtmanPeeringService(peeringServiceName);
            await peeringService.AddTagAsync("addtagkey", "addtagvalue");

            peeringService = await _peeringServiceCollection.GetAsync(peeringServiceName);
            KeyValuePair<string, string> tag = peeringService.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);
        }

        private void ValidatePeeringService(PeeringServiceResource peeringService)
        {
            Assert.IsNotNull(peeringService);
            Assert.AreEqual("South Australia", peeringService.Data.PeeringServiceLocation);
            Assert.AreEqual("Atman", peeringService.Data.PeeringServiceProvider);
            Assert.AreEqual("Warsaw", peeringService.Data.ProviderPrimaryPeeringLocation);
            Assert.AreEqual("Succeeded", peeringService.Data.ProvisioningState.ToString());
        }
    }
}
