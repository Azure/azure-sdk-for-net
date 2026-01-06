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
    /// The suite of tests for the <see cref="PipelineRunClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [Ignore("Blocked on https://github.com/Azure/azure-rest-api-specs/pull/12501")]
    public class PipelineRunClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public PipelineRunClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private PipelineClient CreatePipelineClient()
        {
            return InstrumentClient(new PipelineClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        private PipelineRunClient CreatePipelineRunClient()
        {
            return InstrumentClient(new PipelineRunClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.Credential,
                InstrumentClientOptions(new ArtifactsClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestCancelRun()
        {
            PipelineClient pipelineClient = CreatePipelineClient();
            PipelineRunClient runClient = CreatePipelineRunClient();

            await using DisposablePipeline pipeline = await DisposablePipeline.Create (pipelineClient, this.Recording);

            CreateRunResponse runResponse = await pipelineClient.CreatePipelineRunAsync (pipeline.Name);
            Assert.That(runResponse.RunId, Is.Not.Null);

            Response response = await runClient.CancelPipelineRunAsync (runResponse.RunId);
            response.AssertSuccess();
        }

        [RecordedTest]
        public async Task TestGet()
        {
            PipelineClient pipelineClient = CreatePipelineClient();
            PipelineRunClient runClient = CreatePipelineRunClient();

            await using DisposablePipeline pipeline = await DisposablePipeline.Create (pipelineClient, this.Recording);

            CreateRunResponse runResponse = await pipelineClient.CreatePipelineRunAsync (pipeline.Name);
            Assert.That(runResponse.RunId, Is.Not.Null);

            PipelineRun run = await runClient.GetPipelineRunAsync (runResponse.RunId);
            Assert.Multiple(() =>
            {
                Assert.That(runResponse.RunId, Is.EqualTo(run.RunId));
                Assert.That(run.Status, Is.Not.Null);
            });
        }

        [RecordedTest]
        public async Task TestQueryActivity()
        {
            PipelineClient pipelineClient = CreatePipelineClient();
            PipelineRunClient runClient = CreatePipelineRunClient();

            await using DisposablePipeline pipeline = await DisposablePipeline.Create (pipelineClient, this.Recording);

            CreateRunResponse runResponse = await pipelineClient.CreatePipelineRunAsync (pipeline.Name);
            Assert.That(runResponse.RunId, Is.Not.Null);

            PipelineRunsQueryResponse queryResponse = await runClient.QueryPipelineRunsByWorkspaceAsync (new RunFilterParameters (DateTimeOffset.MinValue, DateTimeOffset.MaxValue));
            Assert.That(queryResponse.Value, Is.Not.Empty);
        }

        [RecordedTest]
        public async Task TestQueryRuns()
        {
            PipelineClient pipelineClient = CreatePipelineClient();
            PipelineRunClient runClient = CreatePipelineRunClient();

            await using DisposablePipeline pipeline = await DisposablePipeline.Create (pipelineClient, this.Recording);

            CreateRunResponse runResponse = await pipelineClient.CreatePipelineRunAsync (pipeline.Name);
            Assert.That(runResponse.RunId, Is.Not.Null);

            PipelineRunsQueryResponse queryResponse = await runClient.QueryPipelineRunsByWorkspaceAsync (new RunFilterParameters (DateTimeOffset.MinValue, DateTimeOffset.MaxValue));
            Assert.That(queryResponse.Value, Is.Not.Empty);
        }
    }
}
