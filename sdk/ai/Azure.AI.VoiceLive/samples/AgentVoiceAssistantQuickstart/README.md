# Azure AI Foundry Agent Voice Assistant Quickstart

This is a **standalone, self-contained** version of the BasicVoiceAssistant sample that connects to an **Azure AI Foundry agent** instead of directly using a VoiceLive model. Unlike the model quickstart, this sample routes requests to a deployed agent in Azure AI Foundry, using the agent's configured model and instructions. All required code is consolidated into a single `Program.cs` file. This folder is completely independent from the parent project and can be copied/distributed separately.

## What's Included

- **Program.cs**: Contains all classes consolidated into one file:
  - `Program` class (main entry point and command-line handling)
  - `BasicVoiceAssistant` class (voice assistant logic)
  - `AudioProcessor` class (audio capture and playback)
- **ConsolidatedVoiceAssistant.csproj**: Project file with all necessary dependencies
- **appsettings.json**: Configuration file (template - update with your values)

## Standalone Features

✅ **Complete isolation** - No dependencies on parent folder structure  
✅ **Self-contained** - All code in one Program.cs file  
✅ **Portable** - Copy this entire folder anywhere  
✅ **Independent build** - Uses own Directory.Build.props to avoid inheritance  

## Prerequisites

- .NET 8.0 SDK
- Audio input/output devices (microphone and speakers)  
- Azure VoiceLive resource with API key or Azure authentication
- Azure AI Foundry project with a deployed agent
- Azure CLI authentication or appropriate Azure credentials configured

## Configuration

1. Update `appsettings.json` with your values:

   ```json
   {
     "VoiceLive": {
       "ApiKey": "your-voicelive-api-key",
       "Endpoint": "wss://api.voicelive.com/v1",
       "Voice": "en-US-AvaNeural"
     },
     "Agent": {
       "Id": "your-agent-id",
       "ProjectName": "your-agent-project-name"
     }
   }
   ```

2. Or set environment variables:
   - `AZURE_VOICELIVE_API_KEY`
   - `AZURE_VOICELIVE_ENDPOINT`  
   - `AZURE_AGENT_ID`
   - `AZURE_AGENT_PROJECT_NAME`

**Note**: Agent access tokens are automatically generated using `DefaultAzureCredential`. No need to manually configure agent authentication - just ensure you're authenticated with Azure CLI or have appropriate credentials configured.

## Usage

```powershell
# Build the project
dotnet build

# Run with agent parameters (requires Azure authentication)
dotnet run --agent-id "asst_ABC123" --agent-project-name "my-project" --use-token-credential

# Run with parameters from appsettings.json
dotnet run --use-token-credential

# Run with API key authentication (for VoiceLive service)
dotnet run --agent-id "asst_ABC123" --agent-project-name "my-project" --api-key "your-api-key"

# Run with verbose logging  
dotnet run --agent-id "asst_ABC123" --agent-project-name "my-project" --use-token-credential --verbose

# Run with custom voice
dotnet run --agent-id "asst_ABC123" --agent-project-name "my-project" --use-token-credential --voice "en-US-JennyNeural"
```

## Command Line Options

- `--api-key`: Azure VoiceLive API key
- `--endpoint`: Azure VoiceLive endpoint
- `--model`: VoiceLive model to use (default: "gpt-4o")
- `--voice`: Voice for the assistant (default: "en-US-AvaNeural")
- `--instructions`: System instructions for the AI
- `--use-token-credential`: Use Azure authentication instead of API key
- `--verbose`: Enable detailed logging

## Features

This consolidated sample demonstrates:

- Real-time voice conversation with interruption handling
- Audio capture from microphone
- Audio playback to speakers
- VoiceLive SDK convenience methods
- Proper resource cleanup and error handling

## Isolation Features Implemented

✅ **NuGet.Config**: Uses only nuget.org (no Azure DevOps feeds)  
✅ **Directory.Build.props**: Blocks inheritance from parent build system  
✅ **Project file**: Standard package versions (no VersionOverride)  
✅ **Standalone dependencies**: All packages use public versions  

## Troubleshooting

If you encounter audio issues, ensure:

- Your microphone and speakers are working
- No other applications are using your audio devices
- Audio drivers are up to date

If you encounter build issues:

- Ensure you're running from within the Azure SDK repository (for project reference to Azure.AI.VoiceLive source)
- Try `dotnet clean` and `dotnet restore` to clear cached packages
- Verify the project reference path to `..\..\..\..\src\Azure.AI.VoiceLive.csproj` is correct
