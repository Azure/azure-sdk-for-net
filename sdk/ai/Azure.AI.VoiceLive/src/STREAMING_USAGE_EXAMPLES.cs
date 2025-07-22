// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

/*
# VoiceLive SDK Streaming Updates Usage Examples

This file demonstrates how to use the VoiceLive SDK's streaming update functionality.

## Basic Update Streaming

```csharp
using Azure.AI.VoiceLive;

// Create and connect to a VoiceLive session
var client = new VoiceLiveClient(endpoint, credential);
var session = await client.CreateSessionAsync(sessionOptions);

// Get all updates as they arrive
await foreach (VoiceLiveUpdate update in session.GetUpdatesAsync())
{
    Console.WriteLine($"Received update: {update.Kind}");

    // Handle specific update types
    switch (update)
    {
        case SessionStartedUpdate sessionStarted:
            Console.WriteLine($"Session started: {sessionStarted.SessionId}");
            break;

        case OutputDeltaUpdate deltaUpdate:
            if (deltaUpdate.IsTextDelta)
            {
                Console.Write(deltaUpdate.TextDelta); // Stream text as it arrives
            }
            else if (deltaUpdate.IsAudioDelta)
            {
                ProcessAudioData(deltaUpdate.AudioDelta); // Process audio chunks
            }
            break;

        case InputAudioUpdate inputUpdate:
            if (inputUpdate.IsSpeechStarted)
            {
                Console.WriteLine("User started speaking");
            }
            else if (inputUpdate.IsTranscriptionDelta)
            {
                Console.WriteLine($"Transcription delta: {inputUpdate.TranscriptionDelta}");
            }
            break;

        case ErrorUpdate errorUpdate:
            Console.WriteLine($"Error: {errorUpdate.ErrorMessage}");
            break;
    }
}
```

## Filtered Update Streaming

```csharp
// Get only specific types of updates
await foreach (OutputDeltaUpdate delta in session.GetUpdatesAsync<OutputDeltaUpdate>())
{
    if (delta.IsTextDelta)
    {
        Console.Write(delta.TextDelta);
    }
}

// Get updates of specific kinds
await foreach (VoiceLiveUpdate update in session.GetUpdatesAsync(
    cancellationToken,
    VoiceLiveUpdateKind.ResponseTextDelta,
    VoiceLiveUpdateKind.ResponseAudioDelta))
{
    // Process only text and audio deltas
}
```

## Synchronous Usage

```csharp
// For scenarios where you need synchronous processing
foreach (VoiceLiveUpdate update in session.GetUpdates())
{
    ProcessUpdate(update);
}
```

## Convenience Methods

```csharp
// Wait for a specific update type
SessionStartedUpdate sessionStarted = await session.WaitForUpdateAsync<SessionStartedUpdate>();
Console.WriteLine($"Session {sessionStarted.SessionId} is ready");

// Wait for a specific update kind
VoiceLiveUpdate errorUpdate = await session.WaitForUpdateAsync(VoiceLiveUpdateKind.Error);

// Get only delta updates (streaming content)
await foreach (OutputDeltaUpdate delta in session.GetDeltaUpdatesAsync())
{
    ProcessDelta(delta);
}

// Get only streaming updates (completion events)
await foreach (OutputStreamingUpdate streaming in session.GetStreamingUpdatesAsync())
{
    ProcessStreamingUpdate(streaming);
}

// Get only input audio updates
await foreach (InputAudioUpdate inputAudio in session.GetInputAudioUpdatesAsync())
{
    ProcessInputAudio(inputAudio);
}

// Get only error updates
await foreach (ErrorUpdate error in session.GetErrorUpdatesAsync())
{
    HandleError(error);
}
```

## WebSocket Message Handling

The SDK automatically handles:
- WebSocket message fragmentation and reassembly
- JSON deserialization of server events
- Conversion from server events to typed update objects
- Connection lifecycle management
- Thread-safe message processing

## Update Types

### VoiceLiveUpdateKind Enumeration

- **Session Events**: SessionStarted, SessionUpdated, SessionAvatarConnecting
- **Input Audio Events**: InputAudioBufferCommitted, InputAudioBufferCleared, InputAudioSpeechStarted, InputAudioSpeechStopped
- **Input Transcription Events**: InputAudioTranscriptionCompleted, InputAudioTranscriptionDelta, InputAudioTranscriptionFailed
- **Response Events**: ResponseStarted, ResponseCompleted
- **Response Streaming Events**: ResponseOutputItemAdded, ResponseOutputItemDone, ResponseContentPartAdded, ResponseContentPartDone
- **Response Delta Events**: ResponseTextDelta, ResponseAudioDelta, ResponseAudioTranscriptDelta
- **Animation Events**: ResponseAnimationBlendshapesDelta, ResponseAnimationVisemeDelta, ResponseAudioTimestampDelta
- **Error Events**: Error

### Update Classes

- **VoiceLiveUpdate**: Base class for all updates
- **SessionStartedUpdate**: Session initialization complete
- **InputAudioUpdate**: Input audio processing events (speech detection, transcription)
- **OutputDeltaUpdate**: Streaming content updates (text, audio, animations)
- **OutputStreamingUpdate**: Completion events and response lifecycle
- **ErrorUpdate**: Error conditions and failures

## Error Handling

```csharp
try
{
    await foreach (VoiceLiveUpdate update in session.GetUpdatesAsync())
    {
        if (update is ErrorUpdate errorUpdate)
        {
            Console.WriteLine($"Service error: {errorUpdate.ErrorMessage}");
            // Handle the error appropriately
            break;
        }
        // Process other updates
    }
}
catch (OperationCanceledException)
{
    Console.WriteLine("Update streaming was cancelled");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
```

## Best Practices

1. **Use appropriate update filtering** to reduce processing overhead
2. **Handle cancellation** properly with CancellationToken
3. **Process delta updates quickly** to avoid buffer overrun
4. **Monitor for error updates** to handle service issues
5. **Use async enumeration** for better resource utilization
6. **Implement proper cleanup** when done with the session

*/
