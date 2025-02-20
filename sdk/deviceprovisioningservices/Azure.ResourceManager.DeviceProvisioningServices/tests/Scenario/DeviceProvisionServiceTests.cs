// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DeviceProvisioningServices.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DeviceProvisioningServices.Tests
{
    internal class DeviceProvisionServiceTests : DeviceProvisioningServicesManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private DeviceProvisioningServiceCollection _dpsCollection;

        public DeviceProvisionServiceTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task SetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _dpsCollection = _resourceGroup.GetDeviceProvisioningServices();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string dpsName = Recording.GenerateAssetName("dps");
            var dps = await CreateDefaultDps(_resourceGroup, dpsName);
            ValidateDeviceProvisioningServices(dps.Data, dpsName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string dpsName = Recording.GenerateAssetName("dps");
            await CreateDefaultDps(_resourceGroup, dpsName);
            var flag = await _dpsCollection.ExistsAsync(dpsName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string dpsName = Recording.GenerateAssetName("dps");
            await CreateDefaultDps(_resourceGroup, dpsName);
            var dps = await _dpsCollection.GetAsync(dpsName);
            ValidateDeviceProvisioningServices(dps.Value.Data, dpsName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string dpsName = Recording.GenerateAssetName("dps");
            await CreateDefaultDps(_resourceGroup, dpsName);
            var list = await _dpsCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidateDeviceProvisioningServices(list.FirstOrDefault().Data, dpsName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string dpsName = Recording.GenerateAssetName("dps");
            var dps = await CreateDefaultDps(_resourceGroup, dpsName);
            var flag = await _dpsCollection.ExistsAsync(dpsName);
            Assert.IsTrue(flag);

            await dps.DeleteAsync(WaitUntil.Completed);
            flag = await _dpsCollection.ExistsAsync(dpsName);
            Assert.IsFalse(flag);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string dpsName = Recording.GenerateAssetName("dps");
            var dps = await CreateDefaultDps(_resourceGroup, dpsName);

            // AddTag
            await dps.AddTagAsync("addtagkey", "addtagvalue");
            dps = await _dpsCollection.GetAsync(dpsName);
            Assert.AreEqual(1, dps.Data.Tags.Count);
            KeyValuePair<string, string> tag = dps.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await dps.RemoveTagAsync("addtagkey");
            dps = await _dpsCollection.GetAsync(dpsName);
            Assert.AreEqual(0, dps.Data.Tags.Count);
        }

        private void ValidateDeviceProvisioningServices(DeviceProvisioningServiceData dpsData, string dpsName)
        {
            Assert.IsNotNull(dpsData);
            Assert.AreEqual(dpsName, dpsData.Name);
            Assert.AreEqual(false, dpsData.Properties.IsDataResidencyEnabled);
            Assert.AreEqual("S1", dpsData.Sku.Name.ToString());
            Assert.AreEqual(1, dpsData.Sku.Capacity);
        }
    }
}
