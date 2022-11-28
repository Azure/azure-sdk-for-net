// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.DataFactory.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Storage;
using Azure.Storage;
using Azure.Storage.Blobs;
using NUnit.Framework;

namespace Azure.ResourceManager.DataFactory.Tests
{
    public class PipelineRunTests : DataFactoryManagementTestBase
    {
        private string _linkedServiceName;
        private ResourceGroupResource _resourceGroup;
        private DataFactoryResource _dataFactory;
        private StorageAccountResource _storageAccount;

        public PipelineRunTests(bool isAsync)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [SetUp]
        public async Task TestSetUp()
        {
            // Create a resource group
            SubscriptionResource subscription = await Client.GetDefaultSubscriptionAsync();
            _resourceGroup = await CreateResourceGroup(subscription, "DataFactory-RG-", AzureLocation.WestUS2);

            // Create a DataFactory and a LinkedService
            _dataFactory = await CreateDataFactory(_resourceGroup);

            // Create storage account
            var blobContainerName = "dfecontainer";
            _storageAccount = await GetStorageAccountAsync(_resourceGroup, "dfecontainer");
            var key = await _storageAccount.GetKeysAsync().FirstOrDefaultAsync(_ => true);

            // Upload blob
            if (Mode != RecordedTestMode.Playback)
            {
                var blobUri = new Uri($"https://{_storageAccount.Id.Name}.blob.core.windows.net/{blobContainerName}");
                var blobCred = new StorageSharedKeyCredential(_storageAccount.Id.Name, key.Value);
                var blobClient = InstrumentClient(new BlobContainerClient(blobUri, blobCred));
                using var fs = new FileStream($"{TestContext.CurrentContext.TestDirectory}/Assets/PipelineRunTests/emp.txt", FileMode.Open, FileAccess.Read);
                await blobClient.UploadBlobAsync("input/emp.txt", BinaryData.FromStream(fs));
            }

            // Create a LinkedService
            _linkedServiceName = "BlobLinkedService";
            await CreateLinkedService(_dataFactory, _linkedServiceName, key.Value, _storageAccount.Id.Name);
        }

        [TestCase(true)]
        [TestCase(false)]
        [RecordedTest]
        public async Task UseExpressionFilename(bool useExpression)
        {
            var inputName = "InputDatasetExpression";
            var outputName = "OutputDatasetExpression";
            var expressionString = useExpression ? "-@{pipeline().TriggerTime}" : string.Empty;
            await CreateInputDatasetAsync(inputName, "dfecontainer/input/", "emp.txt");
            await CreateInputDatasetAsync(outputName, $"dfecontainer/output{expressionString}/", null);

            var pipelineData = new FactoryPipelineData();
            var copyActivity = new CopyActivity("CopyPipeline", new AzureBlobSource(), new AzureBlobSink());
            copyActivity.Inputs.Add(new DatasetReference(DatasetReferenceType.DatasetReference, inputName));
            copyActivity.Outputs.Add(new DatasetReference(DatasetReferenceType.DatasetReference, outputName));
            pipelineData.Activities.Add(copyActivity);
            var pipelineName = "dfePipelineExpression";
            var pipeline = (await _dataFactory.GetFactoryPipelines().CreateOrUpdateAsync(WaitUntil.Completed, pipelineName, pipelineData)).Value;

            var result = await pipeline.CreateRunAsync();
            DateTime timeout = DateTime.Now.AddMinutes(2);
            int sleep = Mode == RecordedTestMode.Playback ? 0 : 2000;
            do
            {
                var run = _dataFactory.GetPipelineRunAsync(result.Value.RunId.ToString());
                if (run.Status == TaskStatus.RanToCompletion)
                    break;
                Thread.Sleep(sleep);
            } while (DateTime.Now < timeout);
        }

        private async Task<FactoryDatasetResource> CreateInputDatasetAsync(string name, string folder, string file)
        {
            FactoryLinkedServiceReference linkedServiceReference = new FactoryLinkedServiceReference(FactoryLinkedServiceReferenceType.LinkedServiceReference, _linkedServiceName);
            AzureBlobDataset abDataset = new AzureBlobDataset(linkedServiceReference);
            abDataset.Format = new DatasetStorageFormat();
            abDataset.Format.DatasetStorageFormatType = "TextFormat";

            abDataset.FolderPath = DataFactoryExpression.FromExpression<string>(folder);

            if (file != null)
                abDataset.FileName = BinaryData.FromObjectAsJson(file);
            FactoryDatasetData data = new FactoryDatasetData(abDataset);
            return (await _dataFactory.GetFactoryDatasets().CreateOrUpdateAsync(WaitUntil.Completed, name, data)).Value;
        }
    }
}
