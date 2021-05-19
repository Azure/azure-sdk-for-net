// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    internal class DisposablePipeline : IAsyncDisposable
    {
        private readonly PipelineClient _client;
        public PipelineResource Resource;

        private DisposablePipeline (PipelineClient client, PipelineResource resource)
        {
            _client = client;
            Resource = resource;
        }

        public string Name => Resource.Name;

        public static async ValueTask<DisposablePipeline> Create (PipelineClient client, TestRecording recording) =>
            new DisposablePipeline (client, await CreateResource(client, recording));

        public static async ValueTask<PipelineResource> CreateResource (PipelineClient client, TestRecording recording)
        {
            string pipelineName = recording.GenerateId("Pipeline", 16);
            PipelineCreateOrUpdatePipelineOperation createOperation = await client.StartCreateOrUpdatePipelineAsync(pipelineName, new PipelineResource());
            return await createOperation.WaitForCompletionAsync();
        }

        public async ValueTask DisposeAsync()
        {
            PipelineDeletePipelineOperation operation = await _client.StartDeletePipelineAsync (Name);
            await operation.WaitForCompletionAsync();
        }
    }
}