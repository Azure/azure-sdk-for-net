---
page_type: sample
languages:
- csharp
products:
- azure
- azure-ai-voicelive
- azure-ai-foundry
name: Azure VoiceLive MCP Voice Assistant sample for .NET
description: Sample application demonstrating how to use the Azure VoiceLive SDK with MCP (Model Context Protocol) servers for tool integration.
---

# Azure VoiceLive MCP Voice Assistant Sample

This sample demonstrates how to use the **Azure VoiceLive SDK** with **MCP (Model Context Protocol) servers**, giving the assistant access to external tools and data sources via natural voice interaction.

## Prerequisites

- .NET 8.0 or later
- An Azure subscription with VoiceLive access
- A VoiceLive endpoint and API key (or Azure credential)
- Microphone and speakers/headphones

## Setup

### 1. Install dependencies

```bash
dotnet restore
```

### 2. Configure credentials

You can use either API key or token-based authentication:

**Option 1: Environment variables (API key)**
```bash
export AZURE_VOICELIVE_ENDPOINT="https://<your-resource>.services.ai.azure.com/"
export AZURE_VOICELIVE_API_KEY="<your-api-key>"
export AZURE_VOICELIVE_MODEL="gpt-realtime"
```

**Option 2: Token credential (DefaultAzureCredential)**
```bash
az login
```

Alternatively, update `appsettings.json`:

```json
{
  "VoiceLive": {
    "ApiKey": "your-api-key-here",
    "Endpoint": "https://<your-resource>.services.ai.azure.com/",
    "Model": "gpt-realtime",
    "Voice": "en-US-AvaNeural"
  }
}
```

## Running the Sample

```bash
# With API key
dotnet run

# Or with Azure credentials
dotnet run -- --use-token-credential

# With verbose logging
dotnet run -- --verbose
```

## Command Line Options

- `--api-key <key>`: Azure VoiceLive API key (or set `AZURE_VOICELIVE_API_KEY`)
- `--endpoint <url>`: VoiceLive service endpoint (or set `AZURE_VOICELIVE_ENDPOINT`)
- `--model <model>`: Model to use (or set `AZURE_VOICELIVE_MODEL`, default: `gpt-realtime`)
- `--voice <voice>`: Voice name (or set `AZURE_VOICELIVE_VOICE`, default: `en-US-AvaNeural`)
- `--use-token-credential`: Use `DefaultAzureCredential` instead of API key
- `--verbose`: Enable detailed logging

## Features

- **MCP Server Integration**: Connects to external MCP servers for tool discovery and execution
- **Voice Interaction**: Full duplex voice conversation with tool-augmented responses
- **Tool Discovery**: Automatic discovery of available tools from MCP servers
- **Audio Processing**: Automatic microphone input and speaker output handling
- **Session Management**: Proper session setup and cleanup
- **Error Handling**: Comprehensive error handling and logging
- **Turn Detection**: Server-side VAD (Voice Activity Detection) for natural conversation

## MCP Servers in this Sample

The sample is pre-configured with two MCP servers:

1. **deepwiki**: Wiki reading capabilities
   - URL: `https://mcp.deepwiki.com/mcp`
   - Tools: `read_wiki_structure`, `ask_question`

2. **azure_doc**: Azure documentation access
   - URL: `https://learn.microsoft.com/api/mcp`
   - All tools enabled

You can modify these servers in the `MCPVoiceAssistant.cs` file in the `SetupSessionAsync` method.

## Troubleshooting

- **Audio system check failed**: Ensure your microphone and speakers are properly connected
- **Authentication failed (HTTP 401)**: 
  - Verify endpoint format: `https://<resource>.services.ai.azure.com/`
  - Verify API key or token credential is valid
  - Ensure you're using the same Azure resource for both endpoint and credentials
- **MCP session configuration failed**: 
  - Verify the resource supports VoiceLive MCP with API version `2026-01-01-preview`
  - Ensure the model and transcription options are available
- **Connection refused**: Check endpoint URL is correct and resource is running

## Further Reading

- [Azure VoiceLive Documentation](https://learn.microsoft.com/azure/ai-services/)
- [Model Context Protocol (MCP)](https://modelcontextprotocol.io/)
- [VoiceLive SDK for .NET](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/voicelive/Azure.AI.VoiceLive)
