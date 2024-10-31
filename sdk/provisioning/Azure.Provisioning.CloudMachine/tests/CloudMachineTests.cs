// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
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
    [TestCase([new string[] { "-bicep" }])]
    [TestCase([new string[] { "" }])]
    public void Provisioning(string[] args)
    {
        if (CloudMachineInfrastructure.Configure(args, (cm) =>
        {
            cm.AddFeature(new KeyVaultFeature());
            cm.AddFeature(new OpenAIFeature() // TODO: rework it such that models can be added as features
            {
                Chat = new AIModel("gpt-35-turbo", "0125"),
                Embeddings = new AIModel("text-embedding-ada-002", "2")
            });
        }))
            return;

        // CloudMachineWorkspace cm = new();
        // Console.WriteLine(cm.Id);
        // var embeddings = cm.GetOpenAIEmbeddingsClient();
    }

    // [Ignore("no recordings yet")]
    // [Theory]
    // [TestCase([new string[] { "-bicep" }])]
    // [TestCase([new string[] { "" }])]
    // public void Storage(string[] args)
    // {
    //     ManualResetEventSlim eventSlim = new(false);
    //     if (CloudMachineInfrastructure.Configure(args, (cm) =>
    //     {
    //     }))
    //         return;

    //     CloudMachineClient cm = new();

    //     cm.Storage.WhenBlobUploaded((StorageFile file) =>
    //     {
    //         var data = file.Download();
    //         Console.WriteLine(data.ToString());
    //         Assert.AreEqual("{\"Foo\":5,\"Bar\":true}", data.ToString());
    //         eventSlim.Set();
    //     });
    //     var uploaded = cm.Storage.UploadJson(new
    //     {
    //         Foo = 5,
    //         Bar = true
    //     });
    //     BinaryData downloaded = cm.Storage.DownloadBlob(uploaded);
    //     Console.WriteLine(downloaded.ToString());
    //     eventSlim.Wait();
    // }

    // [Ignore("no recordings yet")]
    // [Theory]
    // [TestCase([new string[] { "-bicep" }])]
    // [TestCase([new string[] { "" }])]
    // public void OpenAI(string[] args)
    // {
    //     if (CloudMachineInfrastructure.Configure(args, (cm) =>
    //     {
    //         cm.AddFeature(new OpenAIFeature() {
    //             Chat = new AIModel("gpt-35-turbo", "0125")
    //         });
    //     }))
    //         return;

    //     CloudMachineWorkspace cm = new();
    //     ChatClient chat = cm.GetOpenAIChatClient();
    //     ChatCompletion completion = chat.CompleteChat("Is Azure programming easy?");

    //     ChatMessageContent content = completion.Content;
    //     foreach (ChatMessageContentPart part in content)
    //     {
    //         Console.WriteLine(part.Text);
    //     }
    // }

    // [Ignore("no recordings yet")]
    // [Theory]
    // [TestCase([new string[] { "-bicep" }])]
    // [TestCase([new string[] { "" }])]
    // public void KeyVault(string[] args)
    // {
    //     if (CloudMachineInfrastructure.Configure(args, (cm) =>
    //     {
    //         cm.AddFeature(new KeyVaultFeature());
    //     }))
    //         return;

    //     CloudMachineWorkspace cm = new();
    //     SecretClient secrets = cm.GetKeyVaultSecretsClient();
    //     secrets.SetSecret("testsecret", "don't tell anybody");
    // }

    // [Ignore("no recordings yet")]
    // [Theory]
    // [TestCase([new string[] { "-bicep" }])]
    // [TestCase([new string[] { "" }])]
    // public void Messaging(string[] args)
    // {
    //     if (CloudMachineInfrastructure.Configure(args))
    //         return;

    //     CloudMachineClient cm = new();
    //     cm.Messaging.WhenMessageReceived(message =>
    //     {
    //         Console.WriteLine(message);
    //         Assert.True(message != null);
    //     });
    //     cm.Messaging.SendMessage(new
    //     {
    //         Foo = 5,
    //         Bar = true
    //     });
    // }

    // [Ignore("no recordings yet")]
    // [Theory]
    // [TestCase([new string[] { "-bicep" }])]
    // [TestCase([new string[] { "" }])]
    // public void Demo(string[] args)
    // {
    //     if (CloudMachineInfrastructure.Configure(args))
    //         return;

    //     CloudMachineClient cm = new();

    //     // setup
    //     cm.Messaging.WhenMessageReceived((string message) => cm.Storage.UploadBinaryData(BinaryData.FromString(message)));
    //     cm.Storage.WhenBlobUploaded((StorageFile file) =>
    //     {
    //         var content = file.Download();
    //         ChatCompletion completion = cm.GetOpenAIChatClient().CompleteChat(content.ToString());
    //         Console.WriteLine(completion.Content[0].Text);
    //     });

    //     // go!
    //     cm.Messaging.SendMessage("Tell me something about Redmond, WA.");
    // }
}
