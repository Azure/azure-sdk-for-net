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
            Assert.That(flag, Is.True);
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
            Assert.That(list, Is.Not.Empty);
            ValidatePeeringService(list.First(item => item.Data.Name == peeringServiceName), peeringServiceName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            var peeringService = await CreateAtmanPeeringService(_resourceGroup, peeringServiceName);
            bool flag = await _peeringServiceCollection.ExistsAsync(peeringServiceName);
            Assert.That(flag, Is.True);

            await peeringService.DeleteAsync(WaitUntil.Completed);
            flag = await _peeringServiceCollection.ExistsAsync(peeringServiceName);
            Assert.That(flag, Is.False);
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
            Assert.That(peeringService.Data.Tags, Has.Count.EqualTo(1));
            KeyValuePair<string, string> tag = peeringService.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.Multiple(() =>
            {
                Assert.That(tag.Key, Is.EqualTo("addtagkey"));
                Assert.That(tag.Value, Is.EqualTo("addtagvalue"));
            });

            // RemoveTag
            await peeringService.RemoveTagAsync("addtagkey");
            peeringService = await _peeringServiceCollection.GetAsync(peeringServiceName);
            Assert.That(peeringService.Data.Tags.Count, Is.EqualTo(0));
        }

        [RecordedTest]
        public async Task ListAllPeeringServiceAvailableLocations()
        {
            string peeringServiceName = Recording.GenerateAssetName("peeringService");
            var peeringService = await CreateAtmanPeeringService(_resourceGroup, peeringServiceName);
            var response = await peeringService.GetAvailableLocationsAsync();
            var list = response.Value.ToList();
            Assert.That(list, Is.Not.Empty);
            Assert.Multiple(() =>
            {
                Assert.That(list.First(item => item.Name == "eastus"), Is.Not.Null);
                Assert.That(list.First(item => item.Name == "westus"), Is.Not.Null);
            });
        }

        private void ValidatePeeringService(PeeringServiceResource peeringService,string peeringServiceName)
        {
            Assert.That(peeringService, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(peeringService.Data.Name, Is.EqualTo(peeringServiceName));
                Assert.That(peeringService.Data.PeeringServiceLocation, Is.EqualTo("South Australia"));
                Assert.That(peeringService.Data.PeeringServiceProvider, Is.EqualTo("Atman"));
                Assert.That(peeringService.Data.ProviderPrimaryPeeringLocation, Is.EqualTo("Warsaw"));
                Assert.That(peeringService.Data.ProvisioningState.ToString(), Is.EqualTo("Succeeded"));
            });
        }
    }
}
