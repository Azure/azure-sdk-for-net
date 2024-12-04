// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.CloudMachine.OpenAI;
using NUnit.Framework;
using System.Linq;
using OpenAI.Chat;

namespace Azure.CloudMachine.Tests;

public partial class CloudMachineTests
{
    [TestCase([new string[] { "-bicep" }])]
    public void GettingStarted(string[] args)
    {
        CloudMachineInfrastructure cm = new();
        cm.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));
        if (cm.TryExecuteCommand(args)) return;

        CloudMachineClient client = cm.GetClient();

        ChatClient chat = client.GetOpenAIChatClient();
        string completion = chat.CompleteChat("List all noble gases.").AsText();
        Console.WriteLine(completion);
    }
}
