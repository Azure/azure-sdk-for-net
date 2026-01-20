using Azure.AI.AgentServer.AgentFramework.Extensions;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System.ComponentModel;

// Get configuration from environment variables
var openAiEndpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ??
                     throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
var deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME") ?? "gpt-4o-mini";
var aiProjectEndpoint = Environment.GetEnvironmentVariable("AZURE_AI_PROJECT_ENDPOINT") ??
                        throw new InvalidOperationException("AZURE_AI_PROJECT_ENDPOINT is not set.");
var toolConnectionId = Environment.GetEnvironmentVariable("TOOL_CONNECTION_ID") ??
                       throw new InvalidOperationException("TOOL_CONNECTION_ID is not set.");

var credential = new DefaultAzureCredential();

// Create chat client
var chatClient = new AzureOpenAIClient(
        new Uri(openAiEndpoint),
        credential)
    .GetChatClient(deploymentName)
    .AsIChatClient()
    .AsBuilder()
    .UseOpenTelemetry(sourceName: "Agents", configure: (cfg) => cfg.EnableSensitiveData = true)
    .Build();

// Create agent
// var agent = new ChatClientAgent(chatClient,
//         name: "test-agent",
//         instructions: "You are a helpful assistant with access to various tools.")
//     .AsBuilder()
//     .UseOpenTelemetry(sourceName: "Agents", configure: (cfg) => cfg.EnableSensitiveData = true)
//     .Build();

[Description("Get the weather for a given location.")]
static string GetWeather([Description("The location to get the weather for.")] string location)
    => $"The weather in {location} is cloudy with a high of 15°C.";

var agent = new ChatClientAgent(chatClient,
      name: "AgentWithHostedMCP",
      instructions: @"You are a helpful assistant with access to tools for fetching Microsoft documentation.

  IMPORTANT: When the user asks about Microsoft Learn articles or documentation:
  1. You MUST use the microsoft_docs_fetch tool to retrieve the actual content
  2. Do NOT rely on your training data
  3. Always fetch the latest information from the provided URL

  Available tools:
  - microsoft_docs_fetch: Fetches and converts Microsoft Learn documentation
  - microsoft_docs_search: Searches Microsoft/Azure documentation
  - microsoft_code_sample_search: Searches for code examples", tools: [AIFunctionFactory.Create(GetWeather)])
      .AsBuilder()
        // .UseFoundryTools(FoundryConnectedTool.Mcp(toolConnectionId))
        .UseFoundryTools(new { type = "mcp", project_connection_id = toolConnectionId }, new { type = "code_interpreter" })
      //   .UseFoundryTools(FoundryHostedMcpTool.Create("web_search_preview"))
      .UseOpenTelemetry(sourceName: "Agents", configure: (cfg) => cfg.EnableSensitiveData = true)
      .Build();

// Run agent with tool support using ToolDefinition objects
await agent.RunAIAgentAsync(telemetrySourceName: "Agents");

// Run agent without tool support
// await agent.RunAIAgentAsync(telemetrySourceName: "Agents");

// ============================================================================
// Alternative: Using IServiceProvider with Dependency Injection
// ============================================================================
// This approach is useful when you want to use dependency injection to manage
// your agent and other services.
//
// var services = new ServiceCollection();

// services.AddSingleton<IChatClient>(chatClient);
// services.AddSingleton<AIAgent>(agent);
// services.AddLogging(builder =>
// {
//     builder.AddConsole();
//     builder.SetMinimumLevel(LogLevel.Information);
// });

// var serviceProvider = services.BuildServiceProvider();
//
// Option 1: Run with tools using IServiceProvider extension
// await serviceProvider.RunAIAgentAsync(
//     agent: null,  // Will retrieve agent from service provider
//     tools: new List<ToolDefinition>
//     {
//         new() { Type = "mcp", ProjectConnectionId = toolConnectionId }
//     },
//     telemetrySourceName: "Agents",
//     credential: credential);
//
// Option 2: Run without tools using IServiceProvider extension
// await serviceProvider.RunAIAgentAsync(
//     agent: null,
//     telemetrySourceName: "Agents");
//
// Option 3: Run with explicit agent instance and tools
// await serviceProvider.RunAIAgentAsync(
//     agent: agent,
//     tools: new List<ToolDefinition>
//     {
//         new() { Type = "mcp", ProjectConnectionId = toolConnectionId }
//     },
//     telemetrySourceName: "Agents",
//     credential: credential);