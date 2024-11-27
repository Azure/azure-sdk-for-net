// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.CloudMachine.OpenAI;
using NUnit.Framework;
using System.Linq;

namespace Azure.CloudMachine.Tests;

public partial class CloudMachineTests
{
    [Test]
    [TestCase([new string[] { "-azd" }])]
    public void GettingStarted(string[] args)
    {
        CloudMachineInfrastructure infra = new();
        infra.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));

        if (args.Contains("-bicep")) {
            Azd.Init(infra);
            return;
        }

        // TODO: we need to allow newing up the client.
        CloudMachineClient client = infra.GetClient();
    }
}
