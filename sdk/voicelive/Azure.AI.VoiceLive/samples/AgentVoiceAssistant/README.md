# Agent Voice Assistant Sample

This sample demonstrates how to use the Azure VoiceLive SDK to connect to an **Azure AI Foundry agent** (Agent V2 API), enabling voice interaction with an agent that has tools, knowledge bases, and custom behaviors configured in Azure AI Foundry.

## Prerequisites

- .NET 8.0 or later
- An Azure subscription with VoiceLive access
- An Azure AI Foundry project with a deployed agent
- Azure CLI logged in (`az login`) or a managed identity
- Microphone and speakers/headphones

## Setup

1. **Install dependencies**:
   ```bash
   dotnet restore
   ```

2. **Configure credentials**:
   
   Agent sessions require `DefaultAzureCredential`. Ensure you're logged in:
   ```bash
   az login
   ```

3. **Set required environment variables**:
   ```bash
   export AZURE_VOICELIVE_ENDPOINT="https://<your-resource>.services.ai.azure.com/"
   export AGENT_NAME="my-agent"
   export AGENT_PROJECT_NAME="my-project"
   ```

## Running the Sample

```bash
dotnet run
```

Or pass values via command line:

```bash
dotnet run -- --endpoint https://<your-resource>.services.ai.azure.com/ \
              --agent-name my-agent \
              --agent-project my-project
```

## Command Line Options

Available options:
- `--endpoint <url>`: VoiceLive service endpoint (required)
- `--agent-name <name>`: Azure AI Foundry agent name (required)
- `--agent-project <name>`: Azure AI Foundry project name (required)
- `--agent-version <version>`: Specific agent version (defaults to latest)
- `--voice <voice>`: Voice name (default: `en-US-AvaNeural`)
- `--foundry-resource <url>`: Override Foundry resource endpoint
- `--client-id <id>`: Managed identity client ID
- `--verbose`: Enable detailed logging

Example:
```bash
dotnet run -- --agent-name my-agent \
              --agent-project my-project \
              --voice "en-US-JennyNeural" \
              --verbose
```

## Key Concepts

- **`AgentSessionConfig`**: Specifies the agent to connect to by name and project. The VoiceLive service routes the session to the agent's configured instructions, tools, and knowledge.
- **`client.StartSessionAsync(AgentSessionConfig)`**: Opens a WebSocket session connected to the specified agent.
- **`DefaultAzureCredential`**: Used for authentication; run `az login` locally or configure a managed identity in production.
- **Input audio transcription**: Enabled via `AudioInputTranscriptionOptions` so the agent can process spoken input.
- **Interruption handling**: When the user starts speaking, the assistant's current audio playback is stopped and the response is cancelled, enabling natural back-and-forth conversation.

## Audio Requirements

This sample requires a working microphone and speaker. Audio is captured and played back at 24 kHz PCM 16-bit mono using NAudio.
