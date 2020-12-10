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
        [Test]
        public void PipelineSample()
        {
            #region Snippet:CreatePipelineClient
            // Replace the string below with your actual workspace url.
            string workspaceUrl = "<my-workspace-url>";
            /*@@*/workspaceUrl = TestEnvironment.WorkspaceUrl;
            PipelineClient client = new PipelineClient(endpoint: new Uri(workspaceUrl), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreatePipeline
            PipelineCreateOrUpdatePipelineOperation operation = client.StartCreateOrUpdatePipeline("MyPipeline", new PipelineResource());
            operation.WaitForCompletionAsync().ConfigureAwait(true).GetAwaiter().GetResult();
            #endregion

            #region Snippet:RetrievePipeline
            PipelineResource pipeline = client.GetPipeline("MyPipeline");
            #endregion

            #region Snippet:ListPipelines
            Pageable<PipelineResource> pipelines = client.GetPipelinesByWorkspace();
            foreach (PipelineResource pipe in pipelines)
            {
                System.Console.WriteLine(pipeline.Name);
            }
            #endregion

            #region Snippet:DeletePipeline
            client.StartDeletePipeline("MyPipeline");
            #endregion
        }
    }
}
