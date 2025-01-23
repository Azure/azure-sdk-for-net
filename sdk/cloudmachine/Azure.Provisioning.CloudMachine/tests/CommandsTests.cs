// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.CloudMachine.KeyVault;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CommandsTests
{
    [Ignore("no recordings yet")]
    [Test]
    public void ListModels()
    {
        CloudMachineInfrastructure cm = new();
        cm.TryExecuteCommand(["-ai", "chat"]);
    }

    [Test]
    public void GenerateBicep()
    {
        CloudMachineInfrastructure cm = new();
        cm.AddFeature(new KeyVaultFeature());
        cm.TryExecuteCommand(["-bicep"]);
    }

    [Test]
    public void DoInit()
    {
        CloudMachineInfrastructure cm = new();
        cm.TryExecuteCommand(["-init", "demo.csproj"]);
    }
}
