// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects;
using Azure.Projects.OpenAI;
using OpenAI.Chat;

ProjectInfrastructure infrastructure = new("cm69489e8c64db465");
infrastructure.AddFeature(new OpenAIChatFeature("gpt-35-turbo", "0125"));

if (args.Length > 0 && args[0] == "-bicep")
{
    Azd.Init(infrastructure);
    return;
}

ProjectClient project = new();
ChatClient chat = project.GetOpenAIChatClient();
Console.WriteLine(chat.CompleteChat("list all noble gasses.").AsText());

