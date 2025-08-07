// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class IntegrationRuntimeResourceTests : DataFactoryManagementTestBase
    {
        public IntegrationRuntimeResourceTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<DataFactoryIntegrationRuntimeResource> CreateDefaultIntegrationRuntime(DataFactoryResource dataFactory, string integrationRuntimeName)
        {
            DataFactoryIntegrationRuntimeProperties properties = new SelfHostedIntegrationRuntime();
            DataFactoryIntegrationRuntimeData data = new DataFactoryIntegrationRuntimeData(properties);
            var integrationRuntime = await dataFactory.GetDataFactoryIntegrationRuntimes().CreateOrUpdateAsync(WaitUntil.Completed, integrationRuntimeName, data);
            return integrationRuntime.Value;
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
            // Create a IntegrationRuntime
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            var integrationRuntime = await CreateDefaultIntegrationRuntime(dataFactory, integrationRuntimeName);
            Assert.IsNotNull(integrationRuntime);
            // Exists
            bool flag = await dataFactory.GetDataFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsTrue(flag);
            // Get
            var integrationRuntimeGet = await dataFactory.GetDataFactoryIntegrationRuntimes().GetAsync(integrationRuntimeName);
            Assert.IsNotNull(integrationRuntime);
            Assert.AreEqual(integrationRuntimeName, integrationRuntimeGet.Value.Data.Name);
            // GetAll
            var list = await dataFactory.GetDataFactoryIntegrationRuntimes().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
            // Delete
            await integrationRuntime.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsFalse(flag);
        }
    }
}
