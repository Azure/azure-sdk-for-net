using Azure.AI.AgentServer.AgentFramework.Extensions;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;

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
var agent = new ChatClientAgent(chatClient,
        name: "test-agent",
        instructions: "You are a helpful assistant with access to various tools.")
    .AsBuilder()
    .UseOpenTelemetry(sourceName: "Agents", configure: (cfg) => cfg.EnableSensitiveData = true)
    .Build();

// Run agent with tool support using ToolDefinition objects
await agent.RunAIAgentAsync(
    telemetrySourceName: "Agents",
    tools: new List<ToolDefinition>
    {
        new() { Type = "mcp", ProjectConnectionId = toolConnectionId }
    },
    endpoint: new Uri(aiProjectEndpoint),
    credential: credential);

// Alternative: Run with inline tool configuration (anonymous objects)
/*
await agent.RunAIAgentAsync(
    telemetrySourceName: "Agents",
    toolConfigs: new object[]
    {
        new { type = "mcp", project_connection_id = toolConnectionId }
    },
    endpoint: new Uri(aiProjectEndpoint),
    credential: credential);
*/