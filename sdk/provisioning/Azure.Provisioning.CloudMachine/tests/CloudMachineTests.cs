// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning.CloudMachine;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [TestCase]
    public void Configure()
    {
        bool initializing = CloudMachineInfrastructure.Configure(["--init"], (cmi) =>
        {
        });

        CloudMachineClient cm = new();

        Console.WriteLine(cm.Id);
    }
}
