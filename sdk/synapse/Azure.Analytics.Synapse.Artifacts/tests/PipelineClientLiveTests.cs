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
    /// The suite of tests for the <see cref="PipelineClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class PipelineClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public PipelineClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private PipelineClient CreateClient()
        {
            return InstrumentClient(new PipelineClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestGetPipeline()
        {
            PipelineClient client = CreateClient ();
            await using DisposablePipeline pipeline = await DisposablePipeline.Create (client, this.Recording);

            IList<PipelineResource> pipelines = await client.GetPipelinesByWorkspaceAsync().ToListAsync();
            Assert.GreaterOrEqual(pipelines.Count, 1);

            foreach (var expectedPipeline in pipelines)
            {
                PipelineResource actualPipeline = await client.GetPipelineAsync(expectedPipeline.Name);
                Assert.AreEqual(expectedPipeline.Name, actualPipeline.Name);
                Assert.AreEqual(expectedPipeline.Id, actualPipeline.Id);
            }
        }

        [RecordedTest]
        public async Task TestDeleteNotebook()
        {
            PipelineClient client = CreateClient();

            PipelineResource resource = await DisposablePipeline.CreateResource (client, this.Recording);

            PipelineDeletePipelineOperation operation = await client.StartDeletePipelineAsync (resource.Name);
            await operation.WaitAndAssertSuccessfulCompletion();
        }

        [RecordedTest]
        public async Task TestRenameLinkedService()
        {
            PipelineClient client = CreateClient();

            PipelineResource resource = await DisposablePipeline.CreateResource (client, Recording);

            string newPipelineName = Recording.GenerateId("Pipeline2", 16);

            PipelineRenamePipelineOperation renameOperation = await client.StartRenamePipelineAsync (resource.Name, new ArtifactRenameRequest () { NewName = newPipelineName } );
            await renameOperation.WaitForCompletionAsync();

            PipelineResource pipeline = await client.GetPipelineAsync (newPipelineName);
            Assert.AreEqual (newPipelineName, pipeline.Name);

            PipelineDeletePipelineOperation operation = await client.StartDeletePipelineAsync (newPipelineName);
            await operation.WaitForCompletionAsync();
        }

        [RecordedTest]
        public async Task TestPipelineRun()
        {
            PipelineClient client = CreateClient();

            await using DisposablePipeline pipeline = await DisposablePipeline.Create (client, this.Recording);

            CreateRunResponse runResponse = await client.CreatePipelineRunAsync (pipeline.Name);
            Assert.NotNull(runResponse.RunId);
        }
    }
}
