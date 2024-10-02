// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Provisioning.CloudMachine;
using Azure.Provisioning.CloudMachine.KeyVault;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class CloudMachineTests
{
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Configure(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) => {
            cm.AddFeature(new KeyVaultFeature()
            {
                //Sku = new KeyVaultSku { Name = KeyVaultSkuName.Premium, Family = KeyVaultSkuFamily.A, }
            });
        })) return;

        CloudMachineClient cm = new();
        Console.WriteLine(cm.Id);
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void KeyVault(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) =>
        {
            cm.AddFeature(new KeyVaultFeature()
            {
                //Sku = new KeyVaultSku { Name = KeyVaultSkuName.Premium, Family = KeyVaultSkuFamily.A, }
            });
        })) return;

        CloudMachineClient cm = new();
        SecretClient secrets = cm.GetKeyVaultSecretClient();
        secrets.SetSecret("test_secret", "don't tell anybody");
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Storage(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) => {
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
        if (CloudMachineInfrastructure.Configure(args, (cm) => {
        })) return;

        CloudMachineClient cm = new();
        cm.Send(new
        {
            Foo = 5,
            Bar = true
        });
    }
}
