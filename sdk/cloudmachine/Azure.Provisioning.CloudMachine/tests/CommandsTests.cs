// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CommandsTests
{
    [Ignore("no recordings yet")]
    [Test]
    public void ListModels()
    {
        CloudMachineCommands.Execute(["-ai", "chat"], exitProcessIfHandled: false);
    }

    [Test]
    public void DoInit()
    {
        CloudMachineCommands.Execute(["-init", "demo.csproj"], exitProcessIfHandled: false);
    }
}
