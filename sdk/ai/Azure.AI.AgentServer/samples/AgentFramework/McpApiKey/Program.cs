using Azure.AI.AgentServer.AgentFramework.Extensions;
using Azure.AI.OpenAI;
using Azure.Identity;
using Microsoft.Agents.AI;
using Microsoft.Extensions.AI;
using ModelContextProtocol.Client;

using Microsoft.Extensions.Logging.Abstractions;

var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ??
               throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is not set.");
var deploymentName = Environment.GetEnvironmentVariable("AZURE_OPENAI_DEPLOYMENT_NAME") ?? "gpt-4o-mini";
var githubToken = Environment.GetEnvironmentVariable("GITHUB_TOKEN") ?? throw new InvalidOperationException("GITHUB_TOKEN is not set.");

// Create an MCPClient for the GitHub server
var transportOptions = new HttpClientTransportOptions
{
    Endpoint = new Uri("https://api.githubcopilot.com/mcp/"),
    Name = "github",
};

if (transportOptions.AdditionalHeaders is IDictionary<string, string> headers)
{
    headers["Authorization"] = $"Bearer {githubToken}";
}

var mcpClient = await McpClient.CreateAsync(
    new HttpClientTransport(transportOptions, NullLoggerFactory.Instance),
    new McpClientOptions()).ConfigureAwait(false);
await using var _ = mcpClient.ConfigureAwait(false);

// Retrieve the list of tools available on the GitHub server
var mcpTools = await mcpClient.ListToolsAsync().ConfigureAwait(false);

var chatClient = new AzureOpenAIClient(
        new Uri(endpoint),
        new DefaultAzureCredential())
    .GetChatClient(deploymentName)
    .AsIChatClient()
    .AsBuilder()
    .UseOpenTelemetry(sourceName: "Agents")
    .Build();

var agent = new ChatClientAgent(chatClient,
        instructions: "You are a helpful assistant that answers GitHub questions. Use only the exposed MCP tools.",
        tools: [.. mcpTools])
    .AsBuilder()
    .UseOpenTelemetry(sourceName: "Agents")
    .Build();

// Run container agent adapter
await agent.RunAIAgentAsync(telemetrySourceName: "Agents").ConfigureAwait(false);
