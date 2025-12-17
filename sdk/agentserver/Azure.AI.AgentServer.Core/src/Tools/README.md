# Azure AI Tools Support for C#

This implementation provides comprehensive tools support for the Azure AI Agent Server in C#, mirroring the functionality of the Python implementation.

## Architecture

### Core Components

```
Tools/
├── Models/                          # Data models
│   ├── FoundryTool.cs              # Tool descriptor
│   ├── ToolSource.cs               # Enum: McpTools, RemoteTools
│   ├── ToolDefinition.cs           # Tool configuration
│   └── UserInfo.cs                 # User context
├── Operations/                      # Protocol handlers
│   ├── MCPToolsOperations.cs       # MCP (JSON-RPC 2.0)
│   └── RemoteToolsOperations.cs    # Azure AI Tools API
├── Utilities/                       # Helper classes
│   ├── ToolDescriptorBuilder.cs    # Builds FoundryTool
│   ├── ToolMetadataExtractor.cs    # Extracts metadata
│   ├── NameResolver.cs             # Unique name resolution
│   ├── MetadataMapper.cs           # Maps _meta to config
│   └── ToolConfigurationParser.cs  # Parses tool configs
├── Exceptions/                      # Custom exceptions
│   ├── OAuthConsentRequiredException.cs
│   └── MCPToolApprovalRequiredException.cs
├── AzureAIToolClient.cs       # Async client
└── AzureAIToolClientOptions.cs     # Configuration
```

## Features

-   **Dual Protocol Support**: MCP (Model Context Protocol) and Remote Tools (Azure AI Tools API)
-   **Synchronous and Asynchronous APIs**: Both sync and async versions available
-   **Agent Framework Integration**: Seamless conversion to AIFunction
-   **OAuth Support**: Handles OAuth consent flows
-   **Tool Approval**: Supports MCP tool approval workflow
-   **Parallel Tool Listing**: Uses Task.WhenAll() for optimal performance
-   **Metadata Mapping**: Intelligent mapping of \_meta schema to tool configuration

## Usage

### Basic Example

```csharp
using Azure.AI.AgentServer.Core.Tools;
using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.Identity;

var endpoint = new Uri("https://<resource>.api.azureml.ms");
var credential = new DefaultAzureCredential();

var options = new AzureAIToolClientOptions
{
    Tools = new List<ToolDefinition>
    {
        new() { Type = "mcp", ProjectConnectionId = "my-connection" }
    }
};

await using var toolClient = new AzureAIToolClient(endpoint, credential, options);

// List tools
var tools = await toolClient.ListToolsAsync();
foreach (var tool in tools)
{
    Console.WriteLine($"{tool.Name}: {tool.Description}");
}

// Invoke tool
var result = await toolClient.InvokeToolAsync("tool_name", new Dictionary<string, object?>
{
    ["param"] = "value"
});
```

### Agent Framework Integration

```csharp
using Azure.AI.AgentServer.AgentFramework.Extensions;
using Azure.AI.AgentServer.Core.Tools.Models;
using Microsoft.Agents.AI;

var agent = new ChatClientAgent(chatClient,
    name: "assistant",
    instructions: "You are a helpful assistant.");

// Run with tool support
await agent.RunAIAgentAsync(
    telemetrySourceName: "Agents",
    tools: new List<ToolDefinition>
    {
        new() { Type = "mcp", ProjectConnectionId = "connection-id" }
    },
    endpoint: new Uri("https://..."),
    credential: new DefaultAzureCredential());
```

### Inline Tool Configuration

```csharp
// Alternative: Use anonymous objects for configuration
await agent.RunAIAgentAsync(
    telemetrySourceName: "Agents",
    toolConfigs: new object[]
    {
        new { type = "mcp", project_connection_id = "connection-id" },
        new { type = "image_generation" }
    },
    endpoint: new Uri("https://..."),
    credential: new DefaultAzureCredential());
```

## Supported Tool Types

1. **MCP Tools** - Model Context Protocol tools via JSON-RPC 2.0
2. **Remote Tools** - Azure AI Tools API (A2A protocol)
3. **Named MCP Tools** - Predefined MCP tools (e.g., "image_generation")

## Configuration

### Environment Variables

```bash
AZURE_AI_PROJECT_ENDPOINT=https://<account>.services.ai.azure.com/api/projects/<project>
AZURE_OPENAI_ENDPOINT=https://<endpoint>.cognitiveservices.azure.com/
AZURE_OPENAI_DEPLOYMENT_NAME=gpt-4o
TOOL_CONNECTION_ID=<your-tool-connection-id>
```

### AzureAIToolClientOptions

```csharp
var options = new AzureAIToolClientOptions
{
    AgentName = "$default",                           // Agent name
    Tools = new List<ToolDefinition> { ... },        // Tool definitions
    User = new UserInfo("objectId", "tenantId"),     // User context
    ApiVersion = "2025-05-15-preview",               // API version
    CredentialScopes = new List<string> { ... }      // Auth scopes
};
```

## Error Handling

```csharp
try
{
    var result = await toolClient.InvokeToolAsync("tool", args);
}
catch (OAuthConsentRequiredException ex)
{
    Console.WriteLine($"OAuth consent required: {ex.ConsentUrl}");
}
catch (MCPToolApprovalRequiredException ex)
{
    Console.WriteLine($"Tool approval required: {ex.Message}");
}
```

## Design Patterns

-   **Record Types**: Immutable data models (FoundryTool, ToolDefinition, UserInfo)
-   **Async/Await**: Comprehensive async support with ConfigureAwait(false)
-   **IAsyncDisposable**: Proper resource cleanup
-   **Extension Methods**: Convenient API for agent integration
-   **Builder Pattern**: Agent.AsBuilder() for composability

## API Compatibility

This C# implementation maintains feature parity with the Python implementation while following idiomatic C# patterns and conventions.
