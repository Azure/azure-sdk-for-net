// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Analytics.Synapse.Artifacts.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Synapse.Artifacts.Tests
{
    internal class DisposableTrigger : IAsyncDisposable
    {
        private readonly TriggerClient _client;
        public TriggerResource Resource;

        private DisposableTrigger (TriggerClient client, TriggerResource resource)
        {
            _client = client;
            Resource = resource;
        }

        public string Name => Resource.Name;

        public static async ValueTask<DisposableTrigger> Create (TriggerClient client, TestRecording recording) =>
            new DisposableTrigger (client, await CreateResource(client, recording));

        public static async ValueTask<TriggerResource> CreateResource (TriggerClient client, TestRecording recording)
        {
            string triggerName = recording.GenerateId("Trigger", 16);
            TriggerResource trigger = new TriggerResource(new ScheduleTrigger(new ScheduleTriggerRecurrence()));
            TriggerCreateOrUpdateTriggerOperation createOperation = await client.StartCreateOrUpdateTriggerAsync (triggerName, trigger);
            return await createOperation.WaitForCompletionAsync();
        }

        public async ValueTask DisposeAsync()
        {
            TriggerDeleteTriggerOperation deleteOperation = await _client.StartDeleteTriggerAsync (Name);
            await deleteOperation.WaitForCompletionAsync();
        }
    }
}