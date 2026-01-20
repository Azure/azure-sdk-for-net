using Azure.AI.AgentServer.AgentFramework.Extensions;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Agents.AI.Workflows;
using Microsoft.Extensions.AI;
using Azure.AI.AgentServer.Core.Tools.Models;

namespace ToolWorkflow;

/// <summary>
/// This sample introduces the use of AI agents as executors within a workflow,
/// then runs the workflow with agent adapter using AIAgent exposed from it.
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
        var toolConnectionId = Environment.GetEnvironmentVariable("TOOL_CONNECTION_ID") ??
                       throw new InvalidOperationException("TOOL_CONNECTION_ID is not set.");

        // Check if API Key is provided, otherwise use DefaultAzureCredential
        var apiKey = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");
        AzureOpenAIClient azureClient;

        if (!string.IsNullOrEmpty(apiKey))
        {
            // Use API Key authentication
            azureClient = new AzureOpenAIClient(new Uri(endpoint), new Azure.AzureKeyCredential(apiKey));
        }
        else
        {
            // Use DefaultAzureCredential (Azure CLI, Managed Identity, etc.)
            azureClient = new AzureOpenAIClient(new Uri(endpoint), new DefaultAzureCredential());
        }

        var chatClient = azureClient
            .GetChatClient(deploymentName)
            .AsIChatClient()
            .AsBuilder()
            //   .UseFoundryTools(FoundryConnectedTool.Mcp(toolConnectionId))
            .UseFoundryTools(new { type = "mcp", project_connection_id = toolConnectionId }, new { type = "code_interpreter" })
            .UseOpenTelemetry(sourceName: "Agents", configure: (cfg) => cfg.EnableSensitiveData = true)
            .Build();

        var testAgent = new ChatClientAgent(chatClient,
              name: "AgentWithHostedMCP",
              tools: [],
              instructions: @"You are a helpful assistant with access to tools for fetching Microsoft documentation.
                IMPORTANT: When the user asks about Microsoft Learn articles or documentation:
                1. You MUST use the microsoft_docs_fetch tool to retrieve the actual content
                2. Do NOT rely on your training data
                3. Always fetch the latest information from the provided URL

                Available tools:
                - microsoft_docs_fetch: Fetches and converts Microsoft Learn documentation
                - microsoft_docs_search: Searches Microsoft/Azure documentation
                - microsoft_code_sample_search: Searches for code examples")
              .AsBuilder()
              .UseOpenTelemetry(sourceName: "Agents", configure: (cfg) => cfg.EnableSensitiveData = true)
              .Build();


        // Build the workflow by adding executors and connecting them
        WorkflowBuilder builder = new(testAgent);
        var agent = builder.Build().AsAgent();

        // Run container agent adapter
        await agent.RunAIAgentAsync(telemetrySourceName: "Agents");

        // await agent.RunAIAgentAsync(telemetrySourceName: "Agents",
        // tools: new List<ToolDefinition>
        // {
        //     ToolDefinition.Mcp(toolConnectionId)
        // });
    }
}
