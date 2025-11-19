# WebSocket Content Logging Tests

This directory contains comprehensive tests for the WebSocket content logging functionality in Azure.AI.VoiceLive.

## Test Files

### 1. `ContentLoggingTests.cs`
**Purpose**: Core functionality tests for WebSocket content logging
**Key Test Areas**:
- Configuration validation (`IsLoggingContentEnabled`, `IsLoggingEnabled`)
- Connection lifecycle logging (open/close events)
- Message operation logging (send/receive events)  
- Content logging with proper event levels
- Content size truncation
- Error content logging at appropriate levels

**Example Tests**:
```csharp
[Test]
public async Task Session_WithContentLoggingEnabled_LogsConnectionOpen()
[Test] 
public async Task Session_WithContentLoggingEnabled_LogsSentMessages()
[Test]
public void ContentLogger_TruncatesLargeContent()
```

### 2. `EventSourceIntegrationTests.cs`
**Purpose**: Integration tests verifying EventSource behavior and Azure SDK compliance
**Key Test Areas**:
- EventSource naming conventions (`Azure-VoiceLive`)
- Inheritance from `AzureEventSource` 
- Event ID uniqueness and range (1000+)
- Event level filtering behavior
- Message format consistency with Azure SDK patterns
- Unified discovery alongside other Azure EventSources

**Example Tests**:
```csharp
[Test]
public void AzureVoiceLiveEventSource_InheritsFromAzureEventSource()
[Test]
public void EventSource_CanBeDiscoveredByAzurePattern()
[Test]
public void EventMessages_FollowAzureSDKPatterns()
```

### 3. `ContentLoggingPerformanceTests.cs`
**Purpose**: Performance tests ensuring content logging doesn't impact WebSocket operations
**Key Test Areas**:
- Overhead measurement (disabled vs enabled logging)
- Large content truncation efficiency
- EventSource call performance when disabled
- Session operation performance with logging enabled

**Example Tests**:
```csharp
[Test]
public void ContentLogger_WhenLoggingDisabled_HasMinimalOverhead()
[Test]
public async Task SessionOperations_WithContentLogging_MaintainPerformance()
```

### 4. `UnifiedLoggingExperienceTests.cs`
**Purpose**: Tests demonstrating the unified Azure SDK logging experience
**Key Test Areas**:
- Unified EventListener handling both HTTP and WebSocket events
- Event level consistency with Azure.Core patterns
- Configuration experience matching Azure SDK conventions
- Structured event capture and processing

**Example Tests**:
```csharp
[Test]
public async Task UnifiedListener_CapturesWebSocketEvents_WithCorrectMetadata()
[Test]
public void EventLevels_FollowAzureSDKPatterns()
```

## Running the Tests

### Prerequisites
- .NET SDK 6.0 or higher
- NUnit test framework
- Azure.Core.TestFramework
- Nullable reference types enabled (all test files include `#nullable enable`)

### Run All Content Logging Tests
```bash
# From the test directory
dotnet test --filter "FullyQualifiedName~ContentLogging"

# Or run specific test classes
dotnet test --filter "ClassName=ContentLoggingTests"
dotnet test --filter "ClassName=EventSourceIntegrationTests"
dotnet test --filter "ClassName=ContentLoggingPerformanceTests"
dotnet test --filter "ClassName=UnifiedLoggingExperienceTests"
```

### Run Specific Test Categories
```bash
# Run only unit tests (fast)
dotnet test --filter "FullyQualifiedName~ContentLogging&TestCategory!=Performance"

# Run only performance tests
dotnet test --filter "ClassName=ContentLoggingPerformanceTests"

# Run integration tests
dotnet test --filter "ClassName=EventSourceIntegrationTests"
```

## Test Infrastructure

### `TestEventListener` 
Helper class that captures EventSource events for verification:
```csharp
internal class TestEventListener : EventListener
{
    protected override void OnEventSourceCreated(EventSource eventSource)
    {
        if (eventSource.Name == "Azure-VoiceLive")
        {
            EnableEvents(eventSource, EventLevel.Verbose);
        }
    }
}
```

### `FakeWebSocket`
Mock WebSocket implementation from existing test infrastructure:
- Captures sent messages
- Provides scriptable inbound message queue
- Simulates WebSocket lifecycle events

### Test Patterns

1. **Arrange-Act-Assert**: Standard test structure
2. **Event Capture**: Use TestEventListener to capture and verify events
3. **Mock WebSocket**: Use FakeWebSocket for deterministic testing
4. **Performance Measurement**: Use Stopwatch for timing-sensitive tests
5. **Event ID Constants**: Use `AzureVoiceLiveEventSource.EventName` constants instead of magic numbers

## Key Verification Points

### ✅ **Event Source Compliance**
- EventSource name follows `"Azure-{ServiceName}"` pattern
- Inherits from `AzureEventSource` for Azure SDK integration
- Event IDs in 1000+ range to avoid conflicts
- Proper event level usage (Verbose, Informational, Warning)

### ✅ **Configuration Integration**
- Respects `DiagnosticsOptions.IsLoggingContentEnabled`
- Honors `LoggedContentSizeLimit` for content truncation
- Works with existing Azure SDK diagnostic infrastructure

### ✅ **Functional Correctness**
- Connection lifecycle events logged appropriately
- Message send/receive operations captured
- Content logging with proper truncation
- Error scenarios handled with appropriate event levels

### ✅ **Performance Requirements**
- Minimal overhead when logging disabled
- Efficient content truncation for large payloads
- Fast EventSource calls when events not enabled
- Reasonable performance impact when logging enabled

### ✅ **Developer Experience**
- Unified listener can handle both HTTP and WebSocket events
- Consistent event patterns with Azure.Core
- Clear event messages with connection IDs
- Standard Azure SDK configuration experience

## Expected Test Results

When running these tests, you should see:

1. **All tests pass** - Indicates functionality works correctly
2. **Performance tests complete quickly** - Usually < 1 second each
3. **Event capture works correctly** - EventListener receives expected events
4. **Configuration validation succeeds** - DiagnosticsOptions integration works
5. **No memory leaks** - EventListeners properly disposed

## Troubleshooting

### Common Issues

1. **EventSource not found**: Ensure Azure.AI.VoiceLive.dll is loaded
2. **Events not captured**: Verify EventListener enables correct event levels
3. **Performance test failures**: May indicate system load or debugging overhead
4. **Assembly loading issues**: Ensure all dependencies are available

### Debug Tips

1. Add console output to EventListener.OnEventWritten for debugging
2. Use EventSource.GetSources() to list available EventSources
3. Check EventSource.IsEnabled() status for troubleshooting
4. Verify test isolation by running tests individually

## Event ID Constants Reference

### Azure.AI.VoiceLive WebSocket Events
All event IDs are defined as constants in `AzureVoiceLiveEventSource` and should be used instead of magic numbers:

| Constant | Event ID | Event Name | Level | Description |
|----------|----------|------------|-------|-------------|
| `WebSocketConnectionOpenEvent` | 1 | Connection Open | Informational | WebSocket connection opened |
| `WebSocketConnectionCloseEvent` | 2 | Connection Close | Informational | WebSocket connection closed |
| `WebSocketMessageSentEvent` | 3 | Message Sent | Informational | WebSocket message sent |
| `WebSocketMessageSentContentEvent` | 4 | Sent Content (Binary) | Verbose | Message content as byte array |
| `WebSocketMessageSentContentTextEvent` | 5 | Sent Content (Text) | Verbose | Message content as text |
| `WebSocketMessageReceivedEvent` | 6 | Message Received | Informational | WebSocket message received |
| `WebSocketMessageReceivedContentEvent` | 7 | Received Content (Binary) | Verbose | Message content as byte array |
| `WebSocketMessageReceivedContentTextEvent` | 8 | Received Content (Text) | Verbose | Message content as text |
| `WebSocketMessageErrorEvent` | 9 | Message Error | Warning | WebSocket error occurred |
| `WebSocketMessageErrorContentEvent` | 10 | Error Content (Binary) | Informational | Error content as byte array |
| `WebSocketMessageErrorContentTextEvent` | 11 | Error Content (Text) | Informational | Error content as text |

### Usage in Tests
```csharp
// ✅ Correct - Use constants
var event = capturedEvents.FirstOrDefault(e => 
    e.EventId == AzureVoiceLiveEventSource.WebSocketMessageSentContentTextEvent);

// ❌ Wrong - Don't use magic numbers
var event = capturedEvents.FirstOrDefault(e => e.EventId == 5);
```

This test suite provides comprehensive coverage of the WebSocket content logging functionality while following Azure SDK testing best practices.