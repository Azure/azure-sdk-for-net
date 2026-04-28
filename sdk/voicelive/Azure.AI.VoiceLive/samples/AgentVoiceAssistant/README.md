# Agent Voice Assistant Sample

This sample demonstrates how to use the Azure VoiceLive SDK to connect to an **Azure AI Foundry agent** (Agent V2 API), enabling voice interaction with an agent that has tools, knowledge bases, and custom behaviors configured in Azure AI Foundry.

## Prerequisites

- .NET 8.0 or later
- An Azure subscription with VoiceLive access
- An Azure AI Foundry project with a deployed agent
- Azure CLI logged in (`az login`) or a managed identity

## Configuration

Agent sessions require `DefaultAzureCredential` — API key authentication is not supported.

Set the following environment variables before running:

| Variable | Required | Description |
|---|---|---|
| `AZURE_VOICELIVE_ENDPOINT` | Yes | Azure VoiceLive endpoint URL |
| `AGENT_NAME` | Yes | Azure AI Foundry agent name |
| `AGENT_PROJECT_NAME` | Yes | Azure AI Foundry project name |
| `AGENT_VERSION` | No | Specific agent version (defaults to latest) |
| `AGENT_VOICE` | No | Voice name (default: `en-US-AvaNeural`) |
| `FOUNDRY_RESOURCE_OVERRIDE` | No | Override Foundry resource endpoint |
| `AGENT_AUTH_IDENTITY_CLIENT_ID` | No | Managed identity client ID |

## Running the Sample

```bash
# Set required variables
export AZURE_VOICELIVE_ENDPOINT="https://<your-resource>.services.ai.azure.com/"
export AGENT_NAME="my-agent"
export AGENT_PROJECT_NAME="my-project"

dotnet run
```

Or pass values via command line:

```bash
dotnet run -- --endpoint https://<your-resource>.services.ai.azure.com/ \
              --agent-name my-agent \
              --agent-project my-project \
              --voice en-US-AvaNeural
```

## Key Concepts

- **`AgentSessionConfig`**: Specifies the agent to connect to by name and project. The VoiceLive service routes the session to the agent's configured instructions, tools, and knowledge.
- **`client.StartSessionAsync(AgentSessionConfig)`**: Opens a WebSocket session connected to the specified agent.
- **`DefaultAzureCredential`**: Used for authentication; run `az login` locally or configure a managed identity in production.
- **Input audio transcription**: Enabled via `AudioInputTranscriptionOptions` so the agent can process spoken input.
- **Interruption handling**: When the user starts speaking, the assistant's current audio playback is stopped and the response is cancelled, enabling natural back-and-forth conversation.

## Audio Requirements

This sample requires a working microphone and speaker. Audio is captured and played back at 24 kHz PCM 16-bit mono using NAudio.
