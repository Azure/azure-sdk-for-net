// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using Azure.CloudMachine.KeyVault;
using Azure.CloudMachine.OpenAI;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [Test]
    public void GenerateBicep()
    {
        CloudMachineInfrastructure? infra = default;
        CloudMachineCommands.Execute(["-bicep"], (CloudMachineInfrastructure infrastructure) =>
        {
            infra = infrastructure;
            infrastructure.AddFeature(new KeyVaultFeature());
            infrastructure.AddFeature(new OpenAIModel("gpt-35-turbo", "0125"));
            infrastructure.AddFeature(new OpenAIModel("text-embedding-ada-002", "2", AIModelKind.Embedding));
        }, exitProcessIfHandled: false);

        string actualBicep = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "Infra", "cm.bicep"));
        string expectedBicep = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "GenerateBicep.bicep")).Replace("\r\n", Environment.NewLine);
        Assert.AreEqual(expectedBicep, actualBicep);
    }

    [Ignore("no recordings yet")]
    [Test]
    public void ListModels()
    {
        CloudMachineCommands.Execute(["-ai", "chat"], exitProcessIfHandled: false);
    }
}
