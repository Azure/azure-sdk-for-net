using Azure.AI.Agents.V2;
using Azure.AI.AgentsHosting.AgentFramework.Extensions;
using Azure.AI.OpenAI;
using Azure.Identity;

using FoundryConversation.Executors;

using Microsoft.Agents.Workflows;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.AI.Agents;

public static class Program
{
    private static async Task Main()
    {
        // This sample is blocked by concurrency issue in AgentFramework workflow
        // see - https://github.com/microsoft/agent-framework/issues/784

        // Set up the Azure OpenAI client
        var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ??
                       throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
        var deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME") ?? "gpt-4o-mini";
        var chatClient = new AzureOpenAIClient(
                new Uri(endpoint),
                new DefaultAzureCredential())
            .GetChatClient(deploymentName)
            .AsIChatClient();

        // Create agents
        var retrieveChatHistoryExecutor = GetRetrieveChatHistoryExecutor();
        var frenchAgent = GetTranslationAgent("French", chatClient);
        var spanishAgent = GetTranslationAgent("Spanish", chatClient);
        var englishAgent = GetTranslationAgent("English", chatClient);

        // Build the workflow by adding executors and connecting them
        WorkflowBuilder builder = new(retrieveChatHistoryExecutor);
        builder.AddEdge(retrieveChatHistoryExecutor, frenchAgent);
        builder.AddEdge(frenchAgent, spanishAgent);
        builder.AddEdge(spanishAgent, englishAgent);
        var workflow = builder.Build<List<ChatMessage>>();

        var agent = workflow.AsAgent().WithOpenTelemetry();
        await agent.RunAIAgentAsync();
    }

    private static Executor GetRetrieveChatHistoryExecutor()
    {
        var agentsEndpoint = Environment.GetEnvironmentVariable("AZURE_FOUNDRY_AGENTS_ENDPOINT") ??
                             throw new InvalidOperationException("AZURE_FOUNDRY_AGENTS_ENDPOINT is not set.");

        var client = new AgentsClient(new Uri(agentsEndpoint), new DefaultAzureCredential());
        return new RetrieveChatHistoryExecutor(client);
    }

    /// <summary>
    /// Creates a translation agent for the specified target language.
    /// </summary>
    /// <param name="targetLanguage">The target language for translation</param>
    /// <param name="chatClient">The chat client to use for the agent</param>
    /// <returns>A ChatClientAgent configured for the specified language</returns>
    private static AIAgent GetTranslationAgent(string targetLanguage, IChatClient chatClient)
    {
        var instructions = $"You are a translation assistant that translates the provided text to {targetLanguage}.";
        return new ChatClientAgent(chatClient, instructions).WithOpenTelemetry();
    }
}
