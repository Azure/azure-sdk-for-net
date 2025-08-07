// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class ManagedVirtualNetworkTests : DataFactoryManagementTestBase
    {
        public ManagedVirtualNetworkTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<DataFactoryManagedVirtualNetworkResource> CreateDefaultManagedVirtualNetworkResource(DataFactoryResource dataFactory, string managedVirtualNetworkName)
        {
            DataFactoryManagedVirtualNetworkProperties properties = new DataFactoryManagedVirtualNetworkProperties();
            DataFactoryManagedVirtualNetworkData data = new DataFactoryManagedVirtualNetworkData(properties);
            var managedVirtualNetwork = await dataFactory.GetDataFactoryManagedVirtualNetworks().CreateOrUpdateAsync(WaitUntil.Completed, managedVirtualNetworkName, data);
            return managedVirtualNetwork.Value;
        }

        [Test]
        [RecordedTest]
        public async Task IntegraionRuntime_Create_Exists_Get_List_Delete()
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName("adf-rg-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName("adf-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            // Create a Virtual Network
            string managedVirtualNetworkName = Recording.GenerateAssetName("managedVirtualNetwork-");
            var managedVirtualNetwork = await CreateDefaultManagedVirtualNetworkResource(dataFactory, managedVirtualNetworkName);
            Assert.IsNotNull(managedVirtualNetwork);
            Assert.AreEqual(managedVirtualNetworkName, managedVirtualNetwork.Data.Name);
            // Exists
            bool flag = await dataFactory.GetDataFactoryManagedVirtualNetworks().ExistsAsync(managedVirtualNetworkName);
            Assert.IsTrue(flag);
            // Get
            var managedVirtualNetworkGet = await dataFactory.GetDataFactoryManagedVirtualNetworks().GetAsync(managedVirtualNetworkName);
            Assert.IsNotNull(managedVirtualNetwork);
            Assert.AreEqual(managedVirtualNetworkName, managedVirtualNetworkGet.Value.Data.Name);
            // GetAll
            var list = await dataFactory.GetDataFactoryManagedVirtualNetworks().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            Assert.AreEqual(1, list.Count);
        }
    }
}
