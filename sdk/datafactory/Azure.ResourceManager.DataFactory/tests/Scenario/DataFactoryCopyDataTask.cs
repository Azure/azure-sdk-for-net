// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests.Scenario
{
    internal class DataFactoryCopyDataTask : DataFactoryManagementTestBase
    {
        private ResourceIdentifier _dataFactoryIdentifier;
        private DataFactoryResource _dataFactory;
        private string _connectionString;
        private string _linkedServiceName;
        private string _dataSetSourceName;
        private string _dataSetSinkName;
        private string _pipelineName;
        public DataFactoryCopyDataTask(bool isAsync): base(isAsync) { }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = SessionRecording.GenerateAssetName("DataFactory-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            var dataFactoryLro = await CreateDataFactory(rgLro.Value, dataFactoryName);
            _dataFactoryIdentifier = dataFactoryLro.Id;
            _connectionString = Environment.GetEnvironmentVariable("DATAFACTORY_CONNECTIONSTRING");
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _dataFactory = await Client.GetDataFactoryResource(_dataFactoryIdentifier).GetAsync();
        }

        public async Task CreateLinkedService()
        {
            _linkedServiceName = Recording.GenerateAssetName("LinkedService");
            var linkedService = await CreateAzureDBLinkedService(_dataFactory, _linkedServiceName, _connectionString);
            Assert.IsNotNull(linkedService);
            Assert.AreEqual(_linkedServiceName, linkedService.Data.Name);
        }

        public async Task CreateDataSet()
        {
            _dataSetSourceName = Recording.GenerateAssetName("DataSet");
            var dataSetSource = await CreateAzureDBDataSet(_dataFactory, _dataSetSourceName, _linkedServiceName ,"SampleTable1");
            Assert.IsNotNull(dataSetSource);
            Assert.AreEqual(_dataSetSourceName, dataSetSource.Data.Name);

            _dataSetSinkName = Recording.GenerateAssetName("DataSet");
            var dataSetSink = await CreateAzureDBDataSet(_dataFactory, _dataSetSinkName, _linkedServiceName,"SampleTable2");
            Assert.IsNotNull(dataSetSink);
            Assert.AreEqual(_dataSetSinkName, dataSetSink.Data.Name);
        }

        public async Task CreatePipeline()
        {
            string pipelineName = Recording.GenerateAssetName("pipeline-");
            string copyTaskName = Recording.GenerateAssetName("CopyActivity");
            var pipeline = await CreateCopyDataPipeline(_dataFactory, pipelineName, copyTaskName, _dataSetSourceName, _dataSetSinkName);
            Assert.IsNotNull(pipeline);
            Assert.AreEqual(pipelineName, pipeline.Data.Name);
            _pipelineName = pipeline.Data.Name;
        }

        public async Task ExecutePipelineAndVerify()
        {
            DataFactoryPipelineResource pipelineResource = await _dataFactory.GetDataFactoryPipelineAsync(_pipelineName);
            var pipelineTrigger = await pipelineResource.CreateRunAsync();
            Assert.IsNotNull(pipelineTrigger);
            var result = await _dataFactory.GetPipelineRunAsync(pipelineTrigger.Value.RunId.ToString());
            Assert.AreNotEqual("Failed", result.Value.Status);
        }

        [Test]
        [RecordedTest]
        public async Task CreateCopyDataTask()
        {
            await CreateLinkedService();
            await CreateDataSet();
            await CreatePipeline();
            await ExecutePipelineAndVerify();
        }
    }
}
