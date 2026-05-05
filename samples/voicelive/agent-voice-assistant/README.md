---
page_type: sample
languages:
- csharp
products:
- azure
- azure-ai-voicelive
- azure-ai-foundry
name: Azure VoiceLive Agent Voice Assistant sample for .NET
description: Sample application demonstrating how to use the Azure VoiceLive SDK to connect to an Azure AI Foundry agent with voice interaction.
---

# Azure VoiceLive Agent Voice Assistant Sample

This sample demonstrates how to use the **Azure VoiceLive SDK** to connect to an **Azure AI Foundry agent** (Agent V2 API), enabling voice interaction with an agent that has tools, knowledge bases, and custom behaviors configured in Azure AI Foundry.

## Prerequisites

- .NET 8.0 or later
- An Azure subscription with VoiceLive access
- An Azure AI Foundry project with a deployed agent
- Azure CLI logged in (`az login`) or a managed identity
- Microphone and speakers/headphones

## Setup

### 1. Install dependencies

```bash
dotnet restore
```

### 2. Configure credentials

Agent sessions require `DefaultAzureCredential`. Ensure you're logged in:

```bash
az login
```

### 3. Set required environment variables

```bash
export AZURE_VOICELIVE_ENDPOINT="https://<your-resource>.services.ai.azure.com/"
export AGENT_NAME="my-agent"
export AGENT_PROJECT_NAME="my-project"
```

Alternatively, update `appsettings.json`:

```json
{
  "VoiceLive": {
    "Endpoint": "https://<your-resource>.services.ai.azure.com/"
  },
  "Agent": {
    "Name": "your-agent-name",
    "ProjectName": "your-project-name"
  }
}
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

- `--endpoint <url>`: Azure VoiceLive endpoint (or set `AZURE_VOICELIVE_ENDPOINT`)
- `--agent-name <name>`: Azure AI Foundry agent name (or set `AGENT_NAME`)
- `--agent-project <name>`: Azure AI Foundry project name (or set `AGENT_PROJECT_NAME`)
- `--agent-version <version>`: Agent version (optional, defaults to latest)
- `--foundry-resource-override <url>`: Override Foundry resource endpoint (optional)
- `--auth-identity-client-id <id>`: Managed identity client ID (optional)
- `--voice <name>`: Voice for the assistant (default: `en-US-AvaNeural`)
- `--verbose`: Enable detailed logging

## Features

- **Agent Integration**: Connects to Azure AI Foundry agents with full tool and knowledge base support
- **Voice Interaction**: Full duplex voice conversation with the agent
- **Audio Processing**: Automatic microphone input and speaker output handling
- **Session Management**: Proper session setup and cleanup
- **Error Handling**: Comprehensive error handling and logging
- **Turn Detection**: Server-side VAD (Voice Activity Detection) for natural conversation
- **Transcription**: Automatic transcription of user speech and agent responses

## Troubleshooting

- **Audio system check failed**: Ensure your microphone and speakers are properly connected
- **Authentication failed**: Verify `az login` is working and you have access to the resource
- **Agent not found**: Verify agent name and project name are correct in Azure AI Foundry
- **Session timeout**: Agent sessions may timeout if idle for too long; restart the application

## Further Reading

- [Azure VoiceLive Documentation](https://learn.microsoft.com/en-us/azure/ai-services/voicelive/overview)
- [Azure AI Foundry Documentation](https://learn.microsoft.com/en-us/azure/ai-studio/what-is-ai-studio)
- [VoiceLive SDK for .NET](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/voicelive/Azure.AI.VoiceLive)
