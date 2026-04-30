# MCP Voice Assistant Sample

This sample demonstrates how to use the Azure VoiceLive SDK with **MCP (Model Context Protocol) servers**, giving the assistant access to external tools and data sources via natural voice interaction.

## Prerequisites

- .NET 8.0 or later
- An Azure subscription with VoiceLive access
- A VoiceLive endpoint and API key (or Azure credential)
- Microphone and speakers/headphones

## Setup

1. **Install dependencies**:
   ```bash
   dotnet restore
   ```

2. **Configure credentials**:
   
   Option 1: Environment variables
   ```bash
   export AZURE_VOICELIVE_ENDPOINT="https://<your-resource>.services.ai.azure.com/"
   export AZURE_VOICELIVE_API_KEY="<your-api-key>"
   export AZURE_VOICELIVE_MODEL="gpt-realtime"
   ```
   
   Option 2: Update `appsettings.json` or use `--use-token-credential` with `az login`

## Running the Sample

```bash
# With API key
dotnet run

# Or with Azure credentials
dotnet run -- --use-token-credential
```

## Command Line Options

Available options:
- `--api-key <key>`: Azure VoiceLive API key
- `--endpoint <url>`: VoiceLive service endpoint
- `--model <model>`: Model to use (default: `gpt-realtime`)
- `--voice <voice>`: Voice name (default: `en-US-AvaNeural`)
- `--use-token-credential`: Use DefaultAzureCredential instead of API key
- `--verbose`: Enable detailed logging

Example:
```bash
dotnet run -- --voice "en-US-JennyNeural" --verbose
```

## MCP Servers

This sample configures two MCP servers:

| Server | URL | Tools |
|---|---|---|
| `deepwiki` | `https://mcp.deepwiki.com/mcp` | `read_wiki_structure`, `ask_question` |
| `azure_doc` | `https://learn.microsoft.com/api/mcp` | All available tools |

Both servers are configured with `RequireApproval = Never` so tool calls proceed automatically without user confirmation.

## Key Concepts

- **`VoiceLiveClientOptions.ServiceVersion.V2026_01_01_PREVIEW`**: Required API version for MCP support.
- **`VoiceLiveMcpServerDefinition`**: Registers an MCP server with the session. Provide a label, URL, optional `AllowedTools` list, and `RequireApproval`.
- **`MCPApprovalType.Never`**: Set on `RequireApproval` to allow all tool calls without prompting.
- **`VoiceLiveSessionOptions.Tools`**: Add `VoiceLiveMcpServerDefinition` instances here before calling `ConfigureSessionAsync`.
- **MCP lifecycle events**: `SessionUpdateMcpListToolsInProgress/Completed/Failed` fire during tool discovery; `SessionUpdateResponseMcpCallInProgress/Completed/Failed` fire during tool calls.

## Audio Requirements

This sample requires a working microphone and speaker. Audio is captured and played back at 24 kHz PCM 16-bit mono using NAudio.
