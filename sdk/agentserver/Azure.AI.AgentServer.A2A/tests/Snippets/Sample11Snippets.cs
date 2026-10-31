// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;
using Azure.AI.AgentServer.Core.Storage;
using Azure.Core;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using static Azure.AI.AgentServer.A2A.Tests.Snippets.ReadMeSnippets;

namespace Azure.AI.AgentServer.A2A.Tests.Snippets;

public class Sample11Snippets
{
    #region Snippet:A2A_Sample11_LocalStore
    public static async Task<FoundryTaskStore> CreateLocalStoreAsync(
        string name,
        CancellationToken cancellationToken = default)
    {
        var backing = await FoundryStateStore.GetOrCreateAsync(
            name,
            itemTtlSeconds: 3600,
            cancellationToken: cancellationToken);
        return new FoundryTaskStore(backing);
    }
    #endregion

    [Test]
    [Explicit("Starts a server; local snapshot persistence is exercised by SampleEndToEndTests.")]
    public async Task StartLocalServerAsync()
    {
        #region Snippet:A2A_Sample11_LocalStart
        using var store = await CreateLocalStoreAsync("echo/tasks");
        var builder = AgentHost.CreateBuilder();
        builder.Services.AddSingleton<ITaskStore>(store);
        builder.AddA2A<TaskAgent>(CreateCard());
        builder.Build().Run();
        #endregion
    }

    #region Snippet:A2A_Sample11_HostedStore
    public static FoundryTaskStore CreateHostedStore(
        TokenCredential credential,
        Uri projectEndpoint)
    {
        return new FoundryTaskStore(
            "echo/tasks",
            credential: credential,
            endpoint: projectEndpoint,
            itemTtlSeconds: 3600);
    }
    #endregion
}
