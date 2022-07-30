// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.DataFactory.Tests;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.IotHub.Tests.Scenario
{
    internal class ManagedVirtualNetworkTests : DataFactoryManagementTestBase
    {
        private ResourceIdentifier _dataFactoryIdentifier;
        private DataFactoryResource _dataFactory;
        private string _managedVirtualNetworkName;
        public ManagedVirtualNetworkTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = SessionRecording.GenerateAssetName("DataFactory-");
             _managedVirtualNetworkName = SessionRecording.GenerateAssetName("managedVirtualNetwork-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            var dataFactoryLro = await CreateDataFactory(rgLro.Value, dataFactoryName);
            _dataFactoryIdentifier = dataFactoryLro.Id;
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _dataFactory = await Client.GetDataFactoryResource(_dataFactoryIdentifier).GetAsync();
        }

        private async Task<DataFactoryVirtualNetworkResource> CreateDefaultManagedVirtualNetworkResource(string managedVirtualNetworkName)
        {
            ManagedVirtualNetwork properties = new ManagedVirtualNetwork();
            DataFactoryVirtualNetworkData data = new DataFactoryVirtualNetworkData(properties);
            var managedVirtualNetwork = await _dataFactory.GetDataFactoryVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, managedVirtualNetworkName, data);
            return managedVirtualNetwork.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            var managedVirtualNetwork = await CreateDefaultManagedVirtualNetworkResource(_managedVirtualNetworkName);
            Assert.IsNotNull(managedVirtualNetwork);
            Assert.AreEqual(_managedVirtualNetworkName, managedVirtualNetwork.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            await CreateDefaultManagedVirtualNetworkResource(_managedVirtualNetworkName);
            bool flag = await _dataFactory.GetDataFactoryVirtualNetworks().ExistsAsync(_managedVirtualNetworkName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            await CreateDefaultManagedVirtualNetworkResource(_managedVirtualNetworkName);
            var managedVirtualNetwork = await _dataFactory.GetDataFactoryVirtualNetworks().GetAsync(_managedVirtualNetworkName);
            Assert.IsNotNull(managedVirtualNetwork);
            Assert.AreEqual(_managedVirtualNetworkName, managedVirtualNetwork.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            await CreateDefaultManagedVirtualNetworkResource(_managedVirtualNetworkName);
            var list = await _dataFactory.GetDataFactoryVirtualNetworks().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1,list.Count);
        }
    }
}
