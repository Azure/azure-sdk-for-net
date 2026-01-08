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
            Assert.That(managedVirtualNetwork, Is.Not.Null);
            Assert.That(managedVirtualNetwork.Data.Name, Is.EqualTo(managedVirtualNetworkName));
            // Exists
            bool flag = await dataFactory.GetDataFactoryManagedVirtualNetworks().ExistsAsync(managedVirtualNetworkName);
            Assert.That(flag, Is.True);
            // Get
            var managedVirtualNetworkGet = await dataFactory.GetDataFactoryManagedVirtualNetworks().GetAsync(managedVirtualNetworkName);
            Assert.Multiple(() =>
            {
                Assert.That(managedVirtualNetwork, Is.Not.Null);
                Assert.That(managedVirtualNetworkGet.Value.Data.Name, Is.EqualTo(managedVirtualNetworkName));
            });
            // GetAll
            var list = await dataFactory.GetDataFactoryManagedVirtualNetworks().GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Empty);
            Assert.That(list, Has.Count.EqualTo(1));
        }
    }
}
