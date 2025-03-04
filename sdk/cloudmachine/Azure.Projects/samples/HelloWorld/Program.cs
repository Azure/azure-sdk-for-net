// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Projects;
using Azure.Projects.OpenAI;
using OpenAI.Chat;

ProjectInfrastructure infrastructure = new();
infrastructure.AddFeature(new OpenAIModelFeature("gpt-35-turbo", "0125"));

// the app can be called with -init switch to generate bicep and prepare for azd deployment.
if (infrastructure.TryExecuteCommand(args)) return;

ProjectClient project = infrastructure.GetClient();
ChatClient chat = project.GetOpenAIChatClient();
Console.WriteLine(chat.CompleteChat("list all noble gasses."));

