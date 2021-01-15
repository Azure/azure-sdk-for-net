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

        [Test]
        public async Task TestGetPipeline()
        {
            PipelineClient client = CreateClient ();

            await foreach (var expectedPipeline in client.GetPipelinesByWorkspaceAsync())
            {
                PipelineResource actualPipeline = await client.GetPipelineAsync(expectedPipeline.Name);
                Assert.AreEqual(expectedPipeline.Name, actualPipeline.Name);
                Assert.AreEqual(expectedPipeline.Id, actualPipeline.Id);
            }
        }

        [Test]
        public async Task TestCreatePipeline()
        {
            PipelineClient client = CreateClient ();

            string pipelineName = Recording.GenerateName("Pipeline");
            PipelineCreateOrUpdatePipelineOperation operation = await client.StartCreateOrUpdatePipelineAsync(pipelineName, new PipelineResource());
            PipelineResource pipeline = await operation.WaitForCompletionAsync();
            Assert.AreEqual(pipelineName, pipeline.Name);
        }

        [Test]
        public async Task TestDeletePipeline()
        {
            PipelineClient client = CreateClient ();

            string pipelineName = Recording.GenerateName("Pipeline");

            PipelineCreateOrUpdatePipelineOperation createOperation = await client.StartCreateOrUpdatePipelineAsync(pipelineName, new PipelineResource());
            await createOperation.WaitForCompletionAsync();

            PipelineDeletePipelineOperation deleteOperation = await client.StartDeletePipelineAsync(pipelineName);
            Response response = await deleteOperation.WaitForCompletionAsync();
            Assert.AreEqual(200, response.Status);
        }
    }
}
