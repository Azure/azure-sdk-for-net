// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Tests.Artifacts
{
    /// <summary>
    /// The suite of tests for the <see cref="DatasetClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class DatasetClientLiveTests : ArtifactsClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatasetClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DatasetClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task TestGetDataset()
        {
            await foreach (var expectedDataset in DatasetClient.GetDatasetsByWorkspaceAsync())
            {
                DatasetResource actualDataset = await DatasetClient.GetDatasetAsync(expectedDataset.Name);
                Assert.AreEqual(expectedDataset.Name, actualDataset.Name);
                Assert.AreEqual(expectedDataset.Id, actualDataset.Id);
            }
        }

        [Test]
        public async Task TestCreateDataset()
        {
            var operation = await DatasetClient.StartCreateOrUpdateDatasetAsync("MyDataset", new DatasetResource(new Dataset(new LinkedServiceReference(LinkedServiceReferenceType.LinkedServiceReference, "testsynapseworkspace-WorkspaceDefaultStorage"))));
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            Assert.AreEqual("MyDataset", operation.Value.Name);
        }

        [Test]
        public async Task TestDeleteDataset()
        {
            var operation = await DatasetClient.StartDeleteDatasetAsync("MyDataset");
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            Assert.AreEqual(200, operation.Value.Status);
        }
    }
}
