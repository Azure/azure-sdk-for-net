// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests;

public class ClientConnectionProviderExtensionsTests
{
    [Test]
    public void AgentAdministrationClientPropertyCreatesOneClientPerProvider()
    {
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions());
        PipelineConnectionProvider provider = new(pipeline);
        PipelineConnectionProvider otherProvider = new(pipeline);

        AgentAdministrationClient client = provider.AgentAdministrationClient;

        Assert.That(provider.AgentAdministrationClient, Is.SameAs(client));
        Assert.That(provider.GetConnectionCalls, Is.EqualTo(1));
        Assert.That(otherProvider.AgentAdministrationClient, Is.Not.SameAs(client));
    }

    [Test]
    public void AgentAdministrationClientPropertyUsesProviderPipeline()
    {
        ClientPipeline pipeline = ClientPipeline.Create(new ClientPipelineOptions());
        PipelineConnectionProvider provider = new(pipeline);

        Assert.That(provider.AgentAdministrationClient.Pipeline, Is.SameAs(pipeline));
    }

    private sealed class PipelineConnectionProvider(ClientPipeline pipeline) : ClientConnectionProvider(maxCacheSize: 1)
    {
        public int GetConnectionCalls { get; private set; }

        public override ClientConnection GetConnection(string connectionId)
        {
            GetConnectionCalls++;
            return new(connectionId, "https://example.services.ai.azure.com/api/projects/test", pipeline, CredentialKind.None);
        }

        public override IEnumerable<ClientConnection> GetAllConnections() => [GetConnection("Internal.AgentsPipelinePassthrough")];
    }
}
