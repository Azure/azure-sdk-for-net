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
        private ResourceIdentifier _dataFactoryIdentifier;
        private DataFactoryResource _dataFactory;
        public ManagedIntegrationRuntimeResourceTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = SessionRecording.GenerateAssetName("DataFactory-");
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

        private async Task<DataFactoryIntegrationRuntimeResource> CreateDefaultManagedIntegrationRuntime(string integrationRuntimeName)
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
            var integrationRuntime = await _dataFactory.GetDataFactoryIntegrationRuntimes().CreateOrUpdateAsync(WaitUntil.Completed, integrationRuntimeName, data);
            return integrationRuntime.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            var integrationRuntime = await CreateDefaultManagedIntegrationRuntime(integrationRuntimeName);
            Assert.IsNotNull(integrationRuntime);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            await CreateDefaultManagedIntegrationRuntime(integrationRuntimeName);
            bool flag = await _dataFactory.GetDataFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            await CreateDefaultManagedIntegrationRuntime(integrationRuntimeName);
            var integrationRuntime = await _dataFactory.GetDataFactoryIntegrationRuntimes().GetAsync(integrationRuntimeName);
            Assert.IsNotNull(integrationRuntime);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            await CreateDefaultManagedIntegrationRuntime(integrationRuntimeName);
            var list = await _dataFactory.GetDataFactoryIntegrationRuntimes().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            var integrationRuntime = await CreateDefaultManagedIntegrationRuntime(integrationRuntimeName);
            bool flag = await _dataFactory.GetDataFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsTrue(flag);

            await integrationRuntime.DeleteAsync(WaitUntil.Completed);
            flag = await _dataFactory.GetDataFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsFalse(flag);
        }
    }
}
