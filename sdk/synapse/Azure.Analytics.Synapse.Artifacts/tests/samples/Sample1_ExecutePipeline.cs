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
    /// This sample demonstrates how to execute piplines in Azure Synapse Analytics using synchronous methods of <see cref="PipelineClient"/>.
    /// </summary>
    public partial class ExecutePipelines
    {
        private PipelineClient PipelineClient;

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Synapse workspace endpoint.
            string workspaceUrl = TestEnvironment.WorkspaceUrl;

            #region Snippet:CreatePipelineClient
            // Create a new Pipeline client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            PipelineClient client = new PipelineClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            this.PipelineClient = client;
        }

        [Test]
        public async Task CreateAndRunPipeline()
        {
            const string PipelineName = "Test-Pipeline";
            const string JobName = "SparkJobName";
            const string ActivityName = "ActivityName";

            var sparkJob = new SynapseSparkJobReference(SparkJobReferenceType.SparkJobDefinitionReference, JobName);
            var activity = new SynapseSparkJobDefinitionActivity(ActivityName, sparkJob);
            var pipelineResource = new PipelineResource();
            pipelineResource.Activities.Add(activity);

            Console.WriteLine("Create pipeline if not already exists.");
            await PipelineClient.StartCreateOrUpdatePipelineAsync(PipelineName, pipelineResource);
            Console.WriteLine("Pipeline created");

            Console.WriteLine("Running pipeline.");
            CreateRunResponse runOperation = await PipelineClient.CreatePipelineRunAsync(PipelineName);
            Console.WriteLine("Run started. ID: {0}", runOperation.RunId);
        }

        [Test]
        public async Task RunPipeline()
        {
            const string PipelineName = "Test-Pipeline";

            Console.WriteLine("Running pipeline.");
            CreateRunResponse runOperation = await PipelineClient.CreatePipelineRunAsync(PipelineName);
            Console.WriteLine("Run started. ID: {0}", runOperation.RunId);
        }
    }
}
