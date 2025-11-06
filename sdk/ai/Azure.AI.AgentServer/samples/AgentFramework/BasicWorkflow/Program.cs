using Azure.AI.AgentServer.AgentFramework.Extensions;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Agents.AI.Workflows;
using Microsoft.Extensions.AI;

namespace BasicWorkflow.Samples;

/// <summary>
/// This sample introduces the use of AI agents as executors within a workflow,
/// then runs the workflow with agent adapter using AIAgent exposed from it.
///
/// Instead of simple text processing executors, this workflow uses three translation agents:
/// 1. French Agent - translates input text to French
/// 2. Spanish Agent - translates French text to Spanish
/// 3. English Agent - translates Spanish text back to English
///
/// The agents are connected sequentially, creating a translation chain that demonstrates
/// how AI-powered components can be seamlessly integrated into workflow pipelines.
/// </summary>
/// <remarks>
/// Pre-requisites:
/// - An Azure OpenAI chat completion deployment must be configured.
/// </remarks>
public class Program
{
    private static async Task Main()
    {
        // Set up the Azure OpenAI client
        var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ??
                       throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
        var deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME") ?? "gpt-4o-mini";
        var chatClient = new AzureOpenAIClient(
                new Uri(endpoint),
                new DefaultAzureCredential())
            .GetChatClient(deploymentName)
            .AsIChatClient()
            .AsBuilder()
            .UseOpenTelemetry(sourceName: "Agents")
            .Build();

        // Create agents
        var frenchAgent = GetTranslationAgent("French", chatClient);
        var spanishAgent = GetTranslationAgent("Spanish", chatClient);
        var englishAgent = GetTranslationAgent("English", chatClient);

        // Build the workflow by adding executors and connecting them
        WorkflowBuilder builder = new(frenchAgent);
        builder.AddEdge(frenchAgent, spanishAgent);
        builder.AddEdge(spanishAgent, englishAgent);
        var agent = builder.Build().AsAgent();

        // Run Agent Server
        await agent.RunAIAgentAsync(telemetrySourceName: "Agents").ConfigureAwait(false);
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
        return new ChatClientAgent(chatClient, instructions)
            .AsBuilder()
            .UseOpenTelemetry(sourceName: "Agents")
            .Build();
    }
}
