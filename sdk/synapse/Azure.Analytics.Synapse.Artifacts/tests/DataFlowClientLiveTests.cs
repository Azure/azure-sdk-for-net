// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts.Models;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Tests.Artifacts
{
    /// <summary>
    /// The suite of tests for the <see cref="DataFlowClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class DataFlowClientLiveTests : ArtifactsClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataFlowClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public DataFlowClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task TestGetDataFlow()
        {
            await foreach (var expectedDataFlow in DataFlowClient.GetDataFlowsByWorkspaceAsync())
            {
                DataFlowResource actualDataFlow = await DataFlowClient.GetDataFlowAsync(expectedDataFlow.Name);
                Assert.AreEqual(expectedDataFlow.Name, actualDataFlow.Name);
                Assert.AreEqual(expectedDataFlow.Id, actualDataFlow.Id);
            }
        }

        [Test]
        public async Task TestCreateDataFlow()
        {
            var operation = await DataFlowClient.StartCreateOrUpdateDataFlowAsync("MyDataFlow", new DataFlowResource(new DataFlow()));
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            Assert.AreEqual("MyDataFlow", operation.Value.Name);
        }

        [Test]
        public async Task TestDeleteDataFlow()
        {
            var operation = await DataFlowClient.StartDeleteDataFlowAsync("MyDataFlow");
            while (!operation.HasValue)
            {
                operation.UpdateStatus();
            }
            Assert.AreEqual(200, operation.Value.Status);
        }
    }
}
