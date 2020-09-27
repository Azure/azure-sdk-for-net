// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;
using Azure.Analytics.Synapse.Artifacts.Models;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class PipelineSnippets : SampleFixture
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
        public void CreatePipeline()
        {
            #region Snippet:CreatePipeline
            PipelineCreateOrUpdatePipelineOperation operation = PipelineClient.StartCreateOrUpdatePipeline("MyPipeline", new PipelineResource());
            PipelineResource pipeline = operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion
        }

        [Test]
        public void RetrievePipeline()
        {
            #region Snippet:RetrievePipeline
            PipelineResource pipeline = PipelineClient.GetPipeline("MyPipeline");
            #endregion
        }

        [Test]
        public void ListPipelines()
        {
            #region Snippet:ListPipelines
            Pageable<PipelineResource> pipelines = PipelineClient.GetPipelinesByWorkspace();
            foreach (PipelineResource pipeline in pipelines)
            {
                System.Console.WriteLine(pipeline.Name);
            }
            #endregion
        }

        [Test]
        public void DeletePipeline()
        {
            #region Snippet:DeletePipeline
            PipelineClient.StartDeletePipeline("MyPipeline");
            #endregion
        }
    }
}
