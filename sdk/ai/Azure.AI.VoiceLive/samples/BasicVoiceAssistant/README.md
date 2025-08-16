# Basic Voice Assistant Sample

This sample demonstrates the fundamental capabilities of the Azure VoiceLive SDK by creating a basic voice assistant that can engage in natural conversation with proper interruption handling. This serves as the foundational example that showcases the core value proposition of unified speech-to-speech interaction.

## New VoiceLive SDK Convenience Methods

This sample now demonstrates some of the new convenience methods added to the VoiceLive SDK for better developer experience:

**Used in this sample:**
- `ClearStreamingAudioAsync()` - Clears all input audio currently being streamed
- `ConfigureConversationSessionAsync()` - Configures conversation session options
- `CancelResponseAsync()` - Cancels the current response generation
- `SendInputAudioAsync()` - Sends audio data to the service

**Additional convenience methods available:**
- `StartAudioTurnAsync()` / `EndAudioTurnAsync()` / `CancelAudioTurnAsync()` - Audio turn management
- `AppendAudioToTurnAsync()` - Append audio data to an ongoing turn  
- `ConnectAvatarAsync()` - Connect avatar with SDP for media negotiation
- `CommitInputAudioAsync()` / `ClearInputAudioAsync()` - Audio buffer operations

These methods eliminate the need to manually construct and populate `ClientEvent` classes, providing a more developer-friendly API similar to the OpenAI SDK.

## Features

- **Real-time voice conversation**: Seamless bidirectional audio streaming
- **Interruption handling**: Graceful handling of user interruptions during assistant responses
- **Multiple voice options**: Support for both OpenAI and Azure voices
- **Cross-platform audio**: Uses NAudio for reliable audio capture and playback
- **Robust error handling**: Automatic reconnection and error recovery
- **Configurable settings**: Command line options and configuration file support

## Prerequisites

- .NET 8.0 or later
- Azure VoiceLive API key or Azure credential
- Microphone and speakers/headphones
- Audio drivers properly installed

## Setup

1. **Install dependencies**:
   ```bash
   dotnet restore
   ```

2. **Configure credentials**:
   
   Option 1: Environment variables
   ```bash
   export AZURE_VOICELIVE_API_KEY="your-api-key"
   export AZURE_VOICELIVE_ENDPOINT="wss://api.voicelive.com/v1"
   ```
   
   Option 2: Update `appsettings.json`
   ```json
   {
     "VoiceLive": {
       "ApiKey": "your-api-key",
       "Endpoint": "wss://api.voicelive.com/v1",
       "Model": "gpt-4o-realtime-preview",
       "Voice": "en-US-AvaNeural",
       "Instructions": "You are a helpful AI assistant. Respond naturally and conversationally."
     }
   }
   ```

3. **Test audio system**:
   ```bash
   dotnet run -- --verbose
   ```

## Usage

### Basic Usage
```bash
dotnet run
```

### Command Line Options
```bash
dotnet run -- --help
```

Available options:
- `--api-key <key>`: Azure VoiceLive API key
- `--endpoint <url>`: VoiceLive service endpoint
- `--model <model>`: Model to use (default: gpt-4o-realtime-preview)
- `--voice <voice>`: Voice for the assistant (default: en-US-AvaNeural)
- `--instructions <text>`: System instructions for the AI
- `--use-token-credential`: Use Azure authentication instead of API key
- `--verbose`: Enable detailed logging

### Example Commands

**Using a different voice**:
```bash
dotnet run -- --voice "en-US-JennyNeural"
```

**Using OpenAI voice**:
```bash
dotnet run -- --voice "alloy"
```

**Custom instructions**:
```bash
dotnet run -- --instructions "You are a helpful coding assistant. Focus on programming questions and provide code examples."
```

**Azure authentication**:
```bash
dotnet run -- --use-token-credential
```

## Supported Voices

### OpenAI Voices
- `alloy`
- `echo`
- `fable`
- `onyx`
- `nova`
- `shimmer`

### Azure Voices
- `en-US-AvaNeural`
- `en-US-JennyNeural`
- `en-US-GuyNeural`

## How It Works

### Architecture
The sample uses a multi-threaded architecture for optimal performance:

1. **Main Thread**: UI and event processing
2. **Audio Capture**: NAudio input stream processing
3. **Audio Send**: Async transmission to VoiceLive service
4. **Audio Playback**: NAudio output stream processing

### Key Components

#### VoiceLiveClient
- Manages authentication and connection to the service
- Provides WebSocket-based real-time communication

#### VoiceLiveSession  
- Handles bidirectional message streaming
- Manages session lifecycle and configuration

#### AudioProcessor
- Captures audio from microphone (24kHz PCM16 mono)
- Streams audio to VoiceLive service in real-time
- Plays back assistant responses through speakers
- Handles interruption scenarios

#### BasicVoiceAssistant
- Orchestrates the entire conversation flow
- Handles VoiceLive events and updates
- Manages session configuration and voice settings

### Event Flow

1. **Session Setup**: Configure audio format, voice, and turn detection
2. **Audio Capture**: Start capturing microphone input
3. **Speech Detection**: Service detects when user starts/stops speaking
4. **Response Generation**: AI generates audio response
5. **Audio Playback**: Stream response audio to speakers
6. **Interruption Handling**: Stop playback when user interrupts

## Troubleshooting

### Audio Issues

**No microphone detected**:
- Ensure microphone is connected and recognized by Windows
- Check audio permissions for the application
- Try running with `--verbose` to see detailed audio device information

**No sound output**:
- Check speaker/headphone connections
- Verify volume levels
- Ensure no other applications are exclusively using audio devices

**Poor audio quality**:
- Check microphone positioning and levels
- Reduce background noise
- Ensure stable internet connection for real-time streaming

### Connection Issues

**Authentication failed**:
- Verify API key is correct and active
- Check endpoint URL format
- Try using `--use-token-credential` for Azure authentication

**Connection timeouts**:
- Check internet connectivity
- Verify firewall allows WebSocket connections
- Try different endpoint if available

### Performance Issues

**High latency**:
- Close other bandwidth-intensive applications
- Use wired internet connection instead of WiFi
- Reduce audio buffer sizes (requires code modification)

**Audio dropouts**:
- Check system resources (CPU, memory)
- Close unnecessary applications
- Update audio drivers

## Advanced Configuration

### Custom Audio Settings
Modify `AudioProcessor.cs` to adjust:
- Buffer sizes for latency vs. stability trade-offs
- Sample rates (requires service support)
- Audio formats and compression

### Session Configuration
Modify `BasicVoiceAssistant.cs` to customize:
- Turn detection sensitivity
- Response modalities (text + audio vs. audio only)
- Conversation context and memory

### Error Handling
The sample includes robust error handling for:
- Network connectivity issues
- Audio device problems  
- Service-side errors
- Graceful shutdown scenarios

## Next Steps

This basic sample can be extended with:

1. **Voice Selection UI**: Dynamic voice switching during conversation
2. **Conversation History**: Save and replay conversations
3. **Custom Instructions**: Runtime instruction updates
4. **Multi-Language Support**: Language detection and switching
5. **Audio Effects**: Voice modulation and audio processing
6. **Analytics**: Conversation metrics and usage tracking

## References

- [NAudio Documentation](https://github.com/naudio/NAudio)
- [System.CommandLine Documentation](https://docs.microsoft.com/dotnet/standard/commandline/)
