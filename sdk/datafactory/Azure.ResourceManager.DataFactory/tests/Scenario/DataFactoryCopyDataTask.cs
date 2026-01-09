// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        private string _azureSqlDBLinkedServiceName;
        private string _dataSetAzureSqlSourceName;
        private string _dataSetAzureSqlSinkName;
        private string _pipelineName;
        private string _azureBlobStorageLinkedServiceName;
        private string _azureBlobStorageSourceName;
        private string _azureBlobStorageSinkName;
        private string _accessBlobKey;
        private string _accessGen2Key;
        private string _azureDataLakeGen2LinkedServiceName;
        private string _azureDataLakeGen2SourceName;
        private string _azureDataLakeGen2SinkName;

        public DataFactoryCopyDataTask(bool isAsync) : base(isAsync)
        {
            JsonPathSanitizers.Add("$..value");
            JsonPathSanitizers.Add("$..encryptedCredential");
            JsonPathSanitizers.Add("$..url");
            JsonPathSanitizers.Add("$..accountKey");
        }

        [OneTimeSetUp]
        public async Task GlobalSetUp()
        {
            string rgName = SessionRecording.GenerateAssetName("DataFactory-RG-");
            string dataFactoryName = SessionRecording.GenerateAssetName("DataFactory-");
            var rgLro = await GlobalClient.GetDefaultSubscriptionAsync().Result.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, new ResourceGroupData(AzureLocation.WestUS2));
            var dataFactoryLro = await CreateDataFactory(rgLro.Value, dataFactoryName);
            _dataFactoryIdentifier = dataFactoryLro.Id;
            _connectionString = SessionRecording.GenerateAssetName("DATAFACTORY_CONNECTIONSTRING");
            _accessBlobKey = SessionRecording.GenerateAssetName("DATAFACTORY_BLOBKEY");
            _accessGen2Key = SessionRecording.GenerateAssetName("DATAFACTORY_Gen2KEY");
            await StopSessionRecordingAsync();
        }

        [SetUp]
        public async Task TestSetUp()
        {
            _dataFactory = await Client.GetDataFactoryResource(_dataFactoryIdentifier).GetAsync();
        }

        public async Task CreateLinkedService()
        {
            _azureSqlDBLinkedServiceName = Recording.GenerateAssetName("LinkedService");
            var azureSqlDBLinkedService = await CreateAzureDBLinkedService(_dataFactory, _azureSqlDBLinkedServiceName, _connectionString);
            Assert.That(azureSqlDBLinkedService, Is.Not.Null);
            Assert.That(azureSqlDBLinkedService.Data.Name, Is.EqualTo(_azureSqlDBLinkedServiceName));

            _azureBlobStorageLinkedServiceName = Recording.GenerateAssetName("LinkedService");
            var azureBlobStorageLinkedService = await CreateAzureBlobStorageLinkedService(_dataFactory, _azureBlobStorageLinkedServiceName, _accessBlobKey);
            Assert.That(azureBlobStorageLinkedService, Is.Not.Null);
            Assert.That(azureBlobStorageLinkedService.Data.Name, Is.EqualTo(_azureBlobStorageLinkedServiceName));

            _azureDataLakeGen2LinkedServiceName = Recording.GenerateAssetName("LinkedService");
            var azureDataLakeGen2LinkedService = await CreateAzureDataLakeGen2LinkedService(_dataFactory, _azureDataLakeGen2LinkedServiceName, _accessGen2Key);
            Assert.That(azureDataLakeGen2LinkedService, Is.Not.Null);
            Assert.That(azureDataLakeGen2LinkedService.Data.Name, Is.EqualTo(_azureDataLakeGen2LinkedServiceName));
        }

        public async Task CreateDataSet()
        {
            _dataSetAzureSqlSourceName = Recording.GenerateAssetName("DataSet");
            var dataSetAzureSqlSource = await CreateAzureDBDataSet(_dataFactory, _dataSetAzureSqlSourceName, _azureSqlDBLinkedServiceName, "SampleTable1");
            Assert.That(dataSetAzureSqlSource, Is.Not.Null);
            Assert.That(dataSetAzureSqlSource.Data.Name, Is.EqualTo(_dataSetAzureSqlSourceName));

            _dataSetAzureSqlSinkName = Recording.GenerateAssetName("DataSet");
            var dataSetAzureSqlSink = await CreateAzureDBDataSet(_dataFactory, _dataSetAzureSqlSinkName, _azureSqlDBLinkedServiceName, "SampleTable2");
            Assert.That(dataSetAzureSqlSink, Is.Not.Null);
            Assert.That(dataSetAzureSqlSink.Data.Name, Is.EqualTo(_dataSetAzureSqlSinkName));

            _azureBlobStorageSourceName = Recording.GenerateAssetName("DataSet");
            var dataSetAzureStorageSource = await CreateAzureBlobStorageDataSet(_dataFactory, _azureBlobStorageSourceName, _azureBlobStorageLinkedServiceName);
            Assert.That(dataSetAzureStorageSource, Is.Not.Null);
            Assert.That(dataSetAzureStorageSource.Data.Name, Is.EqualTo(_azureBlobStorageSourceName));

            _azureBlobStorageSinkName = Recording.GenerateAssetName("DataSet");
            var dataSetAzureStorageSink = await CreateAzureBlobStorageDataSet(_dataFactory, _azureBlobStorageSinkName, _azureBlobStorageLinkedServiceName);
            Assert.That(dataSetAzureStorageSink, Is.Not.Null);
            Assert.That(dataSetAzureStorageSink.Data.Name, Is.EqualTo(_azureBlobStorageSinkName));

            _azureDataLakeGen2SourceName = Recording.GenerateAssetName("DataSet");
            var dataSetAzureGen2Source = await CreateAzureDataLakeGen2DataSet(_dataFactory, _azureDataLakeGen2SourceName, _azureDataLakeGen2LinkedServiceName);
            Assert.That(dataSetAzureGen2Source, Is.Not.Null);
            Assert.That(dataSetAzureGen2Source.Data.Name, Is.EqualTo(_azureDataLakeGen2SourceName));

            _azureDataLakeGen2SinkName = Recording.GenerateAssetName("DataSet");
            var dataSetAzureGen2Sink = await CreateAzureDataLakeGen2DataSet(_dataFactory, _azureDataLakeGen2SinkName, _azureDataLakeGen2LinkedServiceName);
            Assert.That(dataSetAzureGen2Sink, Is.Not.Null);
            Assert.That(dataSetAzureGen2Sink.Data.Name, Is.EqualTo(_azureDataLakeGen2SinkName));
        }

        public async Task CreatePipeline()
        {
            string pipelineName = Recording.GenerateAssetName("pipeline-");
            var pipeline = await CreateCopyDataPipeline(_dataFactory, pipelineName, _dataSetAzureSqlSourceName, _dataSetAzureSqlSinkName, _azureBlobStorageSourceName, _azureBlobStorageSinkName,_azureDataLakeGen2SourceName,_azureDataLakeGen2SinkName);
            Assert.That(pipeline, Is.Not.Null);
            Assert.That(pipeline.Data.Name, Is.EqualTo(pipelineName));
            _pipelineName = pipeline.Data.Name;
        }

        public async Task ExecutePipelineAndVerify()
        {
            DataFactoryPipelineResource pipelineResource = await _dataFactory.GetDataFactoryPipelineAsync(_pipelineName);
            var pipelineTrigger = await pipelineResource.CreateRunAsync();
            Assert.That(pipelineTrigger, Is.Not.Null);
            var result = await _dataFactory.GetPipelineRunAsync(pipelineTrigger.Value.RunId.ToString());
            Assert.That(result.Value.Status, Is.Not.EqualTo("Failed"));
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
