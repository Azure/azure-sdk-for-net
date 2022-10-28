// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.PrivateDns.Tests
{
    internal class PrivateDnsTests : PrivateDnsManagementTestBase
    {
        private ResourceGroupResource _resourceGroup;
        private PrivateZoneCollection _privateZoneResource;

        public PrivateDnsTests(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _resourceGroup = await CreateResourceGroup();
            _privateZoneResource = _resourceGroup.GetPrivateZones();
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var privateZone = await CreatePrivateZone(_resourceGroup, privateZoneName);
            ValidatePrivateZone(privateZone, privateZoneName);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreatePrivateZone(_resourceGroup, privateZoneName);
            bool flag = await _privateZoneResource.ExistsAsync(privateZoneName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreatePrivateZone(_resourceGroup, privateZoneName);
            var privateZone = await _privateZoneResource.GetAsync(privateZoneName);
            ValidatePrivateZone(privateZone, privateZoneName);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            await CreatePrivateZone(_resourceGroup, privateZoneName);
            var list = await _privateZoneResource.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            ValidatePrivateZone(list.First(item => item.Data.Name == privateZoneName), privateZoneName);
        }

        [RecordedTest]
        public async Task Delete()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var privateZone = await CreatePrivateZone(_resourceGroup, privateZoneName);
            bool flag = await _privateZoneResource.ExistsAsync(privateZoneName);
            Assert.IsTrue(flag);

            await privateZone.DeleteAsync(WaitUntil.Completed);
            flag = await _privateZoneResource.ExistsAsync(privateZoneName);
            Assert.IsFalse(flag);
        }

        [RecordedTest]
        public async Task GetRecordsAsync()
        {
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var privateZone = await CreatePrivateZone(_resourceGroup, privateZoneName);

            var records = await privateZone.GetRecordsAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(records);
            Assert.IsNotNull(records.First().SoaRecordInfo);
        }

        [TestCase(null)]
        [TestCase(false)]
        [TestCase(true)]
        public async Task AddRemoveTag(bool? useTagResource)
        {
            SetTagResourceUsage(Client, useTagResource);
            string privateZoneName = $"{Recording.GenerateAssetName("sample")}.com";
            var privateZone = await CreatePrivateZone(_resourceGroup, privateZoneName);

            // AddTag
            await privateZone.AddTagAsync("addtagkey", "addtagvalue");
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(30000);
            }
            privateZone = await _privateZoneResource.GetAsync(privateZoneName);
            Assert.AreEqual(1, privateZone.Data.Tags.Count);
            KeyValuePair<string, string> tag = privateZone.Data.Tags.Where(tag => tag.Key == "addtagkey").FirstOrDefault();
            Assert.AreEqual("addtagkey", tag.Key);
            Assert.AreEqual("addtagvalue", tag.Value);

            // RemoveTag
            await privateZone.RemoveTagAsync("addtagkey");
            if (TestEnvironment.Mode == RecordedTestMode.Record)
            {
                Thread.Sleep(30000);
            }
            privateZone = await _privateZoneResource.GetAsync(privateZoneName);
            Assert.AreEqual(0, privateZone.Data.Tags.Count);
        }

        private void ValidatePrivateZone(PrivateZoneResource privateZone, string privateZoneName)
        {
            Assert.IsNotNull(privateZone);
            Assert.IsNotNull(privateZone.Data.Id);
            Assert.AreEqual(privateZoneName, privateZone.Data.Name);
        }
    }
}
