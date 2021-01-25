  // Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    internal class DisposableDataFlow : IAsyncDisposable
    {
        private readonly DataFlowClient _client;
        public DataFlowResource Resource;

        private DisposableDataFlow (DataFlowClient client, DataFlowResource resource)
        {
            _client = client;
            Resource = resource;
        }

        public string Name => Resource.Name;

        public static async ValueTask<DisposableDataFlow> Create (DataFlowClient client, TestRecording recording) =>
            new DisposableDataFlow (client, await CreateResource(client, recording));

        public static async ValueTask<DataFlowResource> CreateResource (DataFlowClient client, TestRecording recording)
        {
            string name = recording.GenerateAssetName("DataFlow");
            DataFlowCreateOrUpdateDataFlowOperation create = await client.StartCreateOrUpdateDataFlowAsync (name, new DataFlowResource (new DataFlow ()));
            return await create.WaitForCompletionAsync();
        }

        public async ValueTask DisposeAsync()
        {
            DataFlowDeleteDataFlowOperation operation = await _client.StartDeleteDataFlowAsync (Name);
            await operation.WaitForCompletionAsync();
        }
    }
}