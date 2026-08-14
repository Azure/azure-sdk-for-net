// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

/*
# VoiceLive SDK Server Events Usage Examples

This file demonstrates how to use the VoiceLive SDK's server event streaming functionality.

## Basic Server Event Streaming

```csharp
using Azure.AI.VoiceLive;

// Create and connect to a VoiceLive session
var client = new VoiceLiveClient(endpoint, credential);
var session = await client.StartSessionAsync(sessionOptions);

// Get all server events as they arrive
await foreach (VoiceLiveServerEvent serverEvent in session.GetUpdatesAsync())
{
    Console.WriteLine($"Received event: {serverEvent.Type}");

    // Handle specific event types
    switch (serverEvent)
    {
        case VoiceLiveServerEventSessionCreated sessionCreated:
            Console.WriteLine($"Session created: {sessionCreated.Session?.Id}");
            break;

        case VoiceLiveServerEventResponseTextDelta textDelta:
            Console.Write(textDelta.Delta); // Stream text as it arrives
            break;

        case VoiceLiveServerEventResponseAudioDelta audioDelta:
            ProcessAudioData(audioDelta.Delta); // Process audio chunks
            break;

        case VoiceLiveServerEventInputAudioBufferSpeechStarted speechStarted:
            Console.WriteLine("User started speaking");
            break;

        case VoiceLiveServerEventConversationItemInputAudioTranscriptionDelta transcriptionDelta:
            Console.WriteLine($"Transcription delta: {transcriptionDelta.Delta}");
            break;

        case VoiceLiveServerEventError errorEvent:
            Console.WriteLine($"Error: {errorEvent.Error?.Message}");
            break;
    }
}
```

## Filtered Server Event Streaming

```csharp
// Get only specific types of server events
await foreach (VoiceLiveServerEventResponseTextDelta textDelta in session.GetUpdatesAsync<VoiceLiveServerEventResponseTextDelta>())
{
    Console.Write(textDelta.Delta);
}

// Get only audio delta events
await foreach (VoiceLiveServerEventResponseAudioDelta audioDelta in session.GetUpdatesAsync<VoiceLiveServerEventResponseAudioDelta>())
{
    ProcessAudioData(audioDelta.Delta);
}
```

## Synchronous Usage

```csharp
// For scenarios where you need synchronous processing
foreach (VoiceLiveServerEvent serverEvent in session.GetUpdates())
{
    ProcessServerEvent(serverEvent);
}
```

## Convenience Methods

```csharp
// Wait for a specific server event type
VoiceLiveServerEventSessionCreated sessionCreated = await session.WaitForUpdateAsync<VoiceLiveServerEventSessionCreated>();
Console.WriteLine($"Session {sessionCreated.Session?.Id} is ready");

// Wait for any error event
VoiceLiveServerEventError errorEvent = await session.WaitForUpdateAsync<VoiceLiveServerEventError>();
Console.WriteLine($"Error: {errorEvent.Error?.Message}");
```

## Avatar and Animation Events

```csharp
// Handle avatar-specific events
await foreach (VoiceLiveServerEvent serverEvent in session.GetUpdatesAsync())
{
    switch (serverEvent)
    {
        case VoiceLiveServerEventSessionAvatarConnecting avatarConnecting:
            Console.WriteLine("Avatar connection in progress");
            break;

        case ResponseAnimationBlendshapeDeltaEvent blendshapeDelta:
            ProcessBlendshapeData(blendshapeDelta.Frames);
            break;

        case ResponseAnimationVisemeDeltaEvent visemeDelta:
            ProcessVisemeData(visemeDelta.VisemeIds);
            break;

        case ResponseEmotionHypothesis emotionHypothesis:
            Console.WriteLine($"Detected emotion: {emotionHypothesis.Emotion} (confidence: {emotionHypothesis.Candidates?.FirstOrDefault()?.Confidence})");
            break;
    }
}
```

## Response Lifecycle Tracking

```csharp
await foreach (VoiceLiveServerEvent serverEvent in session.GetUpdatesAsync())
{
    switch (serverEvent)
    {
        case VoiceLiveServerEventResponseCreated responseCreated:
            Console.WriteLine($"Response started: {responseCreated.Response?.Id}");
            break;

        case VoiceLiveServerEventResponseOutputItemAdded itemAdded:
            Console.WriteLine($"Output item added: {itemAdded.Item?.Id}");
            break;

        case VoiceLiveServerEventResponseOutputItemDone itemDone:
            Console.WriteLine($"Output item completed: {itemDone.Item?.Id}");
            break;

        case VoiceLiveServerEventResponseDone responseDone:
            Console.WriteLine($"Response completed: {responseDone.Response?.Id} (status: {responseDone.Response?.Status})");
            break;
    }
}
```

## Event Type Categories

The VoiceLive service generates several categories of server events:

### Session Events
- **VoiceLiveServerEventSessionCreated**: Session initialization complete
- **VoiceLiveServerEventSessionUpdated**: Session configuration updated
- **VoiceLiveServerEventSessionAvatarConnecting**: Avatar connection in progress

### Input Audio Events
- **VoiceLiveServerEventInputAudioBufferSpeechStarted**: Voice activity detected
- **VoiceLiveServerEventInputAudioBufferSpeechStopped**: Voice activity ended
- **VoiceLiveServerEventInputAudioBufferCommitted**: Audio buffer committed
- **VoiceLiveServerEventInputAudioBufferCleared**: Audio buffer cleared

### Response Events
- **VoiceLiveServerEventResponseCreated**: Response generation started
- **VoiceLiveServerEventResponseDone**: Response generation completed
- **VoiceLiveServerEventResponseOutputItemAdded**: New output item created
- **VoiceLiveServerEventResponseOutputItemDone**: Output item completed

### Content Streaming Events
- **VoiceLiveServerEventResponseTextDelta**: Text content streaming
- **VoiceLiveServerEventResponseTextDone**: Text content completed
- **VoiceLiveServerEventResponseAudioDelta**: Audio content streaming
- **VoiceLiveServerEventResponseAudioDone**: Audio content completed
- **VoiceLiveServerEventResponseAudioTranscriptDelta**: Audio transcript streaming
- **VoiceLiveServerEventResponseAudioTranscriptDone**: Audio transcript completed

### Animation Events (VoiceLive-specific)
- **ResponseAnimationBlendshapeDeltaEvent**: Blendshape animation data streaming
- **ResponseAnimationBlendshapeDoneEvent**: Blendshape animation completed
- **ResponseAnimationVisemeDeltaEvent**: Viseme animation data streaming
- **ResponseAnimationVisemeDoneEvent**: Viseme animation completed
- **ResponseEmotionHypothesis**: Emotion detection results

### Conversation Events
- **VoiceLiveServerEventConversationItemCreated**: New conversation item
- **VoiceLiveServerEventConversationItemDeleted**: Conversation item removed
- **VoiceLiveServerEventConversationItemInputAudioTranscriptionDelta**: Input transcription streaming
- **VoiceLiveServerEventConversationItemInputAudioTranscriptionCompleted**: Input transcription completed

### Error Events
- **VoiceLiveServerEventError**: Error conditions and failures

## Error Handling

```csharp
await foreach (VoiceLiveServerEvent serverEvent in session.GetUpdatesAsync())
{
    if (serverEvent is VoiceLiveServerEventError errorEvent)
    {
        Console.WriteLine($"Error occurred: {errorEvent.Error?.Message}");
        Console.WriteLine($"Error type: {errorEvent.Error?.Type}");
        Console.WriteLine($"Error code: {errorEvent.Error?.Code}");

        // Handle specific error conditions
        switch (errorEvent.Error?.Type)
        {
            case "connection_error":
                // Handle connection issues
                break;
            case "invalid_request_error":
                // Handle request validation errors
                break;
            default:
                // Handle other errors
                break;
        }
    }
}
```

*/
