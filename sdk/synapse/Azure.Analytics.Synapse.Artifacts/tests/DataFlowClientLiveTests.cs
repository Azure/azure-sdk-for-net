// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="DataFlowClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class DataFlowClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public DataFlowClientLiveTests(bool isAsync) : base(isAsync, useLegacyTransport: true)
        {
        }

        private DataFlowClient CreateClient()
        {
            return InstrumentClient(new DataFlowClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task GetDataFlows()
        {
            DataFlowClient client = CreateClient();
            await using DisposableDataFlow flow = await DisposableDataFlow.Create (client, this.Recording);

            AsyncPageable<DataFlowResource> dataFlows = client.GetDataFlowsByWorkspaceAsync ();
            Assert.GreaterOrEqual((await dataFlows.ToListAsync()).Count, 1);
        }

        [RecordedTest]
        public async Task GetDataFlow()
        {
            DataFlowClient client = CreateClient();
            await using DisposableDataFlow flow = await DisposableDataFlow.Create (client, this.Recording);

            DataFlowResource dataFlow = await client.GetDataFlowAsync (flow.Name);
            Assert.AreEqual (flow.Name, dataFlow.Name);
        }

        [RecordedTest]
        public async Task RenameDataFlow()
        {
            DataFlowClient client = CreateClient();

            DataFlowResource resource = await DisposableDataFlow.CreateResource (client, this.Recording);

            string newFlowName = Recording.GenerateAssetName("DataFlow2");

            DataFlowRenameDataFlowOperation renameOperation = await client.StartRenameDataFlowAsync (resource.Name, new ArtifactRenameRequest () { NewName = newFlowName } );
            await renameOperation.WaitForCompletionResponseAsync();

            DataFlowResource dataFlow = await client.GetDataFlowAsync (newFlowName);
            Assert.AreEqual (newFlowName, dataFlow.Name);

            DataFlowDeleteDataFlowOperation operation = await client.StartDeleteDataFlowAsync (newFlowName);
            await operation.WaitForCompletionResponseAsync();
        }

        [RecordedTest]
        public async Task DeleteDataFlow()
        {
            DataFlowClient client = CreateClient();

            DataFlowResource resource = await DisposableDataFlow.CreateResource (client, this.Recording);

            DataFlowDeleteDataFlowOperation operation = await client.StartDeleteDataFlowAsync (resource.Name);
            await operation.WaitAndAssertSuccessfulCompletion ();
        }
    }
}
