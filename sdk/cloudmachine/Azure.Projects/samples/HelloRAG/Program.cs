// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.OpenAI;
using Azure.Projects;
using Azure.Projects.AI;
using OpenAI.Chat;

ProjectInfrastructure infrastructure = new();
infrastructure.AddFeature(new OpenAIChatFeature("gpt-35-turbo", "0125"));
infrastructure.AddFeature(new OpenAIEmbeddingFeature("text-embedding-ada-002", "2"));

// the app can be called with -init switch to generate bicep and prepare for azd deployment.
if (infrastructure.TryExecuteCommand(args)) return;

ProjectClient project = new();
ChatClient chat = project.GetOpenAIChatClient();
EmbeddingsStore embeddings = EmbeddingsStore.Create(project.GetOpenAIEmbeddingClient());
ChatThread conversation = [];
ChatTools tools = new ChatTools(typeof(Tools));

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
        embeddings.Add(fact);
        continue;
    }

    var related = embeddings.FindRelated(prompt);
    conversation.Add(related);

    conversation.Add(ChatMessage.CreateUserMessage(prompt));

complete:
    ChatCompletion completion = chat.CompleteChat(conversation, tools.ToOptions());

    switch (completion.FinishReason)
    {
        case ChatFinishReason.Stop:
            conversation.Add(completion);
            Console.WriteLine(completion.AsText());
            break;
        case ChatFinishReason.Length:
            conversation.Trim();
            goto complete;
        case ChatFinishReason.ToolCalls:

            // for some reason I am getting tool calls for tools that dont exist.
            ToolCallResult toolResults = await tools.CallAllWithErrors(completion.ToolCalls).ConfigureAwait(false);
            if (toolResults.Failed != null)
            {
                toolResults.Failed.ForEach(f => Console.WriteLine($"Failed to call tool: {f}"));
                conversation.Add(ChatMessage.CreateUserMessage("don't call tools that dont exist"));
            }
            else
            {
                conversation.Add(completion);
                conversation.AddRange(toolResults.Messages);
            }
            goto complete;
        default:
            //case ChatFinishReason.ContentFilter:
            //case ChatFinishReason.FunctionCall:
            throw new NotImplementedException();
    }
}

class Tools
{
    public static string GetCurrentTime() => DateTime.Now.ToString("T");
}
