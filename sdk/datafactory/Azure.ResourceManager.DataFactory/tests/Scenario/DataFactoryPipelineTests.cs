// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryPipelineTests : DataFactoryManagementTestBase
    {
        private ResourceIdentifier _dataFactoryIdentifier;
        private DataFactoryResource _dataFactory;
        public DataFactoryPipelineTests(bool isAsync) : base(isAsync)
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

        private async Task<DataFactoryPipelineResource> CreateDefaultEmptyPipeLine(DataFactoryResource dataFactory,string pipelineName)
        {
            DataFactoryPipelineData data = new DataFactoryPipelineData() { };
            var pipeline = await _dataFactory.GetDataFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, data);
            return pipeline.Value;
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            string pipelineName = Recording.GenerateAssetName("pipeline-");
            var pipeline = await CreateDefaultEmptyPipeLine(_dataFactory, pipelineName);
            Assert.IsNotNull(pipeline);
            Assert.AreEqual(pipelineName,pipeline.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task Exist()
        {
            string pipelineName = Recording.GenerateAssetName("pipeline-");
            await CreateDefaultEmptyPipeLine(_dataFactory, pipelineName);
            bool flag = await _dataFactory.GetDataFactoryPipelines().ExistsAsync(pipelineName);
            Assert.IsTrue(flag);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            string pipelineName = Recording.GenerateAssetName("pipeline-");
            await CreateDefaultEmptyPipeLine(_dataFactory, pipelineName);
            var pipeline = await _dataFactory.GetDataFactoryPipelines().GetAsync(pipelineName);
            Assert.IsNotNull(pipeline);
            Assert.AreEqual(pipelineName, pipeline.Value.Data.Name);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            string pipelineName = Recording.GenerateAssetName("pipeline-");
            await CreateDefaultEmptyPipeLine(_dataFactory, pipelineName);
            var list  = await _dataFactory.GetDataFactoryPipelines().GetAllAsync().ToEnumerableAsync();
            Assert.IsNotEmpty(list);
        }

        [Test]
        [RecordedTest]
        public async Task Delete()
        {
            string pipelineName = Recording.GenerateAssetName("pipeline-");
            var pipeline = await CreateDefaultEmptyPipeLine(_dataFactory, pipelineName);
            bool flag = await _dataFactory.GetDataFactoryPipelines().ExistsAsync(pipelineName);
            Assert.IsTrue(flag);

            await pipeline.DeleteAsync(WaitUntil.Completed);
            flag = await _dataFactory.GetDataFactoryPipelines().ExistsAsync(pipelineName);
            Assert.IsFalse(flag);
        }
    }
}
