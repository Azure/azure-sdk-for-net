// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
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
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Configure(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) => {
            //cm.AddFeature(new KeyVaultFeature());
            cm.AddFeature(new OpenAIFeature("gpt-35-turbo", "0125"));
        })) return;

        CloudMachineClient cm = new();
        Console.WriteLine(cm.Id);
    }

    //[Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void OpenAI(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) => {
            cm.AddFeature(new OpenAIFeature("gpt-35-turbo", "0125"));
        })) return;

        CloudMachineClient cm = new();
        ChatClient chat = cm.GetOpenAIClient();
        ChatCompletion completion = chat.CompleteChat("Is Azure programming easy?");
        Console.WriteLine(completion.Content);
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void KeyVault(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) => {
            cm.AddFeature(new KeyVaultFeature());
        })) return;

        CloudMachineClient cm = new();
        SecretClient secrets = cm.GetKeyVaultSecretClient();
        secrets.SetSecret("testsecret", "don't tell anybody");
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Storage(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args)) return;

        CloudMachineClient cm = new();

        cm.WhenBlobUploaded((string content) => {
            Console.WriteLine(content);
        });

        var uploaded = cm.UploadBlob(new
        {
            Foo = 5,
            Bar = true
        });
        BinaryData downloaded = cm.DownloadBlob(uploaded);
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Messaging(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args)) return;

        CloudMachineClient cm = new();
        cm.WhenMessageReceived((string message) => Console.WriteLine(message));
        cm.SendMessage(new
        {
            Foo = 5,
            Bar = true
        });
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Demo(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args)) return;

        CloudMachineClient cm = new();
        cm.WhenMessageReceived((string message) => cm.UploadBlob(message));
        cm.WhenBlobUploaded((string content) => { Console.WriteLine(content); });
        cm.SendMessage("Hello World");
    }
}
