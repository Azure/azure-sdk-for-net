// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.AI.Agents;
using Azure.Projects.AIFoundry;
using Azure.Projects.OpenAI;
using NUnit.Framework;
using OpenAI.Chat;

namespace Azure.Projects.Tests;

public class E2ETests
{
    [TestCase("-bicep")]
    [TestCase("")]
    public void OpenAI(string arg)
    {
        ProjectInfrastructure infra = new("cm0a110d2f21084bb");
        infra.AddFeature(new OpenAIModelFeature("gpt-4o-mini", "2024-07-18"));
        if (infra.TryExecuteCommand([arg])) return;

        ProjectClient project = new(infra.Connections);
        ChatClient chat = project.GetOpenAIChatClient();

        Assert.AreEqual(2, project.Connections.Count);
    }

    [TestCase("-bicep")]
    [TestCase("")]
    public void FoundryWithOpenAI(string arg)
    {
        ProjectInfrastructure infra = new("cm0a110d2f21084bb");
        var openAI = infra.AddFeature(new OpenAIModelFeature("gpt-4o-mini", "2024-07-18"));
        var foundry = infra.AddFeature(new AIProjectFeature()
        {
            Connections = [ openAI.CreateConnection(infra.ProjectId) ]
        });

        infra.TryExecuteCommand([arg]);

        ProjectClient project = new(infra.Connections);
        ChatClient chat = project.GetOpenAIChatClient();

        Assert.AreEqual(2, project.Connections.Count);
    }
}
