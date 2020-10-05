﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Tests.Artifacts
{
    /// <summary>
    /// The suite of tests for the <see cref="PipelineClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class PipelineClientLiveTests : ArtifactsClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public PipelineClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task TestGetPipeline()
        {
            await foreach (var expectedPipeline in PipelineClient.GetPipelinesByWorkspaceAsync())
            {
                PipelineResource actualPipeline = await PipelineClient.GetPipelineAsync(expectedPipeline.Name);
                Assert.AreEqual(expectedPipeline.Name, actualPipeline.Name);
                Assert.AreEqual(expectedPipeline.Id, actualPipeline.Id);
            }
        }

        [Test]
        public async Task TestCreatePipeline()
        {
            string pipelineName = Recording.GenerateName("Pipeline");
            PipelineCreateOrUpdatePipelineOperation operation = await PipelineClient.StartCreateOrUpdatePipelineAsync(pipelineName, new PipelineResource());
            PipelineResource pipeline = await operation.WaitForCompletionAsync();
            Assert.AreEqual(pipelineName, pipeline.Name);
        }

        [Test]
        public async Task TestDeletePipeline()
        {
            string pipelineName = Recording.GenerateName("Pipeline");

            PipelineCreateOrUpdatePipelineOperation createOperation = await PipelineClient.StartCreateOrUpdatePipelineAsync(pipelineName, new PipelineResource());
            await createOperation.WaitForCompletionAsync();

            PipelineDeletePipelineOperation deleteOperation = await PipelineClient.StartDeletePipelineAsync(pipelineName);
            Response response = await deleteOperation.WaitForCompletionAsync();
            Assert.AreEqual(200, response.Status);
        }
    }
}
