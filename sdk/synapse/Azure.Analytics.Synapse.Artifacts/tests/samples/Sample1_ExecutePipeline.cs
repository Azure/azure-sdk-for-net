// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Synapse.Samples
{
    /// <summary>
    /// This sample demonstrates how to execute piplines in Azure Synapse Analytics using asynchronous methods of <see cref="PipelineClient"/>.
    /// </summary>
    public partial class ExecutePipelines
    {
        [Test]
        public async Task CreateAndRunPipeline()
        {
            const string PipelineName = "Test-Pipeline";
            const string JobName = "SparkJobName";
            const string ActivityName = "ActivityName";
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            var pipelineClient = new PipelineClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());

            var sparkJob = new SynapseSparkJobReference(SparkJobReferenceType.SparkJobDefinitionReference, JobName);
            var activity = new SynapseSparkJobDefinitionActivity(ActivityName, sparkJob);
            var pipelineResource = new PipelineResource();
            pipelineResource.Activities.Add(activity);

            Console.WriteLine("Create pipeline if not already exists.");
            await pipelineClient.StartCreateOrUpdatePipelineAsync(PipelineName, pipelineResource);
            Console.WriteLine("Pipeline created");

            Console.WriteLine("Running pipeline.");
            CreateRunResponse runOperation = await pipelineClient.CreatePipelineRunAsync(PipelineName);
            Console.WriteLine("Run started. ID: {0}", runOperation.RunId);
        }

        [Test]
        public async Task RunPipeline()
        {
            const string PipelineName = "Test-Pipeline";
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            var pipelineClient = new PipelineClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());

            Console.WriteLine("Running pipeline.");
            CreateRunResponse runOperation = await pipelineClient.CreatePipelineRunAsync(PipelineName);
            Console.WriteLine("Run started. ID: {0}", runOperation.RunId);
        }
    }
}
