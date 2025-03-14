// Copyright (c) Microsoft Corporation. All rights reserved.
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
    await tools.AddMcpServerAsync("http://localhost:3001/sse");
    string prompt = "can you get detailed information about the storage account 'stchriss2334910047646422' in resourec group 'cm0ddf918b146443b' in subscription 'faa080af-c1d8-40ad-9cce-e1a450ca5b57'";
    // string prompt = Console.ReadLine();
    // if (string.IsNullOrEmpty(prompt)) continue;
    // if (string.Equals(prompt, "bye", StringComparison.OrdinalIgnoreCase)) break;
    // if (prompt.StartsWith("fact:", StringComparison.OrdinalIgnoreCase))
    // {
    //     string fact = prompt[5..].Trim();
    //     processor.VectorDb.Add(fact);
    //     continue;
    // }
    // if (prompt.StartsWith("addmcp:", StringComparison.OrdinalIgnoreCase))
    // {
    //     string mcp = prompt[7..].Trim();
    //     await tools.AddMcpServerAsync(mcp);
    //     continue;
    // }

    ChatCompletion completion = await processor.TakeTurnAsync(conversation, prompt).ConfigureAwait(false);

    Console.WriteLine(completion.AsText());
}

class Tools
{
    public static string GetCurrentTime() => DateTime.Now.ToString("T");
}
