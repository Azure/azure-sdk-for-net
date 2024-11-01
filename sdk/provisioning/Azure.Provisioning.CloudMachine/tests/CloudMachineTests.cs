// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CloudMachine.KeyVault;
using Azure.Provisioning.CloudMachine.OpenAI;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;
using OpenAI.Chat;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [Theory]
    [TestCase([new string[] { "-bicep" }])]
    [TestCase([new string[] { }])]
    public void Provisioning(string[] args)
    {
        CloudMachineInfrastructure.Configure(args, (cm) =>
        {
            //cm.AddFeature(new KeyVaultFeature());
            //cm.AddFeature(new OpenAIFeature() // TODO: rework it such that models can be added as features
            //{
            //    Chat = new AIModel("gpt-35-turbo", "0125"),
            //    Embeddings = new AIModel("text-embedding-ada-002", "2")
            //});
        });
    }
}
