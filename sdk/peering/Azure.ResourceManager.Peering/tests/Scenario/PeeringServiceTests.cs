// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
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
    internal class PeeringServiceTests : PeeringManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private PeeringServiceCollection _peeringServiceCollection => _resourceGroup.GetPeeringServices();

        public PeeringServiceTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            var peeringService = await CreateAtmanPeeringService(_resourceGroup, peeringServiceName);
            ValidatePeeringService(peeringService, peeringServiceName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            await CreateAtmanPeeringService(_resourceGroup, peeringServiceName);
            bool flag = await _peeringServiceCollection.ExistsAsync(peeringServiceName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            await CreateAtmanPeeringService(_resourceGroup, peeringServiceName);
            var peeringService = await _peeringServiceCollection.GetAsync(peeringServiceName);
            ValidatePeeringService(peeringService, peeringServiceName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            await CreateAtmanPeeringService(_resourceGroup, peeringServiceName);
            var list = await _peeringServiceCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePeeringService(list.First(item => item.Data.Name == peeringServiceName), peeringServiceName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            var peeringService = await CreateAtmanPeeringService(_resourceGroup, peeringServiceName);
            bool flag = await _peeringServiceCollection.ExistsAsync(peeringServiceName);
            Assert.IsTrue(flag);

            await peeringService.DeleteAsync(WaitUntil.Completed);
            flag = await _peeringServiceCollection.ExistsAsync(peeringServiceName);
            Assert.IsFalse(flag);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            var peeringService = await CreateAtmanPeeringService(_resourceGroup, peeringServiceName);

            // AddTag
            await peeringService.AddTagAsync("addtagkey", "addtagvalue");
            peeringService = await _peeringServiceCollection.GetAsync(peeringServiceName);
            Assert.AreEqual(1, peeringService.Data.Tags.Count);
            KeyValuePair<string, string> tag = peeringService.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await peeringService.RemoveTagAsync("addtagkey");
            peeringService = await _peeringServiceCollection.GetAsync(peeringServiceName);
            Assert.AreEqual(0, peeringService.Data.Tags.Count);
        }

        [RecordedTest]
        public async Task ListAllPeeringServiceAvailableLocations()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            var peeringService = await CreateAtmanPeeringService(_resourceGroup, peeringServiceName);
            var response = await peeringService.GetAvailableLocationsAsync();
            var list = response.Value.ToList();
            Assert.IsNotEmpty(list);
            Assert.IsNotNull(list.First(item => item.Name == "eastus"));
            Assert.IsNotNull(list.First(item => item.Name == "westus"));
        }

        private void ValidatePeeringService(PeeringServiceResource peeringService,string peeringServiceName)
        {
            Assert.IsNotNull(peeringService);
            Assert.AreEqual(peeringServiceName, peeringService.Data.Name);
            Assert.AreEqual("South Australia", peeringService.Data.PeeringServiceLocation);
            Assert.AreEqual("Atman", peeringService.Data.PeeringServiceProvider);
            Assert.AreEqual("Warsaw", peeringService.Data.ProviderPrimaryPeeringLocation);
            Assert.AreEqual("Succeeded", peeringService.Data.ProvisioningState.ToString());
        }
    }
}
