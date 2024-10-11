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
    public void Provisioning(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) => {
            //cm.AddFeature(new KeyVaultFeature());
            //cm.AddFeature(new OpenAIFeature("gpt-35-turbo", "0125"));
        })) return;

        CloudMachineWorkspace cm = new();
        Console.WriteLine(cm.Id);
    }

    //[Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Storage(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) =>
        {
        })) return;

        CloudMachineClient cm = new();

        var uploaded = cm.Storage.UploadBlob(new
        {
            Foo = 5,
            Bar = true
        });
        BinaryData downloaded = cm.Storage.DownloadBlob(uploaded);
        Console.WriteLine(downloaded.ToString());
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

        CloudMachineWorkspace cm = new();
        ChatClient chat = cm.GetOpenAIChatClient();
        ChatCompletion completion = chat.CompleteChat("Is Azure programming easy?");

        ChatMessageContent content = completion.Content;
        foreach (ChatMessageContentPart part in content)
        {
            Console.WriteLine(part.Text);
        }
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

        CloudMachineWorkspace cm = new();
        SecretClient secrets = cm.GetKeyVaultSecretsClient();
        secrets.SetSecret("testsecret", "don't tell anybody");
    }

    [Ignore("no recordings yet")]
    [Theory]
    [TestCase([new string[] { "--init" }])]
    [TestCase([new string[] { "" }])]
    public void Messaging(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args)) return;

        CloudMachineClient cm = new();
        cm.Messaging.WhenMessageReceived((string message) => Console.WriteLine(message));
        cm.Messaging.SendMessage(new
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

        // setup
        cm.Messaging.WhenMessageReceived((string message) => cm.Storage.UploadBlob(message));
        cm.Storage.WhenBlobUploaded((string content) => {
            ChatCompletion completion = cm.GetOpenAIChatClient().CompleteChat(content);
            Console.WriteLine(completion.Content[0].Text);
        });

        // go!
        cm.Messaging.SendMessage("Tell me something about Redmond, WA.");
    }
}
