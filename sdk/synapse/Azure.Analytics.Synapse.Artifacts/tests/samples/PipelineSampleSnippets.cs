// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Samples;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Artifacts.Samples
{
    public partial class PipelineSnippets : SampleFixture
    {
        [Test]
        public async Task PipelineSample()
        {
            #region Snippet:CreatePipelineClient
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;
            PipelineClient client = new PipelineClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreatePipeline
            PipelineCreateOrUpdatePipelineOperation operation = client.StartCreateOrUpdatePipeline("MyPipeline", new PipelineResource());
            Response<PipelineResource> createdPipeline = await operation.WaitForCompletionAsync();
            #endregion

            #region Snippet:RetrievePipeline
            PipelineResource retrievedPipeline = client.GetPipeline("MyPipeline");
            #endregion

            #region Snippet:ListPipelines
            Pageable<PipelineResource> pipelines = client.GetPipelinesByWorkspace();
            foreach (PipelineResource pipeline in pipelines)
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
