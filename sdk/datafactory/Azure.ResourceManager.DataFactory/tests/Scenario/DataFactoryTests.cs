// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.DataFactory;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryTests : DataFactoryManagementTestBase
    {
        public DataFactoryTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [RecordedTest]
        public async Task DataFactory_Create_Exists_Get_List_Delete()
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName("adf-rg-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName("dataFactory-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            Assert.IsNotNull(dataFactory);
            Assert.AreEqual(dataFactoryName, dataFactory.Data.Name);
            // Exist
            bool flag = await resourceGroup.GetDataFactories().ExistsAsync(dataFactoryName);
            Assert.IsTrue(flag);
            // Get
            var dataFactoryGet = await resourceGroup.GetDataFactories().GetAsync(dataFactoryName);
            Assert.IsNotNull(dataFactoryGet);
            Assert.AreEqual(dataFactoryName, dataFactoryGet.Value.Data.Name);
            // GetAll
            var list = await resourceGroup.GetDataFactories().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
            // Delete
            await dataFactory.DeleteAsync(WaitUntil.Completed);
            flag = await resourceGroup.GetDataFactories().ExistsAsync(dataFactoryName);
            Assert.IsFalse(flag);
        }
    }
}
