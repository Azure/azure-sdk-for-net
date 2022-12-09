// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class IntegrationRuntimeResourceTests : DataFactoryManagementTestBase
    {
        private ResourceIdentifier _dataFactoryIdentifier;
        private DataFactoryResource _dataFactory;
        private const string _globalParameterName = "default";
        public IntegrationRuntimeResourceTests(bool isAsync) : base(isAsync)
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

        private async Task<FactoryIntegrationRuntimeResource> CreateDefaultIntegrationRuntime(string integrationRuntimeName)
        {
            IntegrationRuntimeDefinition properties = new IntegrationRuntimeDefinition()
            {
                RuntimeType = "SelfHosted"
            };
            FactoryIntegrationRuntimeData data = new FactoryIntegrationRuntimeData(properties);
            var integrationRuntime = await _dataFactory.GetFactoryIntegrationRuntimes().CreateOrUpdateAsync(WaitUntil.Completed, integrationRuntimeName, data);
            return integrationRuntime.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            var integrationRuntime = await CreateDefaultIntegrationRuntime(integrationRuntimeName);
            Assert.IsNotNull(integrationRuntime);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            await CreateDefaultIntegrationRuntime(integrationRuntimeName);
            bool flag = await _dataFactory.GetFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
             await CreateDefaultIntegrationRuntime(integrationRuntimeName);
            var integrationRuntime = await _dataFactory.GetFactoryIntegrationRuntimes().GetAsync(integrationRuntimeName);
            Assert.IsNotNull(integrationRuntime);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            await CreateDefaultIntegrationRuntime(integrationRuntimeName);
            var list = await _dataFactory.GetFactoryIntegrationRuntimes().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotNull(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string integrationRuntimeName = Recording.GenerateAssetName("intergration");
            var integrationRuntime = await CreateDefaultIntegrationRuntime(integrationRuntimeName);
            bool flag = await _dataFactory.GetFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsTrue(flag);

            await integrationRuntime.DeleteAsync(WaitUntil.Completed);
            flag = await _dataFactory.GetFactoryIntegrationRuntimes().ExistsAsync(integrationRuntimeName);
            Assert.IsFalse(flag);
        }
    }
}
