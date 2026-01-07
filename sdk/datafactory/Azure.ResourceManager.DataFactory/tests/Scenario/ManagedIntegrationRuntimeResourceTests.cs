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
    internal class ManagedIntegrationRuntimeResourceTests : DataFactoryManagementTestBase
    {
        public ManagedIntegrationRuntimeResourceTests(bool isAsync) : base(isAsync)
        {
        }

        private async Task<DataFactoryIntegrationRuntimeResource> CreateDefaultManagedIntegrationRuntime(DataFactoryResource dataFactory, string integrationRuntimeName)
        {
            ManagedIntegrationRuntime properties = new ManagedIntegrationRuntime()
            {
                ComputeProperties = new IntegrationRuntimeComputeProperties()
                {
                    Location = "eastus2",
                    DataFlowProperties = new IntegrationRuntimeDataFlowProperties()
                    {
                        ComputeType = DataFlowComputeType.General,
                        CoreCount = 16,
                        TimeToLiveInMinutes = 10
                    }
                }
            };
            DataFactoryIntegrationRuntimeData data = new DataFactoryIntegrationRuntimeData(properties);
            var integrationRuntime = await dataFactory.GetDataFactoryIntegrationRuntimes().CreateOrUpdateAsync(WaitUntil.Completed, integrationRuntimeName, data);
            return integrationRuntime.Value;
        }

        [Test]
        [RecordedTest]
        public async Task ManagedIntegraionRuntime_Create_Exists_Get_List_Delete()
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName("adf-rg-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName("adf-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);
            // Create a ManagedIntegrationRuntime
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            var integrationRuntime = await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            Assert.That(integrationRuntime, Is.Not.Null);
            // Exists
            bool flag = await dataFactory.GetDataFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.That(flag, Is.True);
            // Get
            var integrationRuntimeGet = await dataFactory.GetDataFactoryIntegrationRuntimes().GetAsync(integrationRuntimeName);
            Assert.That(integrationRuntime, Is.Not.Null);
            Assert.That(integrationRuntimeGet.Value.Data.Name, Is.EqualTo(integrationRuntimeName));
            // GetAll
            var list = await dataFactory.GetDataFactoryIntegrationRuntimes().GetAllAsync().ToEnumerableAsync();
            Assert.That(list, Is.Not.Null);
            // Delete
            await integrationRuntime.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.That(flag, Is.False);
        }

        [Test]
        [RecordedTest]
        public async Task IntegrationRuntime_Managed_Create()
        {
            // Get the resource group
            string rgName = Recording.GenerateAssetName("adf-rg-");
            var resourceGroup = await CreateResourceGroup(rgName, AzureLocation.WestUS2);
            // Create a DataFactory
            string dataFactoryName = Recording.GenerateAssetName("adf-");
            DataFactoryResource dataFactory = await CreateDataFactory(resourceGroup, dataFactoryName);

            string integrationRuntimeName = Recording.GenerateAssetName("integraionRuntime-");
            DataFactoryIntegrationRuntimeData data = new DataFactoryIntegrationRuntimeData(new ManagedIntegrationRuntime()
            {
                ComputeProperties = new IntegrationRuntimeComputeProperties()
                {
                    Location = "westus",
                    NodeSize = "standard_d2_v3",
                    NumberOfNodes = 1,
                    MaxParallelExecutionsPerNode = 4
                }
                ,
                SsisProperties = new IntegrationRuntimeSsisProperties()
                {
                    LicenseType = "BasePrice",
                    Edition = "Standard"
                }
            });

            var result = await dataFactory.GetDataFactoryIntegrationRuntimes().CreateOrUpdateAsync(WaitUntil.Completed, integrationRuntimeName, data);
            Assert.That(result.Value.Id, Is.Not.Null);
        }
    }
}
