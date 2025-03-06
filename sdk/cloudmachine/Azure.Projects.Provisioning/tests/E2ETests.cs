// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.AI.OpenAI;
using Azure.Projects.KeyVault;
using Azure.Projects.OpenAI;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;
using OpenAI.Chat;

namespace Azure.Projects.Tests;

public class E2ETests
{
    [TestCase("-bicep")]
    //[TestCase("")]
    public void OpenAI(string arg)
    {
        ProjectInfrastructure infra = new("cm0a110d2f21084bb");
        infra.AddFeature(new OpenAIModelFeature("gpt-4o-mini", "2024-07-18"));
        if (infra.TryExecuteCommand([arg])) return;

        ProjectClient project = new();
        ChatClient chat = project.GetOpenAIChatClient();
    }

    [TestCase("-bicep")]
    //[TestCase("")]
    public void ConnectionsInAppConfig(string arg)
    {
        ProjectInfrastructure infra = new("cm0a110d2f21084bb");
        infra.AddFeature(new KeyVaultFeature());
        if (infra.TryExecuteCommand([arg])) return;

        ProjectClient project = new();
        SecretClient secrets = project.GetKeyVaultSecretsClient();
    }
}
