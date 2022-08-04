// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="DatasetClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class DatasetClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public DatasetClientLiveTests(bool isAsync) : base(isAsync)
        {
            // temporary until https://github.com/Azure/azure-sdk-for-net/issues/27688 is addressed
            CompareBodies = false;
        }

        private DatasetClient CreateClient()
        {
            return InstrumentClient(new DatasetClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestGetDataset()
        {
            DatasetClient client = CreateClient();
            await foreach (var expectedDataset in client.GetDatasetsByWorkspaceAsync())
            {
                DatasetResource actualDataset = await client.GetDatasetAsync(expectedDataset.Name);
                Assert.AreEqual(expectedDataset.Name, actualDataset.Name);
                Assert.AreEqual(expectedDataset.Id, actualDataset.Id);
            }
        }

        [RecordedTest]
        public async Task TestCreateDataset()
        {
            DatasetClient client = CreateClient();

            string datasetName = Recording.GenerateId("Dataset", 16);
            DatasetCreateOrUpdateDatasetOperation operation = await client.StartCreateOrUpdateDatasetAsync(datasetName, new DatasetResource(new Dataset(new LinkedServiceReference(LinkedServiceReferenceType.LinkedServiceReference, TestEnvironment.WorkspaceName + "-WorkspaceDefaultStorage"))));
            DatasetResource dataset = await operation.WaitForCompletionAsync();
            Assert.AreEqual(datasetName, dataset.Name);
        }

        [RecordedTest]
        public async Task TestDeleteDataset()
        {
            DatasetClient client = CreateClient();
            string datasetName = Recording.GenerateId("Dataset", 16);

            DatasetCreateOrUpdateDatasetOperation createOperation = await client.StartCreateOrUpdateDatasetAsync(datasetName, new DatasetResource(new Dataset(new LinkedServiceReference(LinkedServiceReferenceType.LinkedServiceReference, TestEnvironment.WorkspaceName + "-WorkspaceDefaultStorage"))));
            await createOperation.WaitForCompletionAsync();

            DatasetDeleteDatasetOperation deleteOperation = await client.StartDeleteDatasetAsync(datasetName);
            Response response = await deleteOperation.WaitForCompletionResponseAsync();
            Assert.AreEqual(200, response.Status);
        }
    }
}
