// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.IO;
using System.Linq;
using Azure.CloudMachine.AppService;
using Azure.CloudMachine.KeyVault;
using Azure.CloudMachine.OpenAI;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [Test]
    public void GenerateBicep()
    {
        CloudMachineInfrastructure infra = new("cm0c420d2f21084cd");
        infra.AddFeature(new KeyVaultFeature());
            infra.AddFeature(new OpenAIModel("gpt-35-turbo", "0125"));
            infra.AddFeature(new OpenAIModel("text-embedding-ada-002", "2", AIModelKind.Embedding));
            infra.AddFeature(new AppServiceFeature());

        string actualBicep = infra!.Build().Compile().FirstOrDefault().Value;
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
