﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI;
using Azure.Projects;
using Azure.Projects.OpenAI;
using OpenAI.Chat;

ProjectInfrastructure infrastructure = new();
infrastructure.AddFeature(new OpenAIModelFeature("gpt-4o-mini", "2024-07-18"));
infrastructure.AddFeature(new OpenAIModelFeature("text-embedding-ada-002", "2", AIModelKind.Embedding));

// the app can be called with -init switch to generate bicep and prepare for azd deployment.
if (infrastructure.TryExecuteCommand(args)) return;

ChatTools tools = new(typeof(Tools));

ProjectClient project = new();

List<ChatMessage> conversation = [];

ChatProcessor processor = new(
    project.GetOpenAIChatClient(),
    project.GetOpenAIEmbeddingClient(),
    tools
);

while (true)
{
    Console.Write("> ");
    string prompt = Console.ReadLine();
    if (string.IsNullOrEmpty(prompt))
        continue;
    if (string.Equals(prompt, "bye", StringComparison.OrdinalIgnoreCase))
        break;
    if (prompt.StartsWith("fact:", StringComparison.OrdinalIgnoreCase))
    {
        string fact = prompt[5..].Trim();
        processor.VectorDb.Add(fact);
        continue;
    }
    if (prompt.StartsWith("addmcp:", StringComparison.OrdinalIgnoreCase))
    {
        string mcp = prompt[7..].Trim();
        Console.WriteLine($"Adding MCP server {mcp}");
        await tools.AddMcpServerAsync(new Uri(mcp)).ConfigureAwait(false);
        continue;
    }
    ChatCompletion completion = await processor.TakeTurnAsync(conversation, prompt).ConfigureAwait(false);

    Console.WriteLine(completion.AsText());
}

class Tools
{
    public static string GetCurrentTime() => DateTime.Now.ToString("T");
}
