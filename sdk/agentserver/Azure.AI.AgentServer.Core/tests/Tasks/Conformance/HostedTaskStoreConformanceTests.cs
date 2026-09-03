// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tasks.Providers;
using Azure.AI.AgentServer.Core.Tasks.Providers.Hosted;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks.Conformance;

/// <summary>
/// Runs the shared store-conformance suite against <see cref="HostedTaskStore"/>
/// backed by an in-memory Foundry protocol harness transport.
/// </summary>
[TestFixture]
public sealed class HostedTaskStoreConformanceTests : TaskStoreConformanceTestsBase
{
    /// <inheritdoc/>
    private protected override ITaskStore CreateStore()
    {
        var harness = new FoundryProtocolHarness();
        var options = new HostedTaskStoreClientOptions();
        options.Transport = harness;

        // Disable retries for tests so errors propagate immediately.
        options.Retry.MaxRetries = 0;

        var pipeline = HttpPipelineBuilder.Build(options);
        var storageBaseUri = new System.Uri("https://test.example.com/api/projects/proj/");
        return new HostedTaskStore(pipeline, storageBaseUri);
    }
}
