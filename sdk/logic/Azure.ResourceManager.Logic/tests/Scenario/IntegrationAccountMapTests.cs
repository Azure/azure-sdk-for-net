// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        private ResourceIdentifier _integrationAccountIdentifier;
        private IntegrationAccountResource _integrationAccount;

        private IntegrationAccountMapCollection _mapCollection => _integrationAccount.GetIntegrationAccountMaps();

        public IntegrationAccountMapTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            var rgLro = await (await GlobalClient.GetDefaultSubscriptionAsync()).GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Started, SessionRecording.GenerateAssetName(ResourceGroupNamePrefix), new ResourceGroupData(AzureLocation.CentralUS));
            var integrationAccount = await CreateIntegrationAccount(rgLro.Value, SessionRecording.GenerateAssetName("intergrationAccount"));
            _integrationAccountIdentifier = integrationAccount.Data.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            _integrationAccount = await Client.GetIntegrationAccountResource(_integrationAccountIdentifier).GetAsync();
        }

        private async Task<IntegrationAccountMapResource> CreateMap(string mapName)
        {
            IntegrationAccountMapData data = new IntegrationAccountMapData(_integrationAccount.Data.Location, IntegrationAccountMapType.Xslt30)
            {
                Content = File.ReadAllText(@"TestData/MapContent.xml"),
                ContentType = "application/xml"
            };
            var map = await _mapCollection.CreateOrUpdateAsync(WaitUntil.Completed, mapName, data);
            return map.Value;
        }

        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string mapName = Recording.GenerateAssetName("map");
            var map = await CreateMap(mapName);
            Assert.IsNotNull(map);
            Assert.AreEqual(mapName, map.Data.Name);
        }

        [RecordedTest]
        public async Task Exist()
        {
            string mapName = Recording.GenerateAssetName("map");
            await CreateMap(mapName);
            bool flag = await _mapCollection.ExistsAsync(mapName);
            Assert.IsTrue(flag);
        }

        [RecordedTest]
        public async Task Get()
        {
            string mapName = Recording.GenerateAssetName("map");
            await CreateMap(mapName);
            var map = await _mapCollection.GetAsync(mapName);
            Assert.IsNotNull(map);
            Assert.AreEqual(mapName, map.Value.Data.Name);
        }

        [RecordedTest]
        public async Task GetAll()
        {
            string mapName = Recording.GenerateAssetName("map");
            await CreateMap(mapName);
            var list = await _mapCollection.GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [RecordedTest]
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
