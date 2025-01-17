// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using Azure.Security.KeyVault.Secrets;
using Azure.CloudMachine.KeyVault;
using NUnit.Framework;
using OpenAI.Chat;

namespace Azure.CloudMachine.Tests;

// TODO: we need recordings to enable these tests

public partial class CloudMachineTests
{
//    [Ignore("no recordings yet")]
//    [Test]
//    [TestCase([new string[] { "-bicep" }])]
//    [TestCase([new string[] { "" }])]
//    public void Storage(string[] args)
//    {
//        if (CloudMachineCommands.Execute(args, exitProcessIfHandled: false)) return;

//        ManualResetEventSlim eventSlim = new(false);
//        CloudMachineClient cm = new();

//        cm.Storage.WhenUploaded((StorageFile file) =>
//        {
//            var data = file.Download();
//            Console.WriteLine(data.ToString());
//            Assert.AreEqual("{\"Foo\":5,\"Bar\":true}", data.ToString());
//            eventSlim.Set();
//        });
//        var uploaded = cm.Storage.UploadJson(new
//        {
//            Foo = 5,
//            Bar = true
//        });
//        BinaryData downloaded = cm.Storage.Download(uploaded);
//        Console.WriteLine(downloaded.ToString());
//        eventSlim.Wait();
//    }

//    [Ignore("no recordings yet")]
//    [Test]
//    [TestCase([new string[] { "-bicep" }])]
//    [TestCase([new string[] { "" }])]
//    public void OpenAI(string[] args)
//    {
//        if (CloudMachineCommands.Execute(args, (infrastructure) =>
//        {
//            infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
//        }, exitProcessIfHandled: false)) return;

//        CloudMachineWorkspace cm = new();
//        ChatClient chat = cm.GetOpenAIChatClient();
//        ChatCompletion completion = chat.CompleteChat("Is Azure programming easy?");
//        Console.WriteLine(completion.AsText());
//    }

//    [Ignore("no recordings yet")]
//    [Test]
//    [TestCase([new string[] { "-bicep" }])]
//    [TestCase([new string[] { "" }])]
//    public void KeyVault(string[] args)
//    {
//        if (CloudMachineCommands.Execute(args, (cm) =>
//        {
//            cm.AddFeature(new KeyVaultFeature());
//        }, exitProcessIfHandled: false)) return;

//        CloudMachineWorkspace cm = new();
//        SecretClient secrets = cm.GetKeyVaultSecretsClient();
//        secrets.SetSecret("testsecret", "don't tell anybody");
//    }

//    [Ignore("no recordings yet")]
//    [Test]
//    [TestCase([new string[] { "-bicep" }])]
//    [TestCase([new string[] { "" }])]
//    public void Messaging(string[] args)
//    {
//        CloudMachineCommands.Execute(args);

//        CloudMachineClient cm = new();
//        cm.Messaging.WhenMessageReceived(message =>
//        {
//            Console.WriteLine(message);
//            Assert.True(message != null);
//        });
//        cm.Messaging.SendJson(new
//        {
//            Foo = 5,
//            Bar = true
//        });
//    }

//    [Ignore("no recordings yet")]
//    [Test]
//    [TestCase([new string[] { "-bicep" }])]
//    [TestCase([new string[] { "" }])]
//    public void Demo(string[] args)
//    {
//        if (CloudMachineCommands.Execute(args, exitProcessIfHandled: false)) return;

//        CloudMachineClient cm = new();

//        // setup
//        cm.Messaging.WhenMessageReceived((string message) => cm.Storage.Upload(BinaryData.FromString(message)));
//        cm.Storage.WhenUploaded((StorageFile file) =>
//        {
//            var content = file.Download();
//            ChatCompletion completion = cm.GetOpenAIChatClient().CompleteChat(content.ToString());
//            Console.WriteLine(completion.Content[0].Text);
//        });

//        // go!
//        cm.Messaging.SendJson("Tell me something about Redmond, WA.");
//    }
}
