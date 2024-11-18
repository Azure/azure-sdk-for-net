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
            infrastructure.AddFeature(new OpenAIModel("gpt-35-turbo", "0125"));
            infrastructure.AddFeature(new OpenAIModel("text-embedding-ada-002", "2", AIModelKind.Embedding));
        }, exitProcessIfHandled:false);
    }

    [Ignore("no recordings yet")]
    [Test]
    public void ListModels()
    {
        CloudMachineCommands.Execute(["-ai", "chat"], exitProcessIfHandled: false);
    }
}
