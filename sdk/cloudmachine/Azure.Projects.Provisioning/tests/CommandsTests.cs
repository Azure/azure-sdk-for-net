// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.Projects.Tests;

public class CommandsTests
{
    [Ignore("no recordings yet")]
    [Test]
    public void ListModels()
    {
        ProjectInfrastructure cm = new();
        cm.TryExecuteCommand(["-ai", "chat"]);
    }

    [Test]
    public void GenerateBicep()
    {
        ProjectInfrastructure cm = new();
        cm.AddFeature(new KeyVaultFeature());
        cm.TryExecuteCommand(["-bicep"]);
    }

    [Test]
    public void DoInit()
    {
        ProjectInfrastructure cm = new();
        cm.TryExecuteCommand(["-init", "demo.csproj"]);
    }
}
