// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Logic.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.Logic.Tests
{
    internal class IntegrationAccountMapTests : LogicManagementTestBase
    {
        private IntegrationAccountResource _integrationAccount;

        private IntegrationAccountMapCollection _mapCollection => _integrationAccount.GetIntegrationAccountMaps();

        public IntegrationAccountMapTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public async Task GlobalSetup()
        {
            var resourceGroup = await CreateResourceGroup(AzureLocation.CentralUS);
            _integrationAccount = await CreateIntegrationAccount(resourceGroup, Recording.GenerateAssetName("intergrationAccount"));
        }

        private async Task<IntegrationAccountMapResource> CreateMap(string mapName)
        {
            string content = File.ReadAllText(@"TestData/MapContent.xsd");
            IntegrationAccountMapData data = new IntegrationAccountMapData(_integrationAccount.Data.Location, IntegrationAccountMapType.Xslt30)
            {
                Content = BinaryData.FromObjectAsJson<string>(content),
                ContentType = "application/xml"
            };
            // Due to the different test servers in the pipeline, the line break encoding is also different causing the playback result to fail, changing the record file content to "Santize"
            if (SessionEnvironment.Mode == RecordedTestMode.Playback)
            {
                data.Content = BinaryData.FromString("\"Sanitized\"");
            }
            var map = await _mapCollection.CreateOrUpdateAsync(WaitUntil.Completed, mapName, data);
            return map.Value;
        }

        [RecordedTest]
        [PlaybackOnly("Need to manually change the content value to Sanitized")]
        public async Task CreateOrUpdate()
        {
            string mapName = Recording.GenerateAssetName("map");
            var map = await CreateMap(mapName);
            Assert.IsNotNull(map);
            Assert.AreEqual(mapName, map.Data.Name);
        }

        [RecordedTest]
        [PlaybackOnly("Need to manually change the content value to Sanitized")]
        public async Task Exist()
        {
            string mapName = Recording.GenerateAssetName("map");
            await CreateMap(mapName);
            bool flag = await _mapCollection.ExistsAsync(mapName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        [PlaybackOnly("Need to manually change the content value to Sanitized")]
        public async Task Get()
        {
            string mapName = Recording.GenerateAssetName("map");
            await CreateMap(mapName);
            var map = await _mapCollection.GetAsync(mapName);
            Assert.IsNotNull(map);
            Assert.AreEqual(mapName, map.Value.Data.Name);
        }

        [RecordedTest]
        [PlaybackOnly("Need to manually change the content value to Sanitized")]
        public async Task GetAll()
        {
            string mapName = Recording.GenerateAssetName("map");
            await CreateMap(mapName);
            var list = await _mapCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
        [PlaybackOnly("Need to manually change the content value to Sanitized")]
        public async Task Delete()
        {
            string mapName = Recording.GenerateAssetName("map");
            var map = await CreateMap(mapName);
            bool flag = await _mapCollection.ExistsAsync(mapName);
            Assert.IsTrue(flag);

            await map.DeleteAsync(WaitUntil.Completed);
            flag = await _mapCollection.ExistsAsync(mapName);
            Assert.IsFalse(flag);
        }
    }
}
