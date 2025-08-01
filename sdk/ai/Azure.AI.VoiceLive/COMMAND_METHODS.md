# VoiceLive Session Command Methods

This document describes the new convenience methods added to the `VoiceLiveSession` class to provide a more developer-friendly API similar to the OpenAI SDK.

## Overview

The following convenience methods have been added to provide an easier way to send control messages to the VoiceLive service without requiring developers to manually construct and populate `ClientEvent` classes.

## New Methods Added

### Audio Stream Management

#### `ClearStreamingAudioAsync` / `ClearStreamingAudio`
Clears all input audio currently being streamed.

```csharp
// Async version
await session.ClearStreamingAudioAsync(cancellationToken);

// Sync version  
session.ClearStreamingAudio(cancellationToken);
```

**Underlying ClientEvent:** `ClientEventInputAudioClear`

### Audio Turn Management

#### `StartAudioTurnAsync` / `StartAudioTurn`
Starts a new audio input turn with a unique identifier.

```csharp
string turnId = Guid.NewGuid().ToString();

// Async version
await session.StartAudioTurnAsync(turnId, cancellationToken);

// Sync version
session.StartAudioTurn(turnId, cancellationToken);
```

**Underlying ClientEvent:** `ClientEventInputAudioTurnStart`

#### `AppendAudioToTurnAsync` / `AppendAudioToTurn` 
Appends audio data to an ongoing input turn. Available in two overloads for different audio data types.

```csharp
string turnId = "some-turn-id";
byte[] audioData = GetAudioBytes();
BinaryData audioBinary = BinaryData.FromBytes(audioData);

// With byte array - Async
await session.AppendAudioToTurnAsync(turnId, audioData, cancellationToken);

// With byte array - Sync
session.AppendAudioToTurn(turnId, audioData, cancellationToken);

// With BinaryData - Async
await session.AppendAudioToTurnAsync(turnId, audioBinary, cancellationToken);

// With BinaryData - Sync
session.AppendAudioToTurn(turnId, audioBinary, cancellationToken);
```

**Underlying ClientEvent:** `ClientEventInputAudioTurnAppend`

#### `EndAudioTurnAsync` / `EndAudioTurn`
Marks the end of an audio input turn.

```csharp
string turnId = "some-turn-id";

// Async version
await session.EndAudioTurnAsync(turnId, cancellationToken);

// Sync version
session.EndAudioTurn(turnId, cancellationToken);
```

**Underlying ClientEvent:** `ClientEventInputAudioTurnEnd`

#### `CancelAudioTurnAsync` / `CancelAudioTurn`
Cancels an in-progress input audio turn.

```csharp
string turnId = "some-turn-id";

// Async version
await session.CancelAudioTurnAsync(turnId, cancellationToken);

// Sync version
session.CancelAudioTurn(turnId, cancellationToken);
```

**Underlying ClientEvent:** `ClientEventInputAudioTurnCancel`

### Avatar Management

#### `ConnectAvatarAsync` / `ConnectAvatar`
Connects and provides the client's SDP (Session Description Protocol) for avatar-related media negotiation.

```csharp
string clientSdp = GetClientSdpOffer();

// Async version
await session.ConnectAvatarAsync(clientSdp, cancellationToken);

// Sync version
session.ConnectAvatar(clientSdp, cancellationToken);
```

**Underlying ClientEvent:** `ClientEventSessionAvatarConnect`

## Complete Audio Turn Example

Here's a complete example showing how to use the audio turn management methods:

```csharp
using Azure.AI.VoiceLive;

public async Task HandleAudioTurnAsync(VoiceLiveSession session, Stream audioStream)
{
    string turnId = Guid.NewGuid().ToString();
    
    try
    {
        // Start the audio turn
        await session.StartAudioTurnAsync(turnId);
        
        // Read and append audio data in chunks
        byte[] buffer = new byte[4096];
        int bytesRead;
        
        while ((bytesRead = await audioStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            byte[] audioChunk = new byte[bytesRead];
            Array.Copy(buffer, audioChunk, bytesRead);
            
            await session.AppendAudioToTurnAsync(turnId, audioChunk);
        }
        
        // End the audio turn
        await session.EndAudioTurnAsync(turnId);
    }
    catch (Exception ex)
    {
        // Cancel the turn if something goes wrong
        await session.CancelAudioTurnAsync(turnId);
        throw;
    }
}
```

## Design Principles

These methods follow the established patterns in the VoiceLive SDK:

1. **Both sync and async versions** are provided for all methods
2. **Proper parameter validation** using `Argument.AssertNotNull` and `Argument.AssertNotNullOrEmpty`
3. **Disposal checking** using `ThrowIfDisposed()` 
4. **Consistent naming** that describes the action rather than just mirroring the event type
5. **Comprehensive documentation** with parameter descriptions and exception information
6. **JSON serialization** for sending commands, consistent with existing methods

## Previously Existing Methods

The following convenience methods were already available and remain unchanged:

- **Audio Buffer Management:** `SendInputAudioAsync`, `ClearInputAudioAsync`, `CommitInputAudioAsync`
- **Session Configuration:** `ConfigureSessionAsync`, `ConfigureConversationSessionAsync`, `ConfigureTranscriptionSessionAsync`
- **Item Management:** `AddItemAsync`, `RequestItemRetrievalAsync`, `DeleteItemAsync`, `TruncateConversationAsync`
- **Response Management:** `StartResponseAsync`, `CancelResponseAsync`

The new methods complement these existing ones to provide comprehensive coverage of all available `ClientEvent` types.