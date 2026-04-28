# MCP Voice Assistant Sample

This sample demonstrates how to use the Azure VoiceLive SDK with **MCP (Model Context Protocol) servers**, giving the assistant access to external tools and data sources via natural voice interaction.

## Prerequisites

- .NET 8.0 or later
- An Azure subscription with VoiceLive access
- A VoiceLive endpoint and API key (or Azure credential)

## Configuration

Set the following environment variables before running:

| Variable | Required | Description |
|---|---|---|
| `AZURE_VOICELIVE_ENDPOINT` | Yes | Azure VoiceLive endpoint URL |
| `AZURE_VOICELIVE_MODEL` | Yes | Model to use (e.g., `gpt-4o-realtime-preview`) |
| `AZURE_VOICELIVE_API_KEY` | No* | API key for authentication |
| `AZURE_VOICELIVE_VOICE` | No | Voice name (default: `en-US-AvaNeural`) |

\* Either `AZURE_VOICELIVE_API_KEY` or `--use-token-credential` is required.

## Running the Sample

```bash
export AZURE_VOICELIVE_ENDPOINT="https://<your-resource>.services.ai.azure.com/"
export AZURE_VOICELIVE_API_KEY="<your-api-key>"
export AZURE_VOICELIVE_MODEL="gpt-4o-realtime-preview"

dotnet run
```

Or with DefaultAzureCredential:

```bash
dotnet run -- --use-token-credential
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
