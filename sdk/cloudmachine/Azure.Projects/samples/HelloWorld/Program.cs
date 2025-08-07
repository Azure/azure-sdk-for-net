// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI;
using Azure.Projects;
using OpenAI.Chat;

ProjectInfrastructure infrastructure = new();
infrastructure.AddFeature(new OpenAIChatFeature("gpt-35-turbo", "0125"));

if (args.Length > 0 && args[0] == "-bicep")
{
    Azd.Init(infrastructure);
    return;
}

ProjectClient project = new();
ChatClient chat = project.GetOpenAIChatClient();
Console.WriteLine(chat.CompleteChat("list all noble gasses.").AsText());
