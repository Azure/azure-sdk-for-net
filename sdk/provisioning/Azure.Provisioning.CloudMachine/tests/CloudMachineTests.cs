// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.CloudMachine.KeyVault;
using Azure.CloudMachine.OpenAI;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [Test]
    public void GenerateBicep()
    {
        CloudMachineCommands.Execute(["-bicep"], (CloudMachineInfrastructure infrastructure) =>
        {
            infrastructure.AddFeature(new KeyVaultFeature());
            infrastructure.AddFeature(new OpenAIFeature() // TODO: rework it such that models can be added as features
            {
                Chat = new AIModel("gpt-35-turbo", "0125"),
                Embeddings = new AIModel("text-embedding-ada-002", "2")
            });
        });
    }

    [Test]
    public void ListModels()
    {
        CloudMachineCommands.Execute(["-ai", "chat"]);
    }
}
