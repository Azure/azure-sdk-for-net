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

            await CreatePipeline(PipelineName);
            await RunPipeline(PipelineName);
        }

        private async Task CreatePipeline (string pipelineName)
        {
            const string JobName = "SparkJobName";
            const string ActivityName = "ActivityName";

            string endpoint = TestEnvironment.EndpointUrl;

            var pipelineClient = new PipelineClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());

            var sparkJob = new SynapseSparkJobReference(SparkJobReferenceType.SparkJobDefinitionReference, JobName);
            var activity = new SynapseSparkJobDefinitionActivity(ActivityName, sparkJob);
            var pipelineResource = new PipelineResource();
            pipelineResource.Activities.Add(activity);

            Console.WriteLine("Create pipeline if not already exists.");
            var operation = await pipelineClient.StartCreateOrUpdatePipelineAsync(pipelineName, pipelineResource);
            await operation.WaitForCompletionAsync ();
            Console.WriteLine("Pipeline created");
        }

        private async Task RunPipeline(string pipelineName)
        {
            string endpoint = TestEnvironment.EndpointUrl;

            var pipelineClient = new PipelineClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());

            Console.WriteLine("Running pipeline.");
            CreateRunResponse runOperation = await pipelineClient.CreatePipelineRunAsync(pipelineName);
            Console.WriteLine("Run started. ID: {0}", runOperation.RunId);
        }
    }
}
