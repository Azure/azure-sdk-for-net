# Consolidated Voice Assistant Quickstart

This is a **standalone, self-contained** version of the BasicVoiceAssistant sample with all required code consolidated into a single `Program.cs` file. This folder is completely independent from the parent project and can be copied/distributed separately.

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

## Configuration

1. Update `appsettings.json` with your values:
   - `ApiKey`: Your Azure VoiceLive API key
   - `Endpoint`: Your Azure VoiceLive endpoint URL
   - `Model`: The model to use (default: "gpt-realtime")
   - `Voice`: The voice to use (default: "en-US-Ava:DragonHDLatestNeural")

2. Or set environment variables:
   - `AZURE_VOICELIVE_API_KEY`
   - `AZURE_VOICELIVE_ENDPOINT`

## Usage

```powershell
# Build the project
dotnet build

# Run with API key authentication (from appsettings.json or environment)
dotnet run

# Run with Azure token credential
dotnet run --use-token-credential

# Run with custom endpoint
dotnet run --endpoint "https://your-endpoint.services.ai.azure.com/"

# Run with verbose logging
dotnet run --verbose

# Run with custom voice
dotnet run --voice "en-US-JennyNeural"
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
