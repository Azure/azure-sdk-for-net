// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [TestCase]
    public void Configure()
    {
        _ = CloudMachineClient.Configure(["--init"]);

        CloudMachineClient cm = new();

        Console.WriteLine(cm.Id);
    }
}
