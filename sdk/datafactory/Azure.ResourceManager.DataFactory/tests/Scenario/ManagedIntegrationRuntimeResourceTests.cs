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

        private async Task<DataFactoryResource> TestSetup()
        {
            string rgName = Recording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = Recording.GenerateAssetName("DataFactory-");
            var rgLro = await Client.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            var dataFactoryLro = await CreateDataFactory(rgLro.Value, dataFactoryName);
            return await Client.GetDataFactoryResource(dataFactoryLro.Id).GetAsync();
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
        public async Task CreateOrUpdate()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            var integrationRuntime = await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            Assert.IsNotNull(integrationRuntime);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            bool flag = await dataFactory.GetDataFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            var integrationRuntime = await dataFactory.GetDataFactoryIntegrationRuntimes().GetAsync(integrationRuntimeName);
            Assert.IsNotNull(integrationRuntime);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            var list = await dataFactory.GetDataFactoryIntegrationRuntimes().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            DataFactoryResource dataFactory = await TestSetup();
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            var integrationRuntime = await CreateDefaultManagedIntegrationRuntime(dataFactory, integrationRuntimeName);
            bool flag = await dataFactory.GetDataFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsTrue(flag);

            await integrationRuntime.DeleteAsync(WaitUntil.Completed);
            flag = await dataFactory.GetDataFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsFalse(flag);
        }

        [Test]
        [RecordedTest]
        public async Task IntegrationRuntime_Managed()
        {
            DataFactoryResource dataFactory = await TestSetup();
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
            Assert.IsNotNull(result.Value.Id);
        }
    }
}
