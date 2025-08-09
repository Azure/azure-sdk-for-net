# Azure.AI.VoiceLive SDK - Streaming and Processing Implementation

## Overview
This implementation provides comprehensive streaming and processing functionality for the Azure.AI.VoiceLive SDK, following Azure SDK design patterns and based on the OpenAI Realtime API patterns.

## Components Implemented

### 1. Core Update Infrastructure

#### `VoiceLiveUpdateKind` (`/src/Updates/VoiceLiveUpdateKind.cs`)
- Enumeration of all possible update types from the VoiceLive service
- Maps server event types to client-side update kinds
- Includes session, input audio, response, animation, and error events
- Provides conversion methods from server event type strings

#### `VoiceLiveUpdate` (`/src/Updates/VoiceLiveUpdate.cs`)
- Abstract base class for all updates received from the service
- Implements `IJsonModel<VoiceLiveUpdate>` and `IPersistableModel<VoiceLiveUpdate>`
- Provides serialization/deserialization support
- Includes factory method to create updates from server events

### 2. Specific Update Types

#### `SessionStartedUpdate` (`/src/Updates/SessionStartedUpdate.cs`)
- Represents session initialization completion
- Provides access to session details (ID, configuration)
- Created when the service confirms session establishment

#### `InputAudioUpdate` (`/src/Updates/InputAudioUpdate.cs`)
- Handles all input audio-related events
- Covers speech detection (start/stop), audio buffer management, transcription events
- Provides typed access to audio timing, transcription text, errors
- Boolean properties for easy event type checking

#### `OutputDeltaUpdate` (`/src/Updates/OutputDeltaUpdate.cs`)
- Represents streaming/incremental content from the service
- Handles text deltas, audio chunks, animation data, timestamps
- Provides typed access to different content types (text, audio, animations)
- Supports real-time content streaming scenarios

#### `OutputStreamingUpdate` (`/src/Updates/OutputStreamingUpdate.cs`)
- Represents completion events and response lifecycle updates
- Handles response start/completion, item creation/completion, content part events
- Provides access to final content, usage statistics, response status
- Boolean properties for different completion states

#### `ErrorUpdate` (`/src/Updates/ErrorUpdate.cs`)
- Represents error conditions from the service
- Provides detailed error information (type, code, message, parameters)
- Includes helpful string representation for debugging
- Maps service error events to client-side error objects

### 3. Factory Pattern

#### `VoiceLiveUpdateFactory` (`/src/VoiceLiveUpdateFactory.cs`)
- Factory class for creating appropriate update instances from server events
- Maps server event types to corresponding update classes
- Handles JSON deserialization and type conversion
- Supports both direct server event conversion and JSON element parsing
- Includes generic update handling for unknown event types

### 4. Session Extension for Streaming

#### `VoiceLiveSession.Updates.cs` (`/src/VoiceLiveSession.Updates.cs`)
- Partial class extension providing streaming functionality
- Implements `IAsyncEnumerable<VoiceLiveUpdate>` pattern
- Provides multiple convenience methods for filtered streaming

**Main Methods:**
- `GetUpdatesAsync()` - Get all updates as async enumerable
- `GetUpdates()` - Synchronous version for blocking scenarios
- `GetUpdatesAsync<T>()` - Filter by specific update type
- `GetUpdatesAsync(kinds...)` - Filter by update kinds
- `WaitForUpdateAsync<T>()` - Wait for next update of specific type
- `WaitForUpdateAsync(kind)` - Wait for next update of specific kind

**Convenience Methods:**
- `GetDeltaUpdatesAsync()` - Only streaming content updates
- `GetStreamingUpdatesAsync()` - Only completion/lifecycle updates  
- `GetInputAudioUpdatesAsync()` - Only input audio processing updates
- `GetErrorUpdatesAsync()` - Only error updates

### 5. WebSocket Message Handling

#### Core Features:
- **Fragmentation Handling**: Properly handles WebSocket message fragmentation using existing `AsyncVoiceLiveMessageCollectionResult`
- **Thread Safety**: Uses existing locking mechanism to prevent multiple readers
- **Message Processing**: Converts WebSocket messages to server events and then to updates
- **Error Recovery**: Handles JSON parsing failures gracefully with unknown update types
- **Connection Management**: Integrates with existing connection lifecycle

#### `AsyncEnumerableExtensions` (`/src/WebSocketHelpers/AsyncEnumerableExtensions.cs`)
- Utility for converting `IAsyncEnumerable` to blocking enumerable
- Supports synchronous usage scenarios
- Proper cancellation and disposal handling

## Key Features

### 1. Comprehensive Event Coverage
- Supports all VoiceLive server event types
- Maps to appropriate client-side update classes
- Handles both streaming (delta) and completion events

### 2. Type Safety
- Strongly typed update classes with appropriate properties
- Generic filtering methods for compile-time type safety
- Boolean properties for easy event type checking

### 3. Flexible Consumption Patterns
- Async enumerable for efficient streaming
- Synchronous enumerable for blocking scenarios
- Filtered streaming by type or kind
- Wait methods for specific events
- Convenience methods for common scenarios

### 4. WebSocket Integration
- Builds on existing WebSocket infrastructure
- Handles message fragmentation automatically
- Thread-safe message processing
- Proper connection state management

### 5. Error Handling
- Comprehensive error update support
- Graceful handling of parsing failures
- Proper exception propagation
- Unknown event type handling

### 6. Azure SDK Compliance
- Follows Azure SDK design guidelines
- Implements required interfaces (`IJsonModel`, `IPersistableModel`)
- Uses Azure SDK naming conventions
- Integrates with existing patterns

## Usage Patterns

### Basic Streaming
```csharp
await foreach (VoiceLiveUpdate update in session.GetUpdatesAsync())
{
    switch (update)
    {
        case OutputDeltaUpdate delta when delta.IsTextDelta:
            Console.Write(delta.TextDelta);
            break;
        case ErrorUpdate error:
            Console.WriteLine($"Error: {error.ErrorMessage}");
            break;
    }
}
```

### Filtered Streaming
```csharp
await foreach (OutputDeltaUpdate delta in session.GetUpdatesAsync<OutputDeltaUpdate>())
{
    ProcessDelta(delta);
}
```

### Wait for Specific Events
```csharp
SessionStartedUpdate started = await session.WaitForUpdateAsync<SessionStartedUpdate>();
Console.WriteLine($"Session {started.SessionId} ready");
```

## Implementation Quality

### Strengths
1. **Complete Implementation**: Covers all major VoiceLive event types
2. **Type Safety**: Strong typing with appropriate inheritance hierarchy  
3. **Flexible API**: Multiple consumption patterns for different scenarios
4. **Integration**: Builds on existing WebSocket infrastructure
5. **Error Handling**: Comprehensive error scenarios covered
6. **Documentation**: Extensive inline documentation and usage examples

### Architecture Benefits
1. **Extensible**: Easy to add new update types as service evolves
2. **Performant**: Efficient streaming with minimal allocations
3. **Testable**: Clean separation of concerns enables thorough testing
4. **Maintainable**: Clear code organization and consistent patterns

## Files Created
- `/src/Updates/VoiceLiveUpdateKind.cs` - Update type enumeration
- `/src/Updates/VoiceLiveUpdate.cs` - Base update class
- `/src/Updates/SessionStartedUpdate.cs` - Session events
- `/src/Updates/InputAudioUpdate.cs` - Input audio processing
- `/src/Updates/OutputDeltaUpdate.cs` - Streaming content
- `/src/Updates/OutputStreamingUpdate.cs` - Completion events
- `/src/Updates/ErrorUpdate.cs` - Error handling
- `/src/VoiceLiveUpdateFactory.cs` - Factory pattern implementation
- `/src/VoiceLiveSession.Updates.cs` - Session streaming extension
- `/src/WebSocketHelpers/AsyncEnumerableExtensions.cs` - Utility methods
- `/src/STREAMING_USAGE_EXAMPLES.cs` - Comprehensive usage examples

This implementation provides a complete, production-ready streaming and processing system for the Azure.AI.VoiceLive SDK that follows best practices and integrates seamlessly with the existing codebase.