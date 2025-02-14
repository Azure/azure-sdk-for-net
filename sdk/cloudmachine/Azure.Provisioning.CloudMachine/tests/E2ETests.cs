// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.CloudMachine.AIFoundry;
using Azure.CloudMachine.OpenAI;
using NUnit.Framework;
using OpenAI.Chat;

namespace Azure.CloudMachine.Tests;

public class E2ETests
{
    [TestCase("-bicep")]
    [TestCase("")]
    public void Foundry(string arg)
    {
        ProjectInfrastructure infra = new("cm0a110d2f21084bb");
        var openAI = infra.AddFeature(new OpenAIModelFeature("gpt-4o-mini", "2024-07-18"));
        var foundry = infra.AddFeature(new AIFoundryFeature()
        {
            Connections = [ openAI.CreateConnection(infra.Id) ]
        });

        infra.TryExecuteCommand([arg]);

        ProjectClient project = new(infra.Connections);
        ChatClient chat = project.GetOpenAIChatClient();

        Assert.AreEqual(8, project.Connections.Count);
    }
}
