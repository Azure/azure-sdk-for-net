// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning.CloudMachine;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Configure(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cmi) => {
            cmi.AddKeyVault();
        })) return;

        CloudMachineClient cm = new();
        Console.WriteLine(cm.Id);

        var kvClient = cm.GetKeyVaultSecretClient();
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Storage(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cmi) => {
        })) return;

        CloudMachineClient cm = new();
        var uploaded = cm.Upload(new
        {
            Foo = 5,
            Bar = true
        });
        BinaryData downloaded = cm.Download(uploaded);
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Messaging(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cmi) => {
        })) return;

        CloudMachineClient cm = new();
        cm.Send(new
        {
            Foo = 5,
            Bar = true
        });
    }
}
