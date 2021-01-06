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
    /// This sample demonstrates how to create an empty pipline and execute it in Azure Synapse Analytics using asynchronous methods of <see cref="PipelineClient"/>.
    /// </summary>
    public partial class Sample1_HelloWorldPipeline : SampleFixture
    {
        [Test]
        public async Task RunPipeline()
        {
            #region Snippet:CreatePipelineClientPrep
            // Replace the string below with your actual endpoint url.
            string endpoint = "<my-endpoint-url>";
            /*@@*/endpoint = TestEnvironment.EndpointUrl;

            string pipelineName = "Test-Pipeline";
            #endregion

            #region Snippet:CreatePipelineClient
            var client = new PipelineClient(endpoint: new Uri(endpoint), credential: new DefaultAzureCredential());
            #endregion

            #region Snippet:CreatePipeline
            PipelineCreateOrUpdatePipelineOperation operation = client.StartCreateOrUpdatePipeline(pipelineName, new PipelineResource());
            Response<PipelineResource> createdPipeline = await operation.WaitForCompletionAsync();
            #endregion

            #region Snippet:RetrievePipeline
            PipelineResource retrievedPipeline = client.GetPipeline(pipelineName);
            Console.WriteLine("Pipeline ID: {0}", retrievedPipeline.Id);
            #endregion

            #region Snippet:RunPipeline
            Console.WriteLine("Running pipeline.");
            CreateRunResponse runOperation = await client.CreatePipelineRunAsync(pipelineName);
            Console.WriteLine("Run started. ID: {0}", runOperation.RunId);
            #endregion

            #region Snippet:ListPipelines
            Pageable<PipelineResource> pipelines = client.GetPipelinesByWorkspace();
            foreach (PipelineResource pipeline in pipelines)
            {
                Console.WriteLine(pipeline.Name);
            }
            #endregion

            #region Snippet:DeletePipeline
            PipelineDeletePipelineOperation deleteOperation = client.StartDeletePipeline(pipelineName);
            await deleteOperation.WaitForCompletionAsync();
            #endregion
        }
    }
}
